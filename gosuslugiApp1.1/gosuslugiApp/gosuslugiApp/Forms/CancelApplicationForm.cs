using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static gosuslugiApp.ViewApplicationsForm;

namespace gosuslugiApp
{
    public partial class CancelApplicationForm : Form
    {
        private readonly ApplicationController applicationController;

        public class ApplicationViewModel
        {
            public int Id { get; set; }
            public string ServiceName { get; set; }
            public DateTime DateSubmitted { get; set; }
            public DateTime PlannedDate { get; set; }
            public string Status { get; set; }
            public string Result { get; set; }
            public string Requirements { get; set; }
        }

        public CancelApplicationForm(ApplicationController applicationController)
        {
            this.applicationController = applicationController;
            InitializeComponent();
            LoadApplications();
        }

       

        private void LoadApplications()
        {
            var applications = applicationController.GetUserApplications(Session.UserId);
            var appViewModels = applications.Select(a => new ApplicationViewModel
            {
                Id = a.Id,
                ServiceName = a.ServiceName ?? "Неизвестно",
                DateSubmitted = a.DateSubmitted,
                PlannedDate = a.PlannedDate,
                Status = a.Status.ToString(),
                Result = a.Result ?? "",
                Requirements = a.Requirements ?? ""
            }).ToList();

            dataGridViewApplications.DataSource = appViewModels;
            dataGridViewApplications.Columns["Id"].Visible = false;
            dataGridViewApplications.Columns["ServiceName"].HeaderText = "Услуга";
            dataGridViewApplications.Columns["DateSubmitted"].HeaderText = "Дата подачи";
            dataGridViewApplications.Columns["PlannedDate"].HeaderText = "Плановая дата";
            dataGridViewApplications.Columns["Status"].HeaderText = "Статус";
            dataGridViewApplications.Columns["Result"].HeaderText = "Результат";
            dataGridViewApplications.Columns["Requirements"].HeaderText = "Требования";
            dataGridViewApplications.Columns["DateSubmitted"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            dataGridViewApplications.Columns["PlannedDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (dataGridViewApplications.SelectedRows.Count == 0)
            {
                labelError.Text = "Выберите заявку для отмены.";
                return;
            }

            int applicationId = (int)dataGridViewApplications.SelectedRows[0].Cells["Id"].Value;
            if (applicationController.CancelApplication(applicationId))
            {
                labelError.Text = "Заявка успешно отменена.";
                LoadApplications();
            }
            else
            {
                labelError.Text = "Не удалось отменить заявку. Возможно, она уже обработана.";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataGridView dataGridViewApplications;
        private Button buttonCancel;
        private Button buttonClose;
        private Label labelError;
    }
}
