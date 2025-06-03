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

namespace KalaPezeshki
{
    public partial class frmCheckP : Form
    {
        // متد پاک‌سازی فیلدها
        private void ClearFormFields(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();

                // اگر کنترل داخل کنترل دیگری باشه (مثلاً GroupBox یا Panel)
                if (c.HasChildren)
                    ClearFormFields(c);
            }
        }
        public frmCheckP()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        private void frmCheckP_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskSarResid.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            mskTarikh.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into CheckP(ids,AcctNum,NameAcct,NameM,Balance,Tarikh,SarResid,Vaziyat,Tozih)values(@a,@b,@c,@d,@e,@f,@g,@h,@i)";
                cmd.Parameters.AddWithValue("@a", txtCode.Text);
                cmd.Parameters.AddWithValue("@b", txtShH.Text);
                cmd.Parameters.AddWithValue("@c", txtNameH.Text);
                cmd.Parameters.AddWithValue("@d", txtNameM.Text);
                cmd.Parameters.AddWithValue("@e", txtMablagh.Text);
                cmd.Parameters.AddWithValue("@f", mskTarikh.Text);
                cmd.Parameters.AddWithValue("@g", mskSarResid.Text);
                cmd.Parameters.AddWithValue("@h", cmbVaziyat.Text);
                cmd.Parameters.AddWithValue("@i", txtTozih.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("چک پرداختی ثبت شد");
                //*****************
                txtCode.Text = "";
                txtShH.Text = "";
                txtNameH.Text = "";
                txtNameM.Text = "";
                txtMablagh.Text = "";
                txtTozih.Text = "";
            }
            catch (Exception)
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
                cmd.CommandText = "Delete from CheckP where ids=" + txtCode.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("چک پرداختی حذف شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update CheckP set ids='" + txtCode.Text + "',AcctNum='" + txtShH.Text + "',NameAcct='" + txtNameH.Text + "',NameM='" + txtNameM.Text + "',Balance='" + txtMablagh.Text + "',Tarikh='" + mskTarikh.Text + "',SarResid='" + mskSarResid.Text + "',Vaziyat='" + cmbVaziyat.Text + "',Tozih='" + txtTozih.Text + "' where ids=" + txtCode.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("چک پرداختی ویرایش شد");
                //*****************
                txtCode.Text = "";
                txtShH.Text = "";
                txtNameH.Text = "";
                txtNameM.Text = "";
                txtMablagh.Text = "";
                txtTozih.Text = "";
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
            cmd.CommandText = "select * from CheckP where IdS=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtCode.Text = dr["idS"].ToString();
                txtShH.Text = dr["NameAcct"].ToString();
                txtNameH.Text = dr["NameAcct"].ToString();
                txtNameM.Text = dr["NameM"].ToString();
                txtMablagh.Text = dr["Balance"].ToString();
                mskTarikh.Text = dr["Tarikh"].ToString();
                mskSarResid.Text = dr["SarResid"].ToString();
                cmbVaziyat.Text = dr["Vaziyat"].ToString();
                txtTozih.Text = dr["Tozih"].ToString();
            }
            else
            {
                txtCode.Text = "";
                txtCode.Focus();
                MessageBox.Show("برای کد وارد شده اطلاعاتی یافت نشد");
            }
            con.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            SqlDataReader dr;
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "select * from Bank where AcctNum=@N";
            cmd.Parameters.AddWithValue("@N", txtShH.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtNameH.Text = dr["NameAcct"].ToString();
                txtShH.Text = dr["AcctNum"].ToString();
            }
            else
            {
                txtShH.Text = "";
                txtShH.Focus();
                MessageBox.Show("برای کد وارد شده اطلاعاتی یافت نشد");
            }
            con.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            new frmCheckP().ShowDialog();
        }

        private void txtNameH_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormFields(this);
        }

        private void cmbVaziyat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
