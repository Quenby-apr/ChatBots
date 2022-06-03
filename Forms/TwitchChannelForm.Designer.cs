namespace ChatBots.Forms
{
    partial class TwitchChannelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelChannelName = new System.Windows.Forms.Label();
            this.textBoxChannelName = new System.Windows.Forms.TextBox();
            this.checkBoxCustomBot = new System.Windows.Forms.CheckBox();
            this.labelOAuthToken = new System.Windows.Forms.Label();
            this.textBoxOAuthToken = new System.Windows.Forms.TextBox();
            this.buttonTools = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxRoll = new System.Windows.Forms.CheckBox();
            this.checkBoxFlip = new System.Windows.Forms.CheckBox();
            this.checkBoxDinoWorld = new System.Windows.Forms.CheckBox();
            this.checkBoxGibbet = new System.Windows.Forms.CheckBox();
            this.checkBoxCleaning = new System.Windows.Forms.CheckBox();
            this.labelError = new System.Windows.Forms.Label();
            this.checkBoxCustomCommands = new System.Windows.Forms.CheckBox();
            this.listBoxCommands = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.textBoxCommandName = new System.Windows.Forms.TextBox();
            this.labelCommandName = new System.Windows.Forms.Label();
            this.labelAnswerText = new System.Windows.Forms.Label();
            this.textBoxCommandAnswer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelChannelName
            // 
            this.labelChannelName.AutoSize = true;
            this.labelChannelName.Location = new System.Drawing.Point(12, 73);
            this.labelChannelName.Name = "labelChannelName";
            this.labelChannelName.Size = new System.Drawing.Size(149, 13);
            this.labelChannelName.TabIndex = 0;
            this.labelChannelName.Text = "Введите имя Twitch канала:";
            // 
            // textBoxChannelName
            // 
            this.textBoxChannelName.BackColor = System.Drawing.Color.PowderBlue;
            this.textBoxChannelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxChannelName.Location = new System.Drawing.Point(12, 89);
            this.textBoxChannelName.Name = "textBoxChannelName";
            this.textBoxChannelName.Size = new System.Drawing.Size(271, 20);
            this.textBoxChannelName.TabIndex = 1;
            // 
            // checkBoxCustomBot
            // 
            this.checkBoxCustomBot.AutoSize = true;
            this.checkBoxCustomBot.BackColor = System.Drawing.Color.LightBlue;
            this.checkBoxCustomBot.Location = new System.Drawing.Point(12, 151);
            this.checkBoxCustomBot.Name = "checkBoxCustomBot";
            this.checkBoxCustomBot.Size = new System.Drawing.Size(197, 17);
            this.checkBoxCustomBot.TabIndex = 2;
            this.checkBoxCustomBot.Text = "Использовать стандартного бота";
            this.checkBoxCustomBot.UseVisualStyleBackColor = false;
            this.checkBoxCustomBot.CheckedChanged += new System.EventHandler(this.checkBoxCustomBot_CheckedChanged);
            // 
            // labelOAuthToken
            // 
            this.labelOAuthToken.AutoSize = true;
            this.labelOAuthToken.Location = new System.Drawing.Point(12, 175);
            this.labelOAuthToken.Name = "labelOAuthToken";
            this.labelOAuthToken.Size = new System.Drawing.Size(143, 13);
            this.labelOAuthToken.TabIndex = 3;
            this.labelOAuthToken.Text = "Введите OAuth токен бота:";
            // 
            // textBoxOAuthToken
            // 
            this.textBoxOAuthToken.BackColor = System.Drawing.Color.PowderBlue;
            this.textBoxOAuthToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOAuthToken.Location = new System.Drawing.Point(12, 191);
            this.textBoxOAuthToken.Name = "textBoxOAuthToken";
            this.textBoxOAuthToken.ReadOnly = true;
            this.textBoxOAuthToken.Size = new System.Drawing.Size(271, 20);
            this.textBoxOAuthToken.TabIndex = 4;
            // 
            // buttonTools
            // 
            this.buttonTools.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTools.Location = new System.Drawing.Point(310, 151);
            this.buttonTools.Name = "buttonTools";
            this.buttonTools.Size = new System.Drawing.Size(75, 23);
            this.buttonTools.TabIndex = 5;
            this.buttonTools.Text = "Настройки";
            this.buttonTools.UseVisualStyleBackColor = false;
            this.buttonTools.Click += new System.EventHandler(this.buttonTools_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(55, 312);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(154, 38);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxRoll
            // 
            this.checkBoxRoll.AutoSize = true;
            this.checkBoxRoll.Location = new System.Drawing.Point(412, 99);
            this.checkBoxRoll.Name = "checkBoxRoll";
            this.checkBoxRoll.Size = new System.Drawing.Size(42, 17);
            this.checkBoxRoll.TabIndex = 7;
            this.checkBoxRoll.Text = "!roll";
            this.checkBoxRoll.UseVisualStyleBackColor = true;
            // 
            // checkBoxFlip
            // 
            this.checkBoxFlip.AutoSize = true;
            this.checkBoxFlip.Location = new System.Drawing.Point(412, 122);
            this.checkBoxFlip.Name = "checkBoxFlip";
            this.checkBoxFlip.Size = new System.Drawing.Size(42, 17);
            this.checkBoxFlip.TabIndex = 8;
            this.checkBoxFlip.Text = "!flip";
            this.checkBoxFlip.UseVisualStyleBackColor = true;
            // 
            // checkBoxDinoWorld
            // 
            this.checkBoxDinoWorld.AutoSize = true;
            this.checkBoxDinoWorld.Location = new System.Drawing.Point(412, 146);
            this.checkBoxDinoWorld.Name = "checkBoxDinoWorld";
            this.checkBoxDinoWorld.Size = new System.Drawing.Size(76, 17);
            this.checkBoxDinoWorld.TabIndex = 9;
            this.checkBoxDinoWorld.Text = "DinoWorld";
            this.checkBoxDinoWorld.UseVisualStyleBackColor = true;
            // 
            // checkBoxGibbet
            // 
            this.checkBoxGibbet.AutoSize = true;
            this.checkBoxGibbet.Location = new System.Drawing.Point(412, 170);
            this.checkBoxGibbet.Name = "checkBoxGibbet";
            this.checkBoxGibbet.Size = new System.Drawing.Size(75, 17);
            this.checkBoxGibbet.TabIndex = 10;
            this.checkBoxGibbet.Text = "Виселица";
            this.checkBoxGibbet.UseVisualStyleBackColor = true;
            // 
            // checkBoxCleaning
            // 
            this.checkBoxCleaning.AutoSize = true;
            this.checkBoxCleaning.Location = new System.Drawing.Point(412, 194);
            this.checkBoxCleaning.Name = "checkBoxCleaning";
            this.checkBoxCleaning.Size = new System.Drawing.Size(133, 17);
            this.checkBoxCleaning.TabIndex = 11;
            this.checkBoxCleaning.Text = "Удаление банвордов";
            this.checkBoxCleaning.UseVisualStyleBackColor = true;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(15, 116);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 12;
            // 
            // checkBoxCustomCommands
            // 
            this.checkBoxCustomCommands.AutoSize = true;
            this.checkBoxCustomCommands.Location = new System.Drawing.Point(412, 218);
            this.checkBoxCustomCommands.Name = "checkBoxCustomCommands";
            this.checkBoxCustomCommands.Size = new System.Drawing.Size(100, 17);
            this.checkBoxCustomCommands.TabIndex = 13;
            this.checkBoxCustomCommands.Text = "Свои команды";
            this.checkBoxCustomCommands.UseVisualStyleBackColor = true;
            this.checkBoxCustomCommands.CheckedChanged += new System.EventHandler(this.checkBoxCustomCommands_CheckedChanged);
            // 
            // listBoxCommands
            // 
            this.listBoxCommands.BackColor = System.Drawing.Color.SkyBlue;
            this.listBoxCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxCommands.FormattingEnabled = true;
            this.listBoxCommands.ItemHeight = 16;
            this.listBoxCommands.Location = new System.Drawing.Point(551, 218);
            this.listBoxCommands.Name = "listBoxCommands";
            this.listBoxCommands.Size = new System.Drawing.Size(216, 130);
            this.listBoxCommands.TabIndex = 14;
            this.listBoxCommands.SelectedIndexChanged += new System.EventHandler(this.listBoxCommands_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Location = new System.Drawing.Point(786, 222);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 38);
            this.buttonAdd.TabIndex = 15;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(786, 310);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 38);
            this.buttonDelete.TabIndex = 16;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChange.Location = new System.Drawing.Point(786, 266);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 38);
            this.buttonChange.TabIndex = 17;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // textBoxCommandName
            // 
            this.textBoxCommandName.BackColor = System.Drawing.Color.PowderBlue;
            this.textBoxCommandName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCommandName.Location = new System.Drawing.Point(551, 43);
            this.textBoxCommandName.Name = "textBoxCommandName";
            this.textBoxCommandName.Size = new System.Drawing.Size(216, 20);
            this.textBoxCommandName.TabIndex = 18;
            // 
            // labelCommandName
            // 
            this.labelCommandName.AutoSize = true;
            this.labelCommandName.Location = new System.Drawing.Point(548, 27);
            this.labelCommandName.Name = "labelCommandName";
            this.labelCommandName.Size = new System.Drawing.Size(109, 13);
            this.labelCommandName.TabIndex = 19;
            this.labelCommandName.Text = "Название команды:";
            // 
            // labelAnswerText
            // 
            this.labelAnswerText.AutoSize = true;
            this.labelAnswerText.Location = new System.Drawing.Point(551, 99);
            this.labelAnswerText.Name = "labelAnswerText";
            this.labelAnswerText.Size = new System.Drawing.Size(77, 13);
            this.labelAnswerText.TabIndex = 20;
            this.labelAnswerText.Text = "Текст ответа:";
            // 
            // textBoxCommandAnswer
            // 
            this.textBoxCommandAnswer.BackColor = System.Drawing.Color.PowderBlue;
            this.textBoxCommandAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCommandAnswer.Location = new System.Drawing.Point(551, 115);
            this.textBoxCommandAnswer.Multiline = true;
            this.textBoxCommandAnswer.Name = "textBoxCommandAnswer";
            this.textBoxCommandAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCommandAnswer.Size = new System.Drawing.Size(216, 96);
            this.textBoxCommandAnswer.TabIndex = 21;
            // 
            // TwitchChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(874, 361);
            this.Controls.Add(this.textBoxCommandAnswer);
            this.Controls.Add(this.labelAnswerText);
            this.Controls.Add(this.labelCommandName);
            this.Controls.Add(this.textBoxCommandName);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxCommands);
            this.Controls.Add(this.checkBoxCustomCommands);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.checkBoxCleaning);
            this.Controls.Add(this.checkBoxGibbet);
            this.Controls.Add(this.checkBoxDinoWorld);
            this.Controls.Add(this.checkBoxFlip);
            this.Controls.Add(this.checkBoxRoll);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonTools);
            this.Controls.Add(this.textBoxOAuthToken);
            this.Controls.Add(this.labelOAuthToken);
            this.Controls.Add(this.checkBoxCustomBot);
            this.Controls.Add(this.textBoxChannelName);
            this.Controls.Add(this.labelChannelName);
            this.Name = "TwitchChannelForm";
            this.Text = "ChannelForm";
            this.Load += new System.EventHandler(this.TwitchChannelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChannelName;
        private System.Windows.Forms.TextBox textBoxChannelName;
        private System.Windows.Forms.CheckBox checkBoxCustomBot;
        private System.Windows.Forms.Label labelOAuthToken;
        private System.Windows.Forms.TextBox textBoxOAuthToken;
        private System.Windows.Forms.Button buttonTools;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxRoll;
        private System.Windows.Forms.CheckBox checkBoxFlip;
        private System.Windows.Forms.CheckBox checkBoxDinoWorld;
        private System.Windows.Forms.CheckBox checkBoxGibbet;
        private System.Windows.Forms.CheckBox checkBoxCleaning;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.CheckBox checkBoxCustomCommands;
        private System.Windows.Forms.ListBox listBoxCommands;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.TextBox textBoxCommandName;
        private System.Windows.Forms.Label labelCommandName;
        private System.Windows.Forms.Label labelAnswerText;
        private System.Windows.Forms.TextBox textBoxCommandAnswer;
    }
}