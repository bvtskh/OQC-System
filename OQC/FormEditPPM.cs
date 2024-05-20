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
    public partial class FormEditPPM : Form
    {
        public FormEditPPM()
        {
            InitializeComponent();
            using(var db = new ClaimFormEntities())
            {
                var auto = db.TargetPPMs.Where(m => m.Area == "AUTO").FirstOrDefault();
                txbPPMAuto.Text = auto.Target.ToString();
                var OA = db.TargetPPMs.Where(m => m.Area == "OA").FirstOrDefault();
                txbPPMOA.Text = OA.Target.ToString();
                var ID = db.TargetPPMs.Where(m => m.Area == "ID").FirstOrDefault();
                txbPPMID.Text = ID.Target.ToString();
                var ALL = db.TargetPPMs.Where(m => m.Area == "ALL").FirstOrDefault();
                txbPPMALL.Text = ALL.Target.ToString();
            }
        }

        private void OnlyNumberPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new ClaimFormEntities())
            {
                var auto = db.TargetPPMs.Where(m => m.Area == "AUTO").FirstOrDefault();
                auto.Target = int.Parse(txbPPMAuto.Text.Trim());
                db.SaveChanges();
                var OA = db.TargetPPMs.Where(m => m.Area == "OA").FirstOrDefault();
                OA.Target = int.Parse(txbPPMOA.Text.Trim());
                db.SaveChanges();
                var ID = db.TargetPPMs.Where(m => m.Area == "ID").FirstOrDefault();
                ID.Target = int.Parse(txbPPMID.Text.Trim());
                db.SaveChanges();
                var ALL = db.TargetPPMs.Where(m => m.Area == "ALL").FirstOrDefault();
                ALL.Target = int.Parse(txbPPMALL.Text.Trim());
                db.SaveChanges();
                MessageBox.Show("Sửa thành công!");
            }
        }
    }
}
