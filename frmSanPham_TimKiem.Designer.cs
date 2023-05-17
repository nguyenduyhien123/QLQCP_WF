namespace _9_12_QuanLyQuanCaPhe
{
    partial class frmSanPham_TimKiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanPham_TimKiem));
            this.cboTimKiem = new System.Windows.Forms.ComboBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDanhSachSanPham = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvDanhSachChiTietSanPham = new System.Windows.Forms.DataGridView();
            this.grpThongTinSanPham = new System.Windows.Forms.GroupBox();
            this.grpTimKiemSanPham = new System.Windows.Forms.GroupBox();
            this.btnDongTimKiemSanPham = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTimKiemSanPham = new System.Windows.Forms.Label();
            this.txtTimKiemSanPham = new System.Windows.Forms.TextBox();
            this.cboTimKiemSanPham = new System.Windows.Forms.ComboBox();
            this.rtxtMoTa_SanPham = new System.Windows.Forms.RichTextBox();
            this.btnChonHinhAnh = new System.Windows.Forms.Button();
            this.ptxHinhAnh = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMaNCC = new System.Windows.Forms.ComboBox();
            this.cboTrangThai_SanPham = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboLoaiSanPham = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoLuong_SanPham = new System.Windows.Forms.Label();
            this.txtSoLuongSanPham = new System.Windows.Forms.TextBox();
            this.grpThongTinChiTietSanPham = new System.Windows.Forms.GroupBox();
            this.btnThemChiTietSanPham = new System.Windows.Forms.Button();
            this.nupGiaBan = new System.Windows.Forms.NumericUpDown();
            this.nupGiaVon = new System.Windows.Forms.NumericUpDown();
            this.nupSoLuongChiTietSanPham = new System.Windows.Forms.NumericUpDown();
            this.cboMaSize = new System.Windows.Forms.ComboBox();
            this.rtxtMoTa_ChiTietSanPham = new System.Windows.Forms.RichTextBox();
            this.cboTrangThai_ChiTietSanPham = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaChiTietSanPham = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachChiTietSanPham)).BeginInit();
            this.grpThongTinSanPham.SuspendLayout();
            this.grpTimKiemSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptxHinhAnh)).BeginInit();
            this.grpThongTinChiTietSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupGiaVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSoLuongChiTietSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTimKiem
            // 
            this.cboTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTimKiem.FormattingEnabled = true;
            this.cboTimKiem.Items.AddRange(new object[] {
            "Mã sản phẩm",
            "Tên sản phẩm",
            "Giá",
            "Đơn vị tính"});
            this.cboTimKiem.Location = new System.Drawing.Point(910, 67);
            this.cboTimKiem.Name = "cboTimKiem";
            this.cboTimKiem.Size = new System.Drawing.Size(289, 37);
            this.cboTimKiem.TabIndex = 0;
            this.cboTimKiem.SelectedIndexChanged += new System.EventHandler(this.cboTimKiem_SelectedIndexChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.Location = new System.Drawing.Point(1290, 20);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(281, 44);
            this.lblTimKiem.TabIndex = 2;
            this.lblTimKiem.Text = "Tìm kiếm";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(905, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn tiêu chí cần tìm kiếm";
            // 
            // dgvDanhSachSanPham
            // 
            this.dgvDanhSachSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachSanPham.Location = new System.Drawing.Point(12, 376);
            this.dgvDanhSachSanPham.Name = "dgvDanhSachSanPham";
            this.dgvDanhSachSanPham.RowHeadersWidth = 51;
            this.dgvDanhSachSanPham.RowTemplate.Height = 24;
            this.dgvDanhSachSanPham.Size = new System.Drawing.Size(858, 345);
            this.dgvDanhSachSanPham.TabIndex = 10;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(1295, 71);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(305, 38);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // dgvDanhSachChiTietSanPham
            // 
            this.dgvDanhSachChiTietSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachChiTietSanPham.Location = new System.Drawing.Point(896, 378);
            this.dgvDanhSachChiTietSanPham.Name = "dgvDanhSachChiTietSanPham";
            this.dgvDanhSachChiTietSanPham.RowHeadersWidth = 51;
            this.dgvDanhSachChiTietSanPham.RowTemplate.Height = 24;
            this.dgvDanhSachChiTietSanPham.Size = new System.Drawing.Size(822, 345);
            this.dgvDanhSachChiTietSanPham.TabIndex = 11;
            // 
            // grpThongTinSanPham
            // 
            this.grpThongTinSanPham.Controls.Add(this.grpTimKiemSanPham);
            this.grpThongTinSanPham.Controls.Add(this.rtxtMoTa_SanPham);
            this.grpThongTinSanPham.Controls.Add(this.btnChonHinhAnh);
            this.grpThongTinSanPham.Controls.Add(this.ptxHinhAnh);
            this.grpThongTinSanPham.Controls.Add(this.label10);
            this.grpThongTinSanPham.Controls.Add(this.cboMaNCC);
            this.grpThongTinSanPham.Controls.Add(this.cboTrangThai_SanPham);
            this.grpThongTinSanPham.Controls.Add(this.label12);
            this.grpThongTinSanPham.Controls.Add(this.cboLoaiSanPham);
            this.grpThongTinSanPham.Controls.Add(this.label6);
            this.grpThongTinSanPham.Controls.Add(this.label14);
            this.grpThongTinSanPham.Controls.Add(this.txtMaSanPham);
            this.grpThongTinSanPham.Controls.Add(this.label2);
            this.grpThongTinSanPham.Controls.Add(this.label3);
            this.grpThongTinSanPham.Controls.Add(this.txtTenSanPham);
            this.grpThongTinSanPham.Controls.Add(this.label4);
            this.grpThongTinSanPham.Controls.Add(this.lblSoLuong_SanPham);
            this.grpThongTinSanPham.Controls.Add(this.txtSoLuongSanPham);
            this.grpThongTinSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinSanPham.Location = new System.Drawing.Point(12, 11);
            this.grpThongTinSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpThongTinSanPham.Name = "grpThongTinSanPham";
            this.grpThongTinSanPham.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpThongTinSanPham.Size = new System.Drawing.Size(858, 359);
            this.grpThongTinSanPham.TabIndex = 12;
            this.grpThongTinSanPham.TabStop = false;
            this.grpThongTinSanPham.Text = "Thông tin sản phẩm";
            // 
            // grpTimKiemSanPham
            // 
            this.grpTimKiemSanPham.Controls.Add(this.btnDongTimKiemSanPham);
            this.grpTimKiemSanPham.Controls.Add(this.label5);
            this.grpTimKiemSanPham.Controls.Add(this.lblTimKiemSanPham);
            this.grpTimKiemSanPham.Controls.Add(this.txtTimKiemSanPham);
            this.grpTimKiemSanPham.Controls.Add(this.cboTimKiemSanPham);
            this.grpTimKiemSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpTimKiemSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTimKiemSanPham.Location = new System.Drawing.Point(45, 366);
            this.grpTimKiemSanPham.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grpTimKiemSanPham.Name = "grpTimKiemSanPham";
            this.grpTimKiemSanPham.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grpTimKiemSanPham.Size = new System.Drawing.Size(1064, 496);
            this.grpTimKiemSanPham.TabIndex = 7;
            this.grpTimKiemSanPham.TabStop = false;
            this.grpTimKiemSanPham.Text = "Tìm kiếm sản phẩm";
            this.grpTimKiemSanPham.Visible = false;
            // 
            // btnDongTimKiemSanPham
            // 
            this.btnDongTimKiemSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongTimKiemSanPham.Location = new System.Drawing.Point(303, 282);
            this.btnDongTimKiemSanPham.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnDongTimKiemSanPham.Name = "btnDongTimKiemSanPham";
            this.btnDongTimKiemSanPham.Size = new System.Drawing.Size(364, 62);
            this.btnDongTimKiemSanPham.TabIndex = 7;
            this.btnDongTimKiemSanPham.Text = "Đóng tìm kiếm";
            this.btnDongTimKiemSanPham.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(453, 33);
            this.label5.TabIndex = 5;
            this.label5.Text = "Chọn tiêu chí cần tìm kiếm";
            // 
            // lblTimKiemSanPham
            // 
            this.lblTimKiemSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiemSanPham.Location = new System.Drawing.Point(527, 98);
            this.lblTimKiemSanPham.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimKiemSanPham.Name = "lblTimKiemSanPham";
            this.lblTimKiemSanPham.Size = new System.Drawing.Size(375, 33);
            this.lblTimKiemSanPham.TabIndex = 6;
            this.lblTimKiemSanPham.Text = "Tìm kiếm";
            // 
            // txtTimKiemSanPham
            // 
            this.txtTimKiemSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemSanPham.Location = new System.Drawing.Point(532, 153);
            this.txtTimKiemSanPham.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTimKiemSanPham.Name = "txtTimKiemSanPham";
            this.txtTimKiemSanPham.Size = new System.Drawing.Size(405, 38);
            this.txtTimKiemSanPham.TabIndex = 4;
            // 
            // cboTimKiemSanPham
            // 
            this.cboTimKiemSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTimKiemSanPham.FormattingEnabled = true;
            this.cboTimKiemSanPham.Items.AddRange(new object[] {
            "Mã sản phẩm",
            "Tên sản phẩm",
            "Mã nhà cung cấp"});
            this.cboTimKiemSanPham.Location = new System.Drawing.Point(17, 156);
            this.cboTimKiemSanPham.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboTimKiemSanPham.Name = "cboTimKiemSanPham";
            this.cboTimKiemSanPham.Size = new System.Drawing.Size(384, 37);
            this.cboTimKiemSanPham.TabIndex = 3;
            // 
            // rtxtMoTa_SanPham
            // 
            this.rtxtMoTa_SanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtMoTa_SanPham.Location = new System.Drawing.Point(525, 238);
            this.rtxtMoTa_SanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtxtMoTa_SanPham.Name = "rtxtMoTa_SanPham";
            this.rtxtMoTa_SanPham.Size = new System.Drawing.Size(200, 109);
            this.rtxtMoTa_SanPham.TabIndex = 15;
            this.rtxtMoTa_SanPham.Text = "";
            // 
            // btnChonHinhAnh
            // 
            this.btnChonHinhAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonHinhAnh.Location = new System.Drawing.Point(549, 9);
            this.btnChonHinhAnh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChonHinhAnh.Name = "btnChonHinhAnh";
            this.btnChonHinhAnh.Size = new System.Drawing.Size(163, 55);
            this.btnChonHinhAnh.TabIndex = 14;
            this.btnChonHinhAnh.Text = "Chọn hình ảnh";
            this.btnChonHinhAnh.UseVisualStyleBackColor = true;
            this.btnChonHinhAnh.Visible = false;
            // 
            // ptxHinhAnh
            // 
            this.ptxHinhAnh.BackColor = System.Drawing.Color.White;
            this.ptxHinhAnh.Image = ((System.Drawing.Image)(resources.GetObject("ptxHinhAnh.Image")));
            this.ptxHinhAnh.Location = new System.Drawing.Point(525, 73);
            this.ptxHinhAnh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptxHinhAnh.Name = "ptxHinhAnh";
            this.ptxHinhAnh.Size = new System.Drawing.Size(200, 150);
            this.ptxHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptxHinhAnh.TabIndex = 13;
            this.ptxHinhAnh.TabStop = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(428, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 33);
            this.label10.TabIndex = 5;
            this.label10.Text = "Hình ảnh";
            // 
            // cboMaNCC
            // 
            this.cboMaNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNCC.FormattingEnabled = true;
            this.cboMaNCC.Items.AddRange(new object[] {
            "Hoạt động",
            "Không hoạt động"});
            this.cboMaNCC.Location = new System.Drawing.Point(200, 162);
            this.cboMaNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMaNCC.Name = "cboMaNCC";
            this.cboMaNCC.Size = new System.Drawing.Size(213, 28);
            this.cboMaNCC.TabIndex = 11;
            // 
            // cboTrangThai_SanPham
            // 
            this.cboTrangThai_SanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai_SanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTrangThai_SanPham.FormattingEnabled = true;
            this.cboTrangThai_SanPham.Items.AddRange(new object[] {
            "Hoạt động",
            "Không hoạt động"});
            this.cboTrangThai_SanPham.Location = new System.Drawing.Point(200, 254);
            this.cboTrangThai_SanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboTrangThai_SanPham.Name = "cboTrangThai_SanPham";
            this.cboTrangThai_SanPham.Size = new System.Drawing.Size(213, 28);
            this.cboTrangThai_SanPham.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(428, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 33);
            this.label12.TabIndex = 6;
            this.label12.Text = "Mô tả";
            // 
            // cboLoaiSanPham
            // 
            this.cboLoaiSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiSanPham.FormattingEnabled = true;
            this.cboLoaiSanPham.Items.AddRange(new object[] {
            "chai",
            "lít",
            "lọ",
            "ly",
            "lon"});
            this.cboLoaiSanPham.Location = new System.Drawing.Point(200, 206);
            this.cboLoaiSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboLoaiSanPham.Name = "cboLoaiSanPham";
            this.cboLoaiSanPham.Size = new System.Drawing.Size(213, 28);
            this.cboLoaiSanPham.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 33);
            this.label6.TabIndex = 7;
            this.label6.Text = "Loại sản phẩm";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 254);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 30);
            this.label14.TabIndex = 8;
            this.label14.Text = "Trạng thái";
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSanPham.Location = new System.Drawing.Point(200, 33);
            this.txtMaSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(215, 27);
            this.txtMaSanPham.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã sản phẩm";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 33);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên sản phẩm";
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSanPham.Location = new System.Drawing.Point(200, 75);
            this.txtTenSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(215, 27);
            this.txtTenSanPham.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 33);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên nhà cung cấp";
            // 
            // lblSoLuong_SanPham
            // 
            this.lblSoLuong_SanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong_SanPham.Location = new System.Drawing.Point(6, 118);
            this.lblSoLuong_SanPham.Name = "lblSoLuong_SanPham";
            this.lblSoLuong_SanPham.Size = new System.Drawing.Size(187, 33);
            this.lblSoLuong_SanPham.TabIndex = 1;
            this.lblSoLuong_SanPham.Text = "Số lượng";
            // 
            // txtSoLuongSanPham
            // 
            this.txtSoLuongSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuongSanPham.Location = new System.Drawing.Point(200, 118);
            this.txtSoLuongSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuongSanPham.Name = "txtSoLuongSanPham";
            this.txtSoLuongSanPham.Size = new System.Drawing.Size(213, 27);
            this.txtSoLuongSanPham.TabIndex = 2;
            // 
            // grpThongTinChiTietSanPham
            // 
            this.grpThongTinChiTietSanPham.Controls.Add(this.btnThemChiTietSanPham);
            this.grpThongTinChiTietSanPham.Controls.Add(this.nupGiaBan);
            this.grpThongTinChiTietSanPham.Controls.Add(this.nupGiaVon);
            this.grpThongTinChiTietSanPham.Controls.Add(this.nupSoLuongChiTietSanPham);
            this.grpThongTinChiTietSanPham.Controls.Add(this.cboMaSize);
            this.grpThongTinChiTietSanPham.Controls.Add(this.rtxtMoTa_ChiTietSanPham);
            this.grpThongTinChiTietSanPham.Controls.Add(this.cboTrangThai_ChiTietSanPham);
            this.grpThongTinChiTietSanPham.Controls.Add(this.label7);
            this.grpThongTinChiTietSanPham.Controls.Add(this.label8);
            this.grpThongTinChiTietSanPham.Controls.Add(this.txtMaChiTietSanPham);
            this.grpThongTinChiTietSanPham.Controls.Add(this.label11);
            this.grpThongTinChiTietSanPham.Controls.Add(this.label16);
            this.grpThongTinChiTietSanPham.Controls.Add(this.label19);
            this.grpThongTinChiTietSanPham.Controls.Add(this.label17);
            this.grpThongTinChiTietSanPham.Controls.Add(this.label18);
            this.grpThongTinChiTietSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinChiTietSanPham.Location = new System.Drawing.Point(896, 118);
            this.grpThongTinChiTietSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpThongTinChiTietSanPham.Name = "grpThongTinChiTietSanPham";
            this.grpThongTinChiTietSanPham.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpThongTinChiTietSanPham.Size = new System.Drawing.Size(821, 255);
            this.grpThongTinChiTietSanPham.TabIndex = 19;
            this.grpThongTinChiTietSanPham.TabStop = false;
            this.grpThongTinChiTietSanPham.Text = "Thông tin chi tiết sản phẩm";
            // 
            // btnThemChiTietSanPham
            // 
            this.btnThemChiTietSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemChiTietSanPham.Location = new System.Drawing.Point(455, 198);
            this.btnThemChiTietSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemChiTietSanPham.Name = "btnThemChiTietSanPham";
            this.btnThemChiTietSanPham.Size = new System.Drawing.Size(353, 41);
            this.btnThemChiTietSanPham.TabIndex = 5;
            this.btnThemChiTietSanPham.Text = "T&hêm CTSP";
            this.btnThemChiTietSanPham.UseVisualStyleBackColor = true;
            // 
            // nupGiaBan
            // 
            this.nupGiaBan.Location = new System.Drawing.Point(211, 197);
            this.nupGiaBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nupGiaBan.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nupGiaBan.Name = "nupGiaBan";
            this.nupGiaBan.Size = new System.Drawing.Size(233, 30);
            this.nupGiaBan.TabIndex = 17;
            // 
            // nupGiaVon
            // 
            this.nupGiaVon.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupGiaVon.Location = new System.Drawing.Point(211, 161);
            this.nupGiaVon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nupGiaVon.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nupGiaVon.Name = "nupGiaVon";
            this.nupGiaVon.Size = new System.Drawing.Size(233, 30);
            this.nupGiaVon.TabIndex = 17;
            // 
            // nupSoLuongChiTietSanPham
            // 
            this.nupSoLuongChiTietSanPham.Location = new System.Drawing.Point(211, 119);
            this.nupSoLuongChiTietSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nupSoLuongChiTietSanPham.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupSoLuongChiTietSanPham.Name = "nupSoLuongChiTietSanPham";
            this.nupSoLuongChiTietSanPham.Size = new System.Drawing.Size(233, 30);
            this.nupSoLuongChiTietSanPham.TabIndex = 17;
            // 
            // cboMaSize
            // 
            this.cboMaSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaSize.FormattingEnabled = true;
            this.cboMaSize.Location = new System.Drawing.Point(211, 76);
            this.cboMaSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMaSize.Name = "cboMaSize";
            this.cboMaSize.Size = new System.Drawing.Size(233, 28);
            this.cboMaSize.TabIndex = 16;
            // 
            // rtxtMoTa_ChiTietSanPham
            // 
            this.rtxtMoTa_ChiTietSanPham.Location = new System.Drawing.Point(563, 33);
            this.rtxtMoTa_ChiTietSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtxtMoTa_ChiTietSanPham.Name = "rtxtMoTa_ChiTietSanPham";
            this.rtxtMoTa_ChiTietSanPham.Size = new System.Drawing.Size(245, 96);
            this.rtxtMoTa_ChiTietSanPham.TabIndex = 15;
            this.rtxtMoTa_ChiTietSanPham.Text = "";
            // 
            // cboTrangThai_ChiTietSanPham
            // 
            this.cboTrangThai_ChiTietSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai_ChiTietSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTrangThai_ChiTietSanPham.FormattingEnabled = true;
            this.cboTrangThai_ChiTietSanPham.Items.AddRange(new object[] {
            "Hoạt động",
            "Không hoạt động"});
            this.cboTrangThai_ChiTietSanPham.Location = new System.Drawing.Point(563, 162);
            this.cboTrangThai_ChiTietSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboTrangThai_ChiTietSanPham.Name = "cboTrangThai_ChiTietSanPham";
            this.cboTrangThai_ChiTietSanPham.Size = new System.Drawing.Size(245, 28);
            this.cboTrangThai_ChiTietSanPham.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(473, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 33);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mô tả";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(451, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 33);
            this.label8.TabIndex = 8;
            this.label8.Text = "Trạng thái";
            // 
            // txtMaChiTietSanPham
            // 
            this.txtMaChiTietSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaChiTietSanPham.Location = new System.Drawing.Point(211, 34);
            this.txtMaChiTietSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaChiTietSanPham.Name = "txtMaChiTietSanPham";
            this.txtMaChiTietSanPham.Size = new System.Drawing.Size(235, 27);
            this.txtMaChiTietSanPham.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 33);
            this.label11.TabIndex = 1;
            this.label11.Text = "Mã chi tiết sản phẩm";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(21, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(165, 33);
            this.label16.TabIndex = 1;
            this.label16.Text = "Giá vốn";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(21, 116);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(161, 33);
            this.label19.TabIndex = 1;
            this.label19.Text = "Số lượng";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(21, 78);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(161, 33);
            this.label17.TabIndex = 1;
            this.label17.Text = "Tên size";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(21, 206);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(156, 33);
            this.label18.TabIndex = 1;
            this.label18.Text = "Giá bán";
            // 
            // frmSanPham_TimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1756, 769);
            this.Controls.Add(this.grpThongTinChiTietSanPham);
            this.Controls.Add(this.grpThongTinSanPham);
            this.Controls.Add(this.dgvDanhSachChiTietSanPham);
            this.Controls.Add(this.dgvDanhSachSanPham);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.cboTimKiem);
            this.Name = "frmSanPham_TimKiem";
            this.Text = "frmSanPham_TimKiem";
            this.Load += new System.EventHandler(this.frmSanPham_TimKiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachChiTietSanPham)).EndInit();
            this.grpThongTinSanPham.ResumeLayout(false);
            this.grpThongTinSanPham.PerformLayout();
            this.grpTimKiemSanPham.ResumeLayout(false);
            this.grpTimKiemSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptxHinhAnh)).EndInit();
            this.grpThongTinChiTietSanPham.ResumeLayout(false);
            this.grpThongTinChiTietSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupGiaBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupGiaVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSoLuongChiTietSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDanhSachSanPham;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvDanhSachChiTietSanPham;
        private System.Windows.Forms.GroupBox grpThongTinSanPham;
        private System.Windows.Forms.GroupBox grpTimKiemSanPham;
        private System.Windows.Forms.Button btnDongTimKiemSanPham;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTimKiemSanPham;
        private System.Windows.Forms.TextBox txtTimKiemSanPham;
        private System.Windows.Forms.ComboBox cboTimKiemSanPham;
        private System.Windows.Forms.RichTextBox rtxtMoTa_SanPham;
        private System.Windows.Forms.Button btnChonHinhAnh;
        private System.Windows.Forms.PictureBox ptxHinhAnh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMaNCC;
        private System.Windows.Forms.ComboBox cboTrangThai_SanPham;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboLoaiSanPham;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSoLuong_SanPham;
        private System.Windows.Forms.TextBox txtSoLuongSanPham;
        private System.Windows.Forms.GroupBox grpThongTinChiTietSanPham;
        private System.Windows.Forms.Button btnThemChiTietSanPham;
        private System.Windows.Forms.NumericUpDown nupGiaBan;
        private System.Windows.Forms.NumericUpDown nupGiaVon;
        private System.Windows.Forms.NumericUpDown nupSoLuongChiTietSanPham;
        private System.Windows.Forms.ComboBox cboMaSize;
        private System.Windows.Forms.RichTextBox rtxtMoTa_ChiTietSanPham;
        private System.Windows.Forms.ComboBox cboTrangThai_ChiTietSanPham;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaChiTietSanPham;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}