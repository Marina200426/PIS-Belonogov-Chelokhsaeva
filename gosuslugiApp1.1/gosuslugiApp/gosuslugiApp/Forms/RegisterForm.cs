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
    public partial class RegisterForm : Form
    {
        private readonly AuthController authController;

        public RegisterForm(AuthController authController)
        {
            this.authController = authController;
            InitializeComponent();
        }      

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                labelError.Text = "Заполните все поля.";
                return;
            }

            var user = new User
            {
                FullName = fullName,
                Email = email,
                Password = password,
                Role = UserRole.гражданин
            };

            if (authController.Register(user))
            {
                labelError.Text = "Регистрация успешна. Теперь вы можете войти.";
                textBoxFullName.Clear();
                textBoxEmail.Clear();
                textBoxPassword.Clear();
            }
            else
            {
                labelError.Text = "Регистрация не удалась. Возможно, email уже используется.";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label labelFullName;
        private TextBox textBoxFullName;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Button buttonRegister;
        private Button buttonClose;
        private Label labelError;
    }
}
