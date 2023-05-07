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
    public partial class frmMenuNhanVien : Form
    {
        _9_12_QuanLyQuanCaPhe classTong = new _9_12_QuanLyQuanCaPhe();
        DataSet ds= new DataSet();
        string account = "";
        List<Form> openForms = new List<Form>(Application.OpenForms.Cast<Form>());
        public frmMenuNhanVien(string manv)
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

        private void HDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frmHoaDonBan = new frmHoaDonBan(account);
            frmHoaDonBan.MdiParent = this;
            frmHoaDonBan.Show();
        }

        private void BanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatBan_1 frmDatBan_1 = new frmDatBan_1();
            frmDatBan_1.MdiParent = this;
            frmDatBan_1.Show();
        }

        private void frmMenuNhanVien_Load(object sender, EventArgs e)
        {

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
                this.Close();
            }
        }

        private void btnDangXuat_MouseHover(object sender, EventArgs e)
        {
            btnDangXuat.ForeColor = Color.Red;
        }

        private void btnDangXuat_MouseLeave(object sender, EventArgs e)
        {
            btnDangXuat.ForeColor = Color.White;
        }

        private void frmMenuNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu người dùng ấn nút X ở form đăng nhập, thoát chương trình
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ds = classTong.LayDuLieu($"SELECT TOP 1 MANV,CONVERT(varchar(23), NGAYGIODANGNHAP, 121) AS 'NGAYGIODANGNHAP' FROM LICHSUDANGNHAP WHERE MANV='{account}' ORDER BY NGAYGIODANGNHAP DESC");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    classTong.CapNhatDuLieu($"UPDATE LICHSUDANGNHAP SET NGAYGIODANGXUAT = getdate() WHERE MANV='{account}' AND NGAYGIODANGNHAP='{ds.Tables[0].Rows[0]["NGAYGIODANGNHAP"]}'");
                }
            }
        }

        private void frmMenuNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnLichSuDangNhap_Click(object sender, EventArgs e)
        {
            frmLichSuDangNhap frmLichSuDangNhap=new frmLichSuDangNhap(account);
            frmLichSuDangNhap.MdiParent = this;
            frmLichSuDangNhap.Show();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            frmDatBan_1 frmDatBan_1 = new frmDatBan_1();
            frmDatBan_1.MdiParent = this;
            frmDatBan_1.Show();
        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frmHoaDonBan = new frmHoaDonBan(account);
            frmHoaDonBan.MdiParent = this;
            frmHoaDonBan.Show();
        }

        private void btnThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmThayDoiMatKhau frmThayDoiMatKhau = new frmThayDoiMatKhau(account);
            frmThayDoiMatKhau.MdiParent = this;
            frmThayDoiMatKhau.Show();
        }
    }
}
