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
    public partial class CreateServiceForm : Form
    {
        private readonly ServiceController serviceController;

        public CreateServiceForm(ServiceController serviceController)
        {
            this.serviceController = serviceController;
            InitializeComponent();
            LoadGovernmentEmployees();
        }

        

        private void LoadGovernmentEmployees()
        {
            var employees = serviceController.GetGovernmentEmployees();
            comboResponsible.DataSource = employees;
            comboResponsible.DisplayMember = "FullName";
            comboResponsible.ValueMember = "Id";
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string requirements = textBoxRequirements.Text.Trim();
            if (comboResponsible.SelectedItem == null)
            {
                labelError.Text = "Выберите ответственного.";
                return;
            }
            int responsibleId = (int)comboResponsible.SelectedValue;

            if (string.IsNullOrEmpty(name))
            {
                labelError.Text = "Введите название услуги.";
                return;
            }

            var service = new Service
            {
                Name = name,
                Requirements = requirements,
                DateActivated = DateTime.Now, 
                DateDeactivated = null, 
                ResponsibleId = responsibleId
            };

            serviceController.AddService(service, new System.Collections.Generic.List<Rule>());
            labelError.Text = "Услуга создана.";
            textBoxName.Clear();
            textBoxRequirements.Clear();
            comboResponsible.SelectedIndex = -1;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label labelName;
        private TextBox textBoxName;
        private Label labelRequirements;
        private TextBox textBoxRequirements;
        private Label labelResponsible;
        private ComboBox comboResponsible;
        private Button buttonCreate;
        private Button buttonClose;
        private Label labelError;
    }
}
