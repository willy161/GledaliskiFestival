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
    public partial class DodajajNastope : Form
    {
        DateTime datumnastop;
        string idp, idg;
        public DodajajNastope()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                idp = comboBox1.Text;
                idp = idp.Substring(idp.IndexOf("-") + 2);
                idg = comboBox2.Text;
                idg = idg.Substring(idg.IndexOf("-") + 2);
                datumnastop = dateTimePicker1.Value;
                NpgsqlConnection conn = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT dodajnastop(@idp, @idg, @datum)", conn);
                cmd.Parameters.AddWithValue("@idp", Convert.ToInt32(idp));
                cmd.Parameters.AddWithValue("@idg", Convert.ToInt32(idg));
                cmd.Parameters.AddWithValue("@datum", datumnastop);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Uspešno dodan");
                conn.Close();
                VsiNastopi vsePredstavitve = new VsiNastopi();
                vsePredstavitve.refresh();
                vsePredstavitve.Show();
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DodajajNastope_Load(object sender, EventArgs e)
        {
            Barve.Setbarva();
            BackColor = Color.FromArgb(Barve.Rgb1, Barve.Rgb2, Barve.Rgb3);
            NpgsqlConnection con = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM vrnipredstave()", con);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1].ToString() + " - " + dr[0].ToString());
            }
            dr.Close();
            cmd.Dispose();
            NpgsqlCommand cmd2 = new NpgsqlCommand("SELECT * FROM vrnigledalisca()", con);
            NpgsqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2[1].ToString() + " - " + dr2[0].ToString());
            }
            dr2.Close();
            cmd2.Dispose();
            con.Close();
        }
    }
}
