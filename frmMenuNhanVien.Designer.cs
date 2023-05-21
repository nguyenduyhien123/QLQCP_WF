namespace _9_12_QuanLyQuanCaPhe
{
    partial class frmMenuNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuNhanVien));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngChínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.lblNgayGio = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLichSuDangNhap = new System.Windows.Forms.Button();
            this.btnThayDoiMatKhau = new System.Windows.Forms.Button();
            this.btnHoaDonBan = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngChínhToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1788, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngChínhToolStripMenuItem
            // 
            this.chứcNăngChínhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HDBToolStripMenuItem,
            this.BanToolStripMenuItem});
            this.chứcNăngChínhToolStripMenuItem.Name = "chứcNăngChínhToolStripMenuItem";
            this.chứcNăngChínhToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.chứcNăngChínhToolStripMenuItem.Text = "Chức năng chính";
            // 
            // HDBToolStripMenuItem
            // 
            this.HDBToolStripMenuItem.Name = "HDBToolStripMenuItem";
            this.HDBToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.HDBToolStripMenuItem.Text = "Hoá đơn bán";
            this.HDBToolStripMenuItem.Click += new System.EventHandler(this.HDBToolStripMenuItem_Click);
            // 
            // BanToolStripMenuItem
            // 
            this.BanToolStripMenuItem.Name = "BanToolStripMenuItem";
            this.BanToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.BanToolStripMenuItem.Text = "Bàn";
            this.BanToolStripMenuItem.Click += new System.EventHandler(this.BanToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDangXuat);
            this.panel1.Controls.Add(this.lblTaiKhoan);
            this.panel1.Controls.Add(this.lblNgayGio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1788, 55);
            this.panel1.TabIndex = 2;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(1601, 2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(155, 52);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            this.btnDangXuat.MouseLeave += new System.EventHandler(this.btnDangXuat_MouseLeave);
            this.btnDangXuat.MouseHover += new System.EventHandler(this.btnDangXuat_MouseHover);
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaiKhoan.ForeColor = System.Drawing.Color.Blue;
            this.lblTaiKhoan.Location = new System.Drawing.Point(623, 5);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(871, 47);
            this.lblTaiKhoan.TabIndex = 1;
            this.lblTaiKhoan.Text = "tài khoản";
            this.lblTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgayGio
            // 
            this.lblNgayGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayGio.Location = new System.Drawing.Point(12, 11);
            this.lblNgayGio.Name = "lblNgayGio";
            this.lblNgayGio.Size = new System.Drawing.Size(573, 37);
            this.lblNgayGio.TabIndex = 0;
            this.lblNgayGio.Text = "a";
            this.lblNgayGio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panel2.Controls.Add(this.btnLichSuDangNhap);
            this.panel2.Controls.Add(this.btnThayDoiMatKhau);
            this.panel2.Controls.Add(this.btnHoaDonBan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 638);
            this.panel2.TabIndex = 4;
            // 
            // btnLichSuDangNhap
            // 
            this.btnLichSuDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnLichSuDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichSuDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSuDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnLichSuDangNhap.Location = new System.Drawing.Point(3, 180);
            this.btnLichSuDangNhap.Name = "btnLichSuDangNhap";
            this.btnLichSuDangNhap.Size = new System.Drawing.Size(229, 68);
            this.btnLichSuDangNhap.TabIndex = 0;
            this.btnLichSuDangNhap.Text = "Lịch sử đăng nhập";
            this.btnLichSuDangNhap.UseVisualStyleBackColor = false;
            this.btnLichSuDangNhap.Click += new System.EventHandler(this.btnLichSuDangNhap_Click);
            // 
            // btnThayDoiMatKhau
            // 
            this.btnThayDoiMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnThayDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThayDoiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThayDoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnThayDoiMatKhau.Location = new System.Drawing.Point(0, 90);
            this.btnThayDoiMatKhau.Name = "btnThayDoiMatKhau";
            this.btnThayDoiMatKhau.Size = new System.Drawing.Size(229, 68);
            this.btnThayDoiMatKhau.TabIndex = 0;
            this.btnThayDoiMatKhau.Text = "Thay đổi mật khẩu";
            this.btnThayDoiMatKhau.UseVisualStyleBackColor = false;
            this.btnThayDoiMatKhau.Click += new System.EventHandler(this.btnThayDoiMatKhau_Click);
            // 
            // btnHoaDonBan
            // 
            this.btnHoaDonBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnHoaDonBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDonBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDonBan.ForeColor = System.Drawing.Color.White;
            this.btnHoaDonBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoaDonBan.Location = new System.Drawing.Point(0, 6);
            this.btnHoaDonBan.Name = "btnHoaDonBan";
            this.btnHoaDonBan.Size = new System.Drawing.Size(229, 63);
            this.btnHoaDonBan.TabIndex = 0;
            this.btnHoaDonBan.Text = "Hoá đơn bán";
            this.btnHoaDonBan.UseVisualStyleBackColor = false;
            this.btnHoaDonBan.Click += new System.EventHandler(this.btnHoaDonBan_Click);
            // 
            // frmMenuNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1788, 721);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMenuNhanVien";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Nhân Viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenuNhanVien_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenuNhanVien_FormClosed);
            this.Load += new System.EventHandler(this.frmMenuNhanVien_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngChínhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BanToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblNgayGio;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnThayDoiMatKhau;
        private System.Windows.Forms.Button btnHoaDonBan;
        private System.Windows.Forms.Button btnLichSuDangNhap;
    }
}