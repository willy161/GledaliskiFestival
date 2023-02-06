using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace FestivalVelenje3
{
    public partial class Arhiv : Form
    {
        public Arhiv()
        {
            InitializeComponent();
        }

        private void Arhiv_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM arhivnastopov()", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                item.SubItems.Add(dr[5].ToString());
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
