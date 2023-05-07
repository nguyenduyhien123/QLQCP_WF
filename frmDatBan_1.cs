using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9_12_QuanLyQuanCaPhe
{
    public partial class frmDatBan_1 : Form
    {
        public frmDatBan_1()
        {
            InitializeComponent();

        }
        _9_12_QuanLyQuanCaPhe c = new _9_12_QuanLyQuanCaPhe();
        void TaoBan(int n)
        {
            int buttonWidth = 50; // Chiều rộng của Button
            int buttonHeight = 30; // Chiều cao của Button
            int buttonSpacing = 80; // Khoảng cách giữa các Button
            int labelWidth = 25;
            int labelHeight = 15;
            int labelSpacing= 15;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    Label lbl = new Label();
                    lbl.Name = "lblGhe" + i + "_" + j;
                    lbl.Text = j.ToString();
                    lbl.Size = new Size(labelWidth,labelHeight);
                    lbl.Location = new Point(i * (labelWidth+labelSpacing),i*(labelHeight+10));
                    this.Controls.Add(lbl);
                }
                Button btn = new Button();
                btn.Name = "btnBan" + i;
                btn.Text = "Bàn " + i.ToString();
                btn.Size = new Size(buttonWidth, buttonHeight);
                btn.Location= new Point(i *( buttonWidth + buttonSpacing), buttonHeight);
                this.Controls.Add(btn);
                for (int j = 3; j <= 4; j++)
                {
                    Label lbl = new Label();
                    lbl.Name = "lblGhe" + i + "_" + j;
                    lbl.Text = j.ToString();
                    lbl.Size = new Size(labelWidth,labelHeight);
                        lbl.Location = new Point(i * (labelWidth + labelSpacing), i * (labelHeight + 10));
                    this.Controls.Add(lbl);
                }
            }
        }
        DataSet ds = new DataSet();
        void danhsach( string sql)
        {
            ds = c.LayDuLieu(sql);
            //d.DataSource = ds.Tables[0];
        }
        //List<Button> dsButtonDaAn = new List<Button>();
        List<Button> dsCacBanDaChon = new List<Button>();
        List<Button> dsCacBan = new List<Button>();
        Color mauBanTrong= Color.LightGreen;
        Color mauBanDatTruoc = Color.Orange;
        Color mauBanDangSuDung= Color.Red;
        Color mauBanDaChon = Color.Aqua;
        Color mauBanVoHieuHoa = Color.White;
        // Số bàn muốn hiển thị ra màn hình
        int sobanhienthi = 60;
        private void CreateDynamicControls(int buttonCount = 20,int buttonsPerRow = 5)
        {
            // Tạo danh sách các Button động
            List<Button> dynamicButtons = new List<Button>();

            // Tạo các Button động
           
            int buttonWidth = 150;
            int buttonHeight = 80;
            int buttonSpacing = 120;

            int startX = this.ClientSize.Width / 2 - (buttonsPerRow * (buttonWidth + buttonSpacing) - buttonSpacing) / 2;
            int startY = 50;

            for (int i = 0; i < buttonCount; i++)
            {
                Color color = new Color();
                color = MauCuaBan(ds.Tables[0].Rows[i]["TRANGTHAI"].ToString());
                //danhsach_datagridview(dgvDanhSach, "SELECT * FROM SANPHAM WHERE TRANGTHAI=1");
                Button dynamicButton = new Button();
                dynamicButton.Name = "btnBan" + (i + 1);
                dynamicButton.Text = $"{ds.Tables[0].Rows[i]["TENBAN"]}";
                dynamicButton.Size = new Size(buttonWidth, buttonHeight);
                dynamicButton.Location = new Point(startX + (i % buttonsPerRow) * (buttonWidth + buttonSpacing),
                    startY + (i / buttonsPerRow) * (buttonHeight + buttonSpacing));
                dynamicButton.Font= new Font("Time New Romans", 18);
                dynamicButton.BackColor = color;
                dynamicButton.Click += ButtonClick;
                dynamicButtons.Add(dynamicButton);
                dsCacBan.Add(dynamicButton);
                // Tạo danh sách các Label động cho Button này
                List<Label> dynamicLabels = new List<Label>();

                // Tạo các Label động
                int labelWidth = 30;
                int labelHeight = 30;
                int labelSpacing = 10;
                Label lblLeftTop = new Label();
                lblLeftTop.Name = "lblBan" + (i + 1) + "_1";
                lblLeftTop.Text = "" + (1);
                lblLeftTop.Size = new Size(labelWidth, labelHeight);
                lblLeftTop.Location = new Point(dynamicButton.Location.X - lblLeftTop.Width- labelSpacing, dynamicButton.Location.Y);
                lblLeftTop.BackColor = color;
                lblLeftTop.Font = new Font("Time New Romans", 12);
                lblLeftTop.TextAlign = ContentAlignment.MiddleCenter;
                dynamicLabels.Add(lblLeftTop);

                Label lblLeftBottom = new Label();
                lblLeftBottom.Name = "lblBan" + (i + 1) + "_2";
                lblLeftBottom.Text = "" + (2);
                lblLeftBottom.Size = new Size(labelWidth, labelHeight);
                lblLeftBottom.Location = new Point(dynamicButton.Location.X - lblLeftBottom.Width- labelSpacing, dynamicButton.Location.Y + dynamicButton.Height - lblLeftBottom.Height);
                lblLeftBottom.BackColor = color;
                lblLeftBottom.Font = new Font("Time New Romans", 12);
                lblLeftBottom.TextAlign = ContentAlignment.MiddleCenter;
                dynamicLabels.Add(lblLeftBottom);

                Label lblRightTop = new Label();
                lblRightTop.Name = "lblBan" + (i + 1) + "_3";
                lblRightTop.Text = "" + (3);
                lblRightTop.Size = new Size(labelWidth, labelHeight);
                lblRightTop.Location = new Point(dynamicButton.Location.X + dynamicButton.Width+ labelSpacing, dynamicButton.Location.Y);
                lblRightTop.BackColor = color;
                lblRightTop.Font = new Font("Time New Romans", 12);
                lblRightTop.TextAlign = ContentAlignment.MiddleCenter;
                dynamicLabels.Add(lblRightTop);

                Label lblRightBottom = new Label();
                lblRightBottom.Name = "lblBan" + (i + 1) + "_4";
                lblRightBottom.Text = "" + ( 4);
                lblRightBottom.Size = new Size(labelWidth, labelHeight);
                lblRightBottom.Location = new Point(dynamicButton.Location.X + dynamicButton.Width+ labelSpacing, dynamicButton.Location.Y + dynamicButton.Height - lblRightBottom.Height);
                lblRightBottom.BackColor = color;
                lblRightBottom.Font = new Font("Time New Romans", 12);
                lblRightBottom.TextAlign = ContentAlignment.MiddleCenter;
                dynamicLabels.Add(lblRightBottom);

                // Thêm Labels vào Form
                foreach (Label lbl in dynamicLabels)
                {
                    //this.Controls.Add(lbl);
                    pnlBan.Controls.Add(lbl);
                }
            }

            // Thêm Buttons vào Form
            foreach (Button btn in dynamicButtons)
            {
                //this.Controls.Add(btn);
                pnlBan.Controls.Add(btn);

            }
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int soban = Convert.ToInt32(btn.Name.Substring(6));// Name : btnBan, nên cắt từ index thứ 6
            //MessageBox.Show(soban.ToString(), "Thông báo");
            List<Label> labels = new List<Label>();
            for (int i=1; i <= 4;i++)
            {
                string labelname = "lblBan" +  soban +"_"+i;
                Control[] foundLabels = this.Controls.Find(labelname, true);
                // Control button, label, textbox, ....
                if (foundLabels.Length > 0 && foundLabels[0] is Label)
                {
                    Label label = (Label)foundLabels[0];
                    labels.Add(label);
                }
            }
            //List<Button> dsButtonDaAn = new List<Button>();
            // Người dùng đã chọn button này, nhưng bây giờ không muốn chọn nữa
            if (dsCacBanDaChon.IndexOf(btn) != -1) // Tức là button này đã ấn, trả về index khác -1
            {
                dsCacBanDaChon.Remove(btn); // Gỡ button này ra khỏi danh sách button đã ấn
                // ..........................
                KhoiPhucLaiMauBanDauCuaBan(btn, soban);
                // ..........................
            }
            // người dùng muốn chọn lại button này
            else
            {
                dsCacBanDaChon.Add(btn); // Thêm button này vào danh sách các button đã ấn
                btn.BackColor = mauBanDaChon;
                //btn.Font = new Font("Time News Romans", 18,FontStyle.Bold);
                foreach (Label i in labels)
                {
                    i.BackColor = mauBanDaChon;
                    //Thread.Sleep(500);
                }
            }
            lblCacBanDaDat.Text = "Các bàn đã chọn: ";
            if (dsCacBanDaChon.Count == 0)
            {
                lblCacBanDaDat.Text += $"({dsCacBanDaChon.Count}): ";
            }
            else
            {
                lblCacBanDaDat.Text+= $"({dsCacBanDaChon.Count}): ";
                dsCacBanDaChon =dsCacBanDaChon.OrderBy(i => int.Parse(i.Name.Substring(6))).ToList();// Sắp xếp lại list theo name của phần tử, theo giá trị số
                for(int i=0;i<dsCacBanDaChon.Count-1;i++)
                {
                    lblCacBanDaDat.Text += dsCacBanDaChon[i].Text + ",  ";
                }
                lblCacBanDaDat.Text += dsCacBanDaChon[dsCacBanDaChon.Count - 1].Text+".";
            }
        }
        void KhoiPhucLaiMauBanDauCuaBan(Button btn,int vitri)
        {
            if (ds.Tables[0].Rows[vitri - 1]["TRANGTHAI"].ToString() == "DANG SU DUNG")
            {
                btn.Enabled = true;
                btn.BackColor = mauBanDangSuDung;
                DoiMauLabelTuongUngVoiButton(btn, mauBanDangSuDung);
            }
            else if (ds.Tables[0].Rows[vitri - 1]["TRANGTHAI"].ToString() == "TRONG")
            {
                btn.Enabled = true;
                btn.BackColor = mauBanTrong;
                DoiMauLabelTuongUngVoiButton(btn, mauBanTrong);
            }
            else if (ds.Tables[0].Rows[vitri - 1]["TRANGTHAI"].ToString() == "DAT BAN TRUOC")
            {
                btn.Enabled = true;
                btn.BackColor = mauBanDatTruoc;
                DoiMauLabelTuongUngVoiButton(btn, mauBanDatTruoc);
            }
        }
        private void LabelClick(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            MessageBox.Show(lbl.Name, "Thông báo");
        }
        private void frmDatBan_1_Load(object sender, EventArgs e)
        {
            //dsCacBan.Clear();
            //dsCacBanDaChon.Clear();
            //pnlBan.Controls.Clear();
            danhsach($"SELECT * FROM BAN");
            CreateDynamicControls(ds.Tables[0].Rows.Count, 5);
        }
        private void button1_Click(object sender, EventArgs e)
        {
             
        }

        private void lblCacBanDaDat_Click(object sender, EventArgs e)
        {

        }

        private void chọnMàuGhếToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pnlBan_Paint(object sender, PaintEventArgs e)
        {

        }
        private Color MauCuaBan(string loai)
        {
            Color color = new Color();
            color = Color.Red;
            switch (loai)
            {
                case "DANG SU DUNG":
                    {
                        color = mauBanDangSuDung;
                        break;
                    }
                case "DAT BAN TRUOC":
                    {
                        color = mauBanDatTruoc;
                        break;
                    }
                case "TRONG":
                    {
                        color =mauBanTrong;
                        break;
                    }
            }
            return color;
        }
        private void MauCuaBanDaChon(string loai)
        {
            Color color = new Color();
            color = Color.Red;
            switch (loai)
                {
                case "DANG SU DUNG":
                    {
                        color = mauBanDangSuDung;
                        break;
                    }
                case "DAT BAN TRUOC":
                    {
                        color = mauBanDatTruoc;
                        break;
                    }
                case "TRONG":
                    {
                        color = mauBanTrong;
                        break;
                    }
            }
            foreach (Button i in dsCacBanDaChon)
            {
                int soban = Convert.ToInt32(i.Name.Substring(6));// Name : btnBan, nên cắt từ index thứ 6
                                                                 //MessageBox.Show(soban.ToString(), "Thông báo");
                i.BackColor = color;
                List<Label> labels = new List<Label>();
                for (int j = 1; j <= 4; j++)
                {
                    string labelname = "lblBan" + soban + "_" + j;
                    Control[] foundLabels = this.Controls.Find(labelname, true);
                    // Control button, label, textbox, ....
                    if (foundLabels.Length > 0 && foundLabels[0] is Label)
                    {
                        Label label = (Label)foundLabels[0];
                        labels.Add(label);
                    }
                }
                foreach (Label j in labels)
                {
                    j.BackColor = color;
                    //Thread.Sleep(500);
                }
            }
            dsCacBanDaChon.Clear();
            lblCacBanDaDat.Text = "Các bàn đã chọn: ";
        }
        void DoiMauLabelTuongUngVoiButton(Button i,Color color)
        {
            int soban = Convert.ToInt32(i.Name.Substring(6));// Name : btnBan, nên cắt từ index thứ 6
                                                             //MessageBox.Show(soban.ToString(), "Thông báo");
            i.BackColor = color;
            List<Label> labels = new List<Label>();
            for (int j = 1; j <= 4; j++)
            {
                string labelname = "lblBan" + soban + "_" + j;
                Control[] foundLabels = this.Controls.Find(labelname, true);
                // Control button, label, textbox, ....
                if (foundLabels.Length > 0 && foundLabels[0] is Label)
                {
                    Label label = (Label)foundLabels[0];
                    labels.Add(label);
                }
            }
            foreach (Label j in labels)
            {
                j.BackColor = color;
                //Thread.Sleep(500);
            }
        }
        private void btnLuuBanDatTruoc_Click(object sender, EventArgs e)
        {
            if (dsCacBanDaChon.Count >= 1)
            {
                List<string> MaBan = new List<string>();
                MaBan = dsCacBanDaChon.Select(x => x.Name.Substring(6)).ToList();
                string ids = "'" + string.Join("','", MaBan) + "'";
                string sql = "UPDATE BAN SET TRANGTHAI='DAT BAN TRUOC' WHERE MABAN IN (" + ids + ")";
                //MessageBox.Show(sql, "Thông báo");
                int sodong = c.CapNhatDuLieu(sql);
                MauCuaBanDaChon("DAT BAN TRUOC");
                MessageBox.Show($"ĐÃ CẬP NHẬT THÀNH CÔNG {sodong} BÀN VỚI TRẠNG THÁI ĐẶT BÀN TRƯỚC", "Thông báo");
            }
        }
        private void btnLuuBanDangSuDung_Click(object sender, EventArgs e)
        {
            if (dsCacBanDaChon.Count >= 1)
            {
                List<string> MaBan = new List<string>();
                MaBan = dsCacBanDaChon.Select(x => x.Name.Substring(6)).ToList();
                string ids = "'" + string.Join("','", MaBan) + "'";
                string sql = "UPDATE BAN SET TRANGTHAI='DANG SU DUNG' WHERE MABAN IN (" + ids + ")";
                //MessageBox.Show(sql, "Thông báo");
                int sodong = c.CapNhatDuLieu(sql);
                MauCuaBanDaChon("DANG SU DUNG");
                MessageBox.Show($"ĐÃ CẬP NHẬT THÀNH CÔNG {sodong} BÀN VỚI TRẠNG THÁI ĐANG SỬ DỤNG", "Thông báo");
            }
        }

        private void btnLuuBanTrong_Click(object sender, EventArgs e)
        {
            if (dsCacBanDaChon.Count >= 1)
            {
                List<string> MaBan = new List<string>();
                MaBan = dsCacBanDaChon.Select(x => x.Name.Substring(6)).ToList();
                string ids = "'" + string.Join("','", MaBan) + "'";
                string sql = "UPDATE BAN SET TRANGTHAI='TRONG' WHERE MABAN IN (" + ids + ")";
                //MessageBox.Show(sql, "Thông báo");    
                int sodong = c.CapNhatDuLieu(sql);
                MauCuaBanDaChon("TRONG");
                MessageBox.Show($"ĐÃ CẬP NHẬT THÀNH CÔNG {sodong} BÀN VỚI TRẠNG THÁI TRỐNG", "Thông báo");
            }
        }

        private void btnCacBanTrong_Click(object sender, EventArgs e)
        {

            //ds = c.LayDuLieu($"SELECT * FROM BAN");
            //for(int i = 0; i < ds.Tables[0].Rows.Count;i++)
            //{
            //    if(ds.Tables[0].Rows[i]["TRANGTHAI"].ToString() == "TRONG")
            //    {
            //        dsCacBan[i].Enabled = true;
            //        dsCacBan[i].BackColor = mauBanTrong;
            //        DoiMauLabelTuongUngVoiButton(dsCacBan[i], mauBanTrong);
            //    }    
            //    else
            //    {
            //        dsCacBan[i].Enabled = false;
            //        dsCacBan[i].BackColor = mauBanVoHieuHoa;
            //        DoiMauLabelTuongUngVoiButton(dsCacBan[i], mauBanVoHieuHoa);
            //    }
            //}    
            pnlBan.Controls.Clear();
            danhsach("SELECT * FROM BAN WHERE TRANGTHAI ='TRONG'");
            CreateDynamicControls(ds.Tables[0].Rows.Count, 5);
        }

        private void btnCacBanDaDatTruoc_Click(object sender, EventArgs e)
        {
            //ds = c.LayDuLieu($"SELECT * FROM BAN");
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["TRANGTHAI"].ToString() == "DAT BAN TRUOC")
            //    {
            //        dsCacBan[i].Enabled = true;
            //        dsCacBan[i].BackColor = mauBanDatTruoc;
            //        DoiMauLabelTuongUngVoiButton(dsCacBan[i], mauBanDatTruoc);
            //    }
            //    else
            //    {
            //        dsCacBan[i].Enabled = false;
            //        dsCacBan[i].BackColor = mauBanVoHieuHoa;
            //        DoiMauLabelTuongUngVoiButton(dsCacBan[i], mauBanVoHieuHoa);
            //    }
            //}
            pnlBan.Controls.Clear();
            danhsach("SELECT * FROM BAN WHERE TRANGTHAI ='DAT BAN TRUOC'");
            CreateDynamicControls(ds.Tables[0].Rows.Count, 5);
        }

        private void btnCacBanDangSuDung_Click(object sender, EventArgs e)
        {
            //ds = c.LayDuLieu($"SELECT * FROM BAN");
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["TRANGTHAI"].ToString() == "DANG SU DUNG")
            //    {
            //        dsCacBan[i].Enabled = true;
            //        dsCacBan[i].BackColor = mauBanDangSuDung;
            //        DoiMauLabelTuongUngVoiButton(dsCacBan[i], mauBanDangSuDung);
            //    }
            //    else
            //    {
            //        dsCacBan[i].Enabled = false;
            //        dsCacBan[i].BackColor = mauBanVoHieuHoa;
            //        DoiMauLabelTuongUngVoiButton(dsCacBan[i], mauBanVoHieuHoa);
            //    }
            //}
            pnlBan.Controls.Clear();
            danhsach("SELECT * FROM BAN WHERE TRANGTHAI ='DANG SU DUNG'");
            CreateDynamicControls(ds.Tables[0].Rows.Count, 5);
        }

        private void btnTatCaCacBan_Click(object sender, EventArgs e)
        {
            //ds = c.LayDuLieu($"SELECT * FROM BAN");
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    KhoiPhucLaiMauBanDauCuaBan(dsCacBan[i], i + 1);
            //}
            pnlBan.Controls.Clear();
            danhsach("SELECT * FROM BAN");
            CreateDynamicControls(ds.Tables[0].Rows.Count, 5);
        }
    }
}