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
using System.Diagnostics;
using System.Security;
using System.ComponentModel;
using System.Media;


namespace Menu_pizza_poo_v2
{
    /// <summary>
    /// Logique d'interaction pour PageRapport.xaml
    /// </summary>
    public partial class PageRapport :  Page
    {
        MainWindow localMainWindow;//déclare une instance locale du type de MainWindow
        PageRapport a;


       
        public PageRapport(MainWindow main)
        {
            this.localMainWindow = main;
            InitializeComponent();
        }

        // Méthodes ouvrant les fichier voulus :

        private void Ouvrepdf(object sender, RoutedEventArgs e)
        {
            Process.Start("Rapport_projet_POOA_ann_e_3.pdf");
        }

      
        private void OuvreUml(object sender, RoutedEventArgs e)
        {
            Process.Start("UML Lewis Souhail.PNG");
        }

        private void OuvreHome(object sender, RoutedEventArgs e)
        {
            localMainWindow.Home();
        }
    }
}
