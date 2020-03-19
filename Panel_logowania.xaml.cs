using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FirmaApp
{

    public partial class Panel_logowania : Window
    {
        public static string Stanowisko;
        public static int id;
        


        public Panel_logowania()
        {

            InitializeComponent();
        }
        public void Login_Click(object sender, RoutedEventArgs e)
        {

            string user = UserLogintxt.Text;
            string passwd = UserPassword.Password;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|SMA.mdf;Integrated Security=True;Connect Timeout=30";
            conn.Open();
            SqlDataReader read = (null);
            string query2 = ("SELECT Stanowisko,Id from Uzytkownicy WHERE Login=@user");
            SqlCommand com = new SqlCommand(query2, conn);
            com.Parameters.AddWithValue("@user", user);
            read = com.ExecuteReader();
            if (read.Read())
            {
                Stanowisko = read.GetString(0);
                id = read.GetInt32(1);
            }

            read.Close();
            conn.Close();
            conn.Open();
            string query = "SELECT * FROM Uzytkownicy WHERE Login=@user AND Haslo=@passwd";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@passwd", passwd);
            cmd.Parameters.AddWithValue("@user", user);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows == true)
            {
                MessageBox.Show("Zalogowano poprawnie \n Stanowisko: " + Stanowisko + "\n Twoje id : " + id);
                Panel_glowny menu = new Panel_glowny();
                menu.Show();
                this.Close();
            }
            
            else
            {
                FailMsg.Visibility = Visibility.Visible;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();

        }
    }

}
