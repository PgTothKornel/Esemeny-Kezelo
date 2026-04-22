using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esemény_kezelő
{
    public partial class Hozzadas : Form
    {
        public Hozzadas()
        {
            InitializeComponent();
        }

        public static string connstring = "server=127.0.0.1;uid=root;pwd=mysql;database=school_events";
        private void Hozzadas_Load(object sender, EventArgs e)
        {
            string sql = "SELECT categories.category FROM categories;";

            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            cb_kategoria.Items.Clear();
            cb_kategoria.Items.Add("");
            cb_kategoria.SelectedIndex = 0;
            cb_helyszin.Items.Clear();
            cb_helyszin.Items.Add("");
            cb_helyszin.SelectedIndex = 0;
            using (var conn = new MySqlConnection(connstring))
            {
                conn.Open();   
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cb_kategoria.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }

            sql = "SELECT locations.location FROM locations;";
            using (var conn = new MySqlConnection(connstring))
            {
                conn.Open();   
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cb_helyszin.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }


        }

        private void tb_torol_Click(object sender, EventArgs e)
        {
            tb_nev.Text = "";
            rtb_leriras.Text = "";
            cb_kategoria.SelectedIndex = 0;
            cb_helyszin.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btn_hozzaad_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT users.id FROM users WHERE";


            sql = $"INSERT INTO events (name, date, category_id, location_id, description, created_by_id, created_date) VALUES(\'{tb_nev.Text}\', \'{dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")}\', \'{cb_kategoria.SelectedIndex}\', \'{cb_helyszin.SelectedIndex}\', \'{rtb_leriras.Text}\', \'{Form1.index}\', \'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\') ";

            using (var conn = new MySqlConnection(connstring))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }

        private void tb_nev_TextChanged(object sender, EventArgs e)
        {
            if (tb_nev.Text == "" || rtb_leriras.Text == "" || cb_kategoria.SelectedIndex == 0 || cb_helyszin.SelectedIndex == 0)
                btn_hozzaad.Enabled = false;
            else
                btn_hozzaad.Enabled = true;
        }

        private void rtb_leriras_TextChanged(object sender, EventArgs e)
        {
            if (tb_nev.Text == "" || rtb_leriras.Text == "" || cb_kategoria.SelectedIndex == 0 || cb_helyszin.SelectedIndex == 0)
                btn_hozzaad.Enabled = false;
            else
                btn_hozzaad.Enabled = true;
        }

        private void cb_kategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tb_nev.Text == "" || rtb_leriras.Text == "" || cb_kategoria.SelectedIndex == 0 || cb_helyszin.SelectedIndex == 0)
                btn_hozzaad.Enabled = false;
            else
                btn_hozzaad.Enabled = true;
        }

        private void cb_helyszin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tb_nev.Text == "" || rtb_leriras.Text == "" || cb_kategoria.SelectedIndex == 0 || cb_helyszin.SelectedIndex == 0)
                btn_hozzaad.Enabled = false;
            else
                btn_hozzaad.Enabled = true;
        }
    }
}
