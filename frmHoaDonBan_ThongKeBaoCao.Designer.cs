namespace _9_12_QuanLyQuanCaPhe
{
    partial class frmHoaDonBan_ThongKeBaoCao
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chartThongKeHoaDonBan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpThongTinTomTat = new System.Windows.Forms.GroupBox();
            this.lblCoLoiNhieuNhat = new System.Windows.Forms.Label();
            this.lblThangDoanhThuCaoNhat = new System.Windows.Forms.Label();
            this.lblThangCoLoiNhieuNhat = new System.Windows.Forms.Label();
            this.lblDoanhThuCaoNhat = new System.Windows.Forms.Label();
            this.cboTieuChiThongKe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpThoiGianThongKe = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeHoaDonBan)).BeginInit();
            this.grpThongTinTomTat.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartThongKeHoaDonBan
            // 
            chartArea1.Name = "ChartArea1";
            this.chartThongKeHoaDonBan.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThongKeHoaDonBan.Legends.Add(legend1);
            this.chartThongKeHoaDonBan.Location = new System.Drawing.Point(12, 138);
            this.chartThongKeHoaDonBan.Name = "chartThongKeHoaDonBan";
            this.chartThongKeHoaDonBan.Size = new System.Drawing.Size(1336, 663);
            this.chartThongKeHoaDonBan.TabIndex = 0;
            this.chartThongKeHoaDonBan.Text = "chart1";
            this.chartThongKeHoaDonBan.Click += new System.EventHandler(this.chartThongKeHoaDonBan_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 2000;
            this.toolTip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 20;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // grpThongTinTomTat
            // 
            this.grpThongTinTomTat.BackColor = System.Drawing.Color.White;
            this.grpThongTinTomTat.Controls.Add(this.lblCoLoiNhieuNhat);
            this.grpThongTinTomTat.Controls.Add(this.lblThangDoanhThuCaoNhat);
            this.grpThongTinTomTat.Controls.Add(this.lblThangCoLoiNhieuNhat);
            this.grpThongTinTomTat.Controls.Add(this.lblDoanhThuCaoNhat);
            this.grpThongTinTomTat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinTomTat.Location = new System.Drawing.Point(1354, 138);
            this.grpThongTinTomTat.Name = "grpThongTinTomTat";
            this.grpThongTinTomTat.Size = new System.Drawing.Size(431, 663);
            this.grpThongTinTomTat.TabIndex = 1;
            this.grpThongTinTomTat.TabStop = false;
            this.grpThongTinTomTat.Text = "Thông tin tóm tắt";
            // 
            // lblCoLoiNhieuNhat
            // 
            this.lblCoLoiNhieuNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoLoiNhieuNhat.Location = new System.Drawing.Point(7, 191);
            this.lblCoLoiNhieuNhat.Name = "lblCoLoiNhieuNhat";
            this.lblCoLoiNhieuNhat.Size = new System.Drawing.Size(394, 76);
            this.lblCoLoiNhieuNhat.TabIndex = 0;
            this.lblCoLoiNhieuNhat.Text = "Tháng có lời nhiều nhất";
            this.lblCoLoiNhieuNhat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThangDoanhThuCaoNhat
            // 
            this.lblThangDoanhThuCaoNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblThangDoanhThuCaoNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThangDoanhThuCaoNhat.Location = new System.Drawing.Point(5, 130);
            this.lblThangDoanhThuCaoNhat.Name = "lblThangDoanhThuCaoNhat";
            this.lblThangDoanhThuCaoNhat.Size = new System.Drawing.Size(408, 61);
            this.lblThangDoanhThuCaoNhat.TabIndex = 0;
            this.lblThangDoanhThuCaoNhat.Text = "Tháng ...";
            this.lblThangDoanhThuCaoNhat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThangCoLoiNhieuNhat
            // 
            this.lblThangCoLoiNhieuNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblThangCoLoiNhieuNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThangCoLoiNhieuNhat.Location = new System.Drawing.Point(6, 276);
            this.lblThangCoLoiNhieuNhat.Name = "lblThangCoLoiNhieuNhat";
            this.lblThangCoLoiNhieuNhat.Size = new System.Drawing.Size(408, 61);
            this.lblThangCoLoiNhieuNhat.TabIndex = 0;
            this.lblThangCoLoiNhieuNhat.Text = "Tháng ...";
            this.lblThangCoLoiNhieuNhat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDoanhThuCaoNhat
            // 
            this.lblDoanhThuCaoNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuCaoNhat.Location = new System.Drawing.Point(7, 34);
            this.lblDoanhThuCaoNhat.Name = "lblDoanhThuCaoNhat";
            this.lblDoanhThuCaoNhat.Size = new System.Drawing.Size(394, 85);
            this.lblDoanhThuCaoNhat.TabIndex = 0;
            this.lblDoanhThuCaoNhat.Text = "Tháng có doanh thu cao nhất";
            this.lblDoanhThuCaoNhat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTieuChiThongKe
            // 
            this.cboTieuChiThongKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTieuChiThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTieuChiThongKe.FormattingEnabled = true;
            this.cboTieuChiThongKe.Items.AddRange(new object[] {
            "Theo từng năm",
            "Theo từng tháng trong một năm",
            "Theo từng ngày trong một tháng trong năm"});
            this.cboTieuChiThongKe.Location = new System.Drawing.Point(19, 66);
            this.cboTieuChiThongKe.Name = "cboTieuChiThongKe";
            this.cboTieuChiThongKe.Size = new System.Drawing.Size(852, 50);
            this.cboTieuChiThongKe.TabIndex = 2;
            this.cboTieuChiThongKe.SelectedIndexChanged += new System.EventHandler(this.cboTieuChiThongKe_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(538, 54);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn tiêu chí thống kê";
            // 
            // dtpThoiGianThongKe
            // 
            this.dtpThoiGianThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThoiGianThongKe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGianThongKe.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dtpThoiGianThongKe.Location = new System.Drawing.Point(877, 67);
            this.dtpThoiGianThongKe.Name = "dtpThoiGianThongKe";
            this.dtpThoiGianThongKe.Size = new System.Drawing.Size(268, 49);
            this.dtpThoiGianThongKe.TabIndex = 4;
            this.dtpThoiGianThongKe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpThoiGianThongKe_KeyDown);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(1168, 67);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(217, 49);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // frmHoaDonBan_ThongKeBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 830);
            this.Controls.Add(this.grpThongTinTomTat);
            this.Controls.Add(this.chartThongKeHoaDonBan);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtpThoiGianThongKe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTieuChiThongKe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmHoaDonBan_ThongKeBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoá Đơn bán - Thống Kê Doanh Thu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHoaDonBan_ThongKeBaoCao_FormClosing);
            this.Load += new System.EventHandler(this.frmHoaDonBan_TimKiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeHoaDonBan)).EndInit();
            this.grpThongTinTomTat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeHoaDonBan;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox grpThongTinTomTat;
        private System.Windows.Forms.Label lblCoLoiNhieuNhat;
        private System.Windows.Forms.Label lblThangDoanhThuCaoNhat;
        private System.Windows.Forms.Label lblThangCoLoiNhieuNhat;
        private System.Windows.Forms.Label lblDoanhThuCaoNhat;
        private System.Windows.Forms.ComboBox cboTieuChiThongKe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpThoiGianThongKe;
        private System.Windows.Forms.Button btnThongKe;
    }
}