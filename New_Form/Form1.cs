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
namespace New_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP;Initial Catalog=Youtube;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, user_password;
            username = textBox1.Text;
            user_password = textBox2.Text;

            try
            {
                String querry = "SELECT * FROM Login_Form WHERE username='"+textBox1.Text+"' AND password='"+textBox2.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry,conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    user_password = textBox2.Text;

                    //page that needed to be loaded next
                    Menuform form2 = new Menuform();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Login Details", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();

                    //to focus username
                    textBox1.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Error!!","Error", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }
    }
}
