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
    public partial class Predstave : Form
    {
        int id;
        public void refresh()
        {
            listView1.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM vrnipredstave()", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                listView1.Items.Add(item);
            }
            conn.Close();

        }
        public Predstave()
        {
            InitializeComponent();
        }

        private void Nastopi_Load(object sender, EventArgs e)
        {
            Barve.Setbarva();
            BackColor = Color.FromArgb(Barve.Rgb1, Barve.Rgb2, Barve.Rgb3);
            refresh();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            }
            catch
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT editpredstava(@idp,@vst,@imep)", con);
            cmd.Parameters.AddWithValue("@idp", id);
            cmd.Parameters.AddWithValue("@vst", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@imep", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT izbrisipredstavo(@idp)", con);
            cmd.Parameters.AddWithValue("@idp", id);
            cmd.ExecuteNonQuery();
            con.Close();
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DodajPredstavo dodajPredstavo = new DodajPredstavo();
            dodajPredstavo.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
