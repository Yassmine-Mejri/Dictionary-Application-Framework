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
    public partial class Administrator : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DHOUHA\SQLEXPRES;Initial Catalog=Dictionaire;Integrated Security=True");
        public Administrator()
        {
            InitializeComponent();
        }

        private void btn_I_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into English values('" + mot_E.Text + "','" + type_E.Text + "','" + exemple_E.Text + "','" + mot_F.Text + "')";
            cmd.ExecuteReader();
            con.Close();
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "insert into French values('" + mot_F.Text + "','" + type_F.Text + "','" + exemple_F.Text + "','" + mot_E.Text + "')";
            cmd1.ExecuteReader();
            con.Close();

            MessageBox.Show("insert successefully");

        }

        private void btn_D_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from English where mot_E='" + mot_E.Text + "'";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "delete from French where mot_F='" + mot_F.Text + "'";
            cmd1.ExecuteNonQuery();

            con.Close();


            MessageBox.Show("delete successefully");
        }

        private void btn_E_Click(object sender, EventArgs e)
        {


            con.Open();
            

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update English set type_E= '" + type_E.Text + "', exemple_E ='" + exemple_E.Text + "' where mot_E= '" + mot_E.Text + "'";
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "update French set type_F= '" + type_F.Text + "', exemple_F ='" + exemple_F.Text + "'where mot_F='" + mot_F.Text + "'";
            cmd2.ExecuteNonQuery();


            con.Close();
 
        }

        private void mot_E_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from English where mot_E='" + mot_E.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                type_E.Text = dr["type_E"].ToString();
                exemple_E.Text = dr["exemple_E"].ToString();

            }
            con.Close();
        }

        private void mot_F_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from French where mot_F='" + mot_F.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                type_F.Text = dr["type_F"].ToString();
                exemple_F.Text = dr["exemple_F"].ToString();

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Close();   
        }

        private void textfile_Click(object sender, EventArgs e)
        {
            import r = new import();
            r.Show();
            this.Close();
        }
    }
}
