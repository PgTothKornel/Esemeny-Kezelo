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

        private void Hozzadas_Load(object sender, EventArgs e)
        {
            string connstring = "server=127.0.0.1;uid=root;pwd=mysql;database=school_events";
            string sql = "SELECT categories.category FROM categories;";
            
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


        }
    }
}
