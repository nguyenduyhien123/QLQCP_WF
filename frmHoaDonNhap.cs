using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmHoaDonNhap : Form
    {
        public frmHoaDonNhap()
        {
            InitializeComponent();
        }


        DataSet dataset = new DataSet();
        DataSet dsMaNV = new DataSet();
        DataSet dsNhaCungCap = new DataSet();
        DataSet ds_CTHDN = new DataSet();
        DataSet ds_MaSP = new DataSet();
        DataSet ds_MaSize = new DataSet();
        DataSet ds_MAHDN = new DataSet();

        string sql = "";
        int flag = 0;
        int vitri = 0;//tu 0 den n-1
        clsquanlycaphe hoaDonNhap = new clsquanlycaphe();// ket noi vao database
        Boolean Load_dgv = false;


        //ham ket noi
        void danhsach_datagridview(ref DataSet ds, DataGridView dgv, string sql)
        {
            ds = hoaDonNhap.LayDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
            //do 
        }

        void xulychucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
            btnHuy.Enabled = !t;
        }

        void ReadOnly(Boolean t)
        {
            txtThanhTien.ReadOnly = t;
           
            cboMaNCC.Enabled = !t;
            cboTrangThai.Enabled = !t;
            dtpNgaylap.Enabled = !t;
            cboMaNVL.Enabled = !t;
        }

        void HienThi_Textbox(DataSet ds, int vitri)
        {
            if (vitri > -1 && vitri < ds.Tables[0].Rows.Count)
            {
                txtMaHDN.Text = ds.Tables[0].Rows[vitri]["MAHDN"].ToString();
                txtThanhTien.Text = ds.Tables[0].Rows[vitri]["THANHTIEN"].ToString();
                dtpNgaylap.Text = ds.Tables[0].Rows[vitri]["NGAYLAP"].ToString();
                cboTrangThai.Text = ds.Tables[0].Rows[vitri]["TRANGTHAI"].ToString();
                string manv = dataset.Tables[0].Rows[vitri]["MANV_LAP"].ToString();
                string mancc = dataset.Tables[0].Rows[vitri]["MANCC"].ToString();
                hienThiComboBox(dsMaNV, cboMaNVL, $"select * from nhanvien where manv='{manv}' and trangthai != N'Xóa'", "TENNV", "MANV"); //để hiện tên nhân viên lập khi nhấn vào dgv
                hienThiComboBox(dsNhaCungCap, cboMaNCC, $"select * from nhacc where mancc='{mancc}' and trangthai != N'Xóa'", "TENNCC", "MANCC");// để hiện tên nhà cung cấp khi nhấn vào dgv
            }
        }


        void hienThiComboBox(DataSet ds, ComboBox cb, string sql, string tencot, string ma)
        {
            ds = hoaDonNhap.LayDuLieu(sql);
            cb.DataSource = ds.Tables[0];
            cb.DisplayMember = tencot;
            cb.ValueMember = ma;
        }

        void hienThiComboBoxtrongDataGridView(DataSet ds, DataGridViewComboBoxColumn tencot_ComboBox, string sql, string tencotHienThi, string maTuongUngVoiCotHienThi)
        {
            ds = hoaDonNhap.LayDuLieu(sql);
            tencot_ComboBox.DataSource = ds.Tables[0];
            tencot_ComboBox.DisplayMember = tencotHienThi;
            tencot_ComboBox.ValueMember = maTuongUngVoiCotHienThi;
        }

        bool load_dgv = false;
        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(ref dataset, dgvDanhSach, "select * from HOADONNHAP where trangthai != N'Xóa'");
            ReadOnly(true);
            Load_dgv = true;
            ds_CTHDN = hoaDonNhap.LayDuLieu("select * from CHITIETHDN where trangthai != N'Xóa'");
            HienThi_Textbox(dataset, vitri);

            hienThiComboBox(ds_MaSP, cboMaSP_CT, $"select * from SANPHAM where trangthai != N'%x%'", "TENSP", "MASP");
            hienThiComboBox(ds_MaSize, cboMaSize_CT, $"select * from SIZE where trangthai != N'0'", "MASIZE", "MASIZE");
            load_dgv = true;
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            if (vitri >= 0 && vitri < dgvDanhSach.Rows.Count -1)
            {
                if (dataset.Tables.Count > 0)
                {
                    ReadOnly(true);
                    HienThi_Textbox(dataset, vitri);
                    string mahdn = dataset.Tables[0].Rows[vitri]["MAHDN"].ToString();
                    danhsach_datagridview(ref ds_CTHDN, dgvDanhSachCT, $"select * from chitiethdn where MAHDN = '{mahdn}'");
                }
            }
        }

        void clearTextBox(Boolean t)
        {
            txtMaHDN.Clear();
            txtThanhTien.Clear();
            txtTim.Clear();
            cboMaNCC.SelectedIndex = -1;
            cboMaNVL.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            dtpNgaylap.Text = DateTime.Now.ToString();
        }

        string MAHDN_them = "";
        private void btnThem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            ReadOnly(false);
            clearTextBox(true);
            txtMaHDN.Text = phatsinhMa().ToString();
            MAHDN_them = phatsinhMa().ToString();
            txtMaHDN.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            HienThiTimKiem(gboThongTin, gboTimKiem, false);
            hienThiComboBox(dsMaNV, cboMaNVL, "SELECT * FROM NHANVIEN", "TENNV", "MANV");
            hienThiComboBox(dsNhaCungCap, cboMaNCC, "SELECT * FROM NHACC", "TENNCC", "MANCC");
            cboMaNCC.SelectedIndex = -1;
            cboMaNVL.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            flag = 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHDN.Text != "")
            {
                xulychucnang(false);
                flag = 2;
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn xóa ở danh sách hóa đơn nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHDN.Text != "")
            {
                xulychucnang(false);
                HienThiTimKiem(gboThongTin, gboTimKiem, false);
                ReadOnly(false);
                txtThanhTien.ReadOnly=true;
                string tenncc = cboMaNCC.Text;
                string tennv = cboMaNVL.Text;
                hienThiComboBox(dsMaNV, cboMaNVL, "SELECT * FROM NHANVIEN", "TENNV", "MANV");
                hienThiComboBox(dsNhaCungCap, cboMaNCC, "SELECT * FROM NHACC", "TENNCC", "MANCC");
                cboMaNCC.Text = tenncc;
                cboMaNVL.Text = tennv;
                flag = 3;
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn sửa ở danh sách hóa đơn nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        string ThemHDN = "";
        void clearCTHDN()
        {
            cboTrangThai_CT.Text = "";
            cboMaHDN_CT.Text = "";
            cboMaSize_CT.Text = "";
            cboMaSP_CT.Text = "";
            txtSoLuong_CT.Text = "";
            txtDonGia_CT.Text = "";
            txtTong_CT.Text = "";
        }
        string mancc = "";
        string manv = "";
        private void btnLuu_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            string NgayTruocThang = dtpNgaylap.Text;
            DateTime date = DateTime.ParseExact(NgayTruocThang, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string ThangTruocNgay = date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            bool stop = false;

            if(cboMaNCC.SelectedIndex == -1)
            {
                string tenncc = cboMaNCC.Text;
                mancc = hoaDonNhap.LayDuLieu($"select MANCC from nhacc where tenncc = N'{tenncc}'").Tables[0].Rows[0]["MANCC"].ToString();
            }
            else
            {
                mancc = cboMaNCC.SelectedValue.ToString();
            }

            if(cboMaNVL.SelectedIndex == -1)
            {
                string tennv = cboMaNVL.Text;
                manv = hoaDonNhap.LayDuLieu($"select MANV from NHANVIEN where tennv = N'{tennv}'").Tables[0].Rows[0]["MANV"].ToString();
            }
            else
            {
                manv = cboMaNVL.SelectedValue.ToString(); 
            }
            if (flag == 1)//them
            {
                if (txtMaHDN.Text == "" || cboTrangThai.SelectedIndex == -1 || cboMaNCC.Text == "" || cboMaNVL.Text  == "")
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else
                {
                    sql = $"insert hoadonnhap values('{txtMaHDN.Text}', '{manv}', '{mancc}', '{ThangTruocNgay}', NULL,N'{cboTrangThai.Text}')";
                }
            }
            else if (flag == 2)//xoa
            {
                sql = $"update HOADONNHAP set TRANGTHAI=N'Xóa' where MAHDN = '{txtMaHDN.Text}'";
            }
            else if (flag == 3)//sua
            {
                if (txtMaHDN.Text == "" || cboTrangThai.SelectedIndex == -1 || cboMaNCC.Text == "" || cboMaNVL.Text == "")
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else
                {
                    sql = $"update HOADONNHAP set MANV_LAP ='{manv}', MANCC='{mancc}', NGAYLAP='{ThangTruocNgay}',THANHTIEN ={txtThanhTien.Text}, TRANGTHAI=N'{cboTrangThai.Text}' where MAHDN='{txtMaHDN.Text}'";
                }
            }
            if (stop == false)
            {
                if (hoaDonNhap.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    frmHoaDonNhap_Load(sender, e);
                    xulychucnang(true);
                    clearCTHDN();
                    if (flag == 1)
                    {
                        ThemHDN = "ThemHDN Thanh cong";
                    }
                }
            }

            if (ThemHDN.Equals("ThemHDN Thanh cong"))
            {
                gboThongTin.Visible = false;
                btnTim.Visible = false;
                gboChucNangHDN.Visible = false;
                gboThongTinCTHDN.Visible = true;
                ReadOnly_ChiTietHDN(false);
                XuLyChucNangCT(false);
                cboMaHDN_CT.Text = MAHDN_them;
                cboMaHDN_CT.Enabled = false;
                btnTruyCap_CT.Visible = false;
                btnHuyCT.Enabled = false;
                flag_CT = "them";
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            txtMaHDN.Text = "";
            cboMaNCC.Text = "";
            cboTrangThai.Text = "";
            cboMaNVL.Text = "";
            ReadOnly(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string phatsinhMa()
        {
            string maPhatSinh = "";
            DataSet dshdn = hoaDonNhap.LayDuLieu("Select mahdn from hoadonnhap");
            maPhatSinh = "HDN" + (dshdn.Tables[0].Rows.Count + 1).ToString();
            DataSet dshdn_moi;
            if (hoaDonNhap.LayDuLieu($"select mahdn from hoadonnhap where mahdn ='{maPhatSinh}'").Tables[0].Rows.Count > 0)
            {
                int i = 1;
                do
                {
                    maPhatSinh = "HDN" + (dshdn.Tables[0].Rows.Count + i).ToString();
                    i++;
                    dshdn_moi = hoaDonNhap.LayDuLieu($"select mahdn from hoadonnhap where mahdn ='{maPhatSinh}'");
                } while (dshdn_moi.Tables[0].Rows.Count > 0);
            }
            return maPhatSinh;
        }

        void HienThiTimKiem(GroupBox thongtin, GroupBox Tim, Boolean t)
        {
            thongtin.Visible = !t;
            Tim.Visible = t;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            cboTim.SelectedIndex = 0;
            if (gboThongTin.Visible == true)
            {
                btnTim.Text = "Hiện Hộp thông tin";
                HienThiTimKiem(gboThongTin, gboTimKiem, true);
                
            }
            else
            {
                btnTim.Text = "Tìm thông tin khuyến mãi";
                HienThiTimKiem(gboThongTin, gboTimKiem, false);
                danhsach_datagridview(ref dataset, dgvDanhSach, "select * from HOADONNHAP where trangthai != N'Xóa'");
            }
        }

        private void btnTimTT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                MessageBox.Show(this, "Bạn phải điền thông tin thì tôi mới tìm được chứ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboTim.SelectedIndex == 0)
            {
                danhsach_datagridview(ref dataset, dgvDanhSach, $"select * from hoadonnhap where mahdn like N'{txtTim.Text}' and trangthai != N'Xóa'");
            }
            else if (cboTim.SelectedIndex == 1)
            {
                danhsach_datagridview(ref dataset, dgvDanhSach, $"select MAHDN, hdn.MANV_LAP as 'MANV_LAP', hdn.MANCC as 'MANCC',NGAYLAP, THANHTIEN, hdn.TRANGTHAI as 'TRANGTHAI' from NHACC ncc,hoadonnhap hdn where ncc.MANCC = hdn.MANCC and hdn.TRANGTHAI != N'Xóa' and TENNCC like N'%{txtTim.Text}%'");
            }
            else if (cboTim.SelectedIndex == 2)
            {
                danhsach_datagridview(ref dataset, dgvDanhSach, $"select MAHDN, hdn.MANV_LAP as 'MANV_LAP', MANCC,NGAYLAP, THANHTIEN, hdn.TRANGTHAI as 'TRANGTHAI' from nhanvien nv,hoadonnhap hdn where nv.MANV = hdn.MANV_LAP and hdn.TRANGTHAI != N'Xóa' and TENNV like N'%{txtTim.Text}%'");
            }
            else if (cboTim.SelectedIndex == 3)
            {
                danhsach_datagridview(ref dataset, dgvDanhSach, $"select * from hoadonnhap where trangthai like N'%{txtTim.Text}%' and trangthai != N'Xóa'");
            }

            if (dgvDanhSach.Rows.Count - 1 == 0)
            {
                MessageBox.Show(this, "Không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHienDS_Click(object sender, EventArgs e)
        {
            danhsach_datagridview(ref dataset, dgvDanhSach, "select * from HOADONNHAP where trangthai != N'Xóa'");
        }

        private void txtThanhTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và dấu chấm thập phân
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar) && (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar)) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void ReadOnly_ChiTietHDN(Boolean t)
        {
            cboMaHDN_CT.Enabled = !t;
            cboMaSize_CT.Enabled = !t;
            cboMaSP_CT.Enabled = !t;
            txtSoLuong_CT.ReadOnly = t;
            txtDonGia_CT.ReadOnly = t;
            cboTrangThai_CT.Enabled = !t;
            txtSoLuong_CT.ReadOnly = t;
        }
        void HienThi_TextboxCTHDN(DataSet ds, int vitri)
        {
            if (vitri > -1 && vitri < ds.Tables[0].Rows.Count)
            {
                string mahdn = ds.Tables[0].Rows[vitri]["MAHDN"].ToString();
                hienThiComboBox(ds_MAHDN, cboMaHDN_CT, $"select * from HOADONNHAP where mahdn='{mahdn}' and trangthai != N'Xóa'", "MAHDN", "MAHDN");

                string masp = ds.Tables[0].Rows[vitri]["MASP"].ToString();
                hienThiComboBox(ds_MaSP, cboMaSP_CT, $"select * from sanpham where masp='{masp}' and trangthai != N'Xóa'", "TENSP", "MASP");

                string masize = ds.Tables[0].Rows[vitri]["MASIZE"].ToString();
                hienThiComboBox(ds_MaSize, cboMaSize_CT, $"select * from size where masize='{masize}' and trangthai != N'0'", "MASIZE", "MASIZE");
                cboTrangThai_CT.Text = ds.Tables[0].Rows[vitri]["TRANGTHAI"].ToString();
                txtSoLuong_CT.Text = ds.Tables[0].Rows[vitri]["SOLUONG"].ToString();
                txtDonGia_CT.Text = ds.Tables[0].Rows[vitri]["DONGIA"].ToString();
                txtTong_CT.Text = ds.Tables[0].Rows[vitri]["TONG"].ToString();
            }
        }

        void XuLyChucNangCT(Boolean t)
        {
            btnThemCT.Enabled = t;
            btnSuaCT.Enabled = t;
            btnXoaCT.Enabled = t;
            btnLuuCT.Enabled = !t;
            btnHuyCT.Enabled = !t;
        }

        private void dgvDanhSachCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            if (vitri >= 0 && vitri < dgvDanhSachCT.Rows.Count)
            {
                if (ds_CTHDN.Tables.Count >= 0 && e.RowIndex < dgvDanhSachCT.Rows.Count - 1)
                {
                    HienThi_TextboxCTHDN(ds_CTHDN, vitri);
                    ReadOnly_ChiTietHDN(true);
                    XuLyChucNangCT(true);
                }
            }
        }

        string flag_CT = "";
        private void btnThemCT_Click(object sender, EventArgs e)
        {
            flag_CT = "them";
            ReadOnly_ChiTietHDN(false);
            hienThiComboBox(ds_MAHDN, cboMaHDN_CT, $"select * from HOADONNHAP where trangthai != N'Xóa'", "MAHDN", "MAHDN");
            hienThiComboBox(ds_MaSP, cboMaSP_CT, "select * from SANPHAM where trangthai != N'Xóa'", "TENSP", "MASP");
            string masp = cboMaSP_CT.SelectedValue.ToString();
            hienThiComboBox(ds_MaSize, cboMaSize_CT, $"select * from CHITIETSANPHAM where MASP ='{masp}' and TRANGTHAI !=N'Xóa'", "MASIZE", "MASIZE");
            XuLyChucNangCT(false);
        }

        private void cboMaSP_CT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag_CT.Equals("them"))
            {
                string masp = "";
                if (cboMaSP_CT.SelectedIndex == -1)
                {
                    masp = cboMaSP_CT.Text;
                }
                else
                {
                    masp = cboMaSP_CT.SelectedValue.ToString();
                }
                hienThiComboBox(ds_MaSize, cboMaSize_CT, $"select * from CHITIETSANPHAM where masp='{masp}' and TRANGTHAI !=N'Xóa'", "MASIZE", "MASIZE");
                cboMaSize_CT.SelectedIndex = -1;
            }
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (txtSoLuong_CT.Text != "")
            {
                flag_CT = "xoa";
                XuLyChucNangCT(false);
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn xóa ở danh sách hóa đơn nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            if (txtSoLuong_CT.Text != "")
            {
                XuLyChucNangCT(false);
                ReadOnly_ChiTietHDN(false);
                flag_CT = "sua";
                cboMaHDN_CT.Enabled = false;
                cboMaSize_CT.Enabled = false;
                cboMaSP_CT.Enabled = false;
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn sửa ở danh sách hóa đơn nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuyCT_Click(object sender, EventArgs e)
        {
            flag_CT = "huy";
            XuLyChucNangCT(true);
            ReadOnly_ChiTietHDN(true);
            cboMaHDN_CT.SelectedIndex = -1;
            cboMaSize_CT.SelectedIndex = -1;
            cboMaSP_CT.SelectedIndex = -1;
            txtDonGia_CT.Clear();
            txtSoLuong_CT.Clear();
            cboTrangThai_CT.SelectedIndex = -1;
        }

        private void btnLuuCT_Click(object sender, EventArgs e)
        {
            bool stop = false;
            string mahdn = "";
            if (cboMaHDN_CT.SelectedIndex == -1)
            {
                mahdn = cboMaHDN_CT.Text;
            }
            else
            {
                mahdn = cboMaHDN_CT.SelectedValue.ToString();
            }
            string masp = "";
            if (cboMaSP_CT.SelectedIndex == -1)
            {
                string tensp = cboMaSP_CT.Text;
                if (hoaDonNhap.LayDuLieu($"select masp from sanpham where tensp = N'{tensp}' and trangthai !=N'%x%'").Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(this, "Tên sản phẩm nhập không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                masp = hoaDonNhap.LayDuLieu($"select masp from sanpham where tensp = N'{tensp}' and trangthai != N'%x%'").Tables[0].Rows[0]["MASP"].ToString();
            }
            else
            {
                masp = cboMaSP_CT.SelectedValue.ToString();
            }
            string masize = cboMaSize_CT.SelectedValue.ToString();
            string dongia = txtDonGia_CT.Text.ToString();
            string soluong = txtSoLuong_CT.Text;
            string tong = txtTong_CT.Text;
            string trangthai = cboTrangThai_CT.Text;
            try
            {
                if (flag_CT.Equals("them"))//them
                {
                    if (txtDonGia_CT.Text == "" || txtSoLuong_CT.Text == "" || txtTong_CT.Text == "")
                    {
                        MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stop = true;
                        xulychucnang(false);
                    }
                    else
                    {
                        sql = $"insert chitiethdn values('{mahdn}','{masp}','{masize}','{soluong}','{dongia}', '{tong}',N'{trangthai}')";
                    }
                }
                else if (flag_CT.Equals("xoa"))//xoa
                {
                    if(hoaDonNhap.LayDuLieu($"select * from chitiethdn where mahdn='{mahdn}'").Tables[0].Rows.Count<=1)
                    {
                        MessageBox.Show(this, "Một hóa đơn nhập phải có ít nhất 1 sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stop = true;
                        xulychucnang(true);
                    }
                    else
                    {
                        sql = $"delete chitiethdn where mahdn ='{mahdn}' and MASIZE = '{masize}' and MASP = '{masp}'";
                        string maHDN = "";
                        if (cboMaHDN_CT.SelectedIndex == -1)
                        {
                            maHDN = cboMaHDN_CT.Text;
                        }
                        else
                        {
                            maHDN = cboMaHDN_CT.SelectedValue.ToString();
                        }
                        ReadOnly(true);
                        danhsach_datagridview(ref ds_CTHDN, dgvDanhSachCT, $"select * from chitiethdn where mahdn = '{maHDN}' and TRANGTHAI !=N'Xóa'");
                    }
                }
                else if (flag_CT.Equals("sua"))
                {
                    if (txtDonGia_CT.Text == "" || txtSoLuong_CT.Text == "" || txtTong_CT.Text =="")
                    {
                        MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stop = true;
                        xulychucnang(false);
                    }
                    else
                    {
                        sql = $"update chitiethdn set soluong ='{soluong}', dongia= '{dongia}', tong='{tong}', TRANGTHAI=N'{trangthai}' where mahdn = '{mahdn}' and MASIZE = '{masize}' and MASP = '{masp}'";
                    }
                }

                if (stop == false)
                {
                    if (hoaDonNhap.capnhatdulieu(sql) > 0)
                    {
                        string CapNhatThanhTien = $"update HOADONNHAP set THANHTIEN=(select sum(tong) from CHITIETHDN where MAHDN ='{mahdn}') where MAHDN ='{mahdn}'";
                        hoaDonNhap.capnhatdulieu(CapNhatThanhTien);
                        MessageBox.Show("Cập nhật thành công!");
                        frmHoaDonNhap_Load(sender, e);
                        danhsach_datagridview(ref ds_CTHDN, dgvDanhSachCT, $"select * from chitiethdn where mahdn = '{mahdn}' and TRANGTHAI !=N'Xóa'");
                        ReadOnly_ChiTietHDN(true);
                        XuLyChucNangCT(true);
                    }
                    else
                    {
                        MessageBox.Show(this, "Dữ liệu bạn nhập không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XuLyChucNangCT(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Chi tiết đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XuLyChucNangCT(false);
                danhsach_datagridview(ref ds_CTHDN, dgvDanhSachCT, $"select * from chitiethdn where mahdn = '{mahdn}' and TRANGTHAI !=N'Xóa'");
            }
        }

        private void txtDonGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDonGia_CT.Text != "" && txtSoLuong_CT.Text != "")
                {
                    txtTong_CT.Text = (Convert.ToDouble(txtDonGia_CT.Text) * Convert.ToDouble(txtSoLuong_CT.Text)).ToString();
                }
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và dấu chấm thập phân
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar) && (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar)) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và dấu chấm thập phân
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar) && (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar)) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGia_CT.Text == "")
            {
                txtTong_CT.Text = "";
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong_CT.Text == "")
            {
                txtTong_CT.Text = "";
            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDonGia_CT.Text != "" && txtSoLuong_CT.Text != "")
                {
                    txtTong_CT.Text = (Convert.ToDouble(txtDonGia_CT.Text) * Convert.ToDouble(txtSoLuong_CT.Text)).ToString();
                }
            }
        }

        private void cboTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            if(hoaDonNhap.LayDuLieu($"select * from chitiethdn where MAHDN='{MAHDN_them}'").Tables[0].Rows.Count == 0 && ThemHDN.Equals("ThemHDN Thanh cong"))
            {
                MessageBox.Show($"Hóa đơn {MAHDN_them} chưa có sản phẩm nào, Bạn hãy nhập sản phẩm cho hóa đơn này!");
            }
            else
            {
                gboChucNangHDN.Visible = false;
                gboThongTin.Visible = true;
                btnTim.Visible = true;
                gboChucNangHDN.Visible = true;
                gboThongTinCTHDN.Visible = false;
                btnTruyCap_CT.Visible = true;
            }
        }

        private void frmHoaDonNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ThemHDN.Equals("ThemHDN Thanh cong"))
            {
                if (hoaDonNhap.LayDuLieu($"select * from chitiethdn where MAHDN='{MAHDN_them}'").Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show($"Hóa đơn {MAHDN_them} chưa có sản phẩm nào, Bạn hãy nhập sản phẩm cho hóa đơn này!");
                    e.Cancel = true;
                }
            }
        }

        private void btnTruyCap_CT_Click(object sender, EventArgs e)
        {
            gboThongTin.Visible = false;
            btnTim.Visible = false;
            gboChucNangHDN.Visible = false;
            gboThongTinCTHDN.Visible = true;
            ReadOnly_ChiTietHDN(true);
            XuLyChucNangCT(true);
            cboMaHDN_CT.Text = MAHDN_them;
            cboMaHDN_CT.Enabled = false;
            btnTruyCap_CT.Visible = false;
            cboMaSize_CT.SelectedIndex = -1;
            cboMaSP_CT.SelectedIndex = -1;
            clearCTHDN();
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(Load_dgv)
            {
                if(e.RowIndex >=0 && e.RowIndex < dgvDanhSach.Rows.Count)
                {
                    string mahdn = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string trangthai = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                    if(hoaDonNhap.capnhatdulieu($"update hoadonnhap set trangthai = N'{trangthai}' where mahdn ='{mahdn}'") > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        frmHoaDonNhap_Load(sender, e);
                        danhsach_datagridview(ref ds_CTHDN, dgvDanhSachCT, $"select * from chitiethdn where mahdn = '{mahdn}' and TRANGTHAI !=N'Xóa'");
                    }
                }
            }
        }

        private void cboMaHDN_CT_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(flag_CT=="them")
                {
                    if(cboMaHDN_CT.SelectedIndex == -1)
                    {
                        string mahdn = cboMaHDN_CT.Text;
                        if (hoaDonNhap.LayDuLieu($"select mahdn from hoadonnhap where mahdn ='{mahdn}' and trangthai != N'%x%'").Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show(this, "Hóa đơn bạn nhập không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void cboMaSP_CT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (flag_CT == "them")
                {
                    string masp = "";
                    if (cboMaSP_CT.SelectedIndex == -1)
                    {
                        string tensp = cboMaSP_CT.Text;
                        if (hoaDonNhap.LayDuLieu($"select masp from sanpham where tensp = N'{tensp}' and trangthai != N'%x%'").Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show(this, "Tên sản phẩm nhập không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            masp = hoaDonNhap.LayDuLieu($"select masp from sanpham where tensp = N'{tensp}' and trangthai !=N'%x%'").Tables[0].Rows[0]["MASP"].ToString();
                        }
                    }
                    else
                    {
                        masp = cboMaSP_CT.SelectedValue.ToString();
                    }
                    hienThiComboBox(ds_MaSize, cboMaSize_CT, $"select MASIZE from CHITIETSANPHAM where masp='{masp}' and TRANGTHAI !=N'Xóa'", "MASIZE", "MASIZE");
                }
            }
        }

        private void cboMaNCC_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(cboMaNCC.SelectedIndex == -1)
                {
                    string tenncc =cboMaNCC.Text;
                    if(hoaDonNhap.LayDuLieu($"select MANCC from nhacc where TENNCC = N'{tenncc}'").Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(this, "Tên nhà cung cấp nhập không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        mancc = hoaDonNhap.LayDuLieu($"select MANCC from nhacc where TENNCC = N'{tenncc}'").Tables[0].Rows[0]["MANCC"].ToString();
                    }
                }
            }
        }

        private void cboMaNVL_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(cboMaNVL.SelectedIndex == -1)
                {
                    string tennv= cboMaNVL.Text;
                    if (hoaDonNhap.LayDuLieu($"select MANV from nhanvien where tennv=N'{tennv}'").Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(this, "Tên Nhân viên nhập không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        manv = hoaDonNhap.LayDuLieu($"select MANV from nhanvien where tennv = N'{tennv}'").Tables[0].Rows[0]["MANV"].ToString();
                    }
                }
            }
        }

        private void cboTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvDanhSachCT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(load_dgv)
            {
                if(e.RowIndex >= 0 && e.RowIndex < dgvDanhSachCT.Rows.Count)
                {
                    string mahdn = dgvDanhSachCT.CurrentRow.Cells[0].Value.ToString();
                    string masp = dgvDanhSachCT.CurrentRow.Cells[1].Value.ToString();
                    string masize = dgvDanhSachCT.CurrentRow.Cells[2].Value.ToString();
                    string trangthai = dgvDanhSachCT.CurrentRow.Cells[6].Value.ToString();
                    if(hoaDonNhap.capnhatdulieu($"update chitiethdn set trangthai =N'{trangthai}' where mahdn ='{mahdn}' and masp ='{masp}' and masize = '{masize}'") > 0)
                    {
                        MessageBox.Show(this, "Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
