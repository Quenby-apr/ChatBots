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
    public partial class SignInForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly UserLogic logic;
        public SignInForm(UserLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            clearForm();
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                labelLoginError.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                labelPassword1Error.Visible = true;
                return;
            }

            var users = logic.Read(null);
            UserViewModel _user = null;
            foreach (var user in users)
            {
                if (user.Login == textBoxLogin.Text && user.Password == textBoxPassword.Text)
                {
                    _user = user;
                }
            }
            if (_user != null)
            {
                Program.User = _user;
                var form = Container.Resolve<FormMain>();
                form.Show();
                Close();
            }
            else
            {
                labelError.Visible = true;
            }

        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<SignUpForm>();
            form.ShowDialog();
        }

        private void clearForm()
        {
            labelLoginError.Visible = false;
            labelPassword1Error.Visible = false;
            labelError.Visible = false;
        }
    }
}
