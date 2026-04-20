using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esemény_kezelő
{
    public partial class Atnezes : Form
    {
        public Atnezes()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void Atnezes_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Esemény", "Esemény");
            dataGridView1.Columns.Add("Dátum", "Dátum");
            dataGridView1.Columns.Add("Leírás", "Leírás");
            dataGridView1.Columns.Add("Tervező", "Tervező");
            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=mysql;database=school_events"))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand("S")) {

                dataGridView1.Rows.Add("");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = false;
        }
    }
}
