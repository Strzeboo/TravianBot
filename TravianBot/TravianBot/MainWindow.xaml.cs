using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using WpfApp1.Klasy;

namespace TravianBot
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string nazwaLogin, nazwaHaslo, trescRzadania, SerialKey;

        static public string odpowiedzLogowania { get; private set; }

        async private void buttonLoginOnClick(object sender, RoutedEventArgs e)
        {
            #region STARE POBIERANIE PAKIETU
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
            //var response = await client.GetAsync("https://ts2.travian.pl/login.php");

            //response.EnsureSuccessStatusCode();
            //string content = await response.Content.ReadAsStringAsync();
            #endregion

            string recivedLoginPackage = await HttpConnectionHelper.GetPackage("https://ts2.travian.pl/login.php");

            SerialKey = HttpConnectionHelper.GetLoginSecretCode(recivedLoginPackage);

            nazwaLogin = textBoxLogin.Text;
            nazwaHaslo = textPasswordBox.Password.ToString();

            trescRzadania = HttpConnectionHelper.setLoginPostData(nazwaLogin, nazwaHaslo, SerialKey);


            #region STARE WYSYŁANIE PAKIETU
            //HttpWebRequest requestt = (HttpWebRequest)WebRequest.Create("https://ts2.travian.pl/login.php");
            //requestt.Method = "POST";
            //string postData = trescRzadania;
            //byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //requestt.ContentType = "application/x-www-form-urlencoded";
            ////requestt.Referer = "http://webpage.com/";
            //requestt.ContentLength = byteArray.Length;
            //requestt.CookieContainer = new CookieContainer();
            //requestt.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31";

            //Stream dataStream = requestt.GetRequestStream();
            //dataStream.Write(byteArray, 0, byteArray.Length);
            //dataStream.Close(); // *** [1] ***

            ////client.Dispose();

            //HttpWebResponse response10 = (HttpWebResponse)requestt.GetResponse();


            //using (dataStream = dataStream = response10.GetResponseStream())
            //{
            //    // Open the stream using a StreamReader for easy access.  
            //    StreamReader reader = new StreamReader(dataStream);
            //    // Read the content.  
            //    string responseFromServer = reader.ReadToEnd();
            //    // Display the content.  
            //    //scroolViewer.Content = responseFromServer;
            //    odpowiedzLogowania = responseFromServer.Trim();
            //}

            #endregion

            odpowiedzLogowania = HttpConnectionHelper.SendPackage("https://ts2.travian.pl/login.php", trescRzadania);


            if (HttpConnectionHelper.IsLoginOkey(odpowiedzLogowania))
            {
                MessageBox.Show("Logowanie udane!", "Stan logowania", MessageBoxButton.OK, MessageBoxImage.Information);
                Okno2 nextForm = new Okno2();
                //nextForm.pierwszaOdpowiedz = odpowiedzLogowania;
                this.Hide();
                nextForm.ShowDialog();
                this.Close();
            }

            else
            {
                MessageBox.Show("Błąd logowania!", "Stan logowania", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

    }
}
