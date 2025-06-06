    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace KalaPezeshki
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

            using (frmLogin login = new frmLogin())
            {
                DialogResult result = login.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Application.Run(new Form1());  // فرم اصلی فقط بعد از لاگین موفق اجرا می‌شود
                }

            }
        }

    }
}
