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
    public partial class UrejajZasedbe : Form
    {
        string idi;
        public UrejajZasedbe()
        {
            InitializeComponent();
        }

        private void UrejajZasedbe_Load(object sender, EventArgs e)
        {
            Barve.Setbarva();
            BackColor = Color.FromArgb(Barve.Rgb1, Barve.Rgb2, Barve.Rgb3);
            NpgsqlConnection con = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM vsiigralci()", con);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(Convert.ToInt32(dr[0]).ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                igralciListView.Items.Add(item);
            }
            dr.Close();
            cmd.Dispose();
            NpgsqlCommand cmd2 = new NpgsqlCommand("SELECT * FROM vrnipredstave()", con);
            NpgsqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[1].ToString() +" - " + dr2[0].ToString());
            }
            dr2.Close();
            cmd2.Dispose();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            idi = comboBox1.Text;
            idi = idi.Substring(idi.IndexOf("-") + 2);
            NpgsqlConnection conn = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT igralecvzasedbo(@idi, @idp)", conn);
            cmd.Parameters.AddWithValue("@idi", Convert.ToInt32(igralciListView.SelectedItems[0].Text));
            cmd.Parameters.AddWithValue("@idp", Convert.ToInt32(idi));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Igralec je bil dodan v zasedbo.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
