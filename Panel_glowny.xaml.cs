using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlTypes;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FirmaApp
{

    public partial class Panel_glowny : Window
    {
        public string stanowisko;
        public Panel_glowny()
        {
            stanowisko = Panel_logowania.Stanowisko;
            InitializeComponent();
        }
        public void Boss_Click(object sender, RoutedEventArgs e)
        {
            if (stanowisko == "Kierownik")
            {
                Strefa_kierownika sk = new Strefa_kierownika();
                sk.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nie posiadasz uprawnień");
            }
        }


        private void Seller_Click(object sender, RoutedEventArgs e)
        {
            if (stanowisko == "Przedstawiciel" || stanowisko == "Kierownik")
            {
                Strefa_przedstawiciela sp = new Strefa_przedstawiciela();
                sp.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nie posiadasz uprawnień");
            }
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {if (stanowisko == "Przedstawiciel" || stanowisko == "Kierownik")
            {
                Zamowienia z = new Zamowienia();
                z.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nie posiadasz uprawnień");
            }
        }

        private void Warehouse_Click(object sender, RoutedEventArgs e)
        {
            if (stanowisko == "Magazynier" || stanowisko == "Kierownik")
            {
                Magazyn m = new Magazyn();
                m.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nie posiadasz uprawnień");
            }
        }
    }
}
