using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Common;
using System.Threading;
using System.IO;
using System.Data.SqlClient;


namespace InventoryManagementSystem
{
    public partial class Backup_Restore_Form7 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =MOSA-PC\SQLEXPRESS; Initial Catalog = aserzamzam12; Integrated Security = True");
        
        public Backup_Restore_Form7()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
                BrowseBackupBtn.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            con.Open();
            String database = con.Database.ToString();
            try
            {
                if (textBox1.Text == string.Empty)
                {
                    //  s.Speak("please enter the valid backup file location");
                    MessageBox.Show("من فصلك اختار مكان حفظ النسخة الاحتياطية");
                }
                else
                {

                    string q = "BACKUP DATABASE [" + database + "] TO DISK='" + textBox1.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";

                    SqlCommand scmd = new SqlCommand(q, con);
                    scmd.ExecuteNonQuery();
                    // s.Speak("Backup taken successfully");
                    MessageBox.Show("تم اخذ نسخة احتياطية من البيانات بنجاح", "جاري النسخ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button3.Enabled = false;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void RestoreBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SQL SERVER database backup files|*.bak";
            ofd.Title = "Database Restore";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
                RestoreBtn.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            String database = con.Database.ToString();
            try
            {
                if (textBox2.Text == string.Empty)
                {
                    //  s.Speak("please enter the valid backup file location");
                    MessageBox.Show("من فصلك اختار مكان النسخة الاحتياطية المحفوظة");
                }
                else
                {
                    string sql1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    cmd1.ExecuteNonQuery();

                    string sql2 = string.Format("USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + textBox2.Text + "' WITH REPLACE;");
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.ExecuteNonQuery();

                    string sql3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    cmd3.ExecuteNonQuery();
                    // s.Speak("Database Restored successfully");
                    MessageBox.Show("تم استرجاع النسخة بنجاح", "جاري اتسرجاع النسخة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
