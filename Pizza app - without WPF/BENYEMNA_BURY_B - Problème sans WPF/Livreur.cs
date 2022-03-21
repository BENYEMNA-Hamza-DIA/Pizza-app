using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    sealed public class Livreur : Effectif//Elle hérite d'Effectif et est sealed car aucune classe n'hérite de Livreur
    {
        #region Attributs
        private string vehicule;
        List<Commande> commandes_livrees;//Cette liste permet d'accéder facilement aux commandes livrées par le Livreur
        #endregion

        #region Constructeur
        public Livreur(string nom, string prenom, string ville, DateTime dateEmbauche, string etat, string vehicule) : base(nom, prenom, ville, dateEmbauche, etat)
        {
            this.vehicule = vehicule;
            this.commandes_livrees = new List<Commande>();
            //Pour chaque Livreur crée, une liste vide de commandes livrées est automatiquement créee
        }
        #endregion

        #region Propriétés
        public string Vehicule
        {
            get { return this.vehicule; }
        }

        public List<Commande> Commandes_livrees
        {
            get { return this.commandes_livrees; }
        }
        #endregion

        #region Méthodes
        public override string ToString()
        {
            return base.ToString() + " ; Véhicule: " + this.vehicule;
        }

        public void AjoutCommandeLivreur(Commande c)
        /*Lorsqu'une commande a fini d'être livrée, on l'ajoute à la liste de commandes livrées par un Livreur*/
        {
            if (c.VerifieLivraison())
            {
                this.commandes_livrees.Add(c);
            }
        }

        public int NbLivraisons()
        /*Permet de connaitre le nombre de commandes livrées par un Livreur facilement grâce à la liste de ses commandes livrées*/
        {
            if (this.commandes_livrees != null && this.commandes_livrees.Count != 0)
            {
                return this.commandes_livrees.Count;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
