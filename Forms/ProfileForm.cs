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
    public partial class ProfileForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly UserLogic logic;
        public ProfileForm(UserLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
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
            logic.Update(new UserViewModel
            {
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text,
            });
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLeave_Click(object sender, EventArgs e)
        {
            Program.User = null;
            Close();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            checkBoxChange.Checked = false;
            LoadData();
            clearForm();
        }

        private void checkBoxChange_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxChange.Checked == true)
            {
                textBoxLogin.Enabled = true;
                textBoxPassword.Enabled = true;
            }
            if (checkBoxChange.Checked == false)
            {
                LoadData();
            }
        }
        private void clearForm()
        {
            labelLoginError.Visible = false;
            labelPassword1Error.Visible = false;
        }

        private void LoadData()
        {
            textBoxLogin.Text = Program.User.Login;
            textBoxPassword.Text = Program.User.Password;
            textBoxLogin.Enabled = false;
            textBoxPassword.Enabled = false;
        }
    }
}
