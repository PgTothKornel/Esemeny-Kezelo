using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Esemény_kezelő
{
    public partial class Atnezes : Form
    {
        public List<string> leirasok = new List<string>(), nevek = new List<string>(), keszitok = new List<string>(), datumok = new List<string>(), kategoriak = new List<string>(), helyek = new List<string>();
        int index = 0;
        public Atnezes()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void Atnezes_Load(object sender, EventArgs e)
        {
            if (!Form1.admin)
            {
                richTextBox1.ReadOnly = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                button3.Visible = false;
            }

            button3.Click += new EventHandler(mentes);

            dataGridView1.Columns.Add("Esemény", "Esemény");
            dataGridView1.Columns.Add("Dátum", "Dátum");
            dataGridView1.Columns.Add("Leírás", "Leírás");
            dataGridView1.Columns.Add("Tervező", "Tervező");
            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var cmd = new MySqlCommand("SELECT name, date, description, users.username, categories.category, locations.location FROM events INNER JOIN users ON created_by_id = users.id INNER JOIN categories on categories.id = category_id INNER JOIN locations on locations.id = location_id;", conn)) 
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nev = reader.GetValue(0).ToString();
                            string datum = reader.GetValue(1).ToString();
                            string leiras = reader.GetValue(2).ToString();
                            string keszito = reader.GetValue(3).ToString();
                            string kategoria = reader.GetValue(4).ToString();
                            string hely = reader.GetValue(5).ToString();
                            dataGridView1.Rows.Add(nev, datum, leiras, keszito);
                            nevek.Add(nev);
                            datumok.Add(datum);
                            leirasok.Add(leiras);
                            keszitok.Add(keszito);
                            kategoriak.Add(kategoria);
                            helyek.Add(hely);
                        }
                    }
                }

            }

            button1.Click += new EventHandler(balra);
            button2.Click += new EventHandler(balra);
        }

        void mentes(object obj, EventArgs e)
        {
            string nev = textBox1.Text;
            string datum = textBox2.Text;
            string leiras = richTextBox1.Text;
            string keszito = textBox3.Text;
            string kategoria = textBox4.Text;
            string hely = textBox5.Text;

            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var command = new MySqlCommand($"UPDATE events SET events.name = \'{nev}\', events.date = \'{datum}\', events.category_id = {kategoria}, events.location_id = {hely}, events.description = \'{leiras}\' WHERE events.name LIKE \'{nevek[index]}\';"))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (e.RowIndex < 0) { return; }

            textBox1.Text = nevek[e.RowIndex];
            textBox2.Text = datumok[e.RowIndex];

            richTextBox1.Text = leirasok[e.RowIndex];

            textBox3.Text = keszitok[e.RowIndex];
            textBox4.Text = kategoriak[e.RowIndex];
            textBox5.Text = helyek[e.RowIndex];

            //MessageBox.Show(dataGridView1.selected)

            panel1.Visible = false;
            dataGridView1.Visible = false;
        }

        void balra(object obj, EventArgs e)
        {
            index--;
            if (index == -1) index = dataGridView1.RowCount - 2;

            textBox1.Text = nevek[index];
            textBox2.Text = datumok[index];

            richTextBox1.Text = leirasok[index];

            textBox3.Text = keszitok[index];
            textBox4.Text = kategoriak[index];
            textBox5.Text = helyek[index];
        }
        void jobbra(object obj, EventArgs e)
        {
            index++;
            if (index == dataGridView1.RowCount) index = 0;

            textBox1.Text = nevek[index];
            textBox2.Text = datumok[index];

            richTextBox1.Text = leirasok[index];

            textBox3.Text = keszitok[index];
            textBox4.Text = kategoriak[index];
            textBox5.Text = helyek[index];
        }
    }
}
