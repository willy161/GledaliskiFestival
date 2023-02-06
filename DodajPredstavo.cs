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
    public partial class DodajPredstavo : Form
    {
        public DodajPredstavo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT dodajpredstavo(@ime,@vstopnina)", con);
            cmd.Parameters.AddWithValue("@ime", textBox1.Text);
            cmd.Parameters.AddWithValue("@vstopnina", Convert.ToInt32(textBox2.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Uspešno dodano");
            con.Close();
            Predstave nastopi = new Predstave();
            nastopi.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DodajPredstavo_Load(object sender, EventArgs e)
        {
            Barve.Setbarva();
            BackColor = Color.FromArgb(Barve.Rgb1, Barve.Rgb2, Barve.Rgb3);
        }
    }
}
