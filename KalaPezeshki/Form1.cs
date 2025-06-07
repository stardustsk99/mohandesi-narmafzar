// using‌های استاندارد مورد نیاز برای برنامه‌های Windows Forms
using System;
using System.Windows.Forms;
using System.Globalization;
using static KalaPezeshki.frmHelper;
// -----------------------------------------------------------------------------
// فضای نام اصلی برنامه
// -----------------------------------------------------------------------------

namespace KalaPezeshki
{
    /// <summary>
    /// فرم اصلی برنامه برای مدیریت کالاهای پزشکی
    /// </summary>
    // -------------------------------------------------------------------------
    // تعریف کلاس فرم اصلی (Form1) به صورت partial برای امکان تفکیک در چند فایل
    // -------------------------------------------------------------------------

    public partial class Form1 : Form
    {
        /// <summary>
        /// سازنده‌ی فرم - انجام مقداردهی اولیه‌ی کنترل‌ها
        /// </summary>
        /// <summary>
        /// سازنده‌ی فرم - مقداردهی اولیه‌ی کامپوننت‌ها
        /// </summary>
        public Form1()
        {
            InitializeComponent(); // فراخوانی متد پیش‌فرض برای مقداردهی کنترل‌های فرم
        }

        /// <summary>
        /// رویداد بارگذاری فرم (Load) - انجام تنظیمات اولیه هنگام اجرای برنامه
        /// </summary>
        /// <summary>
        /// رویداد بارگذاری فرم (Load) - انجام تنظیمات اولیه هنگام اجرای برنامه
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // تنظیم تاریخ شمسی و نمایش اطلاعات کاربر
            PersianCalendar persianCalendar = new PersianCalendar();
            label1.Text = $"{persianCalendar.GetYear(DateTime.Now)}/{persianCalendar.GetMonth(DateTime.Now):00}/{persianCalendar.GetDayOfMonth(DateTime.Now):00}";

            lblUsername.Text = UserSession.Username; // نمایش نام کاربری جاری
            lblRole.Text = UserSession.Role;         // نمایش نقش کاربر جاری

            // فعال‌سازی تایمر برای به‌روزرسانی ساعت
            timerClock.Interval = 1000; // هر ۱۰۰۰ میلی‌ثانیه (۱ ثانیه)
            timerClock.Tick += TimerClock_Tick;
            timerClock.Start();

            // تبدیل تمامی اعداد موجود در فرم به ارقام فارسی
            frmHelper.ConvertNumbersToPersian(this);
        }

        /// <summary>
        /// به‌روزرسانی ساعت فرم به صورت شمسی با ارقام فارسی در هر تیک تایمر
        /// </summary>
        /// <summary>
        /// به‌روزرسانی ساعت فرم به صورت شمسی با ارقام فارسی در هر تیک تایمر
        /// </summary>
        private void TimerClock_Tick(object sender, EventArgs e)
        {
            lblClock1.Text = frmHelper.GetPersianDateTime(); // دریافت و نمایش زمان جاری به صورت شمسی با ارقام فارسی
        }

