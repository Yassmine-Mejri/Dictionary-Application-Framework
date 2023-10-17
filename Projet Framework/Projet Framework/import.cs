using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Framework
{
    public partial class import : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DHOUHA\SQLEXPRES;Initial Catalog=Dictionaire;Integrated Security=True");
        public import()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView2.DataSource != null)
            {

                 TextWriter tw = new StreamWriter(@"C:\\Users\\Lenovo\\Documents\\MEGA\\2LNIG\\semestre2\\PROJETS\\FRAMEWORK\\dictionnaire.txt");
                for (int i = 0; i < dataGridView2.Rows.Count-1; i++)

                { 
                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    {
                        if (j == dataGridView2.Columns.Count-1)
                        {
                            tw.Write(dataGridView2.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                            tw.Write( dataGridView2.Rows[i].Cells[j].Value.ToString() +"|");
                        }

                    tw.WriteLine("");

                }
                    tw.Close();
             }
            

        }
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void dataGridView2_DoubleClick(object sender, EventArgs e)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select mot_E,mot_F,type_E,exemple_E,exemple_F from English,French where mot_E=synonyme_F and mot_F=synonyme_E ";
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];

            }

            private void button1_Click(object sender, EventArgs e)
            {
                string[] lines = File.ReadAllLines(@"C:\\Users\\Lenovo\\Documents\\MEGA\\2LNIG\\semestre2\\PROJETS\\FRAMEWORK\\dictionnaire.txt");
                string[] values;


                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split('|');
                    string[] row = new string[values.Length];

                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }

                    dt.Rows.Add(row);
                }
            }
            DataTable dt = new DataTable();

            private void import_Load(object sender, EventArgs e)
            {


                dt.Columns.Add("MOT_E", typeof(string));
                dt.Columns.Add("MOT_F", typeof(string));
                dt.Columns.Add("type_E", typeof(string));
                dt.Columns.Add("exemple_E", typeof(string));
                dt.Columns.Add("exemple_F", typeof(string));
                dataGridView1.DataSource = dt;

            }



            private void button3_Click(object sender, EventArgs e)
            {
                Administrator ad = new Administrator();
                ad.Show();
            }
        }
    }
