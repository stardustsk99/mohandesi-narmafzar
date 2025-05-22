using Stimulsoft.Report;
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
    public partial class frmListKharid : Form
    {
        public frmListKharid()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select distinct CodeFactor,Tarikh,NameM,JameKol from Kharid where Tarikh between '" + mskTarikh1.Text + "' AND '" + mskTarikh2.Text + "'";
            adp.Fill(ds, "Kharid");
            dgvFactor.DataSource = ds;
            dgvFactor.DataMember = "Kharid";
            //***************************

            dgvFactor.Columns[0].HeaderText = "شماره فاکتور";
            dgvFactor.Columns[1].HeaderText = "تاریخ خرید";
            dgvFactor.Columns[2].HeaderText = "نام مشتری";
            dgvFactor.Columns[3].HeaderText = "مبلغ فاکتور";

        }


        private void frmListKharid_Load(object sender, EventArgs e)
        {

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskTarikh1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            mskTarikh2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
         
                try
                {
                    int x = Convert.ToInt32(dgvFactor.SelectedCells[0].Value);
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from Kharid where CodeFactor=@N";
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
            Report.Load("Report/rptListKharid.mrt");
            Report.Compile();
            Report["Tarikh1"] = mskTarikh1.Text;
            Report["Tarikh2"] = mskTarikh2.Text;
            Report.ShowWithRibbonGUI();
        }

        private void dataGridViewX2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
