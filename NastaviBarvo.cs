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
    public partial class NastaviBarvo : Form
    {
        public NastaviBarvo()
        {
            InitializeComponent();
        }

        private void NastaviBarvo_Load(object sender, EventArgs e)
        {
            Barve.Setbarva();
            BackColor = Color.FromArgb(Barve.Rgb1, Barve.Rgb2, Barve.Rgb3);
            NpgsqlConnection conn = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM barve()", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1].ToString() + " - " + dr[0].ToString());
            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT nastavibarvo(@rgb1,@rgb2,@rgb3,@ime)", con);
            cmd.Parameters.AddWithValue("@rgb1", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@rgb2", Convert.ToInt32(textBox2.Text));
            cmd.Parameters.AddWithValue("@rgb3", Convert.ToInt32(textBox3.Text));
            cmd.Parameters.AddWithValue("@ime", textBox4.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Uspešno nastavljeno");
            con.Close();
            FestivalVelenje3.NastaviBarvo.ActiveForm.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT barvaobstaja(@id)", connection);
            command.Parameters.AddWithValue("@id", Convert.ToInt32(comboBox1.Text.Substring(comboBox1.Text.IndexOf("-")+2)));
            command.ExecuteNonQuery();
            MessageBox.Show("Uspešno nastavljeno");
            connection.Close();
            FestivalVelenje3.NastaviBarvo.ActiveForm.Close();
            Form1 form1 = new Form1();
            form1.Show();


        }

        private void NastaviBarvo_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
