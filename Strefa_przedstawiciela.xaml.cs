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

    public partial class Strefa_przedstawiciela : Window
    {
        public Strefa_przedstawiciela()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Panel_glowny back = new Panel_glowny();
            back.Show();
            this.Close();
        }

        private void OrderAdd_Click(object sender, RoutedEventArgs e) { 
        

                string id = Id.Text;
                string faktura = Faktura.Text;
                string klient = Klient.Text;
                string nip = NIP.Text;

                SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|SMA.mdf;Integrated Security=True;Connect Timeout=30";
            conn.Open();
                string query = "INSERT INTO Przedstawiciele (Id_sprzedawcy,Faktura,Klient,NIP) VALUES ( @id,@faktura,@klient,@nip)";



                if ((id == "") || (faktura == "") || (klient == "") || (nip == ""))
                {
                    MessageBox.Show("Uzupełnij wszystkie pola");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@faktura", faktura);
                    cmd.Parameters.AddWithValue("@klient", klient);
                    cmd.Parameters.AddWithValue("@nip", nip);
                    SqlDataReader useradd = cmd.ExecuteReader();

                    MessageBox.Show("Pomyślnie dodano zamówienie");
                }

            }
        }
 }

