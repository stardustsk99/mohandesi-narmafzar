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
        // ---------------------------------------------------------------------
        // سازنده‌ی فرم
        // ---------------------------------------------------------------------
        public frmFroosh()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------------
        // تعریف اتصال به پایگاه‌داده SQL Server
        // ---------------------------------------------------------------------
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // ---------------------------------------------------------------------
        // تعریف شیء فرمان SQL برای اجرای دستورات
        // ---------------------------------------------------------------------
        SqlCommand cmd = new SqlCommand();

        // ---------------------------------------------------------------------
        // متغیرهای عمومی برای نگهداری اطلاعات فروشنده/فروشگاه
        // ---------------------------------------------------------------------
        String NameKP;
        String Tel;
        String Address;

        // ---------------------------------------------------------------------
        // رویداد بارگذاری فرم
        // ---------------------------------------------------------------------
        private void frmFroosh_Load(object sender, EventArgs e)
        {
            // تنظیم تاریخ جاری به صورت شمسی
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskTarikh.Text = p.GetYear(DateTime.Now).ToString() +
                             p.GetMonth(DateTime.Now).ToString("0#") +
                             p.GetDayOfMonth(DateTime.Now).ToString("0#");

            // دریافت اطلاعات فروشگاه از جدول Info
            SqlDataReader dr;
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Info";
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                NameKP = dr["NameK"].ToString();
                Tel = dr["Tel"].ToString();
                Address = dr["Address"].ToString();
            }
            else
            {
                // در صورت عدم یافتن اطلاعات
                MessageBox.Show("برای کد وارد شده اطلاعاتی وجود ندارد");
            }

            con.Close();
        }

        // ---------------------------------------------------------------------
        // رویداد رد ورودی نامعتبر در فیلد تاریخ (فعلاً بدون استفاده)
        // ---------------------------------------------------------------------
        private void mskTarikh_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // دکمه افزودن کالا به فاکتور
        // ---------------------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // بررسی موجودی انبار نسبت به تعداد فروش
                if (txtNumber.Value > Convert.ToInt32(lbelNumber.Text))
                {
                    MessageBox.Show("تعداد موجودی انبار کم‌تر از تعداد مورد نظر برای فروش است");
                    return;
                }

                // بررسی ورود هزینه خدمات و تخفیف
                if (txtKhadamat.Text == "" || txtTakhfif.Text == "")
                {
                    MessageBox.Show("لطفا هزینه خدمات یا تخفیف را وارد کنید");
                    return;
                }

                // افزودن ردیف جدید به جدول فاکتور
                dgvFactor.Rows.Add(txtCode.Text, txtName.Text, txtNumber.Text, txtSP.Text);

                // پاک‌سازی فیلدهای ورودی پس از افزودن
                txtCode.Text = "";
                txtName.Text = "";
                txtNumber.Text = "";
                txtSP.Text = "";

                // -----------------------------------------------------------------
                // محاسبه جمع مبلغ کالاها و جمع کل فاکتور
                // -----------------------------------------------------------------
                int JameGood = 0;  // جمع مبلغ کل کالاها
                int JameKol = 0;   // جمع کل نهایی فاکتور
                int TotalCP = 0;   // مبلغ کل هر ردیف

                for (int i = 0; i < dgvFactor.Rows.Count; i++)
                {
                    // محاسبه مبلغ کل برای هر ردیف
                    JameGood += (Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value));
                    txtJameGood.Text = JameGood.ToString();

                    // محاسبه و درج مبلغ کل ردیف در ستون TotalCP
                    TotalCP = Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value);
                    dgvFactor.Rows[i].Cells[4].Value = TotalCP;

                    // محاسبه جمع کل نهایی فاکتور
                    JameKol = (JameGood + Convert.ToInt32(txtKhadamat.Text)) - Convert.ToInt32(txtTakhfif.Text);
                    txtJameKol.Text = JameKol.ToString();
                }
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }
        // ---------------------------------------------------------------------
        // دکمه جستجوی اطلاعات کالا بر اساس شناسه
        // ---------------------------------------------------------------------
        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                // بستن اتصال در صورت باز بودن
                con.Close();
                SqlDataReader dr;

                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Goods WHERE id=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);

                // اجرای فرمان و دریافت نتایج
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // نمایش اطلاعات کالا در فیلدهای فرم
                    txtCode.Text = dr["id"].ToString();
                    txtName.Text = dr["NameGoods"].ToString();
                    txtNumber.Text = dr["Number"].ToString();
                    lbelNumber.Text = dr["Number"].ToString();
                    txtSP.Text = dr["SP"].ToString();
                }
                else
                {
                    // در صورت عدم یافتن اطلاعات برای کد وارد شده
                    txtCode.Clear();
                    txtCode.Focus();
                    MessageBox.Show("برای کد وارد شده اطلاعاتی وجود ندارد");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // ---------------------------------------------------------------------
        // دکمه محاسبه جمع کل نهایی فاکتور
        // ---------------------------------------------------------------------
        private void btnSum_Click(object sender, EventArgs e)
        {
            try
            {
                // محاسبه جمع کل = (جمع مبلغ کالاها + خدمات) - تخفیف
                int JameKol = (Convert.ToInt32(txtJameGood.Text) + Convert.ToInt32(txtKhadamat.Text)) - Convert.ToInt32(txtTakhfif.Text);
                txtJameKol.Text = JameKol.ToString();
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // ---------------------------------------------------------------------
        // دکمه حذف ردیف انتخاب‌شده از جدول فاکتور
        // ---------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // بررسی انتخاب شدن یک ردیف در جدول
                if (dgvFactor.CurrentRow == null)
                {
                    MessageBox.Show("هیچ ردیفی انتخاب نشده است.");
                    return;
                }

                // بررسی تعداد ستون‌های ردیف انتخاب‌شده
                if (dgvFactor.CurrentRow.Cells.Count <= 4)
                {
                    MessageBox.Show("ستون مورد نظر وجود ندارد.");
                    return;
                }

                // استخراج ایمن مقدار ستون شماره 4 (مبلغ ردیف)
                if (!int.TryParse(dgvFactor.CurrentRow.Cells[4].Value?.ToString(), out int JameGood))
                {
                    MessageBox.Show("مقدار ستون مورد نظر قابل تبدیل به عدد نیست.");
                    return;
                }

                // بررسی و استخراج مقدار فعلی جمع مبلغ کالاها
                if (!int.TryParse(txtJameGood.Text, out int currentJameGood))
                {
                    MessageBox.Show("مقدار جمع کالاها در txtJameGood معتبر نیست.");
                    return;
                }

                // بررسی و استخراج مقدار فعلی جمع کل فاکتور
                if (!int.TryParse(txtJameKol.Text, out int currentJameKol))
                {
                    MessageBox.Show("مقدار جمع کل در txtJameKol معتبر نیست.");
                    return;
                }

                // محاسبه جمع جدید پس از حذف ردیف
                int JameGood2 = currentJameGood - JameGood;
                int jameKol = currentJameKol - JameGood;

                // جلوگیری از منفی شدن مقادیر
                if (JameGood2 < 0) JameGood2 = 0;
                if (jameKol < 0) jameKol = 0;

                // به‌روزرسانی مقادیر جمع در فرم
                txtJameGood.Text = JameGood2.ToString();
                txtJameKol.Text = jameKol.ToString();

                // حذف ردیف انتخاب‌شده از جدول فاکتور
                dgvFactor.Rows.RemoveAt(dgvFactor.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است: " + ex.Message);
            }
        }

        // ---------------------------------------------------------------------
        // دکمه ثبت دریافت مبلغ فاکتور فروش به صورت چک
        // ---------------------------------------------------------------------
        private void btnCheckP_Click(object sender, EventArgs e)
        {
            try
            {
                // ایجاد فرم جدید چک دریافتی
                frmCheckD frm = new frmCheckD();

                // مقداردهی اولیه فیلدهای فرم چک دریافتی
                frm.txtTozih.Text = "دریافت مبلغ فاکتور فروش به صورت چک به شماره فاکتور " + txtIdFactor.Text;
                frm.txtNameM.Text = txtNameM.Text;
                frm.txtMablagh.Text = txtJameKol.Text;

                // نمایش فرم چک دریافتی به صورت دیالوگ
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است: " + ex.Message);
            }
        }
        // ---------------------------------------------------------------------
        // دکمه ذخیره اطلاعات فاکتور فروش
        // ---------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // بررسی وارد شدن کد فاکتور
                if (txtIdFactor.Text == "")
                {
                    MessageBox.Show("کد فاکتور وارد نشده است");
                    txtIdFactor.Focus();
                    return;
                }

                // بررسی تکراری نبودن کد فاکتور در جدول Froosh
                con.Close();
                SqlDataReader dr;
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT CodeFactor FROM Froosh WHERE CodeFactor=@N";
                cmd.Parameters.AddWithValue("@N", txtIdFactor.Text);

                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtIdFactor.Text = "";
                    txtIdFactor.Focus();
                    MessageBox.Show("این کد فاکتور قبلا ثبت شده است");
                    con.Close();
                    return;
                }
                con.Close();

                // -----------------------------------------------------------------
                // شروع ثبت اطلاعات کالاهای فاکتور
                // -----------------------------------------------------------------
                for (int i = 0; i < dgvFactor.Rows.Count; i++)
                {
                    // جلوگیری از پردازش ردیف خالی (آخرین ردیف)
                    if (dgvFactor.Rows[i].IsNewRow) continue;

                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Froosh " +
                                      "(CodeFactor, Tarikh, NameM, Tel, Address, id, NameGood, Number, SP, TotalSP, TotalSGood, Khadamat, Takhfif, JameKol, Tozih) " +
                                      "VALUES(@a, @b, @c, @d, @e, @f, @g, @h, @i, @j, @k, @l, @m, @n, @o)";

                    // مقداردهی پارامترها
                    cmd.Parameters.AddWithValue("@a", txtIdFactor.Text);
                    cmd.Parameters.AddWithValue("@b", mskTarikh.Text);
                    cmd.Parameters.AddWithValue("@c", txtNameM.Text);
                    cmd.Parameters.AddWithValue("@d", txtTel.Text);
                    cmd.Parameters.AddWithValue("@e", txtAddress.Text);

                    cmd.Parameters.AddWithValue("@f", Convert.ToInt32(dgvFactor.Rows[i].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@g", dgvFactor.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@h", Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value));
                    cmd.Parameters.AddWithValue("@i", Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value));
                    cmd.Parameters.AddWithValue("@j", Convert.ToInt32(dgvFactor.Rows[i].Cells[4].Value));

                    cmd.Parameters.AddWithValue("@k", txtJameGood.Text);
                    cmd.Parameters.AddWithValue("@l", txtKhadamat.Text);
                    cmd.Parameters.AddWithValue("@m", txtTakhfif.Text);
                    cmd.Parameters.AddWithValue("@n", txtJameKol.Text);
                    cmd.Parameters.AddWithValue("@o", txtTozih.Text);

                    // اجرای ثبت اطلاعات در جدول Froosh
                    con.Open();
                    cmd.ExecuteNonQuery();

                    // -----------------------------------------------------------------
                    // کاهش موجودی کالا در جدول Goods
                    // -----------------------------------------------------------------
                    int goodId = Convert.ToInt32(dgvFactor.Rows[i].Cells[0].Value);
                    SqlCommand sqlcmd = new SqlCommand("SELECT Number FROM Goods WHERE id='" + goodId + "'", con);
                    int mojoodi = Convert.ToInt32(sqlcmd.ExecuteScalar());

                    int tedadForosh = Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value);
                    int finalCount = mojoodi - tedadForosh;

                    // به‌روزرسانی موجودی کالا
                    SqlCommand com = new SqlCommand("UPDATE Goods SET Number='" + finalCount + "' WHERE id='" + goodId + "'", con);
                    com.ExecuteNonQuery();

                    con.Close();
                }

                // نمایش پیام موفقیت در پایان عملیات
                MessageBox.Show("ثبت با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("خطا در ثبت اطلاعات: " + ex.Message);
            }
        }

        // ---------------------------------------------------------------------
        // دکمه پرداخت نقدی مبلغ فاکتور به حساب بانکی
        // ---------------------------------------------------------------------
        private void btnNagd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Close();

                // بررسی ورود شماره حساب
                if (txtShH.Text == "")
                {
                    MessageBox.Show("لطفا شماره حساب را وارد کنید");
                    return;
                }

                string str;
                int str1;

                // دریافت موجودی فعلی حساب
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SELECT Balance FROM Bank WHERE AcctNum='" + txtShH.Text + "'", con);
                str = Convert.ToString((int)sqlcmd.ExecuteScalar()); // مبلغ موجودی حساب

                // مبلغ فاکتور
                str1 = Convert.ToInt32(txtJameKol.Text);

                // محاسبه موجودی جدید
                int sum = Int32.Parse(str) + str1;

                // به‌روزرسانی موجودی حساب
                string UpdateBalance = "UPDATE Bank SET Balance='" + sum + "' WHERE AcctNum='" + txtShH.Text + "'";
                SqlCommand com = new SqlCommand(UpdateBalance, con);
                com.ExecuteNonQuery();

                MessageBox.Show("مبلغ به حساب واریز شد");
                con.Close();
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // ---------------------------------------------------------------------
        // دکمه نمایش لیست فاکتورهای فروش
        // ---------------------------------------------------------------------
        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListFroosh().ShowDialog();
        }

        // ---------------------------------------------------------------------
        // دکمه چاپ فاکتور فروش
        // ---------------------------------------------------------------------
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // بررسی وارد شدن شماره فاکتور
                if (txtIdFactor.Text == "")
                {
                    MessageBox.Show("لطفا شماره فاکتور را وارد کنید");
                    return;
                }

                // بارگذاری و نمایش گزارش چاپ
                StiReport Report = new StiReport();
                Report.Load("Report/rptFroosh.mrt");
                Report.Compile();
                Report["CodeFactor"] = Convert.ToInt32(txtIdFactor.Text);
                Report.ShowWithRibbonGUI();
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // ---------------------------------------------------------------------
        // رویدادهای فعلاً استفاده‌نشده (در صورت نیاز می‌توان حذف یا تکمیل کرد)
        // ---------------------------------------------------------------------
        private void label10_Click(object sender, EventArgs e) { }

        private void txtShH_TextChanged(object sender, EventArgs e) { }

        private void groupPanel5_Click(object sender, EventArgs e) { }

        private void groupPanel2_Click(object sender, EventArgs e) { }

        private void line3_Click(object sender, EventArgs e) { }

        // ---------------------------------------------------------------------
        // دکمه پاکسازی تمام فیلدهای فرم
        // ---------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        private void dgvFactor_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void txtTel_TextChanged(object sender, EventArgs e) { }
        private void txtAddress_TextChanged(object sender, EventArgs e) { }

    } // پایان کلاس frmFroosh
} // پایان فضای نام KalaPezeshki
