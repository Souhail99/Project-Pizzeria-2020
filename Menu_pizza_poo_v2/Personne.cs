using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    abstract public class Personne
    {
        // Attributs :
        
        protected string nomFamille;
        protected string prenom;
        protected string adresse;

        /// <summary>
        ///  Constructeur d'une instance de la classe Personne
        /// </summary>
        /// <param name="nomFamille">Nom de famille de la personne</param>
        /// <param name="prenom">Prénom de la personne</param>
        /// <param name="adresse">Adresse de la personne</param>
        public Personne(string nomFamille, string prenom, string adresse)
        {
            this.nomFamille = nomFamille;
            this.prenom = prenom;
            this.adresse = adresse;
        }
        public Personne() { }

        // Propriétés :

        public string NomFamille
        {
            get { return this.nomFamille; }
        }
        public string Prenom
        {
            get { return this.prenom; }
        }
        public string Adresse
        {
            get { return this.adresse; }
        }

        public override string ToString()
        {
            return this.nomFamille + " " + this.prenom + " " + this.adresse;
        }
    }
}
