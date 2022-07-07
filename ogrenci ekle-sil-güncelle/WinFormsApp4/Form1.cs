using System.Data.SqlClient;

namespace WinFormsApp4
{
    public partial class frm_login : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public frm_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM tblUser where usr=@user AND psw=@pass";

            con = new SqlConnection("server=.; Initial Catalog=dbLogin;Integrated Security=true");
            cmd = new SqlCommand(sorgu, con);

            cmd.Parameters.AddWithValue("@user", txt_id.Text);
            cmd.Parameters.AddWithValue("@pass", txt_password.Text);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Welcome");
                con.Close();
                this.Hide();
                Form2 f2 = new Form2();
                f2.admin = txt_id.Text;
                f2.Show();
            }
            else
            {
                MessageBox.Show("Try Again! Wrong Password or ID!!!");
            }
        }
    }
}