using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Menu_pizza_poo_v2
{
    public class Commande
    {
        // Attributs :

        static int numerodecommande;
        Pizza[] pizzas;
        List<Boissons> boissons;
        int prix;
        string etatcommande;
        int numcommande;
        int numTelAssocié;
        DateTime dt;
        int heure;
        Commis com;
        Livreur liv;
        static bool lecture = true;

        // Constructeurs :

        public Commande() { }

        /// <summary>
        /// Constructeur d'une instance de la classe Commande
        /// </summary>
        /// <param name="pizzas">Liste de pizzas de la commande</param>
        /// <param name="prix">Prix de la commande</param>
        /// <param name="bois">Liste de boissons de la commande</param>
        public Commande(Pizza[] pizzas, int prix, List<Boissons> bois)
        {
            this.pizzas = pizzas;
            this.boissons = bois;
            this.prix = prix;
            if (lecture) LectureFichierCommandes(); Commande.lecture = false;
            Commande.numerodecommande++;
            this.etatcommande = "En préparation";
            this.numcommande = Commande.numerodecommande;
            this.dt = DateTime.Now;
            this.heure = DateTime.Now.Hour;
        }

        /// <summary>
        /// Constructeur d'une instance de la classe Commande
        /// </summary>
        /// <param name="pizzas">Liste de pizzas de la commande</param>
        /// <param name="prix">Prix de la commande</param>
        /// <param name="numTelAssocié">Numéro du client ayant passé commande</param>
        /// <param name="bois">Liste de boissons de la commande</param>
        public Commande(Pizza[] pizzas, int prix, int numTelAssocié, List<Boissons> bois)
        {
            this.pizzas = pizzas;
            this.boissons = bois;
            this.prix = prix;
            if (lecture) LectureFichierCommandes(); Commande.lecture = false;
            Commande.numerodecommande++;
            this.etatcommande = "En préparation";
            this.numcommande = Commande.numerodecommande;
            this.numTelAssocié = numTelAssocié;
            this.dt = DateTime.Now;
            this.heure = DateTime.Now.Hour;
        }

        /// <summary>
        /// Constructeur d'une instance de la classe Commande
        /// </summary>
        /// <param name="pizzas">Liste de pizzas de la commande</param>
        /// <param name="prix">Prix de la commande</param>
        /// <param name="numTelAssocié">Numéro du client ayant passé commande</param>
        /// <param name="bois">Liste de boissons de la commande</param>
        /// <param name="com">Commis en charge</param>
        /// <param name="liv">Livreur en charge</param>
        /// <param name="numtel">Numéro de tel</param>
        public Commande(Pizza[] pizzas, int prix, List<Boissons> bois, Commis com, Livreur liv, int numtel, int numcommande)
        {
            this.pizzas = pizzas;
            this.boissons = bois;
            this.prix = prix;
            if (lecture) LectureFichierCommandes(); Commande.lecture = false;
            this.etatcommande = "En préparation";
            this.numcommande = numcommande;
            this.dt = DateTime.Now;
            this.heure = DateTime.Now.Hour;
            this.com = com;
            this.liv = liv;
            this.numTelAssocié = numtel;
        }
        public int NumeroDeCommande
        {
            get { return this.numcommande; }
        }
        public Pizza[] Pizzas
        {
            get { return this.pizzas; }
            set { this.pizzas = value; }
        }
        public int Prix
        {
            get { return this.prix; }
            set { this.prix = value; }
        }
        public string EtatCommande
        {
            get { return this.etatcommande; }
            set { this.etatcommande = value; }
        }
        public int NumTelAssocié
        {
            get { return this.numTelAssocié; }
        }
        public List<Boissons> Boisson
        {
            get { return this.boissons; }
        }


        public void LectureFichierCommandes()
        {
            List<int> NumeroDeCommande = new List<int>();
            List<int> HeureDeCommande = new List<int>();
            List<int> NumeroDuClient = new List<int>();
            List<string> NomCommis = new List<string>();
            List<string> NomLivreur = new List<string>();
            List<string> EtatCommande = new List<string>();
            List<string> SoldeCommande = new List<string>();
            List<DateTime> DateDeCommande = new List<DateTime>();

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
                    DateDeCommande.Add(Convert.ToDateTime(gamma[i + 2]));
                    NumeroDuClient.Add(Convert.ToInt32(gamma[i + 3]));
                    NomCommis.Add(Convert.ToString(gamma[i + 4]));
                    NomLivreur.Add(Convert.ToString(gamma[i + 5]));
                    EtatCommande.Add(Convert.ToString(gamma[i + 6]));
                    SoldeCommande.Add(Convert.ToString(gamma[i + 7]));
                    i = i + 8;
                }
            }
            Commande.numerodecommande = NumeroDeCommande[NumeroDeCommande.Count - 1];
            fichLect.Close();
        }

        public override string ToString()
        {
            string str = "";

            int compteurFrom = 0;
            int compteurChor = 0;
            int compteurVege = 0;

            int compteurCoca = 0;
            int compteurJusOrange = 0;
            int compteurIceTea = 0;

            Pizza pizzaFrom = new Pizza();
            Pizza pizzaChor = new Pizza();
            Pizza pizzaVege = new Pizza();

            Boissons coca = new Boissons();
            Boissons jusOrange = new Boissons();
            Boissons iceTea = new Boissons();

            foreach (Pizza piz in this.pizzas)
            {
                if (piz.Type == "4 fromages") { compteurFrom++; pizzaFrom = piz; }
                if (piz.Type == "chorizo") { compteurChor++; pizzaChor = piz; }
                if (piz.Type == "végétarienne") { compteurVege++; pizzaVege = piz; }
            }

            foreach (Boissons bois in this.boissons)
            {
                if (bois.Nom == "Coca") { compteurCoca++; coca = bois; }
                if (bois.Nom == "Jus d'orange") { compteurJusOrange++; jusOrange = bois; }
                if (bois.Nom == "Ice Tea") { compteurIceTea++; iceTea = bois; }
            }

            if (compteurFrom > 0) { str += "\n" + compteurFrom + " * " + pizzaFrom.ToString(); }
            if (compteurChor > 0) { str += "\n" + compteurChor + " * " + pizzaChor.ToString(); }
            if (compteurVege > 0) { str += "\n" + compteurVege + " * " + pizzaVege.ToString(); }

            if (compteurCoca > 0) { str += "\n" + compteurCoca + " * " + coca.ToString(); }
            if (compteurJusOrange > 0) { str += "\n" + compteurJusOrange + " * " + jusOrange.ToString(); }
            if (compteurIceTea > 0) { str += "\n" + compteurIceTea + " * " + iceTea.ToString(); }

            return str;
        }
        public static bool operator ==(Commande a, Commande b)
        {
            if (a == null && b != null) { return false; }
            if (a != null && b == null) { return false; }
            if (a == null && b == null) { return true; }
            if (a.NumeroDeCommande == b.NumeroDeCommande && a.Prix == b.Prix) { return true; }
            return false;
        }
        public static bool operator !=(Commande a, Commande b)
        {
            if (a == null && b != null) { return true; }
            if (a != null && b == null) { return true; }
            if (a == null && b == null) { return false; }
            if (a.NumeroDeCommande == b.NumeroDeCommande && a.Prix == b.Prix) { return false; }
            return true;
        }
        public static void AjoutCommandeCSV(Commande commande)
        {
            using (var w = new StreamWriter(("Commandes.csv"), true))
            {
                string line = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", commande.NumeroDeCommande, commande.heure + "H", commande.dt.ToShortDateString(), commande.numTelAssocié, commande.com.NomFamille, commande.liv.NomFamille, "fermee", "ok");
                w.WriteLine(line);
            }
            using (var y = new StreamWriter(("DetailsCommandes.csv"), true))
            {
                int nbFrom = 0;
                int nbVege = 0;
                int nbChori = 0;
                Pizza from = new Pizza();
                Pizza vege = new Pizza();
                Pizza chori = new Pizza();
                foreach(Pizza pizza in commande.pizzas)
                {
                    if (pizza.Type == "végétarienne")
                    {
                        nbVege++;
                        vege = pizza;
                    }
                    else
                    {
                        if (pizza.Type == "4 fromages")
                        {
                            nbFrom++;
                            from = pizza;
                        }
                        else
                        {
                            if (pizza.Type == "chorizo")
                            {
                                nbChori++;
                                chori = pizza;
                            }
                        }
                    }
                }
                if(nbFrom>0)
                {
                    string strf = string.Format("{0};{1};{2};{3};{4};{5};{6}", commande.NumeroDeCommande,"Pizza", from.Prix, from.Type, from.Taille, "", nbFrom);
                    y.WriteLine(strf);
                }
                if (nbVege > 0)
                {
                    string strv = string.Format("{0};{1};{2};{3};{4};{5};{6}", commande.NumeroDeCommande, "Pizza", vege.Prix, vege.Type, vege.Taille, "", nbVege);
                    y.WriteLine(strv);
                }
                if (nbChori > 0)
                {
                    string strc = string.Format("{0};{1};{2};{3};{4};{5};{6}", commande.NumeroDeCommande, "Pizza", chori.Prix, chori.Type, chori.Taille, "", nbChori);
                    y.WriteLine(strc);
                }

                int nbCoca = 0;
                int nbJus = 0;
                int nbIceTea = 0;
                Boissons coca = new Boissons();
                Boissons jus = new Boissons();
                Boissons iceTea = new Boissons();
                foreach (Boissons boisson in commande.boissons)
                {
                    if (boisson.Nom == "Coca")
                    {
                        nbCoca++;
                        coca = boisson;
                    }
                    else
                    {
                        if (boisson.Nom == "Jus d'orange")
                        {
                            nbJus++;
                            jus = boisson;
                        }
                        else
                        {
                            if (boisson.Nom == "Ice Tea")
                            {
                                nbIceTea++;
                                iceTea = boisson;
                            }
                        }
                    }
                }
                if (nbCoca > 0)
                {
                    string strco = string.Format("{0};{1};{2};{3};{4};{5};{6}", commande.NumeroDeCommande, coca.Nom, coca.Prix, "", "", coca.Volume, nbCoca);
                    y.WriteLine(strco);
                }
                if (nbJus > 0)
                {
                    string strj = string.Format("{0};{1};{2};{3};{4};{5};{6}", commande.NumeroDeCommande, jus.Nom, jus.Prix, "", "", jus.Volume, nbJus);
                    y.WriteLine(strj);
                }
                if (nbIceTea > 0)
                {
                    string stri = string.Format("{0};{1};{2};{3};{4};{5};{6}", commande.NumeroDeCommande, iceTea.Nom, iceTea.Prix, "", "", iceTea.Volume, nbIceTea);
                    y.WriteLine(stri);
                }
            }
        }
    }
}
