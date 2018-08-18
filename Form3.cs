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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\hina\documents\visual studio 2013\Projects\Database_Connectivity\Database_Connectivity\Mydb.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
               // string myquery = "select s.stu_id,s.stu_name,s.stu_gender,s.stu_age,c.c_name,c.c_fees 
              //  from student s inner join courses c on s.course_id=c.C_id ";

                SqlDataAdapter adapter = new SqlDataAdapter(myquery, cn);
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
    }
}
