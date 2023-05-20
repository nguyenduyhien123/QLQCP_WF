using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        clsquanlycaphe khachhang = new clsquanlycaphe();

        int vitri = 0;
        string flag = "";
        string sql = "";
        DataSet ds = new DataSet();

        void xulychucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
            btnHuy.Enabled = !t;
        }

        string phatsinhma()
        {
            string makh = "";
            DataSet dsmakh = khachhang.LayDuLieu("select makh from khachhang");
            makh = ("KH" + (dsmakh.Tables[0].Rows.Count + 1)).ToString();
            return makh;
        }

        void Clear()
        {
            txtTenKH.Clear();
            txtSDT.Clear();
            txtMaKhachHang.Clear();
            txtDiaChi.Clear();
            cboTrangThai.Text = "";
        }
        void danhsach_datagridview(DataGridView dgv, string sql)
        {
            ds = khachhang.LayDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = "them";
            Clear();
            txtMaKhachHang.Text = phatsinhma();
            xulychucnang(false);
            ReadOnly(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = "sua";
            xulychucnang(false);
            ReadOnly(false);
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            //Đổi kiểu dữ liệu ngày từ dd/mm/yy thành mm/dd/yyyy do datetime cua sql la mm/dd/yyyy
            string ngaySinh1 = dtpNgaySinh.Text;
            DateTime dateNS = DateTime.ParseExact(ngaySinh1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string ngaySinh2 = dateNS.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            string MAKH = txtMaKhachHang.Text;
            string TENKN = txtTenKH.Text;
            string DIACHI = txtDiaChi.Text;
            string SDT = txtSDT.Text;
            string TRANGTHAI = cboTrangThai.Text;
            bool stop = false;
            if (flag == "them")
            {
                if (txtSDT.Text == "" || txtMaKhachHang.Text == "" || txtDiaChi.Text == "" || txtTenKH.Text == "" || cboTrangThai.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else
                {
                    sql = $"insert KHACHHANG values ('{MAKH}',N'{TENKN}',N'{DIACHI}','{SDT}','{ngaySinh2}',N'{TRANGTHAI}')";
                }
            }
            else if (flag == "xoa")
            {
                sql = $"update KHACHHANG set TRANGTHAI=N'Xóa' where MAKH = '{MAKH}'";
            }
            else if (flag == "sua")
            {
                if (txtSDT.Text == "" || txtMaKhachHang.Text == "" || txtDiaChi.Text == "" || txtTenKH.Text == "" || cboTrangThai.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    ReadOnly(false);
                }
                else
                {
                    sql = $"update KHACHHANG set TENKH = N'{TENKN}', DIACHI = N'{DIACHI}', SDT='{SDT}', NGAYSINH =N'{ngaySinh2}',TRANGTHAI=N'{TRANGTHAI}' where MAKH='{MAKH}'";
                }
            }
            if (stop == false)
            {
                if (khachhang.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmKhachHang_Load(sender, e);
                }
            }
            ReadOnly(true);
            xulychucnang(true);
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            flag = "xoa";
            xulychucnang(false);
        }

        void ReadOnly(Boolean t)
        {
            txtTenKH.ReadOnly = t;
            txtSDT.ReadOnly = t;
            txtDiaChi.ReadOnly = t;
            cboTrangThai.Enabled = !t;
            dtpNgaySinh.Enabled = !t;
        }

        void HienThiTextBox(DataSet ds, int vitri)
        {
            if (vitri >= 0 && vitri < ds.Tables[0].Rows.Count)
            {
                txtMaKhachHang.Text = ds.Tables[0].Rows[vitri]["MAKH"].ToString();
                txtTenKH.Text = ds.Tables[0].Rows[vitri]["TENKH"].ToString();
                txtDiaChi.Text = ds.Tables[0].Rows[vitri]["DIACHI"].ToString();
                txtSDT.Text = ds.Tables[0].Rows[vitri]["SDT"].ToString();
                cboTrangThai.Text = ds.Tables[0].Rows[vitri]["TRANGTHAI"].ToString();
                dtpNgaySinh.Text = ds.Tables[0].Rows[vitri]["NGAYSINH"].ToString();
            }
        }

        Boolean Load_dgv = false;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvDanhSach, "select * from khachhang where TRANGTHAI not like N'%x%'");
            HienThiTextBox(ds, vitri);
            ReadOnly(true);
            dgvDanhSach.ReadOnly = false;
            Load_dgv = true;
            DateTime d = DateTime.Now;
            dtpNgaySinh.Value = d.AddYears(-13);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            if (vitri >= 0 && vitri < dgvDanhSach.Rows.Count)
            {
                if (ds.Tables.Count > 0)
                {
                    HienThiTextBox(ds, vitri);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Clear();
            xulychucnang(true);
            ReadOnly(true);
        }
        void HienThiTimKiem(GroupBox thongtin, GroupBox Tim, Boolean t)
        {
            thongtin.Visible = !t;
            Tim.Visible = t;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
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
                btnHienDS_Click(sender, e);
            }
            xulychucnang(true);
        }

        private void btnHienDS_Click(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvDanhSach, "select * from khachhang where TRANGTHAI not like N'%x%'");
        }

        private void btnTimTT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                MessageBox.Show(this, "Bạn phải điền thông tin thì tôi mới tìm được chứ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboTim.SelectedIndex == 0)
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from khachhang where tenkh like N'%{txtTim.Text}%' and trangthai!=N'Xóa'");
            }
            else if (cboTim.SelectedIndex == 1)
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from khachhang where MAKH='{txtTim.Text}' and trangthai!=N'Xóa'");
            }
            else if (cboTim.SelectedIndex == 2)
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from khachhang where SDT='{txtTim.Text}' and trangthai!=N'Xóa'");
            }
            else if (cboTim.SelectedIndex == 3)
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from khachhang where TRANGTHAI=N'{txtTim.Text}' and trangthai!=N'Xóa'");
            }
            if (dgvDanhSach.ColumnCount == 0)
            {
                MessageBox.Show(this, "Xin lỗi, tôi không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))//IsPUNctuation là kiếm tra có phải dấu câu, IsSymbol dùng để kiểm tra ký tự toán học, ký tự đặc biệt dựa trên bảng mã Unicode.
            {
                e.Handled = true;
            }
        }

        private void cboTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
