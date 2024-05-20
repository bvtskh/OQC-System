using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using Spire.Xls;
using System.Windows.Forms;
using System.IO;
using System.Deployment.Application;
using System.Reflection;

namespace OQC.Business
{
    public static class Utils
    {
        public static string GetRunningVersion()
        {

            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }

        }

        public static void SetDoubleBuffering(this DataGridView dgv, bool value)
        {
            // Double buffering can make DGV slow in remote desktop
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = dgv.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                        BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dgv, value, null);
            }
        }
        public static void UploadFile(string host, string username, string password, string localPath, string remotePath)
        {

            using (var ftp = new FtpClient(host, username, password))
            {
                ftp.Connect();
                ftp.UploadFile(localPath, remotePath, FtpRemoteExists.Overwrite, true, FtpVerify.Retry);
            }
        }
        public static string DownloadFile(string host, string username, string password, string localPath, string remotePath)
        {
            using (var ftp = new FtpClient(host, username, password))
            {
                ftp.Connect();
                ftp.DownloadFile(localPath, remotePath, FtpLocalExists.Overwrite, FtpVerify.Retry);
                return localPath;
            }
        }
        public static string GetFileName(FolderBrowserDialog choofdlog, string fileNameExcel)
        {
            string folderName = choofdlog.SelectedPath;
            string[] fileEntries = Directory.GetFiles(folderName);
            string fileName = "";
            int i = -1;
            foreach (var file in fileEntries)
            {
                if (file.Contains(fileNameExcel))
                {
                    int start = file.IndexOf('(');
                    int end = file.IndexOf(')');
                    if (start > 0 && end > 0)
                    {
                        string index = file.Substring(start + 1, end - start - 1);
                        if (int.Parse(index) > i)
                        {
                            i = int.Parse(index);
                        }
                    }
                    else
                    {
                        if (i < 0)
                            i = 0;
                    }

                }
            }
            if (i < 0)
            {
                fileName = folderName + "\\" + fileNameExcel + ".csv";
            }
            else
            {
                fileName = folderName + "\\" + fileNameExcel + "(" + (i + 1).ToString() + ")" + ".csv";
            }
            return fileName;
        }
        public static Tuple<int, string> ExportStaff(List<ODI> odis, string path)
        {
            try
            {
                Workbook workbook = new Workbook();
                Worksheet sheet = workbook.Worksheets[0];
                int row = 1;
                sheet.Range[string.Format("A{0}", row)].Text = "ID";
                sheet.Range[string.Format("B{0}", row)].Text = "Customer";
                sheet.Range[string.Format("C{0}", row)].Text = "Station";
                sheet.Range[string.Format("D{0}", row)].Text = "Inspector";
                sheet.Range[string.Format("E{0}", row)].Text = "GroupModel";
                sheet.Range[string.Format("F{0}", row)].Text = "ModelName";
                sheet.Range[string.Format("G{0}", row)].Text = "WO";
                sheet.Range[string.Format("H{0}", row)].Text = "WOQty";
                sheet.Range[string.Format("I{0}", row)].Text = "CheckNumber";
                sheet.Range[string.Format("J{0}", row)].Text = "Area";
                sheet.Range[string.Format("K{0}", row)].Text = "Shift";
                sheet.Range[string.Format("L{0}", row)].Text = "NumberNG";
                sheet.Range[string.Format("M{0}", row)].Text = "Ngày xảy ra";
                sheet.Range[string.Format("N{0}", row)].Text = "Thời điểm xảy ra";
                sheet.Range[string.Format("O{0}", row)].Text = "Line phát sinh";
                sheet.Range[string.Format("P{0}", row)].Text = "Serial";
                sheet.Range[string.Format("Q{0}", row)].Text = "Vị trí";
                sheet.Range[string.Format("R{0}", row)].Text = "Defection";
                sheet.Range[string.Format("S{0}", row)].Text = "Hình thức lấy mẫu";

                row++;
                var index = 1;
                foreach (var odi in odis)
                {
                    sheet.Range[string.Format("A{0}", row)].Text = index.ToString();
                    sheet.Range[string.Format("A{0}", row)].NumberFormat = "0";
                    sheet.Range[string.Format("B{0}", row)].Text = odi.Customer;
                    sheet.Range[string.Format("C{0}", row)].Text = odi.Station;
                    sheet.Range[string.Format("D{0}", row)].Text = odi.Inspector;
                    sheet.Range[string.Format("E{0}", row)].Text = odi.GroupModel;
                    sheet.Range[string.Format("F{0}", row)].Text = odi.ModelName;
                    sheet.Range[string.Format("G{0}", row)].Text = odi.WO;
                    sheet.Range[string.Format("H{0}", row)].Text = odi.WOQty.ToString();
                    sheet.Range[string.Format("I{0}", row)].Text = odi.CheckNumber.ToString();
                    sheet.Range[string.Format("I{0}", row)].NumberFormat = "0";
                    sheet.Range[string.Format("J{0}", row)].Text = odi.Area;
                    sheet.Range[string.Format("K{0}", row)].Text = odi.Shift;
                    sheet.Range[string.Format("L{0}", row)].Text = odi.NumberNG.ToString();
                    sheet.Range[string.Format("L{0}", row)].NumberFormat = "0";
                    sheet.Range[string.Format("M{0}", row)].Text = odi.DateOccur.ToString("dd/MM/yyyy");
                    sheet.Range[string.Format("N{0}", row)].Text = odi.Occur_Time != null ? odi.Occur_Time : "";
                    sheet.Range[string.Format("O{0}", row)].Text = odi.Occur_Line != null ? odi.Occur_Line : "";
                    sheet.Range[string.Format("P{0}", row)].Text = odi.Serial_Number != null ? odi.Serial_Number : "";
                    sheet.Range[string.Format("Q{0}", row)].Text = odi.Position != null ? odi.Position : "";
                    sheet.Range[string.Format("R{0}", row)].Text = odi.Defection != null ? odi.Defection : "";
                    sheet.Range[string.Format("S{0}", row)].Text = odi.Sample_Form != null ? odi.Sample_Form : "";
                  
                    index++;
                    row++;
                }
                workbook.SaveToFile(path, ExcelVersion.Version2013);
                return Tuple.Create<int, string>(Constants.SUCCESS, "Export success!");
            }
            catch (Exception e)
            {
                return Tuple.Create<int, string>(Constants.ERROR, e.Message.ToString());

            }
        }

    }

    public static class Encrypt
    {

        public static string MD5Hash(this string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

    }
}
