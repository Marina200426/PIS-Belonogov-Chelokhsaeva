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
    public partial class ManageServicesForm : Form
    {
        private readonly ServiceController serviceController;

        public class ServiceViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Requirements { get; set; }
            public bool IsActive { get; set; }
        }

        public ManageServicesForm(ServiceController serviceController)
        {
            this.serviceController = serviceController;
            InitializeComponent();
            LoadServices();
        }   

        private void LoadServices()
        {
            var services = serviceController.GetActiveServices();
            var serviceViewModels = services.Select(s => new ServiceViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Requirements = s.Requirements ?? "",
                IsActive = s.DateDeactivated == null
            }).ToList();

            dataGridViewServices.DataSource = serviceViewModels;
            dataGridViewServices.Columns["Id"].Visible = false;
            dataGridViewServices.Columns["Name"].HeaderText = "Название услуги";
            dataGridViewServices.Columns["Requirements"].HeaderText = "Требования";
            dataGridViewServices.Columns["IsActive"].HeaderText = "Активна";
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                labelError.Text = "Выберите услугу для редактирования.";
                return;
            }

            int serviceId = (int)dataGridViewServices.SelectedRows[0].Cells["Id"].Value;
            var service = serviceController.GetServiceById(serviceId);
            if (service != null)
            {
                string newName = Prompt.ShowDialog("Введите новое название услуги:", "Редактирование услуги", service.Name);
                string newRequirements = Prompt.ShowDialog("Введите новые требования:", "Редактирование услуги", service.Requirements);

                var updatedService = new Service
                {
                    Id = service.Id,
                    Name = newName,
                    Requirements = newRequirements,
                    DateActivated = service.DateActivated,
                    DateDeactivated = service.DateDeactivated, 
                    ResponsibleId = service.ResponsibleId
                };

                serviceController.ReplaceService(serviceId, updatedService);
                labelError.Text = "Услуга обновлена.";
                LoadServices();
            }
            else
            {
                labelError.Text = "Не удалось загрузить услугу.";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                labelError.Text = "Выберите услугу для удаления.";
                return;
            }

            int serviceId = (int)dataGridViewServices.SelectedRows[0].Cells["Id"].Value;
            serviceController.DeleteService(serviceId);
            labelError.Text = "Услуга удалена.";
            LoadServices();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataGridView dataGridViewServices;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonClose;
        private Label labelError;
    }

    
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string defaultValue)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 100 };
            TextBox textBox = new TextBox() { Left = 120, Top = 20, Width = 200, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 120, Width = 100, Top = 50, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Отмена", Left = 230, Width = 100, Top = 50, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : defaultValue;
        }
    }
}
