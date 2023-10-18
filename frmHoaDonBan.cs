using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan(string account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void grpThongTinSanPham_Enter(object sender, EventArgs e)
        {

        }
        _9_12_QuanLyQuanCaPhe classTong = new _9_12_QuanLyQuanCaPhe();
        int vitri_chitiethoadon = 0;
        int vitri_hoadon = 0;
        DataSet ds_HoaDon = new DataSet();
        DataSet ds_ChiTietHoaDon = new DataSet();
        DataSet ds_NCC = new DataSet();
        DataSet ds_MASP = new DataSet();
        DataSet ds_MASIZE = new DataSet();
        DataSet ds_KiemTra = new DataSet();
        DataSet ds_KhuyenMai = new DataSet();
        DataSet ds_ChiTietKhuyenMai = new DataSet();
        string account = "";
        // cờ cho các thao tác với Hoá đơn
        // 1: đang thêm  Hoá đơn
        // 2: sửa  Hoá đơn
        // 3: xoá  Hoá đơn
        int flag_HoaDon = 0;
        int flag_ChiTietHoaDon = 0;
        int flag = 0;
        /// <summary>
        /// Hàm này có chức năng truy vấn dữ liệu, và hiển thị lên DataGridView
        /// </summary>
        /// <param name="d">Tên của DataGridView</param>
        /// <param name="sql">Câu lệnh truy vấn. Ví dụ: SELECT * FROM SANPHAM</param>
        void danhsach_datagridview(ref DataSet ds, DataGridView dgv, string sql)
        {
            ds = classTong.LayDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        /// <summary>
        /// Hàm có chức năng lấy dữ liệu hiển thị dưới dạng comboBox
        /// Cột hiển thị thường là cột tên, tương ứng với tên chính là mã
        /// </summary>
        /// <param name="ds">Tên của DataSet</param>
        /// <param name="cb">Tên của ComboBox</param>
        /// <param name="sql">Câu lệnh truy vấn SQL</param>
        /// <param name="tencot">Tên cột hiển thị DisplayMember</param>
        /// <param name="ma">Mã tương ứng với cột hiển thị ValueMember</param>
        void hienThiComboBox(ref DataSet ds, ComboBox cb, string sql, string tencot, string ma)
        {
            ds = classTong.LayDuLieu(sql);
            cb.DataSource = ds.Tables[0];
            cb.DisplayMember = tencot;
            cb.ValueMember = ma;
            cb.SelectedIndex = -1;
        }
        /// <summary>
        /// Hàm có chức năng hiển thị comboBox trong datagridview, tức là DataGridViewComboBoxColumn
        /// </summary>
        /// <param name="ds">Tên của DataSet</param>
        /// <param name="tencot_ComboBox">Tên cột là ComboBox trong DataGridView</param>
        /// <param name="sql">Câu lệnh truy vấn SQL</param>
        /// <param name="tencotHienThi">Tên cột hiển thị DisplayMember</param>
        /// <param name="maTuongUngVoiCotHienThi">Mã tương ứng với cột hiển thị ValueMember</param>
        void hienThiComboBoxtrongDataGridView(ref DataSet ds, DataGridViewComboBoxColumn tencot_ComboBox, string sql, string tencotHienThi, string maTuongUngVoiCotHienThi)
        {
            ds = classTong.LayDuLieu(sql);
            tencot_ComboBox.DataSource = ds.Tables[0];
            tencot_ComboBox.DisplayMember = tencotHienThi;
            tencot_ComboBox.ValueMember = maTuongUngVoiCotHienThi;
            // Lặp qua từng ô chứa DataGridViewComboBoxColumn và gọi RefreshEdit
        }

        private void txtTenSanPhamTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTenSanPhamTimKiem_Click(object sender, EventArgs e)
        {
            string mactsp = txtMaChiTietSanPham.Text;
            lblMaChiTietSanPham.Text = mactsp;
            XoaDuLieuTrongControl_ChiTietHoaDon();
            // Đầu tiên sẽ kiểm tra xem có tồn tại sản phẩm có mã chi tiết sản phẩm đó
            ds_KiemTra = classTong.LayDuLieu($"SELECT DISTINCT A.MASP,B.MASIZE,TENSP,C.MOTA,GIAVON,GIABAN,B.SOLUONG FROM SANPHAM A, CHITIETSANPHAM B,SIZE C WHERE A.MASP = B.MASP AND B.MACTSP='{mactsp}' AND B.MASIZE=C.MASIZE");
            // Nếu có sản phẩm đó
            if (ds_KiemTra.Tables[0].Rows.Count > 0)
            {
                lblGiaVon.Text = Convert.ToInt32(ds_KiemTra.Tables[0].Rows[0]["GIAVON"]).ToString();
                lblSoLuongTonKho.Text = ds_KiemTra.Tables[0].Rows[0]["SOLUONG"].ToString();
                // Lấy tên sản phẩm, size, đơn giá(giá bán)
                lblTenSanPham.Text = ds_KiemTra.Tables[0].Rows[0]["TENSP"].ToString();
                lblTenSize.Text = ds_KiemTra.Tables[0].Rows[0]["MOTA"].ToString();
                lblDonGia.Text = Convert.ToInt32(ds_KiemTra.Tables[0].Rows[0]["GIABAN"]).ToString();
                ds_KiemTra = classTong.LayDuLieu($"SELECT * FROM KHUYENMAI A, CHITIETKM B WHERE GETDATE() BETWEEN A.NGAYBATDAU AND A.NGAYHETHAN AND A.TRANGTHAI = N'Hoạt động' AND B.TRANGTHAI = N'Hoạt động' AND B.MASP = '01' AND B.MASIZE = 'M';");
                // Kiểm tra xem sản phẩm này có khuyến mãi hay không
                // Tách mã chi tiết sản phẩm ra mã sản phẩm và mã size
                string[] spMactsp = mactsp.Split('.');
                string masp = spMactsp[0] + "." + spMactsp[1];
                string masize = spMactsp[2];
                ds_KiemTra = classTong.LayDuLieu($"SELECT * FROM KHUYENMAI A, CHITIETKM B WHERE GETDATE() BETWEEN A.NGAYBATDAU AND A.NGAYHETHAN AND A.TRANGTHAI = N'Hoạt động' AND B.TRANGTHAI = N'Hoạt động' AND B.MASP = '{masp}' AND B.MASIZE = '{masize}' AND A.MAKM = B.MAKM");
                // Nếu có tồn tại chi tiết khuyến mãi
                if (ds_KiemTra.Tables[0].Rows.Count > 0)
                {
                    lblMaKhuyenMai.Text = ds_KiemTra.Tables[0].Rows[0]["MAKM"].ToString();
                    lblTenKhuyenMai.Text = ds_KiemTra.Tables[0].Rows[0]["TENKM"].ToString();
                    lblPhanTramGiam.Text = ds_KiemTra.Tables[0].Rows[0]["PHANTRAMGIAM"].ToString();
                    lblSoTienGiamToiDa.Text = Convert.ToInt32(ds_KiemTra.Tables[0].Rows[0]["SOTIENGIAMTOIDA"]).ToString();
                }
            }
            else

            {
                MessageBox.Show("Không tồn tại sản phẩm có mã như trên !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            //
            XoaDuLieuTrongControl_HoaDon();
            XoaDuLieuTrongControl_ChiTietHoaDon();
            TaoCotHDB();
            TaoCotCTHDB();
            //danhsach_datagridview(ref ds_HoaDon,dgvDanhSachHoaDon, "SELECT MAHDB,MAKH,CONVERT(DECIMAL(18,0),TONGTIENTHANHTOAN) AS 'TONGTIENTHANHTOAN',MANV_LAP,CONVERT(varchar(20), NGAYLAPHD, 103) + ' ' + CONVERT(varchar(20), NGAYLAPHD, 108) AS 'NGAYLAPHD',TRANGTHAI,GHICHU FROM HOADONBAN WHERE TRANGTHAI != N'Thanh toán'");
            CacTextboxChiDoc_HoaDon(true);
            hienthi_textbox_HoaDon(ds_HoaDon, vitri_hoadon);
            // 
            //hienThiComboBox(ref ds_MASP, cboMaSanPham, "SELECT * FROM SANPHAM", "TENSP", "MASP");
            //hienThiComboBox(ref ds_MASIZE, cboMaSize, "SELECT * FROM SIZE", "MOTA", "MASIZE");
            // Load comboBox ở trong Data
            //hienThiComboBoxtrongDataGridView(ref ds_MASP, MASP, "SELECT * FROM SANPHAM", "TENSP", "MASP");
            //hienThiComboBoxtrongDataGridView(ref ds_MASIZE, MASIZE, "SELECT * FROM SIZE", "MOTA", "MASIZE");
            ChiTietHoaDon_Load(vitri_hoadon);
            CacTextboxChiDoc_ChiTietHoaDon(true);
        }
        void ChiTietHoaDon_Load(int vt)
        {
            XoaDuLieuTrongControl_ChiTietHoaDon();
            //if (ds_HoaDon.Tables[0].Rows.Count > 0)
            //{
            //    danhsach_datagridview(ref ds_ChiTietHoaDon, dgvDanhSachChiTietHoaDon, $"  SELECT MASP,MASIZE,SOLUONG,CONVERT(DECIMAL(18,0),GIABAN) AS 'GIABAN', CONVERT(DECIMAL(18,0),THANHTIENBANDAU) AS 'THANHTIENBANDAU',CONVERT(DECIMAL(18,0),THANHTIENCUOICUNG) AS 'THANHTIENCUOICUNG' , B.TRANGTHAI,CONVERT(DECIMAL(18,0),SOTIENGIAM) AS 'SOTIENGIAM' FROM HOADONBAN A, CHITIETHDB B WHERE A.MAHDB='{ds_HoaDon.Tables[0].Rows[vt]["MAHDB"]}' AND A.MAHDB = B.MAHDB");
            //    if (ds_ChiTietHoaDon.Tables.Count > 0)
            //    {
            //        hienthi_textbox_ChiTietHoaDon(ds_ChiTietHoaDon, vitri_chitiethoadon);
            //    }
            //    else
            //    {
            //    }    
            //}
        }
        void hienthi_textbox_HoaDon(DataSet ds, int vt)
        {

            if (ds.Tables.Count > 0)
            {
                if (vt >= 0 && vt < ds.Tables[0].Rows.Count)
                {
                    lblMaHoaDonBan.Text = ds.Tables[0].Rows[vt]["MAHDB"].ToString();
                    lblTongSoTienThanhToan.Text = ds.Tables[0].Rows[vt]["TONGTIENTHANHTOAN"].ToString();
                    lblMaNhanVienLap.Text = ds.Tables[0].Rows[vt]["MANV_LAP"].ToString();
                    //cboTrangThaiHoaDon.Text = ds.Tables[0].Rows[vt]["TRANGTHAI"].ToString();
                    lblMaKhachHang.Text = ds.Tables[0].Rows[vt]["MAKH"].ToString();
                    ds_KiemTra = classTong.LayDuLieu($"SELECT * FROM KHACHHANG WHERE MAKH='{ds.Tables[0].Rows[vt]["MAKH"]}'");
                    lblTenKhachHang.Text = ds_KiemTra.Tables[0].Rows[0]["TENKH"].ToString();
                    txtSoDienThoai.Text = ds_KiemTra.Tables[0].Rows[0]["SDT"].ToString();
                    ds_KiemTra = classTong.LayDuLieu($"SELECT * FROM NHANVIEN WHERE MANV='{ds.Tables[0].Rows[vt]["MANV_LAP"]}'");
                    lblTenNhanVienLap.Text = ds_KiemTra.Tables[0].Rows[0]["TENNV"].ToString();
                }
                else
                {
                }
            }
            else
            {
            }
        }
        void CacTextboxChiDoc_HoaDon(bool t = false)
        {
            txtSoDienThoai.ReadOnly = t;
            btnTimKiemSoDienThoai.Enabled = !t;
        }
        void XoaDuLieuTrongControl_HoaDon()
        {
            lblMaHoaDonBan.Text = "";
            txtSoDienThoai.Text = "";
            lblMaKhachHang.Text = "";
            lblTenKhachHang.Text = "";
            lblTongSoTienThanhToan.Text = "0";
            lblMaNhanVienLap.Text = "";
            lblTenNhanVienLap.Text = "";
            //cboTrangThaiHoaDon.SelectedIndex = 1;
            rtxtGhiChu.Text = "";
        }
        void hienthi_textbox_ChiTietHoaDon(DataGridView dgv, int vt)
        {
            if (dgv.RowCount > 0)
            {
                if (vt >= 0 && vt < dgv.Rows.Count - 1)
                {
                    //string mactsp = dgv.Rows[vt].Cells["MACTSP"].Value.ToString();
                    string masp = dgv.Rows[vt].Cells[1].Value.ToString();
                    string masize = dgv.Rows[vt].Cells[2].Value.ToString();
                    int giavon = Convert.ToInt32(dgv.Rows[vt].Cells[3].Value.ToString());
                    int giaban = Convert.ToInt32(dgv.Rows[vt].Cells[4].Value.ToString());
                    int soluong = Convert.ToInt32(dgv.Rows[vt].Cells[5].Value.ToString());
                    string makm = dgv.Rows[vt].Cells[6].Value.ToString();
                    int thanhtienbandau = Convert.ToInt32(dgv.Rows[vt].Cells[7].Value.ToString());
                    int giagiam = Convert.ToInt32(dgv.Rows[vt].Cells[8].Value.ToString());
                    int thanhtiencuoicung = Convert.ToInt32(dgv.Rows[vt].Cells[9].Value.ToString());
                    string trangthaiSQL = "Đã thanh toán";
                    // Hiển thị lên các label 
                    ds_KiemTra = classTong.LayDuLieu($"SELECT TENSP FROM SANPHAM WHERE MASP='{masp}'");
                    lblTenSanPham.Text = ds_KiemTra.Tables[0].Rows[0]["TENSP"].ToString();
                    ds_KiemTra = classTong.LayDuLieu($"SELECT MOTA FROM SIZE WHERE MASIZE='{masize}'");
                    lblTenSize.Text = ds_KiemTra.Tables[0].Rows[0]["MOTA"].ToString();
                    // Label khuyến mãi
                    ds_KiemTra = classTong.LayDuLieu($"SELECT * FROM KHUYENMAI A, CHITIETKM B WHERE GETDATE() BETWEEN A.NGAYBATDAU AND A.NGAYHETHAN AND A.TRANGTHAI = N'Hoạt động' AND B.TRANGTHAI = N'Hoạt động' AND B.MASP = '{masp}' AND B.MASIZE = '{masize}' AND A.MAKM = B.MAKM AND A.MAKM='{makm}'");
                    // Nếu có tồn tại chi tiết khuyến mãi
                    if (ds_KiemTra.Tables[0].Rows.Count > 0)
                    {
                        lblMaKhuyenMai.Text = ds_KiemTra.Tables[0].Rows[0]["MAKM"].ToString();
                        lblTenKhuyenMai.Text = ds_KiemTra.Tables[0].Rows[0]["TENKM"].ToString();
                        lblPhanTramGiam.Text = ds_KiemTra.Tables[0].Rows[0]["PHANTRAMGIAM"].ToString();
                        lblSoTienGiamToiDa.Text = Convert.ToInt32(ds_KiemTra.Tables[0].Rows[0]["SOTIENGIAMTOIDA"]).ToString();
                    }
                    nupSoLuong.Value = Convert.ToInt32(dgv.Rows[vt].Cells[5].Value.ToString());
                    lblDonGia.Text = dgv.Rows[vt].Cells[4].Value.ToString();
                    lblThanhTienDau.Text = dgv.Rows[vt].Cells[7].Value.ToString();
                    lblThanhTienCuoi.Text = dgv.Rows[vt].Cells[9].Value.ToString();
                }
                else
                {
                }
            }
            else
            {
            }
        }

        private void dgvDanhSachChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //vitri_chitiethoadon = e.RowIndex;// Lấy vị trí được chọn
            //if (vitri_chitiethoadon >= 0 && vitri_chitiethoadon < dgvDanhSachChiTietHoaDon.Rows.Count)
            //{
            //    XoaDuLieuTrongControl_ChiTietHoaDon();
            //    hienthi_textbox_ChiTietHoaDon(dgvDanhSachChiTietHoaDon, vitri_chitiethoadon);
            //}
            //else
            //{
            //    XoaDuLieuTrongControl_ChiTietHoaDon();
            //}
        }

        private void dgvDanhSachHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri_hoadon = e.RowIndex;// Lấy vị trí được chọn
            if (vitri_hoadon >= 0 && vitri_hoadon < dgvDanhSachHoaDon.Rows.Count)
            {
                hienthi_textbox_HoaDon(ds_HoaDon, vitri_hoadon);
                ChiTietHoaDon_Load(vitri_hoadon);
            }
            else
            {
            }
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            dgvDanhSachHoaDon.DataSource = null;
            dgvDanhSachHoaDon.Columns.Clear();
            TaoCotHDB();
            dgvDanhSachChiTietHoaDon.DataSource = null;
            dgvDanhSachChiTietHoaDon.Columns.Clear();
            TaoCotCTHDB();
            CacTextboxChiDoc_HoaDon(false);
            CacTextboxChiDoc_ChiTietHoaDon(false);
            XoaDuLieuTrongControl_HoaDon();
            XoaDuLieuTrongControl_ChiTietHoaDon();
            // Các textbox xử lý như sau
            ds_KiemTra = classTong.LayDuLieu("SELECT COUNT(*) AS 'SOHANG' FROM HOADONBAN");
            lblMaHoaDonBan.Text = (int.Parse(ds_KiemTra.Tables[0].Rows[0]["SOHANG"].ToString()) + 1).ToString();
            lblMaNhanVienLap.Text = account;
            ds_KiemTra = classTong.LayDuLieu($"SELECT * FROM NHANVIEN WHERE MANV ='{account}'");
            lblTenNhanVienLap.Text = ds_KiemTra.Tables[0].Rows[0]["TENNV"].ToString();
            flag = 1;
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            XoaDuLieuTrongControl_HoaDon();
            CacTextboxChiDoc_HoaDon(true);
            hienthi_textbox_HoaDon(ds_HoaDon, 0);
        }

        private void btnTimKiemSoDienThoai_Click(object sender, EventArgs e)
        {
            if (txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Số điện thoại không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ValidateSDT(txtSoDienThoai.Text))
            {
                //txtSoDienThoai.Text = "";
                return;
            }
            ds_KiemTra = classTong.LayDuLieu($"SELECT * FROM KHACHHANG WHERE SDT ='{txtSoDienThoai.Text}'");
            if (ds_KiemTra.Tables[0].Rows.Count > 0)
            {
                lblTenKhachHang.Text = ds_KiemTra.Tables[0].Rows[0]["TENKH"].ToString();
                lblMaKhachHang.Text = ds_KiemTra.Tables[0].Rows[0]["MAKH"].ToString();
            }
            else
            {
                MessageBox.Show("Không tồn tại Khách hàng nào có số điện thoại như trên !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        void CacTextboxChiDoc_ChiTietHoaDon(bool t = false)
        {
            txtMaChiTietSanPham.ReadOnly = t;
            //cboMaSanPham.Enabled = !t ;
            //cboMaSize.Enabled =!t;
            //cboTrangThaiChiTietHoaDon.Enabled = !t;
            nupSoLuong.ReadOnly = t;
        }
        void XoaDuLieuTrongControl_ChiTietHoaDon()
        {
            txtMaChiTietSanPham.Text = "";
            lblTenSanPham.Text = "";
            lblTenSize.Text = "";
            //cboMaSanPham.SelectedIndex = -1;
            //cboMaSize.SelectedIndex = -1;
            lblMaKhuyenMai.Text = "";
            lblTenKhuyenMai.Text = "";
            lblPhanTramGiam.Text = "";
            lblSoTienGiamToiDa.Text = "";
            //cboTrangThaiChiTietHoaDon.SelectedIndex = -1;
            lblDonGia.Text = "0";
            lblSoTienGiamGia.Text = "0";
            lblThanhTienCuoi.Text = "0";
            nupSoLuong.Value = 0;
        }
        private void btnThemChiTietHoaDon_Click(object sender, EventArgs e)
        {
            CacTextboxChiDoc_ChiTietHoaDon(false);
            XoaDuLieuTrongControl_ChiTietHoaDon();
            flag_ChiTietHoaDon = 1;
        }

        private void btnHuyChiTietSanPham_Click(object sender, EventArgs e)
        {
            XoaDuLieuTrongControl_ChiTietHoaDon();
            CacTextboxChiDoc_ChiTietHoaDon(true);
            hienthi_textbox_ChiTietHoaDon(dgvDanhSachChiTietHoaDon, 0);
        }

        private void btnThoatHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            string mahdb = lblMaHoaDonBan.Text;
            if (mahdb == "")
            {
                MessageBox.Show("Bạn chưa tạo Hoá đơn mới", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string makh = lblMaKhachHang.Text;
            decimal tongtienthanhtoan = Decimal.Parse(lblTongSoTienThanhToan.Text);
            string manv_lap = lblMaNhanVienLap.Text;
            string trangthai = "Đã thanh toán";
            string ghichu = rtxtGhiChu.Text;
            object[] d = new object[6];
            d[0] = mahdb;
            d[1] = makh;
            d[2] = tongtienthanhtoan.ToString();
            d[3] = manv_lap;
            d[4] = trangthai;
            d[5] = ghichu;
            dgvDanhSachHoaDon.Rows.Add(d);
            //string contentQR = $"Mã hoá đơn: {dgvDanhSachHoaDon.Rows[0].Cells[0].Value}\nTổng tiền thanh toán: {dgvDanhSachHoaDon.Rows[0].Cells[2].Value}\nMã khách hàng: {dgvDanhSachHoaDon.Rows[0].Cells[1].Value}\nNhân viên lập: {dgvDanhSachHoaDon.Rows[0].Cells[3].Value}\nNgày lập hoá đơn: {dgvDanhSachHoaDon.Rows[0].Cells[4].Value}\nGhi chú: {dgvDanhSachHoaDon.Rows[0].Cells[6].Value}";
            //TaoQR(contentQR, ptxMaQR);
            CacTextboxChiDoc_ChiTietHoaDon(false);
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
            ds_HD = classTong.LayDuLieu($"SELECT MAHDB,A.MAKH,B.MANV,CONVERT(varchar(20), NGAYLAPHD, 103) + ' ' + CONVERT(varchar(20), NGAYLAPHD, 108) AS 'NGAYLAPHD',CONVERT(DECIMAL(18,0),TONGTIENTHANHTOAN) AS 'TONGTIENTHANHTOAN'  FROM HOADONBAN A, NHANVIEN B WHERE MAHDB='{mahdb}' AND A.MANV_LAP=B.MANV");
            DataSet ds_CTHD = new DataSet();
            ds_CTHD = classTong.LayDuLieu($"SELECT TENSP,D.MASIZE,D.SOLUONG,D.GIABAN,D.SOTIENGIAM,THANHTIENCUOICUNG  FROM SANPHAM A, CHITIETSANPHAM B,HOADONBAN C, CHITIETHDB D WHERE A.MASP=B.MASP AND B.MASIZE = D.MASIZE AND B.MASP = D.MASP AND C.MAHDB=D.MAHDB AND C.MAHDB='{mahdb}'");
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
                exRange.Range[$"a" + row + ""].ColumnWidth = 13;
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
            int tongtienthanhtoan = Convert.ToInt32(ds_HD.Tables[0].Rows[0]["TONGTIENTHANHTOAN"].ToString());
            exRange.Range[$"D" + row + ":F" + row + ""].Value = tongtienthanhtoan.ToString("N0");
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
            // Mở tệp Excel bằng ứng dụng mặc định của hệ thống
            Process.Start(filePath);

            string pdfFilePath = Path.ChangeExtension(filePath, "pdf");
            // Mở tệp Excel bằng ứng dụng mặc định của hệ thống
            Process.Start(pdfFilePath);
            return true;
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (XuatHoaDon("HD23"))
            {
                MessageBox.Show("Xuất hoá đơn thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xuất hoá đơn THẤT BẠI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        }

        private void btnSuaHoaDon_Click(object sender, EventArgs e)
        {
            CacTextboxChiDoc_HoaDon(true);
        }

        private void btnLuuChiTietHoaDon_Click(object sender, EventArgs e)
        {
            if (lblTenSanPham.Text == "")
            {
                MessageBox.Show("Vui lòng thêm sản phẩm và chọn số lượng !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mactsp = lblMaChiTietSanPham.Text;
            string mahdb = lblMaHoaDonBan.Text;
            string[] spMactsp = mactsp.Split('.');
            string masp = spMactsp[0] + "." + spMactsp[1];
            string masize = spMactsp[2];
            //string macthdb = mahdb + "." + mactsp;
            int soluong = (int)nupSoLuong.Value;
            if (soluong == 0)
            {
                MessageBox.Show("Bạn chưa nhập Số lượng, vui lòng nhập Số lượng !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int giavon = Convert.ToInt32(lblGiaVon.Text);
            int giaban = Convert.ToInt32(lblDonGia.Text);
            string makm = lblMaKhuyenMai.Text;
            int thanhtienbandau = Convert.ToInt32(lblThanhTienDau.Text);
            int giagiam = Convert.ToInt32(lblSoTienGiamGia.Text);
            int thanhtiencuoicung = Convert.ToInt32(lblThanhTienCuoi.Text);
            //string trangthai = cboTrangThaiChiTietHoaDon.Text;
            // 0. mã ctsp, 1. tên sp, 2. tên size, 3.giá vốn, 4.đơn giá, 5.số lượng, 6.mã khuyến mãi, 7.thành tiền ban đầu, 8.số tiền giảm, 9.thành tiền cuói cùng, 10.trạng thái
            object[] d = new object[11];
            d[0] = mactsp;
            d[1] = masp;
            d[2] = masize;
            d[3] = giavon.ToString();
            d[4] = giaban.ToString();
            d[5] = soluong.ToString();
            d[6] = makm.ToString();
            d[7] = thanhtienbandau.ToString();
            d[8] = giagiam.ToString();
            d[9] = thanhtiencuoicung.ToString();
            d[10] = "";
            dgvDanhSachChiTietHoaDon.Rows.Add(d);
            // Cập nhật trên label tổng tiền thanh toán của hoá đơn bán
            // tổng tiền thanh toán của hoá đơn bán
            int tongtienthanhtoan = Convert.ToInt32(lblTongSoTienThanhToan.Text);
            // Cập nhật trên label tổng tiền thanh toán của hoá đơn bán
            lblTongSoTienThanhToan.Text = (tongtienthanhtoan + thanhtiencuoicung).ToString();
            dgvDanhSachHoaDon.Rows[0].Cells[2].Value = (tongtienthanhtoan + thanhtiencuoicung);
            XoaDuLieuTrongControl_ChiTietHoaDon();
        }
        //else
        //{
        //    MessageBox.Show("Không tồn tại mã chi tiết sản phẩm này !!! ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //    break;
        //}

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void nupSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                int soluongton = Convert.ToInt32(lblSoLuongTonKho.Text);
                if (nupSoLuong.Value <= soluongton)
                {
                    lblThanhTienDau.Text = (nupSoLuong.Value * Convert.ToInt32(lblDonGia.Text)).ToString();
                    if (lblPhanTramGiam.Text != "")
                    {
                        decimal sotiengiamgia = Convert.ToDecimal(lblPhanTramGiam.Text) / 100 * Convert.ToInt32(lblThanhTienDau.Text);
                        lblSoTienGiamGia.Text = Convert.ToInt32(sotiengiamgia).ToString();
                        if (sotiengiamgia > Convert.ToInt32(lblSoTienGiamToiDa.Text))
                        {
                            sotiengiamgia = Convert.ToInt32(lblSoTienGiamToiDa.Text);
                            lblSoTienGiamGia.Text = sotiengiamgia.ToString();
                        }
                        lblThanhTienCuoi.Text = (Convert.ToInt32(lblThanhTienDau.Text) - Convert.ToInt32(lblSoTienGiamGia.Text)).ToString();
                    }
                    else
                    {
                        lblThanhTienCuoi.Text = (Convert.ToInt32(lblThanhTienDau.Text)).ToString();
                    }

                }
                else
                {
                    MessageBox.Show($"Số lượng sản phẩm đặt mua không đủ chỉ còn {soluongton}, Vui lòng giảm số lượng", "Thông báo");
                    nupSoLuong.Value = 0;
                }
            }
        }

        private void grpThongTinChiTietSanPham_Enter(object sender, EventArgs e)
        {

        }
        private void TaoQR(string content, PictureBox ptx)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            ptx.Image = qrCodeImage;
            ptx.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lblMaHoaDonBan.Text != "" && dgvDanhSachChiTietHoaDon.RowCount > 1)
            {
                int mahdb = int.Parse(lblMaHoaDonBan.Text);
                // phần hoá đơn bán
                string makh = lblMaKhachHang.Text != "" ? $"'{lblMaKhachHang.Text}'" : "NULL";
                decimal tongtienthanhtoan = Decimal.Parse(lblTongSoTienThanhToan.Text);
                string manv_lap = lblMaNhanVienLap.Text;
                // string ngaylaphd = lblNgayLapHoaDon.Text;
                string ngaylaphd = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string trangthai = "Đã thanh toán";
                string ghichu = rtxtGhiChu.Text;
                string sqlHDB = $"INSERT INTO HOADONBAN VALUES ({mahdb},{makh},{tongtienthanhtoan},'{manv_lap}','{ngaylaphd}',N'{trangthai}',N'{ghichu}')";
                // Thực hiện lưu vào bảng HOÁ ĐƠN BÁN trong csdl
                classTong.CapNhatDuLieu(sqlHDB);
                for (int i = 0; i < dgvDanhSachChiTietHoaDon.RowCount - 1; i++)
                {
                    //string mactsp = dgvDanhSachChiTietHoaDon.Rows[i].Cells["MACTSP"].Value.ToString();
                    //string[] spMactsp = mactsp.Split('.');
                    //string masp = spMactsp[0] + "." + spMactsp[1];
                    //string masize = spMactsp[2];
                    //string macthdb = mahdb + "." + mactsp;
                    string masp = dgvDanhSachChiTietHoaDon.Rows[i].Cells[1].Value.ToString();
                    string masize = dgvDanhSachChiTietHoaDon.Rows[i].Cells[2].Value.ToString();
                    string mactsp = masp + "." + masize;
                    int giavon = Convert.ToInt32(dgvDanhSachChiTietHoaDon.Rows[i].Cells[3].Value.ToString());
                    int giaban = Convert.ToInt32(dgvDanhSachChiTietHoaDon.Rows[i].Cells[4].Value.ToString());
                    int soluong = Convert.ToInt32(dgvDanhSachChiTietHoaDon.Rows[i].Cells[5].Value.ToString());
                    string makm = dgvDanhSachChiTietHoaDon.Rows[i].Cells[6].Value.ToString();
                    makm = makm != "" ? $"'{makm}'" : "NULL";
                    int thanhtienbandau = Convert.ToInt32(dgvDanhSachChiTietHoaDon.Rows[i].Cells[7].Value.ToString());
                    int giagiam = Convert.ToInt32(dgvDanhSachChiTietHoaDon.Rows[i].Cells[8].Value.ToString());
                    int thanhtiencuoicung = Convert.ToInt32(dgvDanhSachChiTietHoaDon.Rows[i].Cells[9].Value.ToString());
                    string trangthaiSQL = "Đã thanh toán";
                    string sqlThanhToan = $"INSERT INTO CHITIETHDB VALUES ({mahdb},'{masp}','{masize}',{giavon},{giaban},{soluong},{makm},{thanhtienbandau},{giagiam},{thanhtiencuoicung},N'{trangthaiSQL}')";
                    // Thực hiện lưu vào bảng CHI TIẾT HOÁ ĐƠN BÁN trong csdl
                    classTong.CapNhatDuLieu(sqlThanhToan);
                    // Thực hiện cập nhật số lượng sản phẩm trong bảng CHI TIẾT SẢN PHẨM
                    string sqlCTSP = $"UPDATE CHITIETSANPHAM SET SOLUONG-={soluong} WHERE MACTSP='{mactsp}'";
                    classTong.CapNhatDuLieu(sqlCTSP);
                    // Thực hiện cập nhật tổng tiền hoá đơn bán trong bảng HOÁ ĐƠN BÁN
                    sqlHDB = $"UPDATE HOADONBAN SET TONGTIENTHANHTOAN+={thanhtiencuoicung} WHERE MAHDB='{mahdb}'";
                }
                MessageBox.Show("Thanh toán hoá đơn thành công", "Thông báo", MessageBoxButtons.OK);
                if (XuatHoaDon(mahdb.ToString()))
                {
                    MessageBox.Show("Xuất hoá đơn thành công", "Thông báo", MessageBoxButtons.OK);

                }
            }
            else
            {
                MessageBox.Show($"Bạn chưa tạo hoá đơn , Vui lòng tạo hoá đơn !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        bool KiemTraDuLieuTextBoxCoPhaiLaSo(string abc)
        {
            if (flag == 1 || flag == 2)
            {
                double number = 0;
                bool isNumber = double.TryParse(abc, out number);
                if (!isNumber)
                {
                    MessageBox.Show("Dữ liệu ô bạn nhập phải là một số !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            return false;
        }
        private void dgvDanhSachChiTietHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex < dgvDanhSachChiTietHoaDon.Rows.Count - 1 && e.RowIndex >= 0)
            {
                int hang = e.RowIndex;
                // Lấy vị trí( hàng đã chọn)
                int tong = 0;
                for (int i = 0; i < dgvDanhSachChiTietHoaDon.Rows.Count - 1; i++)
                {
                    // Lấy giá trị từng cột trong dòng hiện tại
                    int giaban = Convert.ToInt32(dgvDanhSachChiTietHoaDon.Rows[i].Cells[4].Value.ToString());
                    int soluong = 0;
                    if (KiemTraDuLieuTextBoxCoPhaiLaSo(dgvDanhSachChiTietHoaDon.Rows[i].Cells[5].Value.ToString()))
                    {
                        soluong = int.Parse(dgvDanhSachChiTietHoaDon.Rows[i].Cells[5].Value.ToString());
                    }
                    else
                    {
                        return;
                    }

                    int thanhtienbandau = soluong * giaban;
                    int sotiengiam = 0;
                    int thanhtiencuoicung = 0;
                    dgvDanhSachChiTietHoaDon.Rows[i].Cells[7].Value = thanhtienbandau.ToString();
                    string masp = dgvDanhSachChiTietHoaDon.Rows[i].Cells[1].Value.ToString();
                    string masize = dgvDanhSachChiTietHoaDon.Rows[i].Cells[2].Value.ToString();
                    string makm = dgvDanhSachChiTietHoaDon.Rows[i].Cells[6].Value.ToString();

                    if (makm != "")
                    {
                        DataSet dsKM = new DataSet();
                        dsKM = classTong.LayDuLieu($"SELECT * FROM KHUYENMAI A, CHITIETKM B WHERE A.MAKM = B.MAKM AND B.MASP = '{masp}' AND B.MASIZE ='{masize}'");
                        if (dsKM.Tables[0].Rows.Count > 0)
                        {
                            int sotiengiamtoida = int.Parse(dsKM.Tables[0].Rows[0]["SOTIENGIAMTOIDA"].ToString());
                            double phantramgiam = double.Parse(dsKM.Tables[0].Rows[0]["PHANTRAMGIAM"].ToString()) / 100;
                            sotiengiam = (int)(Convert.ToDouble(thanhtienbandau) * phantramgiam);
                            if (sotiengiam > 100000)
                            {
                                sotiengiam = 100000;
                            }
                        }
                    }
                    thanhtiencuoicung = thanhtienbandau - sotiengiam;
                    dgvDanhSachChiTietHoaDon.Rows[i].Cells[9].Value = thanhtiencuoicung.ToString();
                    tong += thanhtiencuoicung;
                }
                dgvDanhSachHoaDon.Rows[0].Cells[2].Value = tong.ToString(); ;
                lblTongSoTienThanhToan.Text = tong.ToString();

            }
        }

        private void txtMaChiTietSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTenSanPhamTimKiem_Click(sender, e);
            }
        }
        void TaoCotHDB()
        {
            //
            DataGridViewColumn MAHDB = new DataGridViewTextBoxColumn();
            MAHDB.HeaderText = "Mã HDB";
            MAHDB.DataPropertyName = "MAHDB"; // Chỉ định tên thuộc tính dữ liệu
            MAHDB.ReadOnly = true;
            DataGridViewColumn MAKH = new DataGridViewTextBoxColumn();
            MAKH.HeaderText = "MÃ KH";
            MAKH.DataPropertyName = "MAKH"; // Chỉ định tên thuộc tính dữ liệu
            MAKH.ReadOnly = true;
            DataGridViewColumn TONGTIENTHANHTOAN = new DataGridViewTextBoxColumn();
            TONGTIENTHANHTOAN.HeaderText = "TỔNG TIỀN THANH TOÁN";
            TONGTIENTHANHTOAN.DataPropertyName = "TONGTIENTHANHTOAN"; // Chỉ định tên thuộc tính dữ liệu
            TONGTIENTHANHTOAN.ReadOnly = true;
            DataGridViewColumn MANV_LAP = new DataGridViewTextBoxColumn();
            MANV_LAP.HeaderText = "MÃ NV";
            MANV_LAP.DataPropertyName = "MANV_LAP"; // Chỉ định tên thuộc tính dữ liệu
            MANV_LAP.ReadOnly = false;
            DataGridViewColumn NGAYLAPHD = new DataGridViewTextBoxColumn();
            NGAYLAPHD.HeaderText = "NGÀY LẬP HD";
            NGAYLAPHD.DataPropertyName = "NGAYLAPHD"; // Chỉ định tên thuộc tính dữ liệu
            NGAYLAPHD.ReadOnly = true;
            DataGridViewColumn TRANGTHAI = new DataGridViewTextBoxColumn();
            TRANGTHAI.HeaderText = "TRẠNG THÁI";
            TRANGTHAI.DataPropertyName = "TRANGTHAI"; // Chỉ định tên thuộc tính dữ liệu
            TRANGTHAI.ReadOnly = true;
            TRANGTHAI.Visible = false;
            DataGridViewColumn GHICHU = new DataGridViewTextBoxColumn();
            GHICHU.HeaderText = "GHI CHÚ";
            GHICHU.DataPropertyName = "GHICHU"; // Chỉ định tên thuộc tính dữ liệu
            GHICHU.ReadOnly = true;
            dgvDanhSachHoaDon.Columns.Clear();
            dgvDanhSachHoaDon.Columns.Add(MAHDB);
            dgvDanhSachHoaDon.Columns.Add(MAKH);
            dgvDanhSachHoaDon.Columns.Add(TONGTIENTHANHTOAN);
            dgvDanhSachHoaDon.Columns.Add(MANV_LAP);
            dgvDanhSachHoaDon.Columns.Add(TRANGTHAI);
            dgvDanhSachHoaDon.Columns.Add(GHICHU);

        }
        void TaoCotCTHDB()
        {
            //
            DataGridViewColumn MAHDB = new DataGridViewTextBoxColumn();
            MAHDB.HeaderText = "Mã HDB";
            MAHDB.DataPropertyName = "MAHDB"; // Chỉ định tên thuộc tính dữ liệu
            MAHDB.ReadOnly = true;
            MAHDB.Visible = false;
            DataGridViewColumn MASP = new DataGridViewTextBoxColumn();
            MASP.HeaderText = "MÃ SP";
            MASP.DataPropertyName = "MASP"; // Chỉ định tên thuộc tính dữ liệu
            MASP.ReadOnly = true;
            DataGridViewColumn MASIZE = new DataGridViewTextBoxColumn();
            MASIZE.HeaderText = "MÃ SIZE";
            MASIZE.DataPropertyName = "MASIZE"; // Chỉ định tên thuộc tính dữ liệu
            MASIZE.ReadOnly = true;
            DataGridViewColumn GIAVON = new DataGridViewTextBoxColumn();
            GIAVON.HeaderText = "GIÁ VỐN";
            GIAVON.DataPropertyName = "GIAVON"; // Chỉ định tên thuộc tính dữ liệu
            GIAVON.ReadOnly = true;
            GIAVON.Visible = false;

            DataGridViewColumn GIABAN = new DataGridViewTextBoxColumn();
            GIABAN.HeaderText = "GIÁ BÁN";
            GIABAN.DataPropertyName = "GIABAN"; // Chỉ định tên thuộc tính dữ liệu
            GIABAN.ReadOnly = true;
            DataGridViewColumn SOLUONG = new DataGridViewTextBoxColumn();
            SOLUONG.HeaderText = "SỐ LƯỢNG";
            SOLUONG.DataPropertyName = "SOLUONG"; // Chỉ định tên thuộc tính dữ liệu
            SOLUONG.ReadOnly = false; ;
            DataGridViewColumn MAKM = new DataGridViewTextBoxColumn();
            MAKM.HeaderText = "MÃ KM";
            MAKM.DataPropertyName = "MAKM"; // Chỉ định tên thuộc tính dữ liệu
            MAKM.ReadOnly = true;
            DataGridViewColumn THANHTIENBANDAU = new DataGridViewTextBoxColumn();
            THANHTIENBANDAU.HeaderText = "THÀNH TIÊN BAN ĐẦU";
            THANHTIENBANDAU.DataPropertyName = "THANHTIENBANDAU"; // Chỉ định tên thuộc tính dữ liệu
            THANHTIENBANDAU.ReadOnly = true;
            THANHTIENBANDAU.Visible = false;
            DataGridViewColumn SOTIENGIAM = new DataGridViewTextBoxColumn();
            SOTIENGIAM.HeaderText = "SỐ TIỀN GIẢM";
            SOTIENGIAM.DataPropertyName = "SOTIENGIAM"; // Chỉ định tên thuộc tính dữ liệu
            SOTIENGIAM.ReadOnly = true;
            SOTIENGIAM.Visible = false;
            DataGridViewColumn THANHTIENCUOICUNG = new DataGridViewTextBoxColumn();
            THANHTIENCUOICUNG.HeaderText = "THÀNH TIÊN CUỐI CÙNG";
            THANHTIENCUOICUNG.DataPropertyName = "THANHTIENCUOICUNG"; // Chỉ định tên thuộc tính dữ liệu
            THANHTIENCUOICUNG.ReadOnly = true;
            DataGridViewColumn TRANGTHAI = new DataGridViewTextBoxColumn();
            TRANGTHAI.HeaderText = "TRẠNG THÁI";
            TRANGTHAI.DataPropertyName = "TRANGTHAI"; // Chỉ định tên thuộc tính dữ liệu
            TRANGTHAI.ReadOnly = true;
            dgvDanhSachChiTietHoaDon.Columns.Clear();
            dgvDanhSachChiTietHoaDon.Columns.Add(MAHDB);
            dgvDanhSachChiTietHoaDon.Columns.Add(MASP);
            dgvDanhSachChiTietHoaDon.Columns.Add(MASIZE);
            dgvDanhSachChiTietHoaDon.Columns.Add(GIAVON);
            dgvDanhSachChiTietHoaDon.Columns.Add(GIABAN);
            dgvDanhSachChiTietHoaDon.Columns.Add(SOLUONG);
            dgvDanhSachChiTietHoaDon.Columns.Add(MAKM);
            dgvDanhSachChiTietHoaDon.Columns.Add(THANHTIENBANDAU);
            dgvDanhSachChiTietHoaDon.Columns.Add(SOTIENGIAM);
            dgvDanhSachChiTietHoaDon.Columns.Add(THANHTIENCUOICUNG);
            dgvDanhSachChiTietHoaDon.Columns.Add(TRANGTHAI);

        }

        private void txtSoDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemSoDienThoai_Click(sender, e);
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                return;
            }
        }
        bool ValidateSDT(string sdt)
        {
            //Regex regex = new Regex("^[0-9]*$");
            // Kiểm tra nếu chuỗi đã nhập vào không phải là số thì xóa bỏ ký tự đó
            if (!Regex.IsMatch(sdt, "^0(3|9)\\d{8}") || sdt.Length != 10)
            {
                MessageBox.Show("Định dạng số điện thoại không đúng, Vui lòng nhập lại !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMaKhuyenMai_Click(object sender, EventArgs e)
        {

        }

        private void frmHoaDonBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show($"Bạn có chắc muốn Đóng form Hoá đơn bán?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgThoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void lblTongSoTienThanhToan_TextChanged(object sender, EventArgs e)
        {
            //string contentQR = $"Mã hoá đơn: {dgvDanhSachHoaDon.Rows[0].Cells[0].Value}\nTổng tiền thanh toán: {dgvDanhSachHoaDon.Rows[0].Cells[2].Value}\nMã khách hàng: {dgvDanhSachHoaDon.Rows[0].Cells[1].Value}\nNhân viên lập: {dgvDanhSachHoaDon.Rows[0].Cells[3].Value}\nNgày lập hoá đơn: {dgvDanhSachHoaDon.Rows[0].Cells[4].Value}\nGhi chú: {dgvDanhSachHoaDon.Rows[0].Cells[6].Value}";
            //TaoQR(contentQR, ptxMaQR);
        }

        private void lblMaNhanVienLap_Click(object sender, EventArgs e)
        {

        }
    }
}
