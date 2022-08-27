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
    public partial class m : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public m()
        {
            InitializeComponent();
            tp.Enabled = false;
            LoadCustomer();
            button1.Enabled = false;
        }
        public void LoadCustomer()
        {
            double total = 0;
            double total1 = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM md", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                // total += Convert.ToInt32(dr[2].ToString());
                total += Convert.ToInt32(dr[4].ToString());
                total1 += Convert.ToInt32(dr[3].ToString());
            }
            dr.Close();
            con.Close();
            label23.Text = total.ToString();
            label9.Text = total1.ToString();
        }
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mn.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المندوب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل حساب المندوب كامل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل دفعة من حساب المندوب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double t1 = Convert.ToInt32(tt.Text);
            double t2 = Convert.ToInt32(dt.Text);
            double t3 = t1- t2;
            tp.Text = t3.ToString();
            try
            {
               
                if (MessageBox.Show("هل انت متاكد من حفظ البيانات ؟  ", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dt.Text == "0") {
                        cm = new SqlCommand("INSERT INTO md (mname,tprice,dprice,bprice)VALUES(@mname,@tprice,@dprice,@bprice)", con);
                        //cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                        cm.Parameters.AddWithValue("@mname", mn.Text);
                        cm.Parameters.AddWithValue("@tprice", tt.Text);
                        cm.Parameters.AddWithValue("@dprice", dt.Text);
                        cm.Parameters.AddWithValue("@bprice", tp.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم حفظ اليبانات بنجاح ");
                        Clear();
                    }
                    else
                    {
                        cm = new SqlCommand("INSERT INTO md (date,mname,tprice,dprice,bprice)VALUES(@date,@mname,@tprice,@dprice,@bprice)", con);
                        cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                        cm.Parameters.AddWithValue("@mname", mn.Text);
                        cm.Parameters.AddWithValue("@tprice", LL.Text);
                        cm.Parameters.AddWithValue("@dprice", dt.Text);
                        cm.Parameters.AddWithValue("@bprice", tp.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم حفظ اليبانات بنجاح ");
                        Clear();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            LoadCustomer();
        }
        public void Clear()
        {
            //txtCName.Clear();
            mn.Clear();
            tp.Clear();
            tt.Clear();
            dt.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            double t1 = Convert.ToInt32(tt.Text);
            double t2 = Convert.ToInt32(dt.Text);
            double t3 = t1 - t2;
            tp.Text = t3.ToString();
            try
            {
               
                
                if (MessageBox.Show("هل انت متاكد من تعديل البيانات  ", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("update md set date =@date,mname=@mname,tprice=@tprice,dprice=@dprice,bprice=@bprice where mid like '" + lblCId.Text + "'  ", con);
                    
                    cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cm.Parameters.AddWithValue("@mname", mn.Text);
                    cm.Parameters.AddWithValue("@tprice", tt.Text);
                    cm.Parameters.AddWithValue("@dprice", dt.Text);
                    cm.Parameters.AddWithValue("@bprice", tp.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم تعديل اليبانات بنجاح ");
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            LoadCustomer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            button1.Enabled = false;
            LoadCustomer();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                // nasreat customerModule = new nasreat();
                //customerModule.lblCId.text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                mn.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                tt.Text = dgvCustomer.Rows[e.RowIndex].Cells[6].Value.ToString();
                dt.Text = dgvCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
                tp.Text = dgvCustomer.Rows[e.RowIndex].Cells[6].Value.ToString();
                //customerModule.txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                //customerModule.txtCPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();

                btnSave.Enabled = true;
                button1.Enabled = true;
                
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد من حذف البيانات", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM md WHERE mid LIKE '" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    //dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم الحذف بنجاح");
                    // MessageBox.Show("ملحوظه مهم جدا يرجاء التاكد من مسح جميع بيانات الخوارج في نهاية اليوم حتي لا يتم حسبها في اليوم التالي");
                }
            }

            LoadCustomer();
        }

        private void tn_TextChanged(object sender, EventArgs e)
        {
            double total = 0;
            double total1 = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM md WHERE mname=@mname", con);
            cm.Parameters.AddWithValue("@mname", tn.Text);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                total += Convert.ToInt32(dr[4].ToString());
                total1 += Convert.ToInt32(dr[3].ToString());
            }
            dr.Close();
            con.Close();
            label23.Text = total.ToString();
            label9.Text = total1.ToString();
        }
    }
}
