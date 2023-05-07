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
        void danhsach_datagridview(ref DataSet ds,DataGridView dgv, string sql)
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
            txtSoLuong.ReadOnly = t;
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

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(ref dataset, dgvDanhSach, "select * from HOADONNHAP where trangthai != N'Xóa'");
            ReadOnly(true);
            Load_dgv = true;
            ds_CTHDN = hoaDonNhap.LayDuLieu("select * from CHITIETHDN where trangthai != N'Xóa'");
            HienThi_Textbox(dataset, vitri);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (vitri >= 0 && vitri < dgvDanhSach.Rows.Count)
            {
                if (dataset.Tables.Count > 0)
                {
                    vitri = e.RowIndex;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            ReadOnly(false);
            clearTextBox(true);
            txtMaHDN.Text = phatsinhMa().ToString();
            txtMaHDN.ReadOnly = true;
            HienThiTimKiem(gboThongTin, gboTimKiem, false);
            hienThiComboBox(dsMaNV, cboMaNVL, "SELECT * FROM NHANVIEN", "TENNV", "MANV");
            cboMaNVL.SelectedIndex = -1;
            hienThiComboBox(dsNhaCungCap, cboMaNCC, "SELECT * FROM NHACC", "TENNCC", "MANCC");
            cboMaNCC.SelectedIndex = -1;
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
                flag = 3;
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn sửa ở danh sách hóa đơn nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            string NgayTruocThang = dtpNgaylap.Text;
            DateTime date = DateTime.ParseExact(NgayTruocThang, "dd/MM/yy", CultureInfo.InvariantCulture);
            string ThangTruocNgay = date.ToString("MM/dd/yy", CultureInfo.InvariantCulture);
            bool stop = false;
            if (flag == 1)//them
            {
                if (txtMaHDN.Text == "" || cboTrangThai.SelectedIndex == -1 || txtThanhTien.Text == "" || cboMaNCC.SelectedIndex == -1 || cboMaNVL.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else
                {
                    sql = $"insert hoadonnhap values('{txtMaHDN.Text}', '{cboMaNVL.SelectedValue}', '{cboMaNCC.SelectedValue}', '{ThangTruocNgay}', {txtThanhTien.Text},N'{cboTrangThai.Text}')";
                }
            }
            else if (flag == 2)//xoa
            {
                sql = $"update HOADONNHAP set TRANGTHAI=N'Xóa' where MAHDN = '{txtMaHDN.Text}'";
            }
            else if (flag == 3)//sua
            {
                if (txtMaHDN.Text == "" || cboTrangThai.SelectedIndex == -1 || txtThanhTien.Text == "" || cboMaNCC.SelectedIndex == -1 || cboMaNVL.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else
                {
                    sql = $"update HOADONNHAP set MANV_LAP ='{cboMaNCC.SelectedValue}', MANCC='{cboMaNCC.SelectedValue}', NGAYLAP='{ThangTruocNgay}',THANHTIEN ={txtThanhTien.Text}, TRANGTHAI=N'{cboTrangThai.Text}' where MAHDN='{txtMaHDN.Text}'";
                }
            }
            if (stop == false)
            {
                if (hoaDonNhap.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    frmHoaDonNhap_Load(sender, e);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            ReadOnly(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string phatsinhMa()
        {
            string maPhatSinh = "";
            DataSet dsban = hoaDonNhap.LayDuLieu("Select mahdn from hoadonnhap");
            maPhatSinh = "HDN" + (dsban.Tables[0].Rows.Count + 1).ToString();
            return maPhatSinh;
        }

        //private void btnHienTimCT_Click(object sender, EventArgs e)
        //{
        //    xulychucnang(true);
        //    cboTim.SelectedIndex = 0;
        //    if (gboThongTinCTHDN.Visible == true)
        //    {
        //        btnHienTimCT.Text = "Hiện Hộp thông tin";
        //        HienThiTimKiem(gboThongTinCTHDN, gboTimKiemCT, true);
        //    }
        //    else
        //    {
        //        btnHienTimCT.Text = "Tìm thông tin khuyến mãi";
        //        HienThiTimKiem(gboThongTinCTHDN, gboTimKiemCT, false);
        //    }
        //}

        void HienThiTimKiem(GroupBox thongtin, GroupBox Tim, Boolean t)
        {
            thongtin.Visible = !t;
            Tim.Visible = t;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            cboTim.SelectedIndex = 0;
            if(gboThongTin.Visible == true)
            {
                btnTim.Text = "Hiện Hộp thông tin";
                HienThiTimKiem(gboThongTin,gboTimKiem,true);
            }
            else
            {
                btnTim.Text = "Tìm thông tin khuyến mãi";
                HienThiTimKiem(gboThongTin, gboTimKiem, false);
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
                danhsach_datagridview(ref dataset, dgvDanhSach, $"select * from hoadonnhap where mahdn like N'%{txtTim.Text}%' and trangthai != N'Xóa'");
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar) && (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))|| char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void HienThi_TextboxCTHDN(DataSet ds, int vitri)
        {
            if (vitri > -1 && vitri < ds.Tables[0].Rows.Count)
            {
                string mahdn = ds.Tables[0].Rows[vitri]["MAHDN"].ToString();
                hienThiComboBox(ds_MAHDN, cboMaHDN_CT, $"select * from chitiethdn where mahdn='{mahdn}'", "MAHDN", "MAHDN");

                string masp = ds.Tables[0].Rows[vitri]["MASP"].ToString();
                hienThiComboBox(ds_MaSP, cboMaSP_CT, $"select * from sanpham where masp='{masp}'", "TENSP", "MASP");

                string masize = ds.Tables[0].Rows[vitri]["MASIZE"].ToString();
                hienThiComboBox(ds_MaSize, cboMaSize_CT, $"select * from size where masize='{masize}'", "MASIZE", "MASIZE");
                cboTrangThai_CT.Text = ds.Tables[0].Rows[vitri]["TRANGTHAI"].ToString();
                txtSoLuong.Text = ds.Tables[0].Rows[vitri]["SOLUONG"].ToString();
                txtDonGia.Text = ds.Tables[0].Rows[vitri]["DONGIA"].ToString();
            }
        }
        private void dgvDanhSachCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (vitri >= 0 && vitri < dgvDanhSachCT.Rows.Count - 1)
            {
                if (ds_CTHDN.Tables.Count >= 0 && e.RowIndex < dgvDanhSachCT.Rows.Count - 1)
                {
                    vitri = e.RowIndex;
                    HienThi_TextboxCTHDN(ds_CTHDN, vitri);
                    ////ReadOnly_ChiTietKM(true);
                    ////XuLyChucNangCT(true);
                }
            }
        }
    }
}
