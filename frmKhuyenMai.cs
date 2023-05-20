using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MessageBox = System.Windows.Forms.MessageBox;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmKhuyenMai : Form
    {
        public frmKhuyenMai()
        {
            InitializeComponent();
        }

        string sql = "";
        int flag = 0;
        int vitri = 0;
        DataSet ds_ChiTietKM = new DataSet();
        DataSet ds_MASP = new DataSet();
        DataSet ds_MASIZE = new DataSet();
        DataSet ds_MAKM = new DataSet();
        DataSet ds = new DataSet();

        clsquanlycaphe khuyenmai = new clsquanlycaphe();// ket noi vao database

        //ham ket noi
        void danhsach_datagridview(ref DataSet ds, DataGridView dgv, string sql)
        {
            ds = khuyenmai.LayDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
            //do 
        }

        void HienThiTimKiem(GroupBox thongtin, GroupBox Tim, Boolean t)
        {
            thongtin.Visible = !t;
            Tim.Visible = t;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ReadOnly(Boolean t)
        {
            dtpNgayBatDau.Enabled = !t;
            dtpNgayHet.Enabled = !t;
            txtTenKM.ReadOnly = t;
            cboTrangThai.Enabled = !t;
        }

        void xulychucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
            btnHuy.Enabled = !t;
        }

        string MAKM_them = "";
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            HienThiTimKiem(gboThongTin, gboTimKiem, false);
            txtTenKM.ReadOnly=false;
            cboTrangThai.Enabled = true;
            txtMaKM.Text = phatSinhMa();
            MAKM_them = phatSinhMa();
            txtMaKM.ReadOnly=true;
            dtpNgayBatDau.Enabled = true;
            dtpNgayHet.Enabled = true;
            txtTenKM.Clear();
            cboTrangThai.SelectedIndex = -1;
            flag = 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTenKM.Text != "" && cboTrangThai.SelectedIndex != -1)
            {
                xulychucnang(false);
                flag = 3;
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn xóa ở danh sách khuyến mãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtTenKM.Text !="" && cboTrangThai.SelectedIndex != -1)
            {
                xulychucnang(false);
                ReadOnly(false);
                
                HienThiTimKiem(gboThongTin, gboTimKiem, false);
                flag = 2;
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn sửa ở danh sách khuyến mãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        string ThemKM = "";
        private void btnLuu_Click(object sender, EventArgs e)
        {
            xulychucnang(true);

            //Đổi kiểu dữ liệu ngày từ dd/mm/yy thành mm/dd/yyyy
            //string ngayBatDau1 = dtpNgayBatDau.Value.ToString(
            //    "dd/MM/yy");
            DateTime dateBD = dtpNgayBatDau.Value;
            //DateTime dateBD = DateTime.ParseExact(ngayBatDau1, "dd/MM/yy", CultureInfo.InvariantCulture);
            string ngayBatDau2 = dateBD.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            //string ngayKetThuc1 = dtpNgayHet.Text;

            //DateTime dateKT = DateTime.ParseExact(ngayKetThuc1, "dd/MM/yy", CultureInfo.InvariantCulture);
            DateTime dateKT = dtpNgayHet.Value;
            string ngayKetThuc2 = dateKT.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            bool stop = false;
            if (flag == 1)//thêm
            {
                if (txtTenKM.Text == "" && cboTrangThai.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else if (txtTenKM.Text == "")
                {
                    MessageBox.Show(this, "Bạn chưa nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                    stop = true;
                    xulychucnang(false);
                }
                else if (cboTrangThai.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Bạn chưa chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else if(dtpNgayHet.Value <= dtpNgayBatDau.Value)
                {
                    MessageBox.Show(this, "Ngày kết thúc phải lớn hơn ngày bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(false);
                }
                else
                {
                    sql = $"insert KHUYENMAI values('{txtMaKM.Text}', N'{txtTenKM.Text}','{ngayBatDau2}','{ngayKetThuc2}',N'{cboTrangThai.Text}')";
                }
            }
            if (flag == 2)//sửa
            {
                if (txtTenKM.Text == "")
                {
                    MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                    xulychucnang(true);
                }
                else
                {
                    sql = $"update khuyenmai set TENKM=N'{txtTenKM.Text}', trangthai = N'{cboTrangThai.Text}', NGAYBATDAU ='{ngayBatDau2}', NGAYHETHAN = '{ngayKetThuc2}' where MAKM='{txtMaKM.Text}'";
                }
            }
            if (flag == 3)//xóa
            {
                sql = $"update khuyenmai set trangthai = N'Xóa'  where makm='{txtMaKM.Text}'";
            }
            if (stop == false)
            {
                if (khuyenmai.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    KhuyenMai_Load(sender, e);
                    if (flag == 1)
                    {
                        ThemKM = "ThemKM Thanh cong";
                    }
                }
            }

            if (ThemKM.Equals("ThemKM Thanh cong"))
            {
                gboThongTin.Visible = false;
                btnTim.Visible = false;
                gboChucNangKM.Visible = false;
                gboThongTinCT.Visible = true;
                ReadOnly_ChiTietKM(false);
                XuLyChucNangCT(false);
                hienThiComboBox(ds_MAKM, cboMaKM_CT, $"select * from khuyenmai where makm='{MAKM_them}'", "TENKM", "MAKM");
                cboMaKM_CT.Enabled = false;
                btnTruycap_CT.Visible = false;
                btnHuyCT.Enabled = false;
                flag_CT = 1;
            }
        }

        Boolean Load_dgv = false;
        private void KhuyenMai_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(ref ds,dgvDanhSach, "select * from khuyenmai where TRANGTHAI!=N'Xóa'");
            ds_ChiTietKM = khuyenmai.LayDuLieu("select * from chitietkm");
            ReadOnly(true);
            xulychucnang(true);
            Load_dgv = true;
            gboTimKiemCT.Visible = true;

            hienThiComboBox(ds_MAKM, cboMaKM_CT, "select * from khuyenmai where trangthai !=N'%x%'","TENKM", "MAKM");
            hienThiComboBox(ds_MASP, cboMASP_CT, "select * from SANPHAM where trangthai != N'Xóa'", "TENSP", "MASP");
            string masp = cboMASP_CT.SelectedValue.ToString();
            hienThiComboBox(ds_MASIZE, cboMaSize_CT, $"select * from CHITIETSANPHAM where MASP ={masp} and TRANGTHAI !=N'Xóa'", "MASIZE", "MASIZE");
        }

       

        void HienThi_Textbox(DataSet ds, int vitri)
        {
            if (vitri > -1 && vitri < ds.Tables[0].Rows.Count)
            {
                txtTenKM.Text = ds.Tables[0].Rows[vitri]["TENKM"].ToString();
                txtMaKM.Text = ds.Tables[0].Rows[vitri]["MAKM"].ToString();
                dtpNgayHet.Text = ds.Tables[0].Rows[vitri]["NGAYHETHAN"].ToString();
                dtpNgayBatDau.Text = ds.Tables[0].Rows[vitri]["NGAYBATDAU"].ToString();
                if (String.Equals(ds.Tables[0].Rows[vitri]["TRANGTHAI"], "Hoạt động"))
                    cboTrangThai.SelectedIndex = 0;
                else
                    cboTrangThai.SelectedIndex = 1;
            }
        }

        void HienThi_TextboxCTKM(DataSet ds, int vitri)
        {
            if (vitri > -1 && vitri < ds.Tables[0].Rows.Count)
            {
                string makm = ds.Tables[0].Rows[vitri]["MAKM"].ToString();
                hienThiComboBox(ds_MAKM, cboMaKM_CT, $"select * from khuyenmai where makm='{makm}'", "TENKM", "MAKM");
               
                string masp = ds.Tables[0].Rows[vitri]["MASP"].ToString();
                hienThiComboBox(ds_MASP, cboMASP_CT, $"select * from sanpham where masp='{masp}'", "TENSP", "MASP");

                string masize = ds.Tables[0].Rows[vitri]["MASIZE"].ToString();
                hienThiComboBox(ds_MASIZE, cboMaSize_CT, $"select * from size where masize='{masize}'", "MASIZE", "MASIZE");
                cboTrangThai_CT.Text = ds.Tables[0].Rows[vitri]["TRANGTHAI"].ToString();
                txtGiaBan.Text = ds.Tables[0].Rows[vitri]["GIABAN"].ToString();
                txtGiaSauKhiGiam_CT.Text = ds.Tables[0].Rows[vitri]["GIASAUKHIGIAM"].ToString();
                txtPhanTramGiam_CT.Text = ds.Tables[0].Rows[vitri]["PHANTRAMGIAM"].ToString();
                txtSoTienGiam_CT.Text = ds.Tables[0].Rows[vitri]["SOTIENGIAM"].ToString();
                txtSoTienGiamToiDa_CT.Text = ds.Tables[0].Rows[vitri]["SOTIENGIAMTOIDA"].ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            ReadOnly(true);
            txtMaKM.Text = " ";
            HienThiTimKiem(gboThongTin, gboTimKiem, false);
        }

        string phatSinhMa()
        {
            string maPhatSinh = "";
            DataSet dsKM = khuyenmai.LayDuLieu("Select makm from khuyenmai");
            maPhatSinh = "KM"+(dsKM.Tables[0].Rows.Count + 1).ToString();
            return maPhatSinh;
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Load_dgv)
            {
                if (e.ColumnIndex >= 0 && e.ColumnIndex < dgvDanhSach.Rows.Count)
                {
                    int vitri = dgvDanhSach.CurrentRow.Index;
                    string makm = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenkm = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string trangthai = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    sql = $"update KHUYENMAI set TENKM=N'{tenkm}', TRANGTHAI=N'{trangthai}' where MAKM='{makm}'";
                    if (khuyenmai.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        vitri = 0;
                        KhuyenMai_Load(sender, e);
                    }
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            cboTim.SelectedIndex = 0;
            if(gboThongTin.Visible == true)
            {
                btnTim.Text = "Hiện Hộp thông tin";
                HienThiTimKiem(gboThongTin, gboTimKiem, true);
            }
            else
            {
                btnTim.Text = "Tìm thông tin khuyến mãi";
                HienThiTimKiem(gboThongTin, gboTimKiem, false);
                btnHienDS_Click(sender, e);
            }
        }

        private void btnTimTT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                MessageBox.Show(this, "Bạn phải điền thông tin thì tôi mới tìm được chứ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cboTim.SelectedIndex == 0)
            {
                danhsach_datagridview(ref ds,dgvDanhSach, $"select * from khuyenmai where tenkm like N'%{txtTim.Text}%' and trangthai != N'Xóa'");
            }
            else if (cboTim.SelectedIndex == 1)
            {
                danhsach_datagridview(ref ds,dgvDanhSach, $"Select * from khuyenmai where makm like '%{txtTim.Text}%' and trangthai != N'Xóa'");
            }
            else if(cboTim.SelectedIndex == 2)
            {
                danhsach_datagridview(ref ds, dgvDanhSach, $"select * from khuyenmai where trangthai like N'%{txtTim.Text}%' and trangthai != N'Xóa'");
            }

            if(dgvDanhSach.Rows.Count - 1  == 0)
            {
                MessageBox.Show(this, "Không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHienDS_Click(object sender, EventArgs e)
        {
            danhsach_datagridview(ref ds, dgvDanhSach, "select * from KHUYENMAI where trangthai != N'Xóa'");
        }

        string makm = "";
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            if (vitri>=0 && vitri < dgvDanhSach.Rows.Count)
            {
                if(ds.Tables.Count > 0 && e.RowIndex < dgvDanhSach.Rows.Count-1 && e.RowIndex!=-1)
                {
                    HienThi_Textbox(ds, vitri);
                    makm = ds.Tables[0].Rows[vitri]["MAKM"].ToString();
                    ReadOnly(true);
                    xulychucnang(true);
                    danhsach_datagridview(ref ds_ChiTietKM, dvgDanhSachCT, $"select * from CHITIETKM where MAKM = '{makm}' and TRANGTHAI !=N'Xóa'");
                }
            }
        }

        private void txtTenKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))//IsPUNctuation là kiếm tra có phải dấu câu, IsSymbol dùng để kiểm tra ký tự toán học, ký tự đặc biệt dựa trên bảng mã Unicode.
            {
                e.Handled = true;
            }
        }

        private void txtPhanTramGiam_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và dấu chấm thập phân
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar) && (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar)) || char.IsLetter(e.KeyChar) || e.KeyChar == (char)22)
            {
                e.Handled = true;
            }
        }

        private void dvgDanhSachCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            if (vitri >= 0 && vitri < dvgDanhSachCT.Rows.Count)
            {
                if (ds_ChiTietKM.Tables.Count >= 0 && e.RowIndex < dvgDanhSachCT.Rows.Count)
                {
                    HienThi_TextboxCTKM(ds_ChiTietKM, vitri);
                    ReadOnly_ChiTietKM(true);
                    XuLyChucNangCT(true);
                }
            }
        }

        int flag_CT = 0;
        void XuLyChucNangCT(Boolean t)
        {
            btnThemCT.Enabled = t;
            btnSuaCT.Enabled = t;
            btnXoaCT.Enabled = t;
            btnLuuCT.Enabled = !t;
            btnHuyCT.Enabled = !t;
        }
        void ReadOnly_ChiTietKM(Boolean t)
        {
            cboMaKM_CT.Enabled= !t;
            cboMASP_CT.Enabled = !t;
            cboMaSize_CT.Enabled = !t;
            cboTrangThai_CT.Enabled = !t;
            txtPhanTramGiam_CT.ReadOnly = t;
            txtSoTienGiamToiDa_CT.ReadOnly = t;
        }

        void hienThiComboBox(DataSet ds, System.Windows.Forms.ComboBox cb, string sql, string tencot, string ma)
        {
            ds = khuyenmai.LayDuLieu(sql);
            cb.DisplayMember = tencot;
            cb.ValueMember = ma;
            cb.DataSource = ds.Tables[0];
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            flag_CT = 1;
            ReadOnly_ChiTietKM(false);
            hienThiComboBox(ds_MAKM, cboMaKM_CT, "select * from KHUYENMAI where trangthai != N'Xóa'", "TENKM", "MAKM");
            hienThiComboBox(ds_MASP, cboMASP_CT, "select * from SANPHAM where trangthai != N'Xóa'", "TENSP", "MASP");
            string masp = cboMASP_CT.SelectedValue.ToString();
            hienThiComboBox(ds_MASIZE, cboMaSize_CT, $"select * from CHITIETSANPHAM where MASP ={masp} and TRANGTHAI !=N'Xóa'", "MASIZE", "MASIZE");
            XuLyChucNangCT(false);
        }
        

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (txtPhanTramGiam_CT.Text != "")
            {
                flag_CT = 2;
                XuLyChucNangCT(false);
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn xóa ở danh sách khuyến mãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            if (txtPhanTramGiam_CT.Text != "")
            {
                flag_CT = 3;
                XuLyChucNangCT(false);
                ReadOnly_ChiTietKM(false);
                cboMaKM_CT.Enabled = false;
                cboMaSize_CT.Enabled = false;
                cboMASP_CT.Enabled = false;
                txtSoTienGiamToiDa_CT.ReadOnly = true;
            }
            else
            {
                MessageBox.Show(this, "Bạn chưa chọn thông tin muốn sửa ở danh sách khuyến mãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuyCT_Click(object sender, EventArgs e)
        {
            XuLyChucNangCT(true);
            ReadOnly_ChiTietKM(true);
        }

        void clearCTKM()
        {
            cboMaKM_CT.Text = "";
            cboMaSize_CT.Text = "";
            cboMASP_CT.Text = "";
            cboTrangThai_CT.Text = "";
            txtGiaBan.Text = "";
            txtPhanTramGiam_CT.Text = "";
            txtGiaSauKhiGiam_CT.Text = "";
            txtSoTienGiamToiDa_CT.Text = "";
            txtSoTienGiam_CT.Text = "";
            txtGiaSauKhiGiam_CT.Text = "";
        }
        string tenkm = "";
        DataSet ds_Tenkm;
        
        private void btnLuuCT_Click(object sender, EventArgs e)
        {
            bool stop = false;
            XuLyChucNangCT(true);
            string MASP = "";
            if ( cboMASP_CT.SelectedIndex == -1)
            {
                string tensp = cboMASP_CT.Text;
                if (khuyenmai.LayDuLieu($"select masp from sanpham where tensp like N'%{tensp}%'").Tables[0].Rows.Count==0)
                {
                    MessageBox.Show(this, "Tên sản phẩm nhập không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stop = true;
                }
                MASP = khuyenmai.LayDuLieu($"select masp from sanpham where tensp like N'%{tensp}%'").Tables[0].Rows[0]["MASP"].ToString();
            }
            else
            {
                MASP = cboMASP_CT.SelectedValue.ToString();
            }
            string MASIZE = cboMaSize_CT.SelectedValue.ToString();
            string MAKM = "";
            if (cboMaKM_CT.SelectedIndex == -1)
            {
                string tenkm = cboMaKM_CT.Text;
                if (khuyenmai.LayDuLieu($"select makm from khuyenmai where tenkm = N'{tenkm}'").Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(this, "Tên khuyến mãi nhập không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MAKM = khuyenmai.LayDuLieu($"select MAKM from khuyenmai where tenkm = N'{tenkm}' and trangthai !=N'%x%'").Tables[0].Rows[0]["MAKM"].ToString();
                }
            }
            else
            {
                MAKM = cboMaKM_CT.SelectedValue.ToString();
            }
            string giaban = txtGiaBan.Text.ToString();
            string PHANTRAMGIAM = txtPhanTramGiam_CT.Text;
            string SOTIENGIAM = txtSoTienGiam_CT.Text;
            string GIASAUKHIGIAM = txtGiaSauKhiGiam_CT.Text;
            string trangthai = cboTrangThai_CT.Text;
            string sotiengiamtoida = txtSoTienGiamToiDa_CT.Text;
            
            try
            {
                if (flag_CT == 1)//them
                {
                    if (txtSoTienGiam_CT.Text == "" || cboTrangThai_CT.SelectedIndex == -1 || cboMASP_CT.Text == "" || cboMaSize_CT.Text == "" || txtPhanTramGiam_CT.Text ==""|| txtSoTienGiamToiDa_CT.Text =="")
                    {
                        MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stop = true;
                        XuLyChucNangCT(false);
                    }
                    else if (txtSoTienGiam_CT.Text == "")
                    {
                        MessageBox.Show(this, "Bạn chưa nhập số phần trăm giảm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stop = true;
                        XuLyChucNangCT(false);
                    }
                    else if (cboTrangThai_CT.SelectedIndex == -1)
                    {
                        MessageBox.Show(this, "Bạn chưa chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stop = true;
                        XuLyChucNangCT(false);
                    }
                    else
                    {
                        sql = $"insert CHITIETKM values('{MASP}','{MASIZE}','{MAKM}',{PHANTRAMGIAM},{giaban},{sotiengiamtoida},{SOTIENGIAM},{GIASAUKHIGIAM},N'{trangthai}')";
                    }
                }
                else if (flag_CT == 2)//xoa
                {
                    if (khuyenmai.LayDuLieu($"select * from chitietkm where makm='{makm}'").Tables[0].Rows.Count <= 1)
                    {
                        MessageBox.Show(this, "Một khuyến mãi phải áp dụng ít nhất 1 sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stop = true;
                    }
                    else
                    {
                        sql = $"delete CHITIETKM where MAKM ='{MAKM}' and MASIZE = '{MASIZE}' and MASP = '{MASP}'";
                        string makm = cboMaKM_CT.SelectedValue.ToString();
                        ReadOnly(true);
                        XuLyChucNangCT(true);
                        danhsach_datagridview(ref ds_ChiTietKM, dvgDanhSachCT, $"select * from CHITIETKM where MAKM = '{makm}' and TRANGTHAI !=N'Xóa'");
                    }
                }
                else if (flag_CT == 3)
                {
                    if (txtSoTienGiam_CT.Text == "" || cboTrangThai_CT.SelectedIndex == -1 || cboMASP_CT.Text == "" || cboMaSize_CT.Text == ""|| txtPhanTramGiam_CT.Text == "" || txtSoTienGiamToiDa_CT.Text == "")
                    {
                        MessageBox.Show(this, "Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stop = true;
                        XuLyChucNangCT(false);
                    }
                    else
                    {
                        sql = $"update CHITIETKM set PHANTRAMGIAM ={PHANTRAMGIAM}, SOTIENGIAM = {SOTIENGIAM}, GIASAUKHIGIAM={GIASAUKHIGIAM}, sotiengiamtoida={sotiengiamtoida}, TRANGTHAI=N'{trangthai}' where MAKM = '{MAKM}' and MASIZE = '{MASIZE}' and MASP = '{MASP}'";
                    }
                }

                if(stop==false) 
                {
                    if (khuyenmai.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        KhuyenMai_Load(sender, e);
                        danhsach_datagridview(ref ds_ChiTietKM, dvgDanhSachCT, $"select * from CHITIETKM where MAKM = '{makm}' and TRANGTHAI !=N'Xóa'");
                        ReadOnly_ChiTietKM(true);
                        clearCTKM();
                        XuLyChucNangCT(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Chi tiết đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XuLyChucNangCT(false);
                danhsach_datagridview(ref ds_ChiTietKM, dvgDanhSachCT, $"select * from CHITIETKM where MAKM = '{makm}' and TRANGTHAI !=N'Xóa'");
                ReadOnly_ChiTietKM(true);
            }
        }

        private void cboMASP_CT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag_CT == 1 || flag_CT == 3)
            {
                string masp = cboMASP_CT.SelectedValue.ToString();
                hienThiComboBox(ds_MASIZE, cboMaSize_CT, $"select MASIZE from CHITIETSANPHAM where masp='{masp}' and TRANGTHAI !=N'Xóa'", "MASIZE", "MASIZE");
                cboMaSize_CT.SelectedIndex = -1;
                txtGiaSauKhiGiam_CT.Text = "";
                txtPhanTramGiam_CT.Text = "";
                txtSoTienGiamToiDa_CT.Text = "";
                txtSoTienGiam_CT.Text = "";
            }
        }


        private void cboMaSize_CT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMASP_CT.SelectedIndex != -1 && cboMaSize_CT.SelectedIndex != -1)
            {
                DataSet giaban = new DataSet();
                string masize = cboMaSize_CT.Text.ToString();
                string masp = cboMASP_CT.SelectedValue.ToString();
                giaban = khuyenmai.LayDuLieu($"select GiABAN from CHITIETSANPHAM where MASIZE='{masize}' and MASP ='{masp}'");
                if (giaban.Tables[0].Rows.Count > 0)
                {
                    txtGiaBan.Text = giaban.Tables[0].Rows[0]["GIABAN"].ToString();
                }
            }
        }

        double sotiengiam = 0;
        double giasaukhigiam = 0;
        private void txtPhanTramGiam_CT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(Convert.ToDouble(txtPhanTramGiam_CT.Text)<1 || Convert.ToDouble(txtPhanTramGiam_CT.Text)>100)
                {
                    MessageBox.Show(this, "Bạn chỉ được nhập từ 1-100", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhanTramGiam_CT.Text = "";
                }
                else
                {
                    txtSoTienGiamToiDa_CT.ReadOnly = false;
                    giasaukhigiam = Convert.ToDouble(txtGiaBan.Text) * ((100 - Convert.ToDouble(txtPhanTramGiam_CT.Text)) / 100);
                    sotiengiam = Convert.ToDouble(txtGiaBan.Text) - giasaukhigiam;
                    txtSoTienGiam_CT.Text = sotiengiam.ToString();
                    txtSoTienGiamToiDa_CT.ReadOnly = false;
                }
            }

        }

        private void cboTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboTrangThai_CT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= true;
        }

        private void txtTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))//IsPUNctuation là kiếm tra có phải dấu câu, IsSymbol dùng để kiểm tra ký tự toán học, ký tự đặc biệt dựa trên bảng mã Unicode.
            {
                e.Handled = true;
            }
        }

        private void cboTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtSoTienGiamToiDa_CT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và dấu chấm thập phân
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar) && (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar)) || char.IsLetter(e.KeyChar) || e.KeyChar == (char)22)
            {
                e.Handled = true;
            }
        }

        private void txtSoTienGiamToiDa_CT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sotiengiam < Convert.ToDouble(txtSoTienGiamToiDa_CT.Text))
                {
                    txtGiaSauKhiGiam_CT.Text = (Convert.ToDouble(txtGiaBan.Text) - Convert.ToDouble(txtSoTienGiam_CT.Text)).ToString();  
                }
                else
                {
                    txtGiaSauKhiGiam_CT.Text = (Convert.ToDouble(txtGiaBan.Text) - Convert.ToDouble(txtSoTienGiamToiDa_CT.Text)).ToString();
                }
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            if (khuyenmai.LayDuLieu($"select * from chitietkm where MAKM='{MAKM_them}'").Tables[0].Rows.Count == 0 && ThemKM.Equals("ThemKM Thanh cong"))
            {
                ds_Tenkm = khuyenmai.LayDuLieu($"select tenkm from khuyenmai where makm='{MAKM_them}'");
                tenkm = ds_Tenkm.Tables[0].Rows[0]["TENKM"].ToString();
                MessageBox.Show($"Khuyến mãi {tenkm} mã {MAKM_them} chưa có sản phẩm nào, Bạn hãy nhập sản phẩm cho khuyến mãi này!");
            }
            else
            {
                gboThongTin.Visible = true;
                btnTim.Visible = true;
                gboChucNangKM.Visible = true;
                gboThongTinCT.Visible = false;
                btnTruycap_CT.Visible = true;
            }
        }

        private void btnTruycap_CT_Click(object sender, EventArgs e)
        {
            flag_CT = 0;
            gboThongTin.Visible = false;
            btnTim.Visible = false;
            gboChucNangKM.Visible = false;
            gboThongTinCT.Visible = true;
            gboTimKiem.Visible = false;
            ReadOnly_ChiTietKM(true);
            XuLyChucNangCT(true);
            cboMaKM_CT.Enabled = false;
            btnTruycap_CT.Visible = false;
            cboMaSize_CT.SelectedIndex = -1;
            cboMASP_CT.SelectedIndex = -1;
            txtGiaBan.Text = "";
            cboMaKM_CT.SelectedIndex = -1;
            clearCTKM();
        }

        private void frmKhuyenMai_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ThemKM.Equals("ThemKM Thanh cong"))
            {
                ds_Tenkm = khuyenmai.LayDuLieu($"select tenkm from khuyenmai where makm='{MAKM_them}'");
                tenkm = ds_Tenkm.Tables[0].Rows[0]["TENKM"].ToString();
                if (khuyenmai.LayDuLieu($"select * from chitietkm where MAKM='{MAKM_them}' and trangthai != N'%X%'").Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show($"Khuyến mãi {tenkm} mã {MAKM_them} chưa có sản phẩm nào, Bạn hãy nhập sản phẩm cho khuyến mãi này!");
                    e.Cancel = true;
                }
            }
        }

        private void cboMASP_CT_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (flag_CT == 1)
                {
                    string masp = "";
                    if (cboMASP_CT.SelectedIndex == -1)
                    {
                        string tensp = cboMASP_CT.Text;
                        if (khuyenmai.LayDuLieu($"select masp from sanpham where tensp like N'%{tensp}%' and trangthai != N'%x%'").Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show(this, "Tên sản phẩm nhập không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            masp = khuyenmai.LayDuLieu($"select masp from sanpham where tensp like N'%{tensp}%' and trangthai !=N'%x%'").Tables[0].Rows[0]["MASP"].ToString();
                        }
                    }
                    else
                    {
                        masp = cboMASP_CT.SelectedValue.ToString();
                    }
                    hienThiComboBox(ds_MASIZE, cboMaSize_CT, $"select MASIZE from CHITIETSANPHAM where masp='{masp}' and TRANGTHAI !=N'Xóa'", "MASIZE", "MASIZE");
                    cboMaSize_CT.SelectedIndex = -1;
                    txtGiaSauKhiGiam_CT.Text = "";
                    txtPhanTramGiam_CT.Text = "";
                    txtSoTienGiamToiDa_CT.Text = "";
                    txtSoTienGiam_CT.Text = "";
                }
            }
        }

        private void cboMaKM_CT_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (flag_CT == 1)
                {
                    string makm = "";
                    if(cboMaKM_CT.SelectedIndex == -1)
                    {
                        string tenkm = cboMaKM_CT.Text;
                        if(khuyenmai.LayDuLieu($"select makm from khuyenmai where tenkm = N'{tenkm}'").Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show(this, "Tên khuyến mãi nhập không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            makm = khuyenmai.LayDuLieu($"select MAKM from khuyenmai where tenkm = N'{tenkm}' and trangthai !=N'%x%'").Tables[0].Rows[0]["MAKM"].ToString();
                        }
                    }
                    else
                    {
                        makm = cboMaKM_CT.SelectedValue.ToString();
                    }
                }
            }
        }

        private void cboMaSize_CT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


    }
}
