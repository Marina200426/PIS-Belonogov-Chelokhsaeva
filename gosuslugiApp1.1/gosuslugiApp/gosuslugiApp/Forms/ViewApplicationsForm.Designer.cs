using System;
using System.Drawing;
using System.Windows.Forms;

namespace gosuslugiApp
{
    partial class ViewApplicationsForm
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private System.ComponentModel.IContainer components = null;     
        private void InitializeComponent()
        {
            this.dataGridViewApplications = new System.Windows.Forms.DataGridView();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApplications)).BeginInit();
            this.SuspendLayout();
            
            this.dataGridViewApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewApplications.ColumnHeadersHeight = 29;
            this.dataGridViewApplications.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewApplications.Name = "dataGridViewApplications";
            this.dataGridViewApplications.ReadOnly = true;
            this.dataGridViewApplications.RowHeadersWidth = 51;
            this.dataGridViewApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewApplications.Size = new System.Drawing.Size(740, 300);
            this.dataGridViewApplications.TabIndex = 0;
            
            this.buttonClose.Location = new System.Drawing.Point(660, 330);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 30);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            
            this.ClientSize = new System.Drawing.Size(856, 409);
            this.Controls.Add(this.dataGridViewApplications);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewApplicationsForm";
            this.Text = "Мои заявки";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApplications)).EndInit();
            this.ResumeLayout(false);

        }
    }
}