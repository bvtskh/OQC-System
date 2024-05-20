namespace OQC
{
    partial class FormChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangePassword));
            this.label1 = new System.Windows.Forms.Label();
            this.txbOldPass = new System.Windows.Forms.TextBox();
            this.txbNewPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbReEnter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // txbOldPass
            // 
            this.txbOldPass.Location = new System.Drawing.Point(151, 20);
            this.txbOldPass.Name = "txbOldPass";
            this.txbOldPass.PasswordChar = '*';
            this.txbOldPass.Size = new System.Drawing.Size(100, 20);
            this.txbOldPass.TabIndex = 1;
            // 
            // txbNewPass
            // 
            this.txbNewPass.Location = new System.Drawing.Point(151, 46);
            this.txbNewPass.Name = "txbNewPass";
            this.txbNewPass.PasswordChar = '*';
            this.txbNewPass.Size = new System.Drawing.Size(100, 20);
            this.txbNewPass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu mới";
            // 
            // txbReEnter
            // 
            this.txbReEnter.Location = new System.Drawing.Point(151, 72);
            this.txbReEnter.Name = "txbReEnter";
            this.txbReEnter.PasswordChar = '*';
            this.txbReEnter.Size = new System.Drawing.Size(100, 20);
            this.txbReEnter.TabIndex = 5;
            this.txbReEnter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbReEnter_KeyPress);
            this.txbReEnter.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txbReEnter_PreviewKeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhập lại Mật khẩu mới";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(151, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Maroon;
            this.lblStatus.Location = new System.Drawing.Point(8, 126);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(16, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "...";
            // 
            // FormChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 181);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txbReEnter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbNewPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbOldPass);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChangePassword_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbOldPass;
        private System.Windows.Forms.TextBox txbNewPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbReEnter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStatus;
    }
}