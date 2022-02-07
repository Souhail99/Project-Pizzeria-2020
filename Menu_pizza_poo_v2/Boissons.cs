using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    public class Boissons
    {
        // Attributs

        private string nom;
        private int volume;
        private int prix;

        // Constructeurs :

        public Boissons() { }

        /// <summary>
        /// Constructeur d'une instance de Boissons
        /// </summary>
        /// <param name="nom">Nom de la boisson</param>
        /// <param name="volume">Volume de la boisson</param>
        /// <param name="prix">Prix de la boisson</param>
        public Boissons(string nom, int volume, int prix)
        {
            this.nom = nom;
            this.volume = volume;
            this.prix = prix;
        }
        
        // Propriétés :

        public string Nom
        {
            get
            {
                return this.nom;
            }
            set
            {
                this.nom = value;
            }
        }

        public int Volume
        {
            get
            {
                return this.volume;
            }
            set
            {
                this.volume = value;
            }
        }

        public int Prix
        {
            get
            {
                return this.prix;
            }
            set
            {
                this.prix = value;
            }
        }

        // Méthode ToString :

        public override string ToString()
        {
            return this.nom + " " + this.volume + "cl";
        }
    }
}
