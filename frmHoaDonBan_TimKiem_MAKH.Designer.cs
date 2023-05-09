namespace _9_12_QuanLyQuanCaPhe
{
    partial class frmHoaDon_TimKiem
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
            this.dgvHoaDonBan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMAHDB = new System.Windows.Forms.TextBox();
            this.chkMAHDB = new System.Windows.Forms.CheckBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMAKH = new System.Windows.Forms.TextBox();
            this.chkMAKH = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMANV_LAP = new System.Windows.Forms.TextBox();
            this.txtMASP = new System.Windows.Forms.TextBox();
            this.chkMANV_LAP = new System.Windows.Forms.CheckBox();
            this.chkMASP = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMASIZE = new System.Windows.Forms.TextBox();
            this.txtMAKM = new System.Windows.Forms.TextBox();
            this.chkMASIZE = new System.Windows.Forms.CheckBox();
            this.chkMAKM = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkNGAYLAPHD = new System.Windows.Forms.CheckBox();
            this.dtpNGAYLAPHD = new System.Windows.Forms.DateTimePicker();
            this.dgvChiTietHoaDonBan = new System.Windows.Forms.DataGridView();
            this.rtxtSQL = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDonBan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHoaDonBan
            // 
            this.dgvHoaDonBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonBan.Location = new System.Drawing.Point(6, 33);
            this.dgvHoaDonBan.Name = "dgvHoaDonBan";
            this.dgvHoaDonBan.RowHeadersWidth = 51;
            this.dgvHoaDonBan.RowTemplate.Height = 24;
            this.dgvHoaDonBan.Size = new System.Drawing.Size(836, 382);
            this.dgvHoaDonBan.TabIndex = 0;
            this.dgvHoaDonBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDonBan_CellClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã hoá đơn";
            // 
            // txtMAHDB
            // 
            this.txtMAHDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMAHDB.Location = new System.Drawing.Point(266, 27);
            this.txtMAHDB.Name = "txtMAHDB";
            this.txtMAHDB.Size = new System.Drawing.Size(260, 30);
            this.txtMAHDB.TabIndex = 2;
            // 
            // chkMAHDB
            // 
            this.chkMAHDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMAHDB.Location = new System.Drawing.Point(548, 33);
            this.chkMAHDB.Name = "chkMAHDB";
            this.chkMAHDB.Size = new System.Drawing.Size(323, 24);
            this.chkMAHDB.TabIndex = 3;
            this.chkMAHDB.Text = "Tìm kiếm theo mã hoá đơn";
            this.chkMAHDB.UseVisualStyleBackColor = true;
            this.chkMAHDB.CheckedChanged += new System.EventHandler(this.chkMAHDB_CheckedChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(891, 42);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(202, 68);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã khách hàng";
            // 
            // txtMAKH
            // 
            this.txtMAKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMAKH.Location = new System.Drawing.Point(266, 67);
            this.txtMAKH.Name = "txtMAKH";
            this.txtMAKH.Size = new System.Drawing.Size(260, 30);
            this.txtMAKH.TabIndex = 2;
            // 
            // chkMAKH
            // 
            this.chkMAKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMAKH.Location = new System.Drawing.Point(548, 67);
            this.chkMAKH.Name = "chkMAKH";
            this.chkMAKH.Size = new System.Drawing.Size(323, 43);
            this.chkMAKH.TabIndex = 3;
            this.chkMAKH.Text = "Tìm kiếm theo mã khách hàng";
            this.chkMAKH.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã nhân viên";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mã sản phẩm";
            // 
            // txtMANV_LAP
            // 
            this.txtMANV_LAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMANV_LAP.Location = new System.Drawing.Point(266, 116);
            this.txtMANV_LAP.Name = "txtMANV_LAP";
            this.txtMANV_LAP.Size = new System.Drawing.Size(260, 30);
            this.txtMANV_LAP.TabIndex = 2;
            // 
            // txtMASP
            // 
            this.txtMASP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMASP.Location = new System.Drawing.Point(266, 197);
            this.txtMASP.Name = "txtMASP";
            this.txtMASP.Size = new System.Drawing.Size(260, 30);
            this.txtMASP.TabIndex = 2;
            // 
            // chkMANV_LAP
            // 
            this.chkMANV_LAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMANV_LAP.Location = new System.Drawing.Point(548, 116);
            this.chkMANV_LAP.Name = "chkMANV_LAP";
            this.chkMANV_LAP.Size = new System.Drawing.Size(323, 24);
            this.chkMANV_LAP.TabIndex = 3;
            this.chkMANV_LAP.Text = "Tìm kiếm theo mã nhân viên";
            this.chkMANV_LAP.UseVisualStyleBackColor = true;
            // 
            // chkMASP
            // 
            this.chkMASP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMASP.Location = new System.Drawing.Point(548, 203);
            this.chkMASP.Name = "chkMASP";
            this.chkMASP.Size = new System.Drawing.Size(323, 35);
            this.chkMASP.TabIndex = 3;
            this.chkMASP.Text = "Tìm kiếm theo mã sản phẩm";
            this.chkMASP.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Mã size";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mã khuyến mãi";
            // 
            // txtMASIZE
            // 
            this.txtMASIZE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMASIZE.Location = new System.Drawing.Point(266, 243);
            this.txtMASIZE.Name = "txtMASIZE";
            this.txtMASIZE.Size = new System.Drawing.Size(260, 30);
            this.txtMASIZE.TabIndex = 2;
            // 
            // txtMAKM
            // 
            this.txtMAKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMAKM.Location = new System.Drawing.Point(266, 283);
            this.txtMAKM.Name = "txtMAKM";
            this.txtMAKM.Size = new System.Drawing.Size(260, 30);
            this.txtMAKM.TabIndex = 2;
            // 
            // chkMASIZE
            // 
            this.chkMASIZE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMASIZE.Location = new System.Drawing.Point(548, 247);
            this.chkMASIZE.Name = "chkMASIZE";
            this.chkMASIZE.Size = new System.Drawing.Size(323, 24);
            this.chkMASIZE.TabIndex = 3;
            this.chkMASIZE.Text = "Tìm kiếm theo mã size";
            this.chkMASIZE.UseVisualStyleBackColor = true;
            // 
            // chkMAKM
            // 
            this.chkMAKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMAKM.Location = new System.Drawing.Point(548, 284);
            this.chkMAKM.Name = "chkMAKM";
            this.chkMAKM.Size = new System.Drawing.Size(323, 36);
            this.chkMAKM.TabIndex = 3;
            this.chkMAKM.Text = "Tìm kiếm theo mã khuyến mãi";
            this.chkMAKM.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 35);
            this.label7.TabIndex = 1;
            this.label7.Text = "Ngày lập hoá đơn";
            // 
            // chkNGAYLAPHD
            // 
            this.chkNGAYLAPHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNGAYLAPHD.Location = new System.Drawing.Point(548, 157);
            this.chkNGAYLAPHD.Name = "chkNGAYLAPHD";
            this.chkNGAYLAPHD.Size = new System.Drawing.Size(323, 34);
            this.chkNGAYLAPHD.TabIndex = 3;
            this.chkNGAYLAPHD.Text = "Tìm kiếm theo ngày lập hoá đơn";
            this.chkNGAYLAPHD.UseVisualStyleBackColor = true;
            // 
            // dtpNGAYLAPHD
            // 
            this.dtpNGAYLAPHD.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNGAYLAPHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNGAYLAPHD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNGAYLAPHD.Location = new System.Drawing.Point(266, 157);
            this.dtpNGAYLAPHD.Name = "dtpNGAYLAPHD";
            this.dtpNGAYLAPHD.Size = new System.Drawing.Size(260, 34);
            this.dtpNGAYLAPHD.TabIndex = 5;
            // 
            // dgvChiTietHoaDonBan
            // 
            this.dgvChiTietHoaDonBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDonBan.Location = new System.Drawing.Point(14, 33);
            this.dgvChiTietHoaDonBan.Name = "dgvChiTietHoaDonBan";
            this.dgvChiTietHoaDonBan.RowHeadersWidth = 51;
            this.dgvChiTietHoaDonBan.RowTemplate.Height = 24;
            this.dgvChiTietHoaDonBan.Size = new System.Drawing.Size(895, 382);
            this.dgvChiTietHoaDonBan.TabIndex = 6;
            // 
            // rtxtSQL
            // 
            this.rtxtSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtSQL.Location = new System.Drawing.Point(891, 140);
            this.rtxtSQL.Name = "rtxtSQL";
            this.rtxtSQL.Size = new System.Drawing.Size(821, 133);
            this.rtxtSQL.TabIndex = 7;
            this.rtxtSQL.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvHoaDonBan);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 427);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hoá đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvChiTietHoaDonBan);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(866, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(915, 427);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin sản phẩm trong hoá đơn";
            // 
            // frmHoaDon_TimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1793, 750);
            this.Controls.Add(this.rtxtSQL);
            this.Controls.Add(this.dtpNGAYLAPHD);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.chkMAKM);
            this.Controls.Add(this.chkMASP);
            this.Controls.Add(this.chkMAKH);
            this.Controls.Add(this.chkMASIZE);
            this.Controls.Add(this.chkNGAYLAPHD);
            this.Controls.Add(this.chkMANV_LAP);
            this.Controls.Add(this.chkMAHDB);
            this.Controls.Add(this.txtMAKM);
            this.Controls.Add(this.txtMASP);
            this.Controls.Add(this.txtMAKH);
            this.Controls.Add(this.txtMASIZE);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMANV_LAP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMAHDB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmHoaDon_TimKiem";
            this.Text = "frmHoaDonBan_TimKiem_MAKH";
            this.Load += new System.EventHandler(this.frmHoaDon_TimKiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDonBan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDonBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMAHDB;
        private System.Windows.Forms.CheckBox chkMAHDB;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMAKH;
        private System.Windows.Forms.CheckBox chkMAKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMANV_LAP;
        private System.Windows.Forms.TextBox txtMASP;
        private System.Windows.Forms.CheckBox chkMANV_LAP;
        private System.Windows.Forms.CheckBox chkMASP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMASIZE;
        private System.Windows.Forms.TextBox txtMAKM;
        private System.Windows.Forms.CheckBox chkMASIZE;
        private System.Windows.Forms.CheckBox chkMAKM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkNGAYLAPHD;
        private System.Windows.Forms.DateTimePicker dtpNGAYLAPHD;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDonBan;
        private System.Windows.Forms.RichTextBox rtxtSQL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}