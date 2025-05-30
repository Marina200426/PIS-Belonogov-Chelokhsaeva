using System;
using System.Drawing;
using System.Windows.Forms;

namespace gosuslugiApp
{
    partial class RegisterForm
    {
        private void InitializeComponent()
        {
            this.labelFullName = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
             
            this.labelFullName.Location = new System.Drawing.Point(20, 20);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(100, 20);
            this.labelFullName.TabIndex = 0;
            this.labelFullName.Text = "ФИО:";
            
            this.textBoxFullName.Location = new System.Drawing.Point(230, 20);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(200, 22);
            this.textBoxFullName.TabIndex = 1;
             
            this.labelEmail.Location = new System.Drawing.Point(20, 50);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(158, 20);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "Электронная почта:";
             
            this.textBoxEmail.Location = new System.Drawing.Point(230, 48);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(200, 22);
            this.textBoxEmail.TabIndex = 3;
            
            this.labelPassword.Location = new System.Drawing.Point(20, 80);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(100, 20);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Пароль:";
             
            this.textBoxPassword.Location = new System.Drawing.Point(230, 76);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(200, 22);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            
            this.buttonRegister.Location = new System.Drawing.Point(199, 117);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(156, 30);
            this.buttonRegister.TabIndex = 6;
            this.buttonRegister.Text = "Зарегистрироваться";
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
             
            this.buttonClose.Location = new System.Drawing.Point(361, 117);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 30);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
             
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(20, 150);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(300, 30);
            this.labelError.TabIndex = 8;
             
            this.ClientSize = new System.Drawing.Size(623, 311);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}