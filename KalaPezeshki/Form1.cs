using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KalaPezeshki.frmHelper;
using static System.Collections.Specialized.BitVector32;

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

            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
            label1.Text = persianCalendar.GetYear(DateTime.Now).ToString() + "/" + persianCalendar.GetMonth(DateTime.Now).ToString("0#") + "/" + persianCalendar.GetDayOfMonth(DateTime.Now).ToString("0#");
            lblUsername.Text = UserSession.Username;
            lblRole.Text = UserSession.Role;
            timerClock.Interval = 1000; // هر ثانیه یکبار اجرا می‌شود
            timerClock.Tick += TimerClock_Tick;
            timerClock.Start();
            frmHelper.ConvertNumbersToPersian(this); // this یعنی فرم فعلی


        }
        private void TimerClock_Tick(object sender, EventArgs e)
        {
            lblClock1.Text = frmHelper.GetPersianDateTime(); // تاریخ و ساعت شمسی با ارقام فارسی
        }

        // رویداد کلیک بر روی groupPanel1 (در صورت نیاز به پردازش خاص)
        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        // رویداد کلیک دکمه‌ای که فرم اطلاعات (frmInfo) را نمایش می‌دهد
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }
            new frmInfo().ShowDialog(); // نمایش فرم اطلاعات به‌صورت مودال
        }

        // رویداد کلیک دکمه‌ای که فرم مدیریت کاربران (frmUser) را نمایش می‌دهد
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }
            new frmUser().ShowDialog(); // نمایش فرم کاربران به‌صورت مودال
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            new frmGroup().ShowDialog();
        }

        private void btnListGroup_Click(object sender, EventArgs e)
        {
            new frmListGroup().ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            new frmCompany().ShowDialog();
        }

        private void btnGoods_Click(object sender, EventArgs e)
        {
            new frmGoods().ShowDialog();
        }

        private void btnListGoods_Click(object sender, EventArgs e)
        {
            new frmListGoods().ShowDialog();
        }

        private void btnshortage_Click(object sender, EventArgs e)
        {
            new frmShortage().ShowDialog();
        }

        private void ribbonBar4_ItemClick(object sender, EventArgs e)
        {

        }



        private void ribbonBar12_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }
            new frmBank().ShowDialog();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            new frmListBank().ShowDialog();

        }

        private void ribbonBar10_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            new frmSandoogh().ShowDialog();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            new frmListSandoogh().ShowDialog();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            new frmCheckD().ShowDialog();
        }

        private void ribbonTabItem5_Click(object sender, EventArgs e)
        {

        }

        private void ribbonPanel4_Click(object sender, EventArgs e)
        {

        }

        private void ribbonBar20_ItemClick(object sender, EventArgs e)
        {
            new frmKharid().ShowDialog();
        }

        private void btnListKharid_Click(object sender, EventArgs e)
        {
            new frmListKharid().ShowDialog();
        }

        private void btnListCheckD_Click(object sender, EventArgs e)
        {
            new frmListCheckD().ShowDialog();
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            new frmCheckP().ShowDialog();
        }

        private void btnCheckP_Click(object sender, EventArgs e)
        {
            new frmCheckP().ShowDialog();
        }

        private void btnListFrosh_Click(object sender, EventArgs e)
        {
            new frmListFroosh().ShowDialog();
        }

        private void btnFrosh_Click(object sender, EventArgs e)
        {
            new frmFroosh().ShowDialog();
        }

        private void ribbonTabItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnUser_ItemClick(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnPersenel_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "Admin")
            {
                MessageBox.Show("شما دسترسی لازم برای این عملیات را ندارید");
                return;
            }
            new frmPersenel().ShowDialog();
        }

        private void ribbonBar8_ItemClick(object sender, EventArgs e)
        {

        }
    }
}