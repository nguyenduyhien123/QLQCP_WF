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
            this.label1 = new System.Windows.Forms.Label();
            this.lblThangDoanhThuCaoNhat = new System.Windows.Forms.Label();
            this.lblThangCoLoiNhieuNhat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.chartThongKeHoaDonBan.Location = new System.Drawing.Point(12, 1);
            this.chartThongKeHoaDonBan.Name = "chartThongKeHoaDonBan";
            this.chartThongKeHoaDonBan.Size = new System.Drawing.Size(1204, 734);
            this.chartThongKeHoaDonBan.TabIndex = 0;
            this.chartThongKeHoaDonBan.Text = "chart1";
            this.chartThongKeHoaDonBan.Click += new System.EventHandler(this.chartThongKeHoaDonBan_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            // 
            // grpThongTinTomTat
            // 
            this.grpThongTinTomTat.BackColor = System.Drawing.Color.White;
            this.grpThongTinTomTat.Controls.Add(this.label4);
            this.grpThongTinTomTat.Controls.Add(this.lblThangDoanhThuCaoNhat);
            this.grpThongTinTomTat.Controls.Add(this.lblThangCoLoiNhieuNhat);
            this.grpThongTinTomTat.Controls.Add(this.label1);
            this.grpThongTinTomTat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinTomTat.Location = new System.Drawing.Point(1222, 12);
            this.grpThongTinTomTat.Name = "grpThongTinTomTat";
            this.grpThongTinTomTat.Size = new System.Drawing.Size(515, 723);
            this.grpThongTinTomTat.TabIndex = 1;
            this.grpThongTinTomTat.TabStop = false;
            this.grpThongTinTomTat.Text = "Thông tin tóm tắt";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng có doanh thu cao nhất";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblThangDoanhThuCaoNhat
            // 
            this.lblThangDoanhThuCaoNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblThangDoanhThuCaoNhat.Location = new System.Drawing.Point(27, 98);
            this.lblThangDoanhThuCaoNhat.Name = "lblThangDoanhThuCaoNhat";
            this.lblThangDoanhThuCaoNhat.Size = new System.Drawing.Size(455, 61);
            this.lblThangDoanhThuCaoNhat.TabIndex = 0;
            this.lblThangDoanhThuCaoNhat.Text = "Tháng ...";
            this.lblThangDoanhThuCaoNhat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThangCoLoiNhieuNhat
            // 
            this.lblThangCoLoiNhieuNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblThangCoLoiNhieuNhat.Location = new System.Drawing.Point(27, 229);
            this.lblThangCoLoiNhieuNhat.Name = "lblThangCoLoiNhieuNhat";
            this.lblThangCoLoiNhieuNhat.Size = new System.Drawing.Size(455, 61);
            this.lblThangCoLoiNhieuNhat.TabIndex = 0;
            this.lblThangCoLoiNhieuNhat.Text = "Tháng ...";
            this.lblThangCoLoiNhieuNhat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(27, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(441, 61);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tháng có lời nhiều nhất";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmHoaDonBan_TimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1749, 747);
            this.Controls.Add(this.grpThongTinTomTat);
            this.Controls.Add(this.chartThongKeHoaDonBan);
            this.Name = "frmHoaDonBan_TimKiem";
            this.Text = "frmHoaDonBan_TimKiem";
            this.Load += new System.EventHandler(this.frmHoaDonBan_TimKiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeHoaDonBan)).EndInit();
            this.grpThongTinTomTat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeHoaDonBan;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox grpThongTinTomTat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblThangDoanhThuCaoNhat;
        private System.Windows.Forms.Label lblThangCoLoiNhieuNhat;
        private System.Windows.Forms.Label label1;
    }
}