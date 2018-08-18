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

namespace Database_Connectivity
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\hina\documents\visual studio 2013\Projects\Database_Connectivity\Database_Connectivity\Mydb.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string cname = textBox1.Text;
            int cfees = Convert.ToInt32(textBox2.Text);
            try
            {
                cn.Open();
                string query = "insert into courses (c_name,c_fees) values('" + cname + "','" + cfees + "')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("record insert");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cname = textBox1.Text;
            int cfees = Convert.ToInt32(textBox2.Text);
            try
            {
                cn.Open();
                string query = "update courses set c_name = '" + cname + "',c_fees= '" + cfees + "' where C_id='"+Convert.ToInt32(textBox3.Text) +"' ";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("record insert");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string query = " delete from courses  where C_id='" + Convert.ToInt32(textBox3.Text) + "' ";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("record delete");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                cn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from courses", cn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        private void student_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
