using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SifreYoneticisi
{
    public partial class MainForm : Form
    {
        static string conString = "Server=.\\SQLExpress;Database=passwordman;Trusted_Connection=Yes;";
        SqlConnection baglanti = new SqlConnection(conString);

        string loggedInUser = "";
        

        public MainForm(String userId)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            loggedInUser = userId;
            FillTreeview();

            // Arama textbox
            textBox1.GotFocus += RemoveText;
            textBox1.LostFocus += AddText;
            textBox1.Text = "Arama yapın...";
            textBox1.ForeColor = Color.Gray;
        }

        // Datagrid doldurma fonksiyonu, parent node için
        private void FillDatagrid(String category_id)
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
            string kayit = "SELECT * FROM Password WHERE (related_category=@category_id OR related_parent_category=@category_id) AND related_user=@related_user";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlParameter prms1 = new SqlParameter("@category_id", category_id);
            SqlParameter prms2 = new SqlParameter("@related_user", loggedInUser);
            komut.Parameters.Add(prms1);
            komut.Parameters.Add(prms2);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        // Datagrid doldurma fonksiyonu, parent node için
        private void FilterDatagrid(String query)
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
            string kayit = "SELECT * FROM Password WHERE title LIKE '%' + @query_param + '%' AND related_user=@related_user";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlParameter prms1 = new SqlParameter("@query_param", query);
            SqlParameter prms2 = new SqlParameter("@related_user", loggedInUser);
            komut.Parameters.Add(prms1);
            komut.Parameters.Add(prms2);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        // Datagrid doldurma fonksiyonu, child için
        private void FillDatagrid(String category_id, String parent_id)
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
            string kayit = "SELECT * FROM Password WHERE (related_category=@category_id) AND related_user=@related_user ";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlParameter prms1 = new SqlParameter("@category_id", category_id);
            SqlParameter prms2 = new SqlParameter("@parent_id", parent_id);
            SqlParameter prms3 = new SqlParameter("@related_user", loggedInUser);
            komut.Parameters.Add(prms1);
            komut.Parameters.Add(prms2);
            komut.Parameters.Add(prms3);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        // Sol kategori treeview doldurma fonksiyonu
        public void FillTreeview()
        {
            if (treeView1.Nodes.Count > 0)
                treeView1.Nodes.Clear();
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
            string kayit = "SELECT * from Category WHERE related_user=@related_user";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlParameter prms1 = new SqlParameter("@related_user", loggedInUser);
            komut.Parameters.Add(prms1);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                if(dt.Rows[i].IsNull("parent_category"))
                {
                    treeView1.Nodes.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["name"].ToString());
                } else
                {
                    treeView1.Nodes[dt.Rows[i]["parent_category"].ToString()].Nodes.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["name"].ToString());
                }
            }
            treeView1.ExpandAll();
            if (treeView1.Nodes.Count > 0)
                FillDatagrid(treeView1.Nodes[0].Name);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Parent != null)
            {
                FillDatagrid(e.Node.Name, e.Node.Parent.Name);
            } else
            {
                FillDatagrid(e.Node.Name);
            }
            
        }

        private void yeniKategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nodeName = null;

            if (treeView1.SelectedNode != null)
            {
                if(treeView1.SelectedNode.Parent != null)
                    nodeName = treeView1.SelectedNode.Parent.Name;
                else
                    nodeName = treeView1.SelectedNode.Name;
            }
            using (AddCategoryForm form = new AddCategoryForm(nodeName, loggedInUser))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FillTreeview();
                }
            }
        }

        // Kategori ekle
        private void button2_Click(object sender, EventArgs e)
        {
            using (AddCategoryForm form = new AddCategoryForm(null, loggedInUser))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FillTreeview();
                }
            }
        }

        // Şifre ekle
        private void button1_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode == null)
            {
                MessageBox.Show("Lütfen önce kategori seçin");
                return;
            }
            string parentName = null;
            if (treeView1.SelectedNode.Parent != null)
                parentName = treeView1.SelectedNode.Parent.Name;
            using (AddPasswordForm form = new AddPasswordForm(loggedInUser, treeView1.SelectedNode.Name, parentName))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FillDatagrid(treeView1.SelectedNode.Name);
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Index == 3 && e.Value != null)
            {
                dataGridView1.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 0)
            {
                progressBar1.Value--;
            }
            else
            {
                timer1.Stop();
                progressBar1.Visible = false;
                bilgiLbl.Visible = false;
                Clipboard.Clear();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                string selectedId = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                using (EditPasswordForm form = new EditPasswordForm(selectedId))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        FillDatagrid(treeView1.SelectedNode.Name);
                    }
                }
            }
            else
            {
                timer1.Stop();
                progressBar1.Visible = true;
                bilgiLbl.Visible = true;
                progressBar1.Value = 12;
                timer1.Start();
                Clipboard.SetText(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        // Arkaplanda çalışan uygulamadaki formu dolduran fonksiyon
        private void FillPasswordBehind()
        {
            this.WindowState = FormWindowState.Minimized;
            string username = dataGridView1.SelectedRows[0].Cells["Username"].Value.ToString();
            string password = dataGridView1.SelectedRows[0].Cells["Password"].Value.ToString();
            Thread.Sleep(500);
            if(username.Length > 0)
            {
                foreach (char ch in username)
                {
                    Thread.Sleep(50);
                    SendKeys.SendWait(ch.ToString());
                }
                SendKeys.SendWait("{TAB}");
            }
            foreach (char ch in password)
            {
                Thread.Sleep(50);
                SendKeys.SendWait(ch.ToString());
            }
            SendKeys.SendWait("{ENTER}");
        }

        // Windows'un CTRL-V tuşlarını algılayan fonksiyonu
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V))
            {
                FillPasswordBehind();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void kategoriyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Kategoriyi silmek istediğinizden emin misiniz? Altındaki tüm şifreler de silinecektir"
                , "Silme Onayı", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum) // Eğer kullanıcı Evet seçeneğini seçmişse, veritabanından kaydı silecek kodlar çalışır.
            {
                string nodeName;

                if (treeView1.SelectedNode != null)
                    nodeName = treeView1.SelectedNode.Name;
                else
                    return;

                string silmeSorgusu = "DELETE FROM Category WHERE (id=@category_id OR parent_category=@category_id)";
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();
                SqlCommand komut = new SqlCommand(silmeSorgusu, baglanti);
                SqlParameter prms1 = new SqlParameter("@category_id", nodeName);
                komut.Parameters.Add(prms1);
                komut.ExecuteNonQuery();
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();

                FillTreeview();
            }
        }

        private void kullanıcıAdınıKopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;
            timer1.Stop();
            progressBar1.Visible = true;
            bilgiLbl.Visible = true;
            progressBar1.Value = 12;
            timer1.Start();
            Clipboard.SetText(dataGridView1.SelectedRows[0].Cells["Username"].Value.ToString());
        }

        private void şifreyiKopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;
            timer1.Stop();
            progressBar1.Visible = true;
            bilgiLbl.Visible = true;
            progressBar1.Value = 12;
            timer1.Start();
            Clipboard.SetText(dataGridView1.SelectedRows[0].Cells["Password"].Value.ToString());
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;
            string selectedId = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            using (EditPasswordForm form = new EditPasswordForm(selectedId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FillDatagrid(treeView1.SelectedNode.Name);
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;
            DialogResult durum = MessageBox.Show("Şifreyi silmek istediğinizden emin misiniz?"
                , "Silme Onayı", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum) // Eğer kullanıcı Evet seçeneğini seçmişse, veritabanından kaydı silecek kodlar çalışır.
            {
                string passwordId;

                if (treeView1.SelectedNode != null)
                    passwordId = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                else
                    return;

                string silmeSorgusu = "DELETE FROM Password WHERE (id=@password_id)";
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();
                SqlCommand komut = new SqlCommand(silmeSorgusu, baglanti);
                SqlParameter prms1 = new SqlParameter("@password_id", passwordId);
                komut.Parameters.Add(prms1);
                komut.ExecuteNonQuery();
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();

                FillTreeview();
            }
        }

        public void RemoveText(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            if (textBox1.Text == "Arama yapın...")
                textBox1.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Arama yapın...";
            }
        }

        // Arama butonu
        private void button3_Click(object sender, EventArgs e)
        {
            FilterDatagrid(textBox1.Text.ToLower());
        }
    }
}