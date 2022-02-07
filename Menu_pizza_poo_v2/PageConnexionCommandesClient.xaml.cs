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
    /// Logique d'interaction pour PageConnexionCommandesClient.xaml
    /// </summary>
    public partial class PageConnexionCommandesClient : Page
    {
        // Attributs :
        
        private List<Client> clients = new List<Client> { };
        private List<Commande> commandes = new List<Commande> { };
        private PageBienvenue main;
        public PageConnexionCommandesClient(PageBienvenue mainwindow, List<Client> list, List<Commande> com)
        {
            InitializeComponent();
            this.main = mainwindow;
            this.clients = list;
            this.commandes = com;
        }
        private void numtel_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= numtel_GotFocus;
        }
        int id;

        /// <summary>
        ///  Permet d'afficher une commande en fonction d'un numéro de téléphone, associé au client ayant passé la commande
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numtel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                bool success = int.TryParse(numtel.Text, out id);
                if (!success)
                {
                    MessageBox.Show("Veuillez rentrer un numéro de téléphone valide");
                }
                Client tampon = new Client(0);
                bool ap = false;
                if (clients != null && clients.Count > 0)
                {
                    foreach (Client cl in clients)
                    {
                        if (cl.Egal(new Client(id))) { ap = true; tampon = cl; }
                    }
                }
                if (ap == false && success == true)
                {
                    MessageBox.Show("Client non enregistré dans la base de données");
                }
                if (ap == true && success == true)
                {
                    List<Commande> com = this.commandes.FindAll((Commande commande) => { return commande.NumTelAssocié == id; });
                    main.AfficherCommandeClient(com);
                }
            }
        }
    }
}
