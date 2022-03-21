using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B
{
    
    sealed public class Commis : Effectif //Commis hérite d'Effetif, elle est sealed car aucune classe n'hérite de Commis
    {
        #region Constructeurs
        public Commis(string nom, string prenom, string ville, DateTime dateEmbauche, string etat) : base(nom, prenom,ville, dateEmbauche, etat)
        {

        }
        public Commis(string nom, string prenom, string ville, DateTime dateEmbauche, string etat, List<Commande> commandesAssociees) : base(nom, prenom,ville, dateEmbauche, etat, commandesAssociees)
        {

        }
        #endregion
        #region Méthodes
        public int NbPreparation() //Permet de connaitre le nombre de commandes préparées par un Commis facilement grâce à la liste de ses commandes préparées
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
        public void AjoutCommandeCommis(Commande c) //Lorsqu'une commande a fini d'être préparée, on l'ajoute à la liste de commandes préparées par un Commis
        {
            if (c.VerifiePreparation())
            {
                this.commandesAssociees.Add(c);
            }
        }
        #endregion

    }
}
