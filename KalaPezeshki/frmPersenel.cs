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
    public partial class frmPersenel: Form
    {
        public frmPersenel()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // تعریف شیء فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();
        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into Persenel(Name,Tel,Rool,Salary,Date,Tozih)values (@a,@b,@c,@d,@e,@f)";
                cmd.Parameters.AddWithValue("@a", txtName.Text);
                cmd.Parameters.AddWithValue("@b", txtTel.Text);
                cmd.Parameters.AddWithValue("@c", txtRool.Text);
                cmd.Parameters.AddWithValue("@d", txtSalary.Text);
                cmd.Parameters.AddWithValue("@e", mskDate.Text);
                cmd.Parameters.AddWithValue("@f", txtTozih.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("پرسنل اضافه شد");
                //-------------------------------
                txtCode.Clear();
                txtName.Clear();
                txtTel.Clear();
                txtRool.Clear();
                txtSalary.Text = "";
                txtTozih.Text = "";

            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void frmPersenel_Load(object sender, EventArgs e)
        {

            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
            mskDate.Text = persianCalendar.GetYear(DateTime.Now).ToString() + persianCalendar.GetMonth(DateTime.Now).ToString("0#") + persianCalendar.GetDayOfMonth(DateTime.Now).ToString("0#");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Persenel where id=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("پرسنل حذف شد");
                //-------------------------------
                txtCode.Clear();
                txtName.Clear();
                txtTel.Clear();
                txtRool.Clear();
                txtSalary.Text = "";
                txtTozih.Text = "";

            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Persenel SET Name=@a, Tel=@b, Rool=@c, Salary=@d, Date=@e, Tozih=@f where id="+txtCode.Text;
                cmd.Parameters.AddWithValue("@a", txtName.Text);
                cmd.Parameters.AddWithValue("@b", txtTel.Text);
                cmd.Parameters.AddWithValue("@c", txtRool.Text);
                cmd.Parameters.AddWithValue("@d", txtSalary.Text);
                cmd.Parameters.AddWithValue("@e", mskDate.Text);
                cmd.Parameters.AddWithValue("@f", txtTozih.Text);
                cmd.Parameters.AddWithValue("@id", txtCode.Text);  

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("پرسنل ویرایش شد");

                //-------------------------------
                txtCode.Clear();
                txtName.Clear();
                txtTel.Clear();
                txtRool.Clear();
                txtSalary.Clear();
                txtTozih.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }

        }

        private void btnS_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "select * from Persenel where id=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtCode.Text = dr["id"].ToString();
                txtName.Text = dr["Name"].ToString();
                txtTel.Text = dr["Tel"].ToString();
                txtRool.Text = dr["Rool"].ToString();
                txtSalary.Text = dr["Salary"].ToString();
                mskDate.Text = dr["Date"].ToString();
                txtTozih.Text = dr["Tozih"].ToString();
            }
            else
            {
                txtCode.Clear();
                txtCode.Focus();
                MessageBox.Show("برای کد وارد شده اطلاعاتی وجود ندارد");
            }
            con.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListPersenel().ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
