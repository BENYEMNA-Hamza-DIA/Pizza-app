using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace BENYEMNA_BURY_B
{
    abstract public class Personne : IComparable<Personne>/*Interface existant qui permet les différents tri de liste de Personnes 
                                                            en tant que Client, Commis ou Livreur*/
    /*abstract car toutes les classes (personne,commis,livreur) héritent d'elle donc elle n'a pas besoin d'être instanciée*/
    {
        #region Attributs
        protected string nom;
        protected string prenom;
        protected string ville;//On ajoute l'attribut ville pour permettre plus facilement le tri des Personnes par ville
        protected List<Commande> commandesAssociees; // Correspond à la liste de commandes passées si c'est un client, la liste de commandes gérées si c'est un commis et la liste de commandes livrées si c'est un livreur
        #endregion
        #region Constructeurs
        public Personne(string nom, string prenom, string ville)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.ville = ville;
            this.commandesAssociees = new List<Commande>();
        }


        protected Personne(string nom, string prenom, string ville, List<Commande> commandesAssociees) : this(nom, prenom, ville)
        {
            this.commandesAssociees = commandesAssociees;
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
        public List<Commande> CommandesAssociees
        {
            get { return this.commandesAssociees; }
        }
        #endregion
        #region Méthodes
        public int CompareTo(Personne other) //Permet le tri par ordre alphabétique des Personnes
        {
            return String.Compare(this.nom, other.Nom);
        }

        public static int ComparerVille(Personne a, Personne b) //Permet le tri par ville des Personnes
        {
            return String.Compare(a.Ville, b.Ville);
        }

        public override string ToString()
        /*L'override permet le polymorphisme des méthodes d'affichages 
          et retourner les attributs hérités de Personne grâce au base.ToString()*/
        {
            return "Nom: " + this.nom + " ; Prenom: " + this.prenom + " ; Ville: " + this.ville;
        }
        #endregion

    }
}
