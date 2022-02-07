using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    public class Pizza
    {
        // Attributs :
        
        private string taille;
        private string type;  //3 types dispo : 4 fromages, chorizo ou végétarienne
        private int prix;

        // Constructeurs :
        public Pizza() { }

        /// <summary>
        ///  Constructeur d'une instance de la classe Pizza
        /// </summary>
        /// <param name="taille">Taille de la pizza</param>
        /// <param name="type">Type de la pizza</param>
        /// <param name="prix">Prix de la pizza</param>
        public Pizza(string taille, string type, int prix)
        {
            this.taille = taille;
            this.type = type;
            this.prix = prix;
        }

        // Propriétés :
        public string Taille
        {
            get { return this.taille; }
        }
        public string Type
        {
            get { return this.type; }
        }
        public int Prix
        {
            get { return this.prix; }
        }

        // Méthode ToString :
        public override string ToString()
        {
            return "pizza " + this.type + " format " + this.taille;
        }

    }
}
