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
    public partial class EditRulesForm : Form
    {
        private readonly ServiceController serviceController;

        public class RuleViewModel
        {
            public int Id { get; set; }
            public int CharacteristicTypeId { get; set; }
            public string CharacteristicTypeName { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public int Deadline { get; set; }
            public string Operator { get; set; }
        }

        public EditRulesForm(ServiceController serviceController)
        {
            this.serviceController = serviceController;
            InitializeComponent();
            LoadServices();
        }

        

        private void LoadServices()
        {
            var services = serviceController.GetActiveServices();
            comboService.DataSource = services;
            comboService.DisplayMember = "Name";
            comboService.ValueMember = "Id";
        }

        private void LoadRules(int serviceId)
        {
            var rules = serviceController.GetRulesByServiceId(serviceId);
            var ruleViewModels = rules.Select(r => new RuleViewModel
            {
                Id = r.Id,
                CharacteristicTypeId = r.CharacteristicTypeId,
                CharacteristicTypeName = r.CharacteristicTypeName ?? "Неизвестно",
                Name = r.Name,
                Value = r.Value,
                Deadline = r.Deadline,
                Operator = r.Operator
            }).ToList();

            dataGridViewRules.DataSource = ruleViewModels;
            dataGridViewRules.Columns["Id"].Visible = false;
            dataGridViewRules.Columns["CharacteristicTypeId"].Visible = false;
            dataGridViewRules.Columns["CharacteristicTypeName"].HeaderText = "Тип характеристики";
            dataGridViewRules.Columns["Name"].HeaderText = "Название";
            dataGridViewRules.Columns["Value"].HeaderText = "Значение";
            dataGridViewRules.Columns["Deadline"].HeaderText = "Срок (дни)";
            dataGridViewRules.Columns["Operator"].HeaderText = "Оператор";
        }

        private void LoadCharacteristicTypes()
        {
            var types = serviceController.GetCharacteristicTypes();
            comboCharacteristicType.DataSource = types;
            comboCharacteristicType.DisplayMember = "Name";
            comboCharacteristicType.ValueMember = "Id";
        }

        private void comboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboService.SelectedItem is Service selectedService)
            {
                int serviceId = selectedService.Id;
                LoadRules(serviceId);
                LoadCharacteristicTypes();
            }
        }

        private void buttonAddRule_Click(object sender, EventArgs e)
        {
            if (comboService.SelectedItem == null)
            {
                labelError.Text = "Выберите услугу.";
                return;
            }

            if (comboCharacteristicType.SelectedItem == null)
            {
                labelError.Text = "Выберите тип характеристики.";
                return;
            }

            string name = textBoxName.Text.Trim();
            string value = textBoxValue.Text.Trim();
            string operatorValue = textBoxOperator.Text.Trim();
            if (!int.TryParse(textBoxDeadline.Text.Trim(), out int deadline))
            {
                labelError.Text = "Введите корректный срок (число дней).";
                return;
            }

            bool isDateRelated = name.ToLower().Contains("въезда") || name.ToLower().Contains("патент");

            if (string.IsNullOrEmpty(name))
            {
                labelError.Text = "Введите название правила.";
                return;
            }

            if (!isDateRelated && string.IsNullOrEmpty(value))
            {
                labelError.Text = "Значение обязательно для правила, не связанного с датой.";
                return;
            }

            int serviceId = (int)comboService.SelectedValue;
            int characteristicTypeId = (int)comboCharacteristicType.SelectedValue;

            var rule = new Rule
            {
                ServiceId = serviceId,
                CharacteristicTypeId = characteristicTypeId,
                Name = name,
                Value = value,
                Deadline = deadline,
                Operator = string.IsNullOrWhiteSpace(operatorValue) ? null : operatorValue.ToUpper()
            };

            serviceController.AddRule(rule);
            labelError.Text = "Правило добавлено.";
            LoadRules(serviceId);
            textBoxName.Clear();
            textBoxValue.Clear();
            textBoxDeadline.Clear();
            textBoxOperator.Clear();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label labelService;
        private ComboBox comboService;
        private DataGridView dataGridViewRules;
        private Label labelCharacteristicType;
        private ComboBox comboCharacteristicType;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelValue;
        private TextBox textBoxValue;
        private Label labelDeadline;
        private TextBox textBoxDeadline;
        private Label labelOperator;
        private TextBox textBoxOperator;
        private Button buttonAddRule;
        private Button buttonClose;
        private Label labelError;

    }
}
