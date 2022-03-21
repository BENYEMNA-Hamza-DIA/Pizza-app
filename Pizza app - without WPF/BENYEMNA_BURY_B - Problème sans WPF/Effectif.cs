using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    public class Effectif : Personne//Elle hérite de Personne
    {
        #region Attributs protected car il s'agit d'une classe mère
        protected DateTime dateEmbauche;
        protected string etat;
        #endregion

        #region Constructeur
        public Effectif(string nom, string prenom, string ville, DateTime dateEmbauche, string etat) : base(nom, prenom, ville)
        {
            this.dateEmbauche = dateEmbauche;
            this.etat = etat;
        }
        #endregion
    }
}
