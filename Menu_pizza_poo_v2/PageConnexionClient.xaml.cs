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
    /// Logique d'interaction pour PageConnexionClient.xaml
    /// </summary>
    public partial class PageConnexionClient : Page
    {
        private List<Client> clients;
        private PageBienvenue mainWindow;
        private int index;

       
        public PageConnexionClient(List<Client> list, PageBienvenue main)
        {
            InitializeComponent();
            this.clients = list;
            this.mainWindow = main;
            this.clients = list;
        }

        private void numtel_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= numtel_GotFocus;
        }
        int id;
        bool success = false;

        /// <summary>
        /// Permet de vérifier si le numéro de téléphone entré est valide, et est déjà utilisé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numtel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                success = int.TryParse(numtel.Text, out id);
                if (!success)
                {
                    MessageBox.Show("Veuillez rentrer un numéro de téléphone valide");
                }
                bool ap = false;
                int compteur = 0;
                if (clients != null && clients.Count > 0)
                {
                    foreach (Client cl in clients)
                    {
                        if (cl.Egal(new Client(id))) { ap = true; this.index = compteur; }
                        compteur++;
                    }
                }
                if (ap == false && success == true)
                {
                    nvclient.Text = "Inscription\nnouveau client";
                    prenom.Text = "Entrez ici votre prénom";
                    prenom.BorderBrush = Brushes.DarkGray;
                    nom.Text = "Entrez ici votre nom";
                    nom.BorderBrush = Brushes.DarkGray;
                    adresse.Text = "Entrez ici votre adresse";
                    adresse.BorderBrush = Brushes.DarkGray;
                    inscription.Content = "Inscription";
                    inscription.BorderBrush = Brushes.DarkGray;
                }
                if (ap == true && success == true)
                {
                    mainWindow.PasserConnexionACommande(clients, clients[index]);
                }
            }
        }

        /// <summary>
        /// Permet d'afficher un menu d'inscription pour un nouveau client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inscription_Click(object sender, RoutedEventArgs e)
        {
            if (prenom.Text != null && prenom.Text != "Entrez ici votre prénom" && nom.Text != null && nom.Text != "Entrez ici votre nom" && adresse.Text != null && adresse.Text != "Entrez ici votre adresse" && success)
            {
                Client client = new Client(nom.Text, prenom.Text, adresse.Text, id);
                clients.Add(client);
                Client.AjoutClientCSV(client);
                mainWindow.PasserConnexionACommande(clients, clients[clients.Count-1]);
            }
        }
    }
}
