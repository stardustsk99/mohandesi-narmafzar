using Stimulsoft.Svg;
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
    public partial class frmListGoods : Form
    {
        public frmListGoods()
        {
            InitializeComponent();
        }

        // تعریف اتصال به دیتابیس SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // شی فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();

        // متد Display - نمایش اطلاعات تمام کالاها در DataGridView
        void Display()
        {
            DataSet ds = new DataSet();                          // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter();           // آداپتور برای پر کردن DataSet

            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Goods";   // بازیابی تمام کالاها از جدول Goods

            adp.Fill(ds, "Goods");                               // پر کردن دیتاست با داده‌ها

            dgvGoods.DataSource = ds;
            dgvGoods.DataMember = "Goods";

            // تنظیم عنوان ستون‌های جدول نمایش داده شده
            dgvGoods.Columns[0].HeaderText = "کد";
            dgvGoods.Columns[1].HeaderText = "نام گروه";
            dgvGoods.Columns[2].HeaderText = "نام کالا";
            dgvGoods.Columns[3].HeaderText = "شرکت/کشور";
            dgvGoods.Columns[4].HeaderText = "تاریخ تولید";
            dgvGoods.Columns[5].HeaderText = "تاریخ انقضا";
            dgvGoods.Columns[6].HeaderText = "تعداد کالا";
            dgvGoods.Columns[7].HeaderText = "قیمت خرید";
            dgvGoods.Columns[8].HeaderText = "قیمت فروش";
            dgvGoods.Columns[9].HeaderText = "توضیحات";

            // تنظیم عرض برخی ستون‌ها
            dgvGoods.Columns[0].Width = 80;
            dgvGoods.Columns[2].Width = 120;
            dgvGoods.Columns[9].Width = 150;
        }

        // متد DisplayEXP - نمایش کالاهای دارای تاریخ انقضا بین دو تاریخ مشخص‌شده
        void DisplayEXP()
        {
            DataSet ds = new DataSet();                          // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter();           // آداپتور برای پر کردن DataSet

            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText =
                "SELECT * FROM Goods WHERE EXP BETWEEN '" + mskEXP1.Text + "' AND '" + mskEXP2.Text + "'";   // فیلتر بر اساس بازه تاریخ انقضا

            adp.Fill(ds, "Goods");                               // پر کردن دیتاست با داده‌ها

            dgvGoods.DataSource = ds;
            dgvGoods.DataMember = "Goods";

            // تنظیم عنوان ستون‌های جدول نمایش داده شده
            dgvGoods.Columns[0].HeaderText = "کد";
            dgvGoods.Columns[1].HeaderText = "نام گروه";
            dgvGoods.Columns[2].HeaderText = "نام کالا";
            dgvGoods.Columns[3].HeaderText = "شرکت/کشور";
            dgvGoods.Columns[4].HeaderText = "تاریخ تولید";
            dgvGoods.Columns[5].HeaderText = "تاریخ انقضا";
            dgvGoods.Columns[6].HeaderText = "تعداد کالا";
            dgvGoods.Columns[7].HeaderText = "قیمت خرید";
            dgvGoods.Columns[8].HeaderText = "قیمت فروش";
            dgvGoods.Columns[9].HeaderText = "توضیحات";

            // تنظیم عرض برخی ستون‌ها
            dgvGoods.Columns[0].Width = 80;
            dgvGoods.Columns[2].Width = 120;
            dgvGoods.Columns[9].Width = 150;
        }
        private void frmListGoods_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
            mskEXP1.Text = persianCalendar.GetYear(DateTime.Now).ToString() + persianCalendar.GetMonth(DateTime.Now).ToString("0#") + persianCalendar.GetDayOfMonth(DateTime.Now).ToString("0#");
            mskEXP2.Text = persianCalendar.GetYear(DateTime.Now).ToString() + persianCalendar.GetMonth(DateTime.Now).ToString("0#") + persianCalendar.GetDayOfMonth(DateTime.Now).ToString("0#");
            Display();
        }

        private void mskEXP1_TextChanged(object sender, EventArgs e)
        {
            DisplayEXP();
        }

        private void mskEXP2_TextChanged(object sender, EventArgs e)
        {
            DisplayEXP();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            DisplayEXP();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Display();
        }



        private void txtGroup_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvGoods.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Goods where id=@N";
                cmd.Parameters.AddWithValue("@N", x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("حذف انجام شد");
                Display();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }
        // رویداد کلیک روی سلول‌های DataGridView (در حال حاضر بدون استفاده)
        private void dgvGoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // رویداد Rejected ماسک mskEXP1 (در حال حاضر بدون استفاده)
        private void mskEXP1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        // رویداد تغییر ماسک mskEXP1 (در حال حاضر بدون استفاده)
        private void mskEXP1_MaskChanged(object sender, EventArgs e)
        {

        }

        // رویداد کلیک دکمه "چاپ" - چاپ گزارش کالاها در بازه تاریخ انقضا
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                StiReport Report = new StiReport();
                Report.Load("Report/rptEXP.mrt");      // بارگذاری گزارش مربوطه
                Report.Compile();

                // ارسال پارامترهای بازه تاریخ انقضا به گزارش
                Report["EXP1"] = mskEXP1.Text;
                Report["EXP2"] = mskEXP2.Text;

                // نمایش گزارش به صورت Ribbon GUI
                Report.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // رویداد تغییر متن txtName (در حال حاضر بدون استفاده)
        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        // رویداد تغییر متن txtName با فیلترگذاری لحظه‌ای در DataGridView
        private void txtName_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();                  // مجموعه داده‌ها برای ذخیره نتیجه
                SqlDataAdapter adp = new SqlDataAdapter();    // آداپتور برای پر کردن DataSet

                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "SELECT * FROM Goods WHERE NameGoods LIKE '%' + @S + '%'"; // جستجو براساس نام کالا
                adp.SelectCommand.Parameters.AddWithValue("@S", txtName.Text + "%");

                adp.Fill(ds, "Goods");                        // پر کردن دیتاست با داده‌ها
                dgvGoods.DataSource = ds;
                dgvGoods.DataMember = "Goods";
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }
        // رویداد تغییر متن txtGroup با فیلترگذاری لحظه‌ای در DataGridView براساس نام گروه کالا
        private void txtGroup_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();                  // مجموعه داده‌ها برای ذخیره نتیجه
                SqlDataAdapter adp = new SqlDataAdapter();    // آداپتور برای پر کردن DataSet

                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "SELECT * FROM Goods WHERE NameG LIKE '%' + @S + '%'";   // جستجو براساس نام گروه
                adp.SelectCommand.Parameters.AddWithValue("@S", txtGroup.Text + "%");

                adp.Fill(ds, "Goods");                        // پر کردن دیتاست با داده‌ها
                dgvGoods.DataSource = ds;
                dgvGoods.DataMember = "Goods";
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }
    }
}