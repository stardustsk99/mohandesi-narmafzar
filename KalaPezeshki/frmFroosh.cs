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
using Stimulsoft.Report;

namespace KalaPezeshki
{
    public partial class frmFroosh : Form
    {
        public frmFroosh()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        private void frmFroosh_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskTarikh.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void mskTarikh_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtKhadamat.Text == "" || txtTakhfif.Text == "")
            {
                MessageBox.Show("لطفا هزینه خدمات یا تخفیف را وارد کنید");
                return;
            }
            dgvFactor.Rows.Add(txtCode.Text, txtName.Text, txtNumber.Text, txtSP.Text);
            txtCode.Text = "";
            txtName.Text = "";
            txtNumber.Text = "";
            txtSP.Text = "";
            //***********************
            int JameGood = 0;
            int JameKol = 0;
            int TotalCP = 0;
            for (int i = 0; i < dgvFactor.Rows.Count; i++)
            {
                JameGood = JameGood + (Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value));
                txtJameGood.Text = JameGood.ToString();

                TotalCP = Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value);
                dgvFactor.Rows[i].Cells[4].Value = TotalCP;

                JameKol = (JameGood + Convert.ToInt32(txtKhadamat.Text)) - Convert.ToInt32(txtTakhfif.Text);
                txtJameKol.Text = JameKol.ToString();
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
                txtName.Text = dr["NameGoods"].ToString();
                txtNumber.Text = dr["Number"].ToString();
                txtSP.Text = dr["SP"].ToString();


            }
            else
            {
                txtCode.Clear();
                txtCode.Focus();
                MessageBox.Show("برای کد وارد شده اطلاعاتی وجود ندارد");
            }
            con.Close();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            int JameKol = 0;
            JameKol = (Convert.ToInt32(txtJameGood.Text) + Convert.ToInt32(txtKhadamat.Text)) - Convert.ToInt32(txtTakhfif.Text);
            txtJameKol.Text = JameKol.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int JameGood = 0;
            int JameGood2 = 0;
            int jameKol = 0;
            JameGood = Convert.ToInt32(dgvFactor.CurrentRow.Cells[4].Value);
            JameGood2 = Convert.ToInt32(txtJameGood.Text) - JameGood;
            txtJameGood.Text = JameGood2.ToString();
            jameKol = Convert.ToInt32(txtJameKol.Text) - JameGood;
            txtJameKol.Text = jameKol.ToString();
            dgvFactor.Rows.RemoveAt(dgvFactor.CurrentRow.Index);
        }

        private void btnCheckP_Click(object sender, EventArgs e)
        {
            // frmCheckD frm = new frmCheckD();
            //frm.txtTozih.Text = "  دریافت مبلغ فاکتور فروش به صورت چک به شماره فاکتور" + txtIdFactor.Text;
            //frm.txtNameM.Text = txtNameM.Text;
            //frm.txt.Balance.Text = txtJameKol.Text;
            //frm.ShowDialog();
        }
    }
}
