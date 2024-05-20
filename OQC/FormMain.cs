using CommonProject.Business;
using CommonProject.PVSWebService;
using OQC.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OQC
{
    public partial class FormMain : Form
    {

        List<TypeNG> listNG = new List<TypeNG>();
        USAPService.USAPWebServiceSoapClient usapService = new USAPService.USAPWebServiceSoapClient();
        public string[] areas = new string[]
        {
            Areas.AUTO,
            Areas.ID,
            Areas.PICKUP,
            Areas.OA
        };
        private string sql = "select [ID],[Customer] ,[Station],[Inspector],[GroupModel],[ModelName] ,[WO] ,[WOQty],[CheckNumber],[Area],[Shift],[NumberNG] , [DateOccur],[Occur_Time] ,[Occur_Line] ,[Serial_Number] ,[Position],[Defection],[Sample_Form],[IsConfirm] from ODI";
        private BindingSource odiDataSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private List<Area> customers;
        DataTable table;
        public FormMain()
        {
            InitializeComponent();
            lblcode.Text = Properties.Settings.Default.Code.ToUpper();
            lblName.Text = Properties.Settings.Default.Name;
            txbInspector.Text = Properties.Settings.Default.Code;
            lblVersion.Text = Utils.GetRunningVersion();
            getCustomer();
            if (Properties.Settings.Default.Account == RoleName.ADMIN)
            {
                btnEditTargetPPM.Visible = true;
            }
            else
            {
                btnEditTargetPPM.Visible = false;

            }
            if (Properties.Settings.Default.Account <= RoleName.LEADER && Properties.Settings.Default.Account > 0)
            {
                btnConfirmData.Visible = true;
            }
            else
            {
                btnConfirmData.Visible = false;
            }
            lblStatus.Text = "";

            using (var db = new ClaimFormEntities())
            {
                listNG = db.TypeNGs.ToList();
                foreach (var ng in listNG)
                {
                    cbbTypeNG.Items.Add(ng.TypeNG1);
                }

            }

            adgrvODi.DataSource = odiDataSource;
            odiDataSource.DataSource = table;
            GetListODIs();
            odiDataSource.ListChanged += OdiDataSource_ListChanged;
            GetTotal();
            this.ActiveControl = txbDateOccur;
        }

        private void getCustomer()
        {
            using (var db = new ClaimFormEntities())
            {
                customers = db.Areas.ToList();
                foreach (var cus in customers)
                {
                    cbbCustomer.Items.Add(cus.Customer);
                }

            }
        }
        private void OdiDataSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            lblNumberRow.Text = string.Format("{0} Rows", this.odiDataSource.List.Count);
        }

        private bool ValidateEntry()
        {
            if (string.IsNullOrEmpty(txbDateOccur.Text))
            {
                btnDateOccur.Focus();
                lblStatus.Text = "Chưa Chọn Ngày Phát Sinh Lỗi";
                return false;
            }

            if (string.IsNullOrEmpty(cbbCustomer.Text))
            {
                cbbCustomer.Focus();
                lblStatus.Text = "Chưa chọn khách hàng";
                return false;
            }
            if (!rbShiftDay.Checked && !rbShiftNight.Checked)
            {
                lblStatus.Text = "Chưa chọn shift";
                return false;
            }
            if (!rbStationOQC1.Checked && !rbStationOQC2.Checked && !rbStationCSL.Checked)
            {
                lblStatus.Text = "Chưa chọn station";
                return false;
            }
            if (!rb100Per.Checked && !rbAQL.Checked && !rb50Per.Checked)
            {
                lblStatus.Text = "Chưa chọn hình thức lấy mẫu";
                return false;
            }
            if (string.IsNullOrEmpty(txbInspector.Text))
            {
                lblStatus.Text = "Chưa nhập Inspector";
                txbInspector.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txbGroupModel.Text))
            {
                lblStatus.Text = "Chưa nhập Group Model";
                txbGroupModel.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txbModelName.Text))
            {
                lblStatus.Text = "Chưa nhập Model Name";
                txbModelName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txbWO.Text) || txbWO.Text.Length < 6)
            {
                lblStatus.Text = "WO chưa nhập hoặc nhập thiếu";
                txbWO.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txbWOQty.Text))
            {
                lblStatus.Text = "Chưa nhập số lượng WO";
                txbWOQty.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txbNumerCheck.Text))
            {
                lblStatus.Text = "Chưa nhập số lượng kiểm";
                txbNumerCheck.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txbNumberNG.Text))
            {
                lblStatus.Text = "Chưa nhập số lượng lỗi";
                txbNumberNG.Focus();
                return false;
            }
            if (int.Parse(txbNumberNG.Text.Trim()) == 0 && !string.IsNullOrEmpty(NG_Photo))
            {
                DialogResult dialogResult = MessageBox.Show("Số lượng lỗi bằng 0 mà vẫn có ảnh NG!", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    return true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    lblStatus.Text = "";
                    txbNumberNG.Focus();
                }

                return false;
            }
            if (int.Parse(txbNumberNG.Text.Trim()) == 0)
            {
                return true;
            }
            if (string.IsNullOrEmpty(dtpTimeOccur.Text))
            {
                lblStatus.Text = "Chưa chọn thời gian phát sinh lỗi";
                dtpTimeOccur.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txbLine.Text))
            {
                lblStatus.Text = "Chưa nhập line phát sinh lỗi";
                txbLine.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txbPosition.Text))
            {
                lblStatus.Text = "Chưa nhập vị trí lỗi";
                txbPosition.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbTypeNG.Text))
            {
                lblStatus.Text = "Chưa chọn loại lỗi";
                cbbTypeNG.Focus();
                return false;
            }
            var ng = listNG.Where(m => m.TypeNG1 == cbbTypeNG.Text.Trim()).FirstOrDefault();
            if (string.IsNullOrEmpty(txbNGDetail.Text) && ng != null && ng.ID == 36)
            {
                lblStatus.Text = "Chưa nhập mô tả lỗi";
                txbNumberNG.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(NG_Photo))
            {

                lblStatus.Text = "Chưa chọn hình ảnh lỗi";
                btnAddNG.Focus();
                return false;
            }


            return true;
        }

        private void cbbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        private void txbInspector_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        private void txbModelName_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        
        private void txbWOQty_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        private void txbNumerCheck_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        private void txbNumberNG_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        private void dtpDateOccur_ValueChanged(object sender, EventArgs e)
        {
            txbDateOccur.Text = dtpDateOccur.Value.ToString("dd/MM/yyy");
            compareDate();
            GetTotal();
        }

        private void GetTotal()
        {
            try
            {
                using (var db = new ClaimFormEntities())
                {
                    int totalCheck = 0;
                    int totalNG = 0;
                    var dateOccur = DateTime.ParseExact(txbDateOccur.Text.Trim(), "dd/MM/yyyy", null);
                    if (string.IsNullOrEmpty(cbbCustomer.Text))
                    {
                        totalCheck = db.ODIs.Where(m => m.DateOccur == dateOccur && m.IsConfirm == true).Sum(m => m.CheckNumber);
                        totalNG = db.ODIs.Where(m => m.DateOccur == dateOccur && m.IsConfirm == true).Sum(m => m.NumberNG);
                    }
                    else
                    {
                        totalCheck = db.ODIs.Where(m => m.DateOccur == dateOccur && m.Customer == cbbCustomer.Text.Trim() && m.IsConfirm == true).Sum(m => m.CheckNumber);
                        totalNG = db.ODIs.Where(m => m.DateOccur == dateOccur && m.Customer == cbbCustomer.Text.Trim() && m.IsConfirm == true).Sum(m => m.NumberNG);
                    }

                    lblTotalCheck.Text = totalCheck.ToString();
                    lblNG.Text = totalNG.ToString();
                    if (totalCheck != 0)
                    {
                        var ppm1 = ((float)totalNG * 1000000 / totalCheck);
                        double ppm = Math.Round(ppm1, 1);
                        lblPPM.Text = ppm.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                lblTotalCheck.Text = "0";
                lblNG.Text = "0";
                lblPPM.Text = "0";

            }

        }
        private void GetListODIs()
        {
            pbLoading.Visible = true;
            odiDataSource.Filter = "";
            bgwLoading.RunWorkerAsync();
        }
        private void updateLabelConfirm()
        {
            using (var db = new ClaimFormEntities())
            {
                var countNotConfirm = db.ODIs.Where(m => m.IsConfirm == false).Count();
                if (countNotConfirm == 0)
                {
                    lblNotice.Text = "";
                }
                else
                    lblNotice.Text = countNotConfirm + " rows not confirm!";
            }
        }
        private void updateAll()
        {
            updateLabelConfirm();
            GetTotal();
            GetTotalByOP();
            GetTotalByGroup();
            GetTotalByModel();
            GetTotalByShift(SHIFT.DAY);
            GetTotalByShift(SHIFT.NIGHT);
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

        string NG_Photo = "";
        string OK_Photo = "";
        private void btnAddNG_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.FilterIndex = 1;
                choofdlog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    NG_Photo = Guid.NewGuid().ToString() + Path.GetFileName(choofdlog.FileName);
                    pbNG.Image = new Bitmap(choofdlog.FileName);
                    Utils.UploadFile("172.28.10.17", @"VN\U34811", "hoan200794", choofdlog.FileName, @"\OQC\" + NG_Photo);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnAddOK_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.FilterIndex = 1;
                choofdlog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    OK_Photo = Guid.NewGuid().ToString() + Path.GetFileName(choofdlog.FileName);
                    pbOK.Image = new Bitmap(choofdlog.FileName);
                    Utils.UploadFile("172.28.10.17", @"VN\U34811", "hoan200794", choofdlog.FileName, @"\OQC\" + OK_Photo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnSaveODI_Click(object sender, EventArgs e)
        {
            submit(sender);

        }
        private void submit(object sender)
        {
            if (ValidateEntry())
            {
                using (var db = new ClaimFormEntities())
                {
                    string station = "";
                    if (rbStationOQC1.Checked)
                    {
                        station = OQC.Station.OQC1;
                    }
                    else if (rbStationOQC2.Checked)
                    {
                        station = OQC.Station.OQC2;
                    }
                    else if (rbStationCSL.Checked)
                    {
                        station = OQC.Station.CSL;
                    }
                    string sampleForm = "";
                    if (rb100Per.Checked)
                    {
                        sampleForm = OQC.SampleForm.SF100PER;
                    }
                    else if (rb50Per.Checked)
                    {
                        sampleForm = SampleForm.SF50PER;
                    }
                    else if (rbAQL.Checked)
                    {
                        sampleForm = SampleForm.SFAQL;
                    }
                    string shift = rbShiftDay.Checked ? OQC.SHIFT.DAY : OQC.SHIFT.NIGHT;
                    var ODI = db.ODIs.Where(m => m.ID == IDODI).FirstOrDefault();
                    DateTime dateOccur = DateTime.Now;
                    try
                    {
                        dateOccur = DateTime.ParseExact(txbDateOccur.Text.Trim(), "dd/MM/yyyy", null);
                    }
                    catch
                    {
                        MessageBox.Show("Xem lại định dạng ngày!");
                        txbDateOccur.Focus();
                        return;
                    }

                    if (ODI != null)
                    {
                        if (!CheckOverLoad(ODI.Station, ODI.CheckNumber)) return;
                        ODI.DateOccur = dateOccur;
                        ODI.Area = txbArea.Text;
                        ODI.Customer = cbbCustomer.Text;
                        ODI.Shift = shift;
                        ODI.Station = station;
                        ODI.Inspector = txbInspector.Text;
                        ODI.GroupModel = txbGroupModel.Text;
                        ODI.ModelName = txbModelName.Text;
                        ODI.WO = txbWO.Text;
                        ODI.WOQty = int.Parse(txbWOQty.Text);
                        ODI.CheckNumber = int.Parse(txbNumerCheck.Text);
                        ODI.NumberNG = int.Parse(txbNumberNG.Text);
                        ODI.Note = txbNote.Text;
                        if (ODI.NumberNG != 0)
                        {
                            ODI.Occur_Time = dtpTimeOccur.Value.ToShortTimeString();
                            ODI.Occur_Line = txbLine.Text;
                            ODI.Serial_Number = txbSerial.Text;
                            ODI.Position = txbPosition.Text;
                            ODI.Defection = cbbTypeNG.Text;
                            ODI.Detail = txbNGDetail.Text;
                            ODI.NG_Photo = NG_Photo;
                            ODI.OK_Photo = OK_Photo;
                        }

                        ODI.Sample_Form = sampleForm;

                        db.SaveChanges();

                        DataRow dr = table.Select("ID=" + ODI.ID).FirstOrDefault();
                        if (dr != null)
                        {
                            dr["DateOccur"] = ODI.DateOccur;
                            dr["Area"] = ODI.Area;
                            dr["Customer"] = ODI.Customer;
                            dr["Shift"] = ODI.Shift;
                            dr["Station"] = ODI.Station;
                            dr["Inspector"] = ODI.Inspector;
                            dr["GroupModel"] = ODI.GroupModel;
                            dr["ModelName"] = ODI.ModelName;
                            dr["WO"] = ODI.WO;
                            dr["WOQty"] = ODI.WOQty;
                            dr["CheckNumber"] = ODI.CheckNumber;
                            dr["NumberNG"] = ODI.NumberNG;
                            dr["Occur_Time"] = ODI.Occur_Time;
                            dr["Occur_Line"] = ODI.Occur_Line;
                            dr["Serial_Number"] = ODI.Serial_Number;
                            dr["Position"] = ODI.Position;
                            dr["Defection"] = ODI.Defection;
                            dr["Sample_Form"] = ODI.Sample_Form;
                            dr["IsConfirm"] = ODI.IsConfirm;

                        }
                        adgrvODi.Refresh();
                    }
                    else
                    {

                        ODI = new ODI()
                        {
                            DateOccur = dateOccur,
                            Area = txbArea.Text,
                            Customer = cbbCustomer.Text,
                            Shift = shift,
                            Station = station,
                            Inspector = txbInspector.Text,
                            GroupModel = txbGroupModel.Text,
                            ModelName = txbModelName.Text,
                            WO = txbWO.Text,
                            WOQty = int.Parse(txbWOQty.Text),
                            CheckNumber = int.Parse(txbNumerCheck.Text),
                            NumberNG = int.Parse(txbNumberNG.Text),
                            Note = txbNote.Text,
                            Occur_Time = dtpTimeOccur.Value.ToShortTimeString(),
                            Occur_Line = txbLine.Text,
                            Serial_Number = txbSerial.Text,
                            Position = txbPosition.Text,
                            Defection = cbbTypeNG.Text,
                            Detail = txbNGDetail.Text,
                            NG_Photo = NG_Photo,
                            OK_Photo = OK_Photo,
                            Sample_Form = sampleForm,
                            IsConfirm = true
                        };
                        if (Properties.Settings.Default.Account == RoleName.OPERATOR)
                        {
                            ODI.IsConfirm = false;
                        }
                        if (ODI.NumberNG == 0)
                        {
                            ODI.NG_Photo = "";
                            ODI.OK_Photo = "";
                            ODI.Occur_Time = DateTime.Now.ToShortTimeString();
                            ODI.Occur_Line = "";
                            ODI.Serial_Number = "";
                            ODI.Position = "";
                            ODI.Defection = "";
                            ODI.Detail = "";
                            ODI.NG_Photo = NG_Photo;
                            ODI.OK_Photo = OK_Photo;
                        }
                        db.ODIs.Add(ODI);
                        if (!CheckOverLoad(ODI.Station, 0)) return;
                        db.SaveChanges();
                       

                        table.Rows.Add(ODI.ID, ODI.Customer, ODI.Station, ODI.Inspector, ODI.GroupModel, ODI.ModelName, ODI.WO,
                       ODI.WOQty, ODI.CheckNumber, ODI.Area, ODI.Shift, ODI.NumberNG, ODI.DateOccur, ODI.Occur_Time, ODI.Occur_Line,
                       ODI.Serial_Number, ODI.Position, ODI.Defection, ODI.Sample_Form, ODI.IsConfirm);
                        adgrvODi.Refresh();
                        var model = SingletonHelper.PvsInstance.GetModelInfo(ODI.ModelName);

                        if (model == null)
                        {
                            var entity = new Base_ModelsEntity();
                            entity.Customer = "";
                            entity.Des = ODI.Customer;
                            entity.Pcb = 1;
                            entity.Group_Id = ODI.GroupModel;
                            entity.Product_Id = ODI.ModelName;
                            SingletonHelper.PvsInstance.SaveModelInfo(entity, "");
                        }
                        else if (string.IsNullOrEmpty(model.Group_Id))
                        {
                            model.Group_Id = ODI.GroupModel;
                            SingletonHelper.PvsInstance.SaveModelInfo(model, ODI.ModelName);
                        }
                    }
                    ODIHelper.UpdateWOQty(ODI.WO, ODI.WOQty);
                    if (adgrvODi.RowCount > 1)
                        adgrvODi.FirstDisplayedScrollingRowIndex = adgrvODi.RowCount - 1;

                    if (((Button)sender).Name == "btnSaveODI" || ((Button)sender).Name == "btnCreate")
                    {
                        ResetDataKeepInspector();
                    }
                    else
                    {
                        ResetData();
                    }
                    btnCreate.Visible = false;
                    updateAll();

                }
            }
        }
        private void ResetDataKeepInspector()
        {

            txbGroupModel.Text = "";
            txbModelName.Text = "";
            txbWO.Text = "";
            txbWOQty.Text = "";
            txbNumerCheck.Text = "";
            txbNumberNG.Text = "";
            txbNote.Text = "";
            dtpTimeOccur.Value = DateTime.Now;
            txbLine.Text = "";
            txbSerial.Text = "";
            txbPosition.Text = "";
            cbbTypeNG.Text = "";
            txbNGDetail.Text = "";
            NG_Photo = "";
            OK_Photo = "";
            pbNG.Image = null;
            pbOK.Image = null;
            txbWO.Focus();
            btnSaveODI.Text = "SUBMIT";
            btnSubmitNext.Text = "SUBMIT/NEXT";
            IDODI = 0;
            lblStatus.Text = "";
        }

        int IDODI = 0;

        private void ResetData()
        {
            txbInspector.Text = "";
            txbGroupModel.Text = "";
            txbModelName.Text = "";
            txbWO.Text = "";
            txbWOQty.Text = "";
            txbNumerCheck.Text = "";
            txbNumberNG.Text = "";
            txbNote.Text = "";
            dtpTimeOccur.Value = DateTime.Now;
            txbLine.Text = "";
            txbSerial.Text = "";
            txbPosition.Text = "";
            cbbTypeNG.Text = "";
            txbNGDetail.Text = "";
            NG_Photo = "";
            OK_Photo = "";
            pbNG.Image = null;
            pbOK.Image = null;
            txbInspector.Focus();
            btnSaveODI.Text = "SUBMIT";
            btnSubmitNext.Text = "SUBMIT/NEXT";
            IDODI = 0;
            lblStatus.Text = "";
        }
        private void txbInspector_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbWO.SelectAll();
                txbWO.Focus();
                GetTotalByOP();
            }
        }
        private void GetTotalByOP()
        {
            try
            {
                using (var db = new ClaimFormEntities())
                {
                    var dateOccur = DateTime.ParseExact(txbDateOccur.Text.Trim(), "dd/MM/yyyy", null);
                    var totalCheck = db.ODIs.Where(m => m.DateOccur == dateOccur && m.Inspector == txbInspector.Text.Trim() && m.IsConfirm == true).Sum(m => m.CheckNumber);
                    lblOP.Text = totalCheck.ToString();
                }
            }
            catch (Exception)
            {
                lblOP.Text = "0";
            }
        }
        private void GetTotalByGroup()
        {
            try
            {
                using (var db = new ClaimFormEntities())
                {
                    var dateOccur = DateTime.ParseExact(txbDateOccur.Text.Trim(), "dd/MM/yyyy", null);
                    var totalCheck = db.ODIs.Where(m => m.DateOccur == dateOccur && m.GroupModel == txbGroupModel.Text.Trim() && m.IsConfirm == true).Sum(m => m.CheckNumber);

                    lblGroup.Text = totalCheck.ToString();
                }
            }
            catch (Exception e)
            {
                lblGroup.Text = "0";
            }
        }
        private void GetTotalByModel()
        {
            try
            {
                using (var db = new ClaimFormEntities())
                {
                    var dateOccur = DateTime.ParseExact(txbDateOccur.Text.Trim(), "dd/MM/yyyy", null);
                    var totalCheck = db.ODIs.Where(m => m.DateOccur == dateOccur && m.ModelName == txbModelName.Text.Trim() && m.IsConfirm == true).Sum(m => m.CheckNumber);
                    lblModel.Text = totalCheck.ToString();
                    lblModel.Text = totalCheck.ToString();
                    lblModel.Text = totalCheck.ToString();
                    lblModel.Text = totalCheck.ToString();
                }
            }
            catch (Exception)
            {
                lblModel.Text = "0";
            }
        }
        private void GetTotalByShift(string shift)
        {
            try
            {
                using (var db = new ClaimFormEntities())
                {
                    List<ODI> totalCheck = new List<ODI>();
                    var dateOccur = DateTime.ParseExact(txbDateOccur.Text.Trim(), "dd/MM/yyyy", null);
                    if (string.IsNullOrEmpty(cbbCustomer.Text))
                    {
                        totalCheck = db.ODIs.Where(m => m.DateOccur == dateOccur && m.Shift == shift && m.IsConfirm == true).ToList();
                    }
                    else
                    {
                        totalCheck = db.ODIs.Where(m => m.DateOccur == dateOccur && m.Shift == shift && m.Customer == cbbCustomer.Text.Trim() && m.IsConfirm == true).ToList();
                    }

                    if (totalCheck != null && totalCheck.Count > 0)
                    {
                        if (shift == OQC.SHIFT.DAY)
                        {
                            lblDay.Text = totalCheck.Sum(m => m.CheckNumber).ToString();
                        }
                        else
                        {
                            lblNight.Text = totalCheck.Sum(m => m.CheckNumber).ToString();
                        }
                    }
                    else
                    {
                        lblDay.Text = "0";
                        lblNight.Text = "0";
                    }


                }
            }
            catch (Exception e)
            {
                lblDay.Text = "0";
                lblNight.Text = "0";
            }
        }
        private void txbGroupModel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txbWOQty.Text))
                {
                    txbWOQty.SelectAll();
                    txbWOQty.Focus();

                }
                else
                {
                    txbNumerCheck.SelectAll();
                    txbNumerCheck.Focus();
                }
               
                GetTotalByGroup();
            }
        }

        private void txbWOEnterFinish()
        {
            SearchModelByWork();
            var qty = SearchQtyByWo(txbWO.Text.Trim());
            txbModelName.SelectAll();
            txbModelName.Focus();
            if (qty == 0)
            {
                txbWOQty.Enabled = true;
            }
            else
            {
                txbWOQty.Enabled = PermisionHelper.CheckIsLeader() ? true : false;
                txbWOQty.Text = qty.ToString();
            }
           
        }

        private int SearchQtyByWo(string WO)
        {
            using (var db = new ClaimFormEntities())
            {
                var wo = db.ODIs.Where(m => m.WO == WO).FirstOrDefault();
                if (wo != null) return wo.WOQty;
                else return 0;
            }
        }

        private void SearchModelByWork()
        {
            var BCLBFLMInfo = usapService.GetByTnNo("002000" + txbWO.Text);
            string partNo = "";
            if (BCLBFLMInfo != null)
            {
                partNo = BCLBFLMInfo.PART_NO;
            }
            else
            {
                var order = SingletonHelper.PvsInstance.GetWorkOrdersByOrderNo("2000" + txbWO.Text);
                if (order != null)
                {
                    partNo = order.PRODUCT_ID;
                }
            }
            var split = partNo.Split('-');
            if (split != null && split.Length == 3 && split[2].Contains("000SS0"))
            {
                partNo = split[0] + "-" + split[1];
            }
            txbModelName.Text = partNo;
            GetTotalByModel();
            var modelInfo = SingletonHelper.PvsInstance.GetModelInfo(txbModelName.Text.Trim());
            if (modelInfo != null && !string.IsNullOrEmpty(modelInfo.Group_Id))
            {
                txbGroupModel.Text = modelInfo.Group_Id;
            }
        }
        private void txbNumerCheck_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbNumberNG.SelectAll();
                txbNumberNG.Focus();
            }
        }

        private void txbWOQty_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbNumerCheck.SelectAll();
                txbNumerCheck.Focus();
            }
        }

        private bool CheckOverLoad(string station, int oldSLKiem = 0)
        {
            using (var db = new ClaimFormEntities())
            {
                int sum = 0;
                var woDB = db.ODIs.Where(m => m.WO == txbWO.Text.Trim() && m.Station == station).ToList();
                if (woDB != null) sum = woDB.Sum(m => m.CheckNumber);
                var slKiem = int.Parse(txbNumerCheck.Text.Trim());
                slKiem = slKiem + (sum - oldSLKiem);

                var total = int.Parse(txbWOQty.Text.Trim());
                if (slKiem > total)
                {
                    MessageBox.Show("Số lượng kiểm tra là " + slKiem + " vượt quá số lượng của wo! Vui lòng kiểm tra lại!");
                    return false;
                }
                return true;
            }
        }

        private void txbNote_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txbNumberNG.Text == "0")
                {
                    btnSaveODI.Focus();
                }
                else
                    dtpTimeOccur.Focus();
            }
        }

        private void txbNumberNG_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txbNote.SelectAll();
                txbNote.Focus();
            }
        }

        private void dtpTimeOccur_ValueChanged(object sender, EventArgs e)
        {
            txbLine.SelectAll();
            txbLine.Focus();
        }

        private void txbLine_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbSerial.SelectAll();
                txbSerial.Focus();
            }

        }

        private void txbPosition_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbbTypeNG.SelectAll();
                cbbTypeNG.Focus();
            }
        }

        private void txbSerial_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbPosition.SelectAll();
                txbPosition.Focus();
            }
        }

        private void txbNGDetail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddNG.Focus();
            }
        }

        private void txbModelName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetTotalByModel();
                var modelInfo = SingletonHelper.PvsInstance.GetModelInfo(txbModelName.Text.Trim());
                if (modelInfo != null && !string.IsNullOrEmpty(modelInfo.Group_Id))
                {
                    txbGroupModel.Text = modelInfo.Group_Id;
                }
                txbGroupModel.SelectAll();
                txbGroupModel.Focus();
            }
        }


        private void dtpTimeOccur_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbLine.SelectAll();
                txbLine.Focus();
            }

        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                using (var db = new ClaimFormEntities())
                {
                    if (IDODI == 0)
                    {
                        MessageBox.Show("Chọn một ODI để xóa!");
                        return;
                    }
                    var ODI = db.ODIs.Where(m => m.ID == IDODI).FirstOrDefault();
                    if (ODI == null)
                    {
                        MessageBox.Show("ODI không tồn tại!");
                        return;
                    }
                    db.ODIs.Remove(ODI);
                    db.SaveChanges();
                    DataRow dr = table.Select("ID=" + ODI.ID).FirstOrDefault();
                    if (dr != null)
                    {
                        dr.Delete();
                        adgrvODi.Refresh();
                    }
                    updateAll();
                    ResetDataKeepInspector();

                }
            }

        }
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            // Do stuff only if the radio button is checked (or the action will run twice).
            if (((RadioButton)sender).Checked)
            {
                GetTotalByShift(rbShiftDay.Checked == true ? OQC.SHIFT.DAY : OQC.SHIFT.NIGHT);

            }
        }

        private void btnDateOccur_Click(object sender, EventArgs e)
        {
            dtpDateOccur.Open();
        }


        private void compareDate()
        {
            dpFrom.Value = dtpDateOccur.Value.Date;
            dpTo.Value = dtpDateOccur.Value.Date;
            //GetListODIs();
        }


        private void adgrvODi_FilterStringChanged(object sender, EventArgs e)
        {
            odiDataSource.Filter = this.adgrvODi.FilterString;
        }

        private void adgrvODi_SortStringChanged(object sender, EventArgs e)
        {
            odiDataSource.Sort = this.adgrvODi.SortString;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetListODIs();
        }


        private void adgrvODi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow r = adgrvODi.Rows[e.RowIndex];
                IDODI = int.Parse(r.Cells["ID"].Value.ToString());
                btnSaveODI.Text = "EDIT";
                btnSubmitNext.Text = "EDIT/NEXT";
                btnCreate.Visible = true;
                if (IDODI == 0) return;
                using (var db = new ClaimFormEntities())
                {
                    var odi = db.ODIs.Where(m => m.ID == IDODI).FirstOrDefault();
                    txbDateOccur.Text = odi.DateOccur.ToString("dd/MM/yyy");
                    txbArea.Text = odi.Area;
                    cbbCustomer.Text = odi.Customer;
                    rbShiftDay.Checked = odi.Shift == OQC.SHIFT.DAY;
                    if (odi.Station == OQC.Station.OQC1)
                    {
                        rbStationOQC1.Checked = true;
                    }
                    else if (odi.Station == OQC.Station.OQC2)
                    {
                        rbStationOQC2.Checked = true;
                    }
                    else if (odi.Station == OQC.Station.CSL)
                    {
                        rbStationCSL.Checked = true;
                    }
                    if (odi.Shift == OQC.SHIFT.DAY)
                    {
                        rbShiftDay.Checked = true;
                    }
                    else
                    {
                        rbShiftNight.Checked = true;
                    }
                    if (odi.Sample_Form == SampleForm.SFAQL)
                    {
                        rbAQL.Checked = true;
                    }
                    else if (odi.Sample_Form == SampleForm.SF100PER)
                    {
                        rb100Per.Checked = true;
                    }
                    else if (odi.Sample_Form == SampleForm.SF50PER)
                    {
                        rb50Per.Checked = true;
                    }
                    txbInspector.Text = odi.Inspector;
                    txbGroupModel.Text = odi.GroupModel;
                    txbModelName.Text = odi.ModelName;
                    txbWO.Text = odi.WO;
                    txbWOQty.Text = odi.WOQty.ToString();
                    txbNumerCheck.Text = odi.CheckNumber.ToString();
                    txbNumberNG.Text = odi.NumberNG.ToString();
                    txbNote.Text = odi.Note;
                    dtpTimeOccur.Value = DateTime.Parse(odi.Occur_Time);
                    txbLine.Text = odi.Occur_Line;
                    txbSerial.Text = odi.Serial_Number;
                    txbPosition.Text = odi.Position;
                    cbbTypeNG.Text = odi.Defection;
                    txbNGDetail.Text = odi.Detail;
                    if (!string.IsNullOrEmpty(odi.NG_Photo))
                    {
                        NG_Photo = odi.NG_Photo;
                        pbNG.Image = new Bitmap(
                            Utils.DownloadFile("172.28.10.17", @"VN\U34811", "hoan200794", Application.StartupPath + "/" + odi.NG_Photo,
                            "/OQC/" + odi.NG_Photo));
                    }
                    else
                    {
                        NG_Photo = "";
                        pbNG.Image = null;
                    }
                    if (!string.IsNullOrEmpty(odi.OK_Photo))
                    {
                        OK_Photo = odi.OK_Photo;
                        pbOK.Image = new Bitmap(Utils.DownloadFile("172.28.10.17", @"VN\U34811", "hoan200794", Application.StartupPath + "/" + odi.OK_Photo, "/OQC/" + odi.OK_Photo));

                    }
                    else
                    {
                        OK_Photo = "";
                        pbOK.Image = null;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var choofdlog = new FolderBrowserDialog();

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var number = lblNumberRow.Text.Split(' ');
                    var countRow = int.Parse(number[0]);
                    string fileName = Utils.GetFileName(choofdlog, Constants.EXCEL_STAFF);
                    if (countRow < 65536)
                    {
                        lblExport.Text = "Waiting...";
                        bgWorker.RunWorkerAsync(argument: fileName);
                    }
                    else
                    {
                        // Don't save if no data is returned
                        var dgv = adgrvODi;
                        if (dgv.Rows.Count == 0)
                        {
                            return;
                        }
                        StringBuilder sb = new StringBuilder();
                        // Column headers
                        string columnsHeader = "";
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            columnsHeader += dgv.Columns[i].Name + ",";
                        }
                        sb.Append(columnsHeader + Environment.NewLine);
                        // Go through each cell in the datagridview
                        foreach (DataGridViewRow dgvRow in dgv.Rows)
                        {
                            // Make sure it's not an empty row.
                            if (!dgvRow.IsNewRow)
                            {
                                if (!string.IsNullOrEmpty(dgvRow.Cells[17].Value.ToString()))
                                {
                                    Console.Write("");
                                }
                                for (int c = 0; c < dgvRow.Cells.Count; c++)
                                {
                                    // Append the cells data followed by a comma to delimit.
                                    sb.Append(dgvRow.Cells[c].Value.ToString() + ",");
                                }
                                // Add a new line in the text file.
                                sb.Append(Environment.NewLine);
                            }
                        }
                        // Load up the save file dialog with the default option as saving as a .csv file.
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "CSV files (*.csv)|*.csv";
                        sfd.FileName = fileName;
                        if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            // If they've selected a save location...
                            using (StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, Encoding.UTF8))
                            {
                                // Write the stringbuilder text to the the file.
                                sw.WriteLine(sb.ToString());
                            }
                            MessageBox.Show("Đã xuất file csv thành công!");

                        }

                        //lblPathRoot.Text = @"C:\DATA_BIVN_PACKING_CSV_FILE";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
        }



        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var result = (Tuple<int, string>)e.Result;
            MessageBox.Show(result.Item2);
            lblExport.Text = "";
        }

        private void txbDateOccur_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            cbbCustomer.Focus();
        }

        private void cbbCustomer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txbArea.Text = customers.Where(m => m.Customer == cbbCustomer.Text).FirstOrDefault().Area1;
            if (txbArea.Text == "AUTO")
            {
                rb100Per.Checked = true;
            }
            GetTotal();

        }

        private void rbShiftDay_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            rbShiftNight.Focus();
        }

        private void rbShiftNight_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            rbStationOQC1.Focus();
        }

        private void rbStationOQC1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            rbStationOQC2.Focus();
        }

        private void rbStationOQC2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            rbStationCSL.Focus();
        }

        private void rbStationCSL_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            rb100Per.Focus();
        }

        private void rb100Per_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            rbAQL.Focus();
        }

        private void rbAQL_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            rb50Per.Focus();
        }

        private void rb50Per_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            txbInspector.Focus();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            IDODI = 0;
            submit(sender);

        }

        private void btnEditTargetPPM_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void btnEditTargetPPM_Click(object sender, EventArgs e)
        {
            new FormEditPPM().ShowDialog();
        }

        private void btnConfirmData_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Area == null)
            {
                new FormNhapKhachHang().ShowDialog();
                return;
            }
            if (MessageBox.Show("Bạn có muốn xác nhận dữ liệu đã nhập không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                using (var db = new ClaimFormEntities())
                {
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            int count = 0;
                            var list = table.Select("Check = True").ToList();
                            foreach (var r in list)
                            {
                                if ((bool)r["Check"] == true && r["ID"] != null)
                                {
                                    int IDODI = int.Parse(r["ID"].ToString());
                                    var odi = db.ODIs.Where(m => m.ID == IDODI).FirstOrDefault();
                                    if (odi != null)
                                    {
                                        if (odi.Area == Properties.Settings.Default.Area || Properties.Settings.Default.Area == Areas.ALL)
                                        {
                                            if (odi.IsConfirm == null || (odi.IsConfirm is bool isconfirm && !isconfirm))
                                            {
                                                odi.IsConfirm = true;
                                                db.SaveChanges();
                                                count++;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Đang thực hiện confirm dữ liệu không thuộc khách hàng mà bạn quản lý. Vui lòng kiểm tra lại!");
                                            transaction.Rollback();
                                            return;
                                        }


                                    }
                                }
                            }

                            transaction.Commit();
                            GetListODIs();
                            updateAll();
                            MessageBox.Show("Confirm thành công " + count.ToString() + " rows!");


                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }

                }
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            Properties.Settings.Default.Account = 0;
            new Login().ShowDialog();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            Hide();
            var changePass = new FormChangePassword();
            changePass.ShowDialog();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            var sumDialog = new FormCaculator();
            sumDialog.result = (sum) =>
            {
                if (!string.IsNullOrEmpty(txbNumerCheck.Text))
                {
                    sum += int.Parse(txbNumerCheck.Text.Trim());
                }
                txbNumerCheck.Text = sum.ToString();
            };
            sumDialog.ShowDialog();

        }
        private void getData()
        {
            using (var db = new ClaimFormEntities())
            {
                var dateFrom = dpFrom.Value.Date;
                var dateTo = dpTo.Value.Date;
                var list = db.ODIs.Where(m => m.DateOccur >= dateFrom && m.DateOccur <= dateTo).Take(10).ToList();
                table.Clear();
                foreach (var item in list)
                {
                    table.Rows.Add(item.ID, item.Customer, item.Station, item.Inspector, item.GroupModel, item.ModelName, item.WO,
                    item.WOQty, item.CheckNumber, item.Area, item.Shift, item.NumberNG, item.DateOccur, item.Occur_Time, item.Occur_Line,
                    item.Serial_Number, item.Position, item.Defection, item.Sample_Form, item.IsConfirm);
                }

                odiDataSource.DataSource = null;
                odiDataSource.DataSource = table;
                for (int i = 0; i < adgrvODi.ColumnCount; i++)
                {
                    var width = adgrvODi.Columns[i].ToString().Length * 1 + 20;
                    if (width < 35)
                    {
                        adgrvODi.Columns[0].Width = 35;
                    }
                    else
                    {
                        adgrvODi.Columns[i].Width = width;
                    }

                }
                updateAll();
                if (adgrvODi.RowCount > 1)
                    adgrvODi.FirstDisplayedScrollingRowIndex = adgrvODi.RowCount - 1;
            }

        }
        private void bgwLoading_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=172.28.10.17;Initial Catalog=ClaimForm;Persist Security Info=True;User ID=sa;Password=umc@2019";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var dateFrom = dpFrom.Value.Date;
                    var dateTo = dpTo.Value.Date;
                    SqlCommand cmnd = new SqlCommand(sql + " where DateOccur >= @from and DateOccur <= @to");
                    cmnd.Connection = connection;
                    cmnd.Parameters.Add("@from", SqlDbType.DateTime).Value = dateFrom.Date;
                    cmnd.Parameters.Add("@to", SqlDbType.DateTime).Value = dateTo.Date;
                    dataAdapter = new SqlDataAdapter(cmnd);
                    table = new DataTable
                    {
                        Locale = CultureInfo.InvariantCulture
                    };
                    dataAdapter.FillSchema(table, SchemaType.Source);
                    table.Columns["IsConfirm"].DataType = typeof(string);
                    dataAdapter.Fill(table);
                    table.Columns.Add("Check", typeof(bool));
                    e.Result = table;
                }


            }
            catch (SqlException)
            {
                e.Result = null;
            }
        }

        private void bgwLoading_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                var table = (DataTable)e.Result;
                odiDataSource.DataSource = null;
                odiDataSource.DataSource = table;
                for (int i = 0; i < adgrvODi.ColumnCount; i++)
                {
                    var width = adgrvODi.Columns[i].ToString().Length * 1 + 20;
                    if (width < 35)
                    {
                        adgrvODi.Columns[0].Width = 35;
                    }
                    else
                    {
                        adgrvODi.Columns[i].Width = width;
                    }

                }
                updateAll();
                if (adgrvODi.RowCount > 1)
                    adgrvODi.FirstDisplayedScrollingRowIndex = adgrvODi.RowCount - 1;
            }
            lblStatus.Text = "";
            pbLoading.Visible = false;
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var fileName = (string)e.Argument;
            using (var db = new ClaimFormEntities())
            {
                var dateFrom = dpFrom.Value.Date;
                var dateTo = dpTo.Value.Date;
                var odis = db.ODIs.Where(m => m.DateOccur >= dateFrom && m.DateOccur <= dateTo).ToList();
                var result = Utils.ExportStaff(odis, fileName);
                e.Result = result;
            }
        }

        private void adgrvODi_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            TickAll(cbAll.Checked);
        }
        private void TickAll(bool isAll)
        {
            var list = table.Select(this.adgrvODi.FilterString).ToList();
            foreach (var dr in list)
            {
                dr["Check"] = isAll;
            }
        }

        private void btnSettingModel_Click(object sender, EventArgs e)
        {
            new FormListModel().ShowDialog();
        }

        private void txbWO_TextChanged_1(object sender, EventArgs e)
        {
            if (txbWO.TextLength == 6)
            {
                txbWOEnterFinish();
            }else if(txbWO.TextLength == 0)
            {
                txbModelName.ResetText();
                txbGroupModel.ResetText();
                txbWOQty.ResetText();
                txbWOQty.Enabled = true;
            }
        }

        private void txbWO_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txbWOEnterFinish();
            }
        }
    }
}

