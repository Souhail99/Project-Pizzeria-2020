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
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using Path = System.Windows.Shapes.Path;

namespace Menu_pizza_poo_v2
{
    /// <summary>
    /// Logique d'interaction pour PageMoyenne.xaml
    /// </summary>
    public partial class PageMoyenne : Page, IMoyenne
    {
        // Attributs :

        private int nombredejour;
        private List<string> ItemDeCommande = new List<string>();
        private List<int> PrixDeCommande = new List<int>();
        private List<int> QuantiteItemCommande = new List<int>();
        private List<DateTime> DateDeCommande = new List<DateTime>();

        // Constructeurs :

        public PageMoyenne()
        {
            LectureFichierDetailsCommandes();
            InitializeComponent();

        }

        // Propriétés :

        public List<string> ITemDeCommande
        {
            get
            {
                return this.ItemDeCommande;
            }
            set
            {
                this.ItemDeCommande = value;
            }

        }
        public List<int> PRixDeCommande
        {
            get
            {
                return this.PrixDeCommande;
            }
            set
            {
                this.PrixDeCommande = value;
            }

        }
        public List<int> QUantiteItemCommande
        {
            get
            {
                return this.QuantiteItemCommande;
            }
            set
            {
                this.QuantiteItemCommande = value;
            }

        }
        public List<DateTime> DATEDeCommande
        {
            get
            {
                return this.DateDeCommande;
            }
            set
            {
                this.DateDeCommande = value;
            }
        }

        // Méethodes qui les les fichier csv : les deux suivantes :
       
        public void LectureFichierCommandes()
        {
            List<int> NumeroDeCommande = new List<int>();
            List<int> HeureDeCommande = new List<int>();
            List<int> NumeroDuClient = new List<int>();
            List<string> NomCommis = new List<string>();
            List<string> NomLivreur = new List<string>();
            List<string> EtatCommande = new List<string>();
            List<string> SoldeCommande = new List<string>();

            string nomFich = ("Commandes.csv");

            StreamReader fichLect = new StreamReader(nomFich);
            string ligne = " ";
            int compteur = 0;
            List<string> gamma = new List<string>();
            while (fichLect.Peek() > 0)
            {
                ligne = fichLect.ReadLine();
                gamma.Add(ligne);
                compteur++;
                string[] words = ligne.Split(';');
                foreach (var word in words)
                {
                    gamma.Add(word);
                }
            }
            List<string> descriptionCommande = new List<string>();
            for (int i = 0; i < gamma.Count; i++)//i=9
            {
                if (i % 9 == 0)
                {
                    descriptionCommande.Add(gamma[i]);
                }

                if (i > 9 && i % 9 != 0)
                {
                    NumeroDeCommande.Add(Convert.ToInt32(gamma[i]));
                    string beta = gamma[i + 1].ToUpper();
                    string[] words = beta.Split('H');
                    HeureDeCommande.Add(Convert.ToInt32(words[0]));
                    this.DateDeCommande.Add(Convert.ToDateTime(gamma[i + 2]));
                    NumeroDuClient.Add(Convert.ToInt32(gamma[i + 3]));
                    NomCommis.Add(Convert.ToString(gamma[i + 4]));
                    NomLivreur.Add(Convert.ToString(gamma[i + 5]));
                    EtatCommande.Add(Convert.ToString(gamma[i + 6]));
                    SoldeCommande.Add(Convert.ToString(gamma[i + 7]));
                    i = i + 8;
                }
            }
        }

