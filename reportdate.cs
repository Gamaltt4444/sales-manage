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
    public partial class reportdate : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public reportdate()
        {
            InitializeComponent();
        }
        public void g()
        {
            double total = 0;
            int i = 0;
            double total1 = 0;
            double total2 = 0;
            //double total3 = 0;
            int n = 0;
            dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT date,price,dec FROM nas", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                total += Convert.ToInt32(dr[1].ToString());
            }
            dr.Close();
            con.Close();
            label22.Text = total.ToString();


            dataGridView1.Rows.Clear();
            cm = new SqlCommand("SELECT iddd,odate,pid,cid,qty,price,total From tbOrder ", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView1.Rows.Add(n, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                total1 += Convert.ToInt32(dr[6].ToString());
                total2 += Convert.ToInt32(dr[4].ToString());
                //total3 += Convert.ToInt32(dr[6].ToString());
            }
            dr.Close();
            con.Close();
            label21.Text = n.ToString();
            label23.Text = total1.ToString();
            label15.Text = total2.ToString();
            double total5 = total1 - total;
            label11.Text = total5.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            double tt2 = 0;
            double tt3 = 0;
            int m = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM md", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                m++;
                dgvCustomer.Rows.Add(m, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                // total += Convert.ToInt32(dr[2].ToString());
                tt2 += Convert.ToInt32(dr[4].ToString());
                tt3 += Convert.ToInt32(dr[3].ToString());
            }
            dr.Close();
            con.Close();
            label24.Text = tt2.ToString();
            label26.Text = tt3.ToString();

            double total = 0;
            int i = 0;
            double total1 = 0;
            double total2 = 0;
            //double total3 = 0;
            int n = 0;
            dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT date,price,dec FROM nas", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                total += Convert.ToInt32(dr[1].ToString());
            }
            dr.Close();
            con.Close();
            label22.Text = total.ToString();
           
            
            dataGridView1.Rows.Clear();
            cm = new SqlCommand("SELECT iddd,odate,pid,cid,qty,price,total From tbOrder ", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView1.Rows.Add(n, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                total1 += Convert.ToInt32(dr[6].ToString());
                total2 += Convert.ToInt32(dr[4].ToString());
                //total3 += Convert.ToInt32(dr[6].ToString());
            }
            dr.Close();
            con.Close();
            label21.Text = n.ToString();
            label23.Text = total1.ToString();
            label15.Text = total2.ToString();
            double total5 = total1 - (total + tt2);
            label11.Text = total5.ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            double tt2 = 0;
            double tt3 = 0;
            int m = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM md where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                m++;
                dgvCustomer.Rows.Add(m, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                // total += Convert.ToInt32(dr[2].ToString());
                tt2 += Convert.ToInt32(dr[4].ToString());
                tt3 += Convert.ToInt32(dr[3].ToString());
            }
            dr.Close();
            con.Close();
            label24.Text = tt2.ToString();
            label26.Text = tt3.ToString();

            double total = 0;
            int i = 0;
            double total1 = 0;
            double total2 = 0;
            //double total3 = 0;
            int n = 0;
            dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT date,price,dec FROM nas where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                total += Convert.ToInt32(dr[1].ToString());
            }
            dr.Close();
            con.Close();
            label22.Text = total.ToString();

            dataGridView1.Rows.Clear();
            cm = new SqlCommand("SELECT iddd,odate,pid,cid,qty,price,total From tbOrder  where odate between @fd and @sd", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker1.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView1.Rows.Add(n, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                total1 += Convert.ToInt32(dr[6].ToString());
                total2 += Convert.ToInt32(dr[4].ToString());
                //total3 += Convert.ToInt32(dr[6].ToString());

            }
            dr.Close();
            con.Close();
            label21.Text = n.ToString();
            label23.Text = total1.ToString();
            label15.Text = total2.ToString();
            double total5 = total1 - (total+tt2);
            label11.Text = total5.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد من حذف هذا الاوردر؟", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbOrder WHERE iddd LIKE '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("!تم الحذف بنجاح");

                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    g();

                }
            }

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
    }
}
