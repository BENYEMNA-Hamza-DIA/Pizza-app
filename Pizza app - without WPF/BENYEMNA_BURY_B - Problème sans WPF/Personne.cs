using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    abstract public class Personne : IComparable<Personne>/*Interface existant qui permet les différents tri de liste de Personnes 
                                                            en tant que Client, Commis ou Livreur*/
                                                          /*abstract car toutes les classes (personne,commis,livreur) héritent d'elle donc elle n'a pas besoin d'être instanciée*/
    {
        #region Attributs en protected car il s'agit d'une classe mère
        protected string nom;
        protected string prenom;
        protected string ville;//On ajoute l'attribut ville pour permettre plus facilement le tri des Personnes par ville
        #endregion

        #region Constructeur
        public Personne(string nom, string prenom, string ville)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.ville = ville;
        }
        #endregion

        #region Propriétés
        public string Nom
        {
            get { return this.nom; }
        }
        public string Prenom
        {
            get { return this.prenom; }
        }

        public string Ville
        {
            get { return this.ville; }
        }
        #endregion

        #region Méthodes
        public override string ToString()
        /*L'override permet le polymorphisme des méthodes d'affichages 
          et retourner les attributs hérités de Personne grâce au base.ToString()*/
        {
            return "Nom: " + this.nom + " ; Prenom: " + this.prenom + " ; Ville: " + this.ville;
        }

        public int CompareTo([AllowNull] Personne other) //Permet le tri par ordre alphabétique des Personnes
        {
            return String.Compare(this.nom, other.Nom);
        }

        public static int ComparerVille(Personne a, Personne b) //Permet le tri par ville des Personnes
        {
            return String.Compare(a.Ville, b.Ville);
        }
        #endregion
    }
}
