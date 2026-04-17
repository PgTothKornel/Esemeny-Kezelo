using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esemény_kezelő
{
    public class gradientPanel : TableLayoutPanel
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
        public Form1()
        {
            InitializeComponent();

            bejelentkezesUI();
        }

        void bejelentkezesUI()
        {
            // controllok

            Label lbl_koszones = new Label();
            Label lbl_nev = new Label();
            Label lbl_jelszo = new Label();
            TextBox tb_nev = new TextBox();
            TextBox tb_jelszo = new TextBox();
            Button btn_bejelentkezes = new Button();
            Button btn_regisztracio = new Button();
            tb_nev.AutoSize = true;
            tb_jelszo.AutoSize = true;
            btn_bejelentkezes.AutoSize = true;
            btn_regisztracio.AutoSize = true;
            lbl_koszones.AutoSize = true;
            lbl_nev.AutoSize = true;
            lbl_jelszo.AutoSize = true;
            
            lbl_koszones.Text = "Kérlek jelentkezz be!";
            lbl_nev.Text = "Név:";
            lbl_jelszo.Text = "Jelszó:";
            btn_bejelentkezes.Text = "Bejelentkezés";
            btn_regisztracio.Text = "Regisztráció";

            tb_nev.Width = 150;
            tb_jelszo.Width = 150;
            btn_bejelentkezes.Size = new Size(200, 50);
            btn_regisztracio.Size = new Size(200, 50);

            lbl_koszones.Font = new Font("Arial", 16.0f);
            lbl_nev.Font = new Font("Arial", 16.0f);
            lbl_jelszo.Font = new Font("Arial", 16.0f);
            tb_nev.Font = new Font("Arial", 12.0f);
            tb_jelszo.Font = new Font("Arial", 12.0f);
            btn_regisztracio.Font = new Font("Arial", 16.0f);
            btn_bejelentkezes.Font = new Font("Arial", 16.0f);

            lbl_koszones.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_koszones.Width), Convert.ToInt32(Convert.ToDouble(this.Height) / 10 - lbl_koszones.Height));
            lbl_nev.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_nev.Width * 1.2), Convert.ToInt32(Convert.ToDouble(this.Height) / 2.6 - lbl_nev.Height));
            lbl_jelszo.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_jelszo.Width * 1.2), Convert.ToInt32(Convert.ToDouble(this.Height) / 3.4 - lbl_jelszo.Height));
            tb_jelszo.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 + tb_jelszo.Width * 0.1), Convert.ToInt32(Convert.ToDouble(this.Height) / 2.6 - tb_jelszo.Height));
            tb_nev.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 + tb_nev.Width * 0.1), Convert.ToInt32(Convert.ToDouble(this.Height) / 3.4 - tb_nev.Height));
            btn_bejelentkezes.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 1.5 - btn_bejelentkezes.Width * 0.5), Convert.ToInt32(Convert.ToDouble(this.Height) * 0.8));
            btn_regisztracio.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 3 - btn_regisztracio.Width * 0.5), Convert.ToInt32(Convert.ToDouble(this.Height) * 0.8));

            btn_regisztracio.Click += new EventHandler(regisztracio);

            Controls.Add(lbl_koszones);
            Controls.Add(lbl_nev);
            Controls.Add(lbl_jelszo);
            Controls.Add(tb_nev);
            Controls.Add(tb_jelszo);
            Controls.Add(btn_regisztracio);
            Controls.Add(btn_bejelentkezes);

        }

        void regisztracio(object obj, EventArgs e)
        {
            // regisztrációs cuccok (majdnem ugyanaz)

            Controls.Clear();

            Label lbl_koszones = new Label();
            Label lbl_nev = new Label();
            Label lbl_jelszo = new Label();
            TextBox tb_nev = new TextBox();
            TextBox tb_jelszo = new TextBox();
            Button btn_regisztracio = new Button();
            Button btn_vissza = new Button();
            tb_nev.AutoSize = true;
            tb_jelszo.AutoSize = true;
            btn_regisztracio.AutoSize = true;
            btn_vissza.AutoSize = true;
            lbl_koszones.AutoSize = true;
            lbl_nev.AutoSize = true;
            lbl_jelszo.AutoSize = true;

            lbl_koszones.Text = "Kérlek jelentkezz be!";
            lbl_nev.Text = "Név:";
            lbl_jelszo.Text = "Jelszó:";
            btn_regisztracio.Text = "Regisztráció";
            btn_vissza.Text = "Vissza";

            tb_nev.Width = 150;
            tb_jelszo.Width = 150;
            btn_regisztracio.Size = new Size(200, 50);
            btn_vissza.Size = new Size(200, 50);

            lbl_koszones.Font = new Font("Arial", 16.0f);
            lbl_nev.Font = new Font("Arial", 16.0f);
            lbl_jelszo.Font = new Font("Arial", 16.0f);
            tb_nev.Font = new Font("Arial", 12.0f);
            tb_jelszo.Font = new Font("Arial", 12.0f);
            btn_vissza.Font = new Font("Arial", 16.0f);
            btn_regisztracio.Font = new Font("Arial", 16.0f);

            lbl_koszones.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_koszones.Width), Convert.ToInt32(Convert.ToDouble(this.Height) / 10 - lbl_koszones.Height));
            lbl_nev.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_nev.Width * 1.2), Convert.ToInt32(Convert.ToDouble(this.Height) / 2.6 - lbl_nev.Height));
            lbl_jelszo.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 - lbl_jelszo.Width * 1.2), Convert.ToInt32(Convert.ToDouble(this.Height) / 3.4 - lbl_jelszo.Height));
            tb_jelszo.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 + tb_jelszo.Width * 0.1), Convert.ToInt32(Convert.ToDouble(this.Height) / 2.6 - tb_jelszo.Height));
            tb_nev.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 2 + tb_nev.Width * 0.1), Convert.ToInt32(Convert.ToDouble(this.Height) / 3.4 - tb_nev.Height));
            btn_regisztracio.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 1.5 - btn_regisztracio.Width * 0.5), Convert.ToInt32(Convert.ToDouble(this.Height) * 0.8));
            btn_vissza.Location = new Point(Convert.ToInt32(Convert.ToDouble(this.Width) / 3 - btn_vissza.Width * 0.5), Convert.ToInt32(Convert.ToDouble(this.Height) * 0.8));

            btn_vissza.Click += new EventHandler(vissza);
            btn_regisztracio.Click += new EventHandler(regisztralas);

            Controls.Add(lbl_koszones);
            Controls.Add(lbl_nev);
            Controls.Add(lbl_jelszo);
            Controls.Add(tb_nev);
            Controls.Add(tb_jelszo);
            Controls.Add(btn_vissza);
            Controls.Add(btn_regisztracio);
        }

        void vissza(object obj, EventArgs e)
        {
            Controls.Clear();

            bejelentkezesUI();
        }

        void regisztralas(object obj, EventArgs e)
        {
            // regisztrálás

            Controls.Clear();

            AlapUi();

            //bejelentkezesUI();
        }

        void AlapUi()
        {
            gradientPanel sidebar = new gradientPanel();
            gradientPanel header = new gradientPanel();
            Button Profile = new Button();
            Button atnezes = new Button();
            Button hozzadas = new Button();


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
            sidebar.Angle = 90;

            header.BackColor = System.Drawing.Color.CadetBlue;
            header.Dock = System.Windows.Forms.DockStyle.Top;
            header.Location = new System.Drawing.Point(0, 0);
            header.Name = "panel3";
            header.Size = new System.Drawing.Size(this.Width, Convert.ToInt32(this.Height * 0.1));
            header.ColumnCount = 1;
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            header.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            header.RowCount = 1;
            header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            header.color1 = Color.GreenYellow;
            header.color2 = Color.White;

            Profile.Text = "PlaceHolder";
            Profile.Image = null;
            Profile.ImageAlign = ContentAlignment.MiddleRight;
            Profile.TextAlign = ContentAlignment.MiddleLeft;
            Profile.Size = new Size(Convert.ToInt32(header.Width * 0.3), header.Height);
            Profile.TextImageRelation = TextImageRelation.TextBeforeImage;


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
            header.Controls.Add(Profile);
            sidebar.Controls.Add(atnezes);
            sidebar.Controls.Add(hozzadas);
            Controls.Add(tarto);

            tarto.Controls.Clear();
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
