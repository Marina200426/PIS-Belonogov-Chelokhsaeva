using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gosuslugiApp
{
    public partial class ManageUsersForm : Form
    {
        private readonly AuthController authController;

        public ManageUsersForm(AuthController authController)
        {
            this.authController = authController;
            InitializeComponent();
            comboRole.DataSource = new[] { "гражданин", "госслужащий", "администратор" };
        }

        private void btnRegisterAdmin_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                Role = (UserRole)Enum.Parse(typeof(UserRole), comboRole.SelectedItem.ToString())
            };
            if (authController.RegisterAdmin(user, user.Role))
            {
                MessageBox.Show("Пользователь создан.");
                txtFullName.Clear();
                txtEmail.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Ошибка регистрации.");
            }
        }

        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox comboRole;
        private Button btnRegisterAdmin;

        
        
    }
}
