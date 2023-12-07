using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        _9_12_QuanLyQuanCaPhe nhanvien = new _9_12_QuanLyQuanCaPhe();

        int vitri = 0;
        int flag = 0;
        string sql = "";
        DataSet ds = new DataSet();
        void danhsach_datagridview(DataGridView dgv, string sql)
        {
            ds = nhanvien.LayDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }

        void ReadOnly(Boolean t)
        {
            txtMaNhanVien.ReadOnly = t;
            txtHoVaTen.ReadOnly = t;
            txtMatKhau.ReadOnly = t;
            txtDiaChi.ReadOnly = t;
            txtChucVu.ReadOnly = t;
            txtSoDienThoai.ReadOnly = t;
            cboGioiTinh.Enabled = !t;
            cboTrangThai.Enabled = !t;
            dtpNgaySinh.Enabled = !t;
            dtpNgayVaoLam.Enabled = !t;
        }

        Boolean Load_dgv = false;
        private void NhanVien_Load(object sender, EventArgs e)
        {
            VoHieuHoa(true);
            danhsach_datagridview(dgvDanhSach, "select * from NHANVIEN where TRANGTHAI not like N'%x%'");
            HienThiTextBox(ds, vitri);
            ReadOnly(true);
            dgvDanhSach.ReadOnly = false;
            Load_dgv = true;
            DateTime d = DateTime.Now;
            dtpNgaySinh.Value = d.AddYears(-18);
        }

        private void VoHieuHoa(bool flag = false)
        {
            btnThem.Enabled = flag;
            btnXoa.Enabled = flag;
            btnHuy.Enabled = !flag;
            btnSua.Enabled = flag;
            btnLuu.Enabled = !flag;
        }

        void clearTextbox()
        {
            txtMaNhanVien.Clear();
            txtHoVaTen.Clear();
            txtDiaChi.Clear();
            txtChucVu.Clear();
            txtSoDienThoai.Clear();
            cboGioiTinh.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            VoHieuHoa(false);
            clearTextbox();
            ReadOnly(false);
            btnAnMK.Enabled = true;
            txtMaNhanVien.ReadOnly = true;
            txtMaNhanVien.Text = phatsinhma();
            DateTime d = DateTime.Now;
            dtpNgaySinh.Value = d.AddYears(-18);
            dtpNgayVaoLam.Text = DateTime.Today.ToString();
            flag = 1;
        }

        string ComputeSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            VoHieuHoa(true);
            //Đổi kiểu dữ liệu ngày từ dd/mm/yy thành mm/dd/yyyy do datetime cua sql la mm/dd/yyyy
            string ngaySinh1 = dtpNgaySinh.Text;
            DateTime dateNS = DateTime.ParseExact(ngaySinh1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string ngaySinh2 = dateNS.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            string ngayVaoLam1 = dtpNgayVaoLam.Text;
            DateTime dateNVL = DateTime.ParseExact(ngayVaoLam1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string ngayVaoLam2 = dateNVL.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            string matkhau = ComputeSHA256(txtMatKhau.Text);

            bool stop = false;
            if (txtSoDienThoai.TextLength != 10)
            {
                MessageBox.Show(this, "Số điện thoại phải đủ 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VoHieuHoa(false);
            }
            else
            {
                if (flag == 1)
                {
                    if (txtSoDienThoai.Text == "" || txtMaNhanVien.Text == "" || txtHoVaTen.Text == "" || txtDiaChi.Text == "" || cboTrangThai.SelectedIndex == -1 || txtDiaChi.Text == "" || txtChucVu.Text == "" || txtMatKhau.Text == "")
                    {
                        MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stop = true;
                        VoHieuHoa(false);
                    }
                    else
                    {
                        sql = $"insert nhanvien values('{txtMaNhanVien.Text}',N'{txtHoVaTen.Text}',N'{txtDiaChi.Text}','{txtSoDienThoai.Text}',N'{txtChucVu.Text}','{ngayVaoLam2}',N'{cboGioiTinh.Text}','{ngaySinh2}',N'{cboTrangThai.Text}','{matkhau}')";
                    }
                }
                else if (flag == 2)
                {
                    sql = $"update nhanvien set TRANGTHAI=N'Xóa' where manv = '{txtMaNhanVien.Text}'";
                }
                else if (flag == 3)
                {
                    if (txtSoDienThoai.Text == "" || txtMaNhanVien.Text == "" || txtHoVaTen.Text == "" || txtDiaChi.Text == "" || cboTrangThai.SelectedIndex == -1 || txtDiaChi.Text == "" || txtChucVu.Text == "")
                    {
                        MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stop = true;
                        VoHieuHoa(false);
                    }
                    else
                    {
                        sql = $"update NHANVIEN set TENNV = N'{txtHoVaTen.Text}', DIACHI = N'{txtDiaChi.Text}', SDT='{txtSoDienThoai.Text}', CHUCVU =N'{txtChucVu.Text}', NGAYVAOLAM = '{ngayVaoLam2}', GIOITINH = N'{cboGioiTinh.Text}', NGAYSINH =N'{ngaySinh2}',TRANGTHAI=N'{cboTrangThai.Text}' where MANV='{txtMaNhanVien.Text}'";
                    }
                }
                if (stop == false)
                {
                    if (nhanvien.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            NhanVien_Load(sender, e);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtHoVaTen.Text != "")
            {
                VoHieuHoa(false);
                flag = 2;
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn xoá ở danh sách nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtHoVaTen.Text != "")
            {
                VoHieuHoa(false);
                ReadOnly(false);
                btnAnMK.Enabled = true;
                txtMaNhanVien.ReadOnly = true;
                flag = 3;
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn sửa ở danh sách nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            VoHieuHoa(true);
            ReadOnly(true);
            btnAnMK.Enabled = false;
            txtHoVaTen.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtChucVu.Text = string.Empty;
            txtMaNhanVien.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;
            cboGioiTinh.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void HienThiTextBox(DataSet ds, int vitri)
        {
            if (vitri >= 0 && vitri < ds.Tables[0].Rows.Count)
            {
                txtMaNhanVien.Text = ds.Tables[0].Rows[vitri]["MANV"].ToString();
                txtHoVaTen.Text = ds.Tables[0].Rows[vitri]["TENNV"].ToString();
                txtDiaChi.Text = ds.Tables[0].Rows[vitri]["DIACHI"].ToString();
                txtSoDienThoai.Text = ds.Tables[0].Rows[vitri]["SDT"].ToString();
                cboGioiTinh.Text = ds.Tables[0].Rows[vitri]["GIOITINH"].ToString();
                txtChucVu.Text = ds.Tables[0].Rows[vitri]["CHUCVU"].ToString();
                cboTrangThai.Text = ds.Tables[0].Rows[vitri]["TRANGTHAI"].ToString();
                dtpNgaySinh.Text = ds.Tables[0].Rows[vitri]["NGAYSINH"].ToString();
                dtpNgayVaoLam.Text = ds.Tables[0].Rows[vitri]["NGAYVAOLAM"].ToString();

            }
        }

        void HienThiTimKiem(GroupBox thongtin, GroupBox Tim, Boolean t)
        {
            thongtin.Visible = !t;
            Tim.Visible = t;
        }
        private void btnHienTim_Click(object sender, EventArgs e)
        {
            cboTim.SelectedIndex = 0;
            if (gboThongTin.Visible == true)
            {
                btnHienTim.Text = "Hiện Hộp thông tin";
                HienThiTimKiem(gboThongTin, gboTimKiem, true);
            }
            else
            {
                btnHienTim.Text = "Tìm thông tin khuyến mãi";
                HienThiTimKiem(gboThongTin, gboTimKiem, false);
                btnHienDS_Click(sender, e);
            }
            VoHieuHoa(true);
        }

        string phatsinhma()
        {
            string manv = "";
            DataSet dsnhanvien = nhanvien.LayDuLieu("select manv from nhanvien");
            manv = ("NV" + (dsnhanvien.Tables[0].Rows.Count + 1)).ToString();
            return manv;
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            if (vitri >= 0 && vitri < dgvDanhSach.Rows.Count - 1)
            {
                if (ds.Tables.Count > 0)
                {
                    ReadOnly(true);
                    VoHieuHoa(true);
                    HienThiTextBox(ds, vitri);
                }
            }
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Load_dgv)
            {
                if (e.ColumnIndex > 0)
                {
                    int vitri = dgvDanhSach.CurrentRow.Index;
                    string MANV = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string TENNV = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string SDT = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string DIACHI = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();

                    string NGAYVAOLAM = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    DateTime dateNVL = DateTime.ParseExact(NGAYVAOLAM, "dd/MM/yy", CultureInfo.InvariantCulture);
                    string ngayVaoLam = dateNVL.ToString("MM/dd/yy", CultureInfo.InvariantCulture);

                    string NGAYSINH = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                    DateTime dateNS = DateTime.ParseExact(NGAYSINH, "dd/MM/yy", CultureInfo.InvariantCulture);
                    string ngaySinh = dateNS.ToString("MM/dd/yy", CultureInfo.InvariantCulture);

                    string CHUCVU = dgvDanhSach.CurrentRow.Cells[6].Value.ToString();
                    string GIOITINH = dgvDanhSach.CurrentRow.Cells[7].Value.ToString();
                    string TRANGTHAI = dgvDanhSach.CurrentRow.Cells[8].Value.ToString();
                    sql = $"update NHANVIEN set TENNV = N'{TENNV}', DIACHI = N'{DIACHI}', SDT='{SDT}', CHUCVU =N'{CHUCVU}', NGAYVAOLAM = '{ngayVaoLam}', GIOITINH = N'{GIOITINH}', NGAYSINH =N'{ngaySinh}',TRANGTHAI=N'{TRANGTHAI}' where MANV='{MANV}'";
                    if (nhanvien.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        vitri = 0;
                        NhanVien_Load(sender, e);
                    }
                }
            }
        }

        private void btnHienDS_Click(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvDanhSach, "select * from NHANVIEN");
        }

        private void btnTimTT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                MessageBox.Show(this, "Bạn phải điền thông tin thì tôi mới tìm được chứ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboTim.SelectedIndex == 0)
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from nhanvien where tennv like N'%{txtTim.Text}%' and trangthai!=N'Xóa'");
            }
            else if (cboTim.SelectedIndex == 1)
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from NHANVIEN where MANV='{txtTim.Text}' and trangthai!=N'Xóa'");
            }
            else if (cboTim.SelectedIndex == 2)
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from NHANVIEN where SDT='{txtTim.Text}' and trangthai!=N'Xóa'");
            }
            else if (cboTim.SelectedIndex == 3)
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from NHANVIEN where CHUCVU like N'%{txtTim.Text}%' and trangthai!=N'Xóa'");
            }
            else if (cboTim.SelectedIndex == 4)
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from NHANVIEN where TRANGTHAI=N'{txtTim.Text}' and trangthai!=N'Xóa'");
            }
            if (dgvDanhSach.ColumnCount == 0)
            {
                MessageBox.Show(this, "Xin lỗi, tôi không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtHoVaTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtSoDienThoai.Text.Length >= 10 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtChucVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            string NGAYSINH = dtpNgaySinh.Text;
            DateTime dateNS = DateTime.ParseExact(NGAYSINH, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int nam = dateNS.Year;
            DateTime d = DateTime.Now;
            int namHienTai = d.Year;
            if (namHienTai - nam < 18)
            {
                MessageBox.Show(this, "Nhân viên phải trên 18 tuổi, vui lòng nhập đúng năm sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgaySinh.Value = d.AddYears(-18);
                dtpNgayVaoLam.Text = DateTime.Today.ToString();
            }
        }

        private void cboGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        bool HienThiMatKhau = true;
        private void btnAnMK_Click(object sender, EventArgs e)
        {
            if (HienThiMatKhau == false)
            {
                btnAnMK.Text = "Hiện";
                txtMatKhau.UseSystemPasswordChar = true;
                HienThiMatKhau = true;
            }
            else
            {
                btnAnMK.Text = "Ẩn";
                txtMatKhau.UseSystemPasswordChar = false;
                HienThiMatKhau = false;
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void cboTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show($"Bạn có chắc muốn Đóng form Nhân viên ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgThoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
