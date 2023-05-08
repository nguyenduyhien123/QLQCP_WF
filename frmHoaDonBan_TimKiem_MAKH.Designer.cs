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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cboTimKiem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtThongTinTimKiem = new System.Windows.Forms.TextBox();
            this.lblThongTinTimKiem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 197);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1369, 230);
            this.dataGridView1.TabIndex = 0;
            // 
            // cboTimKiem
            // 
            this.cboTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTimKiem.FormattingEnabled = true;
            this.cboTimKiem.Items.AddRange(new object[] {
            "Mã hoá đơn",
            "Mã khách hàng",
            "Mã nhân viên",
            "Ngày lập hoá đơn",
            "Mã sản phẩm",
            "Mã size",
            "Mã khuyến mãi"});
            this.cboTimKiem.Location = new System.Drawing.Point(41, 81);
            this.cboTimKiem.Name = "cboTimKiem";
            this.cboTimKiem.Size = new System.Drawing.Size(299, 44);
            this.cboTimKiem.TabIndex = 1;
            this.cboTimKiem.SelectedIndexChanged += new System.EventHandler(this.cboTimKiem_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn tiêu chí tìm kiếm";
            // 
            // txtThongTinTimKiem
            // 
            this.txtThongTinTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongTinTimKiem.Location = new System.Drawing.Point(372, 81);
            this.txtThongTinTimKiem.Name = "txtThongTinTimKiem";
            this.txtThongTinTimKiem.Size = new System.Drawing.Size(353, 41);
            this.txtThongTinTimKiem.TabIndex = 3;
            this.txtThongTinTimKiem.TextChanged += new System.EventHandler(this.txtThongTinTimKiem_TextChanged);
            // 
            // lblThongTinTimKiem
            // 
            this.lblThongTinTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinTimKiem.Location = new System.Drawing.Point(375, 25);
            this.lblThongTinTimKiem.Name = "lblThongTinTimKiem";
            this.lblThongTinTimKiem.Size = new System.Drawing.Size(299, 41);
            this.lblThongTinTimKiem.TabIndex = 2;
            this.lblThongTinTimKiem.Text = "Nhập";
            // 
            // frmHoaDon_TimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 445);
            this.Controls.Add(this.txtThongTinTimKiem);
            this.Controls.Add(this.lblThongTinTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTimKiem);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmHoaDon_TimKiem";
            this.Text = "frmHoaDonBan_TimKiem_MAKH";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtThongTinTimKiem;
        private System.Windows.Forms.Label lblThongTinTimKiem;
    }
}