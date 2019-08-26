using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Klasy;

namespace TravianBot
{
    /// <summary>
    /// Logika interakcji dla klasy Okno2.xaml
    /// </summary>
    public partial class Okno2 : Window
    {
        string odpowiedzPierwszaZSerwera;
        public Okno2()
        {
            InitializeComponent();
            odpowiedzPierwszaZSerwera = MainWindow.odpowiedzLogowania;
            labelInfoDrewno.Content = StringOperationHelper.GetStringBeetweenTwoStrings(odpowiedzPierwszaZSerwera, "<span id=\"l1\" class=\"value\">&#x202d;", "&#x202c;</span>");
            labelInfoGlina.Content = StringOperationHelper.GetStringBeetweenTwoStrings(odpowiedzPierwszaZSerwera, "<span id=\"l2\" class=\"value\">&#x202d;", "&#x202c;</span>");
            labelInfoZelazo.Content = StringOperationHelper.GetStringBeetweenTwoStrings(odpowiedzPierwszaZSerwera, "<span id=\"l3\" class=\"value\">&#x202d;", "&#x202c;</span>");
            labelInfoZboze.Content = StringOperationHelper.GetStringBeetweenTwoStrings(odpowiedzPierwszaZSerwera, "<span id=\"l4\" class=\"value\">", 25, "&#x202c;            </span>");
        }
    }
}
