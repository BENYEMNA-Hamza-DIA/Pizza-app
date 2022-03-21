using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    public class Client : Personne, IPromo /*Permet de définir la méthode d'interface Promo en tant qu'interface*/,
                                    IComparable<Client>/*Permet les comparaison entre clients*/
    {
        #region Attributs
        private string numTel;
        private string adresse;
        private DateTime datePremiereCommande;
        List<Commande> commandes_client; //Elle nous permet d'accéder plus facilement aux commandes par clients
        #endregion

        #region Constructeur
        public Client(string nom, string prenom, string ville, string numTel, string adresse, DateTime datePremiereCommande) : base(nom, prenom, ville)
        {
            this.numTel = numTel;
            this.adresse = adresse;
            this.datePremiereCommande = datePremiereCommande;
            this.commandes_client = new List<Commande>(); //Lors de la création du client, une liste vide est créee 
        }
        #endregion

        #region Propriétés
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

        public List<Commande> Commandes_client
        {
            get { return this.commandes_client; }
        }
        #endregion

        #region Méthode
        public override string ToString()
        /*L'override permet le polymorphisme des méthodes d'affichages 
        et retourner les attributs hérités de Personne grâce au base.ToString()*/
        {
            return base.ToString() + " ; Numéro de téléphone: " + this.numTel
                                    + " ; Adresse: " + this.adresse + " ; Date de 1ere commande: " + this.datePremiereCommande;
        }

        public void AjoutCommandeClient(Commande c)
        /*Lorsqu'une commande est bien payée, elle s'ajoute à la liste de commandes faites par le client
         */
        {
            if (c.VerifiePayee())
            {
                this.commandes_client.Add(c);
            }
        }

        public bool Promo()
        /*Cette méthode d'interface permet de vérifier qu'un client possède plus de 10 commandes
         * Ce seuil dépassé, cela prouve qu'il est fidèle donc il accède à une remise de 5% sur toutes ses commandes
         */
        {
            bool promo = false;
            if (this.commandes_client.Count >= 10)
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
            int n = this.commandes_client.Count;
            if (this.commandes_client != null && n != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    if (this.Promo() && i > 10) //On applique la promotion à toutes les commandes suivants la 10eme
                    {
                        prix_cumule += this.commandes_client[i].PrixAvecPromo();
                    }
                    else
                    {
                        prix_cumule += this.commandes_client[i].PrixSansPromo();
                    }
                }
            }
            return prix_cumule;
        }

        public double MoyenneClient()
        /*Il suffit de récupérer le prix cumulé et le nombre de commandes de la liste clients pour calculer la moyenne de ses commandes
         */
        {
            double somme = 0;
            double moyenne = 0;
            if (this.commandes_client != null && this.commandes_client.Count != 0)
            {
                double n = this.commandes_client.Count;
                somme = this.PrixCummule();
                moyenne = somme / n;
            }
            return moyenne;
        }

        public int CompareTo([AllowNull] Client other)
        {
            return String.Compare(this.nom, other.Nom);
        }

        public static int ComparerPrixCumule(Client a, Client b)
        //Permet de trier les clients par prix cumulé pour connaître les meilleurs clients
        {
            double prix_cumul_a = a.PrixCummule();
            double prix_cumul_b = b.PrixCummule();
            return (-1) * prix_cumul_a.CompareTo(prix_cumul_b); // le (-1)* permet d'avoir un tri décroissant, du meilleur au pire client
        }
        #endregion
    }
}
