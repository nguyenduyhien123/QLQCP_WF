using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmHoaDonBan_ThongKeBaoCao : Form
    {
        _9_12_QuanLyQuanCaPhe classTong= new _9_12_QuanLyQuanCaPhe();
        DataSet ds= new DataSet();
        DataSet ds1= new DataSet();
        public frmHoaDonBan_ThongKeBaoCao()
        {
            InitializeComponent();
        }
        string ChuoiThang(int n)
        {
            string[] months = new string[12] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
            string str = "";
            str = months[n - 1];
            return str;
        }
        private void frmHoaDonBan_TimKiem_Load(object sender, EventArgs e)
        {
            cboTieuChiThongKe.SelectedIndex = 0;
            VeBieuDo3Cot();
        }

        private void chartThongKeHoaDonBan_Click(object sender, EventArgs e)
        {

        }

        private void cboTieuChiThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTieuChiThongKe.SelectedIndex)
            {
                case 0:
                    dtpThoiGianThongKe.Visible = false;

                    break;
                case 1:
                    dtpThoiGianThongKe.Visible = true;
                    dtpThoiGianThongKe.Format = DateTimePickerFormat.Custom;
                    dtpThoiGianThongKe.CustomFormat = "yyyy";
                    break;
                case 2:
                    dtpThoiGianThongKe.Visible = true;
                    dtpThoiGianThongKe.Format = DateTimePickerFormat.Custom;
                    dtpThoiGianThongKe.CustomFormat = "MM/yyyy";
                    break;
            }
        }

        private void dtpThoiGianThongKe_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                chartThongKeHoaDonBan.Focus();
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            VeBieuDo3Cot();
          
         }

        private void frmHoaDonBan_ThongKeBaoCao_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show($"Bạn có chắc muốn Đóng form Thống kê / Báo cáo ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgThoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        void VeBieuDo3Cot()
        {
            string sql1 = "";
            string sql2 = "";
            int select = cboTieuChiThongKe.SelectedIndex;
            //chartThongKeHoaDonBan.ChartAreas.Clear();
            chartThongKeHoaDonBan.Series.Clear();
            chartThongKeHoaDonBan.Legends.Clear();
            chartThongKeHoaDonBan.Titles.Clear();
            switch (select)
            {
                case 0:

                    {
                        DateTime dt = dtpThoiGianThongKe.Value;
                        int ngay = dt.Day;
                        int thang = dt.Month;
                        int nam = dt.Year;
                        lblDoanhThuCaoNhat.Text = "Năm có doanh thu cao nhất";
                        lblThangCoLoiNhieuNhat.Text = "Năm có lời cao nhất";
                        lblThangCoLoiNhieuNhat.Text = "Năm ";
                        lblThangDoanhThuCaoNhat.Text = "Năm ";
                        // Lấy về các doanh thu các năm
                        sql1 = $"SELECT YEAR(NGAYLAPHD) AS 'NAM', CONVERT(INT,SUM(GIAVON*SOLUONG)) AS 'TIENVON', CONVERT(INT,SUM(THANHTIENCUOICUNG)) AS 'TIENBAN',  CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) AS 'TIENCHENHLECH' FROM HOADONBAN A,  CHITIETHDB B WHERE A.MAHDB = B.MAHDB GROUP BY YEAR(NGAYLAPHD)";
                        // Lấy năm có doanh thu lớn nhất
                        sql2 = $"SELECT YEAR(NGAYLAPHD) AS 'NAM',CONVERT(INT,SUM(GIAVON*SOLUONG)) AS 'TIENVON',CONVERT(INT,SUM(THANHTIENCUOICUNG)) AS 'TIENBAN',CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) AS 'TIENCHENHLECH' FROM HOADONBAN A,  CHITIETHDB B WHERE A.MAHDB = B.MAHDB GROUP BY YEAR(NGAYLAPHD) HAVING CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) >=( SELECT TOP 1 CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) AS 'TIENCHENHLECH' FROM HOADONBAN A,  CHITIETHDB B WHERE A.MAHDB = B.MAHDB  GROUP BY YEAR(NGAYLAPHD)ORDER BY 'TIENCHENHLECH' DESC)";
                        ds = classTong.LayDuLieu(sql1);
                        ds1 = classTong.LayDuLieu(sql2);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            {
                                lblThangCoLoiNhieuNhat.Text += ds1.Tables[0].Rows[i]["NAM"] + " ";
                            }
                            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            {
                                lblThangDoanhThuCaoNhat.Text += ds1.Tables[0].Rows[i]["NAM"] + " ";
                            }
                            List<string> listNam = new List<string>();
                            List<int> listTienVon = new List<int>();
                            List<int> listTienBan = new List<int>();
                            List<int> listTienChenhLech = new List<int>();

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                listNam.Add("Năm "+(int)ds.Tables[0].Rows[i]["NAM"]);
                                listTienVon.Add((int)ds.Tables[0].Rows[i]["TIENVON"]);
                                listTienBan.Add((int)ds.Tables[0].Rows[i]["TIENBAN"]);
                                listTienChenhLech.Add((int)ds.Tables[0].Rows[i]["TIENCHENHLECH"]);
                            }
                            //
                            Series newSeries1 = new Series("Tiền vốn");
                            newSeries1.Points.DataBindXY(listNam, listTienVon);
                            chartThongKeHoaDonBan.Series.Add(newSeries1);
                            Legend newLegends1 = new Legend();
                            chartThongKeHoaDonBan.Legends.Add(newLegends1);
                            chartThongKeHoaDonBan.Series[0].ToolTip = $"Tiền vốn: #VALX : #VAL VNĐ";
                            chartThongKeHoaDonBan.Legends[0].Font = new Font("Arial", 12f, FontStyle.Regular);
                            chartThongKeHoaDonBan.Legends[0].MaximumAutoSize = 100;
                            //
                            Series newSeries2 = new Series("Tiền bán");
                            newSeries2.Points.DataBindXY(listNam, listTienBan);
                            chartThongKeHoaDonBan.Series.Add(newSeries2);
                            Legend newLegends2 = new Legend();
                            chartThongKeHoaDonBan.Legends.Add(newLegends2);
                            chartThongKeHoaDonBan.Series[1].ToolTip = $"Tiền bán: #VALX : #VAL VNĐ";
                            chartThongKeHoaDonBan.Legends[1].Font = new Font("Arial", 12f, FontStyle.Regular);
                            chartThongKeHoaDonBan.Legends[1].MaximumAutoSize = 100;
                            //
                            Series newSeries3 = new Series("Tiền chênh lệch");
                            newSeries3.Points.DataBindXY(listNam, listTienChenhLech);
                            chartThongKeHoaDonBan.Series.Add(newSeries3);
                            Legend newLegends3 = new Legend();
                            chartThongKeHoaDonBan.Legends.Add(newLegends3);
                            chartThongKeHoaDonBan.Series[2].ToolTip = $"Tiền chênh lệch: #VALX : #VAL VNĐ";
                            chartThongKeHoaDonBan.Legends[2].Font = new Font("Arial", 12f, FontStyle.Regular);
                            chartThongKeHoaDonBan.Legends[2].MaximumAutoSize = 100;
                            //
                            if (chartThongKeHoaDonBan.ChartAreas.Count > 0)
                            {
                                chartThongKeHoaDonBan.ChartAreas[0].AxisX.Interval = 1;
                                chartThongKeHoaDonBan.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
                                chartThongKeHoaDonBan.Titles.Add($"Biểu đồ doanh thu theo các năm");
                                if (chartThongKeHoaDonBan.Titles.Count > 0)
                                {
                                    chartThongKeHoaDonBan.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic);
                                }
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        DateTime dt = dtpThoiGianThongKe.Value;
                        int ngay = dt.Day;
                        int thang = dt.Month;
                        int nam = dt.Year;
                        lblDoanhThuCaoNhat.Text = $"Tháng trong năm {nam} có doanh thu cao nhất";
                        lblCoLoiNhieuNhat.Text = $"Tháng trong năm {nam} có lời cao nhất";
                        lblThangCoLoiNhieuNhat.Text = "Tháng ";
                        lblThangDoanhThuCaoNhat.Text = "Tháng ";
                        // Lấy ra doanh thu các tháng trong năm
                        sql1 = $"  SELECT MONTH(NGAYLAPHD) AS 'THANG',YEAR(NGAYLAPHD) AS 'NAM', CONVERT(INT,SUM(GIAVON*SOLUONG)) AS 'TIENVON', CONVERT(INT,SUM(THANHTIENCUOICUNG)) AS 'TIENBAN',  CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) AS 'TIENCHENHLECH' FROM HOADONBAN A,  CHITIETHDB B WHERE A.MAHDB = B.MAHDB AND YEAR(NGAYLAPHD) = {nam}  GROUP BY MONTH(NGAYLAPHD),YEAR(NGAYLAPHD)";
                        // Lấy ra doanh thu các tháng cao nhất trong năm
                        sql2 = $"SELECT MONTH(NGAYLAPHD) AS 'THANG',YEAR(NGAYLAPHD) AS 'NAM',CONVERT(INT,SUM(GIAVON*SOLUONG)) AS 'TIENVON',CONVERT(INT,SUM(THANHTIENCUOICUNG)) AS 'TIENBAN',CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) AS 'TIENCHENHLECH' FROM HOADONBAN A,  CHITIETHDB B WHERE A.MAHDB = B.MAHDB AND YEAR(NGAYLAPHD)= {nam} GROUP BY MONTH(NGAYLAPHD),YEAR(NGAYLAPHD) HAVING CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) >=(SELECT TOP 1 CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) AS 'TIENCHENHLECH' FROM HOADONBAN A,  CHITIETHDB B WHERE A.MAHDB = B.MAHDB AND YEAR(NGAYLAPHD)= {nam}  GROUP BY MONTH(NGAYLAPHD),YEAR(NGAYLAPHD)ORDER BY 'TIENCHENHLECH' DESC)";
                        ds = classTong.LayDuLieu(sql1);
                        ds1 = classTong.LayDuLieu(sql2);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            {
                                lblThangCoLoiNhieuNhat.Text += ds1.Tables[0].Rows[i]["THANG"] + " ";
                            }
                            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            {
                                lblThangDoanhThuCaoNhat.Text += ds1.Tables[0].Rows[i]["THANG"] + " ";
                            }
                            List<int> listThang = new List<int>();
                            List<int> listTienVon = new List<int>();
                            List<int> listTienBan = new List<int>();
                            List<int> listTienChenhLech = new List<int>();

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                listThang.Add((int)ds.Tables[0].Rows[i]["THANG"]);
                                listTienVon.Add((int)ds.Tables[0].Rows[i]["TIENVON"]);
                                listTienBan.Add((int)ds.Tables[0].Rows[i]["TIENBAN"]);
                                listTienChenhLech.Add((int)ds.Tables[0].Rows[i]["TIENCHENHLECH"]);
                            }
                            List<string> listChuoiThang = new List<string>();
                            for (int i = 0; i < listThang.Count; i++)
                            {
                                listChuoiThang.Add(ChuoiThang(listThang[i]));
                            }
                            //
                            Series newSeries1 = new Series("Tiền vốn");
                            newSeries1.Points.DataBindXY(listChuoiThang, listTienVon);
                            chartThongKeHoaDonBan.Series.Add(newSeries1);
                            Legend newLegends1 = new Legend();
                            chartThongKeHoaDonBan.Legends.Add(newLegends1);
                            chartThongKeHoaDonBan.Series[0].ToolTip = $"Tiền vốn: #VALX : #VAL VNĐ";
                            chartThongKeHoaDonBan.Legends[0].Font = new Font("Arial", 12f, FontStyle.Regular);
                            chartThongKeHoaDonBan.Legends[0].MaximumAutoSize = 100;
                            //
                            Series newSeries2 = new Series("Tiền bán");
                            newSeries2.Points.DataBindXY(listChuoiThang, listTienBan);
                            chartThongKeHoaDonBan.Series.Add(newSeries2);
                            Legend newLegends2 = new Legend();
                            chartThongKeHoaDonBan.Legends.Add(newLegends2);
                            chartThongKeHoaDonBan.Series[1].ToolTip = $"Tiền bán: #VALX : #VAL VNĐ";
                            chartThongKeHoaDonBan.Legends[1].Font = new Font("Arial", 12f, FontStyle.Regular);
                            chartThongKeHoaDonBan.Legends[1].MaximumAutoSize = 100;
                            //
                            Series newSeries3 = new Series("Tiền chênh lệch");
                            newSeries3.Points.DataBindXY(listChuoiThang, listTienChenhLech);
                            chartThongKeHoaDonBan.Series.Add(newSeries3);
                            Legend newLegends3 = new Legend();
                            chartThongKeHoaDonBan.Legends.Add(newLegends3);
                            chartThongKeHoaDonBan.Series[2].ToolTip = $"Tiền chênh lệch: #VALX : #VAL VNĐ";
                            chartThongKeHoaDonBan.Legends[2].Font = new Font("Arial", 12f, FontStyle.Regular);
                            chartThongKeHoaDonBan.Legends[2].MaximumAutoSize = 100;
                            //
                            if (chartThongKeHoaDonBan.ChartAreas.Count > 0)
                            {
                                chartThongKeHoaDonBan.ChartAreas[0].AxisX.Interval = 1;
                                chartThongKeHoaDonBan.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
                                chartThongKeHoaDonBan.Titles.Add($"Biểu đồ doanh thu trong năm {nam}");
                                if (chartThongKeHoaDonBan.Titles.Count > 0)
                                {
                                    chartThongKeHoaDonBan.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic);
                                }
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        DateTime dt = dtpThoiGianThongKe.Value;
                        int ngay = dt.Day;
                        int thang = dt.Month;
                        int nam = dt.Year;
                        lblDoanhThuCaoNhat.Text = $"Ngày trong tháng {thang}/{nam} có doanh thu cao nhất";
                        lblCoLoiNhieuNhat.Text = $"Ngày trong tháng {thang}/{nam} có lời cao nhất";
                        lblThangCoLoiNhieuNhat.Text = "Ngày ";
                        lblThangDoanhThuCaoNhat.Text = "Ngày ";
                        sql1 = $"SELECT DAY(NGAYLAPHD) AS 'NGAY',MONTH(NGAYLAPHD) AS 'THANG',YEAR(NGAYLAPHD) AS 'NAM', CONVERT(INT,SUM(GIAVON*SOLUONG)) AS 'TIENVON', CONVERT(INT,SUM(THANHTIENCUOICUNG)) AS 'TIENBAN',  CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) AS 'TIENCHENHLECH' FROM HOADONBAN A,  CHITIETHDB B WHERE A.MAHDB = B.MAHDB AND YEAR(NGAYLAPHD) = {nam} AND MONTH(NGAYLAPHD) = {thang} GROUP BY DAY(NGAYLAPHD),MONTH(NGAYLAPHD),YEAR(NGAYLAPHD)";
                        sql2 = $"SELECT DAY(NGAYLAPHD) AS 'NGAY',MONTH(NGAYLAPHD) AS 'THANG',YEAR(NGAYLAPHD) AS 'NAM',CONVERT(INT,SUM(GIAVON*SOLUONG)) AS 'TIENVON',CONVERT(INT,SUM(THANHTIENCUOICUNG)) AS 'TIENBAN',CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) AS 'TIENCHENHLECH' FROM HOADONBAN A,  CHITIETHDB B WHERE A.MAHDB = B.MAHDB AND YEAR(NGAYLAPHD) = {nam} AND MONTH(NGAYLAPHD) = {thang} GROUP BY DAY(NGAYLAPHD),MONTH(NGAYLAPHD),YEAR(NGAYLAPHD) HAVING CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) >=(SELECT TOP 1 CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) AS 'TIENCHENHLECH' FROM HOADONBAN A,  CHITIETHDB B WHERE A.MAHDB = B.MAHDB  AND YEAR(NGAYLAPHD) = {nam} AND MONTH(NGAYLAPHD) = {thang}  GROUP BY DAY(NGAYLAPHD) ORDER BY 'TIENCHENHLECH' DESC)";
                        ds = classTong.LayDuLieu(sql1);
                        ds1 = classTong.LayDuLieu(sql2);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            {
                                lblThangCoLoiNhieuNhat.Text += ds1.Tables[0].Rows[i]["NGAY"] + " ";
                            }
                            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            {
                                lblThangDoanhThuCaoNhat.Text += ds1.Tables[0].Rows[i]["NGAY"] + " ";
                            }
                            List<string> listNgay = new List<string>();
                            List<int> listTienVon = new List<int>();
                            List<int> listTienBan = new List<int>();
                            List<int> listTienChenhLech = new List<int>();

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                listNgay.Add("Ngày "+(int)ds.Tables[0].Rows[i]["NGAY"]);
                                listTienVon.Add((int)ds.Tables[0].Rows[i]["TIENVON"]);
                                listTienBan.Add((int)ds.Tables[0].Rows[i]["TIENBAN"]);
                                listTienChenhLech.Add((int)ds.Tables[0].Rows[i]["TIENCHENHLECH"]);
                            }
                            //
                            Series newSeries1 = new Series("Tiền vốn");
                            newSeries1.Points.DataBindXY(listNgay, listTienVon);
                            chartThongKeHoaDonBan.Series.Add(newSeries1);
                            Legend newLegends1 = new Legend();
                            chartThongKeHoaDonBan.Legends.Add(newLegends1);
                            chartThongKeHoaDonBan.Series[0].ToolTip = $"Tiền vốn: #VALX : #VAL VNĐ";
                            chartThongKeHoaDonBan.Legends[0].Font = new Font("Arial", 12f, FontStyle.Regular);
                            chartThongKeHoaDonBan.Legends[0].MaximumAutoSize = 100;
                            //
                            Series newSeries2 = new Series("Tiền bán");
                            newSeries2.Points.DataBindXY(listNgay, listTienBan);
                            chartThongKeHoaDonBan.Series.Add(newSeries2);
                            Legend newLegends2 = new Legend();
                            chartThongKeHoaDonBan.Legends.Add(newLegends2);
                            chartThongKeHoaDonBan.Series[1].ToolTip = $"Tiền bán: #VALX : #VAL VNĐ";
                            chartThongKeHoaDonBan.Legends[1].Font = new Font("Arial", 12f, FontStyle.Regular);
                            chartThongKeHoaDonBan.Legends[1].MaximumAutoSize = 100;
                            //
                            Series newSeries3 = new Series("Tiền chênh lệch");
                            newSeries3.Points.DataBindXY(listNgay, listTienChenhLech);
                            chartThongKeHoaDonBan.Series.Add(newSeries3);
                            Legend newLegends3 = new Legend();
                            chartThongKeHoaDonBan.Legends.Add(newLegends3);
                            chartThongKeHoaDonBan.Series[2].ToolTip = $"Tiền chênh lệch: #VALX : #VAL VNĐ";
                            chartThongKeHoaDonBan.Legends[2].Font = new Font("Arial", 12f, FontStyle.Regular);
                            chartThongKeHoaDonBan.Legends[2].MaximumAutoSize = 100;
                            //
                            if (chartThongKeHoaDonBan.ChartAreas.Count > 0)
                            {
                                chartThongKeHoaDonBan.ChartAreas[0].AxisX.Interval = 1;
                                chartThongKeHoaDonBan.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
                                chartThongKeHoaDonBan.Titles.Add($"Biểu đồ doanh thu trong tháng {thang}/{nam}");
                                if (chartThongKeHoaDonBan.Titles.Count > 0)
                                {
                                    chartThongKeHoaDonBan.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic);
                                }
                            }
                        }

                            break;
            }
            }    
             
          
            }
        }
    }
