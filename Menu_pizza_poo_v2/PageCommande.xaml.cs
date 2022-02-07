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
    /// Logique d'interaction pour PageCommande.xaml
    /// </summary>
    public partial class PageCommande : Page
    {
        // Attributs :

        private PageBienvenue mainWindow;
        private List<Client> clients;
        private Client client;

        /// <summary>
        /// Permet d'afficher un menu de sélection d'affichage de commandes
        /// </summary>
        /// <param name="main"></param>
        /// <param name="list">Liste de clients</param>
        public PageCommande(PageBienvenue main, List<Client> list)
        {
            InitializeComponent();
            this.mainWindow = main;
            this.clients = list;
            VoirCommandes.Content = "    Voir les\ncommandes\n    actives";
            VoirCommandesClient.Content = "    Voir les\ncommandes\n  d'un client";
            NumCommande.Content = "   Voir une\ncommande \navec son n°";
        }

        /// <summary>
        /// Renvoye à une page de connexion client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Commander_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.RenvoyerConnexion();
        }

        /// <summary>
        /// Permet d'afficher toutes les commandes actives
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VoirCommandes_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.AfficherToutesLesCommandes();
        }

        /// <summary>
        /// Renvoye à une page d'identification client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VoirCommandesClient_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ConnexionCommandeClient();
        }


        /// <summary>
        /// Renvoye à une page d'identification commande grâce à son numéro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumCommande_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.RechCommande();
        }
    }
}
