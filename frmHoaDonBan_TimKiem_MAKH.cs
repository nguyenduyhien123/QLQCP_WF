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
    public partial class frmHoaDon_TimKiem : Form
    {
        string CotTimKiem(ComboBox cbo)
        {
            string cot = "";
            int chon = cbo.SelectedIndex;
            switch (chon)
            {
                case 0:
                    cot = "A.MAHDB";
                    break;
                case 1:
                    cot = "A.MAKH";
                    break;
                case 2:
                    cot = "A.MANV_LAP";
                    break;
                case 3:
                    cot = "A.NGAYLAPHD";
                    break;
                case 4:
                    cot = "B.MASP";
                    break;
                case 5:
                    cot = "B.MASIZE";
                    break;
                case 6:
                    cot = "B.MAKM";
                    break;
            }
            return cot;
        }
        public frmHoaDon_TimKiem()
        {
            InitializeComponent();
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTimKiem.SelectedIndex != -1)
            {
                lblThongTinTimKiem.Text = cboTimKiem.SelectedItem.ToString();
            }
        }

        private void txtThongTinTimKiem_TextChanged(object sender, EventArgs e)
        {
            string cot = CotTimKiem(cboTimKiem);
            string sql = $"SELECT * FROM HOADONBAN A,CHITIETHDB B WHERE {cot}='{txtThongTinTimKiem.Text}'";
        }
    }
}
