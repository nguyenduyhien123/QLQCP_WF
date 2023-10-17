using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmQuanLyDangNhap : Form
    {
        _9_12_QuanLyQuanCaPhe classTong = new _9_12_QuanLyQuanCaPhe();
        DataSet ds = new DataSet();
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
            danhsach_datagridview(ref ds, dgvDanhSachDangNhap, "SELECT A.MANV,TENNV,CHUCVU,FORMAT(NGAYGIODANGNHAP, 'dd/MM/yyyy HH:mm:ss') AS 'NGAYGIODANGNHAP',FORMAT(NGAYGIODANGXUAT, 'dd/MM/yyyy HH:mm:ss') AS 'NGAYGIODANGXUAT',B.TRANGTHAI FROM NHANVIEN A, LICHSUDANGNHAP B WHERE A.MANV = B.MANV ORDER BY B.NGAYGIODANGNHAP DESC");
            // Kiểm tra và lấy đối tượng dataGridViewColumn cho cột "STT"
            DataGridViewColumn columnSTT = dgvDanhSachDangNhap.Columns["STT"];
            if (columnSTT != null)
            {
                // Sắp xếp theo cột "STT" tăng dần
                dgvDanhSachDangNhap.Sort(columnSTT, ListSortDirection.Ascending);
            }
            else
            {
                // Hiển thị thông báo lỗi hoặc xử lý khi cột "STT" không tồn tại
            }
        }
        void taoCotDanhSachDangNhap()
        {
            // Tạo đối tượng DataGridViewColumn cho cột tên
            DataGridViewColumn MANV = new DataGridViewTextBoxColumn();
            MANV.HeaderText = "MÃ NHÂN VIÊN";
            MANV.DataPropertyName = "MANV"; // Chỉ định tên thuộc tính dữ liệu
            MANV.ReadOnly = true;                              //
            DataGridViewColumn TENNV = new DataGridViewTextBoxColumn();
            TENNV.HeaderText = "HỌ TÊN";
            TENNV.DataPropertyName = "TENNV"; // Chỉ định tên thuộc tính dữ liệu
            TENNV.ReadOnly = true;                                //
            DataGridViewColumn CHUCVU = new DataGridViewTextBoxColumn();
            CHUCVU.HeaderText = "CHỨC VỤ";
            CHUCVU.DataPropertyName = "CHUCVU"; // Chỉ định tên thuộc tính dữ liệu
            CHUCVU.ReadOnly = true;                                                          // 
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
            dgvDanhSachDangNhap.Columns.Add(MANV);
            dgvDanhSachDangNhap.Columns.Add(TENNV);
            dgvDanhSachDangNhap.Columns.Add(CHUCVU);
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
