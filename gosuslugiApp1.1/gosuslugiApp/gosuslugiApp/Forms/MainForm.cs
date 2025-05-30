using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace gosuslugiApp
{
    public partial class MainForm : Form
    {
        private readonly ApplicationController applicationController;
        private readonly ServiceController serviceController;
        private readonly UserController userController;
        private readonly AuthController authController;


        public MainForm(ApplicationController applicationController, ServiceController serviceController, UserController userController, AuthController authController)
        {
            this.applicationController = applicationController;
            this.serviceController = serviceController;
            this.userController = userController;
            this.authController = authController;
            InitializeComponent();
        }

        

        private void buttonViewApplications_Click(object sender, EventArgs e)
        {
            new ViewApplicationsForm(applicationController).ShowDialog();
        }

        private void buttonSubmitApplication_Click(object sender, EventArgs e)
        {
            new SubmitApplicationForm(serviceController, applicationController).ShowDialog();
        }

        private void buttonCancelApplication_Click(object sender, EventArgs e)
        {
            new CancelApplicationForm(applicationController).ShowDialog();
        }

        private void buttonUpdateProfile_Click(object sender, EventArgs e)
        {
            new UpdateProfileForm(userController).ShowDialog();
        }

        private void buttonUpdateStatus_Click(object sender, EventArgs e)
        {
            new UpdateApplicationStatusForm(applicationController).ShowDialog();
        }

        private void buttonManageServices_Click(object sender, EventArgs e)
        {
            new ManageServicesForm(serviceController).ShowDialog();
        }

        private void buttonManageUsers_Click(object sender, EventArgs e)
        {
            new ManageUsersForm(authController).ShowDialog();
        }

        private void buttonCreateService_Click(object sender, EventArgs e)
        {
            new CreateServiceForm(serviceController).ShowDialog();
        }

        private void buttonEditRules_Click(object sender, EventArgs e)
        {
            new EditRulesForm(serviceController).ShowDialog();
        }

        private void buttonCreateCharacteristicType_Click(object sender, EventArgs e)
        {
            new CreateCharacteristicTypeForm(serviceController).ShowDialog();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Session.UserId = 0;
            Session.FullName = null;
            Session.Email = null;
            Session.Role = null;
            this.Close();
            new LoginForm(new AuthController(new AuthService(new UserRepository(new DatabaseHelper()))),
                         applicationController, serviceController, userController).Show();
        }

        private Label labelWelcome;
        private Button buttonViewApplications;
        private Button buttonSubmitApplication;
        private Button buttonCancelApplication;
        private Button buttonUpdateProfile;
        private Button buttonUpdateStatus;
        private Button buttonManageServices;
        private Button buttonManageUsers;
        private Button buttonCreateService;
        private Button buttonEditRules;
        private Button buttonCreateCharacteristicType;
        private Button buttonLogout;
    }
}
