using System;
using System.Drawing;
using System.Windows.Forms;

namespace gosuslugiApp
{
    partial class UpdateApplicationStatusForm
    {
        private void InitializeComponent()
        {
            this.dataGridViewApplications = new DataGridView();
            this.labelStatus = new Label();
            this.comboStatus = new ComboBox();
            this.labelResult = new Label();
            this.textBoxResult = new TextBox();
            this.buttonUpdate = new Button();
            this.buttonClose = new Button();
            this.labelError = new Label();

            
            this.dataGridViewApplications.Location = new Point(20, 20);
            this.dataGridViewApplications.Size = new Size(740, 300);
            this.dataGridViewApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewApplications.ReadOnly = true;
            this.dataGridViewApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
            this.labelStatus.Text = "Статус:";
            this.labelStatus.Location = new Point(20, 330);
            this.labelStatus.Size = new Size(100, 20);

            
            this.comboStatus.Location = new Point(120, 330);
            this.comboStatus.Size = new Size(200, 20);
            this.comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            
            this.labelResult.Text = "Результат:";
            this.labelResult.Location = new Point(20, 360);
            this.labelResult.Size = new Size(100, 20);

           
            this.textBoxResult.Location = new Point(120, 360);
            this.textBoxResult.Size = new Size(200, 20);

            
            this.buttonUpdate.Text = "Сохранить";
            this.buttonUpdate.Location = new Point(330, 360);
            this.buttonUpdate.Size = new Size(100, 30);
            this.buttonUpdate.Click += new EventHandler(this.buttonUpdate_Click);

            
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.Location = new Point(660, 360);
            this.buttonClose.Size = new Size(100, 30);
            this.buttonClose.Click += new EventHandler(this.buttonClose_Click);

            this.labelError.Text = "";
            this.labelError.ForeColor = Color.Red;
            this.labelError.Location = new Point(20, 390);
            this.labelError.Size = new Size(740, 30);
            this.labelError.AutoSize = false;

            this.Controls.Add(this.dataGridViewApplications);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelError);
            this.Text = "Обновление статуса заявки";
            this.Size = new Size(800, 480);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}