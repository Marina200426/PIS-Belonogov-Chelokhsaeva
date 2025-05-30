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
    public partial class UpdateApplicationStatusForm : Form
    {
        private readonly ApplicationController applicationController;

        public class ApplicationStatusViewModel
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string ServiceName { get; set; }
            public DateTime DateSubmitted { get; set; }
            public DateTime PlannedDate { get; set; }
            public string Status { get; set; }
            public string Result { get; set; }
        }

        public UpdateApplicationStatusForm(ApplicationController applicationController)
        {
            this.applicationController = applicationController;
            InitializeComponent();
            comboStatus.DataSource = Enum.GetValues(typeof(ApplicationStatus));
            LoadApplications();
        }

        

        private void LoadApplications()
        {
            var applications = applicationController.GetApplicationsForResponsible(Session.UserId);
            var appViewModels = applications.Select(a => new ApplicationStatusViewModel
            {
                Id = a.Id,
                UserName = a.UserName ?? "Неизвестно",
                ServiceName = a.ServiceName ?? "Неизвестно",
                DateSubmitted = a.DateSubmitted,
                PlannedDate = a.PlannedDate,
                Status = a.Status.ToString(),
                Result = a.Result ?? ""
            }).ToList();
            dataGridViewApplications.DataSource = appViewModels;
            dataGridViewApplications.Columns["Id"].Visible = false;
            dataGridViewApplications.Columns["UserName"].HeaderText = "Пользователь";
            dataGridViewApplications.Columns["ServiceName"].HeaderText = "Услуга";
            dataGridViewApplications.Columns["DateSubmitted"].HeaderText = "Дата подачи";
            dataGridViewApplications.Columns["PlannedDate"].HeaderText = "Плановая дата";
            dataGridViewApplications.Columns["Status"].HeaderText = "Статус";
            dataGridViewApplications.Columns["Result"].HeaderText = "Результат";
            dataGridViewApplications.Columns["DateSubmitted"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            dataGridViewApplications.Columns["PlannedDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewApplications.SelectedRows.Count == 0)
            {
                labelError.Text = "Выберите заявку.";
                return;
            }

            if (comboStatus.SelectedItem == null)
            {
                labelError.Text = "Выберите статус.";
                return;
            }

            int applicationId = (int)dataGridViewApplications.SelectedRows[0].Cells["Id"].Value;
            ApplicationStatus status = (ApplicationStatus)comboStatus.SelectedItem;
            string result = textBoxResult.Text.Trim();

            if (applicationController.UpdateRequestStatusAndResult(applicationId, status, result, Session.UserId))
            {
                labelError.Text = "Статус и результат обновлены.";
                LoadApplications();
            }
            else
            {
                labelError.Text = "Не удалось обновить статус. Проверьте, являетесь ли вы ответственным.";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataGridView dataGridViewApplications;
        private Label labelStatus;
        private ComboBox comboStatus;
        private Label labelResult;
        private TextBox textBoxResult;
        private Button buttonUpdate;
        private Button buttonClose;
        private Label labelError;
    }
}
