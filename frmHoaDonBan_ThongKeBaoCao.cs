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
            ds = classTong.LayDuLieu(" SELECT MONTH(NGAYLAPHD) AS 'THANG', CONVERT(INT,SUM(GIAVON*SOLUONG)) AS 'TIENVON', CONVERT(INT,SUM(THANHTIENCUOICUNG)) AS 'TIENBAN',  CONVERT(INT,SUM(THANHTIENCUOICUNG) - SUM(GIAVON*SOLUONG)) AS 'TIENCHENHLECH' FROM HOADONBAN A,  CHITIETHDB B WHERE A.MAHDB = B.MAHDB  GROUP BY MONTH(NGAYLAPHD)");
            if (ds.Tables[0].Rows.Count > 0)
            {
                int doanhthucaonhat = Convert.ToInt32(ds.Tables[0].Compute("MAX(TIENBAN)", ""));
                int tienloinhieunhat = Convert.ToInt32(ds.Tables[0].Compute("MAX(TIENCHENHLECH)", ""));
                List<int> thangdoanhthucaonhat = new List<int>();
                List<int> thangtienloinhieunhat = new List<int>();
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++)
                {
                    if((int)ds.Tables[0].Rows[i]["TIENCHENHLECH"] == tienloinhieunhat)
                    {
                        thangdoanhthucaonhat.Add((int)ds.Tables[0].Rows[i]["THANG"]);
                    }
                    if ((int)ds.Tables[0].Rows[i]["TIENBAN"] == doanhthucaonhat)
                    {
                        thangtienloinhieunhat.Add((int)ds.Tables[0].Rows[i]["THANG"]);
                    }    
                }
                lblThangCoLoiNhieuNhat.Text = "Tháng ";
                lblThangDoanhThuCaoNhat.Text = "Tháng ";
                for (int i = 0;i< thangtienloinhieunhat.Count;i++)
                {
                    lblThangCoLoiNhieuNhat.Text += thangtienloinhieunhat[i] + " ";
                }
                for (int i = 0; i < thangdoanhthucaonhat.Count; i++)
                {
                    lblThangDoanhThuCaoNhat.Text += thangdoanhthucaonhat[i]+ " ";
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
                //Series newSeries4 = new Series("Doanh thu quảng cáo");
                //newSeries4.Points.DataBindXY(months, new double[12]);
                //chartThongKeHoaDonBan.Series.Add(newSeries4);
                //chartThongKeHoaDonBan.Series[0].Points.DataBindXY(listChuoiThang, listTienVon);
                //chartThongKeHoaDonBan.Series[1].Points.DataBindXY(listChuoiThang, listTienBan);
                //chartThongKeHoaDonBan.Series[2].Points.DataBindXY(listChuoiThang, listTienChenhLech);
                //chartThongKeHoaDonBan.Series[0].Name = "Doanh thu bán hàng";
                //chartThongKeHoaDonBan.Series[1].Name = "Doanh thu dịch vụ";
                //chartThongKeHoaDonBan.Series[2].Name = "Doanh thu quảng cáo";
                chartThongKeHoaDonBan.ChartAreas[0].AxisX.Interval = 1;
                chartThongKeHoaDonBan.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
                chartThongKeHoaDonBan.Titles.Add("Biểu đồ doanh thu theo tháng");
                if (chartThongKeHoaDonBan.Titles.Count > 0)
                {
                    chartThongKeHoaDonBan.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic);
                }

            }
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
    }
}
