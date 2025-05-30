using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace gosuslugiApp
{
    partial class CreateCharacteristicTypeForm
    {
        private void InitializeComponent()
        {
            this.labelName = new Label();
            this.textBoxName = new TextBox();
            this.buttonCreate = new Button();
            this.buttonClose = new Button();
            this.labelError = new Label();
            this.comboValueType = new ComboBox();
            this.lblValueType = new Label();

            // labelName
            this.labelName.Text = "Название типа:";
            this.labelName.Location = new Point(20, 20);
            this.labelName.Size = new Size(100, 20);

            // textBoxName
            this.textBoxName.Location = new Point(120, 20);
            this.textBoxName.Size = new Size(200, 20);


            this.lblValueType.Text = "Тип значения:";
            this.lblValueType.Location = new Point(20, 50);
            this.comboValueType.Location = new Point(120, 50);
            this.comboValueType.Size = new Size(200, 21);

            

            // buttonCreate
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.Location = new Point(130, 100);
            this.buttonCreate.Size = new Size(100, 30);
            this.buttonCreate.Click += new EventHandler(this.buttonCreate_Click);

            // buttonClose
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.Location = new Point(230, 100);
            this.buttonClose.Size = new Size(100, 30);
            this.buttonClose.Click += new EventHandler(this.buttonClose_Click);

            // labelError
            this.labelError.Text = "";
            this.labelError.ForeColor = Color.Red;
            this.labelError.Location = new Point(20, 80);
            this.labelError.Size = new Size(300, 30);
            this.labelError.AutoSize = false;

            // Form
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.lblValueType);
            this.Controls.Add(this.comboValueType);
            this.Text = "Создание типа характеристики";
            this.Size = new Size(400, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}