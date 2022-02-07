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
    /// Logique d'interaction pour PageBienvenue.xaml
    /// </summary>
    public partial class PageBienvenue : Page
    {
        // Attributs utiles :

        private MainWindow main;
        private List<Commande> commandes;
        private List<Client> clients;
        private List<Commis> commis;
        private List<Livreur> livreurs;
        public int compteur = 0;

        // Constructeur :

       

        public PageBienvenue(MainWindow localWindow)
        {
            this.main = localWindow;
            InitializeComponent();
            //Affichage.Content = new AffichageMenu();
            this.commandes = new List<Commande> { };
            this.clients = Client.LectureFichier();
            this.commis = Commis.LectureFichier();
            this.livreurs = Livreur.LectureFichier();
            //VoirCommandes.Content = "Commandes\n   en cours";
        }

        // Propriété : le compteur fait référence au compteur utilisé dans la page statistique :
        public int Compteur
        {
            get { return this.compteur; }
        
        }


        /// <summary>
        /// Permet de revenir au menu lorsqu'une commande est effectuée, tout en gardant cette commande en mémoire
        /// </summary>
        /// <param name="com">Commande effectuée</param>
        public void GoBackToStartPageCommander(Commande com)
        {
            Affichage.Content = null;
            Random rdn = new Random();
            Commis commi = commis[rdn.Next(0, commis.Count)];
            commi.Commandes.Add(com);
            bool tousLivreurs = false;
            int compt = 0;
            while (tousLivreurs == false)
            {
                if (compt == livreurs.Count) { tousLivreurs = true; }
                else
                {
                    if (livreurs[compt].Etat == "Sur place" || livreurs[compt].Etat == "surplace")
                    {
                        livreurs[compt].Commandedulivreur = com;
                        livreurs[compt].Etat = "En livraison";
                        livreurs[compt].CommandeGerer.Add(com);
                        tousLivreurs = true;
                    }
                    else
                    {
                        compt++;
                    }
                }
            }
            if (com.Prix > 0)
            {
                Commande commande = new Commande(com.Pizzas, com.Prix, com.Boisson, commi, livreurs[compt], com.NumTelAssocié, com.NumeroDeCommande);
                commandes.Add(commande);
                Commande.AjoutCommandeCSV(commande);
            }
        }

        /// <summary>
        /// Permet de revenir au menu une fois qu'un client a été inscrit
        /// </summary>
        /// <param name="client">Client inscrit</param>
        public void GoBackToStartPageInscription(Client client)
        {
            this.clients.Add(client);
            Affichage.Content = null;
        }

        /// <summary>
        /// Permet de revenir au menu une fois qu'un livreur a été inscrit
        /// </summary>
        /// <param name="livreur">Livreur inscrit</param>
        public void GoBackToStartPageInscriptionLivreur(Livreur livreur)
        {
            Affichage.Content = null;
            this.livreurs.Add(livreur);
        }

        /// <summary>
        ///  Permet de revenir au menu une fois qu'un commis a été inscrit
        /// </summary>
        /// <param name="commis">Commis inscrit</param>
        public void GoBackToStartPageInscriptionCommis(Commis commis)
        {
            this.commis.Add(commis);
            Affichage.Content = null;
        }

        /// <summary>
        /// Permet de rafraîchir la page de résumé des commandes, afin de mettre à jour le statut des commandes
        /// </summary>
        /// <param name="com">Liste de commandes actives</param>
        /// <param name="livreurs">Liste de livreurs actifs</param>
        public void RafraichirCommandes(List<Commande> com, List<Livreur> livreurs)
        {
            Affichage.Content = null;
            this.livreurs = livreurs;
            this.commandes = com;
            Affichage.Content = new PageResumeCommandes(com, this, livreurs);
        }

        /// <summary>
        /// Permet d'accéder à la page de résumé des commandes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VoirCommandes_Click(object sender, RoutedEventArgs e)
        {
            Affichage.Content = new PageResumeCommandes(this.commandes, this, this.livreurs);
        }

        /// <summary>
        /// Permet d'accéder à la page de commande
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Affichage.Content = new PageCommande(this, clients);
        }

        /// <summary>
        /// Permet de renvoyer à une page de connexion client
        /// </summary>
        public void RenvoyerConnexion()
        {
            Affichage.Content = new PageConnexionClient(clients, this);
        }

        /// <summary>
        /// Permet à un client s'étant connecté de commander
        /// </summary>
        /// <param name="list">Liste de clients de la pizzeria</param>
        /// <param name="client">Client souhaitant commander</param>
        public void PasserConnexionACommande(List<Client> list, Client client)
        {
            this.clients = list;
            Affichage.Content = new Page1(this, client, this.livreurs);
        }

        /// <summary>
        /// Permet d'afficher toutes les commandes actives
        /// </summary>
        public void AfficherToutesLesCommandes()
        {
            Affichage.Content = new PageResumeCommandes(this.commandes, this, this.livreurs);
        }

        /// <summary>
        /// Permet d'afficher les commandes actives d'un client
        /// </summary>
        /// <param name="list">Liste de commandes du client</param>
        public void AfficherCommandeClient(List<Commande> list)
        {
            Affichage.Content = new PageResumeCommandes(list, this, this.livreurs);
        }

        /// <summary>
        /// Permet de renvoyer une page de connexion client afin de voir ses commandes
        /// </summary>
        public void ConnexionCommandeClient()
        {
            Affichage.Content = new PageConnexionCommandesClient(this, this.clients, this.commandes);
        }
        /* private void Pizzeria_Click(object sender, RoutedEventArgs e)
         {
             Affichage.Content = new PageBienvenue(this);
         }*/

        /// <summary>
        /// Permet de renvoyer à un menu d'affichage des différents acteurs de la pizzeria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Effectifs_Click(object sender, RoutedEventArgs e)
        {
            Affichage.Content = new PageEffectif(this);
        }

        /// <summary>
        /// Permet de renvoyer à un menu d'affichage des Clients de la pizzeria
        /// </summary>
        public void EffectifAClient()
        {
            Affichage.Content = new PageEffectifClient(this, this.clients);
        }

        /// <summary>
        /// Permet de renvoyer à un menu d'affichage des employés (commis et livreurs) de la pizzeria
        /// </summary>
        public void EffectifAEmployé()
        {
            Affichage.Content = new PageEffectifEmployés(this);
        }

        /// <summary>
        /// Permet d'afficher tous les clients de la pizzeria
        /// </summary>
        /// <param name="list">Liste des clients de la pizzeria</param>
        public void ClientAAffichage(List<Client> list)
        {
            Affichage.Content = new PageAffichageClient(this, list);
        }

        /// <summary>
        /// Permet d'afficher les commis de la pizzeria
        /// </summary>
        public void EffectifACommis()
        {
            Affichage.Content = new AffichageEmployes(this, this.commis, new List<Livreur> { });
        }

        /// <summary>
        /// Permet d'afficher les livreurs de la pizzeria
        /// </summary>
        public void EffectifALivreur()
        {
            Affichage.Content = new AffichageEmployes(this, new List<Commis> { }, this.livreurs);
        }

        /// <summary>
        ///  Permet de renvoyer à une page de recherche de commande grâce à son numéro
        /// </summary>
        public void RechCommande()
        {
            Affichage.Content = new PageRechCommande(this, this.commandes);
        }

        /// <summary>
        /// Permet d'afficher une commande
        /// </summary>
        /// <param name="commande">Commande à afficher</param>
        public void AfficherCommande(Commande commande)
        {
            Affichage.Content = new PageResumeCommandes(new List<Commande> { commande }, this, this.livreurs);
        }

        /// <summary>
        /// Permet de renvoyer à une page d'inscription client
        /// </summary>
        public void Inscription()
        {
            Affichage.Content = new PageInscription(this.clients, this, new List<Commis> { }, new List<Livreur> { });
        }

        /// <summary>
        /// Permet de renvoyer à une page d'inscription commis
        /// </summary>
        public void InscriptionCommis()
        {
            Affichage.Content = new PageInscription(new List<Client> { }, this, this.commis, new List<Livreur> { });
        }

        /// <summary>
        /// Permet de renvoyer à une page d'inscription livreur
        /// </summary>
        public void InscriptionLivreur()
        {
            Affichage.Content = new PageInscription(new List<Client> { }, this, new List<Commis> { }, this.livreurs);
        }

        /// <summary>
        /// Ouvre la page statistique et affiche un graphique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ouvrestat(object sender, RoutedEventArgs e)
        {
            compteur++;
            Affichage.Content = new PageStatistique(compteur);
        }

        /// <summary>
        /// Ouvre la page moyenne correspondant au module des moyennes demandé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OuvrePageMoyenne(object sender, RoutedEventArgs e)
        {
            Affichage.Content = new PageMoyenne();
        }

        private void OuvreHome(object sender, RoutedEventArgs e)
        {
            main.Home();
        }
    }
}
