using System;
using System.Drawing;
using System.Windows.Forms;

namespace gosuslugiApp
{
    partial class ManageUsersForm
    {
        private void InitializeComponent()
        {
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.btnRegisterAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            this.lblFullName.Location = new System.Drawing.Point(30, 30);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 23);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "ФИО:";
            
            this.txtFullName.Location = new System.Drawing.Point(150, 30);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(200, 22);
            this.txtFullName.TabIndex = 1;
            
            this.lblEmail.Location = new System.Drawing.Point(30, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            
            this.txtEmail.Location = new System.Drawing.Point(150, 70);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 3;
             
            this.lblPassword.Location = new System.Drawing.Point(30, 110);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 23);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Пароль:";
           
            this.txtPassword.Location = new System.Drawing.Point(150, 110);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            
            this.lblRole.Location = new System.Drawing.Point(30, 150);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 23);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "Роль:";
            
            this.comboRole.Location = new System.Drawing.Point(150, 150);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(200, 24);
            this.comboRole.TabIndex = 7;
            
            this.btnRegisterAdmin.Location = new System.Drawing.Point(100, 190);
            this.btnRegisterAdmin.Name = "btnRegisterAdmin";
            this.btnRegisterAdmin.Size = new System.Drawing.Size(100, 30);
            this.btnRegisterAdmin.TabIndex = 8;
            this.btnRegisterAdmin.Text = "Создать";
            this.btnRegisterAdmin.Click += new System.EventHandler(this.btnRegisterAdmin_Click);
           
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(421, 275);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.btnRegisterAdmin);

            this.Name = "ManageUsersForm";
            this.Text = "Управление пользователями";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}