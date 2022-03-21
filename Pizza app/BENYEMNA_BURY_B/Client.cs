using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B
{
    public class Client : Personne, IPromo /*Permet de définir la méthode d'interface Promo en tant qu'interface*/,
                                    IComparable<Client>/*Permet les comparaison entre clients*/
    {
        #region Attributs
        private string numTel;
        private string adresse;
        private DateTime datePremiereCommande;
        #endregion
        #region Constructeurs
        public Client(string nom, string prenom, string ville, string numTel, string adresse, DateTime datePremiereCommande) : base(nom, prenom,ville)
        {
            this.numTel = numTel;
            this.adresse = adresse;
            this.datePremiereCommande = datePremiereCommande;
        }
        public Client(string nom, string prenom, string ville, string numTel, string adresse, DateTime datePremiereCommande, List<Commande> commandesAssociees) : base(nom, prenom, ville, commandesAssociees)
        {
            this.numTel = numTel;
            this.adresse = adresse;
            this.datePremiereCommande = datePremiereCommande;
        }
#endregion
        #region Propriétes
        public string NumTel
        {
            get { return this.numTel; }
        }
        public string Adresse
        {
            get { return this.adresse; }
        }
        public DateTime DatePremiereCommande
        {
            get { return this.datePremiereCommande; }
        }
        #endregion
        #region Méthodes
        public void AjoutCommandeClient(Commande c)
        {
            /*Lorsqu'une commande est bien payée, elle s'ajoute à la liste de commandes faites par le client
            */
            if (c.VerifiePayee())
            {
                this.commandesAssociees.Add(c);
            }
        }

        public bool Promo()
        {
            /*Cette méthode d'interface permet de vérifier qu'un client possède plus de 10 commandes
            * Ce seuil dépassé, cela prouve qu'il est fidèle donc il accède à une remise de 5% sur toutes ses commandes
            */
            bool promo = false;
            if (this.commandesAssociees.Count >= 10)
            {
                promo = true;
            }
            return promo;
        }

        public double PrixCummule()
        /* Grâce à la liste de commandes établie par clients, il suffit d'additionner le prix de chaque commande de cette liste pour avoir le cumul
         */
        {
            double prix_cumule = 0;
            int n = this.commandesAssociees.Count;
            if (this.commandesAssociees != null && n != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    if (this.Promo() && i > 10) //On applique la promotion à toutes les commandes suivants la 10eme
                    {
                        prix_cumule += this.commandesAssociees[i].PrixAvecPromo();
                    }
                    else
                    {
                        prix_cumule += this.commandesAssociees[i].PrixSansPromo();
                    }
                }
            }
            return prix_cumule;
        }

        public double MoyenneClient()
        {
            /*Il suffit de récupérer le prix cumulé et le nombre de commandes de la liste clients pour calculer la moyenne de ses commandes
            */
            double somme = 0;
            double moyenne = 0;
            if (this.commandesAssociees != null && this.commandesAssociees.Count != 0)
            {
                double n = this.commandesAssociees.Count;
                somme = this.PrixCummule();
                moyenne = somme / n;
            }
            return moyenne;
        }

        public int CompareTo(Client other)
        {
            return String.Compare(this.nom, other.Nom);
        }

        public static int ComparerPrixCumule(Client a, Client b) //Permet de trier les clients par prix cumulé pour connaître les meilleurs clients
        {
            
            double prix_cumul_a = a.PrixCummule();
            double prix_cumul_b = b.PrixCummule();
            return (-1) * prix_cumul_a.CompareTo(prix_cumul_b); //le(-1) * permet d'avoir un tri décroissant, du meilleur au pire client
        }
        public override string ToString()
        /*L'override permet le polymorphisme des méthodes d'affichages 
        et retourner les attributs hérités de Personne grâce au base.ToString()*/
        {
            return base.ToString() + " ; Numéro de téléphone: " + this.numTel
                                    + " ; Adresse: " + this.adresse + " ; Date de 1ere commande: " + this.datePremiereCommande;
        }
        #endregion
    }
}

