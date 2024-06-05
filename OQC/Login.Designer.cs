namespace OQC
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.windowBar1 = new AntdUI.WindowBar();
            this.txbUser = new AntdUI.Input();
            this.txbPass = new AntdUI.Input();
            this.btnLogin = new AntdUI.Button();
            this.SuspendLayout();
            // 
            // windowBar1
            // 
            this.windowBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("windowBar1.BackgroundImage")));
            this.windowBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowBar1.Location = new System.Drawing.Point(0, 0);
            this.windowBar1.MaximizeBox = false;
            this.windowBar1.Name = "windowBar1";
            this.windowBar1.Size = new System.Drawing.Size(227, 23);
            this.windowBar1.TabIndex = 5;
            this.windowBar1.Text = "Login";
            // 
            // txbUser
            // 
            this.txbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUser.Location = new System.Drawing.Point(47, 57);
            this.txbUser.Margins = 2;
            this.txbUser.Name = "txbUser";
            this.txbUser.PlaceholderText = "User";
            this.txbUser.Size = new System.Drawing.Size(154, 31);
            this.txbUser.TabIndex = 1;
            this.txbUser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txbUser_PreviewKeyDown);
            // 
            // txbPass
            // 
            this.txbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPass.Location = new System.Drawing.Point(47, 92);
            this.txbPass.Margins = 2;
            this.txbPass.Name = "txbPass";
            this.txbPass.PlaceholderText = "Password";
            this.txbPass.Size = new System.Drawing.Size(154, 31);
            this.txbPass.TabIndex = 2;
            this.txbPass.UseSystemPasswordChar = true;
            this.txbPass.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txbPass_PreviewKeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.BackActive = System.Drawing.Color.Aqua;
            this.btnLogin.BackColor = System.Drawing.Color.Indigo;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(47, 132);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(154, 41);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Type = AntdUI.TTypeMini.Primary;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(227, 181);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.txbUser);
            this.Controls.Add(this.windowBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OQC System";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private AntdUI.WindowBar windowBar1;
        private AntdUI.Input txbUser;
        private AntdUI.Input txbPass;
        private AntdUI.Button btnLogin;
    }
}