using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        _9_12_QuanLyQuanCaPhe classTong = new _9_12_QuanLyQuanCaPhe();
        // vị trí được chọn trên datagridview Sản phẩm
        int vitri_SanPham = 0;
        // vị trí được chọn trên datagridview Chi tiết sản phẩm
        int vitri_ChiTietSanPham = 0;
        DataSet ds_SanPham = new DataSet();
        DataSet ds_ChiTietSanPham = new DataSet();
        DataSet ds_NCC = new DataSet();
        DataSet ds_DonViTinh = new DataSet();
        DataSet ds_MASP = new DataSet();
        DataSet ds_MASIZE = new DataSet();
        DataSet ds_KiemTra = new DataSet();
        DataSet ds_LoaiSP = new DataSet();
        int flag = 0;
        bool flag_TimKiem = false;
        // cờ cho các thao tác với Sản Phẩm
        // 1: đang thêm sản phẩm
        // 2: sửa sản phẩm
        // 3: xoá sản phẩm
        int flag_SanPham = 0;
        // cờ cho các thao tác với Chi tiết sản phẩm
        // 1: đang thêm Chi tiết sản phẩm
        // 2: sửa Chi tiết sản phẩm
        // 3: xoá Chi tiết sản phẩm
        int flag_ChiTietSanPham = 0;
        string URLHinhAnh = "";
        string SQL = "";
        public static bool t = true;
        Font fontChung = new Font("Arial", 20);
        DataView dv_NCC = new DataView();
        string rootFolder = Application.StartupPath + "\\HINHANH";

        void danhsach_datagridview(ref DataSet ds, DataGridView dgv, string sql)
        {
            ds = classTong.LayDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        /// <summary>
        /// Hàm có chức năng lấy dữ liệu hiển thị dưới dạng comboBox
        /// Cột hiển thị thường là cột tên, tương ứng với tên chính là mã
        /// </summary>
        /// <param name="ds">Tên của DataSet</param>
        /// <param name="cb">Tên của ComboBox</param>
        /// <param name="sql">Câu lệnh truy vấn SQL</param>
        /// <param name="tencot">Tên cột hiển thị DisplayMember</param>
        /// <param name="ma">Mã tương ứng với cột hiển thị ValueMember</param>
        void hienThiComboBox(ref DataSet ds, ComboBox cb, string sql, string tencot, string ma)
        {
            ds = classTong.LayDuLieu(sql);
            cb.DataSource = ds.Tables[0];
            cb.DisplayMember = tencot;
            cb.ValueMember = ma;
            cb.SelectedIndex = -1;
        }
        /// <summary>
        /// Hàm có chức năng hiển thị comboBox trong datagridview, tức là DataGridViewComboBoxColumn
        /// </summary>
        /// <param name="ds">Tên của DataSet</param>
        /// <param name="tencot_ComboBox">Tên cột là ComboBox trong DataGridView</param>
        /// <param name="sql">Câu lệnh truy vấn SQL</param>
        /// <param name="tencotHienThi">Tên cột hiển thị DisplayMember</param>
        /// <param name="maTuongUngVoiCotHienThi">Mã tương ứng với cột hiển thị ValueMember</param>
        void hienThiComboBoxtrongDataGridView(ref DataSet ds, DataGridViewComboBoxColumn tencot_ComboBox, string sql, string tencotHienThi, string maTuongUngVoiCotHienThi)
        {
            ds = classTong.LayDuLieu(sql);
            tencot_ComboBox.DataSource = ds.Tables[0];
            tencot_ComboBox.DisplayMember = tencotHienThi;
            tencot_ComboBox.ValueMember = maTuongUngVoiCotHienThi;
            // Lặp qua từng ô chứa DataGridViewComboBoxColumn và gọi RefreshEdit
        }
        void locDuLieuComboBox(DataView dv, ComboBox cb, string sql, string tencot, string ma, string giatrimuonloc)
        {
            DataSet ds = new DataSet();
            ds = classTong.LayDuLieu(sql);
            dv.Table = ds.Tables[0];
            dv.RowFilter = $"{ma} = '{giatrimuonloc}'";
            cb.DataSource = dv;
            cb.DisplayMember = tencot;
            cb.ValueMember = ma;
        }
        void XuLyBatTatCacNutChucNang(bool t)
        {
            // lúc load ban đầu các nút cần bật là
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnTimKiem.Enabled = t;
            // các nút cần tắt là
            btnLuu.Enabled = !t;
            btnHuy.Enabled = !t;
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            classTong.CapNhatDuLieu("  update sanpham set soluong =(select sum(soluong) from CHITIETSANPHAM where CHITIETSANPHAM.masp= sanpham.masp and CHITIETSANPHAM.trangthai = N'Hoạt động' group by CHITIETSANPHAM.masp)");
            XuLyBatTatCacNutChucNang(true);
            VoHieuHoa2NutThem(false);
            CacTextboxChiDoc_SanPham(t);
            CacTextboxChiDoc_ChiTietSanPham(t);
            hienThiComboBox(ref ds_NCC, cboMaNCC, "SELECT * FROM NHACC", "TENNCC", "MANCC");
            hienThiComboBox(ref ds_LoaiSP, cboLoaiSanPham, "SELECT * FROM LOAISP", "TENLOAISP", "MALOAISP");
            TaoCotSP();
            TaoCotCTSP();
            danhsach_datagridview(ref ds_SanPham, dgvDanhSachSanPham, "SELECT A.MASP , TENSP, ISNULL(SUM(B.SOLUONG), 0) AS 'SOLUONG',LOAISP, LINK_IMG, A.MOTA, A.TRANGTHAI, MANCC FROM SANPHAM A LEFT OUTER JOIN CHITIETSANPHAM B ON A.MASP = B.MASP AND B.TRANGTHAI = N'Hoạt động' WHERE A.TRANGTHAI = N'Hoạt động' GROUP BY A.MASP, TENSP,LOAISP, LINK_IMG, A.MOTA, A.TRANGTHAI, MANCC");
            hienthi_textbox_SanPham(ds_SanPham, 0);
            dgvDanhSachSanPham.Rows[0].Selected = true;
            ChiTietSanPham_Load(vitri_SanPham, vitri_ChiTietSanPham);
        }
        /// <summary>
        /// Hàm có chức năng Tắt, Bật các nút Button của Sản phẩm
        /// </summary>
        /// <param name="t">Giá trị boolean</param>
        void VoHieuHoa2NutThem(bool t)
        {
            btnThemSanPham.Enabled = t;
            btnThemChiTietSanPham.Enabled = t;
        }
        /// <summary>
        /// Hàm này có chức năng khoá các control của Sản phẩm, ví dụ: textbox: cho readonly, comboBox: cho enabled
        /// </summary>
        /// <param name="t">Giá trị boolean</param>
        void CacTextboxChiDoc_SanPham(bool t)
        {
            txtMaSanPham.ReadOnly = true;
            txtTenSanPham.ReadOnly = t;
            txtSoLuongSanPham.ReadOnly = true;
            rtxtMoTa_SanPham.ReadOnly = t;
            // Bật nút chọn hình ảnh
            btnChonHinhAnh.Enabled = !t;
            cboTrangThai_SanPham.Enabled = !t;
            cboMaNCC.Enabled = !t;
            btnChonHinhAnh.Visible = true;
            cboLoaiSanPham.Enabled = !t;
        }
        /// <summary>
        /// Hàm có chức năng xoá các dữ liệu Sản phẩm trong các control như textbox, comboBox, richtext 
        /// </summary>
        void XoaDuLieuTrongControl_SanPham()
        {
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtSoLuongSanPham.Text = "";
            // Xoá hình ảnh hiện tại
            ptxHinhAnh.Image = null;
            rtxtMoTa_SanPham.Text = "";
            cboTrangThai_SanPham.SelectedIndex = 0;
            cboMaNCC.SelectedIndex = 0;
        }
        /// <summary>
        /// Hàm có chức năng chọn hình ảnh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                URLHinhAnh = openFileDialog.FileName;
                Bitmap a = new Bitmap(URLHinhAnh);
                //ptxHinhAnh.Image = Image.FromFile(URLHinhAnh);
                // textBoxImagePath.Text = openFileDialog.FileName;
            }
        }
        /// <summary>
        /// Hàm có chức năng hiển thị hình ảnh lên pictureBox
        /// </summary>
        /// <param name="URL">Đường dẫn hình ảnh</param>
        private void LoadHinhAnh(string URL)
        {
            ptxHinhAnh.ImageLocation = $@"{URL}";
            // Điều chỉnh kích thước và vị trí của PictureBox
            ptxHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            ptxHinhAnh.Size = new Size(200, 100);
            //ptxHinhAnh.Location = new Point(50, 50);
        }
        /// <summary>
        /// Hàm có chức năng hiển thị dữ liệu Sản phẩm của dòng được CellClick trên DataGridView , lên các textbox, comboBox
        /// </summary>
        /// <param name="ds">Tên của DataSet</param>
        /// <param name="vt">Vị trí dòng được click</param>
        void hienthi_textbox_SanPham(DataSet ds, int vt)
        {
            if (ds_SanPham.Tables.Count > 0)
            {
                if (vt >= 0 && vt < ds.Tables[0].Rows.Count)
                {
                    txtTenSanPham.Text = ds.Tables[0].Rows[vt]["TENSP"].ToString();
                    txtMaSanPham.Text = ds.Tables[0].Rows[vt]["MASP"].ToString();
                    txtSoLuongSanPham.Text = ds.Tables[0].Rows[vt]["SOLUONG"].ToString();
                    cboLoaiSanPham.SelectedValue = ds.Tables[0].Rows[vt]["LOAISP"].ToString();
                    string link = Path.Combine(rootFolder, ds.Tables[0].Rows[vt]["LINK_IMG"].ToString());
                    bool fileExist = File.Exists($@"{link}");
                    if (fileExist)
                    {
                        taoAnhTuFile(ptxHinhAnh, link);
                    }
                    else
                    {
                        ptxHinhAnh.Image = null;
                    }
                    rtxtMoTa_SanPham.Text = ds.Tables[0].Rows[vt]["MOTA"].ToString();
                    cboTrangThai_SanPham.Text = ds.Tables[0].Rows[vt]["TRANGTHAI"].ToString();
                    cboMaNCC.SelectedValue = ds.Tables[0].Rows[vt]["MANCC"].ToString();
                }
            }
            else
            {
                XoaDuLieuTrongControl_SanPham();
            }
        }
        void locdl_theodataview(ComboBox cbo, DataSet ds, string ma, string ten, string giatrima)
        {
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = ma + "='" + giatrima + "'";
            cbo.DataSource = dv;
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
        }
        /// <summary>
        /// Hàm bắt sự kiện CellClick của Sản phẩm
        /// </summary>
        /// <param name="sender">Tín hiệu</param>
        /// <param name="e">Sự kiện</param>
        private void dgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (vitri_SanPham != e.RowIndex)
            {
                vitri_SanPham = e.RowIndex;// Lấy vị trí được chọn
                flag_SanPham = 0;
                if (ds_SanPham.Tables.Count > 0)
                {
                    if (vitri_SanPham >= 0 && vitri_SanPham < dgvDanhSachSanPham.Rows.Count - 1)
                    {
                        hienthi_textbox_SanPham(ds_SanPham, vitri_SanPham);
                        danhsach_datagridview(ref ds_ChiTietSanPham, dgvDanhSachChiTietSanPham, $"SELECT MACTSP,MASIZE,MASP,SOLUONG,MOTA ,GIABAN,GIAVON,TRANGTHAI FROM CHITIETSANPHAM WHERE MASP='{ds_SanPham.Tables[0].Rows[vitri_SanPham]["MASP"]}' AND TRANGTHAI != N'Không hoạt động'");
                        if (ds_ChiTietSanPham.Tables[0].Rows.Count > 0)
                        {
                            hienthi_textbox_ChiTietSanPham(ds_ChiTietSanPham, 0);
                        }
                        else
                        {
                            XoaDuLieuTrongControl_ChiTietSanPham();
                        }
                    }
                    else
                    {
                        dgvDanhSachChiTietSanPham.DataSource = null;
                        TaoCotCTSP();
                        ds_ChiTietSanPham.Tables.Clear();
                        XoaDuLieuTrongControl_ChiTietSanPham();
                    }
                }
            }
        }
        string PhatSinhMa_1()
        {
            string masanpham = "";
            DataSet dsmasp = new DataSet();
            dsmasp = classTong.LayDuLieu("SELECT COUNT(*) AS 'SL' FROM SANPHAM");
            int masp = Convert.ToInt32(dsmasp.Tables[0].Rows[0]["SL"]) + 1;
            masanpham = masp < 10 ? $"0{masp}" : $"{masp}";
            return masanpham;
        }
        private void btnLuuSanPham_Click(object sender, EventArgs e)
        {
            string mancc = "";
            if (cboMaNCC.SelectedIndex == -1)
            {
                MessageBox.Show($"Bạn chưa chọn Nhà cung cấp , Vui lòng chọn Nhà cung cấp !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                mancc = cboMaNCC.SelectedValue.ToString();
            }
            string tensp = txtTenSanPham.Text;
            if (tensp == "")
            {
                MessageBox.Show($"Bạn chưa nhập Tên sản phẩm , Vui lòng nhập Tên sản phẩm !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string masp = txtMaSanPham.Text;
            string soluong = txtSoLuongSanPham.Text;
            string link_img = "";
            if (URLHinhAnh == "")
            {
                MessageBox.Show($"Bạn chưa chọn Hình ảnh , Vui lòng chọn Hình ảnh!!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                link_img = LuuHinhAnh(URLHinhAnh, masp);
            }
            string mota = rtxtMoTa_SanPham.Text;
            string trangthai = cboTrangThai_SanPham.SelectedIndex == 0 ? "Hoạt động" : "Không hoạt động";
            //
            object[] d = new object[7];
            d[0] = masp;
            d[1] = tensp;
            d[2] = soluong;
            d[3] = link_img;
            d[4] = mota;
            d[5] = trangthai;
            d[6] = mancc;
            dgvDanhSachSanPham.Rows.Add(d);
        }
        private void btnHuySanPham_Click(object sender, EventArgs e)
        {
            XoaDuLieuTrongControl_SanPham();
            frmSanPham_Load(sender, e);
            if (vitri_SanPham >= 0 && vitri_SanPham < ds_SanPham.Tables[0].Rows.Count - 1)
            {
                hienthi_textbox_SanPham(ds_SanPham, vitri_SanPham);
                danhsach_datagridview(ref ds_ChiTietSanPham, dgvDanhSachChiTietSanPham, $"SELECT MACTSP,MASIZE,MASP,SOLUONG,MOTA ,GIABAN,GIAVON,TRANGTHAI FROM CHITIETSANPHAM WHERE MASP='{ds_SanPham.Tables[0].Rows[vitri_SanPham]["MASP"]}' AND TRANGTHAI != N'Không hoạt động'");
                hienthi_textbox_ChiTietSanPham(ds_ChiTietSanPham, vitri_SanPham);
            }
            CacTextboxChiDoc_SanPham(true);
            flag = 0;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            XuLyBatTatCacNutChucNang(false);
            CacTextboxChiDoc_SanPham(false);
            CacTextboxChiDoc_ChiTietSanPham(false);
            cboMaSize.Enabled = false;
            cboMaNCC.Enabled = false;
            flag = 2;
        }
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            string mancc = "";
            if (cboMaNCC.SelectedIndex == -1)
            {
                MessageBox.Show($"Bạn chưa chọn Nhà cung cấp , Vui lòng chọn Nhà cung cấp !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                mancc = cboMaNCC.SelectedValue.ToString();
            }
            string tensp = txtTenSanPham.Text;
            if (tensp == "")
            {
                MessageBox.Show($"Bạn chưa nhập Tên sản phẩm , Vui lòng nhập Tên sản phẩm !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //
            string masp = txtMaSanPham.Text;
            string soluong = txtSoLuongSanPham.Text;
            string link_img = "";
            if (URLHinhAnh == "")
            {
                MessageBox.Show($"Bạn chưa chọn Hình ảnh , Vui lòng chọn Hình ảnh!!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                link_img = LuuHinhAnh(URLHinhAnh, masp);
            }
            string loaisp = "";
            if (cboLoaiSanPham.SelectedIndex == -1)
            {
                MessageBox.Show($"Bạn chưa chọn Loại sản phẩm , Vui lòng chọn Loại sản phẩm !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                loaisp = cboLoaiSanPham.SelectedValue.ToString();
            }
            string mota = rtxtMoTa_SanPham.Text;
            string trangthai = cboTrangThai_SanPham.SelectedItem.ToString();
            //
            object[] d = new object[8];
            d[0] = masp;
            d[1] = tensp;
            d[2] = soluong;
            d[3] = link_img;
            d[4] = mota;
            d[5] = loaisp;
            d[6] = mancc;
            d[7] = trangthai;
            dgvDanhSachSanPham.Rows.Add(d);
        }
        void chonHinhAnh(PictureBox pic)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    URLHinhAnh = openFileDialog.FileName;
                    taoAnhTuFile(ptxHinhAnh, URLHinhAnh);
                }
                // Sử dụng hình ảnh trong ứng dụng của bạn
                catch (IOException ex)
                {
                    MessageBox.Show("Tệp tin đang được sử dụng bởi một tiến trình khác.");
                }
            }
        }
        void taoAnhTuFile(PictureBox ptx, string duongdan)
        {
            try
            {
                Bitmap bm = new Bitmap(duongdan);
                ptx.Image = bm;
                ptx.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            // Sử dụng hình ảnh trong ứng dụng của bạn
            catch (IOException ex)
            {
                MessageBox.Show("Ảnh hiển thị bị lỗi.");
            }
        }
        /// <summary>
        /// Hàm có chức năng lưu hình ảnh vào đường dẫn mới được chỉ định
        /// </summary>
        /// <returns>Đường dẫn mới của hình ảnh</returns>
        string LuuHinhAnh(string url, string newFileName)
        {
            if (File.Exists(url))
            {
                string oldImagePath = Path.GetFullPath(url);
                string newImagePath = rootFolder; // Đường dẫn mới.
                string oldFileName = Path.GetFileName(url);
                string[] oldFileNameArray = oldFileName.Split('.');
                string extension = oldFileNameArray[oldFileNameArray.Length - 1];
                newFileName += $".{extension}";
                newImagePath += Path.Combine(rootFolder, newFileName);
                // Thực hiện sao chép hình ảnh vào đường dẫn mới
                try
                {
                    File.Copy(oldImagePath, newImagePath, true);
                    // Sử dụng hình ảnh trong ứng dụng của bạn
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Tệp tin đang được sử dụng bởi một tiến trình khác." + ex.Message);
                }
                return newFileName;
            }
            return "";
        }
        private void dgvDanhSachSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (t)
            {
                if (e.ColumnIndex >= 1 && e.RowIndex < dgvDanhSachSanPham.Rows.Count)
                {
                    // Lấy vị trí( hàng đã chọn)
                    vitri_SanPham = dgvDanhSachSanPham.CurrentRow.Index;
                }
            }
        }
        // Phần code của Chi tiết sản phẩm
        /// <summary>
        /// Hàm có chức năng hiển thị dữ liệu Chi tiết Sản phẩm của dòng được CellClick trên DataGridView , lên các textbox, comboBox
        /// </summary>
        /// <param name="ds">Tên của DataSet</param>
        /// <param name="vt">Vị trí dòng được click</param>
        void hienthi_textbox_ChiTietSanPham(DataSet ds, int vt)
        {
            if (ds.Tables.Count > 0)
            {
                if (vt >= 0 && vt < ds.Tables[0].Rows.Count && ds.Tables[0].Rows.Count > 0)
                {
                    txtMaChiTietSanPham.Text = ds.Tables[0].Rows[vt]["MACTSP"].ToString();
                    cboMaSize.SelectedValue = ds.Tables[0].Rows[vt]["MASIZE"].ToString();
                    nupSoLuongChiTietSanPham.Value = int.Parse(ds.Tables[0].Rows[vt]["SOLUONG"].ToString());
                    rtxtMoTa_ChiTietSanPham.Text = ds.Tables[0].Rows[vt]["MOTA"].ToString();
                    nupGiaBan.Value = decimal.Parse(ds.Tables[0].Rows[vt]["GIABAN"].ToString());
                    nupGiaVon.Value = decimal.Parse(ds.Tables[0].Rows[vt]["GIAVON"].ToString());
                    cboTrangThai_ChiTietSanPham.Text = ds.Tables[0].Rows[vt]["TRANGTHAI"].ToString();
                }
                else
                {
                    XoaDuLieuTrongControl_ChiTietSanPham();
                }
            }
            else
            {
                XoaDuLieuTrongControl_ChiTietSanPham();
            }
        }
        /// <summary>
        /// Hàm này có chức năng truy vấn dữ liệu của bảng Chi tiết sản phẩm, và hiển thị lên DataGridView
        /// </summary>
        /// <param name="d">Tên của DataGridView</param>
        /// <param name="sql">Câu lệnh truy vấn Ví dụ: SELECT * FROM CHITIETSANPHAM</param>
        void danhsach_datagridview_ChiTietSanPham(DataGridView d, string sql)
        {
            ds_ChiTietSanPham = classTong.LayDuLieu(sql);
            d.DataSource = ds_ChiTietSanPham.Tables[0];
        }
        void ChiTietSanPham_Load(int vtsp, int vtctsp)
        {
            hienThiComboBox(ref ds_MASIZE, cboMaSize, "SELECT * FROM SIZE", "MOTA", "MASIZE");
            if (ds_SanPham.Tables[0].Rows.Count > 0)
            {
                danhsach_datagridview(ref ds_ChiTietSanPham, dgvDanhSachChiTietSanPham, $"SELECT MACTSP,MASIZE,MASP,SOLUONG,MOTA ,GIABAN,GIAVON,TRANGTHAI FROM CHITIETSANPHAM WHERE MASP='{ds_SanPham.Tables[0].Rows[0]["MASP"]}' AND TRANGTHAI != N'Không hoạt động'");
                if (ds_ChiTietSanPham.Tables[0].Rows.Count > 0)
                {
                    dgvDanhSachChiTietSanPham.Rows[0].Selected = true;
                    hienthi_textbox_ChiTietSanPham(ds_ChiTietSanPham, 0);
                }
            }
        }
        /// <summary>
        /// Hàm có chức năng Tắt, Bật các nút Button của Chi tiết sản phẩm
        /// </summary>
        /// </summary>
        /// <param name="t">Giá trị boolean</param>
        /// <param name="t">Giá trị boolean</param>
        /// <summary>
        /// Hàm có chức năng xoá các dữ liệu Chi tiết Sản phẩm trong các control như textbox, comboBox, richtext 
        /// </summary>
        void XoaDuLieuTrongControl_ChiTietSanPham()
        {
            txtMaChiTietSanPham.Text = "";
            cboMaSize.SelectedIndex = -1;
            nupSoLuongChiTietSanPham.Value = 0;
            rtxtMoTa_ChiTietSanPham.Text = "";
            nupGiaBan.Value = 0;
            nupGiaVon.Value = 0;
            cboTrangThai_ChiTietSanPham.SelectedIndex = -1;
        }
        /// <summary>
        /// Hàm này có chức năng khoá các control của Chi tiết Sản phẩm, ví dụ: textbox: cho readonly, comboBox: cho enabled
        /// </summary>
        /// <param name="t">Giá trị boolean</param>
        void CacTextboxChiDoc_ChiTietSanPham(bool t)
        {
            txtMaChiTietSanPham.ReadOnly = true;
            cboMaSize.Enabled = !t;
            nupSoLuongChiTietSanPham.Enabled = !t;
            rtxtMoTa_ChiTietSanPham.ReadOnly = t;
            nupGiaBan.Enabled = false;
            nupGiaVon.Enabled = !t;
            cboTrangThai_ChiTietSanPham.Enabled = !t;
        }
        private void dgvDanhSachChiTietSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (t)
            {
                if (e.ColumnIndex == 3 && e.RowIndex < dgvDanhSachChiTietSanPham.Rows.Count - 1)
                {
                    // Lấy vị trí( hàng đã chọn)
                    int hangdachon = e.RowIndex;
                    string mactsp = dgvDanhSachChiTietSanPham.Rows[hangdachon].Cells[0].Value.ToString();
                    int soluong = Convert.ToInt32(dgvDanhSachChiTietSanPham.Rows[e.RowIndex].Cells[3].Value.ToString());
                    nupSoLuongChiTietSanPham.Value = soluong;
                    int tong = 0;
                    for (int i = 0; i < dgvDanhSachChiTietSanPham.Rows.Count - 1; i++)
                    {
                        // Lấy giá trị từng cột trong dòng hiện tại
                        int soluong_ = Convert.ToInt32(dgvDanhSachChiTietSanPham.Rows[i].Cells[3].Value.ToString());
                        tong += soluong_;
                    }
                    txtSoLuongSanPham.Text = tong.ToString();
                    dgvDanhSachSanPham.Rows[vitri_SanPham].Cells[2].Value = tong.ToString();
                    string sql = $"UPDATE SANPHAM SET SOLUONG = {tong} where MASP = '{txtMaSanPham.Text}'";
                    int row1 = classTong.CapNhatDuLieu(sql);
                    string sqlCTSP = $"UPDATE CHITIETSANPHAM SET SOLUONG = {soluong}   WHERE MACTSP = '{mactsp}'";
                    int row2 = classTong.CapNhatDuLieu(sqlCTSP);
                    if (row1 > 0 && row2 > 0)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo");
                    }
                }
            }
        }
        void TaoCotSP()
        {
            // Tạo đối tượng DataGridViewColumn cho cột tên
            DataGridViewColumn MASP = new DataGridViewTextBoxColumn();
            MASP.HeaderText = "Mã SP";
            MASP.DataPropertyName = "MASP"; // Chỉ định tên thuộc tính dữ liệu
            MASP.ReadOnly = true;                              //
            DataGridViewColumn TENSP = new DataGridViewTextBoxColumn();
            TENSP.HeaderText = "Tên SP";
            TENSP.DataPropertyName = "TENSP"; // Chỉ định tên thuộc tính dữ liệu
            TENSP.ReadOnly = true;                                //
            // 
            DataGridViewColumn SOLUONG = new DataGridViewTextBoxColumn();
            SOLUONG.HeaderText = "SỐ LƯỢNG";
            SOLUONG.DataPropertyName = "SOLUONG"; // Chỉ định tên thuộc tính dữ liệu
            SOLUONG.ReadOnly = true;
            DataGridViewColumn LINK_IMG = new DataGridViewTextBoxColumn();
            LINK_IMG.HeaderText = "ĐƯỜNG DẪN HÌNH ẢNH";
            LINK_IMG.DataPropertyName = "LINK_IMG"; // Chỉ định tên thuộc tính dữ liệu
            LINK_IMG.ReadOnly = true;
            LINK_IMG.Visible = false;
            DataGridViewColumn DONVITINH = new DataGridViewTextBoxColumn();
            DONVITINH.HeaderText = "ĐƠN VỊ TÍNH";
            DONVITINH.DataPropertyName = "DONVITINH"; // Chỉ định tên thuộc tính dữ liệu
            DONVITINH.ReadOnly = true;
            DataGridViewColumn MOTA = new DataGridViewTextBoxColumn();
            MOTA.HeaderText = "MÔ TẢ";
            MOTA.DataPropertyName = "MOTA"; // Chỉ định tên thuộc tính dữ liệu
            MOTA.ReadOnly = true;
            DataGridViewColumn LOAISP = new DataGridViewTextBoxColumn();
            LOAISP.HeaderText = "LOẠI SP";
            LOAISP.DataPropertyName = "LOAISP"; // Chỉ định tên thuộc tính dữ liệu
            LOAISP.ReadOnly = true;

            DataGridViewColumn MANCC = new DataGridViewTextBoxColumn();
            MANCC.HeaderText = "MÃ NHÀ CUNG CẤP";
            MANCC.DataPropertyName = "MANCC"; // Chỉ định tên thuộc tính dữ liệu
            MANCC.ReadOnly = true;
            DataGridViewColumn TRANGTHAI = new DataGridViewTextBoxColumn();
            TRANGTHAI.HeaderText = "TRẠNG THÁI";
            TRANGTHAI.DataPropertyName = "TRANGTHAI"; // Chỉ định tên thuộc tính dữ liệu
            TRANGTHAI.ReadOnly = true;
            dgvDanhSachSanPham.DataSource = null;
            dgvDanhSachSanPham.Columns.Clear();
            dgvDanhSachSanPham.Columns.Add(MASP);
            dgvDanhSachSanPham.Columns.Add(TENSP);
            dgvDanhSachSanPham.Columns.Add(SOLUONG);
            dgvDanhSachSanPham.Columns.Add(LINK_IMG);
            dgvDanhSachSanPham.Columns.Add(MOTA);
            dgvDanhSachSanPham.Columns.Add(LOAISP);
            dgvDanhSachSanPham.Columns.Add(MANCC);
            dgvDanhSachSanPham.Columns.Add(TRANGTHAI);

        }
        void TaoCotCTSP()
        {
            //
            DataGridViewColumn MACTSP = new DataGridViewTextBoxColumn();
            MACTSP.HeaderText = "Mã CTSP";
            MACTSP.DataPropertyName = "MACTSP"; // Chỉ định tên thuộc tính dữ liệu
            MACTSP.ReadOnly = true;
            DataGridViewColumn MASP = new DataGridViewTextBoxColumn();
            MASP.HeaderText = "MÃ SP";
            MASP.DataPropertyName = "MASP"; // Chỉ định tên thuộc tính dữ liệu
            MASP.ReadOnly = true;
            DataGridViewColumn MASIZE = new DataGridViewTextBoxColumn();
            MASIZE.HeaderText = "MÃ SIZE";
            MASIZE.DataPropertyName = "MASIZE"; // Chỉ định tên thuộc tính dữ liệu
            MASIZE.ReadOnly = true;
            DataGridViewColumn SOLUONG = new DataGridViewTextBoxColumn();
            SOLUONG.HeaderText = "SỐ LƯỢNG";
            SOLUONG.DataPropertyName = "SOLUONG"; // Chỉ định tên thuộc tính dữ liệu
            SOLUONG.ReadOnly = false;
            DataGridViewColumn MOTA = new DataGridViewTextBoxColumn();
            MOTA.HeaderText = "MÔ TẢ";
            MOTA.DataPropertyName = "MOTA"; // Chỉ định tên thuộc tính dữ liệu
            MOTA.ReadOnly = true;
            DataGridViewColumn GIAVON = new DataGridViewTextBoxColumn();
            GIAVON.HeaderText = "GIÁ VỐN";
            GIAVON.DataPropertyName = "GIAVON"; // Chỉ định tên thuộc tính dữ liệu
            GIAVON.ReadOnly = true;
            DataGridViewColumn GIABAN = new DataGridViewTextBoxColumn();
            GIABAN.HeaderText = "GIÁ BÁN";
            GIABAN.DataPropertyName = "GIABAN"; // Chỉ định tên thuộc tính dữ liệu
            GIABAN.ReadOnly = true;
            DataGridViewColumn TRANGTHAI = new DataGridViewTextBoxColumn();
            TRANGTHAI.HeaderText = "TRẠNG THÁI";
            TRANGTHAI.DataPropertyName = "TRANGTHAI"; // Chỉ định tên thuộc tính dữ liệu
            TRANGTHAI.ReadOnly = true;
            //
            dgvDanhSachChiTietSanPham.DataSource = null;
            dgvDanhSachChiTietSanPham.Columns.Clear();
            dgvDanhSachChiTietSanPham.Columns.Add(MACTSP);
            dgvDanhSachChiTietSanPham.Columns.Add(MASP);
            dgvDanhSachChiTietSanPham.Columns.Add(MASIZE);
            dgvDanhSachChiTietSanPham.Columns.Add(SOLUONG);
            dgvDanhSachChiTietSanPham.Columns.Add(MOTA);
            dgvDanhSachChiTietSanPham.Columns.Add(GIAVON);
            dgvDanhSachChiTietSanPham.Columns.Add(GIABAN);
            dgvDanhSachChiTietSanPham.Columns.Add(TRANGTHAI);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            XuLyBatTatCacNutChucNang(false);
            VoHieuHoa2NutThem(true);
            XoaDuLieuTrongControl_SanPham();
            XoaDuLieuTrongControl_ChiTietSanPham();
            txtSoLuongSanPham.Text = "0";
            CacTextboxChiDoc_SanPham(false);
            CacTextboxChiDoc_ChiTietSanPham(false);
            dgvDanhSachSanPham.DataSource = null;
            dgvDanhSachChiTietSanPham.DataSource = null;
            TaoCotSP();
            TaoCotCTSP();
            cboTrangThai_ChiTietSanPham.SelectedIndex = 0;
        }
        private void btnThemChiTietSanPham_Click(object sender, EventArgs e)
        {
            string mactsp = txtMaChiTietSanPham.Text;
            if (KiemTraTrungMACTSPtrongDataGridView(mactsp))
            {
                return;
            }
            string masp = txtMaSanPham.Text;
            string masize = "";
            if (cboMaSize.SelectedIndex == -1)
            {
                MessageBox.Show($"Bạn chưa chọn Tên size , Vui lòng chọn Tên Size !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                masize = cboMaSize.SelectedValue.ToString();
            }
            int soluong = Convert.ToInt32(nupSoLuongChiTietSanPham.Value);
            string mota = rtxtMoTa_ChiTietSanPham.Text;
            int giaban = Convert.ToInt32(nupGiaBan.Value);
            int giavon = Convert.ToInt32(nupGiaVon.Value);
            if (giavon == 0)
            {
                MessageBox.Show($"Bạn chưa nhập Giá vốn , Vui lòng nhập Giá vốn !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string trangthai = cboTrangThai_ChiTietSanPham.Text;
            object[] d = new object[8];
            d[0] = mactsp;
            d[1] = masp;
            d[2] = masize;
            d[3] = soluong.ToString();
            d[4] = mota;
            d[5] = giavon.ToString();
            d[6] = giaban.ToString();
            d[7] = trangthai;
            dgvDanhSachChiTietSanPham.Rows.Add(d);
            XoaDuLieuTrongControl_ChiTietSanPham();
            cboTrangThai_ChiTietSanPham.SelectedIndex = 0;
        }
        private void btnThoatChiTietSanPham_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Bắt sự kiện SelectedIndexChanged của cboMaSanPham, sẽ tự động cập nhật Mã chi tiết sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// Bắt sự kiện SelectedIndexChanged của cboMaSanPham, sẽ tự động cập nhật Mã chi tiết sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMaSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t && (flag == 1 || flag == 2))
            {
                if (cboMaSize.SelectedIndex != -1)
                {
                    string selectedValue = cboMaSize.SelectedValue.ToString();
                    txtMaChiTietSanPham.Text = txtMaSanPham.Text + "." + selectedValue;
                    rtxtMoTa_ChiTietSanPham.Text = txtTenSanPham.Text + " " + cboMaSize.Text;
                }
            }
        }
        /// <summary>
        /// Hàm có chức năng kiểm tra Mã chi tiết sản phẩm có tồn tại chưa, nếu có thì thông báo lỗi
        /// </summary>
        /// <param name="mactsp">Mã chi tiết sản phẩm</param>
        bool KiemTraTrungMACTSP(string mactsp)
        {
            ds_KiemTra = classTong.LayDuLieu($"SELECT * FROM CHITIETSANPHAM WHERE MACTSP = '{mactsp}'");
            if (ds_KiemTra.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show($"Đã tồn tại sản phẩm và size có kích thước đã chọn , Vui lòng chọn lại sản phẩm và size khác !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        bool KiemTraTrungMACTSPtrongDataGridView(string mactsp)
        {
            for (int i = 0; i < dgvDanhSachChiTietSanPham.Rows.Count - 1; i++)
            {
                string mactspDataGridView = dgvDanhSachChiTietSanPham.Rows[i].Cells[0].Value.ToString();
                if (mactsp == mactspDataGridView)
                {
                    MessageBox.Show($"Đã tồn tại sản phẩm và size có kích thước đã chọn , Vui lòng chọn lại sản phẩm và size khác !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Hàm bắt sự kiện CellClick của Chi tiết Sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDanhSachChiTietSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri_ChiTietSanPham = e.RowIndex;// Lấy vị trí được chọn
            if (vitri_ChiTietSanPham >= 0 && vitri_ChiTietSanPham < dgvDanhSachChiTietSanPham.Rows.Count)
            {
                hienthi_textbox_ChiTietSanPham(ds_ChiTietSanPham, vitri_ChiTietSanPham);
            }
            else
            {
                XoaDuLieuTrongControl_ChiTietSanPham();
            }
        }
        int RemoveZero(int number)
        {
            string numberStr = number.ToString(); // Chuyển đổi số thành chuỗi
                                                  // Cắt bỏ các ký tự '0' không cần thiết từ đầu chuỗi
            while (numberStr.Length > 1 && numberStr[0] == '0')
            {
                numberStr = numberStr.Substring(1);
            }
            return int.Parse(numberStr); // Chuyển đổi chuỗi thành số nguyên và trả về giá trị
        }
        void ChiNhapSo(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        void KiemTraDuLieuTextBoxCoPhaiLaSo(TextBox txt)
        {
            if (flag_ChiTietSanPham == 1 || flag_ChiTietSanPham == 2)
            {
                double number = 0;
                bool isNumber = double.TryParse(txt.Text, out number);
                if (!isNumber)
                {
                    MessageBox.Show("Dữ liệu ô bạn nhập phải là một số !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt.Text = "";
                }
                else
                {

                }
            }
        }
        private void btnChonHinhAnh_Click(object sender, EventArgs e)
        {
            chonHinhAnh(ptxHinhAnh);
        }
        string AddZero(string n)
        {
            string str = "";
            if (n.Length == 1)
            {
                str = "00" + n;
            }
            else if (n.Length == 2)
            {
                str = "0" + n;
            }
            else
            {
                str = "" + n;
            }
            return str;
        }
        private void cboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNCC.SelectedIndex != -1 && flag == 1)
            {
                string manccc = cboMaNCC.SelectedValue.ToString();
                string sql = $"SELECT MASP FROM SANPHAM WHERE MANCC='{manccc}'";
                string masp = "";
                ds_KiemTra = classTong.LayDuLieu(sql);
                if (ds_KiemTra.Tables[0].Rows.Count > 0 && ds_KiemTra.Tables[0].Rows.Count < 9)
                {
                    masp = manccc + "." + AddZero((ds_KiemTra.Tables[0].Rows.Count + 1).ToString());
                }
                else
                {
                    masp = manccc + "." + AddZero((ds_KiemTra.Tables[0].Rows.Count + 1).ToString());
                }
                txtMaSanPham.Text = masp;
            }
        }
        private void nupGiaVon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (nupGiaVon.Value <= 30000)
                {
                    nupGiaBan.Value = Math.Ceiling(((nupGiaVon.Value) * (decimal)2.5) / 1000) * 1000;
                }
                else if (nupGiaVon.Value > 30000 && nupGiaVon.Value <= 50000)
                {
                    nupGiaBan.Value = Math.Ceiling(((nupGiaVon.Value) * (decimal)2.3) / 1000) * 1000;
                }
                else if (nupGiaVon.Value > 50000)
                {
                    nupGiaBan.Value = Math.Ceiling(((nupGiaVon.Value) * (decimal)2) / 1000) * 1000;
                }
            }
        }
        private void dgvDanhSachSanPham_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (flag == 1)
            {
                if (dgvDanhSachSanPham.RowCount > 1)
                {
                    CacTextboxChiDoc_ChiTietSanPham(false);
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (flag)
            {
                case 1:

                    {
                        for (int i = 0; i < dgvDanhSachSanPham.Rows.Count - 1; i++)
                        {
                            // Lấy giá trị từng cột trong dòng hiện tại
                            string masp = dgvDanhSachSanPham.Rows[i].Cells[0].Value.ToString();
                            string tensp = dgvDanhSachSanPham.Rows[i].Cells[1].Value.ToString();
                            int soluong = Convert.ToInt32(dgvDanhSachSanPham.Rows[i].Cells[2].Value.ToString());
                            string link_img = dgvDanhSachSanPham.Rows[i].Cells[3].Value.ToString();
                            string mota = dgvDanhSachSanPham.Rows[i].Cells[4].Value.ToString();
                            string loaisp = dgvDanhSachSanPham.Rows[i].Cells[5].Value.ToString();
                            string mancc = dgvDanhSachSanPham.Rows[i].Cells[6].Value.ToString();
                            string trangthai = dgvDanhSachSanPham.Rows[i].Cells[7].Value.ToString();
                            // Truy vấn SQL
                            string sqlSP = $"INSERT INTO SANPHAM VALUES ('{masp}',N'{tensp}',{soluong},N'{link_img}',N'{mota}','{mancc}','{loaisp}',N'{trangthai}')";
                            int row = classTong.CapNhatDuLieu(sqlSP);
                            if (row > 0)
                            {
                                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
                            }
                        }
           ;
                        for (int i = 0; i < dgvDanhSachChiTietSanPham.Rows.Count - 1; i++)
                        {
                            // Lấy giá trị từng cột trong dòng hiện tại
                            string mactsp = dgvDanhSachChiTietSanPham.Rows[i].Cells[0].Value.ToString();
                            string masp = dgvDanhSachChiTietSanPham.Rows[i].Cells[1].Value.ToString();
                            string masize = dgvDanhSachChiTietSanPham.Rows[i].Cells[2].Value.ToString();
                            int soluong = Convert.ToInt32(dgvDanhSachChiTietSanPham.Rows[i].Cells[3].Value.ToString());
                            string mota = dgvDanhSachChiTietSanPham.Rows[i].Cells[4].Value.ToString();
                            int giavon = Convert.ToInt32(dgvDanhSachChiTietSanPham.Rows[i].Cells[5].Value.ToString());
                            int giaban = Convert.ToInt32(dgvDanhSachChiTietSanPham.Rows[i].Cells[6].Value.ToString());
                            string trangthai = dgvDanhSachChiTietSanPham.Rows[i].Cells[7].Value.ToString();
                            // Truy vấn SQL
                            string sqlSP = $"INSERT INTO CHITIETSANPHAM VALUES ('{mactsp}','{masp}','{masize}',{soluong},N'{mota}',{giavon},{giaban},N'{trangthai}')";
                            int row = classTong.CapNhatDuLieu(sqlSP);
                            if (row > 0)
                            {
                                MessageBox.Show("Thêm chi tiết sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
                                classTong.CapNhatDuLieu("UPDATE sanpham SET soluong = (SELECT SUM(soluong) FROM chitietsanpham WHERE chitietsanpham.masp = sanpham.masp and CHITIETSANPHAM.TRANGTHAI = 'Hoạt động' )");
                            }
                        }
                        break;
                    }
                case 2:
                    {

                        string mancc = "";
                        if (cboMaNCC.SelectedIndex == -1)
                        {
                            MessageBox.Show($"Bạn chưa chọn Nhà cung cấp , Vui lòng chọn Nhà cung cấp !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            mancc = cboMaNCC.SelectedValue.ToString();
                        }
                        string tensp = txtTenSanPham.Text;
                        if (tensp == "")
                        {
                            MessageBox.Show($"Bạn chưa nhập Tên sản phẩm , Vui lòng nhập Tên sản phẩm !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //
                        string masp = txtMaSanPham.Text;
                        int soluong = Convert.ToInt32(txtSoLuongSanPham.Text);
                        string link_img = LuuHinhAnh(URLHinhAnh, masp);
                        string loaisp = "";
                        if (cboLoaiSanPham.SelectedIndex == -1)
                        {
                            MessageBox.Show($"Bạn chưa chọn Loại sản phẩm , Vui lòng chọn Loại sản phẩm !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            loaisp = cboLoaiSanPham.SelectedValue.ToString();
                        }
                        string mota = rtxtMoTa_SanPham.Text;
                        string trangthai = cboTrangThai_SanPham.SelectedItem.ToString();
                        //
                        //object[] d = new object[8];
                        //d[0] = masp;
                        //d[1] = tensp;
                        //d[2] = soluong;
                        //d[3] = link_img;
                        //d[4] = mota;
                        //d[5] = loaisp;
                        //d[6] = mancc;
                        //d[7] = trangthai;
                        string sqlSP = "";
                        if (link_img != "")
                        {
                            sqlSP = $"UPDATE SANPHAM SET TENSP=N'{tensp}', SOLUONG={soluong},LINK_IMG=N'{link_img}',MOTA=N'{mota}',loaisp='{loaisp}',MANCC = '{mancc}',trangthai=N'{trangthai}' WHERE MASP = '{masp}'";
                        }
                        else
                        {
                            sqlSP = $"UPDATE SANPHAM SET TENSP=N'{tensp}', SOLUONG={soluong},MOTA=N'{mota}',loaisp='{loaisp}',MANCC = '{mancc}',trangthai=N'{trangthai}' WHERE MASP = '{masp}'";
                        }
                        int row = classTong.CapNhatDuLieu(sqlSP);
                        if (row > 0)
                        {
                            MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
                        }
                        // Cập nhật chi tiết sản phẩm
                        string mactsp = txtMaChiTietSanPham.Text;
                        //string masp = txtMaSanPham.Text;
                        string masize = cboMaSize.SelectedValue.ToString();

                        int soluongctsp = Convert.ToInt32(nupSoLuongChiTietSanPham.Value);
                        string motactsp = rtxtMoTa_ChiTietSanPham.Text;
                        int giaban = Convert.ToInt32(nupGiaBan.Value);
                        int giavon = Convert.ToInt32(nupGiaVon.Value);
                        if (giavon == 0)
                        {
                            MessageBox.Show($"Bạn chưa nhập Giá vốn , Vui lòng nhập Giá vốn !!! ", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string trangthaictsp = cboTrangThai_ChiTietSanPham.Text;
                        string sqlCTSP = $"UPDATE CHITIETSANPHAM SET SOLUONG ={soluongctsp}, MOTA = N'{motactsp}',GIAVON = {giavon},GIABAN = {giaban},TRANGTHAI = N'{trangthaictsp}' WHERE MACTSP = '{mactsp}'";
                        int rowCTSP = classTong.CapNhatDuLieu(sqlCTSP);
                        if (rowCTSP > 0)
                        {
                            MessageBox.Show("Cập nhật Chi tiết sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
                            classTong.CapNhatDuLieu("UPDATE sanpham SET soluong = (SELECT SUM(soluong) FROM chitietsanpham WHERE chitietsanpham.masp = sanpham.masp and CHITIETSANPHAM.TRANGTHAI = 'Hoạt động' )");
                        }
                        if (flag_TimKiem)
                        {
                            btnTimKiem_Click(sender, e);
                        }
                        break;
                    }
                // Xoá
                case 3:
                    {
                        DialogResult dlgThoat;
                        string masp = txtMaSanPham.Text;
                        string tensp = txtTenSanPham.Text;
                        dlgThoat = MessageBox.Show($"Bạn có chắc muốn Xoá sản phẩm có Mã {masp} - {tensp}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgThoat == DialogResult.Yes)
                        {
                            string sql = $"UPDATE SANPHAM SET TRANGTHAI=N'Không hoạt động' WHERE MASP='{masp}'";
                            int row = classTong.CapNhatDuLieu(sql);
                            if (row > 0)
                            {
                                MessageBox.Show("Xoá sản phẩm thành công !!!", "Thông báo", MessageBoxButtons.OK);
                                classTong.CapNhatDuLieu("UPDATE sanpham SET soluong = (SELECT SUM(soluong) FROM chitietsanpham WHERE chitietsanpham.masp = sanpham.masp and CHITIETSANPHAM.TRANGTHAI = 'Hoạt động' )");
                                frmSanPham_Load(sender, e);
                            }
                        }
                        if (flag_TimKiem)
                        {
                            btnTimKiem_Click(sender, e);
                        }
                        break;
                    }
            }

            flag = 0;
            URLHinhAnh = "";
            frmSanPham_Load(sender, e);

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show($"Bạn có chắc muốn Đóng form Sản Phẩm ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgThoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XuLyBatTatCacNutChucNang(false);
            CacTextboxChiDoc_SanPham(false);
            CacTextboxChiDoc_ChiTietSanPham(false);
            flag = 3;
        }

        private void txtTenSanPham_TextChanged(object sender, EventArgs e)
        {
            rtxtMoTa_SanPham.Text = txtTenSanPham.Text + " thức uống có vị ngon tuyệt vời";
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            txtTimKiem.Enabled = true;
            TimKiem();
        }
        void TimKiem()
        {
            string type_search = "";
            type_search = cboTimKiem.Text;
            string value_search = txtTimKiem.Text;
            //
            XoaDuLieuTrongControl_SanPham();
            XoaDuLieuTrongControl_ChiTietSanPham();
            danhsach_datagridview(ref ds_ChiTietSanPham, dgvDanhSachChiTietSanPham, "SELECT TOP 0 * FROM CHITIETSANPHAM");
            //
            switch (cboTimKiem.SelectedIndex)
            {
                case 0:
                    {
                        lblTimKiem.Text = "Nhập Mã sản phẩm";
                        type_search = "MASP";
                        danhsach_datagridview(ref ds_SanPham, dgvDanhSachSanPham, $"SELECT * FROM SANPHAM WHERE {type_search} = '{value_search}' AND TRANGTHAI = N'Hoạt động'");
                        if (ds_SanPham.Tables[0].Rows.Count > 0)
                        {
                            hienthi_textbox_SanPham(ds_SanPham, 0);
                            dgvDanhSachSanPham.Rows[0].Selected = true;
                            ChiTietSanPham_Load(vitri_SanPham, vitri_ChiTietSanPham);
                        }
                        break;
                    }
                case 1:
                    {
                        lblTimKiem.Text = "Nhập Tên sản phẩm";
                        type_search = "TENSP";
                        danhsach_datagridview(ref ds_SanPham, dgvDanhSachSanPham, $"SELECT * FROM SANPHAM WHERE {type_search} LIKE N'%{value_search}%' AND '{value_search}'!='' AND TRANGTHAI = N'Hoạt động'");
                        if (ds_SanPham.Tables[0].Rows.Count > 0)
                        {
                            hienthi_textbox_SanPham(ds_SanPham, 0);
                            dgvDanhSachSanPham.Rows[0].Selected = true;
                            ChiTietSanPham_Load(vitri_SanPham, vitri_ChiTietSanPham);
                        }
                        break;
                    }
                case 2:
                    {
                        lblTimKiem.Text = "Nhập Giá bán";
                        type_search = "GIABAN";
                        try
                        {
                            int number = Convert.ToInt32(value_search);
                            danhsach_datagridview(ref ds_SanPham, dgvDanhSachSanPham, $"SELECT * FROM SANPHAM A, CHITIETSANPHAM B WHERE A.MASP = B.MASP and giaban >= {number - 5000} AND giaban <= {number + 5000} AND A.TRANGTHAI = N'Hoạt động' and B.TRANGTHAI = N'Hoạt động'");
                            if (ds_SanPham.Tables[0].Rows.Count > 0)
                            {
                                hienthi_textbox_SanPham(ds_SanPham, 0);
                                dgvDanhSachSanPham.Rows[0].Selected = true;
                                ChiTietSanPham_Load(vitri_SanPham, vitri_ChiTietSanPham);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        break;
                    }
                case 3:
                    {
                        lblTimKiem.Text = "Nhập Giá vốn";
                        type_search = "GIAVON";
                        try
                        {
                            int number = Convert.ToInt32(value_search);
                            danhsach_datagridview(ref ds_SanPham, dgvDanhSachSanPham, $"SELECT * FROM SANPHAM A, CHITIETSANPHAM B WHERE A.MASP = B.MASP and giavon >= {number - 5000} AND giavon <= {number + 5000} AND A.TRANGTHAI = N'Hoạt động' and B.TRANGTHAI = N'Hoạt động'");
                            if (ds_SanPham.Tables[0].Rows.Count > 0)
                            {
                                hienthi_textbox_SanPham(ds_SanPham, 0);
                                dgvDanhSachSanPham.Rows[0].Selected = true;
                                ChiTietSanPham_Load(vitri_SanPham, vitri_ChiTietSanPham);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        break;
                    }
                case 4:
                    {
                        lblTimKiem.Text = "Nhập Mã loại sản phẩm";
                        type_search = "LOAISP";
                        danhsach_datagridview(ref ds_SanPham, dgvDanhSachSanPham, $"SELECT * FROM SANPHAM WHERE {type_search} = '{value_search}'");
                        break;
                    }
                case 5:
                    {
                        lblTimKiem.Text = "Nhập Mã nhà cung cấp";
                        type_search = "NHACC";
                        danhsach_datagridview(ref ds_SanPham, dgvDanhSachSanPham, $"SELECT * FROM SANPHAM WHERE {type_search} = '{value_search}'");
                        break;
                    }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            flag_TimKiem = !flag_TimKiem;
            if (flag_TimKiem)
            {
                txtTimKiem.Text = "";
                btnTimKiem.Text = "Ẩn hộp thoại tìm kiếm";
                grpTimKiem.Visible = true;
                cboTimKiem.SelectedIndex = 0;
                //
                XuLyBatTatCacNutChucNang(true);
                VoHieuHoa2NutThem(false);
                CacTextboxChiDoc_SanPham(true);
                CacTextboxChiDoc_ChiTietSanPham(true);
                XoaDuLieuTrongControl_SanPham();
                XoaDuLieuTrongControl_ChiTietSanPham();
                btnThem.Enabled = false;
                //
                dgvDanhSachSanPham.DataSource = null;
                dgvDanhSachSanPham.Columns.Clear();
                TaoCotSP();
                dgvDanhSachChiTietSanPham.DataSource = null;
                dgvDanhSachChiTietSanPham.Columns.Clear();
                TaoCotCTSP();
            }
            else
            {
                btnTimKiem.Text = "Hiện hộp thoại tìm kiếm";
                grpTimKiem.Visible = false;
                frmSanPham_Load(sender, e);
            }
        }
    }
}