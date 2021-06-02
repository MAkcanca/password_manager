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

namespace SifreYoneticisi
{
    public partial class LoginForm : Form
    {
        static string conString = "Server=.\\SQLExpress;Database=passwordman;Trusted_Connection=Yes;";
        SqlConnection baglanti = new SqlConnection(conString);
        public LoginForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
            string kayit = "SELECT * FROM [User] WHERE username=@username AND password=@password";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlParameter prms1 = new SqlParameter("@username", textBox1.Text);
            SqlParameter prms2 = new SqlParameter("@password", textBox2.Text);
            komut.Parameters.Add(prms1);
            komut.Parameters.Add(prms2);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                MainForm frm2 = new MainForm(dt.Rows[0]["id"].ToString());
                frm2.Closed += (s, args) => this.Close();
                frm2.Show();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı/şifre.");
            }
        }
    }
}
