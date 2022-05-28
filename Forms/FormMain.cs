using ChatBots.BusinessLogic;
using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.Models;
using ChatBots.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public FormMain(ChannelLogic channelLogic, DinoLogic dinoLogic, GibbetLogic gibbetLogic, CleaningLogic cleaningLogic)
        {
            InitializeComponent();
            this.channelLogic = channelLogic;
            this.dinoLogic = dinoLogic;
            this.gibbetLogic = gibbetLogic;
            this.cleaningLogic = cleaningLogic;
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

        }

        private void buttonUpdateDiscord_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteDiscord_Click(object sender, EventArgs e)
        {

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
                TwitchIRCClient client = new TwitchIRCClient(twitchChannel.ChannelName, "Quenby_Bot",twitchChannel.Token,
                    botFunctions, dinoLogic, cleaningLogic, gibbetLogic);
                client.Connect();
                CancellationTokenSource cancellation = new CancellationTokenSource();
                Task.Run(() => client.Chat(cancellation.Token));
            }
        }
    }
}
