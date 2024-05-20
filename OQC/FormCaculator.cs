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
    public partial class FormCaculator : Form
    {
        public Action<int> result;
        public FormCaculator()
        {
            InitializeComponent();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            var str = txtEnter.Lines;
            int sum = 0;
            foreach (var line in str)
            {
                try
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        sum += int.Parse(line);
                    }
                  
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhập số " + line + " sai định dạng");
                    return;
                }

            }
            result(sum);
            Close();
        }

        private void OnlyNumberPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //  (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}

        }

    }
}
