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

namespace Menu_pizza_poo_v2
{
    /// <summary>
    /// Logique d'interaction pour PageEffectif.xaml
    /// </summary>
    public partial class PageEffectif : Page
    {
        private PageBienvenue main;
        public PageEffectif(PageBienvenue mainWindow)
        {
            InitializeComponent();
            this.main = mainWindow;
        }

        /// <summary>
        /// Permet d'afficher un menu d'affichage des clients de la pizzeria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            main.EffectifAClient();
        }

        /// <summary>
        /// Permet d'afficher un menu d'affichage des employés (livreurs et commis) de la pizzeria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Commis_Click(object sender, RoutedEventArgs e)
        {
            main.EffectifAEmployé();
        }
    }
}
