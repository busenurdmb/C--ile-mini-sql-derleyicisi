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

namespace MiniSqlDüzenleyicisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-493DFJA\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
       void run()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-493DFJA\SQLEXPRESS;Initial 
             Catalog=" + comboBox1.Text + "; Integrated Security=True");
            string sorgu = richTextBox1.Text;
            try
            {
                SqlDataAdapter dt = new SqlDataAdapter(sorgu, baglanti);
                DataTable da = new DataTable();
                dt.Fill(da);
                dataGridView1.DataSource = da;

            }
            catch (Exception)
            {

                MessageBox.Show("SORGUNUZU KONTROL EDİN");
            }
        }
        void sumdeleteupdate()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-493DFJA\SQLEXPRESS;Initial
        Catalog=" + comboBox1.Text + ";Integrated Security=True");
            string sorgu = richTextBox1.Text;
            try
            {

                baglanti.Open();
                SqlCommand kmt = new SqlCommand(sorgu, baglanti);
                kmt.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("yanlış sorgu ");
            }
        }
       private void Form1_Load(object sender, EventArgs e)
        {
           
               
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from sys.databases", baglanti);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {


            run();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sumdeleteupdate();
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            run();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sumdeleteupdate();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sumdeleteupdate();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            sumdeleteupdate();
        }
    }
}