        /// <summary>
        /// بررسی سطح دسترسی قبل از نمایش فرم اطلاعات
        /// </summary>
        /// <summary>
        /// بررسی سطح دسترسی قبل از نمایش فرم اطلاعات
        /// </summary>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                // نمایش پیام خطا در صورت نداشتن سطح دسترسی لازم
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }

            // نمایش فرم اطلاعات به صورت محاوره‌ای (Modal)
            new frmInfo().ShowDialog();
        }

        /// <summary>
        /// بررسی سطح دسترسی قبل از نمایش فرم مدیریت کاربران
        /// </summary>
        /// <summary>
        /// بررسی سطح دسترسی قبل از نمایش فرم مدیریت کاربران
        /// </summary>
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                // نمایش پیام خطا در صورت نداشتن سطح دسترسی لازم
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }

            // نمایش فرم مدیریت کاربران به صورت محاوره‌ای (Modal)
            new frmUser().ShowDialog();
        }

        // ---------------------------------------------------------------------
        // سایر فرم‌ها - بدون محدودیت نقش کاربری
        // ---------------------------------------------------------------------
        private void btnGroup_Click(object sender, EventArgs e) => new frmGroup().ShowDialog();
        private void btnListGroup_Click(object sender, EventArgs e) => new frmListGroup().ShowDialog();
        private void btnCompany_Click(object sender, EventArgs e) => new frmCompany().ShowDialog();
        private void btnGoods_Click(object sender, EventArgs e) => new frmGoods().ShowDialog();
        private void btnListGoods_Click(object sender, EventArgs e) => new frmListGoods().ShowDialog();
        private void btnshortage_Click(object sender, EventArgs e) => new frmShortage().ShowDialog();
        private void buttonItem5_Click(object sender, EventArgs e) => new frmSandoogh().ShowDialog();
        private void buttonItem6_Click(object sender, EventArgs e) => new frmListSandoogh().ShowDialog();
        private void buttonItem7_Click(object sender, EventArgs e) => new frmCheckD().ShowDialog();
        private void btnListCheckD_Click(object sender, EventArgs e) => new frmListCheckD().ShowDialog();
        private void buttonItem12_Click(object sender, EventArgs e) => new frmListCheckP().ShowDialog();
        private void btnCheckP_Click(object sender, EventArgs e) => new frmCheckP().ShowDialog();
        private void btnListFrosh_Click(object sender, EventArgs e) => new frmListFroosh().ShowDialog();
        private void btnFrosh_Click(object sender, EventArgs e) => new frmFroosh().ShowDialog();
        private void btnListKharid_Click(object sender, EventArgs e) => new frmListKharid().ShowDialog();

        /// <summary>
        /// دسترسی فقط برای ادمین - نمایش فرم اطلاعات بانکی
        /// </summary>
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                // نمایش پیام خطا در صورت نداشتن سطح دسترسی لازم
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }

            // نمایش فرم اطلاعات بانکی به صورت محاوره‌ای (Modal)
            new frmBank().ShowDialog();
        }
        /// <summary>
        /// نمایش لیست بانک‌ها - بدون محدودیت نقش کاربری
        /// </summary>
        private void buttonItem4_Click(object sender, EventArgs e) => new frmListBank().ShowDialog();

        /// <summary>
        /// نمایش فرم پرسنل (فقط برای مدیران)
        /// </summary>
        /// <summary>
        /// نمایش فرم پرسنل (فقط برای مدیران)
        /// </summary>
        private void btnPersenel_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                // نمایش پیام خطا در صورت نداشتن سطح دسترسی لازم
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }

            // نمایش فرم پرسنل به صورت محاوره‌ای (Modal)
            new frmPersenel().ShowDialog();
        }

        /// <summary>
        /// انجام پشتیبان‌گیری از پایگاه‌داده
        /// </summary>
        /// <summary>
        /// انجام پشتیبان‌گیری از پایگاه‌داده
        /// </summary>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveBackUp = new SaveFileDialog())
            {
                // تنظیمات دیالوگ ذخیره‌سازی فایل پشتیبان
                saveBackUp.OverwritePrompt = true; // سوال در صورت بازنویسی فایل موجود
                saveBackUp.Filter = "SQL Backup Files (*.bak)|*.bak|All Files (*.*)|*.*"; // فیلتر نوع فایل
                saveBackUp.DefaultExt = "bak"; // پسوند پیش‌فرض
                saveBackUp.FileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss"); // نام پیش‌فرض فایل با تاریخ و ساعت
                saveBackUp.Title = "Backup SQL File"; // عنوان دیالوگ

                // در صورت تایید کاربر، عملیات پشتیبان‌گیری انجام می‌شود
                if (saveBackUp.ShowDialog() == DialogResult.OK)
                {
                    frmHelper.Backup(saveBackUp.FileName); // فراخوانی متد پشتیبان‌گیری با مسیر فایل انتخاب‌شده
                }
            }
        }

        /// <summary>
        /// بازیابی پشتیبان پایگاه‌داده
        /// </summary>
        /// <summary>
        /// بازیابی پشتیبان پایگاه‌داده
        /// </summary>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openBackup = new OpenFileDialog())
            {
                // تنظیمات دیالوگ باز کردن فایل پشتیبان
                openBackup.Filter = "SQL Backup Files (*.bak)|*.bak|All Files (*.*)|*.*"; // فیلتر نوع فایل
                openBackup.FilterIndex = 1; // انتخاب پیش‌فرض نوع فایل
                openBackup.Title = "Select SQL Backup File"; // عنوان دیالوگ

                // در صورت انتخاب فایل توسط کاربر
                if (openBackup.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // انجام عملیات بازیابی از فایل انتخاب‌شده
                        frmHelper.Restore(openBackup.FileName);
                    }
                    catch (Exception ex)
                    {
                        // نمایش پیام خطا در صورت بروز مشکل در فرآیند بازیابی
                        MessageBox.Show("خطا در بازیابی: " + ex.Message);
                    }
                }
            }
        }

        // ---------------------------------------------------------------------
        // توابع رویدادی بی‌استفاده در حال حاضر (امکان تکمیل در نسخه‌های بعدی)
        // ---------------------------------------------------------------------

        private void groupPanel1_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void ribbonBar4_ItemClick(object sender, EventArgs e) { }
        private void ribbonBar12_ItemClick(object sender, EventArgs e) { }
        private void ribbonBar10_ItemClick(object sender, EventArgs e) { }
        private void ribbonTabItem5_Click(object sender, EventArgs e) { }
        private void ribbonPanel4_Click(object sender, EventArgs e) { }
        private void ribbonTabItem1_Click(object sender, EventArgs e) { }
        private void btnUser_ItemClick(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void ribbonControl1_Click(object sender, EventArgs e) { }
        private void ribbonBar8_ItemClick(object sender, EventArgs e) { }
        private void ribbonTabItem6_Click(object sender, EventArgs e) { }

        /// <summary>
        /// نمایش فرم خرید (بدون محدودیت نقش کاربری)
        /// </summary>
        private void ribbonBar20_ItemClick(object sender, EventArgs e) => new frmKharid().ShowDialog();

    } // پایان کلاس Form1
} // پایان فضای نام KalaPezeshki
