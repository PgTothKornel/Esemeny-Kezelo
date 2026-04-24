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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Esemény_kezelő
{
    public partial class Atnezes : Form
    {
        public List<string> leirasok = new List<string>(), nevek = new List<string>(), keszitok = new List<string>(), datumok = new List<string>(), kategoriak = new List<string>(), helyek = new List<string>(), jelentkezesek = new List<string>(), kategoriakOssz = new List<string>(), helyekOssz = new List<string>();
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
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button3.Visible = false;
                button4.Visible = false;
            }
            else
            {
                //MessageBox.Show(Form1.admin.ToString());
                richTextBox1.ReadOnly = false;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                button3.Visible = true;
                button4.Visible = true;
            }
            textBox3.ReadOnly = true;
            label4.Visible = false;

            button3.Click += new EventHandler(mentes);
            button4.Click += new EventHandler(torol);
            btn_jelentkezes.Click += new EventHandler(jelentkez);

            dataGridView1.Columns.Add("Esemény", "Esemény");
            dataGridView1.Columns.Add("Dátum", "Dátum");
            dataGridView1.Columns.Add("Leírás", "Leírás");
            dataGridView1.Columns.Add("Tervező", "Tervező");

            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var cmd = new MySqlCommand($"SELECT * FROM participants WHERE participants.participant_id = {Form1.index};", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string szam = reader.GetValue(2).ToString();
                            jelentkezesek.Add(szam);
                        }
                    }
                }


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

                using (var cmd = new MySqlCommand("SELECT categories.category, locations.location FROM categories, locations;", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) {
                            string kategoria = (string)reader.GetValue(0);
                            string hely = (string)reader.GetValue(1);
                            if (!kategoriakOssz.Contains(kategoria)) { kategoriakOssz.Add(kategoria); }
                            if (!helyekOssz.Contains(hely)) { helyekOssz.Add(hely); }
                        }
                    }
                }
            }

            kategoriakOssz.Reverse();

            button1.Click += new EventHandler(balra);
            button2.Click += new EventHandler(jobbra);

            comboBox1.Items.AddRange(kategoriakOssz.ToArray());
            comboBox2.Items.AddRange(helyekOssz.ToArray());
        }

        void mentes(object obj, EventArgs e)
        {
            string nev = textBox1.Text;
            string datum = textBox2.Text;
            string leiras = richTextBox1.Text;
            string kategoria = (comboBox1.SelectedIndex + 1).ToString();
            string hely = (comboBox2.SelectedIndex + 1).ToString();

            if (nev.StartsWith(" ") || nev.StartsWith("\t") || int.TryParse(nev, out int result1) == true)
            {
                MessageBox.Show("Kérem egy rendes nevet adjon meg!");
                return;
            }
            else if (leiras.StartsWith(" ") || int.TryParse(nev, out int result2) == true)
            {
                MessageBox.Show("Kérem egy rendes leírást adjon meg!");
                return;
            }

            if (DateTime.TryParse(datum, out DateTime result) == false) { MessageBox.Show("Kérem helyes dátumot adjon meg!"); return; };

            datum = DateTime.Parse(datum).ToString("yyyy-MM-dd HH:mm:ss");

            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var command = new MySqlCommand($"UPDATE events SET events.name = \'{nev}\', events.date = \'{datum}\', events.category_id = {kategoria}, events.location_id = {hely}, events.description = \'{leiras}\' WHERE events.name LIKE \'{nevek[index]}\';", conn))
                {
                    command.ExecuteNonQuery();
                    nevek[index] = nev;
                    datumok[index] = datum;
                    leirasok[index] = leiras;
                    kategoriak[index] = kategoria;
                    helyek[index] = hely;
                    nevek[index] = nev;
                }
            }
        }

        void torol(object obj, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Biztos ki akarod ezt az eseményt törölni?", "Törlés", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }

            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var cmd = new MySqlCommand($"DELETE FROM participants WHERE participants.event_id = {index + 1};", conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand($"DELETE FROM events WHERE id = {index + 1};", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        void jelentkez(object obj, EventArgs e)
        {
            string szam = "0";

            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var cmd = new MySqlCommand($"SELECT * FROM events WHERE events.name LIKE '{nevek[index]}';", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            szam = reader.GetValue(0).ToString();
                        }
                    }
                }


                if (btn_jelentkezes.Text == "Jelentkezés") {

                    using (var cmd = new MySqlCommand($"INSERT INTO participants VALUES(0, \'{Form1.index}\', \'{szam}\');", conn))
                    {
                        cmd.ExecuteNonQuery();
                        btn_jelentkezes.Text = "Lemondás";
                    }
                }
                else
                {
                    using (var cmd = new MySqlCommand($"DELETE FROM participants WHERE participants.event_id = {szam} AND participants.participant_id = {Form1.index};", conn))
                    {
                        cmd.ExecuteNonQuery();
                        btn_jelentkezes.Text = "Jelentkezés";
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.RowCount - 1) { return; }

            btn_jelentkezes.Text = "Jelentkezés";


            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var cmd = new MySqlCommand($"SELECT participants.participant_id, participants.event_id, events.name FROM participants INNER JOIN events ON events.id = participants.event_id WHERE participants.participant_id = {Form1.index};", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) {
                            if (reader.GetValue(2).ToString() == nevek[index])
                            {
                                btn_jelentkezes.Text = "Lemondás";
                            }
                        }
                    }
                }
            }


            textBox1.Text = nevek[e.RowIndex];
            textBox2.Text = datumok[e.RowIndex];

            richTextBox1.Text = leirasok[e.RowIndex];

            textBox3.Text = keszitok[e.RowIndex];

            for (int j = 0; j < kategoriakOssz.Count; j++)
            {
                if (kategoriakOssz[j] == kategoriak[index])
                {
                    comboBox1.SelectedIndex = j; break;
                }
            }
            for (int j = 0; j < helyekOssz.Count; j++)
            {
                if (helyekOssz[j] == helyek[index])
                {
                    comboBox2.SelectedIndex = j; break;
                }
            }

            //MessageBox.Show(dataGridView1.selected)

            if (!Form1.admin && Form1.nev != textBox3.Text)
            {
                richTextBox1.ReadOnly = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button3.Visible = false;
                button4.Visible = false;
                label4.Visible = false;
            }
            else 
            {
                richTextBox1.ReadOnly = false;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                button3.Visible = true;
                label4.Visible = true;
                button4.Visible = true;
            }

            panel1.Visible = false;
            dataGridView1.Visible = false;
        }

        void balra(object obj, EventArgs e)
        {
            

            index--;
            if (index == -1) { index = dataGridView1.RowCount - 2; }

            btn_jelentkezes.Text = "Jelentkezés";

            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var cmd = new MySqlCommand($"SELECT participants.participant_id, participants.event_id, events.name FROM participants INNER JOIN events ON events.id = participants.event_id WHERE participants.participant_id = {Form1.index};", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(2).ToString() == nevek[index])
                            {
                                btn_jelentkezes.Text = "Lemondás";
                            }
                        }
                    }
                }
            }

            textBox1.Text = nevek[index];
            textBox2.Text = datumok[index];

            richTextBox1.Text = leirasok[index];

            textBox3.Text = keszitok[index];

            for (int j = 0; j < kategoriakOssz.Count; j++)
            {
                if (kategoriakOssz[j] == kategoriak[index])
                {
                    comboBox1.SelectedIndex = j; break;
                }
            }
            for (int j = 0; j < helyekOssz.Count; j++)
            {
                if (helyekOssz[j] == helyek[index])
                {
                    comboBox2.SelectedIndex = j; break;
                }
            }

            if (!Form1.admin && Form1.nev != textBox3.Text)
            {
                richTextBox1.ReadOnly = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button3.Visible = false;
                button4.Visible = false;
                label4.Visible = false;
            }
            else
            {
                richTextBox1.ReadOnly = false;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                button3.Visible = true;
                button4.Visible = true;
                label4.Visible = true;
            }
        }
        void jobbra(object obj, EventArgs e)
        {
            

            index++;
            if (index == dataGridView1.RowCount - 1) { index = 0; }

            btn_jelentkezes.Text = "Jelentkezés";

            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var cmd = new MySqlCommand($"SELECT participants.participant_id, participants.event_id, events.name FROM participants INNER JOIN events ON events.id = participants.event_id WHERE participants.participant_id = {Form1.index};", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(2).ToString() == nevek[index])
                            {
                                btn_jelentkezes.Text = "Lemondás";
                            }
                        }
                    }
                }
            }

            textBox1.Text = nevek[index];
            textBox2.Text = datumok[index];

            richTextBox1.Text = leirasok[index];

            textBox3.Text = keszitok[index];

            for (int j = 0; j < kategoriakOssz.Count; j++)
            {
                if (kategoriakOssz[j] == kategoriak[index])
                {
                    comboBox1.SelectedIndex = j; break;
                }
            }
            for (int j = 0; j < helyekOssz.Count; j++)
            {
                if (helyekOssz[j] == helyek[index])
                {
                    comboBox2.SelectedIndex = j; break;
                }
            }

            if (!Form1.admin && Form1.nev != textBox3.Text)
            {
                richTextBox1.ReadOnly = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button3.Visible = false;
                button4.Visible = false;
                label4.Visible = false;
            }
            else
            {
                richTextBox1.ReadOnly = false;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                button3.Visible = true;
                button4.Visible = true;
                label4.Visible = true;
            }
        }
    }
}
