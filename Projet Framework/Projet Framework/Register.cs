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

namespace Projet_Framework
{

    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DHOUHA\SQLEXPRES;Initial Catalog=Dictionaire;Integrated Security=True");
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "" && password.Text == "" && Confpassword.Text == "")
            {
                MessageBox.Show("Username and Password fileds are empty", "Regestration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (password.Text == Confpassword.Text)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into login values ('" + username.Text + "','" + password.Text + "')";
                cmd.ExecuteReader();
                con.Close();

                MessageBox.Show("Your Account Has Been Successfully Created", "Regestration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            }
            else
            {
                MessageBox.Show("Password  does not match , Please re-enter ", "Regestration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.Text = "";
                password.Text = "";
                Confpassword.Text = "";
            }
        }

        private void showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!showpassword.Checked)
            {
                password.PasswordChar = '*';
                Confpassword.PasswordChar = '*';

            }
            else
            {
                password.PasswordChar = '\0';
                Confpassword.PasswordChar = '\0';
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            username.Text = "";
            password.Text = "";
            Confpassword.Text = "";
            username.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
            login l = new login();
            l.Show();
        }
    }
}
