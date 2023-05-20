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
    public partial class frmQuanLyDangNhap : Form
    {
        _9_12_QuanLyQuanCaPhe classTong= new _9_12_QuanLyQuanCaPhe();
        DataSet ds=new DataSet();
        void danhsach_datagridview(ref DataSet ds, DataGridView dgv, string sql)
        {
            ds = classTong.LayDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        } 
        public frmQuanLyDangNhap()
        {
            InitializeComponent();
        }

        private void frmQuanLyDangNhap_Load(object sender, EventArgs e)
        {
            taoCotDanhSachDangNhap();
            danhsach_datagridview(ref ds, dgvDanhSachDangNhap, "  SELECT ROW_NUMBER() OVER (ORDER BY NGAYGIODANGNHAP DESC) AS 'STT',A.MANV,TENNV,FORMAT(NGAYGIODANGNHAP, 'dd/MM/yyyy HH:mm:ss') AS 'NGAYGIODANGNHAP',FORMAT(NGAYGIODANGXUAT, 'dd/MM/yyyy HH:mm:ss') AS 'NGAYGIODANGXUAT',B.TRANGTHAI FROM NHANVIEN A, LICHSUDANGNHAP B WHERE A.MANV = B.MANV  ORDER BY NGAYGIODANGNHAP DESC");
        }
        void taoCotDanhSachDangNhap()
        {
            // Tạo đối tượng DataGridViewColumn cho cột tên
            DataGridViewColumn STT = new DataGridViewTextBoxColumn();
            STT.HeaderText = "SỐ THỨ TỰ";
            STT.DataPropertyName = "STT"; // Chỉ định tên thuộc tính dữ liệu
            STT.ReadOnly = true;
            DataGridViewColumn MANV = new DataGridViewTextBoxColumn();
            MANV.HeaderText = "MÃ NHÂN VIÊN";
            MANV.DataPropertyName = "MANV"; // Chỉ định tên thuộc tính dữ liệu
            MANV.ReadOnly = true;                              //
            DataGridViewColumn TENNV = new DataGridViewTextBoxColumn();
            TENNV.HeaderText = "HỌ TÊN";
            TENNV.DataPropertyName = "TENNV"; // Chỉ định tên thuộc tính dữ liệu
            TENNV.ReadOnly = true;                                //
                                                                  // 
            DataGridViewColumn NGAYGIODANGNHAP = new DataGridViewTextBoxColumn();
            NGAYGIODANGNHAP.HeaderText = "NGÀY GIỜ ĐĂNG NHẬP";
            NGAYGIODANGNHAP.DataPropertyName = "NGAYGIODANGNHAP"; // Chỉ định tên thuộc tính dữ liệu
            NGAYGIODANGNHAP.ReadOnly = true;
            DataGridViewColumn NGAYGIODANGXUAT = new DataGridViewTextBoxColumn();
            NGAYGIODANGXUAT.HeaderText = "NGÀY GIỜ ĐĂNG XUẤT";
            NGAYGIODANGXUAT.DataPropertyName = "NGAYGIODANGXUAT"; // Chỉ định tên thuộc tính dữ liệu
            NGAYGIODANGXUAT.ReadOnly = true;
            DataGridViewColumn TRANGTHAI = new DataGridViewTextBoxColumn();
            TRANGTHAI.HeaderText = "TRẠNG THÁI";
            TRANGTHAI.DataPropertyName = "TRANGTHAI"; // Chỉ định tên thuộc tính dữ liệu
            TRANGTHAI.ReadOnly = true;
            dgvDanhSachDangNhap.DataSource = null;
            dgvDanhSachDangNhap.Columns.Clear();
            dgvDanhSachDangNhap.Columns.Add(STT);
            dgvDanhSachDangNhap.Columns.Add(MANV);
            dgvDanhSachDangNhap.Columns.Add(TENNV);
            dgvDanhSachDangNhap.Columns.Add(NGAYGIODANGNHAP);
            dgvDanhSachDangNhap.Columns.Add(NGAYGIODANGXUAT);
            dgvDanhSachDangNhap.Columns.Add(TRANGTHAI);
            dgvDanhSachDangNhap.Columns[0].Width = 100;
            dgvDanhSachDangNhap.ColumnHeadersHeight = 40;


        }

        private void frmQuanLyDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show($"Bạn có chắc muốn Đóng form Quản lý đăng nhập?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgThoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
