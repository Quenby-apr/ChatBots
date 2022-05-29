using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace ChatBots.Forms
{
    public partial class DiscordChannelForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ChannelLogic channelLogic;
        private readonly UserLogic userLogic;
        public string NameChan
        {
            set { nameChan = value; }
        }
        private string nameChan;
        public DiscordChannelForm(ChannelLogic channelLogic, UserLogic userLogic)
        {
            InitializeComponent();
            this.channelLogic = channelLogic;
            this.userLogic = userLogic;
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
            try
            {
                if (!string.IsNullOrEmpty(textBoxChannelName.Text) && !string.IsNullOrEmpty(textBoxDiscordID.Text))
                {
                    channelLogic.CreateOrUpdate(new ChannelModel
                    {
                        ChannelName = textBoxChannelName.Text,
                        UserName = Program.User.Login,
                        DiscordID = textBoxDiscordID.Text,
                        Type = "Discord",
                        IsRoll = checkBoxRoll.Checked,
                        IsFlip = checkBoxFlip.Checked,
                        IsDino = checkBoxDinoWorld.Checked,
                        IsCleaning = checkBoxCleaning.Checked
                    });
                    List<string> channels = new List<string>();
                    if (Program.User.DiscordChannelNames != null)
                        channels = Program.User.DiscordChannelNames.ToList();
                    channels.Add(textBoxChannelName.Text);
                    Program.User.DiscordChannelNames = channels.ToArray();
                    if (string.IsNullOrEmpty(nameChan))
                    {
                        userLogic.Update(new UserViewModel()
                        {
                            Login = Program.User.Login,
                            Password = Program.User.Password,
                            DiscordChannelNames = channels.ToArray(),
                            TwitchChannelNames = Program.User.TwitchChannelNames
                        });
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
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
                    var view = channelLogic.Read(new ChannelModel { ChannelName = nameChan, Type = "Discord" })?[0];
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
                    labelError.Text = ex.Message;
                }
            }
        }

        private void DiscordChannelForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
