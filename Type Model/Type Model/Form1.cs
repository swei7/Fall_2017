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
        int rowNum = 1;

        public Form1()
        {
            InitializeComponent();
            //Get the lowest id number in database order by Id
            //assign the id to rowNum
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=IMS;Integrated Security=True;";

            string cmdText =
                "DELETE FROM [dbo].[Type] WHERE ID = @rowNum; ";

            //1 Create a connection
            SqlConnection conn = new SqlConnection(connectionString);

            //2 Open the connection
            conn.Open();

            //3 Create sqlCommand Object
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@rowNum", rowNum);

            //4 Execute Command
            cmd.ExecuteNonQuery();

            //5 close connection
            conn.Close();

            MessageBox.Show("Deleted Successfully!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {         
            string connectionString = "Server=localhost;Database=IMS;Integrated Security=True;";

            string sqlCmd = "SELECT Name, Description FROM Type WHERE ID = @rowNum; ";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);

            cmd.Parameters.AddWithValue("@rowNum", rowNum);

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
                    else
                    {
                        textBox2.Text = "Empty";
                    }
                }
                conn.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=IMS;Integrated Security=True;";

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
            string connectionString = "Server=localhost;Database=IMS;Integrated Security=True;";

            string cmdText =
                "UPDATE [dbo].[Type] SET Name = @name, Description = @description WHERE ID = @rowNum; " ;

            //1 Create a connection
            SqlConnection conn = new SqlConnection(connectionString);

            //2 Open the connection
            conn.Open();

            //3 Create sqlCommand Object
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@rowNum", rowNum);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@description", textBox2.Text);

            //4 Execute Command
            cmd.ExecuteNonQuery();

            //5 close connection
            conn.Close();

            MessageBox.Show("Saved Successfully!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=IMS;Integrated Security=True;";

            string sqlCmd = "select Top 1 * from Type where Id < @rowNum order by id desc;";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);

            // select Top 1 * from Type where Id > 3 order by id;
            

            cmd.Parameters.AddWithValue("@rowNum", rowNum);

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rowNum = (int)reader["Id"];

                    textBox1.Text = reader["Name"].ToString();
                    if (reader["Description"] != null)
                    {
                        textBox2.Text = reader["Description"].ToString();
                    }
                    else textBox2.Text = "Empty";
                }
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=IMS;Integrated Security=True;";

            string sqlCmd = "select Top 1 * from Type where Id > @rowNum order by id;";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            
            cmd.Parameters.AddWithValue("@rowNum", rowNum);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rowNum = (int)reader["Id"];

                    textBox1.Text = reader["Name"].ToString();
                    if (reader["Description"] != null)
                    {
                        textBox2.Text = reader["Description"].ToString();
                    }
                    else textBox2.Text = "Empty";
                }
                conn.Close();
            }
        }
    }
}

