using CommonProject.Business;
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
    public partial class FormListModel : Form
    {
        private DataTable dataTable;
        public FormListModel()
        {
            InitializeComponent();
            dataTable = new DataTable();
            dataTable.Columns.Add("Model");
            dataTable.Columns.Add("Nhóm Model");
            dgrvListModel.DataSource = dataTable;
            LoadData();
        }

        private void LoadData()
        {
            var listModels = SingletonHelper.PvsInstance.GetModelInfos(null);
            foreach (var item in listModels)
            {
                dataTable.Rows.Add(item.Product_Id, item.Group_Id);
            }
            dgrvListModel.DataSource = dataTable;
        }

        private void txbSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txbSearch.Text.Trim())) 
                {
                    var item = SingletonHelper.PvsInstance.GetModelInfo(txbSearch.Text.Trim());
                    dataTable.Clear();
                    dataTable.Rows.Add(item.Product_Id, item.Group_Id);
                    dgrvListModel.DataSource = dataTable;
                }
                
              
            }
           
        }
    }
}
