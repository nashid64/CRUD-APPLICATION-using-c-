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

namespace CRUDApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string conString = "Data Source=DESKTOP-TCVB1HR;Initial Catalog=CRUD;Integrated Security=True;TrustServerCertificate=True";
        
        
        
        //INSERT
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO CRUDTable(id, name, age) VALUES(@id, @name, @age)", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(IDTABLE.Text));
            cmd.Parameters.AddWithValue("@name", NAMETABLE.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(AGETABLE.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Inserted Successfully ");






    }
        // DELETE
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE CRUDTable WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(IDTABLE.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Deleted Successfully");
        }




        //UPDATE
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE CRUDTable SET name=@name, age=@age WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(IDTABLE.Text));
            cmd.Parameters.AddWithValue("@name", NAMETABLE.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(AGETABLE.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Updated Successfully");

           
        }
        //GRIDVIEW/SHOW
        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CRUDTable WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(IDTABLE.Text));
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            dataAdapter.Fill(data);
            dataGridView1.DataSource = data;
        }
    }
}
