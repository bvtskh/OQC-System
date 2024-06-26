﻿using AntdUI;
using CommonProject.Business;
using OQC.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace OQC
{
    public partial class Login : Window
    {
        BackgroundWorker worker = new BackgroundWorker();
        public Login()
        {
            InitializeComponent();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                this.Hide();
                FormMain main = new FormMain();
                main.ShowDialog();
                this.Close();
            }
            btnLogin.Loading = false;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var db = new ClaimFormEntities())
            {
                string username = txbUser.Text.Trim();
                string pass = txbPass.Text.Trim();
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(pass))
                {
                    string login = CheckUserLogin(username, pass);
                    if (login != "OK")
                    {
                        MessageBox.Show(login);
                        e.Result = null;
                    }
                    else
                    {
                        e.Result = 1;
                    }
                }
                else
                {
                    e.Result = null;
                    MessageBox.Show("Cần nhập tài khoản khi login!");
                }
            }
        }

        private string CheckUserLogin(string username, string pass)
        {
            var userWIP = SingletonHelper.PvsInstance.CheckUserLogin(username, pass);
            if (userWIP == null) return "Chưa có tài khoản WIP";

            var user = SingletonHelper.PvsInstance.FindUser(username, pass);
            if (user == null) return "User chưa được phân quyền dùng phần mềm OQC";
            var module = user.Rules.Where(m => m.MODULE == MODULE_LOGIN.MODULE_OQC_QUANLITY).FirstOrDefault();
            if(module == null) return "User chưa được phân quyền dùng phần mềm OQC";
            Properties.Settings.Default.Account = module.RULE_ID;
            Properties.Settings.Default.Code = username;
            Properties.Settings.Default.Name = user.User.NAME;
            return "OK";
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (!worker.IsBusy)
            {
                btnLogin.Loading = true;
                worker.RunWorkerAsync();
            }           
        }

        private void txbUser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbPass.Focus();
            }
        }

        private void txbPass_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txbUser.Focus();
        }
    }
}
