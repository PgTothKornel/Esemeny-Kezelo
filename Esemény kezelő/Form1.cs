using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esemény_kezelő
{
    public partial class Form1 : Form
    {
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

            bejelentkezesUI();
        }
    }
}
