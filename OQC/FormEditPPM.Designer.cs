namespace OQC
{
    partial class FormEditPPM
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbPPMAuto = new System.Windows.Forms.TextBox();
            this.txbPPMOA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPPMID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txbPPMALL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "AUTO";
            // 
            // txbPPMAuto
            // 
            this.txbPPMAuto.Location = new System.Drawing.Point(112, 20);
            this.txbPPMAuto.Name = "txbPPMAuto";
            this.txbPPMAuto.Size = new System.Drawing.Size(100, 20);
            this.txbPPMAuto.TabIndex = 1;
            this.txbPPMAuto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumberPress);
            // 
            // txbPPMOA
            // 
            this.txbPPMOA.Location = new System.Drawing.Point(112, 46);
            this.txbPPMOA.Name = "txbPPMOA";
            this.txbPPMOA.Size = new System.Drawing.Size(100, 20);
            this.txbPPMOA.TabIndex = 3;
            this.txbPPMOA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumberPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "OA";
            // 
            // txbPPMID
            // 
            this.txbPPMID.Location = new System.Drawing.Point(112, 72);
            this.txbPPMID.Name = "txbPPMID";
            this.txbPPMID.Size = new System.Drawing.Size(100, 20);
            this.txbPPMID.TabIndex = 5;
            this.txbPPMID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumberPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(112, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txbPPMALL
            // 
            this.txbPPMALL.Location = new System.Drawing.Point(112, 98);
            this.txbPPMALL.Name = "txbPPMALL";
            this.txbPPMALL.Size = new System.Drawing.Size(100, 20);
            this.txbPPMALL.TabIndex = 8;
            this.txbPPMALL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumberPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ALL";
            // 
            // FormEditPPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 181);
            this.Controls.Add(this.txbPPMALL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txbPPMID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbPPMOA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbPPMAuto);
            this.Controls.Add(this.label1);
            this.Name = "FormEditPPM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditPPM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbPPMAuto;
        private System.Windows.Forms.TextBox txbPPMOA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPPMID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txbPPMALL;
        private System.Windows.Forms.Label label4;
    }
}