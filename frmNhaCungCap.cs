using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }


        string sql = "";
        int flag = 0;
        int vitri = 0;
        DataSet ds = new DataSet();

        clsquanlycaphe nhacc = new clsquanlycaphe();// ket noi vao database

        //ham ket noi
        void danhsach_datagridview(DataGridView dgv, string sql)
        {
            ds = nhacc.LayDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
            //do 
        }
        
        void ReadOnly(Boolean t)
        {
            txtMaNCC.ReadOnly = t;
            txtTenNCC.ReadOnly = t;
            txtDiaChi.ReadOnly = t;
            txtMoTa.ReadOnly = t;
            txtSDT.ReadOnly = t;
            cboTrangThai.Enabled = !t;
        }
        Boolean Load_dgv = false;
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvDanhSach, "select * from nhacc where trangthai != N'Xóa'");
            ReadOnly(true);
            Load_dgv = true;
        }

        void HienThi_Textbox(DataSet ds, int vitri)
        {
            if (vitri > -1 && vitri < ds.Tables[0].Rows.Count)
            {
                txtMaNCC.Text = ds.Tables[0].Rows[vitri]["MANCC"].ToString();
                txtTenNCC.Text = ds.Tables[0].Rows[vitri]["TENNCC"].ToString();
                txtDiaChi.Text = ds.Tables[0].Rows[vitri]["DIACHI"].ToString();
                txtMoTa.Text = ds.Tables[0].Rows[vitri]["MOTA"].ToString();
                txtSDT.Text = ds.Tables[0].Rows[vitri]["SDT"].ToString();
                cboTrangThai.Text = ds.Tables[0].Rows[vitri]["TRANGTHAI"].ToString();
            }
        }

        void xulychucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
            btnHuy.Enabled = !t;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            ReadOnly(false);
            txtMaNCC.ReadOnly = true;
            txtMaNCC.Text = phatSinhMa();
            flag = 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            bool stop = false;
            if(flag == 1)
            {
                if (txtTenNCC.Text =="" || txtMoTa.Text =="" || txtSDT.Text=="" || txtMaNCC.Text =="" || cboTrangThai.SelectedIndex==-1)
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else
                {
                    sql = $"insert NHACC values('{txtMaNCC.Text}',N'{txtTenNCC.Text}','{txtSDT.Text}',N'{txtDiaChi.Text}',N'{txtMoTa.Text}',N'{cboTrangThai.Text}')";
                }
            }
            else if(flag == 2)
            {
                sql = $"update NHACC set TRANGTHAI=N'Xóa' where MANCC = '{txtMaNCC.Text}'";
            }
            else if(flag == 3)
            {
                if (txtTenNCC.Text == "" || txtMoTa.Text == "" || txtSDT.Text == "" || txtMaNCC.Text == "" || cboTrangThai.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else
                {
                    sql = $"update NHACC set TENNCC=N'{txtTenNCC.Text}',SDT='{txtSDT.Text}', DIACHI=N'{txtDiaChi.Text}', MOTA =N'{txtMoTa.Text}', TRANGTHAI=N'{cboTrangThai.Text}' where MANCC = '{txtMaNCC.Text}'";
                }
            }
            if(stop == false)
            {
                if (nhacc.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cap nhat thanh cong!");
                    frmNhaCungCap_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            if (txtTenNCC.Text != "")
            {
                xulychucnang(false);
                flag = 2;
                ReadOnly(true);
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn xoá ở danh sách nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtTenNCC.Text != "")
            {
                xulychucnang(false);
                ReadOnly(false);
                flag = 3;
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn sửa ở danh sách nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void txtMaNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (vitri >= 0 && vitri < dgvDanhSach.Rows.Count)
            {
                vitri = e.RowIndex;
                HienThi_Textbox(ds, vitri);
                ReadOnly(true);
                xulychucnang(true);
                HienThiTimKiem(false);
            }
        }

        string phatSinhMa()
        {
            string mancc = "";
            DataSet dsNhaCC = nhacc.LayDuLieu("Select mancc from nhacc");
            mancc = (dsNhaCC.Tables[0].Rows.Count + 1).ToString();
            if (Convert.ToInt32(mancc) > 0 && Convert.ToInt32(mancc) < 10)
            {
                mancc = "0" + mancc;
            }
            return mancc;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            txtDiaChi.Text = "";
            txtMaNCC.Text = "";
            txtMoTa.Text = "";
            txtSDT.Text = "";
            txtTenNCC.Text = "";
            cboTrangThai.SelectedIndex = -1;
            ReadOnly(true);
        }

        private void btnHienDS_Click(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvDanhSach, "select * from nhacc");
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {

        }
        void HienThiTimKiem(Boolean t)
        {
            gboThongTin.Visible = !t;
            gboTimKiem.Visible = t;
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
                btnHienDS_Click(sender, e);
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
                danhsach_datagridview(dgvDanhSach, $"Select * from nhacc where tenncc like N'%{txtTim.Text}%'");
            }
            else
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from nhacc where mancc='{txtTim.Text}'");
            }

            if (dgvDanhSach.Rows.Count - 1 == 0)
            {
                MessageBox.Show(this, "Không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void HienThiTimKiem(GroupBox thongtin, GroupBox Tim, Boolean t)
        {
            thongtin.Visible = !t;
            Tim.Visible = t;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtSDT.Text.Length >= 10 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtTenNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))//IsPUNctuation là kiếm tra có phải dấu câu, IsSymbol dùng để kiểm tra ký tự toán học, ký tự đặc biệt dựa trên bảng mã Unicode.
            {
                e.Handled = true;
            }
        }

        private void cboTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Load_dgv)
            {
                if (e.ColumnIndex >= 0 && e.ColumnIndex < dgvDanhSach.Rows.Count)
                {
                    int vitri = dgvDanhSach.CurrentRow.Index;
                    string mancc = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenncc = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string sdt = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string diachi = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    string mota = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    string trangthai = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                    sql = $"update nhacc set tenncc=N'{tenncc}', sdt='{sdt}',DIACHI =N'{diachi}', MOTA=N'{mota}', TRANGTHAI =N'{trangthai}' where MANCC ='{mancc}'";
                    if (nhacc.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cap nhat thanh cong!");
                        vitri = 0;
                        frmNhaCungCap_Load(sender, e);
                    }
                }
            }
        }
    }
}
