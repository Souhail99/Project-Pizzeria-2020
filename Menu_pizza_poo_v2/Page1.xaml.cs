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
using System.Collections;
using System.Diagnostics;


namespace Menu_pizza_poo_v2
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
       
        // Attributs :

        int compteurFrom = 0;
        int compteurChor = 0;
        int compteurVege = 0;

        int compteurCoca = 0;
        int compteurJus = 0;
        int compteurIceTea = 0;

        int compteurPrixCoca = 0;
        int compteurPrixJus = 0;
        int compteurPrixIceTea = 0;

        int compteurPrixFrom = 0;
        int compteurPrixChor = 0;
        int compteurPrixVege = 0;

        int grandeVege = 22;
        int moyenneVege = 18;
        int petiteVege = 15;

        int grandeFrom = 20;
        int moyenneFrom = 16;
        int petiteFrom = 12;

        int grandeChor = 26;
        int moyenneChor = 22;
        int petiteChor = 18;

        int coca33cl = 5;
        int coca50cl = 7;
        int coca1l = 10;

        int jus33cl = 6;
        int jus50cl = 9;
        int jus1l = 12;

        int icetea33cl = 4;
        int icetea50cl = 6;
        int icetea1l = 8;


        public Page1(PageBienvenue mainWindow, Client cl, List<Livreur> livr)
        {
            InitializeComponent();
            main = mainWindow;
            this.client = cl;
            this.livreurs = livr;
        }
        private PageBienvenue main;
        private Client client;
        private List<Livreur> livreurs;

      
        private void Btn_MoinsFrom_Click(object sender, RoutedEventArgs e)
        {
            if (compteurFrom > 0)
            {
                compteurFrom--;
                TxCompteurFrom.Text = compteurFrom.ToString();
                if (GrandeFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * grandeFrom; }
                if (MoyenneFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * moyenneFrom; }
                if (PetiteFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * petiteFrom; }
                PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
            }
        }

        private void Btn_PlusFrom_Click(object sender, RoutedEventArgs e)
        {
            compteurFrom++;
            TxCompteurFrom.Text = compteurFrom.ToString();
            if (GrandeFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * grandeFrom; }
            if (MoyenneFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * moyenneFrom; }
            if (PetiteFrom.IsChecked == true) { compteurPrixFrom = compteurFrom * petiteFrom; }
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }
        private void Btn_MoinsChor_Click(object sender, RoutedEventArgs e)
        {
            if (compteurChor > 0)
            {
                compteurChor--;
                TxCompteurChor.Text = compteurChor.ToString();
                if (GrandeChor.IsChecked == true) { compteurPrixChor = compteurChor * grandeChor; }
                if (MoyenneChor.IsChecked == true) { compteurPrixChor = compteurChor * moyenneChor; }
                if (PetiteChor.IsChecked == true) { compteurPrixChor = compteurChor * petiteChor; }
                PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
            }
        }
        private void Btn_PlusChor_Click(object sender, RoutedEventArgs e)
        {
            compteurChor++;
            TxCompteurChor.Text = compteurChor.ToString();
            if (GrandeChor.IsChecked == true) { compteurPrixChor = compteurChor * grandeChor; }
            if (MoyenneChor.IsChecked == true) { compteurPrixChor = compteurChor * moyenneChor; }
            if (PetiteChor.IsChecked == true) { compteurPrixChor = compteurChor * petiteChor; }
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }
        private void Btn_MoinsVege_Click(object sender, RoutedEventArgs e)
        {
            if (compteurVege > 0)
            {
                compteurVege--;
                TxCompteurVege.Text = compteurVege.ToString();
                if (GrandeVege.IsChecked == true) { compteurPrixVege = compteurVege * grandeVege; }
                if (MoyenneVege.IsChecked == true) { compteurPrixVege = compteurVege * moyenneVege; }
                if (PetiteVege.IsChecked == true) { compteurPrixVege = compteurVege * petiteVege; }
                PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
            }
        }
        private void Btn_PlusVege_Click(object sender, RoutedEventArgs e)
        {
            compteurVege++;
            TxCompteurVege.Text = compteurVege.ToString();
            if (GrandeVege.IsChecked == true) { compteurPrixVege = compteurVege * grandeVege; }
            if (MoyenneVege.IsChecked == true) { compteurPrixVege = compteurVege * moyenneVege; }
            if (PetiteVege.IsChecked == true) { compteurPrixVege = compteurVege * petiteVege; }
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void PetiteFrom_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixFrom = compteurFrom * petiteFrom;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void MoyenneFrom_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixFrom = compteurFrom * moyenneFrom;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void GrandeFrom_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixFrom = compteurFrom * grandeFrom;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void PetiteChor_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixChor = compteurChor * petiteChor;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void MoyenneChor_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixChor = compteurChor * moyenneChor;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void GrandeChor_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixChor = compteurChor * grandeChor;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void PetiteVege_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixVege = compteurVege * petiteVege;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void MoyenneVege_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixVege = compteurVege * moyenneVege;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void GrandeVege_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixVege = compteurVege * grandeVege;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege).ToString() + "€";
        }

        private void Btn_Commander_Click(object sender, RoutedEventArgs e)
        {
            Pizza[] pizzas = new Pizza[compteurFrom + compteurChor + compteurVege];
            if (compteurFrom > 0 || compteurChor > 0 || compteurVege > 0)
            {
                Pizza pizzaFrom = new Pizza();
                Pizza pizzaChor = new Pizza();
                Pizza pizzaVege = new Pizza();
                if (PetiteFrom.IsChecked == true) { pizzaFrom = new Pizza("petite", "4 fromages", petiteFrom); }
                if (MoyenneFrom.IsChecked == true) { pizzaFrom = new Pizza("moyenne", "4 fromages", moyenneFrom); }
                if (GrandeFrom.IsChecked == true) { pizzaFrom = new Pizza("grande", "4 fromages", grandeFrom); }

                if (PetiteChor.IsChecked == true) { pizzaChor = new Pizza("petite", "chorizo", petiteChor); }
                if (MoyenneChor.IsChecked == true) { pizzaChor = new Pizza("moyenne", "chorizo", moyenneChor); }
                if (GrandeChor.IsChecked == true) { pizzaChor = new Pizza("grande", "chorizo", grandeChor); }

                if (PetiteVege.IsChecked == true) { pizzaVege = new Pizza("petite", "végétarienne", petiteVege); }
                if (MoyenneVege.IsChecked == true) { pizzaVege = new Pizza("moyenne", "végétarienne", moyenneVege); }
                if (GrandeVege.IsChecked == true) { pizzaVege = new Pizza("grande", "végétarienne", grandeVege); }

                for (int i = 0; i < compteurFrom; i++) { pizzas[i] = pizzaFrom; }
                for (int j = compteurFrom; j < compteurFrom + compteurChor; j++) { pizzas[j] = pizzaChor; }
                for (int k = compteurFrom + compteurChor; k < compteurFrom + compteurChor + compteurVege; k++) { pizzas[k] = pizzaVege; }
            }
            List<Boissons> boissons = new List<Boissons> { };
            if (compteurCoca > 0 || compteurJus > 0 || compteurIceTea > 0)
            {
                Boissons coca = new Boissons();
                Boissons jusorange = new Boissons();
                Boissons icetea = new Boissons();
                if (PetitCoca.IsChecked == true) { coca = new Boissons("Coca", 33, coca33cl); }
                if (MoyenCoca.IsChecked == true) { coca = new Boissons("Coca", 50, coca50cl); }
                if (GrandCoca.IsChecked == true) { coca = new Boissons("Coca", 100, coca1l); }

                if (PetitOrange.IsChecked == true) { jusorange = new Boissons("Jus d'orange", 33, jus33cl); }
                if (MoyenOrange.IsChecked == true) { jusorange = new Boissons("Jus d'orange", 50, jus50cl); }
                if (GrandOrange.IsChecked == true) { jusorange = new Boissons("Jus d'orange", 100, jus1l); }

                if (PetitIceTea.IsChecked == true) { icetea = new Boissons("Ice Tea", 33, icetea33cl); }
                if (MoyenIceTea.IsChecked == true) { icetea = new Boissons("Ice Tea", 50, icetea50cl); }
                if (GrandIceTea.IsChecked == true) { icetea = new Boissons("Ice Tea", 100, icetea1l); }

                for (int i = 0; i < compteurCoca; i++) { boissons.Add(coca); }
                for (int j = compteurCoca; j < compteurCoca + compteurJus; j++) { boissons.Add(jusorange); }
                for (int k = compteurCoca + compteurJus; k < compteurCoca + compteurJus + compteurIceTea; k++) { boissons.Add(icetea); }
            }
            bool dispo = false;
            foreach (Livreur livreur in livreurs)
            {
                if (livreur.Etat == "Sur place" || livreur.Etat == "surplace")
                {
                    dispo = true;
                }
            }
            bool pizzaobli = false;
            if (compteurFrom + compteurChor + compteurVege > 0) { pizzaobli = true; }
            if (dispo == true && pizzaobli == true)
            {
                Commande commande = new Commande(pizzas, compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea, this.client.NumTel, boissons);

                this.client.Commandes.Add(commande);
                this.client.AchatsCumulés += commande.Prix;
                main.GoBackToStartPageCommander(commande);
            }
            else
            {
                if (dispo == false)
                {
                    MessageBox.Show("Navré, aucun livreur n'est pour l'instant disponible : ajoutez un nouveau livreur, ou attendez qu'un livreur finisse sa livraison !");
                }
                if(pizzaobli == false)
                {
                    MessageBox.Show("Une commande doit comporter au moins une pizza");
                }
            }
        }

        private void Btn_MoinsCoca_Click(object sender, RoutedEventArgs e)
        {
            if (compteurCoca > 0)
            {
                compteurCoca--;
                TxCompteurCoca.Text = compteurCoca.ToString();
                if (GrandCoca.IsChecked == true) { compteurPrixCoca = compteurCoca * coca1l; }
                if (MoyenCoca.IsChecked == true) { compteurPrixCoca = compteurCoca * coca50cl; }
                if (PetitCoca.IsChecked == true) { compteurPrixCoca = compteurCoca * coca33cl; }
                PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
            }
        }

        private void Btn_PlusCoca_Click(object sender, RoutedEventArgs e)
        {
            compteurCoca++;
            TxCompteurCoca.Text = compteurCoca.ToString();
            if (GrandCoca.IsChecked == true) { compteurPrixCoca = compteurCoca * coca1l; }
            if (MoyenCoca.IsChecked == true) { compteurPrixCoca = compteurCoca * coca50cl; }
            if (PetitCoca.IsChecked == true) { compteurPrixCoca = compteurCoca * coca33cl; }
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void PetitCoca_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixCoca = compteurCoca * coca33cl;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void MoyenCoca_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixCoca = compteurCoca * coca50cl;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void GrandCoca_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixCoca = compteurCoca * coca1l;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void Btn_MoinsOrange_Click(object sender, RoutedEventArgs e)
        {
            if (compteurJus > 0)
            {
                compteurJus--;
                TxCompteurOrange.Text = compteurJus.ToString();
                if (GrandOrange.IsChecked == true) { compteurPrixJus = compteurJus * jus1l; }
                if (MoyenOrange.IsChecked == true) { compteurPrixJus = compteurJus * jus50cl; }
                if (PetitOrange.IsChecked == true) { compteurPrixJus = compteurJus * jus33cl; }
                PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
            }
        }

        private void Btn_PlusOrange_Click(object sender, RoutedEventArgs e)
        {
            compteurJus++;
            TxCompteurOrange.Text = compteurJus.ToString();
            if (GrandOrange.IsChecked == true) { compteurPrixJus = compteurJus * jus1l; }
            if (MoyenOrange.IsChecked == true) { compteurPrixJus = compteurJus * jus50cl; }
            if (PetitOrange.IsChecked == true) { compteurPrixJus = compteurJus * jus33cl; }
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void PetitOrange_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixJus = compteurJus * jus33cl;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void MoyenOrange_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixJus = compteurJus * jus50cl;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void GrandOrange_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixJus = compteurJus * jus1l;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void Btn_MoinsIceTea_Click(object sender, RoutedEventArgs e)
        {
            if (compteurIceTea > 0)
            {
                compteurIceTea--;
                TxCompteurIceTea.Text = compteurIceTea.ToString();
                if (GrandIceTea.IsChecked == true) { compteurPrixIceTea = compteurIceTea * icetea1l; }
                if (MoyenIceTea.IsChecked == true) { compteurPrixIceTea = compteurIceTea * icetea50cl; }
                if (PetitIceTea.IsChecked == true) { compteurPrixIceTea = compteurIceTea * icetea33cl; }
                PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
            }
        }

        private void Btn_PlusIceTea_Click(object sender, RoutedEventArgs e)
        {
            compteurIceTea++;
            TxCompteurIceTea.Text = compteurIceTea.ToString();
            if (GrandIceTea.IsChecked == true) { compteurPrixIceTea = compteurIceTea * icetea1l; }
            if (MoyenIceTea.IsChecked == true) { compteurPrixIceTea = compteurIceTea * icetea50cl; }
            if (PetitIceTea.IsChecked == true) { compteurPrixIceTea = compteurIceTea * icetea33cl; }
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void PetitIceTea_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixIceTea = compteurIceTea * icetea33cl;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void MoyenIceTea_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixIceTea = compteurIceTea * icetea50cl;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        private void GrandIceTea_Click(object sender, RoutedEventArgs e)
        {
            compteurPrixIceTea = compteurIceTea * icetea1l;
            PrixCount.Text = (compteurPrixFrom + compteurPrixChor + compteurPrixVege + compteurPrixCoca + compteurPrixJus + compteurPrixIceTea).ToString() + "€";
        }

        /*private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            //Process.Start("https://google.com");
            //Process processfirefox = new Process();
            //processfirefox = Process.Start("firefox.exe", "https://codes-sources.commentcamarche.net/forum/affich-199563-lien-vers-site-internet");
            string target = "https://codes-sources.commentcamarche.net/forum/affich-199563-lien-vers-site-internet";
            //Use no more than one assignment when you test this code.
            //string target = "ftp://ftp.microsoft.com";
            //string target = "C:\\Program Files\\Microsoft Visual Studio\\INSTALL.HTM";
            System.Diagnostics.Process.Start(target);
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }*/

        



        // Les 6 méthodes suivantes permettent de pouvoir afficher des informations grâce à un site internet externe

        private void OuvrirInformationPizza4Fromages(object sender, RoutedEventArgs e)
        {
            string target = "https://www.cuisineaz.com/recettes/pizza-aux-quatre-fromages-1246.aspx";
           
            try
            {
                Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void OuvrirInformationPizzaChorizo(object sender, RoutedEventArgs e)
        {
            string target = "https://www.cuisineaz.com/recettes/pizza-au-chorizo-62572.aspx";
           
            try
            {
                Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void OuvrirInformationPizzaVegetarienne(object sender, RoutedEventArgs e)
        {
            string target = "https://www.cuisineaz.com/recettes/pizza-vegetarienne-54979.aspx";
            
            try
            {
                Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void OuvrirInformationCoca(object sender, RoutedEventArgs e)
        {
            string target = "https://www.coca-cola-france.fr/faq/quelles-sont-les-compositions-de-coca-cola-original-taste-et-coca-cola-zero-sucres#:~:text=Coca%E2%80%91Cola%20original%20taste%20%3A%20Eau,extraits%20v%C3%A9g%C3%A9taux)%2C%20dont%20caf%C3%A9ine.";
           
            try
            {
                Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void OuvrirInformationJusDOrange(object sender, RoutedEventArgs e)
        {
            string target = "https://www.cuisineaz.com/recettes/jus-d-orange-au-thermomix-98481.aspx";
            
            try
            {
                Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void OuvrirInformationIceTea(object sender, RoutedEventArgs e)
        {
            string target = "https://fr.openfoodfacts.org/produit/8474034088877/lipton-ice-tea-saveur-peche";
         
            try
            {
               Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
}
