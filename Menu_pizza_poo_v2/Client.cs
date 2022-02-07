using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    public class Client : Personne, IEquatable<Client>
    {
        // Attributs

        private static int compteurclients = 10;

        private int numTel;
        private DateTime datePremiereCommande;
        private List<Commande> commandes;
        private int numClient;
        private int achatscumulés;
        private string ville;

        // Constructeurs :

        /// <summary>
        /// Constructeur d'une instance de la classe Client
        /// </summary>
        /// <param name="nomFamille">Nom de famille du client</param>
        /// <param name="prenom">Prénom du client</param>
        /// <param name="adresse">Adresse du client</param>
        /// <param name="numTel">Numéro de téléphone du client</param>
        public Client(string nomFamille, string prenom, string adresse, int numTel) : base(nomFamille, prenom, adresse)
        {
            this.numTel = numTel;
            this.datePremiereCommande = DateTime.Now;
            this.commandes = new List<Commande> { };
            Client.compteurclients++;
            this.numClient = compteurclients;
            this.achatscumulés = 0;
            int compt = 0;
            string tamp = "";
            this.ville = adresse;
            if (adresse.Contains(" "))
            {
                while (adresse[adresse.Length - (compt + 1)] != ' ')
                {
                    tamp = String.Concat(tamp, adresse[adresse.Length - (compt + 1)]);
                    compt++;
                }
                this.ville = Client.Reverse(tamp);
            }
        }

        /// <summary>
        /// Permet d'inverser une chaîne de caractères
        /// </summary>
        /// <param name="text">Texte à inverser</param>
        /// <returns>Le texte inversé</returns>
        public static string Reverse(string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }

        /// <summary>
        /// Permet de lire un fichier .csv contenant une liste de clients
        /// </summary>
        /// <returns>La liste de clients contenue dans le .csv</returns>
        public static List<Client> LectureFichier()
        {
            string ligne;
            List<Client> clients = new List<Client> { };
            int compteur = 0;
            List<string> liste = new List<string> { };
            StreamReader line = new StreamReader("Clients.csv");
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
                if (i % 5 == 1)
                {
                    clients.Add(new Client(liste[i], liste[i + 1], liste[i + 2], Convert.ToInt32(liste[i + 3])));
                }
            }
            return clients;
        }

        /// <summary>
        /// Permet d'ajouter un client à un .csv
        /// </summary>
        /// <param name="client">Instance de client à ajouter au .csv</param>
        public static void AjoutClientCSV(Client client)
        {
            using (var w = new StreamWriter(("Clients.csv"), true))
            {
                string line = string.Format("{0};{1};{2};{3};{4}", client.numClient, client.NomFamille, client.Prenom, client.Adresse, client.NumTel.ToString());
                w.WriteLine(line);
            }
        }
        public Client(int numTel)
        {
            this.numTel = numTel;
        }
        public int NumTel
        {
            get { return this.numTel; }
        }
        public DateTime DatePremiereCommande
        {
            get { return this.datePremiereCommande; }
        }
        public List<Commande> Commandes
        {
            get { return this.commandes; }
        }
        public int AchatsCumulés
        {
            get { return this.achatscumulés; }
            set { this.achatscumulés = value; }
        }
        public string Ville
        {
            get { return this.ville; }
        }

        public override string ToString()
        {
            return base.ToString() + ", n° de téléphone : " + this.numTel + ", date de la première commande : " + this.datePremiereCommande.ToShortDateString();
        }

        public bool Egal(Client b)
        {
            if (this.numTel == b.numTel) { return true; }
            return false;
        }
        public override bool Equals(object b)
        {
            return Equals(b);
        }
        public bool Equals(Client b)
        {
            if ((this.Prenom == b.Prenom && this.NomFamille == b.NomFamille) || this.NumTel == b.NumTel) { return true; }
            return false;
        }
    }
}
