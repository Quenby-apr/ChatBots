namespace ChatBots
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBoxTwitch = new System.Windows.Forms.CheckedListBox();
            this.labelTwitch = new System.Windows.Forms.Label();
            this.checkedListBoxDiscord = new System.Windows.Forms.CheckedListBox();
            this.labelDiscord = new System.Windows.Forms.Label();
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonAddTwitch = new System.Windows.Forms.Button();
            this.buttonDeleteTwitch = new System.Windows.Forms.Button();
            this.buttonUpdateTwitch = new System.Windows.Forms.Button();
            this.buttonAddDiscord = new System.Windows.Forms.Button();
            this.buttonDeleteDiscord = new System.Windows.Forms.Button();
            this.buttonUpdateDiscord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxTwitch
            // 
            this.checkedListBoxTwitch.BackColor = System.Drawing.Color.SkyBlue;
            this.checkedListBoxTwitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxTwitch.FormattingEnabled = true;
            this.checkedListBoxTwitch.Location = new System.Drawing.Point(45, 59);
            this.checkedListBoxTwitch.Name = "checkedListBoxTwitch";
            this.checkedListBoxTwitch.Size = new System.Drawing.Size(254, 227);
            this.checkedListBoxTwitch.TabIndex = 0;
            // 
            // labelTwitch
            // 
            this.labelTwitch.AutoSize = true;
            this.labelTwitch.Location = new System.Drawing.Point(45, 40);
            this.labelTwitch.Name = "labelTwitch";
            this.labelTwitch.Size = new System.Drawing.Size(83, 13);
            this.labelTwitch.TabIndex = 1;
            this.labelTwitch.Text = "Twitch каналы:";
            // 
            // checkedListBoxDiscord
            // 
            this.checkedListBoxDiscord.BackColor = System.Drawing.Color.SkyBlue;
            this.checkedListBoxDiscord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxDiscord.FormattingEnabled = true;
            this.checkedListBoxDiscord.Location = new System.Drawing.Point(361, 59);
            this.checkedListBoxDiscord.Name = "checkedListBoxDiscord";
            this.checkedListBoxDiscord.Size = new System.Drawing.Size(254, 227);
            this.checkedListBoxDiscord.TabIndex = 2;
            // 
            // labelDiscord
            // 
            this.labelDiscord.AutoSize = true;
            this.labelDiscord.Location = new System.Drawing.Point(361, 40);
            this.labelDiscord.Name = "labelDiscord";
            this.labelDiscord.Size = new System.Drawing.Size(87, 13);
            this.labelDiscord.TabIndex = 3;
            this.labelDiscord.Text = "Discord каналы:";
            // 
            // buttonProfile
            // 
            this.buttonProfile.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProfile.Location = new System.Drawing.Point(581, 12);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(98, 28);
            this.buttonProfile.TabIndex = 4;
            this.buttonProfile.Text = "Профиль";
            this.buttonProfile.UseVisualStyleBackColor = false;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // buttonAddTwitch
            // 
            this.buttonAddTwitch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonAddTwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddTwitch.Location = new System.Drawing.Point(45, 311);
            this.buttonAddTwitch.Name = "buttonAddTwitch";
            this.buttonAddTwitch.Size = new System.Drawing.Size(100, 40);
            this.buttonAddTwitch.TabIndex = 5;
            this.buttonAddTwitch.Text = "Добавить канал";
            this.buttonAddTwitch.UseVisualStyleBackColor = false;
            this.buttonAddTwitch.Click += new System.EventHandler(this.buttonAddTwitch_Click);
            // 
            // buttonDeleteTwitch
            // 
            this.buttonDeleteTwitch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonDeleteTwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteTwitch.Location = new System.Drawing.Point(199, 311);
            this.buttonDeleteTwitch.Name = "buttonDeleteTwitch";
            this.buttonDeleteTwitch.Size = new System.Drawing.Size(100, 40);
            this.buttonDeleteTwitch.TabIndex = 6;
            this.buttonDeleteTwitch.Text = "Удалить канал";
            this.buttonDeleteTwitch.UseVisualStyleBackColor = false;
            this.buttonDeleteTwitch.Click += new System.EventHandler(this.buttonDeleteTwitch_Click);
            // 
            // buttonUpdateTwitch
            // 
            this.buttonUpdateTwitch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonUpdateTwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateTwitch.Location = new System.Drawing.Point(119, 357);
            this.buttonUpdateTwitch.Name = "buttonUpdateTwitch";
            this.buttonUpdateTwitch.Size = new System.Drawing.Size(100, 40);
            this.buttonUpdateTwitch.TabIndex = 7;
            this.buttonUpdateTwitch.Text = "Обновить канал";
            this.buttonUpdateTwitch.UseVisualStyleBackColor = false;
            this.buttonUpdateTwitch.Click += new System.EventHandler(this.buttonUpdateTwitch_Click);
            // 
            // buttonAddDiscord
            // 
            this.buttonAddDiscord.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonAddDiscord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddDiscord.Location = new System.Drawing.Point(361, 311);
            this.buttonAddDiscord.Name = "buttonAddDiscord";
            this.buttonAddDiscord.Size = new System.Drawing.Size(100, 40);
            this.buttonAddDiscord.TabIndex = 8;
            this.buttonAddDiscord.Text = "Добавить канал";
            this.buttonAddDiscord.UseVisualStyleBackColor = false;
            this.buttonAddDiscord.Click += new System.EventHandler(this.buttonAddDiscord_Click);
            // 
            // buttonDeleteDiscord
            // 
            this.buttonDeleteDiscord.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonDeleteDiscord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteDiscord.Location = new System.Drawing.Point(515, 311);
            this.buttonDeleteDiscord.Name = "buttonDeleteDiscord";
            this.buttonDeleteDiscord.Size = new System.Drawing.Size(100, 40);
            this.buttonDeleteDiscord.TabIndex = 9;
            this.buttonDeleteDiscord.Text = "Удалить канал";
            this.buttonDeleteDiscord.UseVisualStyleBackColor = false;
            this.buttonDeleteDiscord.Click += new System.EventHandler(this.buttonDeleteDiscord_Click);
            // 
            // buttonUpdateDiscord
            // 
            this.buttonUpdateDiscord.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonUpdateDiscord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateDiscord.Location = new System.Drawing.Point(441, 357);
            this.buttonUpdateDiscord.Name = "buttonUpdateDiscord";
            this.buttonUpdateDiscord.Size = new System.Drawing.Size(100, 40);
            this.buttonUpdateDiscord.TabIndex = 10;
            this.buttonUpdateDiscord.Text = "Обновить канал";
            this.buttonUpdateDiscord.UseVisualStyleBackColor = false;
            this.buttonUpdateDiscord.Click += new System.EventHandler(this.buttonUpdateDiscord_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(691, 532);
            this.Controls.Add(this.buttonUpdateDiscord);
            this.Controls.Add(this.buttonDeleteDiscord);
            this.Controls.Add(this.buttonAddDiscord);
            this.Controls.Add(this.buttonUpdateTwitch);
            this.Controls.Add(this.buttonDeleteTwitch);
            this.Controls.Add(this.buttonAddTwitch);
            this.Controls.Add(this.buttonProfile);
            this.Controls.Add(this.labelDiscord);
            this.Controls.Add(this.checkedListBoxDiscord);
            this.Controls.Add(this.labelTwitch);
            this.Controls.Add(this.checkedListBoxTwitch);
            this.Name = "FormMain";
            this.Text = "Основное окно";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxTwitch;
        private System.Windows.Forms.Label labelTwitch;
        private System.Windows.Forms.CheckedListBox checkedListBoxDiscord;
        private System.Windows.Forms.Label labelDiscord;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Button buttonAddTwitch;
        private System.Windows.Forms.Button buttonDeleteTwitch;
        private System.Windows.Forms.Button buttonUpdateTwitch;
        private System.Windows.Forms.Button buttonAddDiscord;
        private System.Windows.Forms.Button buttonDeleteDiscord;
        private System.Windows.Forms.Button buttonUpdateDiscord;
    }
}

