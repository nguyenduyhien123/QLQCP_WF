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
        _9_12_QuanLyQuanCaPhe classTong= new _9_12_QuanLyQuanCaPhe();
        List <Control> ControlTieuChiTimKiem = new List <Control> ();
        List <Control> ControlThongTinTimKiem = new List <Control> ();
        DataSet dsHDB= new DataSet ();
        DataSet dsCTHDB = new DataSet();
        string dieukienSQL = "";
        void danhsach_datagridview(ref DataSet ds, DataGridView dgv, string sql)
        {
            ds = classTong.LayDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        void addCacCheckBoxTimKiem()
        {
            ControlTieuChiTimKiem.Add(chkMAHDB);
            ControlTieuChiTimKiem.Add(chkMAKH);
            ControlTieuChiTimKiem.Add(chkMANV_LAP);
            ControlTieuChiTimKiem.Add(chkNGAYLAPHD);
            ControlTieuChiTimKiem.Add(chkMASP);
            ControlTieuChiTimKiem.Add(chkMASIZE);
            ControlTieuChiTimKiem.Add(chkMAKM);
        }
        void addCactextBoxTimKiem()
        {
            ControlThongTinTimKiem.Add(txtMAHDB);
            ControlThongTinTimKiem.Add(txtMAKH);
            ControlThongTinTimKiem.Add(txtMANV_LAP);
            ControlThongTinTimKiem.Add(dtpNGAYLAPHD);
            ControlThongTinTimKiem.Add(txtMASP);
            ControlThongTinTimKiem.Add(txtMASIZE);
            ControlThongTinTimKiem.Add(txtMAKM);
        }
        void ChinhCacControlThongTinTimKiem(bool flag=false)
        {
            for(int i = 0;i < ControlThongTinTimKiem.Count;i++)
            {
                ControlThongTinTimKiem[i].Enabled = flag;
            }    
        }
        void ThemSuKienChoCheckbox()
        {
            for(int i =0;i< ControlTieuChiTimKiem.Count;i++)
            {
                if (ControlTieuChiTimKiem[i] is CheckBox)
                {
                    ((CheckBox)ControlTieuChiTimKiem[i]).CheckedChanged += new EventHandler(SuKienCheckBox);
                }    
            }    
        }
        void TruyVanSQL()
        {
            dgvHoaDonBan.DataSource = null;
            dgvChiTietHoaDonBan.DataSource = null;
            dgvHoaDonBan.Columns.Clear();
            dgvChiTietHoaDonBan.Columns.Clear();
            TaoCotHDB();
            TaoCotCTHDB();
            dieukienSQL = "";
            string sqlHDB = "SELECT DISTINCT A.* FROM HOADONBAN A, CHITIETHDB B WHERE A.MAHDB = B.MAHDB";
            if (ControlTieuChiTimKiem[0] is CheckBox && ((CheckBox)ControlTieuChiTimKiem[0]).Checked)
            {
                string input = ControlThongTinTimKiem[0].Text;
                int number;
                bool isNumeric = int.TryParse(input, out number);
                if (isNumeric)
                {
                    // Chuỗi input là một số nguyên, giá trị của number được gán bởi phương thức TryParse
                    dieukienSQL += $" AND A.{ControlTieuChiTimKiem[0].Name.Substring(3)} = {number}";
                }
                else
                {
                    // Chuỗi input không phải là một số nguyên
                    return;
                }
            }
            for (int i = 1; i <= 2; i++)
            {
                if (ControlTieuChiTimKiem[i] is CheckBox && ((CheckBox)ControlTieuChiTimKiem[i]).Checked)
                {
                        dieukienSQL += $" AND A.{ControlTieuChiTimKiem[i].Name.Substring(3)} = '{ControlThongTinTimKiem[i].Text}'";
                }    
            }
            for (int i = 3; i <= 3; i++)
            {
                if (ControlTieuChiTimKiem[i] is CheckBox && ((CheckBox)ControlTieuChiTimKiem[i]).Checked)
                {
                    DateTime dt = dtpNGAYLAPHD.Value;
                    string formattedDate = dt.ToString("yyyy-MM-dd");
                    dieukienSQL += $" AND CONVERT(DATE, A.{ControlTieuChiTimKiem[i].Name.Substring(3)})  = '{formattedDate}'";
                }
            }
            for (int i = 4; i < ControlTieuChiTimKiem.Count; i++)
            {
                if (ControlTieuChiTimKiem[i] is CheckBox && ((CheckBox)ControlTieuChiTimKiem[i]).Checked)
                {
                    dieukienSQL += $" AND B.{ControlTieuChiTimKiem[i].Name.Substring(3)} = '{ControlThongTinTimKiem[i].Text}'";
                }
            }
            sqlHDB += dieukienSQL;
            rtxtSQL.Text = sqlHDB;
              danhsach_datagridview(ref dsHDB, dgvHoaDonBan, sqlHDB);     
            if (dsHDB.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Không có Hoá đơn nào thoả mãn các tiêu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
            string sqlCTHB = sqlHDB.Replace("A.*", "B.*");
            if (dsHDB.Tables[0].Rows.Count > 0)
            {
                string mahdb = dgvHoaDonBan.Rows[0].Cells[0].Value.ToString();
                if (dieukienSQL.IndexOf("AND A.MAHDB = '") != -1)
                {
                    danhsach_datagridview(ref dsCTHDB, dgvChiTietHoaDonBan, $"SELECT DISTINCT B.* FROM HOADONBAN A,CHITIETHDB B WHERE A.MAHDB = B.MAHDB {dieukienSQL}");
                }
                else
                {
                    danhsach_datagridview(ref dsCTHDB, dgvChiTietHoaDonBan, $"SELECT DISTINCT B.* FROM HOADONBAN A,CHITIETHDB B WHERE A.MAHDB = B.MAHDB AND A.MAHDB = '{mahdb}' {dieukienSQL}");
                }
            }    
        }
        void TaoCotHDB()
        {
            //
            DataGridViewColumn MAHDB = new DataGridViewTextBoxColumn();
            MAHDB.HeaderText = "Mã HDB";
            MAHDB.DataPropertyName = "MAHDB"; // Chỉ định tên thuộc tính dữ liệu
            MAHDB.ReadOnly = true;
            DataGridViewColumn MAKH = new DataGridViewTextBoxColumn();
            MAKH.HeaderText = "MÃ KH";
            MAKH.DataPropertyName = "MAKH"; // Chỉ định tên thuộc tính dữ liệu
            MAKH.ReadOnly = true;
            DataGridViewColumn TONGTIENTHANHTOAN = new DataGridViewTextBoxColumn();
            TONGTIENTHANHTOAN.HeaderText = "TỔNG TIỀN THANH TOÁN";
            TONGTIENTHANHTOAN.DataPropertyName = "TONGTIENTHANHTOAN"; // Chỉ định tên thuộc tính dữ liệu
            TONGTIENTHANHTOAN.ReadOnly = true;
            DataGridViewColumn MANV_LAP = new DataGridViewTextBoxColumn();
            MANV_LAP.HeaderText = "MÃ NV";
            MANV_LAP.DataPropertyName = "MANV_LAP"; // Chỉ định tên thuộc tính dữ liệu
            MANV_LAP.ReadOnly = false;
            DataGridViewColumn NGAYLAPHD = new DataGridViewTextBoxColumn();
            NGAYLAPHD.HeaderText = "NGÀY LẬP HD";
            NGAYLAPHD.DataPropertyName = "NGAYLAPHD"; // Chỉ định tên thuộc tính dữ liệu
            NGAYLAPHD.ReadOnly = true;
            DataGridViewColumn TRANGTHAI = new DataGridViewTextBoxColumn();
            TRANGTHAI.HeaderText = "TRẠNG THÁI";
            TRANGTHAI.DataPropertyName = "TRANGTHAI"; // Chỉ định tên thuộc tính dữ liệu
            TRANGTHAI.ReadOnly = true;
            DataGridViewColumn GHICHU = new DataGridViewTextBoxColumn();
            GHICHU.HeaderText = "GHI CHÚ";
            GHICHU.DataPropertyName = "GHICHU"; // Chỉ định tên thuộc tính dữ liệu
            GHICHU.ReadOnly = true;
            dgvHoaDonBan.Columns.Clear();
            dgvHoaDonBan.Columns.Add(MAHDB);
            dgvHoaDonBan.Columns.Add(MAKH);
            dgvHoaDonBan.Columns.Add(TONGTIENTHANHTOAN);
            dgvHoaDonBan.Columns.Add(MANV_LAP);
            dgvHoaDonBan.Columns.Add(NGAYLAPHD);
            dgvHoaDonBan.Columns.Add(TRANGTHAI);
            dgvHoaDonBan.Columns.Add(GHICHU);
            dgvHoaDonBan.Columns[2].Width = 160;
            dgvHoaDonBan.Columns[4].Width = 160;
        }
        void TaoCotCTHDB()
        {
            //
            DataGridViewColumn MAHDB = new DataGridViewTextBoxColumn();
            MAHDB.HeaderText = "Mã HDB";
            MAHDB.DataPropertyName = "MAHDB"; // Chỉ định tên thuộc tính dữ liệu
            MAHDB.ReadOnly = true;
            MAHDB.Visible = false;
            DataGridViewColumn MASP = new DataGridViewTextBoxColumn();
            MASP.HeaderText = "MÃ SP";
            MASP.DataPropertyName = "MASP"; // Chỉ định tên thuộc tính dữ liệu
            MASP.ReadOnly = true;
            DataGridViewColumn MASIZE = new DataGridViewTextBoxColumn();
            MASIZE.HeaderText = "MÃ SIZE";
            MASIZE.DataPropertyName = "MASIZE"; // Chỉ định tên thuộc tính dữ liệu
            MASIZE.ReadOnly = true;
            DataGridViewColumn GIAVON = new DataGridViewTextBoxColumn();
            GIAVON.HeaderText = "GIÁ VỐN";
            GIAVON.DataPropertyName = "GIAVON"; // Chỉ định tên thuộc tính dữ liệu
            GIAVON.ReadOnly = true;
            GIAVON.Visible = false;

            DataGridViewColumn GIABAN = new DataGridViewTextBoxColumn();
            GIABAN.HeaderText = "GIÁ BÁN";
            GIABAN.DataPropertyName = "GIABAN"; // Chỉ định tên thuộc tính dữ liệu
            GIABAN.ReadOnly = true;
            DataGridViewColumn SOLUONG = new DataGridViewTextBoxColumn();
            SOLUONG.HeaderText = "SỐ LƯỢNG";
            SOLUONG.DataPropertyName = "SOLUONG"; // Chỉ định tên thuộc tính dữ liệu
            SOLUONG.ReadOnly = true;
            DataGridViewColumn MAKM = new DataGridViewTextBoxColumn();
            MAKM.HeaderText = "MÃ KM";
            MAKM.DataPropertyName = "MAKM"; // Chỉ định tên thuộc tính dữ liệu
            MAKM.ReadOnly = true;
            DataGridViewColumn THANHTIENBANDAU = new DataGridViewTextBoxColumn();
            THANHTIENBANDAU.HeaderText = "THÀNH TIÊN BAN ĐẦU";
            THANHTIENBANDAU.DataPropertyName = "THANHTIENBANDAU"; // Chỉ định tên thuộc tính dữ liệu
            THANHTIENBANDAU.ReadOnly = true;
            THANHTIENBANDAU.Visible = false;
            DataGridViewColumn SOTIENGIAM = new DataGridViewTextBoxColumn();
            SOTIENGIAM.HeaderText = "SỐ TIỀN GIẢM";
            SOTIENGIAM.DataPropertyName = "SOTIENGIAM"; // Chỉ định tên thuộc tính dữ liệu
            SOTIENGIAM.ReadOnly = true;
            SOTIENGIAM.Visible = false;
            DataGridViewColumn THANHTIENCUOICUNG = new DataGridViewTextBoxColumn();
            THANHTIENCUOICUNG.HeaderText = "THÀNH TIÊN CUỐI CÙNG";
            THANHTIENCUOICUNG.DataPropertyName = "THANHTIENCUOICUNG"; // Chỉ định tên thuộc tính dữ liệu
            THANHTIENCUOICUNG.ReadOnly = true;
            DataGridViewColumn TRANGTHAI = new DataGridViewTextBoxColumn();
            TRANGTHAI.HeaderText = "TRẠNG THÁI";
            TRANGTHAI.DataPropertyName = "TRANGTHAI"; // Chỉ định tên thuộc tính dữ liệu
            TRANGTHAI.ReadOnly = true;
            dgvChiTietHoaDonBan.Columns.Clear();
            dgvChiTietHoaDonBan.Columns.Add(MAHDB);
            dgvChiTietHoaDonBan.Columns.Add(MASP);
            dgvChiTietHoaDonBan.Columns.Add(MASIZE);
            dgvChiTietHoaDonBan.Columns.Add(GIAVON);
            dgvChiTietHoaDonBan.Columns.Add(GIABAN);
            dgvChiTietHoaDonBan.Columns.Add(SOLUONG);
            dgvChiTietHoaDonBan.Columns.Add(MAKM);
            dgvChiTietHoaDonBan.Columns.Add(THANHTIENBANDAU);
            dgvChiTietHoaDonBan.Columns.Add(SOTIENGIAM);
            dgvChiTietHoaDonBan.Columns.Add(THANHTIENCUOICUNG);
            dgvChiTietHoaDonBan.Columns.Add(TRANGTHAI);
            dgvChiTietHoaDonBan.Columns[4].Width = 160;
            dgvChiTietHoaDonBan.Columns[9].Width = 160;


        }

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

        private void frmHoaDon_TimKiem_Load(object sender, EventArgs e)
        {
            addCacCheckBoxTimKiem();
            addCactextBoxTimKiem();
            ThemSuKienChoCheckbox();
            ChinhCacControlThongTinTimKiem(false);
            dgvHoaDonBan.DefaultCellStyle.Font = new Font("Arial", 10);
            dgvHoaDonBan.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvChiTietHoaDonBan.DefaultCellStyle.Font = new Font("Arial", 10);
            dgvChiTietHoaDonBan.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            TaoCotHDB();
            TaoCotCTHDB();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TruyVanSQL();
        }

        private void SuKienCheckBox(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
           // MessageBox.Show($"Thông báo {chk.Name}", "Thông báo");
           // vị trí của cái chứa thông tin
            int vitri = ControlTieuChiTimKiem.IndexOf(chk);
            if(chk.Checked)
            {
                ControlThongTinTimKiem[vitri].Enabled = true;
            }
            else
            {
                ControlThongTinTimKiem[vitri].Enabled = false;
                ControlThongTinTimKiem[vitri].Text = "";
            }

        }

        private void chkMAHDB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = e.RowIndex;
            if (vitri >= 0 && vitri < dgvHoaDonBan.RowCount - 1)
            {
                string mahdb = dgvHoaDonBan.Rows[vitri].Cells[0].Value.ToString();
                if (dieukienSQL.IndexOf("AND A.MAHDB = '") != -1)
                {
                    danhsach_datagridview(ref dsCTHDB, dgvChiTietHoaDonBan, $"SELECT DISTINCT B.* FROM HOADONBAN A,CHITIETHDB B WHERE A.MAHDB = B.MAHDB {dieukienSQL}");
                }
                else
                {
                    danhsach_datagridview(ref dsCTHDB, dgvChiTietHoaDonBan, $"SELECT DISTINCT B.* FROM HOADONBAN A,CHITIETHDB B WHERE A.MAHDB = B.MAHDB AND A.MAHDB = '{mahdb}' {dieukienSQL}");
                }
            }
        }
    }
}
