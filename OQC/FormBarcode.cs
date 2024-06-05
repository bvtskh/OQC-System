using AntdUI;
using CommonProject.MsgBox_AQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OQC
{
    public partial class FormBarcode : Window
    {
        private Action<string> returnWo;
        USAPService.USAPWebServiceSoapClient usapService = new USAPService.USAPWebServiceSoapClient();
        public FormBarcode(Action<string> callback)
        {
            InitializeComponent();
            returnWo = callback;
        }

        private void FormBarcode_Load(object sender, EventArgs e)
        {
            
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                var data = usapService.GetByBcNo(txtBarcode.Text);
                if(data != null)
                {
                    var wo = data.TN_NO.Remove(0, 6);
                    returnWo?.Invoke(wo);
                    this.Close();
                }
                else
                {
                    RJMessageBox.Show("Barcode không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarcode.SelectAll();
                    txtBarcode.Focus();
                    return;
                }
            }
            //if(e.KeyCode == Keys.Enter) 
            //{
            //    string connectionString = "Data Source=172.28.10.17;Initial Catalog=UMCVN_BASE;Persist Security Info=True;User ID=sa;Password=umc@2019;";
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        try
            //        {
            //            connection.Open();
            //            string sql = $@"SELECT TOP 1 [WONO] FROM [UMCVN_BASE].[dbo].[PMS_Valeo_LabelDetails] where BoxID ='{txtBarcode.Text}'";
            //            using (SqlCommand command = new SqlCommand(sql, connection))
            //            {
            //                using (SqlDataReader reader = command.ExecuteReader())
            //                {
            //                    if (!reader.HasRows)
            //                    {
            //                        RJMessageBox.Show("Barcode không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                        txtBarcode.SelectAll();
            //                        txtBarcode.Focus();
            //                        return;
            //                    }
            //                    // Đọc và xử lý dữ liệu
            //                    while (reader.Read())
            //                    {
            //                        string wo = reader.GetString(0);
            //                        if (wo != null)
            //                        {
            //                            wo = wo.Remove(0, 4);
            //                            returnWo?.Invoke(wo);
            //                            this.Close();
            //                        }
            //                    }  
                                
                                
            //                }
            //            }
            //        }
            //        catch (Exception)
            //        {

            //        }
            //    }
            //}
        }
    }
}
