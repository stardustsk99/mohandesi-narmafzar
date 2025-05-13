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

namespace KalaPezeshki
{
    public partial class frmListCompany: Form
    {
        public frmListCompany()
        {
            InitializeComponent();
        }
        // تعریف اتصال به دیتابیس SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=medical goods;integrated security=true");
        SqlCommand cmd = new SqlCommand(); // شی فرمان SQL برای اجرای دستورات

        // متدی برای نمایش اطلاعات کاربران در DataGridView
        void Display()
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Company"; // بازیابی همه کاربران
            adp.Fill(ds, "Company"); // پر کردن دیتاست با داده‌ها
            dgvCompany.DataSource = ds;
            dgvCompany.DataMember = "Company";

            // تنظیم عنوان ستون‌های جدول نمایش داده شده
            dgvCompany.Columns[0].HeaderText = "کد";
            dgvCompany.Columns[1].HeaderText = "نام شرکت";
            dgvCompany.Columns[2].HeaderText = "تلفن تماس";
            dgvCompany.Columns[3].HeaderText = "آدرس";
            dgvCompany.Columns[4].HeaderText = "توضیحات";
            dgvCompany.Columns[4].Width=150;
            dgvCompany.Columns[3].Width = 150;
            dgvCompany.Columns[1].Width = 150;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Company where NameC like '%'+ @S +'%'";// بازیابی همه کاربران
            adp.SelectCommand.Parameters.AddWithValue("@S",txtName.Text + "%" );
            adp.Fill(ds, "Company"); // پر کردن دیتاست با داده‌ها
            dgvCompany.DataSource = ds;
            dgvCompany.DataMember = "Company";
        }

        private void dgvCompany_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmListCompany_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvCompany.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Company where id=@N";
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
    }
}
