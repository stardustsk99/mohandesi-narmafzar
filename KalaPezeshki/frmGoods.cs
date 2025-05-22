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
    public partial class frmGoods: Form
    {
        public frmGoods()
        {
            InitializeComponent();
        }
        // تعریف اتصال به پایگاه داده SQL Server
        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=KalaPezeshki;integrated security=true");

        // تعریف شیء فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        private void frmGoods_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select NameG from Grooh ",con);
            da.Fill(dt);
            bs.DataSource = dt;
            cmbGroup.DataSource = bs;
            cmbGroup.DisplayMember = "NameG";
            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
            mskFMG.Text = persianCalendar.GetYear(DateTime.Now).ToString() +  persianCalendar.GetMonth(DateTime.Now).ToString("0#")  + persianCalendar.GetDayOfMonth(DateTime.Now).ToString("0#");
            mskEXP.Text = persianCalendar.GetYear(DateTime.Now).ToString() + persianCalendar.GetMonth(DateTime.Now).ToString("0#") + persianCalendar.GetDayOfMonth(DateTime.Now).ToString("0#");


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into Goods(NameG,NameGoods,Company,FMG,EXP,Number,CP,SP,Tozih)values (@a,@b,@c,@d,@e,@f,@g,@h,@i)";
                cmd.Parameters.AddWithValue("@a", cmbGroup.Text);
                cmd.Parameters.AddWithValue("@b", txtName.Text);
                cmd.Parameters.AddWithValue("@c", txtCompany.Text);
                cmd.Parameters.AddWithValue("@d", mskFMG.Text);
                cmd.Parameters.AddWithValue("@e", mskEXP.Text);
                cmd.Parameters.AddWithValue("@f", txtNumber.Text);
                cmd.Parameters.AddWithValue("@g", txtCP.Text);
                cmd.Parameters.AddWithValue("@h", txtSP.Text);
                cmd.Parameters.AddWithValue("@i", txtTozih.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("کالا اضافه شد");
                //-------------------------------
                txtCode.Clear();
                txtName.Clear();
                txtCompany.Clear();
                txtNumber.Text ="";
                txtCP.Clear();
                txtSP.Clear();
                txtTozih.Clear();

            }
            catch(Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Goods where id=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("کالا حذف شد");
                //-------------------------------
                txtCode.Clear();
                txtName.Clear();
                txtCompany.Clear();
                txtNumber.Text = "";
                txtCP.Clear();
                txtSP.Clear();
                txtTozih.Clear();
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
                cmd.CommandText = "UPDATE Goods SET NameG = @a, NameGoods = @b, Company = @c, FMG = @d, EXP = @e, Number = @f, CP = @g, SP = @h, Tozih = @i WHERE id = @j";
                cmd.Parameters.AddWithValue("@a", cmbGroup.Text);
                cmd.Parameters.AddWithValue("@b", txtName.Text);
                cmd.Parameters.AddWithValue("@c", txtCompany.Text);
                cmd.Parameters.AddWithValue("@d", mskFMG.Text);
                cmd.Parameters.AddWithValue("@e", mskEXP.Text);
                cmd.Parameters.AddWithValue("@f", txtNumber.Text);
                cmd.Parameters.AddWithValue("@g", txtCP.Text);
                cmd.Parameters.AddWithValue("@h", txtSP.Text);
                cmd.Parameters.AddWithValue("@i", txtTozih.Text);
                cmd.Parameters.AddWithValue("@j", txtCode.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("ویرایش انجام شد");

                // پاکسازی فیلدها
                txtCode.Clear();
                txtName.Clear();
                txtCompany.Clear();
                txtNumber.Text="";
                txtCP.Clear();
                txtSP.Clear();
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
            cmd.CommandText = "select * from Goods where id=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtCode.Text = dr["id"].ToString();
                cmbGroup.Text = dr["NameG"].ToString();
                txtName.Text = dr["NameGoods"].ToString();
                txtCompany.Text = dr["Company"].ToString();
                mskFMG.Text = dr["FMG"].ToString();
                mskEXP.Text = dr["EXP"].ToString();
                txtNumber.Text = dr["Number"].ToString();
                txtCP.Text = dr["CP"].ToString();
                txtSP.Text = dr["SP"].ToString();
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
            new frmListGoods().ShowDialog();
        }
    }
}
