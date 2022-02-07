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
    /// Logique d'interaction pour PageStatistique.xaml
    /// </summary>
    public partial class PageStatistique : Page, IStatistique
    {
        // Attributs :
        
        private List<string> ItemDeCommande = new List<string>();
        private List<int> PrixDeCommande = new List<int>();
        private List<int> QuantiteItemCommande = new List<int>();
        private int compteur;
        private List<string> NomCommis = new List<string>();
        private List<string> NomLivreur = new List<string>();
        private List<string> NomDuLivreur = new List<string>();
        private List<string> NomDuCommis = new List<string>();
        private List<DateTime> DateDeCommande = new List<DateTime>();
        private List<int> NumeroDeCommande = new List<int>();
        private int[] tableauNombredeCommandeGererCommis;
        private int[] tableauNombredeLivraisonsEffectues;

        // Constructeurs :

        public PageStatistique()
        {
            // compteur pur qu'à chaque fois qu'on appuie sur le bouton stat, un graph different apparait
            /*if (compteur >= 2)
            {
                compteur = 0;
            }
            else
            {
                compteur++;
            }*/

            InitializeComponent();
           
        }
        public PageStatistique(int compteur)
        {
            this.compteur = compteur;
            InitializeComponent();
        }

        // Propriétés :
        public List<string> ITEMDeCommande
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
        public List<int> PRIXDeCommande
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
        public List<int> QUANTITEItemCommande
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

        public List<string> NOMCommis
        {
            get
            {
                return this.NomCommis;
            }
            set
            {
                this.NomCommis = value;
            }

        }
        public List<string> NOmLivreur
        {
            get
            {
                return this.NomDuLivreur;
            }
            set
            {
                this.NomDuLivreur = value;
            }

        }
        public List<string> NOMDuLivreur
        {
            get
            {
                return this.NomDuLivreur;
            }
            set
            {
                this.NomDuLivreur = value;
            }

        }

        public List<string> NOMDuCommis
        {
            get
            {
                return this.NomDuCommis;
            }
            set
            {
                this.NomDuCommis = value;
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

        public List<int> NUMERODeCommande
        {
            get
            {
                return this.NumeroDeCommande;
            }
            set
            {
                this.NumeroDeCommande = value;
            }

        }

        public int[] TABLEAUNombredeCommandeGererCommis
        {

            get
            {
                return this.tableauNombredeCommandeGererCommis;
            }
            set
            {
                this.tableauNombredeCommandeGererCommis = value;
            }


        }

        public int[] TABLEAUNombredeLivraisonsEffectues
        {

            get
            {
                return this.tableauNombredeLivraisonsEffectues;
            }
            set
            {
                this.tableauNombredeLivraisonsEffectues = value;
            }


        }

        // Méthodes pour lire dans les fichiers Excel les nombres de commandes et livraisons faites par les salariés

        public void LectureFichierCommandes()
        {
            List<int> HeureDeCommande = new List<int>();
            List<int> NumeroDuClient = new List<int>();
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
                /*if (i % 9 == 0 && gamma[i] == " " && gamma[i] != null && gamma[i]!="")
                {
                    descriptionCommande.Add(gamma[i]);
                }*/
                if (i > 9 && i % 9 != 0 && gamma[i] != " " && gamma[i] != "" && gamma[i] != null)
                {
                    this.NumeroDeCommande.Add(Convert.ToInt32(gamma[i]));
                    string beta = gamma[i + 1].ToUpper();
                    string[] words = beta.Split('H');
                    HeureDeCommande.Add(Convert.ToInt32(words[0]));
                    this.DateDeCommande.Add(Convert.ToDateTime(gamma[i + 2]));
                    NumeroDuClient.Add(Convert.ToInt32(gamma[i + 3]));
                    this.NomCommis.Add(Convert.ToString(gamma[i + 4]));
                    this.NomLivreur.Add(Convert.ToString(gamma[i + 5]));
                    EtatCommande.Add(Convert.ToString(gamma[i + 6]));
                    SoldeCommande.Add(Convert.ToString(gamma[i + 7]));
                    i = i + 8;
                }
            }
        }

        public void LectureFichierDetailsLivreur()
        {
            List<string> PrenomDuLivreur = new List<string>();
            List<string> AdresseDuLivreur = new List<string>();
            List<int> NumeroDuTelephone = new List<int>();
            List<string> EtatDuLivreur = new List<string>();
            List<string> MoyenDeLocomotionDuLivreur = new List<string>();

            string nomFich = ("Livreurs.csv");

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
            List<string> descriptionLivreur = new List<string>();

            for (int i = 0; i < gamma.Count; i++)
            {
                if (i == 0 && i % 7 == 0)
                {
                    descriptionLivreur.Add(gamma[i]);

                }
                if (i == 1)
                {
                    this.NomDuLivreur.Add(Convert.ToString(gamma[1]));
                }
                if (i > 7 && i % 7 != 0)
                {
                    this.NomDuLivreur.Add(Convert.ToString(gamma[i]));
                    PrenomDuLivreur.Add(Convert.ToString(gamma[i + 1]));
                    AdresseDuLivreur.Add(Convert.ToString(gamma[i + 2]));
                    NumeroDuTelephone.Add(Convert.ToInt32(gamma[i + 3]));
                    EtatDuLivreur.Add(Convert.ToString(gamma[i + 4]));
                    MoyenDeLocomotionDuLivreur.Add(Convert.ToString(gamma[i + 5]));
                    i = i + 6;
                }

            }
        }
        public void LectureFichierDetailsCommis()
        {
            List<string> PrenomDuCommis = new List<string>();
            List<string> AdresseDuLivreur = new List<string>();
            List<string> EtatDuCommis = new List<string>();

            string nomFich = ("Commis.csv");

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
            List<string> descriptionLivreur = new List<string>();

            for (int i = 0; i < gamma.Count; i++)
            {
                if (i == 0 && i % 7 == 0)
                {
                    descriptionLivreur.Add(gamma[i]);

                }
                if (i == 1)
                {
                    NomDuCommis.Add(gamma[i]);
                }

                if (i > 7 && i % 7 != 0)
                {
                    this.NomDuCommis.Add(Convert.ToString(gamma[i]));
                    PrenomDuCommis.Add(Convert.ToString(gamma[i + 1]));
                    AdresseDuLivreur.Add(Convert.ToString(gamma[i + 2]));
                    EtatDuCommis.Add(Convert.ToString(gamma[i + 4]));
                    i = i + 6;
                }

            }
        }


        // Méthodes pour obtenir les nombres de commandes et livraisons faites par les salariés

        public int[] NombredeCommandeGererCommis()
        {
            int result = 1;
            int compteur = 0;
            int[] tab = new int[NomDuCommis.Count];
            for (int i = 0; i <= NomDuCommis.Count - 1; i++)
            {
                for (int j = 0; j <= NumeroDeCommande.Count - 1; j++)
                {
                    if (NomCommis[j].ToUpper() == NomDuCommis[i].ToUpper())
                    {
                        tab[compteur] = result;
                        result++;
                    }
                }
                if (result == 1) tab[compteur] = 0;
                result = 1;
                compteur++;
            }
            return tab;
        }

        public int[] NombredeLivraisonsEffectues()
        {
            int result = 1;
            int compteur = 0;
            int[] tab = new int[NomDuLivreur.Count];
            for (int i = 0; i <= NomDuLivreur.Count - 1; i++)
            {
                for (int j = 0; j <= this.NumeroDeCommande.Count - 1; j++)
                {
                    if (this.NomLivreur[j].ToUpper() == this.NomDuLivreur[i].ToUpper())
                    {
                        tab[compteur] = result;
                        result++;
                    }

                }
                if (result == 1) tab[compteur] = 0;
                result = 1;
                compteur++;
            }
            return tab;
        }






        /// <summary>
        /// Méthode permettant l'obtention d'un graphique pour les commandes gérer par commis et les commandes livrées par livreur :
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LectureFichierCommandes();
            LectureFichierDetailsLivreur();
            LectureFichierDetailsCommis();
            
            this.tableauNombredeCommandeGererCommis = NombredeCommandeGererCommis();
            this.tableauNombredeLivraisonsEffectues = NombredeLivraisonsEffectues();

          
            
            double margin = 5;
            double xmin = 0;
            double xmax = Graphique.Width - margin;
           
            double ymax = Graphique.Height - margin;
            const double step = 50;
            const double stepbis = 10;
            
            
            // On trace l'abscisse des X

            GeometryGroup X = new GeometryGroup();
            X.Children.Add(new LineGeometry(new Point(0, 200), new Point(Graphique.Width, 200)));
            for (double x = xmin + step; x <= xmax - step; x += step)
            {
                X.Children.Add(new LineGeometry(new Point(x, 200 - margin / 2), new Point(x, 200 + margin / 2)));
            }

            Path XAbsicisse = new Path();
            XAbsicisse.StrokeThickness = 1;
            XAbsicisse.Stroke = Brushes.White;
            XAbsicisse.Data = X;

            Graphique.Children.Add(XAbsicisse);

            // On trace l'ordonnée des Y

            GeometryGroup Y = new GeometryGroup();
            Y.Children.Add(new LineGeometry(new Point(xmin, 0), new Point(xmin, Graphique.Height)));
            for (double y = stepbis; y <= ymax; y += stepbis)
            {
                Y.Children.Add(new LineGeometry(new Point(xmin - margin / 2, y), new Point(xmin + margin / 2, y)));
            }

            Path YAbsicisse = new Path();
            YAbsicisse.StrokeThickness = 1;
            YAbsicisse.Stroke = Brushes.White;
            YAbsicisse.Data = Y;

            Graphique.Children.Add(YAbsicisse);


            // Un Tableau de Brush qui permet d'avoir une couleur pour les lignes graphiques 

            Brush[] CouleurdesLignesGraphiques = { Brushes.Aqua, Brushes.Black, Brushes.Blue, Brushes.DarkSalmon };
          
            // Avec le compteur à chaque fois qu'on appuie sur le bouton l'un des deux graphiques s'affichent
            // mettre un message box qui affiche le nom du graphique fait ( donc deux messages box ) à la place de la méthode DrawText

            if (this.compteur % 2 == 0)
            {
                MessageBox.Show("Graphique des nombres de commandes géré par commis");
                Random a = new Random();

                PointCollection alpha = new PointCollection();
                for (int i = 0; i < this.tableauNombredeCommandeGererCommis.Length; i++)
                {
                    alpha.Add(new Point((i + 1) * step, ((20 - tableauNombredeCommandeGererCommis[i]) * stepbis)));
                }
                Polyline polyline = new Polyline();
                polyline.StrokeThickness = 1;
                polyline.Stroke = CouleurdesLignesGraphiques[a.Next(0,4)];
                polyline.Points = alpha;

                Graphique.Children.Add(polyline);
                Point title_location = new Point(100, 30);
                

            }
            else
            {
                MessageBox.Show("Graphique des nombres de commandes livré par livreurs");
                Random a = new Random();

                PointCollection beta = new PointCollection();
                for (int i = 0; i <= this.tableauNombredeLivraisonsEffectues.Length - 1; i++)
                {
                    Point gamma = new Point((i + 1) * step, ((20 - this.tableauNombredeLivraisonsEffectues[i]) * stepbis));
                    beta.Add(gamma);
                }
                Polyline polyline2 = new Polyline();
                polyline2.StrokeThickness = 1;
                polyline2.Stroke = CouleurdesLignesGraphiques[a.Next(0, 4)];
                polyline2.Points = beta;

                Graphique.Children.Add(polyline2);
                Point title_location = new Point(100, 30);
               

            }
        }


    }
}
