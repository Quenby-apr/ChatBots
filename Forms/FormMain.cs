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
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ChatBots
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ChannelLogic logic;
        public FormMain(ChannelLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonAddTwitch_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<TwitchChannelForm>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonDeleteTwitch_Click(object sender, EventArgs e)
        {
            logic.Delete(new ChannelModel
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

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LoadData()
        {
            try
            {
                var listT = logic.Read(new ChannelModel
                {
                    Type = "Twitch",
                    UserName = Program.User.Login
                });

                if (listT != null)
                {
                    listBoxTwitch.DataSource = listT;
                }
                var listD = logic.Read(new ChannelModel
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

        }
    }
}
