using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    public class Commande : ICopie/*Permet d'instancier la méthode d'interface Copie de la facture*/,
                            IVerifieEtat/*Permet d'instancier les méthodes d'interfaces VerifieLivraison et VerfiePreparation*/,
                            IVerifiePayee/*Permet d'instancier la méthode d'interface VerifiePayee*/,
                            IComparable<Commande>//Permet le tri les commandes grâce aux interfaces existantes
    {
        #region Attributs
        private string numCommande;
        private List<Pizza> listePizzas;
        private List<Boisson> listeBoissons;
        private DateTime dateCommande;
        private string nomClient;
        private string nomCommis;
        private string nomLivreur;
        private string etat;//="en préparation", "en livraison" ou "fermée"
        private string solde;//="non payée" ou "payée"
        private string facture;//Permet de regrouper les informations sur le même attributs et faciliter l'affichage
        #endregion

        #region Constructeur
        public Commande(string numCommande, List<Pizza> listePizzas, List<Boisson> listeBoissons, DateTime dateCommande, string nomClient, string nomCommis, string nomLivreur)
        {
            this.numCommande = numCommande;
            this.listePizzas = listePizzas;
            this.listeBoissons = listeBoissons;
            this.dateCommande = dateCommande;
            this.nomClient = nomClient;
            this.nomCommis = nomCommis;
            this.nomLivreur = nomLivreur;
            this.etat = "en préparation";
            this.solde = "non payée";
            this.facture = "Numéro de commande: " + this.numCommande + "\nDate de commande: " + this.dateCommande
                + "\nNom client: " + this.nomClient + "\nNom commis: " + this.nomCommis + "\nNom livreur: " + this.nomLivreur
                + "\nEtat de la commande: " + this.etat + "\nSolde: " + this.solde;
        }
        #endregion

        #region Propriétés
        public string NumCommande
        {
            get { return this.numCommande; }
        }
        public List<Pizza> ListePizzas
        {
            get { return this.listePizzas; }
        }
        public List<Boisson> ListeBoissons
        {
            get { return this.listeBoissons; }
        }
        public DateTime DateCommande
        {
            get { return this.dateCommande; }
        }
        public string NomClient
        {
            get { return this.nomClient; }
        }
        public string NomCommis
        {
            get { return this.nomCommis; }
        }
        public string Etat
        {
            get { return this.etat; }
            set { this.etat = value; }//Car cela me permet de le modifier dans Programs.cs pour effectuer des tests de méthodes
        }
        public string Solde
        {
            get { return this.solde; }
            set { this.solde = value; }//Car cela me permet de le modifier dans Programs.cs pour effectuer des tests de méthodes
        }
        public string Facture
        {
            get { return this.facture; }
        }
        public string NomLivreur
        {
            get { return this.nomLivreur; }
        }
        #endregion

        #region Méthodes
        public double PrixSansPromo() //Permet de calculer le prix normal des commandes
        {
            double prix = 0;
            if (this.ListePizzas != null && this.ListePizzas.Count != 0)
            {
                foreach (Pizza p in this.ListePizzas)
                {
                    prix += p.Prix();
                }
            }

            if (this.ListeBoissons != null && this.ListeBoissons.Count != 0)
            {
                foreach (Boisson b in this.ListeBoissons)
                {
                    prix += b.Prix();
                }
            }
            return prix;
        }

        public double PrixAvecPromo() //Permet d'appliquer une promotion au prix des commandes
        {
            double prix = 0;
            double remise = 5; //remise de 5%
            if (this.ListePizzas != null && this.ListePizzas.Count != 0)
            {
                foreach (Pizza p in this.ListePizzas)
                {
                    prix += p.Prix();
                }
            }

            if (this.ListeBoissons != null && this.ListeBoissons.Count != 0)
            {
                foreach (Boisson b in this.ListeBoissons)
                {
                    prix += b.Prix();
                }
            }
            return prix - ((remise / 100) * prix);
        }

        public string AffichageFacture() //Permet l'affichage des commandes plus facilement en reprenant toutes les infos necéssaires
        {
            string detail = "";
            detail += "Numéro de commande: " + this.numCommande + "\nDate de commande: " + this.dateCommande
                + "\nNom client: " + this.nomClient + "\nNom commis: " + this.nomCommis + "\nNom livreur: " + this.nomLivreur
                + "\nEtat de la commande: " + this.etat + "\nSolde: " + this.solde;
            return detail;
        }

        public bool VerifiePayee() //Méthode d'interface qui permet de vérifier si une commande est payée
        {
            bool paye = false;
            if (this.solde == "payée")
            {
                paye = true;
            }
            return paye;
        }

        public bool VerifiePreparation() //Méthode d'interface qui vérifie si une commande à été préparée par le Commis
        {
            bool preparee = false;
            if (this.etat == "en livraison" || this.etat == "fermée")//une commande a été préparée si elle est en cours de livraison ou livrée
            {
                preparee = true;
            }
            return preparee;
        }

        public bool VerifieLivraison() //Méthode d'interface qui vérifie si une commande à été livrée par le Livreur
        {
            bool livree = false;
            if (this.etat == "fermée")
            {
                livree = true;
            }
            return livree;
        }

        public string Copie() //Permet de faire la copie de la facture que le Livreur remet au Commis
        {
            string copie = this.facture;
            return copie;
        }

        public int CompareTo(Commande other)
        {
            return String.Compare(this.facture, other.Facture);
        }

        internal static int ComparerDateCommande(Commande a, Commande b) //Tri les commandes par date
        {
            DateTime n = DateTime.Now;
            TimeSpan date_a = n - a.DateCommande;
            TimeSpan date_b = n - b.DateCommande;
            return TimeSpan.Compare(date_a, date_b);
        }
        #endregion

    }
}
