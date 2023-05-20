namespace _9_12_QuanLyQuanCaPhe
{
    partial class frmLoaiSP
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnHienDS = new System.Windows.Forms.Button();
            this.cboTim = new System.Windows.Forms.ComboBox();
            this.btnTimTT = new System.Windows.Forms.Button();
            this.gboTimKiem = new System.Windows.Forms.GroupBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTim = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaLSP = new System.Windows.Forms.TextBox();
            this.txtTenLSP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gboThongTin = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gboTimKiem.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gboThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHienDS
            // 
            this.btnHienDS.Location = new System.Drawing.Point(52, 69);
            this.btnHienDS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHienDS.Name = "btnHienDS";
            this.btnHienDS.Size = new System.Drawing.Size(136, 28);
            this.btnHienDS.TabIndex = 9;
            this.btnHienDS.Text = "Hiện danh sách ";
            this.btnHienDS.UseVisualStyleBackColor = true;
            // 
            // cboTim
            // 
            this.cboTim.FormattingEnabled = true;
            this.cboTim.Items.AddRange(new object[] {
            "Tìm theo tên",
            "Tìm theo Mã "});
            this.cboTim.Location = new System.Drawing.Point(15, 23);
            this.cboTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTim.Name = "cboTim";
            this.cboTim.Size = new System.Drawing.Size(219, 24);
            this.cboTim.TabIndex = 8;
            this.cboTim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTim_KeyPress);
            // 
            // btnTimTT
            // 
            this.btnTimTT.Location = new System.Drawing.Point(273, 69);
            this.btnTimTT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimTT.Name = "btnTimTT";
            this.btnTimTT.Size = new System.Drawing.Size(135, 27);
            this.btnTimTT.TabIndex = 2;
            this.btnTimTT.Text = "Tìm";
            this.btnTimTT.UseVisualStyleBackColor = true;
            this.btnTimTT.Click += new System.EventHandler(this.btnTimTT_Click);
            // 
            // gboTimKiem
            // 
            this.gboTimKiem.Controls.Add(this.btnHienDS);
            this.gboTimKiem.Controls.Add(this.cboTim);
            this.gboTimKiem.Controls.Add(this.txtTim);
            this.gboTimKiem.Controls.Add(this.btnTimTT);
            this.gboTimKiem.Location = new System.Drawing.Point(33, 102);
            this.gboTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboTimKiem.Name = "gboTimKiem";
            this.gboTimKiem.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboTimKiem.Size = new System.Drawing.Size(440, 121);
            this.gboTimKiem.TabIndex = 25;
            this.gboTimKiem.TabStop = false;
            this.gboTimKiem.Text = "Tìm kiếm";
            this.gboTimKiem.Visible = false;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(243, 25);
            this.txtTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(181, 22);
            this.txtTim.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(31, 159);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(193, 27);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(31, 123);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(193, 27);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(31, 87);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(193, 27);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(31, 16);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(193, 27);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "&Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnThoat);
            this.groupBox3.Controls.Add(this.btnHuy);
            this.groupBox3.Controls.Add(this.btnLuu);
            this.groupBox3.Controls.Add(this.btnSua);
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.Location = new System.Drawing.Point(540, 70);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(247, 230);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(31, 194);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(193, 27);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(31, 52);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(193, 27);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "&Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvDanhSach
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDanhSach.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvDanhSach.Location = new System.Drawing.Point(17, 22);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.Size = new System.Drawing.Size(656, 187);
            this.dgvDanhSach.TabIndex = 5;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "MALOAISP";
            this.Column1.HeaderText = "Mã loại";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "TENLOAISP";
            this.Column2.HeaderText = "Tên ";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "TRANGTHAI";
            this.Column3.HeaderText = "Trạng thái";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(68, 245);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(331, 52);
            this.btnTim.TabIndex = 20;
            this.btnTim.Text = "Tìm thông tin";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDanhSach);
            this.groupBox1.Location = new System.Drawing.Point(61, 326);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(692, 218);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách các bàn";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Enabled = false;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Trống",
            "Đang sử dụng"});
            this.cboTrangThai.Location = new System.Drawing.Point(188, 103);
            this.cboTrangThai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(191, 24);
            this.cboTrangThai.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên loại sản phẩm";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(32, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã loại sản phẩm";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMaLSP
            // 
            this.txtMaLSP.Location = new System.Drawing.Point(188, 64);
            this.txtMaLSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaLSP.Name = "txtMaLSP";
            this.txtMaLSP.ReadOnly = true;
            this.txtMaLSP.Size = new System.Drawing.Size(191, 22);
            this.txtMaLSP.TabIndex = 1;
            // 
            // txtTenLSP
            // 
            this.txtTenLSP.Location = new System.Drawing.Point(188, 25);
            this.txtTenLSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenLSP.Name = "txtTenLSP";
            this.txtTenLSP.ReadOnly = true;
            this.txtTenLSP.Size = new System.Drawing.Size(191, 22);
            this.txtTenLSP.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 107);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Trạng thái";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gboThongTin
            // 
            this.gboThongTin.Controls.Add(this.cboTrangThai);
            this.gboThongTin.Controls.Add(this.label3);
            this.gboThongTin.Controls.Add(this.label6);
            this.gboThongTin.Controls.Add(this.txtMaLSP);
            this.gboThongTin.Controls.Add(this.txtTenLSP);
            this.gboThongTin.Controls.Add(this.label7);
            this.gboThongTin.Location = new System.Drawing.Point(61, 86);
            this.gboThongTin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboThongTin.Name = "gboThongTin";
            this.gboThongTin.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboThongTin.Size = new System.Drawing.Size(397, 151);
            this.gboThongTin.TabIndex = 23;
            this.gboThongTin.TabStop = false;
            this.gboThongTin.Text = "Thông tin bàn";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, -2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(827, 50);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nhập thông tin loại sản phẩm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLoaiSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 554);
            this.Controls.Add(this.gboTimKiem);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboThongTin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmLoaiSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoaiSP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLoaiSP_FormClosing);
            this.Load += new System.EventHandler(this.frmLoaiSP_Load);
            this.gboTimKiem.ResumeLayout(false);
            this.gboTimKiem.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gboThongTin.ResumeLayout(false);
            this.gboThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHienDS;
        private System.Windows.Forms.ComboBox cboTim;
        private System.Windows.Forms.Button btnTimTT;
        private System.Windows.Forms.GroupBox gboTimKiem;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaLSP;
        private System.Windows.Forms.TextBox txtTenLSP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gboThongTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}