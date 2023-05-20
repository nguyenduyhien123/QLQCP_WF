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
    
    public partial class frmAdmin : Form
    {
        _9_12_QuanLyQuanCaPhe classTong = new _9_12_QuanLyQuanCaPhe();
        DataSet ds = new DataSet();
        string account = "";
        public frmAdmin(string manv)
        {
            InitializeComponent();
            account = manv;
            // Trong đó, this.Width được đặt bằng với chiều rộng của màn hình chính(Screen.PrimaryScreen.WorkingArea.Width).
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            // Khởi tạo ngày giờ
            DateTime date = DateTime.Now;
            string dayOfWeek = Ngay(date.DayOfWeek.ToString());
            lblNgayGio.Text = $"{dayOfWeek} {date.ToString("dd/MM/yyyy HH:mm:ss")}";
            // Load thông tin tài khoản
            DataSet dsThongTinTaiKhoan = new DataSet();
            dsThongTinTaiKhoan = classTong.LayDuLieu($"SELECT * FROM NHANVIEN WHERE MANV='{manv}'");
            string tennv = dsThongTinTaiKhoan.Tables[0].Rows[0]["TENNV"].ToString();
            string chucvu = dsThongTinTaiKhoan.Tables[0].Rows[0]["CHUCVU"].ToString();
            lblTaiKhoan.Text = $"Xin chào {tennv} - Mã NV: {manv} - Chức vụ: {chucvu}";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;

        }

        private void mnuDanhMucHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan f = new frmHoaDonBan(account);
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDanhMucSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham f = new frmSanPham();
            f.MdiParent = this;
            f.Show();
        }
        string Ngay(string day)
        {
            switch (day)
            {
                case "Monday":
                    {
                        return "Thứ Hai";
                    }
                case "Tuesday":
                    {
                        return "Thứ Ba";
                    }
                case "Wednesday":
                    {
                        return "Thứ Tư";
                    }
                case "Thursday":
                    {
                        return "Thứ Năm";
                    }
                case "Friday":
                    {
                        return "Thứ Sáu";
                    }
                case "Saturday":
                    {
                        return "Thứ Bảy";
                    }
                case "Sunday":
                    {
                        return "Chủ Nhật";
                    }
            }
            return "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Thiết lập nội dung của Label là ngày giờ hiện tại theo định dạng "yyyy-MM-dd hh:mm:ss tt"
            DateTime date = DateTime.Now;
            string dayOfWeek = Ngay(date.DayOfWeek.ToString());
            lblNgayGio.Text = $"{dayOfWeek} {date.ToString("dd/MM/yyyy HH:mm:ss")}";
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show($"Bạn có chắc muốn đăng xuất khỏi hệ thống?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgThoat == DialogResult.Yes)
            {
                ds = classTong.LayDuLieu($"SELECT TOP 1 MANV,CONVERT(varchar(23), NGAYGIODANGNHAP, 121) AS 'NGAYGIODANGNHAP' FROM LICHSUDANGNHAP WHERE MANV='{account}' ORDER BY NGAYGIODANGNHAP DESC");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    classTong.CapNhatDuLieu($"UPDATE LICHSUDANGNHAP SET NGAYGIODANGXUAT = getdate() WHERE MANV='{account}' AND NGAYGIODANGNHAP='{ds.Tables[0].Rows[0]["NGAYGIODANGNHAP"]}'");
                }
                //this.FormClosed += new FormClosedEventHandler(frmAdmin_FormClosed);
                // đóng form hiện tại
                this.Close();
                // tạo mới form đăng nhập và hiển thị
                ////frmDangNhap frmDangNhap = new frmDangNhap();
                ////frmDangNhap.Show();
                //FormClosedEventArgs f = new FormClosedEventArgs(CloseReason.UserClosing);
                //frmMenuNhanVien_FormClosed(sender, f);
            }
        }

        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmDangNhap frmDangNhap = new frmDangNhap();
            //frmDangNhap.Show();
        }

        private void mnuDanhMucHoaDonNhap_Click(object sender, EventArgs e)
        {
            frmHoaDonNhap f = new frmHoaDonNhap();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDanhMucKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang f= new frmKhachHang();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDanhMucKhuyenMai_Click(object sender, EventArgs e)
        {
            frmKhuyenMai f= new frmKhuyenMai();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDanhMucLichSuDangNhap_Click(object sender, EventArgs e)
        {
            frmLichSuDangNhap f = new frmLichSuDangNhap(account);
            f.MdiParent = this;
                f.Show();
        }

        private void mnuDanhMucLoaiSanPham_Click(object sender, EventArgs e)
        {
            frmLoaiSP f = new frmLoaiSP();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDanhMucNhaCungCap_Click(object sender, EventArgs e)
        {
            frmNhaCungCap f= new frmNhaCungCap();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDanhMucNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien f= new frmNhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDanhMucSize_Click(object sender, EventArgs e)
        {
            frmSize f = new frmSize();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmThayDoiMatKhau f= new frmThayDoiMatKhau(account); f.MdiParent = this;
            f.Show();
        }

        private void mnuTimKiemHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDon_TimKiem f = new frmHoaDon_TimKiem();
            f.MdiParent = this;
            f.Show();
        }

        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show($"Bạn có chắc muốn Đóng form Quản lý ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgThoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void mnuThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            frmHoaDonBan_ThongKeBaoCao f = new frmHoaDonBan_ThongKeBaoCao();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuQuanLyDangNhap_Click(object sender, EventArgs e)
        {
            frmQuanLyDangNhap f = new frmQuanLyDangNhap();
            f.MdiParent = this;
            f.Show();
        }
    }
}
