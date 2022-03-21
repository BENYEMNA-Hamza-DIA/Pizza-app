using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B
{
    sealed public class Livreur : Effectif //Elle hérite d'Effectif et elle est sealed car aucune classe n'hérite de Livreur
    {
        #region Attributs
        private string vehicule;
        #endregion
        #region Constructeurs
        public Livreur(string nom, string prenom, string ville, DateTime dateEmbauche, string etat, string vehicule) : base(nom, prenom, ville, dateEmbauche, etat)
        {
            this.vehicule = vehicule;
        }
        public Livreur(string nom, string prenom, string ville, DateTime dateEmbauche, string etat, string vehicule, List<Commande> commandesAssociees) : base(nom, prenom, ville, dateEmbauche, etat, commandesAssociees)
        {
            this.vehicule = vehicule;
        }
        #endregion
        #region Propriétés
        public string Vehicule
        {
            get { return this.vehicule; }
        }
        #endregion
        #region Méthodes
        public void AjoutCommandeLivreur(Commande c)
        /*Lorsqu'une commande a fini d'être livrée, on l'ajoute à la liste de commandes livrées par un Livreur*/
        {
            if (c.VerifieLivraison())
            {
                this.commandesAssociees.Add(c);
            }
        }
        public int NbLivraisons()
        /*Permet de connaitre le nombre de commandes livrées par un Livreur facilement grâce à la liste de ses commandes livrées*/
        {
            if (this.commandesAssociees != null && this.commandesAssociees.Count != 0)
            {
                return this.commandesAssociees.Count;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
