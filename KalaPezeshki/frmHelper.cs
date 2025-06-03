using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalaPezeshki
{
    class frmHelper
    {

        // متد پاک‌سازی فیلدها
        public static void ClearFormFields(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();

                if (c.HasChildren)
                    ClearFormFields(c); // بازگشتی برای کنترل‌های تو در تو
            }
        }
    }
}
