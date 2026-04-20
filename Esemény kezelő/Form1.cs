using BCrypt;
using BCrypt.Net;
using Esemény_kezelő.Properties;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esemény_kezelő
{
    public class gradientLayoutPanel : TableLayoutPanel
    {
        public Color color1 { get; set; }
        public Color color2 { get; set; }
        public float Angle { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this.color1, this.color2, this.Angle);
            Graphics g = e.Graphics;
            g.FillRectangle(brush, this.ClientRectangle);
            base.OnPaint(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
    public class gradientMenu: MenuStrip
    {
        public Color color1 { get; set; }
        public Color color2 { get; set; }
        public float Angle { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this.color1, this.color2, this.Angle);
            Graphics g = e.Graphics;
            g.FillRectangle(brush, this.ClientRectangle);
            base.OnPaint(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

    public class gradientPanel : Panel
    {
        public Color color1 { get; set; }
        public Color color2 { get; set; }
        public float Angle { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this.color1, this.color2, this.Angle);
            Graphics g = e.Graphics;
            g.FillRectangle(brush, this.ClientRectangle);
            base.OnPaint(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
    public partial class Form1 : Form
    {
        static Panel tarto = new Panel();
        static TextBox tb_nev = new TextBox();
        static TextBox tb_jelszo = new TextBox();
        public static string nev = "";
        public Form1()
        {
            InitializeComponent();

            bool kell = true;

            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;"))
            {
                conn.Open();

                using (var check = new MySqlCommand("SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA;", conn))

                using (var reader = check.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetValue(0).ToString() == "school_events")
                        {
                            kell = false;
                        }
                        //MessageBox.Show(reader.GetValue(0).ToString());
                    }
                }

                if (kell) { 
                using (var command = new MySqlCommand("DROP DATABASE IF EXISTS school_events;CREATE DATABASE if not EXISTS school_events;", conn))
                {
                    command.ExecuteNonQuery();
                }
                }
            }

            if (kell) { 
            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(File.ReadAllText("database.sql"),conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            }
            bejelentkezesUI();
        }

        void bejelentkezesUI()
        {
            // controllok
            gradientPanel hatter = new gradientPanel();
            Label lbl_koszones = new Label();
            Label lbl_nev = new Label();
            Label lbl_jelszo = new Label();
            tb_nev = new TextBox();
            tb_jelszo = new TextBox();
            Button btn_bejelentkezes = new Button();
            Button btn_regisztracio = new Button();
            tb_nev.AutoSize = true;
            tb_jelszo.AutoSize = true;
            btn_bejelentkezes.AutoSize = true;
            btn_regisztracio.AutoSize = true;
            lbl_koszones.AutoSize = true;
            lbl_nev.AutoSize = true;
            lbl_jelszo.AutoSize = true;

            tb_jelszo.PasswordChar = '*';

            lbl_koszones.Text = "Kérlek jelentkezz be!";
            lbl_nev.Text = "Név:";
            lbl_jelszo.Text = "Jelszó:";
            btn_bejelentkezes.Text = "Bejelentkezés";
            btn_regisztracio.Text = "Regisztráció";

            tb_nev.Width = 150;
            tb_jelszo.Width = 150;
            btn_bejelentkezes.Size = new Size(200, 50);
            btn_regisztracio.Size = new Size(200, 50);

            lbl_jelszo.BackColor = Color.Transparent;
            lbl_nev.BackColor = Color.Transparent;
            lbl_koszones.BackColor = Color.Transparent;

            lbl_koszones.Font = new Font("Candara", 20.0f);
            lbl_nev.Font = new Font("Candara", 20.0f);
            lbl_jelszo.Font = new Font("Candara", 20.0f);
            tb_nev.Font = new Font("Arial", 12.0f);
            tb_jelszo.Font = new Font("Arial", 12.0f);
            btn_regisztracio.Font = new Font("Arial", 16.0f);
            btn_bejelentkezes.Font = new Font("Arial", 16.0f);

            lbl_koszones.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_koszones.Width), Convert.ToInt32(Convert.ToDouble(this.Height) / 10 - lbl_koszones.Height));
            lbl_jelszo.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_nev.Width * 1.2), Convert.ToInt32(Convert.ToDouble(this.Height) / 2.7 - lbl_nev.Height));
            lbl_nev.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_jelszo.Width * 1.2), Convert.ToInt32(Convert.ToDouble(this.Height) / 3.6 - lbl_jelszo.Height));
            tb_jelszo.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 + tb_jelszo.Width * 0.1), Convert.ToInt32(Convert.ToDouble(this.Height) / 2.6 - tb_jelszo.Height));
            tb_nev.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 + tb_nev.Width * 0.1), Convert.ToInt32(Convert.ToDouble(this.Height) / 3.4 - tb_nev.Height));
            btn_regisztracio.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 1.5 - btn_bejelentkezes.Width * 0.5), Convert.ToInt32(Convert.ToDouble(this.Height) * 0.8));
            btn_bejelentkezes.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 3 - btn_regisztracio.Width * 0.5), Convert.ToInt32(Convert.ToDouble(this.Height) * 0.8));

            btn_regisztracio.Click += new EventHandler(regisztracio);
            btn_bejelentkezes.Click += new EventHandler(bejelentkezes);

            btn_regisztracio.FlatStyle = FlatStyle.Flat;
            btn_bejelentkezes.FlatStyle = FlatStyle.Flat;

            hatter.color1 = Color.GreenYellow;
            hatter.color2 = Color.White;
            hatter.Angle = 75;
            hatter.Dock = DockStyle.Fill;

            hatter.Controls.Add(lbl_koszones);
            hatter.Controls.Add(lbl_nev);
            hatter.Controls.Add(lbl_jelszo);
            hatter.Controls.Add(tb_nev);
            hatter.Controls.Add(tb_jelszo);
            hatter.Controls.Add(btn_regisztracio);
            hatter.Controls.Add(btn_bejelentkezes);
            Controls.Add(hatter);
        }

        void bejelentkezes(object obj, EventArgs e)
        {
            if (tb_nev.Text == string.Empty)
            {
                MessageBox.Show("Kérem adjon meg egy nevet!" + " " + tb_nev.Text);
                return;
            }
            else if (tb_jelszo.Text == string.Empty)
            {
                MessageBox.Show("Kérem adja meg a jelszavát!");
                return;
            }
                using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
                {
                    conn.Open();

                    string jelszo = tb_jelszo.Text;
                    string hashed = "";

                    using (var command = new MySqlCommand($"SELECT * FROM users WHERE users.username LIKE \"{tb_nev.Text}\";", conn))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                hashed = reader.GetString(2);
                            }
                        }
                    }

                nev = tb_nev.Text;

                if (BCrypt.Net.BCrypt.Verify(jelszo, hashed))
                    {
                        Controls.Clear();
                        AlapUi();
                    }
                }
        }

        void regisztracio(object obj, EventArgs e)
        {
            // regisztrációs cuccok (majdnem ugyanaz)

            Controls.Clear();

            gradientPanel hatter = new gradientPanel();
            Label lbl_koszones = new Label();
            Label lbl_nev = new Label();
            Label lbl_jelszo = new Label();
            tb_nev = new TextBox();
            tb_jelszo = new TextBox();
            Button btn_regisztracio = new Button();
            Button btn_vissza = new Button();
            tb_nev.AutoSize = true;
            tb_jelszo.AutoSize = true;
            btn_regisztracio.AutoSize = true;
            btn_vissza.AutoSize = true;
            lbl_koszones.AutoSize = true;
            lbl_nev.AutoSize = true;
            lbl_jelszo.AutoSize = true;

            tb_jelszo.PasswordChar = '*';

            lbl_koszones.Text = "Kérlek regisztrálj!";
            lbl_nev.Text = "Név:";
            lbl_jelszo.Text = "Jelszó:";
            btn_regisztracio.Text = "Regisztráció";
            btn_vissza.Text = "Vissza";

            tb_nev.Width = 150;
            tb_jelszo.Width = 150;
            btn_regisztracio.Size = new Size(200, 50);
            btn_vissza.Size = new Size(200, 50);

            lbl_jelszo.BackColor = Color.Transparent;
            lbl_nev.BackColor = Color.Transparent;
            lbl_koszones.BackColor = Color.Transparent;

            lbl_koszones.Font = new Font("Candara", 20.0f);
            lbl_nev.Font = new Font("Candara", 20.0f);
            lbl_jelszo.Font = new Font("Candara", 20.0f);
            tb_nev.Font = new Font("Arial", 12.0f);
            tb_jelszo.Font = new Font("Arial", 12.0f);
            btn_vissza.Font = new Font("Arial", 16.0f);
            btn_regisztracio.Font = new Font("Arial", 16.0f);

            btn_regisztracio.FlatStyle = FlatStyle.Flat;
            btn_vissza.FlatStyle = FlatStyle.Flat;

            lbl_koszones.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_koszones.Width), Convert.ToInt32(Convert.ToDouble(this.Height) / 10 - lbl_koszones.Height));
            lbl_jelszo.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_nev.Width * 1.2), Convert.ToInt32(Convert.ToDouble(this.Height) / 2.7 - lbl_nev.Height));
            lbl_nev.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_jelszo.Width * 1.2), Convert.ToInt32(Convert.ToDouble(this.Height) / 3.6 - lbl_jelszo.Height));
            tb_jelszo.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 + tb_jelszo.Width * 0.1), Convert.ToInt32(Convert.ToDouble(this.Height) / 2.6 - tb_jelszo.Height));
            tb_nev.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 + tb_nev.Width * 0.1), Convert.ToInt32(Convert.ToDouble(this.Height) / 3.4 - tb_nev.Height));
            btn_regisztracio.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 1.5 - btn_regisztracio.Width * 0.5), Convert.ToInt32(Convert.ToDouble(this.Height) * 0.8));
            btn_vissza.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 3 - btn_vissza.Width * 0.5), Convert.ToInt32(Convert.ToDouble(this.Height) * 0.8));

            btn_vissza.Click += new EventHandler(vissza);
            btn_regisztracio.Click += new EventHandler(regisztralas);

            hatter.color1 = Color.GreenYellow;
            hatter.color2 = Color.White;
            hatter.Angle = 75;
            hatter.Dock = DockStyle.Fill;

            hatter.Controls.Add(lbl_koszones);
            hatter.Controls.Add(lbl_nev);
            hatter.Controls.Add(lbl_jelszo);
            hatter.Controls.Add(tb_nev);
            hatter.Controls.Add(tb_jelszo);
            hatter.Controls.Add(btn_vissza);
            hatter.Controls.Add(btn_regisztracio);
            Controls.Add(hatter);
        }

        void vissza(object obj, EventArgs e)
        {
            Controls.Clear();

            bejelentkezesUI();
        }

        void regisztralas(object obj, EventArgs e)
        {
            // regisztrálás

            if (tb_nev.Text == string.Empty)
            {
                MessageBox.Show("Kérem adjon meg egy nevet!" + " " + tb_nev.Text);
                return;
            }
            else if (tb_jelszo.Text == string.Empty)
            {
                MessageBox.Show("Kérem adja meg a jelszavát!");
                return;
            }
            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                nev = tb_nev.Text;

                using (var command = new MySqlCommand($"SELECT * FROM users;", conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (nev == reader.GetValue(1).ToString())
                            {
                                MessageBox.Show("Kérem válasszon másik felhasználónevet, ez már foglalt!");
                                return;
                            }
                        }
                    }
                }

                //MessageBox.Show(BCrypt.Net.BCrypt.HashPassword(tb_jelszo.Text));

                
            }

            using (var conn = new MySqlConnection("server = 127.0.0.1; uid = root; pwd = mysql; database = school_events"))
            {
                conn.Open();

                string jelszo = BCrypt.Net.BCrypt.HashPassword(tb_jelszo.Text, BCrypt.Net.BCrypt.GenerateSalt());

                using (var cmd = new MySqlCommand($"INSERT INTO users VALUES(0, \'{nev}\', \'{jelszo}\', 0);", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
              
            AlapUi();
        }

        void AlapUi()
        {
            Controls.Clear();

            gradientLayoutPanel sidebar = new gradientLayoutPanel();
            gradientMenu header = new gradientMenu();
            Button atnezes = new Button();
            Button hozzadas = new Button();
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            ToolStripMenuItem kijelentkezes = new ToolStripMenuItem();

            sidebar.BackColor = System.Drawing.Color.CadetBlue;
            sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            sidebar.Location = new System.Drawing.Point(0, 0);
            sidebar.Name = "panel1";
            sidebar.Size = new System.Drawing.Size(Convert.ToInt32(this.Width * 0.2), this.Height);
            sidebar.ColumnCount = 1;
            sidebar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            sidebar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            sidebar.RowCount = 3;
            sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            sidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            sidebar.color1 = Color.GreenYellow;
            sidebar.color2 = Color.White;
            sidebar.Angle = 60;

            header.color1 = Color.GreenYellow;
            header.color2 = Color.White;
            header.Angle = 20;
            header.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuItem});
            header.Location = new System.Drawing.Point(0, 0);
            header.Name = "menuStrip1";
            header.Size = new System.Drawing.Size(533, 36);
            header.TabIndex = 0;
            header.Text = "menuStrip1";

            menuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            menuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            kijelentkezes});
            menuItem.Font = new System.Drawing.Font("Segoe UI", 15F);
            menuItem.Image = Image.FromFile("profil.jpg");
            menuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            menuItem.Name = "toolStripMenuItem1";
            menuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            menuItem.Size = new System.Drawing.Size(75, 32);
            menuItem.Text = nev;
            menuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;

            kijelentkezes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            kijelentkezes.Name = "kijelentkezésToolStripMenuItem";
            kijelentkezes.Size = new System.Drawing.Size(196, 32);
            kijelentkezes.Text = "Kijelentkezés";
            kijelentkezes.Click += new System.EventHandler(kijelentkezesGomb);

            atnezes.Text = "Események nézése";
            atnezes.Size = new Size(sidebar.Width, Convert.ToInt32(sidebar.Height * 0.1));
            atnezes.FlatStyle = FlatStyle.Flat;
            atnezes.Dock = DockStyle.Top;
            atnezes.BackColor = Color.LightBlue;
            atnezes.Click += new EventHandler(atnezesForm);

            hozzadas.Text = "Esemény hozzáadása";
            hozzadas.Size = new Size(sidebar.Width, Convert.ToInt32(sidebar.Height * 0.1));
            hozzadas.FlatStyle = FlatStyle.Flat;
            hozzadas.Dock = DockStyle.Top;
            hozzadas.BackColor = Color.LightBlue;
            hozzadas.Click += new EventHandler(hozzadasForm);

            tarto.Dock = DockStyle.Fill;
            tarto.BackColor = Color.LightBlue;

            Controls.Add(header);
            Controls.Add(sidebar);
            sidebar.Controls.Add(atnezes);
            sidebar.Controls.Add(hozzadas);
            Controls.Add(tarto);

            tarto.Controls.Clear();
        }

        void kijelentkezesGomb(object obj, EventArgs e)
        {
            Controls.Clear();

            bejelentkezesUI();
        }

        void atnezesForm(object obj, EventArgs e)
        {
            Form atnezes = new Atnezes();
            atnezes.TopLevel = false;

            tarto.Controls.Clear();
            tarto.Controls.Add(atnezes);
            atnezes.BringToFront();
            atnezes.Show();
        }

        void hozzadasForm(object obj, EventArgs e)
        {
            Form hozzadas = new Hozzadas();
            hozzadas.TopLevel = false;

            tarto.Controls.Clear();
            tarto.Controls.Add(hozzadas);
            hozzadas.BringToFront();
            hozzadas.Show();
        }
    }
}
