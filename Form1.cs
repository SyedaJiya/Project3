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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\hina\documents\visual studio 2013\Projects\Database_Connectivity\Database_Connectivity\Mydb.mdf;Integrated Security=True");
        string gender=null;
        string courses = "";
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int age = Convert.ToInt32(textBox2.Text);
            
          
            if (radioButton1.Checked)
            {
              gender= radioButton1.Text;
            }
            if (radioButton2.Checked)
            {
                gender = radioButton2.Text;
            }

             

            if (checkBox1.Checked)
            {
                courses += checkBox1.Text + " ";
            }
            if (checkBox2.Checked)
            {
                courses += checkBox2.Text + "  ";
            }
            if (checkBox3.Checked)
            {
                courses += checkBox3.Text + "  ";
            }
            if (checkBox4.Checked)
            {
                courses += checkBox4.Text + "  ";
            }

            try
            {
                cn.Open();
                string query = "insert into student (stu_name,stu_age,stu_gender,courses) values('"+name+"','"+age+"','"+gender+"','"+courses+"')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("record insert");

            }
            catch(Exception ex)
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
            
            if (radioButton1.Checked)
            {
              gender= radioButton1.Text;
            }
            if (radioButton2.Checked)
            {
                gender = radioButton2.Text;
            }

             

            if (checkBox1.Checked)
            {
                courses += checkBox1.Text + " ";
            }
            if (checkBox2.Checked)
            {
                courses += checkBox2.Text + "  ";
            }
            if (checkBox3.Checked)
            {
                courses += checkBox3.Text + "  ";
            }
            if (checkBox4.Checked)
            {
                courses += checkBox4.Text + "  ";
            }
            try
            {
                cn.Open();
                string query = " update student set stu_name='"+textBox1.Text+"',stu_age='"+textBox2.Text+"',  stu_gender='"+gender+"',courses='"+courses+"' where stu_id='"+Convert.ToInt32(textBox3.Text)+"' ";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("record update");

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
                string query = " delete from student  where stu_id='" + Convert.ToInt32(textBox3.Text) +"' ";
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

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.studentTableAdapter.Fill(this.mydbDataSet.student);
            try
            {
                cn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from student", cn);
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
