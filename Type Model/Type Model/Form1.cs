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

namespace Type_Model
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int rowNum = 1;

            string connectionString = "Server=DESKTOP-9EIPQF9;Database=Inventory Management System;Integrated Security=True;";

            string sqlCmd = "SELECT Name, Description FROM Type WHERE ID = @rowNum; ";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    textBox1.Text = reader["Name"].ToString();
                    if (reader["Description"] != null)
                    {
                        textBox2.Text = reader["Description"].ToString();
                    }
                    textBox2.Text = "Empty";
                }
                conn.Close();
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-9EIPQF9;Database=Inventory Management System;Integrated Security=True;";

            string cmdText =
                "INSERT INTO [dbo].[Type] (Name,Description) VALUES (@name,@description);";

            //1 Create a connection
            SqlConnection conn = new SqlConnection(connectionString);

            //2 Open the connection
            conn.Open();

            //3 Create sqlCommand Object
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@description", textBox2.Text);

            //4 Execute Command
            cmd.ExecuteNonQuery();

            //5 close connection
            conn.Close();

            MessageBox.Show("Created Successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

