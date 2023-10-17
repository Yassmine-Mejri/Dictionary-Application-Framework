using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projet_Framework
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DHOUHA\SQLEXPRES;Initial Catalog=Dictionaire;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            Administrator ad = new Administrator();
                ad.Show();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select mot_E, type_E , exemple_E,exemple_F from English,French where synonyme_E='"+ textBox1.Text +"'and mot_F='"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                 textBox2.Text = " Type: " + dr["type_E"].ToString()+ "\r\n"+ " Mot: " + dr["mot_E"].ToString()+"\r\n" 
                 + " Exemple 1: " + dr["exemple_E"].ToString()+"\r\n" + " Exemple 2: " + dr["exemple_F"].ToString();
            }
            con.Close();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select mot_F, type_F , exemple_F  , exemple_E from French ,English where synonyme_F='" + textBox1.Text + "'and mot_E='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                  textBox2.Text = " Type: " + dr["type_F"].ToString() + "\r\n" + " Mot: " + dr["mot_F"].ToString() + "\r\n" 
                  +" Exemple 1: " + dr["exemple_F"].ToString() + "\r\n" + " Exemple 2: " + dr["exemple_E"].ToString();
            }
            con.Close();
        }
    }
}
