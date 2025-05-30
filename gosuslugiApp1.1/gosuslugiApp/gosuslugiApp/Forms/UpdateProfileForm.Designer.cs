using System;
using System.Drawing;
using System.Windows.Forms;

namespace gosuslugiApp
{
    partial class UpdateProfileForm
    {
        private void InitializeComponent()
        {
            this.labelFullName = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.buttonUpdateProfile = new System.Windows.Forms.Button();
            this.dataGridViewCharacteristics = new System.Windows.Forms.DataGridView();
            this.labelCharacteristicType = new System.Windows.Forms.Label();
            this.comboCharacteristicType = new System.Windows.Forms.ComboBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonAddCharacteristic = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCharacteristics)).BeginInit();
            this.SuspendLayout();
            
            this.labelFullName.Location = new System.Drawing.Point(20, 20);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(100, 20);
            this.labelFullName.TabIndex = 0;
            this.labelFullName.Text = "ФИО:";
            
            this.textBoxFullName.Location = new System.Drawing.Point(120, 20);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(200, 22);
            this.textBoxFullName.TabIndex = 1;
            
            this.labelEmail.Location = new System.Drawing.Point(20, 50);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(100, 20);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "Электронная почта:";
            
            this.textBoxEmail.Location = new System.Drawing.Point(120, 50);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(200, 22);
            this.textBoxEmail.TabIndex = 3;
            
            this.buttonUpdateProfile.Location = new System.Drawing.Point(120, 80);
            this.buttonUpdateProfile.Name = "buttonUpdateProfile";
            this.buttonUpdateProfile.Size = new System.Drawing.Size(100, 30);
            this.buttonUpdateProfile.TabIndex = 4;
            this.buttonUpdateProfile.Text = "Обновить профиль";
            this.buttonUpdateProfile.Click += new System.EventHandler(this.buttonUpdateProfile_Click);
            
            this.dataGridViewCharacteristics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCharacteristics.ColumnHeadersHeight = 29;
            this.dataGridViewCharacteristics.Location = new System.Drawing.Point(20, 120);
            this.dataGridViewCharacteristics.Name = "dataGridViewCharacteristics";
            this.dataGridViewCharacteristics.ReadOnly = true;
            this.dataGridViewCharacteristics.RowHeadersWidth = 51;
            this.dataGridViewCharacteristics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCharacteristics.Size = new System.Drawing.Size(740, 200);
            this.dataGridViewCharacteristics.TabIndex = 5;
             
            this.labelCharacteristicType.Location = new System.Drawing.Point(20, 330);
            this.labelCharacteristicType.Name = "labelCharacteristicType";
            this.labelCharacteristicType.Size = new System.Drawing.Size(100, 20);
            this.labelCharacteristicType.TabIndex = 6;
            this.labelCharacteristicType.Text = "Тип характеристики:";
            
            this.comboCharacteristicType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCharacteristicType.Location = new System.Drawing.Point(120, 330);
            this.comboCharacteristicType.Name = "comboCharacteristicType";
            this.comboCharacteristicType.Size = new System.Drawing.Size(200, 24);
            this.comboCharacteristicType.TabIndex = 7;
            
            this.labelValue.Location = new System.Drawing.Point(20, 360);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(100, 20);
            this.labelValue.TabIndex = 8;
            this.labelValue.Text = "Значение:";
            
            this.textBoxValue.Location = new System.Drawing.Point(120, 360);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(200, 22);
            this.textBoxValue.TabIndex = 9;
            
            this.buttonAddCharacteristic.Location = new System.Drawing.Point(330, 360);
            this.buttonAddCharacteristic.Name = "buttonAddCharacteristic";
            this.buttonAddCharacteristic.Size = new System.Drawing.Size(164, 30);
            this.buttonAddCharacteristic.TabIndex = 10;
            this.buttonAddCharacteristic.Text = "Добавить/Обновить";
            this.buttonAddCharacteristic.Click += new System.EventHandler(this.buttonAddCharacteristic_Click);
           
            this.buttonClose.Location = new System.Drawing.Point(660, 360);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 30);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(20, 400);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(740, 30);
            this.labelError.TabIndex = 12;
             
            this.ClientSize = new System.Drawing.Size(782, 433);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.buttonUpdateProfile);
            this.Controls.Add(this.dataGridViewCharacteristics);
            this.Controls.Add(this.labelCharacteristicType);
            this.Controls.Add(this.comboCharacteristicType);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.buttonAddCharacteristic);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UpdateProfileForm";
            this.Text = "Обновление профиля";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCharacteristics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}