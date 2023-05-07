using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmBan : Form
    {
        public frmBan()
        {
            InitializeComponent();
        }

        int flag = 0;
        string sql = "";
        DataSet dataset = new DataSet();
        int vitri = 0;//tu 0 den n-1
        clsquanlycaphe ban = new clsquanlycaphe();// ket noi vao database

        //ham ket noi
        void danhsach_datagridview(DataGridView dgv, string sql)
        {
            dataset = ban.LayDuLieu(sql);
            dgv.DataSource = dataset.Tables[0]; 
            //do 
        }

        Boolean Load_dgv = false;
        private void Ban_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvDanhSach, "select MABAN,TENBAN, case when TRANGTHAI=N'TRONG' then N'Trống'\tELSE N'Đang sử dụng' end as 'TRANGTHAI' from BAN where TRANGTHAI !='XOA'");
            HienThi_Textbox(dataset, vitri);
            Load_dgv = true;
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
            txtMaBan.ReadOnly = false;
            txtTenBan.ReadOnly = false;
            cboTrangThai.Enabled = true;
            txtMaBan.Text = phatSinhMa_1();
            txtMaBan.ReadOnly = true;
            txtTenBan.Text = "";
            cboTrangThai.SelectedIndex = 0;
            cboTrangThai.Enabled = true;
            flag = 1;
        }

        void xulychucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            flag = 3;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            txtMaBan.ReadOnly = false;
            txtTenBan.ReadOnly = false;
            cboTrangThai.Enabled=true;
            flag = 2;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            string trangthai = "";
            if (cboTrangThai.Text.Equals("Trống"))
                trangthai = "TRONG";
            else
                trangthai = "HOATDONG";
            if (flag == 1)
            {
                sql = $"insert into BAN values ('{Convert.ToInt32(txtMaBan.Text)}', N'{txtTenBan.Text}', '{trangthai}')";
            }
            if (flag == 2)
            {
                sql = $"update ban set tenban=N'{txtTenBan.Text}', trangthai = {cboTrangThai.SelectedIndex} where maban='{txtMaBan.Text}'";//C# có phân biệt số và chữ nên SỐ KHÔNG ĐỂ TRONG DÂU NHẤY
            }
            if (flag == 3)
            {
                sql = $"update ban set trangthai = 'XOA'  where maban='{txtMaBan.Text}'";
            }
            if (ban.capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("Cap nhat thanh cong!");
                Ban_Load(sender, e);
            }
        }

        void HienThi_Textbox(DataSet ds, int vitri)
        {
            if( vitri > -1 && vitri < dataset.Tables[0].Rows.Count) 
            {
                txtMaBan.Text = ds.Tables[0].Rows[vitri]["MABAN"].ToString();
                txtTenBan.Text = ds.Tables[0].Rows[vitri]["TENBAN"].ToString();
                if(String.Equals(ds.Tables[0].Rows[vitri]["TRANGTHAI"],"TRONG"))
                    cboTrangThai.SelectedIndex = 0;
                else
                    cboTrangThai.SelectedIndex= 1;
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


    
        //string phatsinhMa()
        //{
        //    string maban = "";
        //    maban ="B" + (dataset.Tables[0].Rows.Count+1).ToString();

        //    return maban;
        //}

        string phatSinhMa_1()
        {
            string maban = "";
            DataSet dsban = ban.LayDuLieu("Select maban from ban");
            maban =(dsban.Tables[0].Rows.Count + 1).ToString();
            if(Convert.ToInt32(maban) > 0 && Convert.ToInt32(maban)<10)
            {
                maban = "0" + maban;
            }
            return maban;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {   
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            HienThiTimKiem(false);
        }

        private void txtTenBan_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))//IsPUNctuation là kiếm tra có phải dấu câu, IsSymbol dùng để kiểm tra ký tự toán học, ký tự đặc biệt dựa trên bảng mã Unicode.
            {
                e.Handled = true;
            }
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Load_dgv)
            {
                if (e.ColumnIndex > 0)
                {
                    int vitri = dgvDanhSach.CurrentRow.Index;
                    string maban = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenban = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    sql = $"update ban set tenban=N'{tenban}'where maban='{maban}'";
                    if (ban.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cap nhat thanh cong!");
                        vitri = 0;   
                        Ban_Load(sender, e);
                    }
                }
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimTT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                MessageBox.Show(this, "Bạn phải điền thông tin thì tôi mới tìm được chứ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboTim.SelectedIndex == 0)
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from Ban where tenban=N'{txtTim.Text}'");
            }
            else
            {
                danhsach_datagridview(dgvDanhSach, $"Select * from ban where maban='{txtTim.Text}'");
            }
        }

        private void btnHienDS_Click(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvDanhSach, "select MABAN,TENBAN, case when TRANGTHAI=N'TRONG' then N'Trống'\tELSE N'Đang sử dụng' end as 'TRANGTHAI' from BAN where TRANGTHAI !='XOA'");
        }
    }
}
