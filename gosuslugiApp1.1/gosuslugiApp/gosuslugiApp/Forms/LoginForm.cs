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
    public partial class LoginForm : Form
    {
        private readonly AuthController authController;
        private readonly ApplicationController applicationController;
        private readonly ServiceController serviceController;
        private readonly UserController userController;

        public LoginForm(AuthController authController, ApplicationController applicationController,
                        ServiceController serviceController, UserController userController)
        {
            this.authController = authController;
            this.applicationController = applicationController;
            this.serviceController = serviceController;
            this.userController = userController;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                labelError.Text = "Заполните все поля.";
                return;
            }

            if (authController.Login(email, password, out User user))
            {
                this.Hide();
                new MainForm(applicationController, serviceController, userController,authController).ShowDialog();
                this.Close();
            }
            else
            {
                labelError.Text = "Неверный email или пароль.";
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm(authController).ShowDialog();
        }

        private Label labelEmail;
        private Label labelPassword;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Button buttonRegister;
        private Label labelError;


    }
}
