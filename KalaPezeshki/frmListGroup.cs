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
    public partial class frmListGroup: Form
    {
        public frmListGroup()
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
            adp.SelectCommand.CommandText = "Select * from Grooh"; // بازیابی همه کاربران
            adp.Fill(ds, "Grooh"); // پر کردن دیتاست با داده‌ها
            dgvGroup.DataSource = ds;
            dgvGroup.DataMember = "Grooh";

            // تنظیم عنوان ستون‌های جدول نمایش داده شده
            dgvGroup.Columns[0].HeaderText = "کد";
            dgvGroup.Columns[1].HeaderText = "نام گروه ";
            dgvGroup.Columns[1].Width = 300;
        }

        private void frrmListGroup_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvGroup.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Grooh where id=@N";
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptGroup.mrt");
            Report.Compile();
            Report.ShowWithRibbonGUI(); 
        }

        private void dgvGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
