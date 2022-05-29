﻿using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.Models;
using ChatBots.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace ChatBots.Forms
{
    public partial class TwitchChannelForm : Form
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
        public TwitchChannelForm(ChannelLogic channelLogic, UserLogic userLogic)
        {
            InitializeComponent();
            this.channelLogic = channelLogic;
            this.userLogic = userLogic;
            Size = new Size(450, 290);
        }

        private void checkBoxCustomBot_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCustomBot.Checked == true)
            {
                textBoxOAuthToken.Enabled = false;
                textBoxOAuthToken.Text = Settings.TwitchBotToken;
            }
            else 
            {
                textBoxOAuthToken.Enabled = true;
            }
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
                if (!string.IsNullOrEmpty(textBoxChannelName.Text) && !string.IsNullOrEmpty(textBoxOAuthToken.Text))
                {
                    channelLogic.CreateOrUpdate(new ChannelModel
                    {
                        ChannelName = textBoxChannelName.Text,
                        UserName = Program.User.Login,
                        Token = textBoxOAuthToken.Text,
                        Default = checkBoxCustomBot.Checked,
                        Type = "Twitch",
                        IsRoll = checkBoxRoll.Checked,
                        IsFlip = checkBoxFlip.Checked,
                        IsDino = checkBoxDinoWorld.Checked,
                        IsGibbet = checkBoxGibbet.Checked,
                        IsCleaning = checkBoxCleaning.Checked
                    });
                    List<string> channels = new List<string>();
                    if (Program.User.TwitchChannelNames != null)
                        channels = Program.User.TwitchChannelNames.ToList();
                    channels.Add(textBoxChannelName.Text);
                    Program.User.TwitchChannelNames = channels.ToArray();
                    if (string.IsNullOrEmpty(nameChan))
                    {
                        userLogic.Update(new UserViewModel()
                        {
                            Login = Program.User.Login,
                            Password = Program.User.Password,
                            DiscordChannelNames = Program.User.DiscordChannelNames,
                            TwitchChannelNames = channels.ToArray()
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
                checkBoxCustomBot.Checked = true;
                textBoxOAuthToken.Text = Settings.TwitchBotToken;
                checkBoxRoll.Checked = true;
                checkBoxFlip.Checked = true;
                checkBoxDinoWorld.Checked = true;
                checkBoxGibbet.Checked = true;
                checkBoxCleaning.Checked = true;
            }

            if (!string.IsNullOrEmpty(nameChan))
            {
                try
                {
                    var view = channelLogic.Read(new ChannelModel { ChannelName = nameChan, Type = "Twitch" })?[0];
                    if (view != null)
                    {
                        textBoxChannelName.Text = view.ChannelName;
                        textBoxChannelName.Enabled = false;
                        checkBoxCustomBot.Checked = view.Default;
                        textBoxOAuthToken.Text = view.Token;
                        checkBoxRoll.Checked = view.IsRoll;
                        checkBoxFlip.Checked = view.IsFlip;
                        checkBoxDinoWorld.Checked = view.IsDino;
                        checkBoxGibbet.Checked = view.IsGibbet;
                        checkBoxCleaning.Checked = view.IsCleaning;
                    }

                }
                catch (Exception ex)
                {
                    labelError.Text = ex.Message;
                }
            }
        }

        private void TwitchChannelForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
