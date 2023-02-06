using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FestivalVelenje3
{
    public partial class Zasedbe : Form
    {
        public Zasedbe()
        {
            InitializeComponent();
        }

        private void Zasedbe_Load(object sender, EventArgs e)
        {
            Barve.Setbarva();
            BackColor = Color.FromArgb(Barve.Rgb1, Barve.Rgb2, Barve.Rgb3);
            NpgsqlConnection conn = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM vrnipredstave();", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1].ToString());
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string izbranaPredstava = comboBox1.SelectedItem.ToString();
            igralciListView.Items.Clear();
            igralciListView.Visible = true;
            NpgsqlConnection conn = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM vrnizasedbe(@izbranapredstava)", conn);
            cmd.Parameters.AddWithValue("@izbranapredstava", izbranaPredstava);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[3].ToString());
                igralciListView.Items.Add(item);
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
