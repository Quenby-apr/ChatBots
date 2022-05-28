using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.Models;
using ChatBots.Properties;
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

namespace ChatBots.Forms
{
    public partial class DiscordChannelForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ChannelLogic logic;
        public string NameChan
        {
            set { nameChan = value; }
        }
        private string nameChan;
        public DiscordChannelForm(ChannelLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            Size = new Size(450, 290);
        }

        private void buttonTools_Click(object sender, EventArgs e)
        {
            if (Size.Width == 450)
            {
                Size = new Size(600, 290);
            }
            else
            {
                Size = new Size(450, 290);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxChannelName.Text) && !string.IsNullOrEmpty(textBoxDiscordID.Text))
            {
                logic.CreateOrUpdate(new ChannelModel
                {
                    ChannelName = textBoxChannelName.Text,
                    UserName = Program.User.Login,
                    DiscordID = textBoxDiscordID.Text,
                    Type = "Twitch",
                    IsRoll = checkBoxRoll.Checked,
                    IsFlip = checkBoxFlip.Checked,
                    IsDino = checkBoxDinoWorld.Checked,
                    IsCleaning = checkBoxCleaning.Checked
                });
                Close();
            }
        }
        private void LoadData()
        {
            if (string.IsNullOrEmpty(nameChan))
            {
                checkBoxRoll.Checked = true;
                checkBoxFlip.Checked = true;
                checkBoxDinoWorld.Checked = true;
                checkBoxCleaning.Checked = true;
            }

            if (!string.IsNullOrEmpty(nameChan))
            {
                try
                {
                    var view = logic.Read(new ChannelModel { ChannelName = nameChan, Type = "Twitch" })?[0];
                    if (view != null)
                    {
                        textBoxChannelName.Text = view.ChannelName;
                        textBoxDiscordID.Text = view.DiscordID;
                        checkBoxRoll.Checked = view.IsRoll;
                        checkBoxFlip.Checked = view.IsFlip;
                        checkBoxDinoWorld.Checked = view.IsDino;
                        checkBoxCleaning.Checked = view.IsCleaning;
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        private void TwitchChannelForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
