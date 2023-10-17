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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projet_Framework
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DHOUHA\SQLEXPRES;Initial Catalog=Dictionaire;Integrated Security=True");
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from login where username ='" + username.Text + "' and password ='" + password.Text + "'";


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Administrator ad = new Administrator();
                    ad.Show();
                    MessageBox.Show("Login Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Login UnSuccessfully", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
            con.Close();
          

        
        }

        private void label6_Click(object sender, EventArgs e)
        {

            Register Fr = new Register();
            Fr.Show();
            this.Close();

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from login where username ='" + username.Text + "' and password ='" + password.Text + "'";
  
         
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form1 Form1 = new Form1();
                    Form1.Show();
                    MessageBox.Show("Login Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Login UnSuccessfully", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

           
            }
            catch (Exception ex){
                    MessageBox.Show(""+ex);

            }
            con.Close();
        }

        private void showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!showpassword.Checked)
            {
                password.PasswordChar = '*';
               

            }
            else
            {
                password.PasswordChar = '\0';
              
            }
        }
    }
}
