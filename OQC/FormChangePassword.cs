using OQC.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OQC
{
    public partial class FormChangePassword : Form
    {

        public FormChangePassword()
        {
            InitializeComponent();

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new ClaimFormEntities())
            {
                var user = db.Users.Where(m => m.Id == Properties.Settings.Default.Code).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("User " + Properties.Settings.Default.Code + " không tồn tại!");
                    return;
                }
                if (txbOldPass.Text.MD5Hash() != user.Password)
                {
                    MessageBox.Show("Mật khẩu cũ nhập không chính xác!");
                    return;
                }
                if (txbNewPass.Text == txbOldPass.Text)
                {
                    MessageBox.Show("Mật khẩu mới và mật khẩu cũ không được trùng nhau!");
                    return;
                }

                var pass = txbNewPass.Text.Trim();
                user.Password = pass.MD5Hash();
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công!");
                Hide();
                new Login().ShowDialog();

            }
        }

        private void txbReEnter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txbNewPass.Text.Contains(txbReEnter.Text))
            {
                lblStatus.Text = "Nhập chưa đúng!";
            }
            else
            {
                lblStatus.Text = "";
            }
        }

        private void txbReEnter_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void FormChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
