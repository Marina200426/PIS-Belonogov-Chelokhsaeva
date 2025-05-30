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
    public partial class SubmitApplicationForm : Form
    {
        private readonly ServiceController serviceController;
        private readonly ApplicationController applicationController;
        private readonly int userId;

        public SubmitApplicationForm(ServiceController serviceController, ApplicationController applicationController)
        {
            this.serviceController = serviceController;
            this.applicationController = applicationController;
            this.userId = Session.UserId; 
            InitializeComponent();
            LoadServices();
        }

        private void LoadServices()
        {
            var services = serviceController.GetActiveServices();
            comboServices.DataSource = services;
            comboServices.DisplayMember = "Name";
            comboServices.ValueMember = "Id";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (comboServices.SelectedItem == null)
            {
                labelError.Text = "Выберите услугу.";
                return;
            }

            int serviceId = (int)comboServices.SelectedValue;
            string failReason;
            DateTime? plannedDate;

            bool success = applicationController.SubmitApplication(this.userId, serviceId, out failReason, out plannedDate);

            if (!success)
            {
                MessageBox.Show("Заявка не может быть подана:\n\n" + failReason, "Отказ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var service = serviceController.GetServiceById(serviceId);
            MessageBox.Show(
                "Вы соответствуете всем требованиям!\n\n" +
                "Требования:\n" + (service?.Requirements ?? "Нет требований") + "\n\n" +
                "Услугу нужно получить до: " + plannedDate?.ToString("dd.MM.yyyy"),
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information
            );
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label labelService;
        private ComboBox comboServices;
        private Button btnSubmit;
        private Button buttonClose;
        private Label labelError;
    }
}
