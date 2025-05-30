using System;
using System.Drawing;
using System.Windows.Forms;

namespace gosuslugiApp
{
    partial class SubmitApplicationForm
    {
        
        private void InitializeComponent()
        {
            this.labelService = new Label();
            this.comboServices = new ComboBox();
            this.btnSubmit = new Button();
            this.buttonClose = new Button();
            this.labelError = new Label();

            this.labelService.Text = "Выберите услугу:";
            this.labelService.Location = new Point(20, 20);
            this.labelService.Size = new Size(100, 20);

            this.comboServices.Location = new Point(120, 20);
            this.comboServices.Size = new Size(200, 20);
            this.comboServices.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnSubmit.Text = "Подать заявку";
            this.btnSubmit.Location = new Point(120, 50);
            this.btnSubmit.Size = new Size(100, 30);
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            this.buttonClose.Text = "Закрыть";
            this.buttonClose.Location = new Point(230, 50);
            this.buttonClose.Size = new Size(100, 30);
            this.buttonClose.Click += new EventHandler(this.buttonClose_Click);

            this.labelError.Text = "";
            this.labelError.ForeColor = Color.Red;
            this.labelError.Location = new Point(20, 90);
            this.labelError.Size = new Size(310, 30);
            this.labelError.AutoSize = false;

            this.Controls.Add(this.labelService);
            this.Controls.Add(this.comboServices);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelError);
            this.Text = "Подача заявки";
            this.Size = new Size(400, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}