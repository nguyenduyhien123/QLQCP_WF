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
namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmThayDoiMatKhau : Form
    {
        string account = "";
        _9_12_QuanLyQuanCaPhe classTong=new _9_12_QuanLyQuanCaPhe();
        DataSet ds=new DataSet();
        public frmThayDoiMatKhau(string account)
        {
            InitializeComponent();
            this.account = account;
            this.ActiveControl = txtMatKhauCu;
        }

        private void btnThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matkhaucu = txtMatKhauCu.Text;
            string matkhaumoi=txtMatKhauMoi.Text;
            int row= classTong.CapNhatDuLieu($"UPDATE NHANVIEN SET MATKHAU='{ComputeSHA256(matkhaumoi)}' WHERE MANV='{account}' AND MATKHAU='{ComputeSHA256(matkhaucu)}'");
            if (row > 0 )
            {
                MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo");
                Close();
            }    
            else
            {
                MessageBox.Show("Mật khẩu cũ chưa chính xác", "Thông báo");
            }
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

        private void pnlMatKhauCu_Paint(object sender, PaintEventArgs e)
        {
            txtMatKhauCu.Focus();
        }

        private void pnlMatKhauMoi_Paint(object sender, PaintEventArgs e)
        {
            txtMatKhauMoi.Focus();
        }
        bool HienThiMatKhauCu = true;

        private void btnAnHienMatKhauCu_Click(object sender, EventArgs e)
        {
            if (HienThiMatKhauCu)
            {
                btnAnHienMatKhauCu.Text = "Ẩn";
                txtMatKhauCu.UseSystemPasswordChar = false;
                HienThiMatKhauCu = false;
            }
            else
            {
                btnAnHienMatKhauCu.Text = "Hiện";
                txtMatKhauCu.UseSystemPasswordChar = true;
                HienThiMatKhauCu = true;
            }
        }
        bool HienThiMatKhauMoi = true;
        private void btnAnHienMatKhauMoi_Click(object sender, EventArgs e)
        {
            if (HienThiMatKhauMoi)
            {
                btnAnHienMatKhauMoi.Text = "Ẩn";
                txtMatKhauMoi.UseSystemPasswordChar = false;
                HienThiMatKhauMoi = false;
            }
            else
            {
                btnAnHienMatKhauMoi.Text = "Hiện";
                txtMatKhauMoi.UseSystemPasswordChar = true;
                HienThiMatKhauMoi = true;
            }
        }

        private void txtMatKhauCu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtMatKhauMoi.Focus();
            }
        }

        private void txtMatKhauMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) { 
                btnThayDoiMatKhau_Click(sender, e);
            }
        }

        private void frmThayDoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show($"Bạn có chắc muốn Đóng form Thay đổi mật khẩu ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgThoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
