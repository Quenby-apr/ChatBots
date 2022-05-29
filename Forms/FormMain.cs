using ChatBots.BusinessLogic;
using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.Models;
using ChatBots.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ChatBots
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ChannelLogic channelLogic;
        private readonly DinoLogic dinoLogic;
        private readonly GibbetLogic gibbetLogic;
        private readonly CleaningLogic cleaningLogic;
        private readonly UserLogic userLogic;
        CancellationTokenSource cancellation;
        public FormMain(ChannelLogic channelLogic, DinoLogic dinoLogic, GibbetLogic gibbetLogic, CleaningLogic cleaningLogic, UserLogic userLogic)
        {
            InitializeComponent();
            this.channelLogic = channelLogic;
            this.dinoLogic = dinoLogic;
            this.gibbetLogic = gibbetLogic;
            this.cleaningLogic = cleaningLogic;
            this.userLogic = userLogic;
            cancellation = new CancellationTokenSource();
        }

        private void buttonAddTwitch_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<TwitchChannelForm>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonDeleteTwitch_Click(object sender, EventArgs e)
        {
            channelLogic.Delete(new ChannelModel
            {
                ChannelName = ((ChannelModel)listBoxTwitch.SelectedValue).ChannelName,
                Type = "Twitch"
            });
            var channels = Program.User.TwitchChannelNames.ToList();
            channels.Remove(((ChannelModel)listBoxTwitch.SelectedValue).ChannelName);
            Program.User.TwitchChannelNames = channels.ToArray();
            userLogic.Update(Program.User);
            LoadData();
        }

        private void buttonUpdateTwitch_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<TwitchChannelForm>();
            form.NameChan = ((ChannelModel) listBoxTwitch.SelectedValue).ChannelName;
            form.ShowDialog();
            LoadData();
        }

        private void buttonAddDiscord_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<DiscordChannelForm>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonUpdateDiscord_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<DiscordChannelForm>();
            form.NameChan = ((ChannelModel)listBoxDiscord.SelectedValue).ChannelName;
            form.ShowDialog();
            LoadData();
        }

        private void buttonDeleteDiscord_Click(object sender, EventArgs e)
        {
            channelLogic.Delete(new ChannelModel
            {
                ChannelName = ((ChannelModel)listBoxTwitch.SelectedValue).ChannelName,
                Type = "Discord",
                DiscordID = ((ChannelModel)listBoxTwitch.SelectedValue).DiscordID
            });
            var channels = Program.User.TwitchChannelNames.ToList();
            channels.Remove(((ChannelModel)listBoxTwitch.SelectedValue).ChannelName);
            Program.User.TwitchChannelNames = channels.ToArray();
            userLogic.Update(Program.User);
            LoadData();
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ProfileForm>();
            form.ShowDialog();
            LoadData();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellation.Cancel();         
            if (Program.User != null)
            {
                Application.Exit();
            }
        }

        private void LoadData()
        {
            if (Program.User == null)
            {
                var form = Container.Resolve<SignInForm>();
                form.Show();
                Close();
                return;
            }
            try
            {
                var listT = channelLogic.Read(new ChannelModel
                {
                    Type = "Twitch",
                    UserName = Program.User.Login
                });

                if (listT != null)
                {
                    listBoxTwitch.DataSource = listT;
                }
                var listD = channelLogic.Read(new ChannelModel
                {
                    Type = "Discord",
                    UserName = Program.User.Login
                });

                if (listD != null)
                {
                    listBoxDiscord.DataSource = listD;
                }
                Refresh();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Program.IsDiscordConnect)
                {
                    DiscordClient disc = new DiscordClient(dinoLogic);
                    disc.RunBotAsync(cancellation.Token).GetAwaiter().GetResult();
                    Program.IsDiscordConnect = true;
                }

                buttonConnect.Enabled = false;
                var listT = channelLogic.Read(new ChannelModel
                {
                    Type = "Twitch",
                    UserName = Program.User.Login
                });
                foreach (var twitchChannel in listT)
                {
                    List<bool> botFunctions = new List<bool>()
                {
                    twitchChannel.IsRoll,
                    twitchChannel.IsFlip,
                    twitchChannel.IsDino,
                    twitchChannel.IsGibbet,
                    twitchChannel.IsCleaning
                };
                    TwitchIRCClient client = new TwitchIRCClient(twitchChannel.ChannelName, "Quenby_Bot", twitchChannel.Token,
                        botFunctions, dinoLogic, gibbetLogic);
                    client.Connect();
                    Task.Run(() => client.Chat(cancellation.Token));
                    Task.Run(() => client.InitGibbet(cancellation.Token));
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
