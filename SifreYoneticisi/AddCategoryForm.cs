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
    public partial class AddCategoryForm : Form
    {
        static string conString = "Server=.\\SQLExpress;Database=passwordman;Trusted_Connection=Yes;";
        SqlConnection baglanti = new SqlConnection(conString);
        string parentNode;
        string loggedInUser;

        public AddCategoryForm(String parentNodeName, String userId)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            parentNode = parentNodeName;
            loggedInUser = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            if(parentNode != null)
            {
                string kayit = "INSERT INTO Category(name, parent_category, related_user) VALUES (@name, @parent_category, @related_user)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@name", textBox1.Text);
                komut.Parameters.AddWithValue("@parent_category", parentNode);
                komut.Parameters.AddWithValue("@related_user", loggedInUser);
                komut.ExecuteNonQuery();
            } else
            {
                string kayit = "INSERT INTO Category(name, related_user) VALUES (@name, @related_user)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@name", textBox1.Text);
                komut.Parameters.AddWithValue("@related_user", loggedInUser);
                komut.ExecuteNonQuery();
            }
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
