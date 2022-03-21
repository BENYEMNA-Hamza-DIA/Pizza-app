using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B
{
    abstract public class Effectif : Personne
    {
        #region Attributs
        protected DateTime dateEmbauche;
        protected string etat;
        #endregion

        #region Constructeurs
        public Effectif(string nom, string prenom, string ville, DateTime dateEmbauche, string etat) : base(nom, prenom, ville)
        {
            this.dateEmbauche = dateEmbauche;
            this.etat = etat;
        }
        public Effectif(string nom, string prenom, string ville, DateTime dateEmbauche, string etat, List<Commande> commandesAssociees) : base(nom, prenom, ville, commandesAssociees)
        {
            this.dateEmbauche = dateEmbauche;
            this.etat = etat;
        }
        public DateTime DateEmbauche
        {
            get { return this.dateEmbauche; }
        }
        public string Etat
        {
            get { return this.etat; }
        }
        #endregion
    }
}
