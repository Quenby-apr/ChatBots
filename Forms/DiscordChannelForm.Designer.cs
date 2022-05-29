namespace ChatBots.Forms
{
    partial class DiscordChannelForm
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
            this.labelDiscordID = new System.Windows.Forms.Label();
            this.textBoxDiscordID = new System.Windows.Forms.TextBox();
            this.buttonTools = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxRoll = new System.Windows.Forms.CheckBox();
            this.checkBoxFlip = new System.Windows.Forms.CheckBox();
            this.checkBoxDinoWorld = new System.Windows.Forms.CheckBox();
            this.checkBoxCleaning = new System.Windows.Forms.CheckBox();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelChannelName
            // 
            this.labelChannelName.AutoSize = true;
            this.labelChannelName.Location = new System.Drawing.Point(12, 25);
            this.labelChannelName.Name = "labelChannelName";
            this.labelChannelName.Size = new System.Drawing.Size(153, 13);
            this.labelChannelName.TabIndex = 0;
            this.labelChannelName.Text = "Введите имя Discord канала:";
            // 
            // textBoxChannelName
            // 
            this.textBoxChannelName.BackColor = System.Drawing.Color.PowderBlue;
            this.textBoxChannelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxChannelName.Location = new System.Drawing.Point(12, 41);
            this.textBoxChannelName.Name = "textBoxChannelName";
            this.textBoxChannelName.Size = new System.Drawing.Size(271, 20);
            this.textBoxChannelName.TabIndex = 1;
            // 
            // labelDiscordID
            // 
            this.labelDiscordID.AutoSize = true;
            this.labelDiscordID.Location = new System.Drawing.Point(12, 116);
            this.labelDiscordID.Name = "labelDiscordID";
            this.labelDiscordID.Size = new System.Drawing.Size(150, 13);
            this.labelDiscordID.TabIndex = 3;
            this.labelDiscordID.Text = "Введите ID дискорд канала:";
            // 
            // textBoxDiscordID
            // 
            this.textBoxDiscordID.BackColor = System.Drawing.Color.PowderBlue;
            this.textBoxDiscordID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDiscordID.Location = new System.Drawing.Point(12, 132);
            this.textBoxDiscordID.Name = "textBoxDiscordID";
            this.textBoxDiscordID.Size = new System.Drawing.Size(271, 20);
            this.textBoxDiscordID.TabIndex = 4;
            // 
            // buttonTools
            // 
            this.buttonTools.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTools.Location = new System.Drawing.Point(342, 103);
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
            this.buttonSave.Location = new System.Drawing.Point(71, 191);
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
            this.checkBoxRoll.Location = new System.Drawing.Point(446, 62);
            this.checkBoxRoll.Name = "checkBoxRoll";
            this.checkBoxRoll.Size = new System.Drawing.Size(42, 17);
            this.checkBoxRoll.TabIndex = 7;
            this.checkBoxRoll.Text = "!roll";
            this.checkBoxRoll.UseVisualStyleBackColor = true;
            // 
            // checkBoxFlip
            // 
            this.checkBoxFlip.AutoSize = true;
            this.checkBoxFlip.Location = new System.Drawing.Point(446, 85);
            this.checkBoxFlip.Name = "checkBoxFlip";
            this.checkBoxFlip.Size = new System.Drawing.Size(42, 17);
            this.checkBoxFlip.TabIndex = 8;
            this.checkBoxFlip.Text = "!flip";
            this.checkBoxFlip.UseVisualStyleBackColor = true;
            // 
            // checkBoxDinoWorld
            // 
            this.checkBoxDinoWorld.AutoSize = true;
            this.checkBoxDinoWorld.Location = new System.Drawing.Point(446, 109);
            this.checkBoxDinoWorld.Name = "checkBoxDinoWorld";
            this.checkBoxDinoWorld.Size = new System.Drawing.Size(76, 17);
            this.checkBoxDinoWorld.TabIndex = 9;
            this.checkBoxDinoWorld.Text = "DinoWorld";
            this.checkBoxDinoWorld.UseVisualStyleBackColor = true;
            // 
            // checkBoxCleaning
            // 
            this.checkBoxCleaning.AutoSize = true;
            this.checkBoxCleaning.Location = new System.Drawing.Point(446, 132);
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
            this.labelError.Location = new System.Drawing.Point(12, 78);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 12;
            // 
            // DiscordChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(304, 251);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.checkBoxCleaning);
            this.Controls.Add(this.checkBoxDinoWorld);
            this.Controls.Add(this.checkBoxFlip);
            this.Controls.Add(this.checkBoxRoll);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonTools);
            this.Controls.Add(this.textBoxDiscordID);
            this.Controls.Add(this.labelDiscordID);
            this.Controls.Add(this.textBoxChannelName);
            this.Controls.Add(this.labelChannelName);
            this.Name = "DiscordChannelForm";
            this.Text = "ChannelForm";
            this.Load += new System.EventHandler(this.DiscordChannelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChannelName;
        private System.Windows.Forms.TextBox textBoxChannelName;
        private System.Windows.Forms.Label labelDiscordID;
        private System.Windows.Forms.TextBox textBoxDiscordID;
        private System.Windows.Forms.Button buttonTools;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxRoll;
        private System.Windows.Forms.CheckBox checkBoxFlip;
        private System.Windows.Forms.CheckBox checkBoxDinoWorld;
        private System.Windows.Forms.CheckBox checkBoxCleaning;
        private System.Windows.Forms.Label labelError;
    }
}