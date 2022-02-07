using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Menu_pizza_poo_v2
{
    public class Livreur : Personne, IEquatable<Livreur>
    {
        // Attribut :

        private string moyendetransport;
        private string etat;
        private Commande commande;
        private List<Commande> commandes = new List<Commande> { };
        private int numTel;


        // Constructeur :
        public Livreur() { }

        /// <summary>
        ///  Constructeur d'une instance de la classe Livreur
        /// </summary>
        /// <param name="nom">Nom de famille du livreur</param>
        /// <param name="prenom">Prénom du livreur</param>
        /// <param name="adresse">Adresse du livreur</param>
        /// <param name="numerodetel">Numéro de téléphone du livreur</param>
        /// <param name="etat">État de travail du livreur</param>
        /// <param name="moyendetransport">Moyen de transport du livreur</param>
        /// <param name="commande">Commande active du livreur</param>
        public Livreur(string nom, string prenom, string adresse, int numerodetel, string etat, string moyendetransport, Commande commande) : base(nom, prenom, adresse)
        {
            this.numTel = numerodetel;
            this.etat = etat;
            this.moyendetransport = moyendetransport;
            this.commande = commande;
            this.commandes = new List<Commande> { };
            this.commandes.Add(commande);
        }

        /// <summary>
        /// Constructeur d'une instance de la classe Livreur
        /// </summary>
        /// <param name="nom">Nom de famille du livreur</param>
        /// <param name="prenom">Prénom du livreur</param>
        /// <param name="adresse">Adresse du livreur</param>
        /// <param name="numerodetel">Numéro de téléphone du livreur</param>
        /// <param name="etat">État de travail du livreur</param>
        /// <param name="moyendetransport">Moyen de transport du livreur</param>
        public Livreur(string nom, string prenom, string adresse, int numerodetel, string etat, string moyendetransport) : base(nom, prenom, adresse)
        {
            this.numTel = numerodetel;
            this.etat = etat;
            this.moyendetransport = moyendetransport;
            this.commande = new Commande();
            this.commandes = new List<Commande> { };
        }



        // Propriété : list de commande

        public string MoyendeTransport
        {
            get
            {
                return this.moyendetransport;
            }
        }

        public string Etat
        {
            get
            {
                return this.etat;
            }
            set
            {
                this.etat = value;
            }
        }
        public int NumTel
        {
            get { return this.numTel; }
        }
        public Commande Commandedulivreur
        {
            get
            {
                return this.commande;
            }
            set
            {
                this.commande = value;
            }
        }

        public List<Commande> CommandeGerer
        {
            get
            {
                return this.commandes;
            }
            set
            {
                this.commandes = value;
            }
        }
        // Méthodes :

        public override string ToString()
        {
            string result = base.ToString() + " et son moyen de transport est : " + this.moyendetransport + " et ses commandes sont ";

            for (int i = 0; i < commandes.Count; i++)
            {
                result += commandes[i].ToString();
            }
            return result;
        }

        /// <summary>
        /// Permet de lire un .csv contenant une liste de livreurs
        /// </summary>
        /// <returns>La liste de livreurs contenue dans le .csv</returns>
        static public List<Livreur> LectureFichier()
        {
            string ligne;
            List<Livreur> livreurs = new List<Livreur> { };
            int compteur = 0;
            List<string> liste = new List<string> { };
            StreamReader line = new StreamReader("Livreurs.csv");
            while ((ligne = line.ReadLine()) != null)
            {
                String[] substrings = ligne.Split(';');
                foreach (var substring in substrings)
                {
                    liste.Add(substring);
                }
                compteur++;
            }
            line.Close();
            for (int i = 0; i < liste.Count; i++)
            {
                if (i % 6 == 0)
                {
                    if (liste[i + 4] == "surplace" || liste[i + 4] == "Sur place")
                    {
                        livreurs.Add(new Livreur(liste[i], liste[i + 1], liste[i + 2], Convert.ToInt32(liste[i + 3]), "Sur place", liste[i + 5]));
                    }
                    if (liste[i + 4] == "enconges" || liste[i + 4] == "En congés")
                    {
                        livreurs.Add(new Livreur(liste[i], liste[i + 1], liste[i + 2], Convert.ToInt32(liste[i + 3]), "En congés", liste[i + 5]));
                    }
                    if (liste[i + 4] == "enlivraison" || liste[i + 4] == "En livraison")
                    {
                        livreurs.Add(new Livreur(liste[i], liste[i + 1], liste[i + 2], Convert.ToInt32(liste[i + 3]), "En livraison", liste[i + 5]));
                    }
                }
            }
            return livreurs;
        }

        /// <summary>
        /// Permet d'ajouter un livreur à un .csv
        /// </summary>
        /// <param name="livreur">Livreur à ajouter au .csv</param>
        public static void AjoutLivreurCSV(Livreur livreur)
        {
            using (var w = new StreamWriter(("Livreurs.csv"), true))
            {
                string line = string.Format("{0};{1};{2};{3};{4};{5}", livreur.NomFamille, livreur.Prenom, livreur.Adresse, livreur.NumTel.ToString(), livreur.Etat, livreur.MoyendeTransport);
                w.WriteLine(line);
            }
        }
        public override bool Equals(object b)
        {
            return Equals(b);
        }
        public bool Equals(Livreur b)
        {
            if ((this.Prenom == b.Prenom && this.NomFamille == b.NomFamille) || this.NumTel == b.NumTel) { return true; }
            return false;
        }

        /// <summary>
        /// Permet de modifier l'état de la commande active du livreur
        /// </summary>
        public void EtatLivraison()
        {
            if(this.commande.EtatCommande == "En livraison")
            {
                this.etat = "En livraison";
            }
            if(this.commande.EtatCommande == "Arrivée")
            {
                this.etat = "Sur place";
            }
        }
    }
}
