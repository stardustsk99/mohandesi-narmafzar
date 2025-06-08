using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Stimulsoft.Report;
namespace KalaPezeshki
{
    public partial class frmListKharid : Form
    {
        public frmListKharid()
        {
            InitializeComponent();  // مقداردهی اولیه فرم
        }

        // تعریف اتصال به دیتابیس SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // تعریف شیء فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();

        /// <summary>
        /// نمایش لیست فاکتورهای خرید در بازه تاریخی مشخص‌شده توسط کاربر
        /// </summary>
        void Display()
        {
            // مجموعه داده‌ها برای ذخیره نتایج کوئری
            DataSet ds = new DataSet();

            // آداپتور برای پر کردن DataSet از دیتابیس
            SqlDataAdapter adp = new SqlDataAdapter();

            // تنظیم دستور SELECT برای بازیابی فاکتورها در بازه تاریخی
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select distinct CodeFactor,Tarikh,NameM,JameKol from Kharid where Tarikh between '" + mskTarikh1.Text + "' AND '" + mskTarikh2.Text + "'";

            // اجرای کوئری و پر کردن DataSet
            adp.Fill(ds, "Kharid");

            // تنظیم DataSource برای DataGridView
            dgvFactor.DataSource = ds;
            dgvFactor.DataMember = "Kharid";

            // تنظیم عنوان ستون‌های جدول
            dgvFactor.Columns[0].HeaderText = "شماره فاکتور";
            dgvFactor.Columns[1].HeaderText = "تاریخ خرید";
            dgvFactor.Columns[2].HeaderText = "نام مشتری";
            dgvFactor.Columns[3].HeaderText = "مبلغ فاکتور";
        }

        /// <summary>
        /// رویداد Load فرم - تنظیم تاریخ پیش‌فرض بازه جستجو و نمایش فاکتورهای مربوطه
        /// </summary>
        private void frmListKharid_Load(object sender, EventArgs e)
        {
            // ایجاد نمونه‌ای از تقویم فارسی
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();

            // تنظیم مقدار پیش‌فرض تاریخ شروع و پایان بازه (امروز) در فیلدهای ماسک‌شده
            mskTarikh1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            mskTarikh2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");

            // نمایش لیست اولیه فاکتورها
            Display();
        }
        /// <summary>
        /// رویداد کلیک دکمه "چاپ" - تولید و نمایش گزارش فاکتورهای خرید در بازه تاریخی مشخص
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // ایجاد شیء گزارش جدید
                StiReport Report = new StiReport();

                // بارگذاری فایل قالب گزارش
                Report.Load("Report/rptListKharid.mrt");

                // کامپایل گزارش
                Report.Compile();

                // تنظیم مقادیر پارامترهای تاریخ در گزارش
                Report["Tarikh1"] = mskTarikh1.Text;
                Report["Tarikh2"] = mskTarikh2.Text;

                // نمایش گزارش با رابط کاربری Ribbon
                Report.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است:\n" + ex.Message);
            }
        }

        /// <summary>
        /// رویداد کلیک دکمه "حذف" - حذف فاکتور انتخاب‌شده از دیتابیس و بروزرسانی نمایش
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // تبدیل مقدار انتخاب‌شده (کد فاکتور) به عدد صحیح
                int x = Convert.ToInt32(dgvFactor.SelectedCells[0].Value);

                // پاک‌سازی پارامترهای قبلی
                cmd.Parameters.Clear();

                // تنظیم اتصال به دیتابیس
                cmd.Connection = con;

                // آماده‌سازی دستور DELETE
                cmd.CommandText = "Delete from Kharid where CodeFactor=@N";
                cmd.Parameters.AddWithValue("@N", x);

                // باز کردن اتصال و اجرای دستور
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // بروزرسانی نمایش فاکتورها
                Display();

                // نمایش پیام موفقیت
                MessageBox.Show("حذف انجام شد");
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        /// <summary>
        /// رویداد کلیک روی سلول‌های DataGridView - در حال حاضر بدون پیاده‌سازی
        /// </summary>
        private void dgvFactor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// رویداد رد ورودی در MaskedTextBox تاریخ 1 - بروزرسانی لیست فاکتورها
        /// </summary>
        private void mskTarikh1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Display();
        }

        /// <summary>
        /// رویداد کلیک روی GroupPanel دوم - در حال حاضر بدون پیاده‌سازی
        /// </summary>
        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// رویداد تغییر مقدار در MaskedTextBox تاریخ 1 - بروزرسانی لیست فاکتورها
        /// </summary>
        private void mskTarikh1_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        /// <summary>
        /// رویداد رد ورودی در MaskedTextBox تاریخ 2 (تابع اشتباه تایپی در نام رویداد) - بروزرسانی لیست فاکتورها
        /// </summary>
        private void mskTarikh_Textchange2(object sender, MaskInputRejectedEventArgs e)
        {
            Display();
        }

        /// <summary>
        /// رویداد تغییر مقدار در MaskedTextBox تاریخ 2 - بروزرسانی لیست فاکتورها
        /// </summary>
        private void mskTarikh2_TextChanged(object sender, EventArgs e)
        {
            Display();
        }
    }
}
