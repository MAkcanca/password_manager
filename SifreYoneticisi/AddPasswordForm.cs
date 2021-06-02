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
    public partial class AddPasswordForm : Form
    {
        static string conString = "Server=.\\SQLExpress;Database=passwordman;Trusted_Connection=Yes;";
        SqlConnection baglanti = new SqlConnection(conString);
        string loggedInUser;
        string relatedCategory;
        string relatedParentCategory;
        public AddPasswordForm(String userId, String relatedCategoryId, String relatedParentCategoryId)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            loggedInUser = userId;
            relatedCategory = relatedCategoryId;
            relatedParentCategory = relatedParentCategoryId;
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
            string kayit = "";
            if(relatedParentCategory != null)
                kayit = "INSERT INTO Password(title, username, password, related_user, related_category, related_parent_category) " +
                    "VALUES (@title, @username, @password, @related_user, @related_category, @related_parent_category)";
            else
                kayit = "INSERT INTO Password(title, username, password, related_user, related_category) " +
                    "VALUES (@title, @username, @password, @related_user, @related_category)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@title", textBox1.Text);
            komut.Parameters.AddWithValue("@username", textBox2.Text);
            komut.Parameters.AddWithValue("@password", textBox3.Text);
            komut.Parameters.AddWithValue("@related_user", loggedInUser);
            komut.Parameters.AddWithValue("@related_category", relatedCategory);
            if(relatedParentCategory != null)
                komut.Parameters.AddWithValue("@related_parent_category", relatedParentCategory);
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
    }
}
