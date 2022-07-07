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

namespace WinFormsApp4
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataSet ds;
        SqlDataAdapter da;
        public void listele()
        {
            con = new SqlConnection("server=.; Initial Catalog=dbLogin;Integrated Security=true");
            da = new SqlDataAdapter("select * from kitap ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "kitap");
            dtg_kitap.DataSource = ds.Tables["kitap"];
            con.Close();
        }
        public string admin = string.Empty;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lbl_wlcm.Text = lbl_wlcm.Text +" "+ admin;
            listele();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into kitap values(@id,@ad,@soyad) ";
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update kitap set ktp_ad=@ad,ktp_yazar=@soyad where ktp_no=@id ";
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from kitap where ktp_no=@id ";
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            listele();
        }
    }
}
