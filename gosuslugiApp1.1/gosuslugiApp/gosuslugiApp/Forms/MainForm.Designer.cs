using System.Drawing;
using System.Windows.Forms;
using System;

namespace gosuslugiApp
{
    public partial class MainForm : Form
    {
        private void InitializeComponent()
        {
            this.labelWelcome = new Label();
            this.buttonViewApplications = new Button();
            this.buttonSubmitApplication = new Button();
            this.buttonCancelApplication = new Button();
            this.buttonUpdateProfile = new Button();
            this.buttonUpdateStatus = new Button();
            this.buttonManageServices = new Button();
            this.buttonManageUsers = new Button();
            this.buttonCreateService = new Button();
            this.buttonEditRules = new Button();
            this.buttonCreateCharacteristicType = new Button();
            this.buttonLogout = new Button();

            // labelWelcome
            this.labelWelcome.Text = $"Добро пожаловать, {Session.FullName}!";
            this.labelWelcome.Location = new Point(20, 20);
            this.labelWelcome.Size = new Size(360, 30);
            this.labelWelcome.Font = new Font("Arial", 12, FontStyle.Bold);

            // buttonViewApplications
            this.buttonViewApplications.Text =Session.Role == "гражданин" ? "Просмотреть заявки" : null;
            this.buttonViewApplications.Location = new Point(20, 60);
            this.buttonViewApplications.Size = new Size(180, 30);
            this.buttonViewApplications.Click += new EventHandler(this.buttonViewApplications_Click);
            this.buttonViewApplications.Visible = Session.Role == "гражданин";

            // buttonSubmitApplication
            this.buttonSubmitApplication.Text = Session.Role == "гражданин" ? "Подать заявку" : null;
            this.buttonSubmitApplication.Location = new Point(20, 100);
            this.buttonSubmitApplication.Size = new Size(180, 30);
            this.buttonSubmitApplication.Click += new EventHandler(this.buttonSubmitApplication_Click);
            this.buttonSubmitApplication.Visible = Session.Role == "гражданин";

            // buttonCancelApplication
            this.buttonCancelApplication.Text = Session.Role == "гражданин" ? "Отменить заявку":null;
            this.buttonCancelApplication.Location = new Point(20, 140);
            this.buttonCancelApplication.Size = new Size(180, 30);
            this.buttonCancelApplication.Click += new EventHandler(this.buttonCancelApplication_Click);
            this.buttonCancelApplication.Visible = Session.Role == "гражданин";

            // buttonUpdateProfile
            this.buttonUpdateProfile.Text = Session.Role == "гражданин" ? "Обновить профиль" : null;
            this.buttonUpdateProfile.Location = new Point(20, 180);
            this.buttonUpdateProfile.Size = new Size(180, 30);
            this.buttonUpdateProfile.Click += new EventHandler(this.buttonUpdateProfile_Click);
            this.buttonUpdateProfile.Visible = Session.Role == "гражданин";

            // buttonUpdateStatus
            this.buttonUpdateStatus.Text = Session.Role == "госслужащий" ? "Обновить статус заявки" : null;
            this.buttonUpdateStatus.Location = new Point(20, 60);
            this.buttonUpdateStatus.Size = new Size(180, 30);
            this.buttonUpdateStatus.Click += new EventHandler(this.buttonUpdateStatus_Click);

            // Visibility based on role
            this.buttonUpdateStatus.Visible = Session.Role == "госслужащий" ;

            // buttonManageServices
            this.buttonManageServices.Text = Session.Role == "администратор" ? "Управление услугами" : null;
            this.buttonManageServices.Location = new Point(20, 60);
            this.buttonManageServices.Size = new Size(180, 30);
            this.buttonManageServices.Click += new EventHandler(this.buttonManageServices_Click);
            // Visibility для based роли on Role
            this.buttonManageServices.Visible = Session.Role == "администратор";

            // buttonManageUsers
            this.buttonManageUsers.Text = Session.Role == "администратор" ? "Управление пользователями" : null;
            this.buttonManageUsers.Location = new Point(20, 100);
            this.buttonManageUsers.Size = new Size(180, 30);
            this.buttonManageUsers.Click += new EventHandler(this.buttonManageUsers_Click);
            // Visibility для based роли on Role
            this.buttonManageUsers.Visible = Session.Role == "администратор";

            // buttonCreateService
            this.buttonCreateService.Text = Session.Role == "администратор" ? "Создать услугу" : null;
            this.buttonCreateService.Location = new Point(20, 140);
            this.buttonCreateService.Size = new Size(180, 30);
            this.buttonCreateService.Click += new EventHandler(this.buttonCreateService_Click);
            // Visibility для based роли on Role
            this.buttonCreateService.Visible = Session.Role == "администратор";

            // buttonEditRules
            this.buttonEditRules.Text = Session.Role == "администратор" ? "Редактировать правила" : null;
            this.buttonEditRules.Location = new Point(20, 180);
            this.buttonEditRules.Size = new Size(180, 30);
            this.buttonEditRules.Click += new EventHandler(this.buttonEditRules_Click);
            // Visibility для based роли on Role
            this.buttonEditRules.Visible = Session.Role == "администратор";

            // buttonCreateCharacteristicType
            this.buttonCreateCharacteristicType.Text = Session.Role == "администратор" ? "Создать тип характеристики" : null;
            this.buttonCreateCharacteristicType.Location = new Point(20, 220);
            this.buttonCreateCharacteristicType.Size = new Size(180, 30);
            this.buttonCreateCharacteristicType.Click += new EventHandler(this.buttonCreateCharacteristicType_Click);
            // Visibility для based роли on Role
            this.buttonCreateCharacteristicType.Visible = Session.Role == "администратор";

            // buttonLogout
            this.buttonLogout.Text = "Выйти";
            this.buttonLogout.Location = new Point(20, 460);
            this.buttonLogout.Size = new Size(180, 30);
            this.buttonLogout.Click += new EventHandler(this.buttonLogout_Click);

            // Form
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.buttonViewApplications);
            this.Controls.Add(this.buttonSubmitApplication);
            this.Controls.Add(this.buttonCancelApplication);
            this.Controls.Add(this.buttonUpdateProfile);
            this.Controls.Add(this.buttonUpdateStatus);
            this.Controls.Add(this.buttonManageServices);
            this.Controls.Add(this.buttonManageUsers);
            this.Controls.Add(this.buttonCreateService);
            this.Controls.Add(this.buttonEditRules);
            this.Controls.Add(this.buttonCreateCharacteristicType);
            this.Controls.Add(this.buttonLogout);
            this.Text = "Главное меню";
            this.Size = new Size(400, 550);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

    }
}