        public void LectureFichierDetailsCommandes()
        {
            List<int> NumeroDeCommande = new List<int>();
            List<string> TypeDeLaPizza = new List<string>();
            List<string> TailleDeLaPizza = new List<string>();
            List<int> VolumeDeLaBoisson = new List<int>();

            string nomFich = ("DetailsCommandes.csv");

            StreamReader fichLect = new StreamReader(nomFich);
            string ligne = " ";
            int compteur = 0;
            List<string> gamma = new List<string>();
            while (fichLect.Peek() > 0)
            {
                ligne = fichLect.ReadLine();
                gamma.Add(ligne);
                compteur++;
                string[] words = ligne.Split(';');
                foreach (var word in words)
                {
                    gamma.Add(word);
                }
            }

            List<string> descriptionCommande = new List<string>();
            for (int i = 0; i < gamma.Count; i++)//i==8
            {
                if (i == 0 && i % 8 == 0)
                {
                    descriptionCommande.Add(gamma[i]);
                }
                
                if (i > 8 && i % 8 != 0)
                {
                    NumeroDeCommande.Add(Convert.ToInt32(gamma[i]));
                    this.ItemDeCommande.Add(Convert.ToString(gamma[i + 1]));
                    this.PrixDeCommande.Add(Convert.ToInt32(gamma[i + 2]));
                    TypeDeLaPizza.Add(Convert.ToString(gamma[i + 3]));
                    TailleDeLaPizza.Add(Convert.ToString(gamma[i + 4]));

                    if (gamma[i + 1] != "Pizza")
                    {
                        VolumeDeLaBoisson.Add(Convert.ToInt32(gamma[i + 5]));
                    }

                    this.QuantiteItemCommande.Add(Convert.ToInt32(gamma[i + 6]));
                    i = i + 7;
                }
            }
        }

        /// <summary>
        /// Fait la moyenne des pris des commandes dans le fichier csv
        /// </summary>
        /// <returns>la moyenne</returns>
        public double MoyennedesPrixdesCommandes()
        {
            //LectureFichierDetailsCommandes();
            double result = 0;
            for (int i = 0; i <= this.PrixDeCommande.Count - 1; i++)
            {
                result += PrixDeCommande[i];
                if (i > 5)
                {
                    result += PrixDeCommande[i] * this.QuantiteItemCommande[i];
                }
            }
            result = result / this.PrixDeCommande.Count;
            return result;
        }

        /// <summary>
        /// Fait la moyenne des pizas par commandes
        /// </summary>
        /// <returns>la moyenne</returns>
        public double MoyennedesComptesClients()
        {
            LectureFichierDetailsCommandes();
            double result = 0;
            for (int i = 0; i <= this.PrixDeCommande.Count - 1; i++)
            {
                if (this.ItemDeCommande[i] == "Pizza")
                {
                    result += this.QuantiteItemCommande[i];
                }
            }
            result = result / this.PrixDeCommande.Count;
            return result;
        }

        /// <summary>
        /// Permet d'obtenir le nombre de commandes selon une periode de temps avec en entrée le nombre de jour
        /// </summary>
        /// <param name="jour"> le nombre de jour depuis aujourd'hui</param>
        /// <returns>le nombre de commande</returns>
        public int NombredeCommandesSelonPeriodedeTemps(int jour)
        {
            LectureFichierCommandes();
            int result = 0;
            for (int i = 0; i <= DateDeCommande.Count - 1; i++)
            {
                if (DateTime.Now.Day - jour <= DateDeCommande[i].Day)
                {
                    result++;
                }
            }
            return result;
        }

        
        private void OuvreMoyennedesPrixdesCommandes(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("La moyenne des prix des commandes est : " + MoyennedesPrixdesCommandes());
        }

        private void OuvreMoyennedesComptesClients(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("La moyenne des comptes clients (le nombre moyen de pizza par commande) est : " + MoyennedesComptesClients());
        }

        private void OuvreNombredeCommandesSurUnNombredeJour(object sender, RoutedEventArgs e)
        {
            if (Entrez_un_nombre_de_jour == null || Entrez_un_nombre_de_jour.Text=="")
            {
                MessageBox.Show("Vous vous êtes trompé ! ce n'est pas un chiffre, réessayez !", "Fenêtre", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                this.nombredejour = Convert.ToInt32(Entrez_un_nombre_de_jour.Text);
                //alpha = TextBox.Text;
                int alpha = NombredeCommandesSelonPeriodedeTemps(this.nombredejour);
                if (nombredejour <= 1)
                {
                    MessageBox.Show("Voici le nombre de commande en " + this.nombredejour + " jour, depuis aujourd'hui le " + "( " + DateTime.Now + " ) qui est : " + alpha, "Fenêtre", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Voici le nombre de commande en " + this.nombredejour + " jours, depuis aujourd'hui le "+"( "+ DateTime.Now +" ) qui est : " + alpha, "Fenêtre", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
