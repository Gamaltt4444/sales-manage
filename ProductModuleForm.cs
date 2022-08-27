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

namespace InventoryManagementSystem
{
    public partial class ProductModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
            tp.Enabled = false;
        }

        public void LoadCategory()
        {
            comboCat.Items.Clear();
            cm = new SqlCommand("SELECT catname FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboCat.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPName.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم الصنف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPQty.Text == "")
            {
                MessageBox.Show("من فضلك ادخل كمية الصنف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPPrice.Text == "")
            {
                MessageBox.Show("من فضلك ادخل السعر الكامل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double t1 = Convert.ToInt32(txtPQty.Text);
             double t2 = Convert.ToInt32(txtPPrice.Text);
              double t3 = t2 / t1;
            tp.Text = t3.ToString();

            try
            {
                

                if (MessageBox.Show(" هل انت متاكد انك تريد حفظ هذاالصنف ؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO tbProduct(pname,pqty,Q1,pprice,pdescription,pcategory,wp)VALUES(@pname, @pqty,@Q1, @pprice, @pdescription, @pcategory,@wp)", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPQty.Text));
                    cm.Parameters.AddWithValue("@q1", Convert.ToInt16(txtPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                    cm.Parameters.AddWithValue("@wp", tp.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم الحفظ بنجاح");
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        public void Clear()
        {
            txtPName.Clear();
            txtPQty.Clear();
            txtPPrice.Clear();
            txtPDes.Clear();
            comboCat.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            double t1 = Convert.ToInt32(txtPQty.Text);
            double t2 = Convert.ToInt32(txtPPrice.Text);
            double t3 = t2 / t1;
            tp.Text = t3.ToString();
            try
            {

                if (MessageBox.Show("هل انت متاكد انك تريد تعديل هذا الصنف ؟", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE tbProduct SET pname = @pname, pqty=@pqty, pprice=@pprice, pdescription=@pdescription, pcategory=@pcategory, wp =@wp WHERE pid LIKE '" + lblPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                    cm.Parameters.AddWithValue("@wp", tp.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم التعديل بنجاح");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
