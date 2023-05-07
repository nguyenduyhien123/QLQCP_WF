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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }


        void xulychucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            xulychucnang(true);
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            xulychucnang(false);
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
