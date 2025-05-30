using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace gosuslugiApp
{
    partial class EditRulesForm
    {
        private void InitializeComponent()
        {
            this.labelService = new Label();
            this.comboService = new ComboBox();
            this.dataGridViewRules = new DataGridView();
            this.labelCharacteristicType = new Label();
            this.comboCharacteristicType = new ComboBox();
            this.labelName = new Label();
            this.textBoxName = new TextBox();
            this.labelValue = new Label();
            this.textBoxValue = new TextBox();
            this.labelDeadline = new Label();
            this.textBoxDeadline = new TextBox();
            this.labelOperator = new Label();
            this.textBoxOperator = new TextBox();
            this.buttonAddRule = new Button();
            this.buttonClose = new Button();
            this.labelError = new Label();

            // labelService
            this.labelService.Text = "Выберите услугу:";
            this.labelService.Location = new Point(20, 20);
            this.labelService.Size = new Size(100, 20);

            // comboService
            this.comboService.Location = new Point(120, 20);
            this.comboService.Size = new Size(200, 20);
            this.comboService.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboService.SelectedIndexChanged += new EventHandler(this.comboService_SelectedIndexChanged);

            // dataGridViewRules
            this.dataGridViewRules.Location = new Point(20, 50);
            this.dataGridViewRules.Size = new Size(740, 200);
            this.dataGridViewRules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRules.ReadOnly = true;
            this.dataGridViewRules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // labelCharacteristicType
            this.labelCharacteristicType.Text = "Тип характеристики:";
            this.labelCharacteristicType.Location = new Point(20, 260);
            this.labelCharacteristicType.Size = new Size(100, 20);

            // comboCharacteristicType
            this.comboCharacteristicType.Location = new Point(120, 260);
            this.comboCharacteristicType.Size = new Size(200, 20);
            this.comboCharacteristicType.DropDownStyle = ComboBoxStyle.DropDownList;

            // labelName
            this.labelName.Text = "Название правила:";
            this.labelName.Location = new Point(20, 290);
            this.labelName.Size = new Size(100, 20);

            // textBoxName
            this.textBoxName.Location = new Point(120, 290);
            this.textBoxName.Size = new Size(200, 20);

            // labelValue
            this.labelValue.Text = "Значение:";
            this.labelValue.Location = new Point(20, 320);
            this.labelValue.Size = new Size(100, 20);

            // textBoxValue
            this.textBoxValue.Location = new Point(120, 320);
            this.textBoxValue.Size = new Size(200, 20);

            // labelDeadline
            this.labelDeadline.Text = "Срок (дни):";
            this.labelDeadline.Location = new Point(20, 350);
            this.labelDeadline.Size = new Size(100, 20);

            // textBoxDeadline
            this.textBoxDeadline.Location = new Point(120, 350);
            this.textBoxDeadline.Size = new Size(200, 20);

            // labelOperator
            this.labelOperator.Text = "Оператор:";
            this.labelOperator.Location = new Point(20, 380);
            this.labelOperator.Size = new Size(100, 20);

            // textBoxOperator
            this.textBoxOperator.Location = new Point(120, 380);
            this.textBoxOperator.Size = new Size(200, 20);

            // buttonAddRule
            this.buttonAddRule.Text = "Добавить правило";
            this.buttonAddRule.Location = new Point(330, 380);
            this.buttonAddRule.Size = new Size(100, 30);
            this.buttonAddRule.Click += new EventHandler(this.buttonAddRule_Click);

            // buttonClose
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.Location = new Point(660, 380);
            this.buttonClose.Size = new Size(100, 30);
            this.buttonClose.Click += new EventHandler(this.buttonClose_Click);

            // labelError
            this.labelError.Text = "";
            this.labelError.ForeColor = Color.Red;
            this.labelError.Location = new Point(20, 420);
            this.labelError.Size = new Size(740, 30);
            this.labelError.AutoSize = false;

            // Form
            this.Controls.Add(this.labelService);
            this.Controls.Add(this.comboService);
            this.Controls.Add(this.dataGridViewRules);
            this.Controls.Add(this.labelCharacteristicType);
            this.Controls.Add(this.comboCharacteristicType);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.labelDeadline);
            this.Controls.Add(this.textBoxDeadline);
            this.Controls.Add(this.labelOperator);
            this.Controls.Add(this.textBoxOperator);
            this.Controls.Add(this.buttonAddRule);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelError);
            this.Text = "Редактирование правил";
            this.Size = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}