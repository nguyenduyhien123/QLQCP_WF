using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmSize : Form
    {
        public frmSize()
        {
            InitializeComponent();
        }

        DataSet dataset = new DataSet();
        int vitri = 0;//tu 0 den n-1
        int flag = 0;
        clsquanlycaphe size = new clsquanlycaphe();// ket noi vao database

        //ham ket noi
        void danhsach_datagridview(DataGridView dgv, string sql)
        {
            dataset = size.LayDuLieu(sql);
            dgv.DataSource = dataset.Tables[0];
            //do 
        }

        void ReadOnly(Boolean t)
        {
            txtMaSize.ReadOnly = t; 
            txtMoTa.ReadOnly = t;
            cboTrangThai.Enabled = !t;
        }

        void xulychucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }

        void Clear()
        {
            txtMaSize.Text = "";
            txtMoTa.Text = "";
            cboTrangThai.SelectedIndex = -1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            ReadOnly(false);
            Clear();
            flag = 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            flag = 2;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            ReadOnly (false);
            txtMaSize.ReadOnly = true;
            flag = 3;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            string sql = "";
            int trangthai = cboTrangThai.Text == "Hoạt động" ? 1 : 0;
            bool stop = false;
            if(flag == 1)
            {
                if (txtMaSize.Text == "" || txtMoTa.Text == "" || cboTrangThai.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else
                {
                    sql = $"insert into size values ('{txtMaSize.Text}','{txtMoTa.Text}',{trangthai})";
                }
               
            }    
            else if(flag == 2)
            {
                sql = $"update size set TRANGTHAI = 0 where masize='{txtMaSize.Text}'";
            }
            else if(flag == 3)
            {
                if (txtMaSize.Text == "" || txtMoTa.Text == "" || cboTrangThai.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else
                {
                    sql = $"update size set trangthai='{cboTrangThai.SelectedIndex}', mota=N'{txtMoTa.Text}' where masize='{txtMaSize.Text}'";
                }
            }
            if (stop == false)
            {
                if (size.capnhatdulieu(sql) >= 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    frmSize_Load(sender, e);
                }
            }
        }





        void HienThi_Textbox(DataSet ds, int vitri)
        {
            if (vitri >=0 && vitri < dataset.Tables[0].Rows.Count)
            {
                txtMaSize.Text = ds.Tables[0].Rows[vitri]["MASIZE"].ToString();
                txtMoTa.Text = ds.Tables[0].Rows[vitri]["MOTA"].ToString();
                cboTrangThai.Text = ds.Tables[0].Rows[vitri]["TRANGTHAI"].ToString();
            }
        }

        private void frmSize_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvDanhSach, "select MASIZE,MOTA, case when TRANGTHAI=1 then N'Hoạt động' end as 'TRANGTHAI' from size where TRANGTHAI=1");
            HienThi_Textbox(dataset, vitri);
            xulychucnang(true);
            ReadOnly(true);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            HienThi_Textbox(dataset, vitri);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            ReadOnly (true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cboTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtMaSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaSize.Text.Length>0)
            {
                e.Handled = true;
            }
        }
    }
}
