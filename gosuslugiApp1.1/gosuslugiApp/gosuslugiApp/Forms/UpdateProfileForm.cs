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
    public partial class UpdateProfileForm : Form
    {
        private readonly UserController userController;

        public class CharacteristicViewModel
        {
            public int Id { get; set; }
            public int TypeId { get; set; }
            public string TypeName { get; set; }
            public string Value { get; set; }
        }

        public UpdateProfileForm(UserController userController)
        {
            this.userController = userController;
            InitializeComponent();
            LoadProfile();
            LoadCharacteristics();
            LoadCharacteristicTypes();
        }

        

        private void LoadProfile()
        {
            var user = userController.GetUserProfile(Session.UserId);
            if (user != null)
            {
                textBoxFullName.Text = user.FullName;
                textBoxEmail.Text = user.Email;
            }
            else
            {
                labelError.Text = "Не удалось загрузить профиль.";
            }
        }

        private void LoadCharacteristics()
        {
            var characteristics = userController.GetUserCharacteristics(Session.UserId);
            var charViewModels = characteristics.Select(c => new CharacteristicViewModel
            {
                Id = c.Id,
                TypeId = c.TypeId,
                TypeName = c.TypeName ?? "Неизвестно",
                Value = c.Value
            }).ToList();

            dataGridViewCharacteristics.DataSource = charViewModels;
            dataGridViewCharacteristics.Columns["Id"].Visible = false;
            dataGridViewCharacteristics.Columns["TypeId"].Visible = false;
            dataGridViewCharacteristics.Columns["TypeName"].HeaderText = "Тип характеристики";
            dataGridViewCharacteristics.Columns["Value"].HeaderText = "Значение";
        }

        private void LoadCharacteristicTypes()
        {
            var types = userController.GetCharacteristicTypes();
            comboCharacteristicType.DataSource = types;
            comboCharacteristicType.DisplayMember = "Name";
            comboCharacteristicType.ValueMember = "Id";
        }

        private void buttonUpdateProfile_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text.Trim();
            string email = textBoxEmail.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                labelError.Text = "Заполните все поля.";
                return;
            }

            userController.UpdateProfile(Session.UserId, fullName, email);
            Session.FullName = fullName;
            Session.Email = email;
            labelError.Text = "Профиль обновлён.";
        }

        private void buttonAddCharacteristic_Click(object sender, EventArgs e)
        {
            if (comboCharacteristicType.SelectedItem == null)
            {
                labelError.Text = "Выберите тип характеристики.";
                return;
            }

            if (string.IsNullOrEmpty(textBoxValue.Text.Trim()))
            {
                labelError.Text = "Введите значение характеристики.";
                return;
            }

            int typeId = (int)comboCharacteristicType.SelectedValue;
            string value = textBoxValue.Text.Trim();

            userController.AddOrUpdateCharacteristic(Session.UserId, typeId, value);
            labelError.Text = "Характеристика добавлена/обновлена.";
            LoadCharacteristics();
            textBoxValue.Clear();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label labelFullName;
        private TextBox textBoxFullName;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Button buttonUpdateProfile;
        private DataGridView dataGridViewCharacteristics;
        private Label labelCharacteristicType;
        private ComboBox comboCharacteristicType;
        private Label labelValue;
        private TextBox textBoxValue;
        private Button buttonAddCharacteristic;
        private Button buttonClose;
        private Label labelError;
    }

}
