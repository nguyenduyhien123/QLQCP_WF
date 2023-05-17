//using DocumentFormat.OpenXml.Drawing;
//using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Gói sử dụng để mã hoá mật khẩu
using System.Security.Cryptography;
// 
using System.Drawing.Drawing2D;
namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmDangNhap : Form
    {
        public bool isLogin=false;
        public string account = "";
        public string accountType = "";
        public frmDangNhap()
        {
            InitializeComponent();
            // đăng ký sự kiện FormClosing
        }
        _9_12_QuanLyQuanCaPhe classTong=new _9_12_QuanLyQuanCaPhe();
        DataSet ds_NhanVien=new DataSet();
        private void frmDangNhap_Load(object sender, EventArgs e)
        {

            this.ActiveControl = txtMaNhanVien;
            DateTime date = DateTime.Now;
            string dayOfWeek = Ngay(date.DayOfWeek.ToString());
            lblNgayGio.Text = $"{dayOfWeek} {date.ToString("dd/MM/yyyy HH:mm:ss")}";
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string manv = txtMaNhanVien.Text.ToUpper();
            if(manv != "")
            {
                string matkhau = txtMatKhau.Text;
                if (matkhau != "")
                {
                    ds_NhanVien = classTong.LayDuLieu($"SELECT * FROM NHANVIEN WHERE MANV='{manv}' AND MATKHAU='{ComputeSHA256(matkhau)}' AND TRANGTHAI = N'Đang làm'");
                    if (ds_NhanVien.Tables[0].Rows.Count > 0)
                    {
                        classTong.CapNhatDuLieu($"INSERT INTO LICHSUDANGNHAP VALUES ('{manv}',getdate(),null,'',0)");
                        isLogin = true;
                        account = manv;
                        accountType = ds_NhanVien.Tables[0].Rows[0]["CHUCVU"].ToString();
                        txtMaNhanVien.Text = "";
                        txtMatKhau.Text = "";
                        txtMaNhanVien.Focus();
                        if (isLogin && account != "" && accountType.Trim() == "Quản lý")
                        {

                            frmAdmin f = new frmAdmin(account);
                            this.Hide();
                            f.ShowDialog();
                            this.Show();
                        }
                        else if (isLogin && account != "" && accountType.Trim() != "Quản lý")
                        {
                            frmMenuNhanVien f = new frmMenuNhanVien(account);
                            this.Hide();
                            f.ShowDialog();
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên hoặc mật khẩu không chính xác hoặc tài khoản bị khoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }    
            else
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Thiết lập nội dung của Label là ngày giờ hiện tại theo định dạng "yyyy-MM-dd hh:mm:ss tt"
            DateTime date = DateTime.Now;
            string dayOfWeek = Ngay(date.DayOfWeek.ToString());
            lblNgayGio.Text = $"{dayOfWeek} {date.ToString("dd/MM/yyyy HH:mm:ss")}";
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
        string ComputeSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        bool HienThiMatKhau = true;
        private void btnAnHienMatKhau_Click(object sender, EventArgs e)
        {
            if (HienThiMatKhau)
            {
                btnAnHienMatKhau.Text = "Ẩn";
                txtMatKhau.UseSystemPasswordChar = false;
                HienThiMatKhau= false;
            }
            else
            {
                btnAnHienMatKhau.Text = "Hiện";
                txtMatKhau.UseSystemPasswordChar = true;
                HienThiMatKhau = true;
            }    
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void txtMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMatKhau.Focus(); 
            }
        }

        private void ptxDangNhap_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Focus();
        }

        private void ptxMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.Focus();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Focus();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            txtMatKhau.Focus();
        }
        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show($"Bạn có chắc muốn Thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgThoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
