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
    public partial class frmSanPham_TimKiem : Form
    {
        public frmSanPham_TimKiem()
        {
            InitializeComponent();
            txtTimKiem.Enabled = false;
        }
        _9_12_QuanLyQuanCaPhe c = new _9_12_QuanLyQuanCaPhe();
        int vitri = 0;
        DataSet ds = new DataSet();
        void danhsach_datagridview(DataGridView d, string sql)
        {
            ds = c.LayDuLieu(sql);
            //lblTimKiem.Text = ds.Tables.Count.ToString();
            d.DataSource = ds.Tables[0];
        }
        string type_search = "";
        void TimKiem()
        {
            string type_search = "";
            type_search = cboTimKiem.Text;
            string value_search = txtTimKiem.Text;
            switch (type_search)
            {
                case "Mã sản phẩm":
                    {
                        lblTimKiem.Text = "Nhập Mã sản phẩm";
                        type_search = "MASP";
                        danhsach_datagridview(dgvDanhSach, $"SELECT * FROM SANPHAM WHERE {type_search} = '{value_search}'");
                        break;
                    }
                case "Tên sản phẩm":
                    {
                        lblTimKiem.Text = "Nhập Tên sản phẩm";
                        type_search = "TENSP";
                        danhsach_datagridview(dgvDanhSach, $"SELECT * FROM SANPHAM WHERE {type_search} LIKE N'%{value_search}%' AND '{value_search}'!=''");
                        break;
                    }
                case "Giá":
                    {
                        lblTimKiem.Text = "Nhập Giá";
                        type_search = "GIA";
                        try
                        {
                            int number = Convert.ToInt32(value_search);
                            danhsach_datagridview(dgvDanhSach, $"SELECT * FROM SANPHAM WHERE {type_search} = {number}");
                        }
                        catch (Exception ex)
                        {

                        }
                        break;
                    }
                case "Đơn vị tính":
                    {
                        lblTimKiem.Text = "Nhập Đơn vị tính";
                        type_search = "DONVITINH";
                        danhsach_datagridview(dgvDanhSach, $"SELECT * FROM SANPHAM WHERE {type_search} = '{value_search}'");
                        break;
                    }
            }
        }
        void LamSachDataGridView(DataGridView dgv)
        {
            for (int i = dgv.Rows.Count - 1; i >= 0; i--)
            {
                if (!dgv.Rows[i].IsNewRow)
                {
                    dgv.Rows.RemoveAt(i);
                }
            }
        }
        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            txtTimKiem.Enabled = true;
            for (int i = dgvDanhSach.Rows.Count - 1; i >= 0; i--)
            {
                if (!dgvDanhSach.Rows[i].IsNewRow)
                {
                    dgvDanhSach.Rows.RemoveAt(i);
                }
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
            //danhsach_datagridview(dgvDanhSach, $"SELECT * FROM SANPHAM WHERE {type_search} = {search}");
            // danhsach_datagridview(dgvDanhSach, "SELECT * FROM SANPHAM");
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void lblTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
