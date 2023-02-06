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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            UrejajZasedbe urejajZasedbe = new UrejajZasedbe();
            urejajZasedbe.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Zasedbe zasedbe = new Zasedbe();
            zasedbe.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VsiNastopi vsePredstave = new VsiNastopi();
            vsePredstave.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Arhiv arhiv = new Arhiv();
            arhiv.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Predstave nastopi = new Predstave();
            nastopi.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Barve.Setbarva();
            BackColor = Color.FromArgb(Barve.Rgb1, Barve.Rgb2, Barve.Rgb3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NastaviBarvo nastaviBarvo = new NastaviBarvo();
            FestivalVelenje3.Form1.ActiveForm.Hide();
            nastaviBarvo.Show();
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
