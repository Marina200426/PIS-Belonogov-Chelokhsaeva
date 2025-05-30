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
    public partial class CreateCharacteristicTypeForm : Form
    {
        private readonly ServiceController serviceController;

        public CreateCharacteristicTypeForm(ServiceController serviceController)
        {
            this.serviceController = serviceController;
            InitializeComponent();
            comboValueType.DataSource = new[] { "string", "date", "boolean" };
        }

        

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                labelError.Text = "Введите название типа.";
                return;
            }

            var characteristicType = new CharacteristicType
            {
                Name = name,
                ValueType = comboValueType.SelectedItem.ToString()
            };

            serviceController.CreateCharacteristicType(characteristicType);
            labelError.Text = "Тип характеристики создан.";
            textBoxName.Clear();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label labelName;
        private TextBox textBoxName;
        private Button buttonCreate;
        private Button buttonClose;
        private Label labelError;
        private ComboBox comboValueType;
        private Label lblValueType;
    }
}
