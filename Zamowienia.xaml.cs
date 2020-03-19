using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FirmaApp
{

    public partial class Zamowienia : Window
    {
        public Zamowienia()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Panel_glowny back = new Panel_glowny();
            back.Show();
            this.Close();
        }

        private void OrderAdd_Click(object sender, RoutedEventArgs e)
        {
            string Kerami = kerami.Text;
            string Grunt = grunt.Text;
            string Gladz = gladz.Text;
            string Gladz_luks = gladz_luks.Text;
            string Cement = cement.Text;
            string Tynk = tynk.Text;
            string Wylewka = wylewka.Text;
            string Stiro = stiro.Text;

            int value1 = int.Parse(Kerami);
            int value2 = int.Parse(Grunt);
            int value3 = int.Parse(Gladz);
            int value4 = int.Parse(Gladz_luks);
            int value5 = int.Parse(Cement);
            int value6 = int.Parse(Tynk);
            int value7 = int.Parse(Wylewka);
            int value8 = int.Parse(Stiro);


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|SMA.mdf;Integrated Security=True;Connect Timeout=30";
            conn.Open();
            string query = "INSERT INTO Zamowienia (ilosc_kerami,ilosc_grunt,ilosc_gladz,ilosc_gladz_luks,ilosc_cement,ilosc_tynk,ilosc_wylewka,ilosc_stiro) VALUES (@Kerami,@Grunt,@Gladz,@Gladz_luks,@Cement,@Tynk,@Wylewka,@Stiro)";

            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Kerami", value1);
                cmd.Parameters.AddWithValue("@Grunt", value2);
                cmd.Parameters.AddWithValue("@Gladz", value3);
                cmd.Parameters.AddWithValue("@Gladz_luks", value4);
                cmd.Parameters.AddWithValue("@Cement", value5);
                cmd.Parameters.AddWithValue("@Tynk", value6);
                cmd.Parameters.AddWithValue("@Wylewka", value7);
                cmd.Parameters.AddWithValue("@Stiro", value8);
                SqlDataReader useradd = cmd.ExecuteReader();

                MessageBox.Show("Pomyślnie dodano zamówienie");
            }
        }


    }
}
