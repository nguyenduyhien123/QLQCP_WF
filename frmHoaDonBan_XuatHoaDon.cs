using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmHoaDonBan_XuatHoaDon : Form
    {
        _9_12_QuanLyQuanCaPhe classTong = new _9_12_QuanLyQuanCaPhe();
        DataSet ds = new DataSet();
        public frmHoaDonBan_XuatHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDonBan_XuatHoaDon_Load(object sender, EventArgs e)
        {

        }
        bool XuatHoaDon(string mahdb)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            //string sql;
            //int hang = 0, cot = 0;
            //DataTable tblThongtinHD, tblThongtinHang;
            // Thêm sheet 1
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exSheet.Columns.AutoFit();
            //---
            exRange = exSheet.Cells[1, 1];
            //  Định dạng cho phần tiêu đề
            exRange.Range["A1:G200"].Font.Name = "Arial"; //Font chữ
            exRange.Range["A1:G200"].Font.Size = 5;
            // Thiết lập Auto Fit
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Size = 8;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.ColorIndex = 5; //Màu xanh da trời
            // Nội dung của ô đó
            exRange.Range["A1:F1"].Value = "Phiếu thanh toán DH Coffee";
            exRange.Range["A1:F1"].Font.Size = 13;
            // Căn giữa
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            // Truy vấn dữ liệu
            DataSet ds_HD = new DataSet();
            string sql1 = $"SELECT MAHDB,A.MAKH,B.MANV,CONVERT(varchar(20), NGAYLAPHD, 103) + ' ' + CONVERT(varchar(20), NGAYLAPHD, 108) AS 'NGAYLAPHD',FORMAT(TONGTIENTHANHTOAN, 'N0') AS 'TONGTIENTHANHTOAN'  FROM HOADONBAN A, NHANVIEN B WHERE MAHDB={mahdb} AND A.MANV_LAP=B.MANV";
            ds_HD = classTong.LayDuLieu(sql1);
            DataSet ds_CTHD = new DataSet();
            string sql2 = $"SELECT TENSP,D.MASIZE,D.SOLUONG,D.GIABAN,D.SOTIENGIAM,THANHTIENCUOICUNG  FROM SANPHAM A, CHITIETSANPHAM B,HOADONBAN C, CHITIETHDB D WHERE A.MASP=B.MASP AND B.MASIZE = D.MASIZE AND B.MASP = D.MASP AND C.MAHDB=D.MAHDB AND C.MAHDB={mahdb}";
            ds_CTHD = classTong.LayDuLieu(sql2);
            int row = 0;
            // Phần thông tin mã hoá đơn
            exRange.Range["A2"].Value = "Mã HD: " + ds_HD.Tables[0].Rows[0]["MAHDB"].ToString() + " - " + ds_HD.Tables[0].Rows[0]["NGAYLAPHD"].ToString() + " - Mã NV: " + ds_HD.Tables[0].Rows[0]["MANV"].ToString();
            exRange.Range["A2"].ColumnWidth = 20;
            //

            //// Thiết lập chiều rộng cột ngày lập hoá đơn
            //exRange.Range["B2:C2"].MergeCells = true;
            //// Chỉnh lại định dạng ngày giờ
            //exRange.Range["B2:C2"].NumberFormat = "dd/mm/yyyy hh:mm:ss";
            //exRange.Range["B2:C2"].Value = ds_HD.Tables[0].Rows[0]["NGAYLAPHD"].ToString();
            //exRange.Range["B2:C2"].ColumnWidth = 8;
            //exRange.Range["B2:C2"].Font.Size = 6;
            //// Phần thông tin mã nhân viên
            //exRange.Range["D2:F2"].MergeCells= true;
            //exRange.Range["D2:F2"].Value ="Mã nhân viên: "+ ds_HD.Tables[0].Rows[0]["MANV"].ToString();
            //exRange.Range["D2:F2"].Font.Size = 6;
            // tô đường viền dưới
            exRange.Range["A2:F2"].Borders[COMExcel.XlBordersIndex.xlEdgeBottom].LineStyle = COMExcel.XlLineStyle.xlContinuous;
            exRange.Range["A2:F2"].Borders[COMExcel.XlBordersIndex.xlEdgeBottom].Weight = COMExcel.XlBorderWeight.xlThin;
            // --------------------------------------
            // List chứa các kí tự in hoa
            List<char> uppercaseLetters = new List<char>();
            for (int i = 65; i <= 90; i++)
            {
                uppercaseLetters.Add((char)i);
            }
            // Phần tiêu đề
            exRange.Range[$"A3"].Value = "Tên sản phẩm";
            exRange.Range[$"B3"].Value = "Size";
            exRange.Range[$"C3"].Value = "Số lượng";
            exRange.Range[$"C3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range[$"D3"].Value = "Giá bán";
            exRange.Range[$"D3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range[$"E3"].Value = "Giảm";
            exRange.Range[$"E3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range[$"F3"].Value = "Thành tiền";
            exRange.Range[$"F3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            // Cập nhật lại row thành 4 vì dòng 1,2,3 đã sử dụng ở trên
            int start = 3;
            row = 4;
            // Phần nội dung
            exRange.Range["A1"].ColumnWidth = 25;
            for (int i = 0; i < ds_CTHD.Tables[0].Rows.Count; i++)
            {
                // Đường viền trên
                exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].LineStyle = COMExcel.XlLineStyle.xlContinuous;
                exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].Weight = COMExcel.XlBorderWeight.xlThin;
                //
                exRange.Range[$"A" + row + ""].Value = ds_CTHD.Tables[0].Rows[i]["TENSP"].ToString();
                //exRange.Range[$"A"+row+""].WrapText = true;
                exRange.Range[$"a" + row + ""].ColumnWidth = 18;
                exRange.Range[$"B" + row + ""].Value = ds_CTHD.Tables[0].Rows[i]["MASIZE"].ToString();
                exRange.Range[$"B" + row + ""].ColumnWidth = 1.5;
                exRange.Range[$"C" + row + ""].Value = ds_CTHD.Tables[0].Rows[i]["SOLUONG"].ToString();
                exRange.Range[$"C" + row + ""].ColumnWidth = 5;
                exRange.Range[$"C" + row + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                // 
                int giaban = Convert.ToInt32(ds_CTHD.Tables[0].Rows[i]["GIABAN"]);
                exRange.Range[$"D" + row + ""].Value = giaban.ToString("N0");
                exRange.Range[$"D" + row + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                exRange.Range[$"D" + row + ""].ColumnWidth = 6;
                // 
                int sotiengiam = Convert.ToInt32(ds_CTHD.Tables[0].Rows[i]["SOTIENGIAM"]);
                exRange.Range[$"E" + row + ""].Value = sotiengiam.ToString("N0");
                exRange.Range[$"E" + row + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                exRange.Range[$"E" + row + ""].ColumnWidth = 6;
                // 
                int thanhtiencuoicung = Convert.ToInt32(ds_CTHD.Tables[0].Rows[i]["THANHTIENCUOICUNG"]);
                exRange.Range[$"F" + row + ""].Value = thanhtiencuoicung.ToString("N0");
                exRange.Range[$"F" + row + ""].ColumnWidth = 7;
                exRange.Range[$"F" + row + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                row++;
            }
            int end = row - 1;
            string[] arrAlpha = { "A", "B", "C", "D", "E", "F" };
            for (int i = 0; i < 6; i++)
            {
                // Vẽ đường viền trái
                exRange.Range[$"{arrAlpha[i]}{start}:{arrAlpha[i]}{end}"].Borders[COMExcel.XlBordersIndex.xlEdgeLeft].LineStyle = COMExcel.XlLineStyle.xlContinuous;
                exRange.Range[$"{arrAlpha[i]}{start}:{arrAlpha[i]}{end}"].Borders[COMExcel.XlBordersIndex.xlEdgeLeft].Weight = COMExcel.XlBorderWeight.xlThin;
                // Vẽ đường viền phải
                exRange.Range[$"{arrAlpha[i]}{start}:{arrAlpha[i]}{end}"].Borders[COMExcel.XlBordersIndex.xlEdgeRight].LineStyle = COMExcel.XlLineStyle.xlContinuous;
                exRange.Range[$"{arrAlpha[i]}{start}:{arrAlpha[i]}{end}"].Borders[COMExcel.XlBordersIndex.xlEdgeRight].Weight = COMExcel.XlBorderWeight.xlThin;

            }
            // Đường viền trên
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].LineStyle = COMExcel.XlLineStyle.xlContinuous;
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].Weight = COMExcel.XlBorderWeight.xlThin;
            exRange.Range[$"A" + row + ":C" + row + ""].MergeCells = true;
            exRange.Range[$"A" + row + ":C" + row + ""].Font.Size = 7;

            exRange.Range[$"A" + row + ":C" + row + ""].Value = "Tổng tiền thanh toán: ";
            exRange.Range[$"D" + row + ":F" + row + ""].MergeCells = true;
            string tongtienthanhtoan = ds_HD.Tables[0].Rows[0]["TONGTIENTHANHTOAN"].ToString();
            exRange.Range[$"D" + row + ":F" + row + ""].Value = tongtienthanhtoan;
            exRange.Range[$"D" + row + ":F" + row + ""].Font.Size = 8;
            exRange.Range[$"D" + row + ":F" + row + ""].Font.Bold = true;
            exRange.Range[$"D" + row + ":F" + row + ""].Font.ColorIndex = 5;
            exRange.Range[$"D" + row + ":F" + row + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            // Đường viền dưới
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].LineStyle = COMExcel.XlLineStyle.xlContinuous;
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].Weight = COMExcel.XlBorderWeight.xlThin;
            // 
            row++;
            exRange.Range[$"A" + row + ":F" + row + ""].MergeCells = true;
            exRange.Range[$"A" + row + ":F" + row + ""].Font.Size = 5;
            exRange.Range[$"A" + row + ":F" + row + ""].Value = "Quý khách có thể in bản sao hoá đơn điện tử tại dhcoffee.com";
            exRange.Range[$"A" + row + ":F" + row + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            //
            // Đường viền dưới
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].LineStyle = COMExcel.XlLineStyle.xlContinuous;
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].Weight = COMExcel.XlBorderWeight.xlThin;
            // 
            row++;
            exRange.Range[$"A" + row + ":F" + row + ""].MergeCells = true;
            exRange.Range[$"A" + row + ":F" + row + ""].Value = "KHÁCH HÀNG VUI LÒNG KIỂM TRA HOÁ ĐƠN TRƯỚC KHI RỜI QUẦY THANH TOÁN";
            exRange.Range[$"A" + row + ":F" + row + ""].Font.Size = 3.5;
            exRange.Range[$"A" + row + ":F" + row + ""].Font.Bold = true;
            exRange.Range[$"A" + row + ":F" + row + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            // Đường viền trên
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].LineStyle = COMExcel.XlLineStyle.xlContinuous;
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].Weight = COMExcel.XlBorderWeight.xlThin;
            // Đường viền dưới
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].LineStyle = COMExcel.XlLineStyle.xlContinuous;
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].Weight = COMExcel.XlBorderWeight.xlThin;
            // 
            row++;
            exRange.Range[$"A" + row + ":F" + row + ""].MergeCells = true;
            exRange.Range[$"A" + row + ":F" + row + ""].Value = "CẢM ƠN QUÝ KHÁCH, HẸN GẶP LẠI !!!";
            exRange.Range[$"A" + row + ":F" + row + ""].Font.Size = 6;
            exRange.Range[$"A" + row + ":F" + row + ""].Font.Bold = true;
            exRange.Range[$"A" + row + ":F" + row + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            // Đường viền trên
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].LineStyle = COMExcel.XlLineStyle.xlContinuous;
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeTop].Weight = COMExcel.XlBorderWeight.xlThin;
            // Đường viền dưới
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeBottom].LineStyle = COMExcel.XlLineStyle.xlContinuous;
            exRange.Range[$"A" + row + ":F" + row + ""].Borders[COMExcel.XlBordersIndex.xlEdgeBottom].Weight = COMExcel.XlBorderWeight.xlThin;
            // 
            // --------------------------------------
            // Lệnh kích hoạt Sheeet hiện tại
            exSheet.Activate();
            // Đặt tên cho Sheet
            exSheet.Name = "Hóa đơn nhập";
            //exApp.Visible = true;
            // Ẩn Ứng dụng Excel không hiển thị
            exApp.Visible = false;
            // Lưu file với đường dẫn và tên khác
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("dd/MM/yyyy HH:mm:ss");
            //
            row++;
            exRange.Range[$"A" + row + ":F" + row + ""].MergeCells = true;
            exRange.Range[$"A" + row + ":F" + row + ""].Value = $"NGÀY XUẤT HOÁ ĐƠN {formattedDate}";
            exRange.Range[$"A" + row + ":F" + row + ""].Font.Size = 5;
            exRange.Range[$"A" + row + ":F" + row + ""].Font.Bold = true;
            exRange.Range[$"A" + row + ":F" + row + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            //
            //string strDate = $"{date.Day}_{date.Month}_{date.Year}_TG_{date.Hour}_{date.Minute}_{date.Second}";
            string strDate = date.ToString("dd_MM_yyyy_HH_mm_ss");
            string rootFolder = Application.StartupPath + "\\XUATHOADON";
            string fileName = $"{ds_HD.Tables[0].Rows[0]["MAHDB"]}_{strDate}.xlsx";
            string filePath = Path.Combine(rootFolder, fileName);

            exBook.SaveAs($"{filePath}", COMExcel.XlFileFormat.xlWorkbookDefault, null, null, false, false, COMExcel.XlSaveAsAccessMode.xlExclusive, false, false, false, false, false);
            // Tắt ứng dụng Excel
            exApp.Quit();
            ExportToPDF(filePath);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            return true;
        }
        void ExportToPDF(string filePath)
        {
            // Create an instance of Excel application
            COMExcel.Application excelApplication = new COMExcel.Application();

            // Open the workbook and get reference to the worksheet
            COMExcel.Workbook workbook = excelApplication.Workbooks.Open(filePath);
            COMExcel.Worksheet worksheet = workbook.ActiveSheet;

            // Set the print area to the used range of cells in the worksheet
            worksheet.PageSetup.PrintArea = worksheet.UsedRange.Address;

            // Set the page margins and center the content
            worksheet.PageSetup.LeftMargin = excelApplication.InchesToPoints(0.5);
            worksheet.PageSetup.RightMargin = excelApplication.InchesToPoints(0.5);
            worksheet.PageSetup.TopMargin = excelApplication.InchesToPoints(0.5);
            worksheet.PageSetup.BottomMargin = excelApplication.InchesToPoints(0.5);
            worksheet.PageSetup.HeaderMargin = excelApplication.InchesToPoints(0.5);
            worksheet.PageSetup.FooterMargin = excelApplication.InchesToPoints(0.5);
            //worksheet.PageSetup.CenterHorizontally = true;
            //worksheet.PageSetup.CenterVertically = true;
            worksheet.PageSetup.PaperSize = COMExcel.XlPaperSize.xlPaperA4;
            // Set the column width and row height to fit the content
            //worksheet.Columns.AutoFit();
            //worksheet.Rows.AutoFit();

            // Add padding to the content
            //worksheet.Cells.Style.Padding.Left = 20;
            //worksheet.Cells.Style.Padding.Right = 20;
            //worksheet.Cells.Style.Padding.Top = 20;
            //worksheet.Cells.Style.Padding.Bottom = 20;
            // Export the worksheet to PDF format
            worksheet.ExportAsFixedFormat(COMExcel.XlFixedFormatType.xlTypePDF, Path.ChangeExtension(filePath, "pdf"), COMExcel.XlFixedFormatQuality.xlQualityStandard, false, true, 1, 1, false);
            // Close the workbook and release the resources
            workbook.Close(false);
            excelApplication.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication);

            // Mở tệp Excel bằng ứng dụng mặc định của hệ thống
            Process.Start(filePath);

            string pdfFilePath = Path.ChangeExtension(filePath, "pdf");
            // Mở tệp Excel bằng ứng dụng mặc định của hệ thống
            Process.Start(pdfFilePath);
        }

        private void btnMaHDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHDB.Text != "")
                {
                    string regexPattern = @"^\d+$";  // Biểu thức chính quy để kiểm tra chuỗi chỉ chứa các chữ số
                    bool isMatch = Regex.IsMatch(txtMaHDB.Text, regexPattern);

                    if (isMatch)
                    {
                        int mahdb = int.Parse(txtMaHDB.Text);
                        ds = classTong.LayDuLieu($"SELECT * FROM HOADONBAN WHERE MAHDB = {mahdb}");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            if (XuatHoaDon(mahdb.ToString()))
                            {
                                MessageBox.Show("Xuất hoá đơn thành công", "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tồn tại mã hoá đơn trên !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã hoá đơn phải là một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Mã hoá đơn không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình xuất hoá đơn, Vui lòng xuất lại hoá đơn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
