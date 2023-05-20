using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmLoaiSP : Form
    {
        public frmLoaiSP()
        {
            InitializeComponent();
        }
        string flag = "";
        string sql = "";
        DataSet dataset = new DataSet();
        int vitri = 0;//tu 0 den n-1
        clsquanlycaphe loaiSP = new clsquanlycaphe();// ket noi vao database

        //ham ket noi
        void danhsach_datagridview(DataGridView dgv, string sql)
        {
            dataset = loaiSP.LayDuLieu(sql);
            dgv.DataSource = dataset.Tables[0];
            //do 
        }
        Boolean Load_dgv = false;

        private void frmLoaiSP_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvDanhSach, "select * from LOAISP where trangthai !='%x%'");
            HienThi_Textbox(dataset, vitri);
            xulychucnang(true);
            Load_dgv = true;
        }
        void HienThi_Textbox(DataSet ds, int vitri)
        {
            if (vitri > -1 && vitri < dataset.Tables[0].Rows.Count)
            {
                txtMaLSP.Text = ds.Tables[0].Rows[vitri]["MAloaiSP"].ToString();
                txtTenLSP.Text = ds.Tables[0].Rows[vitri]["TENloaiSP"].ToString();
                cboTrangThai.Text = ds.Tables[0].Rows[vitri]["TRANGTHAI"].ToString();
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            HienThi_Textbox(dataset, vitri);
        }
        void HienThiTimKiem(GroupBox thongtin, GroupBox Tim, Boolean t)
        {
            thongtin.Visible = !t;
            Tim.Visible = t;
        }

        void xulychucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnHuy.Enabled = !t;
            btnLuu.Enabled = !t;
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
            cboTim.SelectedIndex = 0;
        }
        private void btnHienDS_Click(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvDanhSach, "select * from LOAISP where trangthai not like N'%X%'");
        }

        string phatSinhMa()
        {
            string maloaisp = "";
            DataSet dsloaiSP = loaiSP.LayDuLieu("Select maloaiSP from loaiSP");
            maloaisp = (dsloaiSP.Tables[0].Rows.Count + 1).ToString();
            if (Convert.ToInt32(maloaisp) > 0 && Convert.ToInt32(maloaisp) < 10)
            {
                maloaisp = "LSP" + maloaisp;
            }
            return maloaisp;
        }

        void HienThiTimKiem(Boolean t)
        {
            gboThongTin.Visible = !t;
            gboTimKiem.Visible = t;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            HienThiTimKiem(false);
            txtMaLSP.Text = phatSinhMa();
            txtTenLSP.ReadOnly = false;
            txtTenLSP.Text = "";
            cboTrangThai.Enabled = true;
            cboTrangThai.SelectedIndex = 0;
            flag = "them";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            txtTenLSP.ReadOnly=true;
            cboTrangThai.Enabled = false;
            HienThiTimKiem(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            if (flag == "them")
            {
                sql = $"insert into LOAISP values ('{txtMaLSP.Text}', N'{txtTenLSP.Text}', N'{cboTrangThai.Text}')";
            }
            if (flag == "sua")
            {
                sql = $"update LOAISP set tenloaisp=N'{txtTenLSP.Text}', trangthai = N'{cboTrangThai.Text}' where maloaisp='{txtMaLSP.Text}'";//C# có phân biệt số và chữ nên SỐ KHÔNG ĐỂ TRONG DÂU NHẤY
            }
            if (flag == "xoa")
            {
                sql = $"update loaisp set trangthai = N'Xóa'  where maloaisp='{txtMaLSP.Text}'";
            }
            if (loaiSP.capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("Cập nhật thành công!");
                frmLoaiSP_Load(sender, e);
            }
            txtMaLSP.ReadOnly=true;
            cboTrangThai.Enabled=false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLSP.Text == "")
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                xulychucnang(false);
                flag = "xoa";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLSP.Text == "")
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                xulychucnang(false);
                txtTenLSP.ReadOnly = false;
                cboTrangThai.Enabled = true;
                flag = "sua";
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
                danhsach_datagridview(dgvDanhSach, $"Select * from loaisp where tenloaisp=N'{txtTim.Text}'");
            }
            else
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from loaisp where maloaisp='{txtTim.Text}'");
            }
        }

        private void cboTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
