using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace SifreYoneticisi
{
    public partial class EditPasswordForm : Form
    {
        static string conString = "Server=.\\SQLExpress;Database=passwordman;Trusted_Connection=Yes;";
        SqlConnection baglanti = new SqlConnection(conString);
        string passwordId;
        public EditPasswordForm(String editPasswordId)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            passwordId = editPasswordId;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text != textBox4.Text)
            {
                textBox4.BackColor = Color.Pink;
            } else
            {
                textBox4.BackColor = Color.White;
            }
            passwordStrengthControl1.SetPassword(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                textBox4.BackColor = Color.Pink;
            }
            else
            {
                textBox4.BackColor = Color.White;
            }
        }

        // Rastgele şifre oluştur
        private void button1_Click(object sender, EventArgs e)
        {
            string res = GetRandomAlphanumericString(32);
            textBox3.Text = res;
            textBox4.Text = res;
        }

        // Kaydet
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Şifreler birbiriyle uyuşmuyor.", "Doğrulama hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Lütfen boş alanları doldurun", "Doğrulama hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            string kayit = "UPDATE Password SET title=@title, username=@username, password=@password WHERE id=@password_id";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@title", textBox1.Text);
            komut.Parameters.AddWithValue("@username", textBox2.Text);
            komut.Parameters.AddWithValue("@password", textBox3.Text);
            komut.Parameters.AddWithValue("@password_id", passwordId);

            komut.ExecuteNonQuery();
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // İptal
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Şifre oluşturma fonksiyonları
        public static string GetRandomAlphanumericString(int length)
        {
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789" +
                ".?!%$";
            return GetRandomString(length, alphanumericCharacters);
        }

        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }

        private void EditPasswordForm_Load(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
            string kayit = "SELECT * FROM Password where id=@password_id";
            //tc parametresine bağlı olarak hasta bilgilerini çeken sql kodu
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@password_id", passwordId);
            //tc parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

                textBox1.Text = dr["title"].ToString();
                textBox2.Text = dr["username"].ToString();
                textBox3.Text = dr["password"].ToString();
                textBox4.Text = dr["password"].ToString();
            }
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
        }
    }
}
