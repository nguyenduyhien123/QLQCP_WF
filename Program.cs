using System;
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
            frmDangNhap frmDangNhap = new frmDangNhap();
            Application.Run(frmDangNhap);
            //frmSanPham frmSanPham = new frmSanPham();
            //Application.Run(frmSanPham);
            //frmHoaDonBan frmHoaDonBan = new frmHoaDonBan("NV4");
            //Application.Run(frmHoaDonBan);
            //frmHoaDon_TimKiem frmHoaDon_TimKiem = new frmHoaDon_TimKiem();
            //Application.Run(frmHoaDon_TimKiem);
        }
    }
}
