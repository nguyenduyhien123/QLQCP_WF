namespace _9_12_QuanLyQuanCaPhe
{
    partial class frmThayDoiMatKhau
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAnHienMatKhauMoi = new System.Windows.Forms.Button();
            this.pnlMatKhauMoi = new System.Windows.Forms.Panel();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.picMatKhauMoi = new System.Windows.Forms.PictureBox();
            this.btnAnHienMatKhauCu = new System.Windows.Forms.Button();
            this.pnlMatKhauCu = new System.Windows.Forms.Panel();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.picMatKhauCu = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThayDoiMatKhau = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlMatKhauMoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMatKhauMoi)).BeginInit();
            this.pnlMatKhauCu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMatKhauCu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thay đổi mật khẩu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAnHienMatKhauMoi);
            this.panel1.Controls.Add(this.pnlMatKhauMoi);
            this.panel1.Controls.Add(this.btnAnHienMatKhauCu);
            this.panel1.Controls.Add(this.pnlMatKhauCu);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnThayDoiMatKhau);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 303);
            this.panel1.TabIndex = 1;
            // 
            // btnAnHienMatKhauMoi
            // 
            this.btnAnHienMatKhauMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnHienMatKhauMoi.Location = new System.Drawing.Point(639, 135);
            this.btnAnHienMatKhauMoi.Name = "btnAnHienMatKhauMoi";
            this.btnAnHienMatKhauMoi.Size = new System.Drawing.Size(91, 65);
            this.btnAnHienMatKhauMoi.TabIndex = 12;
            this.btnAnHienMatKhauMoi.Text = "Hiện";
            this.btnAnHienMatKhauMoi.UseVisualStyleBackColor = true;
            this.btnAnHienMatKhauMoi.Click += new System.EventHandler(this.btnAnHienMatKhauMoi_Click);
            // 
            // pnlMatKhauMoi
            // 
            this.pnlMatKhauMoi.BackColor = System.Drawing.Color.White;
            this.pnlMatKhauMoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMatKhauMoi.Controls.Add(this.txtMatKhauMoi);
            this.pnlMatKhauMoi.Controls.Add(this.picMatKhauMoi);
            this.pnlMatKhauMoi.Location = new System.Drawing.Point(230, 135);
            this.pnlMatKhauMoi.Name = "pnlMatKhauMoi";
            this.pnlMatKhauMoi.Size = new System.Drawing.Size(394, 65);
            this.pnlMatKhauMoi.TabIndex = 11;
            this.pnlMatKhauMoi.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMatKhauMoi_Paint);
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauMoi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMatKhauMoi.Location = new System.Drawing.Point(75, 14);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(304, 38);
            this.txtMatKhauMoi.TabIndex = 1;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            this.txtMatKhauMoi.WordWrap = false;
            this.txtMatKhauMoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhauMoi_KeyDown);
            // 
            // picMatKhauMoi
            // 
            this.picMatKhauMoi.BackColor = System.Drawing.Color.White;
            this.picMatKhauMoi.Image = global::_9_12_QuanLyQuanCaPhe.Properties.Resources.Papirus_Team_Papirus_Apps_Preferences_desktop_user_password;
            this.picMatKhauMoi.Location = new System.Drawing.Point(9, 14);
            this.picMatKhauMoi.Name = "picMatKhauMoi";
            this.picMatKhauMoi.Size = new System.Drawing.Size(48, 38);
            this.picMatKhauMoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMatKhauMoi.TabIndex = 2;
            this.picMatKhauMoi.TabStop = false;
            // 
            // btnAnHienMatKhauCu
            // 
            this.btnAnHienMatKhauCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnHienMatKhauCu.Location = new System.Drawing.Point(639, 53);
            this.btnAnHienMatKhauCu.Name = "btnAnHienMatKhauCu";
            this.btnAnHienMatKhauCu.Size = new System.Drawing.Size(91, 65);
            this.btnAnHienMatKhauCu.TabIndex = 12;
            this.btnAnHienMatKhauCu.Text = "Hiện";
            this.btnAnHienMatKhauCu.UseVisualStyleBackColor = true;
            this.btnAnHienMatKhauCu.Click += new System.EventHandler(this.btnAnHienMatKhauCu_Click);
            // 
            // pnlMatKhauCu
            // 
            this.pnlMatKhauCu.BackColor = System.Drawing.Color.White;
            this.pnlMatKhauCu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMatKhauCu.Controls.Add(this.txtMatKhauCu);
            this.pnlMatKhauCu.Controls.Add(this.picMatKhauCu);
            this.pnlMatKhauCu.Location = new System.Drawing.Point(230, 53);
            this.pnlMatKhauCu.Name = "pnlMatKhauCu";
            this.pnlMatKhauCu.Size = new System.Drawing.Size(394, 65);
            this.pnlMatKhauCu.TabIndex = 11;
            this.pnlMatKhauCu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMatKhauCu_Paint);
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhauCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauCu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMatKhauCu.Location = new System.Drawing.Point(75, 14);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Size = new System.Drawing.Size(304, 38);
            this.txtMatKhauCu.TabIndex = 1;
            this.txtMatKhauCu.UseSystemPasswordChar = true;
            this.txtMatKhauCu.WordWrap = false;
            this.txtMatKhauCu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhauCu_KeyDown);
            // 
            // picMatKhauCu
            // 
            this.picMatKhauCu.BackColor = System.Drawing.Color.White;
            this.picMatKhauCu.Image = global::_9_12_QuanLyQuanCaPhe.Properties.Resources.Papirus_Team_Papirus_Apps_Preferences_desktop_user_password;
            this.picMatKhauCu.Location = new System.Drawing.Point(9, 14);
            this.picMatKhauCu.Name = "picMatKhauCu";
            this.picMatKhauCu.Size = new System.Drawing.Size(48, 38);
            this.picMatKhauCu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMatKhauCu.TabIndex = 2;
            this.picMatKhauCu.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 43);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mật khẩu mới";
            // 
            // btnThayDoiMatKhau
            // 
            this.btnThayDoiMatKhau.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThayDoiMatKhau.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnThayDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThayDoiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThayDoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnThayDoiMatKhau.Image = global::_9_12_QuanLyQuanCaPhe.Properties.Resources.Kyo_Tux_Aeon_Sign_Forward;
            this.btnThayDoiMatKhau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThayDoiMatKhau.Location = new System.Drawing.Point(230, 218);
            this.btnThayDoiMatKhau.Name = "btnThayDoiMatKhau";
            this.btnThayDoiMatKhau.Size = new System.Drawing.Size(394, 65);
            this.btnThayDoiMatKhau.TabIndex = 10;
            this.btnThayDoiMatKhau.Text = "Cập nhật";
            this.btnThayDoiMatKhau.UseVisualStyleBackColor = false;
            this.btnThayDoiMatKhau.Click += new System.EventHandler(this.btnThayDoiMatKhau_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 43);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // frmThayDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 408);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThayDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmThayDoiMatKhau_FormClosing);
            this.panel1.ResumeLayout(false);
            this.pnlMatKhauMoi.ResumeLayout(false);
            this.pnlMatKhauMoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMatKhauMoi)).EndInit();
            this.pnlMatKhauCu.ResumeLayout(false);
            this.pnlMatKhauCu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMatKhauCu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAnHienMatKhauMoi;
        private System.Windows.Forms.Panel pnlMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.PictureBox picMatKhauMoi;
        private System.Windows.Forms.Button btnAnHienMatKhauCu;
        private System.Windows.Forms.Panel pnlMatKhauCu;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.PictureBox picMatKhauCu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThayDoiMatKhau;
        private System.Windows.Forms.Label label2;
    }
}