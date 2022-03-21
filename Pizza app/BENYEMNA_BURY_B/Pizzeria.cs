using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B
{
    public class Pizzeria
    {
        #region Attributs
        private string nomPizzeria;
        private string addressePizzeria;
        private string telephonePizzeria;
        List<Client> clients;
        List<Livreur> livreurs;
        List<Commis> liste_commis;
        List<Commande> commandes;
        #endregion
        #region Constructeurs
        public Pizzeria(string nom, string addresse, string telephone, List<Client> clients, List<Livreur> livreurs, List<Commis> commis)
        {
            this.nomPizzeria = nom;
            this.addressePizzeria = addresse;
            this.telephonePizzeria = telephone;
            this.clients = clients;
            this.liste_commis = commis;
            this.livreurs = livreurs;
            this.commandes = new List<Commande>();

        }
        public Pizzeria(string nom, string addresse, string telephone)
        {
            this.nomPizzeria = nom;
            this.addressePizzeria = addresse;
            this.telephonePizzeria = telephone;
            this.clients = new List<Client>();
            this.liste_commis = new List<Commis>();
            this.livreurs = new List<Livreur>();
            this.commandes = new List<Commande>();

        }
        #endregion
        #region Propriétés
        public string NomPizzeria { get => nomPizzeria; }
        public string AddressePizzeria { get => addressePizzeria; }
        public string TelephonePizzeria { get => telephonePizzeria; }
        public List<Client> Clients { get => clients; }
        public List<Livreur> Livreurs { get => livreurs; }
        public List<Commis> Liste_commis { get => liste_commis; }
        public List<Commande> Commandes { get => commandes; }
        #endregion
        #region Méthodes
        public void AjoutCommis(Commis commis) //Permet d'ajouter un Commis à la liste de Commis de la Pizzeria
        {
            this.liste_commis.Add(commis);
        }

        public void AjoutLivreur(Livreur livreur) //Permet d'ajouter un Livreur à la liste de Livreur de la Pizzeria
        {
            this.livreurs.Add(livreur);
        }

        public void AjoutClient(Client client) //Permet d'ajouter un Client à la liste de Clients de la Pizzeria
        {
            this.clients.Add(client);
        }

        public void AjoutCommande(Commande commande)
        /*Permet d'ajouter une commande à la liste des commandes (historique des commandes) de la Pizzeria*/
        {
            this.commandes.Add(commande);
        }

        public List<Commande> HistoriqueCommandesParPeriode(DateTime a, DateTime b)
        /*Permet d'afficher l'historique des commandes sur une période choisie entre les dates a et b*/
        {
            List<Commande> commandes_periode = new List<Commande>();

            if (a < b)//Permet à l'utilisateur d'entrer les dates dans l'ordre qu'il veut, a<b ou a>b
            {
                commandes_periode = this.commandes.FindAll(c => a <= c.DateCommande &&
                                                                      c.DateCommande <= b);
            }
            else if (a > b)
            {
                commandes_periode = this.commandes.FindAll(c => b <= c.DateCommande &&
                                                                      c.DateCommande <= a);
            }
            return commandes_periode;//Si a=b, la méthode renvoie une liste vide de commandes car ce n'est pas une période
        }

        public double MoyennePrixCommandes() //Permet de calculer le prix moyen du total des commandes de la Pizzeria
        {
            double somme = 0;
            double moyenne = 0;
            if (this.commandes != null && this.commandes.Count != 0)
            {
                double n = this.commandes.Count;
                foreach (Commande c in this.commandes)
                {
                    somme += c.PrixSansPromo();
                }
                moyenne = somme / n;
            }
            return moyenne;
        }
        public void MAJPrix(Commande commande)// Permet de mettre à jour le prix d'une commande lorsqu'on la modifie selon si le client et eligible ou non a la promotion
        {
            Client client = this.clients.Find(x => x.Nom == commande.NomClient);
            if (client.Promo())
            {
                commande.Prix = commande.PrixAvecPromo() + " euros";
            }
            else
            {
                commande.Prix = commande.PrixSansPromo() + " euros";
            }
        }
        #endregion
    }
}