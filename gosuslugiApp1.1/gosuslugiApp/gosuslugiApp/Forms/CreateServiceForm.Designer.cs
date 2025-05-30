using System;
using System.Drawing;
using System.Windows.Forms;

namespace gosuslugiApp
{
    partial class CreateServiceForm
    {
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelRequirements = new System.Windows.Forms.Label();
            this.textBoxRequirements = new System.Windows.Forms.TextBox();
            this.labelResponsible = new System.Windows.Forms.Label();
            this.comboResponsible = new System.Windows.Forms.ComboBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(20, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(100, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название услуги:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(198, 20);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 22);
            this.textBoxName.TabIndex = 1;
            // 
            // labelRequirements
            // 
            this.labelRequirements.Location = new System.Drawing.Point(20, 50);
            this.labelRequirements.Name = "labelRequirements";
            this.labelRequirements.Size = new System.Drawing.Size(100, 20);
            this.labelRequirements.TabIndex = 2;
            this.labelRequirements.Text = "Требования:";
            // 
            // textBoxRequirements
            // 
            this.textBoxRequirements.Location = new System.Drawing.Point(198, 50);
            this.textBoxRequirements.Name = "textBoxRequirements";
            this.textBoxRequirements.Size = new System.Drawing.Size(200, 22);
            this.textBoxRequirements.TabIndex = 3;
            // 
            // labelResponsible
            // 
            this.labelResponsible.Location = new System.Drawing.Point(20, 80);
            this.labelResponsible.Name = "labelResponsible";
            this.labelResponsible.Size = new System.Drawing.Size(125, 20);
            this.labelResponsible.TabIndex = 4;
            this.labelResponsible.Text = "Ответственный:";
            // 
            // comboResponsible
            // 
            this.comboResponsible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboResponsible.Location = new System.Drawing.Point(198, 80);
            this.comboResponsible.Name = "comboResponsible";
            this.comboResponsible.Size = new System.Drawing.Size(200, 24);
            this.comboResponsible.TabIndex = 5;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(198, 110);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(100, 30);
            this.buttonCreate.TabIndex = 6;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(298, 110);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 30);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelError
            // 
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(20, 150);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(300, 30);
            this.labelError.TabIndex = 8;
            // 
            // CreateServiceForm
            // 
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelRequirements);
            this.Controls.Add(this.textBoxRequirements);
            this.Controls.Add(this.labelResponsible);
            this.Controls.Add(this.comboResponsible);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreateServiceForm";
            this.Text = "Создание услуги";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}