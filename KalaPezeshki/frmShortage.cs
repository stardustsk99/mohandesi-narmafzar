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
    public partial class frmShortage: Form
    {
        public frmShortage()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand(); // شی فرمان SQL برای اجرای دستورات

        void DisplayNumber()
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Goods where Number between '" + txtNumber1.Text + "' AND '" + txtNumber2.Text + "'"; // بازیابی همه کاربران
            adp.Fill(ds, "Goods"); // پر کردن دیتاست با داده‌ها
            dgvGoods.DataSource = ds;
            dgvGoods.DataMember = "Goods";

            // تنظیم عنوان ستون‌های جدول نمایش داده شده
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
            dgvGoods.Columns[0].Width = 80;
            dgvGoods.Columns[2].Width = 120;
            dgvGoods.Columns[9].Width = 150;
        }
        void DisplayZiro()
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Goods where Number = '"+0+"'"; // بازیابی همه کاربران
            adp.Fill(ds, "Goods"); // پر کردن دیتاست با داده‌ها
            dgvGoods.DataSource = ds;
            dgvGoods.DataMember = "Goods";

            // تنظیم عنوان ستون‌های جدول نمایش داده شده
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
            dgvGoods.Columns[0].Width = 80;
            dgvGoods.Columns[2].Width = 120;
            dgvGoods.Columns[9].Width = 150;
        }
        private void frmShortage_Load(object sender, EventArgs e)
        {
            DisplayZiro();
        }

        private void dgvGoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DisplayNumber();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DisplayZiro();
        }
    }
}
