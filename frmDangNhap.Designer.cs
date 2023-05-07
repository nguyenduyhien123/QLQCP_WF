namespace _9_12_QuanLyQuanCaPhe
{
    partial class frmDangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ptxDangNhap = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ptxMatKhau = new System.Windows.Forms.PictureBox();
            this.lblNgayGio = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAnHienMatKhau = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptxDangNhap)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptxMatKhau)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã nhân viên";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 43);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMatKhau.Location = new System.Drawing.Point(75, 14);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(304, 38);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.WordWrap = false;
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(820, 66);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đăng nhập hệ thống cà phê";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNhanVien.Location = new System.Drawing.Point(75, 12);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(304, 38);
            this.txtMaNhanVien.TabIndex = 0;
            this.txtMaNhanVien.WordWrap = false;
            this.txtMaNhanVien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaNhanVien_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtMaNhanVien);
            this.panel1.Controls.Add(this.ptxDangNhap);
            this.panel1.Location = new System.Drawing.Point(235, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 65);
            this.panel1.TabIndex = 6;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // ptxDangNhap
            // 
            this.ptxDangNhap.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptxDangNhap.Image = global::_9_12_QuanLyQuanCaPhe.Properties.Resources.Custom_Icon_Design_Pretty_Office_8_Users;
            this.ptxDangNhap.Location = new System.Drawing.Point(8, 12);
            this.ptxDangNhap.Name = "ptxDangNhap";
            this.ptxDangNhap.Size = new System.Drawing.Size(46, 38);
            this.ptxDangNhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptxDangNhap.TabIndex = 2;
            this.ptxDangNhap.TabStop = false;
            this.ptxDangNhap.Click += new System.EventHandler(this.ptxDangNhap_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtMatKhau);
            this.panel2.Controls.Add(this.ptxMatKhau);
            this.panel2.Location = new System.Drawing.Point(235, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 65);
            this.panel2.TabIndex = 4;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // ptxMatKhau
            // 
            this.ptxMatKhau.BackColor = System.Drawing.Color.White;
            this.ptxMatKhau.Image = global::_9_12_QuanLyQuanCaPhe.Properties.Resources.Papirus_Team_Papirus_Apps_Preferences_desktop_user_password;
            this.ptxMatKhau.Location = new System.Drawing.Point(9, 14);
            this.ptxMatKhau.Name = "ptxMatKhau";
            this.ptxMatKhau.Size = new System.Drawing.Size(48, 38);
            this.ptxMatKhau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptxMatKhau.TabIndex = 2;
            this.ptxMatKhau.TabStop = false;
            this.ptxMatKhau.Click += new System.EventHandler(this.ptxMatKhau_Click);
            // 
            // lblNgayGio
            // 
            this.lblNgayGio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNgayGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayGio.Location = new System.Drawing.Point(0, 343);
            this.lblNgayGio.Name = "lblNgayGio";
            this.lblNgayGio.Size = new System.Drawing.Size(820, 46);
            this.lblNgayGio.TabIndex = 7;
            this.lblNgayGio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnAnHienMatKhau
            // 
            this.btnAnHienMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnHienMatKhau.Location = new System.Drawing.Point(648, 108);
            this.btnAnHienMatKhau.Name = "btnAnHienMatKhau";
            this.btnAnHienMatKhau.Size = new System.Drawing.Size(91, 65);
            this.btnAnHienMatKhau.TabIndex = 8;
            this.btnAnHienMatKhau.Text = "Hiện";
            this.btnAnHienMatKhau.UseVisualStyleBackColor = true;
            this.btnAnHienMatKhau.Click += new System.EventHandler(this.btnAnHienMatKhau_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDangNhap.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Image = global::_9_12_QuanLyQuanCaPhe.Properties.Resources.Kyo_Tux_Aeon_Sign_Forward;
            this.btnDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangNhap.Location = new System.Drawing.Point(235, 188);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(394, 65);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnAnHienMatKhau);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.btnDangNhap);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(27, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(773, 256);
            this.panel3.TabIndex = 10;
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(820, 389);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblNgayGio);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDangNhap_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDangNhap_FormClosed);
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptxDangNhap)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptxMatKhau)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox ptxMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.PictureBox ptxDangNhap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblNgayGio;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAnHienMatKhau;
        private System.Windows.Forms.Panel panel3;
    }
}