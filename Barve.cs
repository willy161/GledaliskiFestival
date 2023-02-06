using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace FestivalVelenje3
{
    public static class Barve
    {
        public static int Rgb1 { get; set; }
        public static int Rgb2 { get; set; }
        public static int Rgb3 { get; set; }
        public static void Setbarva()
        {
            NpgsqlConnection colorcon = new NpgsqlConnection("Host=ep-red-boat-861591.eu-central-1.aws.neon.tech;Port=5432;Username=willy161;Password=sa3zqkobiwK2;Database=neondb");
            colorcon.Open();
            NpgsqlCommand colorcmd = new NpgsqlCommand("SELECT * from barva()", colorcon);
            NpgsqlDataReader colorreader = colorcmd.ExecuteReader();
            while (colorreader.Read())
            {
                Rgb1 = colorreader.GetInt32(0);
                Rgb2 = colorreader.GetInt32(1);
                Rgb3 = colorreader.GetInt32(2);
            }
            colorcon.Close();
        }
    }
}
