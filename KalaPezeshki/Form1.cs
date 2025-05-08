using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// فضای نام اصلی پروژه کالا پزشکی
namespace KalaPezeshki
{
    // کلاس فرم اصلی برنامه
    public partial class Form1 : Form
    {
        // سازنده فرم - مقداردهی اولیه کنترل‌ها
        public Form1()
        {
            InitializeComponent();
        }

        // رویداد بارگذاری فرم هنگام اجرا
        private void Form1_Load(object sender, EventArgs e)
        {
            // می‌توانید تنظیمات اولیه فرم را اینجا انجام دهید
        }

        // رویداد کلیک بر روی groupPanel1 (در صورت نیاز به پردازش خاص)
        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        // رویداد کلیک دکمه‌ای که فرم اطلاعات (frmInfo) را نمایش می‌دهد
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            new frmInfo().ShowDialog(); // نمایش فرم اطلاعات به‌صورت مودال
        }

        // رویداد کلیک دکمه‌ای که فرم مدیریت کاربران (frmUser) را نمایش می‌دهد
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            new frmUser().ShowDialog(); // نمایش فرم کاربران به‌صورت مودال
        }
    }
}

