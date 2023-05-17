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
                        danhsach_datagridview(dgvDanhSachSanPham, $"SELECT * FROM SANPHAM WHERE {type_search} = '{value_search}'");
                        break;
                    }
                case "Tên sản phẩm":
                    {
                        lblTimKiem.Text = "Nhập Tên sản phẩm";
                        type_search = "TENSP";
                        danhsach_datagridview(dgvDanhSachSanPham, $"SELECT * FROM SANPHAM WHERE {type_search} LIKE N'%{value_search}%' AND '{value_search}'!=''");
                        break;
                    }
                case "Giá":
                    {
                        lblTimKiem.Text = "Nhập Giá";
                        type_search = "GIA";
                        try
                        {
                            int number = Convert.ToInt32(value_search);
                            danhsach_datagridview(dgvDanhSachSanPham, $"SELECT * FROM SANPHAM WHERE {type_search} = {number}");
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
                        danhsach_datagridview(dgvDanhSachSanPham, $"SELECT * FROM SANPHAM WHERE {type_search} = '{value_search}'");
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
            for (int i = dgvDanhSachSanPham.Rows.Count - 1; i >= 0; i--)
            {
                if (!dgvDanhSachSanPham.Rows[i].IsNewRow)
                {
                    dgvDanhSachSanPham.Rows.RemoveAt(i);
                }
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
            //danhsach_datagridview(dgvDanhSach, $"SELECT * FROM SANPHAM WHERE {type_search} = {search}");
            // danhsach_datagridview(dgvDanhSach, "SELECT * FROM SANPHAM");
        }
        void TaoCotSP()
        {
            // Tạo đối tượng DataGridViewColumn cho cột tên
            DataGridViewColumn MASP = new DataGridViewTextBoxColumn();
            MASP.HeaderText = "Mã SP";
            MASP.DataPropertyName = "MASP"; // Chỉ định tên thuộc tính dữ liệu
            MASP.ReadOnly = true;                              //
            DataGridViewColumn TENSP = new DataGridViewTextBoxColumn();
            TENSP.HeaderText = "Tên SP";
            TENSP.DataPropertyName = "TENSP"; // Chỉ định tên thuộc tính dữ liệu
            TENSP.ReadOnly = true;                                //
            // 
            DataGridViewColumn SOLUONG = new DataGridViewTextBoxColumn();
            SOLUONG.HeaderText = "SỐ LƯỢNG";
            SOLUONG.DataPropertyName = "SOLUONG"; // Chỉ định tên thuộc tính dữ liệu
            SOLUONG.ReadOnly = true;
            DataGridViewColumn LINK_IMG = new DataGridViewTextBoxColumn();
            LINK_IMG.HeaderText = "ĐƯỜNG DẪN HÌNH ẢNH";
            LINK_IMG.DataPropertyName = "LINK_IMG"; // Chỉ định tên thuộc tính dữ liệu
            LINK_IMG.ReadOnly = true;
            LINK_IMG.Visible = false;
            DataGridViewColumn DONVITINH = new DataGridViewTextBoxColumn();
            DONVITINH.HeaderText = "ĐƠN VỊ TÍNH";
            DONVITINH.DataPropertyName = "DONVITINH"; // Chỉ định tên thuộc tính dữ liệu
            DONVITINH.ReadOnly = true;
            DataGridViewColumn MOTA = new DataGridViewTextBoxColumn();
            MOTA.HeaderText = "MÔ TẢ";
            MOTA.DataPropertyName = "MOTA"; // Chỉ định tên thuộc tính dữ liệu
            MOTA.ReadOnly = true;
            DataGridViewColumn LOAISP = new DataGridViewTextBoxColumn();
            LOAISP.HeaderText = "LOẠI SP";
            LOAISP.DataPropertyName = "LOAISP"; // Chỉ định tên thuộc tính dữ liệu
            LOAISP.ReadOnly = true;

            DataGridViewColumn MANCC = new DataGridViewTextBoxColumn();
            MANCC.HeaderText = "MÃ NHÀ CUNG CẤP";
            MANCC.DataPropertyName = "MANCC"; // Chỉ định tên thuộc tính dữ liệu
            MANCC.ReadOnly = true;
            DataGridViewColumn TRANGTHAI = new DataGridViewTextBoxColumn();
            TRANGTHAI.HeaderText = "TRẠNG THÁI";
            TRANGTHAI.DataPropertyName = "TRANGTHAI"; // Chỉ định tên thuộc tính dữ liệu
            TRANGTHAI.ReadOnly = true;
            dgvDanhSachSanPham.DataSource = null;
            dgvDanhSachSanPham.Columns.Clear();
            dgvDanhSachSanPham.Columns.Add(MASP);
            dgvDanhSachSanPham.Columns.Add(TENSP);
            dgvDanhSachSanPham.Columns.Add(SOLUONG);
            dgvDanhSachSanPham.Columns.Add(LINK_IMG);
            dgvDanhSachSanPham.Columns.Add(MOTA);
            dgvDanhSachSanPham.Columns.Add(LOAISP);
            dgvDanhSachSanPham.Columns.Add(MANCC);
            dgvDanhSachSanPham.Columns.Add(TRANGTHAI);

        }
        void TaoCotCTSP()
        {
            //
            DataGridViewColumn MACTSP = new DataGridViewTextBoxColumn();
            MACTSP.HeaderText = "Mã CTSP";
            MACTSP.DataPropertyName = "MACTSP"; // Chỉ định tên thuộc tính dữ liệu
            MACTSP.ReadOnly = true;
            DataGridViewColumn MASP = new DataGridViewTextBoxColumn();
            MASP.HeaderText = "MÃ SP";
            MASP.DataPropertyName = "MASP"; // Chỉ định tên thuộc tính dữ liệu
            MASP.ReadOnly = true;
            DataGridViewColumn MASIZE = new DataGridViewTextBoxColumn();
            MASIZE.HeaderText = "MÃ SIZE";
            MASIZE.DataPropertyName = "MASIZE"; // Chỉ định tên thuộc tính dữ liệu
            MASIZE.ReadOnly = true;
            DataGridViewColumn SOLUONG = new DataGridViewTextBoxColumn();
            SOLUONG.HeaderText = "SỐ LƯỢNG";
            SOLUONG.DataPropertyName = "SOLUONG"; // Chỉ định tên thuộc tính dữ liệu
            SOLUONG.ReadOnly = false;
            DataGridViewColumn MOTA = new DataGridViewTextBoxColumn();
            MOTA.HeaderText = "MÔ TẢ";
            MOTA.DataPropertyName = "MOTA"; // Chỉ định tên thuộc tính dữ liệu
            MOTA.ReadOnly = true;
            DataGridViewColumn GIAVON = new DataGridViewTextBoxColumn();
            GIAVON.HeaderText = "GIÁ VỐN";
            GIAVON.DataPropertyName = "GIAVON"; // Chỉ định tên thuộc tính dữ liệu
            GIAVON.ReadOnly = true;
            DataGridViewColumn GIABAN = new DataGridViewTextBoxColumn();
            GIABAN.HeaderText = "GIÁ BÁN";
            GIABAN.DataPropertyName = "GIABAN"; // Chỉ định tên thuộc tính dữ liệu
            GIABAN.ReadOnly = true;
            DataGridViewColumn TRANGTHAI = new DataGridViewTextBoxColumn();
            TRANGTHAI.HeaderText = "TRẠNG THÁI";
            TRANGTHAI.DataPropertyName = "TRANGTHAI"; // Chỉ định tên thuộc tính dữ liệu
            TRANGTHAI.ReadOnly = true;
            //
            dgvDanhSachChiTietSanPham.DataSource = null;
            dgvDanhSachChiTietSanPham.Columns.Clear();
            dgvDanhSachChiTietSanPham.Columns.Add(MACTSP);
            dgvDanhSachChiTietSanPham.Columns.Add(MASP);
            dgvDanhSachChiTietSanPham.Columns.Add(MASIZE);
            dgvDanhSachChiTietSanPham.Columns.Add(SOLUONG);
            dgvDanhSachChiTietSanPham.Columns.Add(MOTA);
            dgvDanhSachChiTietSanPham.Columns.Add(GIAVON);
            dgvDanhSachChiTietSanPham.Columns.Add(GIABAN);
            dgvDanhSachChiTietSanPham.Columns.Add(TRANGTHAI);
        }

        private void frmSanPham_TimKiem_Load(object sender, EventArgs e)
        {
            TaoCotSP();
            TaoCotCTSP();
        }
    }
}
