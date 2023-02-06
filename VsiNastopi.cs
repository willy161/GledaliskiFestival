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
    public partial class VsiNastopi : Form
    {
        public void refresh()
        {
            predstavitveListView.Items.Clear();
            NpgsqlConnection con = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM vsepredstave()", con);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string x;
                ListViewItem item = new ListViewItem(Convert.ToInt32(dr[0]).ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(Convert.ToInt32(dr[2]).ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                if (dr[6].ToString().Length==19)
                {
                    x = dr[6].ToString().Substring(0, dr[6].ToString().Length - 3);
                }
                else
                {
                    x = dr[6].ToString();
                }
                item.SubItems.Add(dr[5].ToString());
                item.SubItems.Add(x);
                predstavitveListView.Items.Add(item);
            }
            con.Close();
        }
        public VsiNastopi()
        {
            InitializeComponent();
        }

        private void VsePredstave_Load(object sender, EventArgs e)
        {
            Barve.Setbarva();
            BackColor = Color.FromArgb(Barve.Rgb1, Barve.Rgb2, Barve.Rgb3);
            refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT izbrisinastop(@id)", con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(predstavitveListView.SelectedItems[0].SubItems[0].Text));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodajajNastope dodajajNastop = new DodajajNastope();
            this.Close();
            dodajajNastop.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
