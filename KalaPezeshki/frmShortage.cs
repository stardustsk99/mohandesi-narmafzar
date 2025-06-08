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
namespace KalaPezeshki
{
    public partial class frmShortage : Form
    {
        public frmShortage()
        {
            InitializeComponent();  // مقداردهی اولیه فرم
        }

        // تعریف اتصال به دیتابیس SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // تعریف شیء فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();

        /// <summary>
        /// نمایش کالاهایی که تعداد آن‌ها در بازه مشخص (بین txtNumber1 و txtNumber2) قرار دارد
        /// </summary>
        void DisplayNumber()
        {
            // مجموعه داده‌ها برای ذخیره نتایج کوئری
            DataSet ds = new DataSet();

            // آداپتور برای پر کردن DataSet از دیتابیس
            SqlDataAdapter adp = new SqlDataAdapter();

            // تنظیم دستور SELECT
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Goods where Number between '" + txtNumber1.Text + "' AND '" + txtNumber2.Text + "'";

            // اجرای کوئری و پر کردن DataSet
            adp.Fill(ds, "Goods");

            // تنظیم DataSource برای DataGridView
            dgvGoods.DataSource = ds;
            dgvGoods.DataMember = "Goods";

            // تنظیم عنوان ستون‌های جدول
            dgvGoods.Columns[0].HeaderText = "کد";
            dgvGoods.Columns[1].HeaderText = "نام گروه ";
            dgvGoods.Columns[2].HeaderText = "نام کالا ";
            dgvGoods.Columns[3].HeaderText = "شرکت/کشور ";
            dgvGoods.Columns[4].HeaderText = "تاریخ تولید ";
            dgvGoods.Columns[5].HeaderText = "تاریخ انقضا ";
            dgvGoods.Columns[6].HeaderText = "تعداد کالا ";
            dgvGoods.Columns[7].HeaderText = "قیمت خرید ";
            dgvGoods.Columns[8].HeaderText = "قیمت فروش";
            dgvGoods.Columns[9].HeaderText = "توضیحات ";

            // تنظیم عرض برخی ستون‌ها برای خوانایی بهتر
            dgvGoods.Columns[0].Width = 80;
            dgvGoods.Columns[2].Width = 120;
            dgvGoods.Columns[9].Width = 150;
        }

        /// <summary>
        /// نمایش کالاهایی که تعداد آن‌ها صفر (0) است
        /// </summary>
        void DisplayZiro()
        {
            // مجموعه داده‌ها برای ذخیره نتایج کوئری
            DataSet ds = new DataSet();

            // آداپتور برای پر کردن DataSet از دیتابیس
            SqlDataAdapter adp = new SqlDataAdapter();

            // تنظیم دستور SELECT برای کالاهای دارای تعداد صفر
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Goods where Number = '" + 0 + "'";

            // اجرای کوئری و پر کردن DataSet
            adp.Fill(ds, "Goods");

            // تنظیم DataSource برای DataGridView
            dgvGoods.DataSource = ds;
            dgvGoods.DataMember = "Goods";

            // تنظیم عنوان ستون‌های جدول
            dgvGoods.Columns[0].HeaderText = "کد";
            dgvGoods.Columns[1].HeaderText = "نام گروه ";
            dgvGoods.Columns[2].HeaderText = "نام کالا ";
            dgvGoods.Columns[3].HeaderText = "شرکت/کشور ";
            dgvGoods.Columns[4].HeaderText = "تاریخ تولید ";
            dgvGoods.Columns[5].HeaderText = "تاریخ انقضا ";
            dgvGoods.Columns[6].HeaderText = "تعداد کالا ";
            dgvGoods.Columns[7].HeaderText = "قیمت خرید ";
            dgvGoods.Columns[8].HeaderText = "قیمت فروش";
            dgvGoods.Columns[9].HeaderText = "توضیحات ";

            // تنظیم عرض برخی ستون‌ها برای خوانایی بهتر
            dgvGoods.Columns[0].Width = 80;
            dgvGoods.Columns[2].Width = 120;
            dgvGoods.Columns[9].Width = 150;
        }

        /// <summary>
        /// رویداد Load فرم - به محض بارگذاری فرم، کالاهای با تعداد صفر نمایش داده می‌شوند
        /// </summary>
        private void frmShortage_Load(object sender, EventArgs e)
        {
            DisplayZiro();
        }

        /// <summary>
        /// رویداد کلیک روی سلول‌های DataGridView - در حال حاضر بدون پیاده‌سازی
        /// </summary>
        private void dgvGoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// رویداد کلیک روی گروه پنل (GroupPanel) - در حال حاضر بدون پیاده‌سازی
        /// </summary>
        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// رویداد کلیک دکمه "نمایش بازه تعداد" (buttonX2) - نمایش کالاها در بازه تعداد مشخص‌شده
        /// </summary>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            DisplayNumber();
        }

        /// <summary>
        /// رویداد کلیک دکمه "نمایش کالاهای با تعداد صفر" (buttonX1) - نمایش کالاهای با تعداد صفر
        /// </summary>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            DisplayZiro();
        }
    }
}
