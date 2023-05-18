using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_PMdoga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szakasz> szakaszok = new List<Szakasz>();

        public MainWindow()
        {
            InitializeComponent();

            ListaBetoltes();
            MyDg.ItemsSource = szakaszok;
        }

        public void ListaBetoltes()
        {
            var adatok = File.ReadAllLines("adatok.txt",Encoding.UTF8);
            foreach (var item in adatok)
            {
                Szakasz uj = new Szakasz(item);
                szakaszok.Add(uj);
            }
        }

        private void szakaszok_szama_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"szakaszok száma {szakaszok.Count()}");
        }

        private void teljesitheto_Click(object sender, RoutedEventArgs e)
        {
            var szurt = szakaszok.Select(x => x).Where(x => x.Ido <= Convert.ToInt32(tbido.Text)).ToList();
            MyDg.ItemsSource = szurt;
            lbszurtek.Content = szurt.Count;
        }

        private void pilis_Click(object sender, RoutedEventArgs e)
        {
            var eredmeny = szakaszok.Select(x => x).Where(y => y.Utleiras.Contains("Pilis")).Select(z => z.Ido).Average();
            MessageBox.Show($"pilis szavas szakaszok átlag ideje:{eredmeny}");
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            MyDg.ItemsSource = szakaszok;
        }

        private void lehosszabb_Click(object sender, RoutedEventArgs e)
        {
            var eredmeny = szakaszok.Select(x => x).Where(x => x.Hossz == szakaszok.Max(x => x.Hossz)).ToList();
            foreach (var item in eredmeny)
            {
                MessageBox.Show($"{item.Utleiras},{item.Hossz},{item.Ido}");
            }
        }

        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            List<string> eredmeny = new List<string>();

            foreach (var item in szakaszok)
            {
                eredmeny.Add($"{item.Utleiras},{item.Hossz},{item.Magassag},{item.Nehezseg(item.Hossz)}");
            }
            File.WriteAllLines("utvonal.txt",eredmeny,Encoding.UTF8);
        }
    }
}
