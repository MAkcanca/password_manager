
namespace SifreYoneticisi
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniKategoriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriyiSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.related_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.related_parent_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.related_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kullanıcıAdınıKopyalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şifreyiKopyalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bilgiLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip2;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(12, 59);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(191, 379);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniKategoriEkleToolStripMenuItem,
            this.kategoriyiSilToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(168, 48);
            // 
            // yeniKategoriEkleToolStripMenuItem
            // 
            this.yeniKategoriEkleToolStripMenuItem.Name = "yeniKategoriEkleToolStripMenuItem";
            this.yeniKategoriEkleToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.yeniKategoriEkleToolStripMenuItem.Text = "Yeni Kategori Ekle";
            this.yeniKategoriEkleToolStripMenuItem.Click += new System.EventHandler(this.yeniKategoriEkleToolStripMenuItem_Click);
            // 
            // kategoriyiSilToolStripMenuItem
            // 
            this.kategoriyiSilToolStripMenuItem.Name = "kategoriyiSilToolStripMenuItem";
            this.kategoriyiSilToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.kategoriyiSilToolStripMenuItem.Text = "Kategoriyi Sil";
            this.kategoriyiSilToolStripMenuItem.Click += new System.EventHandler(this.kategoriyiSilToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Yeni Şifre Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.related_category,
            this.related_parent_category,
            this.related_user,
            this.Title,
            this.UserName,
            this.Password});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(210, 59);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(578, 379);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // related_category
            // 
            this.related_category.DataPropertyName = "related_category";
            this.related_category.HeaderText = "related_category";
            this.related_category.Name = "related_category";
            this.related_category.ReadOnly = true;
            this.related_category.Visible = false;
            // 
            // related_parent_category
            // 
            this.related_parent_category.DataPropertyName = "related_parent_category";
            this.related_parent_category.HeaderText = "related_parent_category";
            this.related_parent_category.Name = "related_parent_category";
            this.related_parent_category.ReadOnly = true;
            this.related_parent_category.Visible = false;
            // 
            // related_user
            // 
            this.related_user.DataPropertyName = "related_user";
            this.related_user.HeaderText = "related_user";
            this.related_user.Name = "related_user";
            this.related_user.ReadOnly = true;
            this.related_user.Visible = false;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "title";
            this.Title.HeaderText = "Başlık";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "username";
            this.UserName.HeaderText = "Kullanıcı Adı";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "password";
            this.Password.HeaderText = "Şifre";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullanıcıAdınıKopyalaToolStripMenuItem,
            this.şifreyiKopyalaToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.silToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 92);
            // 
            // kullanıcıAdınıKopyalaToolStripMenuItem
            // 
            this.kullanıcıAdınıKopyalaToolStripMenuItem.Name = "kullanıcıAdınıKopyalaToolStripMenuItem";
            this.kullanıcıAdınıKopyalaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.kullanıcıAdınıKopyalaToolStripMenuItem.Text = "Kullanıcı adını kopyala";
            this.kullanıcıAdınıKopyalaToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıAdınıKopyalaToolStripMenuItem_Click);
            // 
            // şifreyiKopyalaToolStripMenuItem
            // 
            this.şifreyiKopyalaToolStripMenuItem.Name = "şifreyiKopyalaToolStripMenuItem";
            this.şifreyiKopyalaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.şifreyiKopyalaToolStripMenuItem.Text = "Şifreyi kopyala";
            this.şifreyiKopyalaToolStripMenuItem.Click += new System.EventHandler(this.şifreyiKopyalaToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Yeni Kategori Ekle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(673, 449);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Maximum = 12;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(115, 22);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Value = 12;
            this.progressBar1.Visible = false;
            // 
            // bilgiLbl
            // 
            this.bilgiLbl.AutoSize = true;
            this.bilgiLbl.Location = new System.Drawing.Point(207, 453);
            this.bilgiLbl.Name = "bilgiLbl";
            this.bilgiLbl.Size = new System.Drawing.Size(230, 13);
            this.bilgiLbl.TabIndex = 5;
            this.bilgiLbl.Text = "Veri kopyalandı, 12 saniye sonra temizlenecek.";
            this.bilgiLbl.Visible = false;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(-3, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(830, 2);
            this.label3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(709, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "121620191071";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Kategoriler";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(207, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Şifreler";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(326, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(432, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Ara";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(318, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 22);
            this.label5.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AcceptButton = this.button3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bilgiLbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Şifre Yöneticisi";
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıAdınıKopyalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şifreyiKopyalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem yeniKategoriEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kategoriyiSilToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label bilgiLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn related_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn related_parent_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn related_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
    }
}