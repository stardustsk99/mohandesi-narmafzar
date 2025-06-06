// using‌های استاندارد مورد نیاز برای برنامه‌های Windows Forms
using System;
using System.Windows.Forms;
using System.Globalization;
using static KalaPezeshki.frmHelper;

// فضای نام اصلی برنامه
namespace KalaPezeshki
{
    /// <summary>
    /// فرم اصلی برنامه مدیریت کالاهای پزشکی
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// سازنده فرم - مقداردهی اولیه کنترل‌ها
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// رویداد بارگذاری فرم (Load) - انجام تنظیمات اولیه هنگام اجرای برنامه
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // تنظیم تاریخ شمسی و نمایش اطلاعات کاربر
            PersianCalendar persianCalendar = new PersianCalendar();
            label1.Text = $"{persianCalendar.GetYear(DateTime.Now)}/{persianCalendar.GetMonth(DateTime.Now):00}/{persianCalendar.GetDayOfMonth(DateTime.Now):00}";
            lblUsername.Text = UserSession.Username;
            lblRole.Text = UserSession.Role;

            // فعال‌سازی تایمر برای به‌روزرسانی ساعت
            timerClock.Interval = 1000; // هر ۱۰۰۰ میلی‌ثانیه (۱ ثانیه)
            timerClock.Tick += TimerClock_Tick;
            timerClock.Start();

            // تبدیل تمامی اعداد در فرم به فارسی
            frmHelper.ConvertNumbersToPersian(this);
        }

        /// <summary>
        /// به‌روزرسانی ساعت فرم به صورت شمسی با ارقام فارسی در هر تیک تایمر
        /// </summary>
        private void TimerClock_Tick(object sender, EventArgs e)
        {
            lblClock1.Text = frmHelper.GetPersianDateTime();
        }

        /// <summary>
        /// بررسی سطح دسترسی قبل از نمایش فرم اطلاعات
        /// </summary>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }

            new frmInfo().ShowDialog();
        }

        /// <summary>
        /// بررسی سطح دسترسی قبل از نمایش فرم مدیریت کاربران
        /// </summary>
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }

            new frmUser().ShowDialog();
        }

        // سایر فرم‌ها - بدون محدودیت نقش کاربری
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
        private void buttonItem12_Click(object sender, EventArgs e) => new frmCheckP().ShowDialog();
        private void btnCheckP_Click(object sender, EventArgs e) => new frmCheckP().ShowDialog();
        private void btnListFrosh_Click(object sender, EventArgs e) => new frmListFroosh().ShowDialog();
        private void btnFrosh_Click(object sender, EventArgs e) => new frmFroosh().ShowDialog();
        private void btnListKharid_Click(object sender, EventArgs e) => new frmListKharid().ShowDialog();

        /// <summary>
        /// دسترسی فقط برای ادمین - فرم اطلاعات بانکی
        /// </summary>
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }

            new frmBank().ShowDialog();
        }

        private void buttonItem4_Click(object sender, EventArgs e) => new frmListBank().ShowDialog();

        /// <summary>
        /// نمایش فرم پرسنل (فقط برای مدیران)
        /// </summary>
        private void btnPersenel_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }

            new frmPersenel().ShowDialog();
        }

        /// <summary>
        /// انجام پشتیبان‌گیری از پایگاه‌داده
        /// </summary>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveBackUp = new SaveFileDialog())
            {
                saveBackUp.OverwritePrompt = true;
                saveBackUp.Filter = "SQL Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
                saveBackUp.DefaultExt = "bak";
                saveBackUp.FileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                saveBackUp.Title = "Backup SQL File";

                if (saveBackUp.ShowDialog() == DialogResult.OK)
                {
                    frmHelper.Backup(saveBackUp.FileName);
                }
            }
        }

        /// <summary>
        /// بازیابی پشتیبان پایگاه‌داده
        /// </summary>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openBackup = new OpenFileDialog())
            {
                openBackup.Filter = "SQL Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
                openBackup.FilterIndex = 1;
                openBackup.Title = "Select SQL Backup File";

                if (openBackup.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        frmHelper.Restore(openBackup.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("خطا در بازیابی: " + ex.Message);
                    }
                }
            }
        }

        // توابع رویدادی بی‌استفاده فعلاً
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
        private void ribbonBar20_ItemClick(object sender, EventArgs e) => new frmKharid().ShowDialog();
    }
}
