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
    /// Logique d'interaction pour PageRechCommande.xaml
    /// </summary>
    public partial class PageRechCommande : Page
    {
       // Attributs :

        private PageBienvenue main;
        private List<Commande> commandes = new List<Commande> { };
       
        public PageRechCommande(PageBienvenue mainWindow, List<Commande> com)
        {
            InitializeComponent();
            this.main = mainWindow;
            this.commandes = com;
        }

        private void numCommande_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= numCommande_GotFocus;
        }
        private int id;

        /// <summary>
        /// Vérifie que le numéro de commande entré est valide, et affiche la commande le cas échéant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numCommande_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                bool success = int.TryParse(numCommande.Text, out id);
                if (!success)
                {
                    MessageBox.Show("Veuillez rentrer un numéro de commande valide");
                }
                bool ap = false;
                Commande tamp = null;
                if (commandes != null && commandes.Count > 0)
                {
                    foreach (Commande cl in commandes)
                    {
                        if (cl.NumeroDeCommande == id) { ap = true; tamp = cl; }
                    }
                }
                if (ap == false && success == true)
                {
                    MessageBox.Show("Le numéro entré ne correspond à aucune commande");
                }
                if(ap == true && success == true)
                {
                    main.AfficherCommande(tamp);
                }
            }
        }
    }
}
