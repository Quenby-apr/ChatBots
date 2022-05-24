namespace ChatBots.Forms
{
    partial class SignUpForm
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
            this.textBoxPassword1 = new System.Windows.Forms.TextBox();
            this.labelPassword1 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxPassword2 = new System.Windows.Forms.TextBox();
            this.labelPassword2 = new System.Windows.Forms.Label();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelLoginError = new System.Windows.Forms.Label();
            this.labelPassword1Error = new System.Windows.Forms.Label();
            this.labelPassword2Error = new System.Windows.Forms.Label();
            this.labelMatchError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPassword1
            // 
            this.textBoxPassword1.BackColor = System.Drawing.Color.PowderBlue;
            this.textBoxPassword1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword1.Location = new System.Drawing.Point(37, 145);
            this.textBoxPassword1.Name = "textBoxPassword1";
            this.textBoxPassword1.Size = new System.Drawing.Size(195, 20);
            this.textBoxPassword1.TabIndex = 2;
            // 
            // labelPassword1
            // 
            this.labelPassword1.AutoSize = true;
            this.labelPassword1.Location = new System.Drawing.Point(37, 126);
            this.labelPassword1.Name = "labelPassword1";
            this.labelPassword1.Size = new System.Drawing.Size(91, 13);
            this.labelPassword1.TabIndex = 1;
            this.labelPassword1.Text = "Введите пароль:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BackColor = System.Drawing.Color.PowderBlue;
            this.textBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLogin.Location = new System.Drawing.Point(37, 64);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(195, 20);
            this.textBoxLogin.TabIndex = 0;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(37, 48);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(84, 13);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "Введите логин:";
            // 
            // textBoxPassword2
            // 
            this.textBoxPassword2.BackColor = System.Drawing.Color.PowderBlue;
            this.textBoxPassword2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword2.Location = new System.Drawing.Point(37, 225);
            this.textBoxPassword2.Name = "textBoxPassword2";
            this.textBoxPassword2.Size = new System.Drawing.Size(195, 20);
            this.textBoxPassword2.TabIndex = 4;
            // 
            // labelPassword2
            // 
            this.labelPassword2.AutoSize = true;
            this.labelPassword2.Location = new System.Drawing.Point(37, 209);
            this.labelPassword2.Name = "labelPassword2";
            this.labelPassword2.Size = new System.Drawing.Size(103, 13);
            this.labelPassword2.TabIndex = 5;
            this.labelPassword2.Text = "Повторите пароль:";
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignUp.Location = new System.Drawing.Point(70, 308);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(132, 38);
            this.buttonSignUp.TabIndex = 6;
            this.buttonSignUp.Text = "Зарегистрироваться";
            this.buttonSignUp.UseVisualStyleBackColor = false;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(83, 364);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(104, 35);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelLoginError
            // 
            this.labelLoginError.AutoSize = true;
            this.labelLoginError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLoginError.ForeColor = System.Drawing.Color.Red;
            this.labelLoginError.Location = new System.Drawing.Point(45, 95);
            this.labelLoginError.Name = "labelLoginError";
            this.labelLoginError.Size = new System.Drawing.Size(143, 13);
            this.labelLoginError.TabIndex = 8;
            this.labelLoginError.Text = "Поле логина не заполнено";
            this.labelLoginError.Visible = false;
            // 
            // labelPassword1Error
            // 
            this.labelPassword1Error.AutoSize = true;
            this.labelPassword1Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword1Error.ForeColor = System.Drawing.Color.Red;
            this.labelPassword1Error.Location = new System.Drawing.Point(45, 180);
            this.labelPassword1Error.Name = "labelPassword1Error";
            this.labelPassword1Error.Size = new System.Drawing.Size(144, 13);
            this.labelPassword1Error.TabIndex = 9;
            this.labelPassword1Error.Text = "Поле пароля не заполнено";
            this.labelPassword1Error.Visible = false;
            // 
            // labelPassword2Error
            // 
            this.labelPassword2Error.AutoSize = true;
            this.labelPassword2Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword2Error.ForeColor = System.Drawing.Color.Red;
            this.labelPassword2Error.Location = new System.Drawing.Point(45, 259);
            this.labelPassword2Error.Name = "labelPassword2Error";
            this.labelPassword2Error.Size = new System.Drawing.Size(188, 13);
            this.labelPassword2Error.TabIndex = 10;
            this.labelPassword2Error.Text = "Поле повтора пароля не заполнено";
            this.labelPassword2Error.Visible = false;
            // 
            // labelMatchError
            // 
            this.labelMatchError.AutoSize = true;
            this.labelMatchError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMatchError.ForeColor = System.Drawing.Color.Red;
            this.labelMatchError.Location = new System.Drawing.Point(44, 259);
            this.labelMatchError.Name = "labelMatchError";
            this.labelMatchError.Size = new System.Drawing.Size(118, 13);
            this.labelMatchError.TabIndex = 11;
            this.labelMatchError.Text = "Пароли не совпадают";
            this.labelMatchError.Visible = false;
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(305, 441);
            this.Controls.Add(this.labelMatchError);
            this.Controls.Add(this.labelPassword2Error);
            this.Controls.Add(this.labelPassword1Error);
            this.Controls.Add(this.labelLoginError);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSignUp);
            this.Controls.Add(this.labelPassword2);
            this.Controls.Add(this.textBoxPassword2);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelPassword1);
            this.Controls.Add(this.textBoxPassword1);
            this.Name = "SignUpForm";
            this.Text = "Форма регистрации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword1;
        private System.Windows.Forms.Label labelPassword1;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxPassword2;
        private System.Windows.Forms.Label labelPassword2;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelLoginError;
        private System.Windows.Forms.Label labelPassword1Error;
        private System.Windows.Forms.Label labelPassword2Error;
        private System.Windows.Forms.Label labelMatchError;
    }
}