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
    public partial class frmLichSuDangNhap : Form
    {
        DataSet ds = new DataSet();
        string account = "";
        _9_12_QuanLyQuanCaPhe classTong=new _9_12_QuanLyQuanCaPhe();
        public frmLichSuDangNhap(string account)
        {
            InitializeComponent();
           this.account=account;
        }
        void danhsach_datagridview(ref DataSet ds, DataGridView dgv, string sql)
        {
            ds = classTong.LayDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        private void frmLichSuDangNhap_Load(object sender, EventArgs e)
        {
            danhsach_datagridview( ref ds, dgvDanhSachLichSuDangNhap, $"SELECT TOP 20 ROW_NUMBER() OVER (ORDER BY NGAYGIODANGNHAP DESC) AS STT,CONVERT(varchar, NGAYGIODANGNHAP, 103) + ' ' + CONVERT(varchar, NGAYGIODANGNHAP, 108) AS 'NGAYGIODANGNHAP', CONVERT(varchar, NGAYGIODANGXUAT, 103) + ' ' + CONVERT(varchar, NGAYGIODANGXUAT, 108) AS 'NGAYGIODANGXUAT', CASE WHEN SUADOIMATKHAU = 0 THEN 'KHÔNG' ELSE 'CÓ'  END AS 'SUADOIMATKHAU' FROM LICHSUDANGNHAP WHERE MANV='{account}' ORDER BY NGAYGIODANGNHAP DESC");
        }

        private void frmLichSuDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show($"Bạn có chắc muốn Đóng form Lịch sử đăng nhập ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgThoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
