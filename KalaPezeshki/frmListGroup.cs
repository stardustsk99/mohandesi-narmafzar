using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stimulsoft.Report;
namespace KalaPezeshki
{
    // ---------------------------------------------------------------------
    // فرم نمایش لیست گروه‌ها در سیستم کالاهای پزشکی
    // ---------------------------------------------------------------------
    public partial class frmListGroup : Form
    {
        // ---------------------------------------------------------------------
        // سازنده فرم - مقداردهی اولیه کنترل‌ها
        // ---------------------------------------------------------------------
        public frmListGroup()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------------
        // تعریف اتصال به دیتابیس SQL Server
        // ---------------------------------------------------------------------
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // ---------------------------------------------------------------------
        // تعریف شیء فرمان SQL برای اجرای دستورات
        // ---------------------------------------------------------------------
        SqlCommand cmd = new SqlCommand();

        // ---------------------------------------------------------------------
        // متد Display - نمایش اطلاعات گروه‌ها در DataGridView
        // ---------------------------------------------------------------------
        void Display()
        {
            // مجموعه داده‌ها برای ذخیره نتیجه
            DataSet ds = new DataSet();

            // آداپتور برای پر کردن DataSet
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;

            // بازیابی همه گروه‌ها از جدول Grooh
            adp.SelectCommand.CommandText = "SELECT * FROM Grooh";
            adp.Fill(ds, "Grooh");

            // نمایش داده‌ها در DataGridView
            dgvGroup.DataSource = ds;
            dgvGroup.DataMember = "Grooh";

            // تنظیم عنوان ستون‌های جدول
            dgvGroup.Columns[0].HeaderText = "کد";
            dgvGroup.Columns[1].HeaderText = "نام گروه";
            dgvGroup.Columns[1].Width = 300;
        }

        // ---------------------------------------------------------------------
        // رویداد بارگذاری فرم - نمایش لیست گروه‌ها هنگام بارگذاری فرم
        // ---------------------------------------------------------------------
        private void frrmListGroup_Load(object sender, EventArgs e)
        {
            Display();
        }

        // ---------------------------------------------------------------------
        // رویداد کلیک دکمه "حذف" - حذف گروه انتخاب‌شده
        // ---------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // دریافت شناسه گروه انتخاب‌شده از DataGridView
                int x = Convert.ToInt32(dgvGroup.SelectedCells[0].Value);

                // آماده‌سازی فرمان حذف
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Grooh WHERE id=@N";
                cmd.Parameters.AddWithValue("@N", x);

                // اجرای حذف
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // بروزرسانی نمایش داده‌ها و پیام موفقیت
                MessageBox.Show("حذف انجام شد");
                Display();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // ---------------------------------------------------------------------
        // رویداد کلیک دکمه "چاپ" - چاپ لیست گروه‌ها
        // ---------------------------------------------------------------------
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // بارگذاری و نمایش گزارش چاپ با Stimulsoft
                StiReport Report = new StiReport();
                Report.Load("Report/rptGroup.mrt");
                Report.Compile();
                Report.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }
        // ---------------------------------------------------------------------
        // رویداد کلیک روی سلول در DataGridView (فعلاً استفاده‌نشده)
        // ---------------------------------------------------------------------
        private void dgvGroup_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // ---------------------------------------------------------------------
        // رویداد کلیک روی groupPanel4 (فعلاً استفاده‌نشده)
        // ---------------------------------------------------------------------
        private void groupPanel4_Click(object sender, EventArgs e) { }
    }
}