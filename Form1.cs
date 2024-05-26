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

namespace CA_02_VP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Sandalu\\Desktop\\c#\\New folder\\CA_02_VP\\CA_02_VP\\books.mdf\";Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into library values (@isbm,@title,@qty,@author)", conn);
            cmd.Parameters.AddWithValue("@isbm",int.Parse(txtisbm.Text));
            cmd.Parameters.AddWithValue("@title",txttitle.Text);
            cmd.Parameters.AddWithValue("@qty", int.Parse(txtqty.Text));
            cmd.Parameters.AddWithValue("@author", txtatr.Text);
            cmd.ExecuteNonQuery();  
            conn.Close();
            MessageBox.Show("New Recored added");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Sandalu\\Desktop\\c#\\New folder\\CA_02_VP\\CA_02_VP\\books.mdf\";Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update library set title=@title,qty=@qty,author=@author where isbm=@isbm ", conn);
            cmd.Parameters.AddWithValue("@isbm", int.Parse(txtisbm.Text));
            cmd.Parameters.AddWithValue("@title", txttitle.Text);
            cmd.Parameters.AddWithValue("@qty", int.Parse(txtqty.Text));
            cmd.Parameters.AddWithValue("@author", txtatr.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Updated Recored");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Sandalu\\Desktop\\c#\\New folder\\CA_02_VP\\CA_02_VP\\books.mdf\";Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete library where isbm=@isbm ",conn);
            cmd.Parameters.AddWithValue("@isbm", int.Parse(txtisbm.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Deleted Recored");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Sandalu\\Desktop\\c#\\New folder\\CA_02_VP\\CA_02_VP\\books.mdf\";Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from library", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt); 
            dataGridView1.DataSource = dt;
            conn.Close();
            MessageBox.Show("displayed all recored");




        }
    }
}

