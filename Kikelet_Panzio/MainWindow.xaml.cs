using System;
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
using System.IO;

namespace Kikelet_Panzio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szoba> szobak = new List<Szoba> ();
        public MainWindow()
        {
            InitializeComponent();
            CbxFerohey.Items.Clear();
            CbxFerohey.Items.Add("2 férőhely");
            CbxFerohey.Items.Add("3 férőhely");
            CbxFerohey.Items.Add("4 férőhely");

            CbxFerohey.SelectedIndex = 0;
            LoadFromFile("szobak.txt"); 
        }

        private void LoadFromFile(string fileName)
        {
            string[] sorok = File.ReadAllLines(fileName);
            for (int i = 1; i < sorok.Length; i++)
            {
                szobak.Add(new Szoba(sorok[i]));
            }
        }

        private void CbxFerohey_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnMentes_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
