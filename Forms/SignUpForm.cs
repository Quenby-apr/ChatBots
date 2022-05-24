using ChatBots.BusinessLogic.BusinessLogic;
using ChatBots.BusinessLogic.Models;
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
    public partial class SignUpForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly UserLogic logic;
        public SignUpForm(UserLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            clearForm();
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                labelLoginError.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword1.Text))
            {
                labelPassword1Error.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword2.Text))
            {
                labelPassword2Error.Visible = true;
                return;
            }
            if (!textBoxPassword2.Text.Equals(textBoxPassword1.Text))
            {
                labelMatchError.Visible = true;
                return;
            }
            try
            {
                logic.CreateOrUpdate(new UserViewModel
                {
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword1.Text,
                });
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearForm()
        {
            labelLoginError.Visible = false;
            labelPassword1Error.Visible = false;
            labelMatchError.Visible = false;
            labelPassword2Error.Visible = false;
        }

    }
}
