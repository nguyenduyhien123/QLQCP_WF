namespace _9_12_QuanLyQuanCaPhe
{
    partial class frmLichSuDangNhap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDanhSachLichSuDangNhap = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYGIODANGNHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYGIODANGXUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUADOIMATKHAU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachLichSuDangNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1002, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lịch sử đăng nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDanhSachLichSuDangNhap);
            this.panel1.Location = new System.Drawing.Point(12, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 382);
            this.panel1.TabIndex = 1;
            // 
            // dgvDanhSachLichSuDangNhap
            // 
            this.dgvDanhSachLichSuDangNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachLichSuDangNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSachLichSuDangNhap.ColumnHeadersHeight = 29;
            this.dgvDanhSachLichSuDangNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDanhSachLichSuDangNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.NGAYGIODANGNHAP,
            this.NGAYGIODANGXUAT,
            this.SUADOIMATKHAU});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSachLichSuDangNhap.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachLichSuDangNhap.Location = new System.Drawing.Point(3, 38);
            this.dgvDanhSachLichSuDangNhap.Name = "dgvDanhSachLichSuDangNhap";
            this.dgvDanhSachLichSuDangNhap.RowHeadersWidth = 51;
            this.dgvDanhSachLichSuDangNhap.RowTemplate.Height = 24;
            this.dgvDanhSachLichSuDangNhap.Size = new System.Drawing.Size(963, 298);
            this.dgvDanhSachLichSuDangNhap.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.FillWeight = 32.08556F;
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NGAYGIODANGNHAP
            // 
            this.NGAYGIODANGNHAP.DataPropertyName = "NGAYGIODANGNHAP";
            this.NGAYGIODANGNHAP.FillWeight = 134.6333F;
            this.NGAYGIODANGNHAP.HeaderText = "NGÀY ĐĂNG NHẬP";
            this.NGAYGIODANGNHAP.MinimumWidth = 6;
            this.NGAYGIODANGNHAP.Name = "NGAYGIODANGNHAP";
            this.NGAYGIODANGNHAP.ReadOnly = true;
            this.NGAYGIODANGNHAP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NGAYGIODANGXUAT
            // 
            this.NGAYGIODANGXUAT.DataPropertyName = "NGAYGIODANGXUAT";
            this.NGAYGIODANGXUAT.FillWeight = 138.369F;
            this.NGAYGIODANGXUAT.HeaderText = "NGÀY ĐĂNG XUẤT";
            this.NGAYGIODANGXUAT.MinimumWidth = 6;
            this.NGAYGIODANGXUAT.Name = "NGAYGIODANGXUAT";
            this.NGAYGIODANGXUAT.ReadOnly = true;
            this.NGAYGIODANGXUAT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // SUADOIMATKHAU
            // 
            this.SUADOIMATKHAU.DataPropertyName = "SUADOIMATKHAU";
            this.SUADOIMATKHAU.FillWeight = 94.91203F;
            this.SUADOIMATKHAU.HeaderText = "SỬA ĐỔI MẬT KHẨU";
            this.SUADOIMATKHAU.MinimumWidth = 6;
            this.SUADOIMATKHAU.Name = "SUADOIMATKHAU";
            this.SUADOIMATKHAU.ReadOnly = true;
            this.SUADOIMATKHAU.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // frmLichSuDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 557);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "frmLichSuDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLichSuDangNhap";
            this.Load += new System.EventHandler(this.frmLichSuDangNhap_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachLichSuDangNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDanhSachLichSuDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYGIODANGNHAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYGIODANGXUAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUADOIMATKHAU;
    }
}