using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    sealed public class Commis : Effectif//Commis hérite d'Effetif, elle est sealed car aucune classe n'hérite de Commis
    {
        #region Attributs
        List<Commande> commandes_preparees;//Cette liste permet d'accéder facilement aux commandes péparées par le Commis
        #endregion

        #region Constructeur
        public Commis(string nom, string prenom, string ville, DateTime dateEmbauche, string etat) : base(nom, prenom, ville, dateEmbauche, etat)
        {
            this.commandes_preparees = new List<Commande>();
            //Pour chaque commis crée, une liste vide de commandes préparées est automatiquement créee
        }
        #endregion

        #region Propriétés
        public List<Commande> Commandes_preparees
        {
            get { return this.commandes_preparees; }
        }
        #endregion

        #region Méthodes
        public override string ToString()
        {
            return base.ToString();
        }

        public void AjoutCommandeCommis(Commande c)
        /*Lorsqu'une commande a fini d'être préparée, on l'ajoute à la liste de commandes préparées par un Commis*/
        {
            if (c.VerifiePreparation())
            {
                this.commandes_preparees.Add(c);
            }
        }

        public int NbPreparation()
        /*Permet de connaitre le nombre de commandes préparées par un Commis facilement grâce à la liste de ses commandes préparées*/
        {
            if (this.commandes_preparees != null && this.commandes_preparees.Count != 0)
            {
                return this.commandes_preparees.Count;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
