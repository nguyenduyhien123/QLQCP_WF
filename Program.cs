﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9_12_QuanLyQuanCaPhe
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //frmDangNhap frmDangNhap = new frmDangNhap();
            //Application.Run(frmDangNhap);
            frmSanPham frmSanPham = new frmSanPham();
            Application.Run(frmSanPham);
            //frmHoaDonBan frmHoaDonBan = new frmHoaDonBan("NV3");
            //Application.Run(frmHoaDonBan);
            //frmHoaDon_TimKiem frmHoaDon_TimKiem = new frmHoaDon_TimKiem();
            //Application.Run(frmHoaDon_TimKiem);
            //frmHoaDon_TimKiem frmHoaDon_TimKiem = new frmHoaDon_TimKiem();
            //Application.Run(frmHoaDon_TimKiem);
            //frmHoaDonBan_ThongKeBaoCao frmHoaDonBan_TimKiem = new frmHoaDonBan_ThongKeBaoCao();
            //Application.Run(frmHoaDonBan_TimKiem);
            //frmHoaDonBan_BaoCao frmHoaDonBan_BaoCao=new frmHoaDonBan_BaoCao();
            //Application.Run(frmHoaDonBan_BaoCao);
            //frmSanPham_TimKiem f = new frmSanPham_TimKiem();
            //Application.Run(f);
        }
    }
}
