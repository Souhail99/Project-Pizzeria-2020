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
    /// Logique d'interaction pour PageEffectifClient.xaml
    /// </summary>
    public partial class PageEffectifClient : Page
    {
        private PageBienvenue main;
        private List<Client> clients;
        public PageEffectifClient(PageBienvenue mainWindow, List<Client> list)
        {
            InitializeComponent();
            OrdreAlpha.Content = "Affichage ordre \n  alphabétique";
            OrdreVille.Content = "Affichage ordre \n         ville";
            OrdreMontantAchats.Content = "Affichage ordre\nmontant achats";
            AddClient.Content = "  Ajouter\n un client";
            this.main = mainWindow;
            this.clients = list;
        }

        /// <summary>
        /// Permet d'afficher les clients de la pizzeria selon l'ordre alphabétique de leurs noms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdreAlpha_Click(object sender, RoutedEventArgs e)
        {
            List<Client> tamp = this.clients;
            tamp.Sort((Client a, Client b) => { return String.Compare(a.NomFamille, b.NomFamille); });
            main.ClientAAffichage(tamp);
        }

        /// <summary>
        /// Permet d'afficher les clients de la pizzeria selon l'ordre alphabétique de leurs villes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdreVille_Click(object sender, RoutedEventArgs e)
        {
            List<Client> tamp = this.clients;
            tamp.Sort((Client a, Client b) => { return String.Compare(a.Ville, b.Ville); });
            main.ClientAAffichage(tamp);
        }

        /// <summary>
        /// Permet d'afficher les clients de la pizzeria selon l'ordre décroissant de leur montant d'achat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdreMontantAchats_Click(object sender, RoutedEventArgs e)
        {
            List<Client> tamp = this.clients;
            tamp.Sort((Client a, Client b) => { if (a.AchatsCumulés > b.AchatsCumulés) { return -1; } if (a.AchatsCumulés == b.AchatsCumulés) { return 0; } return 1; });
            main.ClientAAffichage(tamp);
        }

        /// <summary>
        /// Permet d'inscrire un nouveau client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            main.Inscription();
        }
        public List<Client> Clients
        {
            get
            {
                return this.clients;
            }
        }
    }
}
