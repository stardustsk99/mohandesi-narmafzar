using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stimulsoft.Report;
using System.Data.SqlClient;

namespace KalaPezeshki
{
    public partial class frmListCheckD : Form
    {
        public frmListCheckD()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from CheckD where SarResid between '" + mskSarResid1.Text + "' AND '" + mskSarResid2.Text + "'";
            adp.Fill(ds, "CheckD");
            dgvCheckD.DataSource = ds;
            dgvCheckD.DataMember = "CheckD";
            //***************************
            dgvCheckD.Columns[0].HeaderText = "سریال چک";
            dgvCheckD.Columns[1].HeaderText = "شماره حساب";
            dgvCheckD.Columns[2].HeaderText = "نام حساب";
            dgvCheckD.Columns[3].HeaderText = "نام شخص";
            dgvCheckD.Columns[4].HeaderText = "مبلغ چک";
            dgvCheckD.Columns[5].HeaderText = "تاریخ صدور";
            dgvCheckD.Columns[6].HeaderText = "سررسید";
            dgvCheckD.Columns[7].HeaderText = "وضعیت";
            dgvCheckD.Columns[8].HeaderText = "توضیحات";
            dgvCheckD.Columns[3].Width = 150;
            dgvCheckD.Columns[4].Width = 150;
        }

        private void frmListCheckD_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskSarResid1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            mskSarResid2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            Display();
        }

        private void mskSarResid1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mskSarResid1_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void mskSarResid2_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvCheckD.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from CheckD where IdS=@N";
                cmd.Parameters.AddWithValue("@N", x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("حذف انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            StiReport Report = new StiReport();
            Report.Load("Report/rptCheckD.mrt");
            Report.Compile();
            Report["SarResid1"] = mskSarResid1.Text;
            Report["SarResid2"] = mskSarResid2.Text;
            Report.ShowWithRibbonGUI();
        }

        private void btnVosol_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                int str1;
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("select Balance from Bank where AcctNum='" + Convert.ToInt32(dgvCheckD.SelectedCells[1].Value) + "'", con);
                str = Convert.ToString((int)sqlcmd.ExecuteScalar());//مبلغ حساب
                str1 = Convert.ToInt32(dgvCheckD.SelectedCells[4].Value);//مبلغ چک
                int sum = Int32.Parse(str) + str1;//مبلغ نهایی حساب
                                                  //**********************************ویرایش موجودی حساب
                string UpdateBalance = "Update Bank set Balance='" + sum + "' where AcctNum='" + Convert.ToInt32(dgvCheckD.SelectedCells[1].Value) + "'";
                SqlCommand com = new SqlCommand(UpdateBalance, con);
                com.ExecuteNonQuery();
                //**********************************ویرایش وضعیت چک
                string UpdateVaziyat = "Update CheckD set Vaziyat=N'وصول شده' where ids='" + Convert.ToInt32(dgvCheckD.SelectedCells[0].Value) + "'";
                SqlCommand cmd = new SqlCommand(UpdateVaziyat, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("وصول چک انجام شد و مبلغ به حساب واریز شد");
                con.Close();
                Display();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");

            }

        }

        private void dgvCheckD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
