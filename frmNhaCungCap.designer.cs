namespace _9_12_QuanLyQuanCaPhe
{
    partial class frmNhaCungCap
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.MANCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANGTHAI = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gboThongTin = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.gboTimKiem = new System.Windows.Forms.GroupBox();
            this.btnHienDS = new System.Windows.Forms.Button();
            this.cboTim = new System.Windows.Forms.ComboBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnTimTT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gboThongTin.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gboTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(814, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHẬP THÔNG TIN NHÀ CUNG CẤP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(374, 20);
            this.txtMaNCC.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(114, 23);
            this.txtMaNCC.TabIndex = 1;
            this.txtMaNCC.TextChanged += new System.EventHandler(this.txtMaNCC_TextChanged);
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(152, 19);
            this.txtTenNCC.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(114, 23);
            this.txtTenNCC.TabIndex = 1;
            this.txtTenNCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenNCC_KeyPress);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(374, 48);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(114, 23);
            this.txtSDT.TabIndex = 1;
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(152, 101);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(336, 23);
            this.txtDiaChi.TabIndex = 1;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(152, 77);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(2);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(336, 23);
            this.txtMoTa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(273, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã nhà cung cấp ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên nhà cung cấp";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(270, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số điện thoại";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Địa chỉ ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(23, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mô tả";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Trạng thái";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(268, 184);
            this.btnTim.Margin = new System.Windows.Forms.Padding(2);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(183, 25);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Hoạt động",
            "Không hoạt động"});
            this.cboTrangThai.Location = new System.Drawing.Point(153, 47);
            this.cboTrangThai.Margin = new System.Windows.Forms.Padding(2);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(114, 25);
            this.cboTrangThai.TabIndex = 4;
            this.cboTrangThai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTrangThai_KeyPress);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MANCC,
            this.TENNCC,
            this.SDT,
            this.DIACHI,
            this.MOTA,
            this.TRANGTHAI});
            this.dgvDanhSach.Location = new System.Drawing.Point(10, 15);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.Size = new System.Drawing.Size(731, 122);
            this.dgvDanhSach.TabIndex = 5;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            this.dgvDanhSach.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellValueChanged);
            // 
            // MANCC
            // 
            this.MANCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MANCC.DataPropertyName = "MANCC";
            this.MANCC.HeaderText = "Mã nhà cung cấp";
            this.MANCC.MinimumWidth = 6;
            this.MANCC.Name = "MANCC";
            this.MANCC.ReadOnly = true;
            this.MANCC.Width = 113;
            // 
            // TENNCC
            // 
            this.TENNCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TENNCC.DataPropertyName = "TENNCC";
            this.TENNCC.HeaderText = "Tên nhà cung cấp";
            this.TENNCC.MinimumWidth = 6;
            this.TENNCC.Name = "TENNCC";
            this.TENNCC.Width = 119;
            // 
            // SDT
            // 
            this.SDT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SDT.DataPropertyName = "SDT";
            this.SDT.HeaderText = "Số điện thoại";
            this.SDT.MinimumWidth = 6;
            this.SDT.Name = "SDT";
            this.SDT.Width = 110;
            // 
            // DIACHI
            // 
            this.DIACHI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DIACHI.DataPropertyName = "DIACHI";
            this.DIACHI.HeaderText = "Địa chỉ";
            this.DIACHI.MinimumWidth = 6;
            this.DIACHI.Name = "DIACHI";
            // 
            // MOTA
            // 
            this.MOTA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MOTA.DataPropertyName = "MOTA";
            this.MOTA.HeaderText = "Mô tả";
            this.MOTA.MinimumWidth = 6;
            this.MOTA.Name = "MOTA";
            // 
            // TRANGTHAI
            // 
            this.TRANGTHAI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TRANGTHAI.DataPropertyName = "TRANGTHAI";
            this.TRANGTHAI.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.TRANGTHAI.HeaderText = "Trạng thái";
            this.TRANGTHAI.Items.AddRange(new object[] {
            "Hoạt động",
            "Không hoạt động"});
            this.TRANGTHAI.MinimumWidth = 6;
            this.TRANGTHAI.Name = "TRANGTHAI";
            this.TRANGTHAI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TRANGTHAI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TRANGTHAI.Width = 94;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDanhSach);
            this.groupBox1.Location = new System.Drawing.Point(31, 213);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(752, 154);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh  sách cá nhà cung cấp";
            // 
            // gboThongTin
            // 
            this.gboThongTin.Controls.Add(this.txtMaNCC);
            this.gboThongTin.Controls.Add(this.label2);
            this.gboThongTin.Controls.Add(this.txtMoTa);
            this.gboThongTin.Controls.Add(this.txtDiaChi);
            this.gboThongTin.Controls.Add(this.cboTrangThai);
            this.gboThongTin.Controls.Add(this.label3);
            this.gboThongTin.Controls.Add(this.label6);
            this.gboThongTin.Controls.Add(this.txtSDT);
            this.gboThongTin.Controls.Add(this.label5);
            this.gboThongTin.Controls.Add(this.txtTenNCC);
            this.gboThongTin.Controls.Add(this.label7);
            this.gboThongTin.Controls.Add(this.label4);
            this.gboThongTin.Location = new System.Drawing.Point(61, 44);
            this.gboThongTin.Margin = new System.Windows.Forms.Padding(2);
            this.gboThongTin.Name = "gboThongTin";
            this.gboThongTin.Padding = new System.Windows.Forms.Padding(2);
            this.gboThongTin.Size = new System.Drawing.Size(506, 136);
            this.gboThongTin.TabIndex = 7;
            this.gboThongTin.TabStop = false;
            this.gboThongTin.Text = "Thông tin nhà cung cấp";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnHuy);
            this.groupBox3.Controls.Add(this.btnThoat);
            this.groupBox3.Controls.Add(this.btnLuu);
            this.groupBox3.Controls.Add(this.btnSua);
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.Location = new System.Drawing.Point(571, 37);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(139, 172);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btnHuy
            // 
            this.btnHuy.Enabled = false;
            this.btnHuy.Location = new System.Drawing.Point(18, 118);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(109, 21);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(18, 143);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(109, 21);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Enabled = false;
            this.btnLuu.Location = new System.Drawing.Point(18, 93);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(109, 21);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(18, 68);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(109, 21);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(18, 43);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(109, 21);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "&Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(18, 18);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(109, 21);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "&Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // gboTimKiem
            // 
            this.gboTimKiem.Controls.Add(this.btnHienDS);
            this.gboTimKiem.Controls.Add(this.cboTim);
            this.gboTimKiem.Controls.Add(this.txtTim);
            this.gboTimKiem.Controls.Add(this.btnTimTT);
            this.gboTimKiem.Location = new System.Drawing.Point(180, 70);
            this.gboTimKiem.Name = "gboTimKiem";
            this.gboTimKiem.Size = new System.Drawing.Size(330, 98);
            this.gboTimKiem.TabIndex = 20;
            this.gboTimKiem.TabStop = false;
            this.gboTimKiem.Text = "Tìm kiếm";
            this.gboTimKiem.Visible = false;
            // 
            // btnHienDS
            // 
            this.btnHienDS.Location = new System.Drawing.Point(39, 56);
            this.btnHienDS.Name = "btnHienDS";
            this.btnHienDS.Size = new System.Drawing.Size(102, 23);
            this.btnHienDS.TabIndex = 9;
            this.btnHienDS.Text = "Hiện danh sách ";
            this.btnHienDS.UseVisualStyleBackColor = true;
            this.btnHienDS.Click += new System.EventHandler(this.btnHienDS_Click);
            // 
            // cboTim
            // 
            this.cboTim.FormattingEnabled = true;
            this.cboTim.Items.AddRange(new object[] {
            "Tìm theo tên ",
            "Tìm theo Mã "});
            this.cboTim.Location = new System.Drawing.Point(11, 19);
            this.cboTim.Name = "cboTim";
            this.cboTim.Size = new System.Drawing.Size(165, 25);
            this.cboTim.TabIndex = 8;
            this.cboTim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTim_KeyPress);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(182, 20);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(137, 23);
            this.txtTim.TabIndex = 7;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // btnTimTT
            // 
            this.btnTimTT.Location = new System.Drawing.Point(205, 56);
            this.btnTimTT.Name = "btnTimTT";
            this.btnTimTT.Size = new System.Drawing.Size(101, 22);
            this.btnTimTT.TabIndex = 2;
            this.btnTimTT.Text = "Tìm";
            this.btnTimTT.UseVisualStyleBackColor = true;
            this.btnTimTT.Click += new System.EventHandler(this.btnTimTT_Click);
            // 
            // frmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 392);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboTimKiem);
            this.Controls.Add(this.gboThongTin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmNhaCungCap";
            this.Text = "frmNhaCungCap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhaCungCap_FormClosing);
            this.Load += new System.EventHandler(this.frmNhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gboThongTin.ResumeLayout(false);
            this.gboThongTin.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.gboTimKiem.ResumeLayout(false);
            this.gboTimKiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gboThongTin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.GroupBox gboTimKiem;
        private System.Windows.Forms.Button btnHienDS;
        private System.Windows.Forms.ComboBox cboTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnTimTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MANCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIACHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOTA;
        private System.Windows.Forms.DataGridViewComboBoxColumn TRANGTHAI;
    }
}