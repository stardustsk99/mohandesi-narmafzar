using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalaPezeshki
{
    internal static class Program
    {
        /// ---------------------------------------------------------------------
        /// نقطه شروع اصلی برنامه
        /// ---------------------------------------------------------------------
        /// <summary>
        /// نقطه ورود اصلی به برنامه (Main)
        /// </summary>
        [STAThread]
        static void Main()
        {
            // فعال‌سازی استایل‌های ویژوال برای کنترل‌های ویندوز فرم
            Application.EnableVisualStyles();

            // استفاده از رندرینگ پیش‌فرض برای متن‌ها
            Application.SetCompatibleTextRenderingDefault(false);

            // نمایش فرم لاگین
            using (frmLogin login = new frmLogin())
            {
                DialogResult result = login.ShowDialog();

                // در صورت لاگین موفق، اجرای فرم اصلی
                if (result == DialogResult.OK)
                {
                    Application.Run(new Form1()); // فرم اصلی فقط بعد از لاگین موفق اجرا می‌شود
                }
            }
        }
    }
}
