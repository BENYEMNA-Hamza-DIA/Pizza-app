using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Tri de commande par date
            Console.WriteLine("Affichage du tri de commande par date: ");
            List<Commande> commandes = new List<Commande>();
            Commande c1 = new Commande("1", null, null, new DateTime(2020, 01, 20), "A", "A", "A");
            Commande c2 = new Commande("2", null, null, new DateTime(2019, 02, 15), "A", "A", "A");
            Commande c3 = new Commande("3", null, null, new DateTime(2021, 01, 04), "A", "A", "A");
            commandes.Add(c1);
            commandes.Add(c2);
            commandes.Add(c3);
            commandes.Sort(Commande.ComparerDateCommande);
            commandes.ForEach(x => Console.WriteLine(x.AffichageFacture() + "\n"));//Méthode de delegation en lambda pour afficher les commandes
            #endregion

            #region Vérification du solde d'une commande
            Console.WriteLine("\n\nVerifie payée:\n");
            Commande c4 = new Commande("4", null, null, new DateTime(2020,03,25), "D", "D", "D");
            c4.Solde = "payée";
            Console.WriteLine(c4.VerifiePayee());
            #endregion

            #region Vérification de l'état d'une commande
            Console.WriteLine("\n\nVérifie état:\n");
            c4.Etat = "fermée";
            Console.WriteLine(c4.VerifieLivraison());
            #endregion

            #region Copie d'une facture
            Console.WriteLine("\n\nVérifie copie:\n");
            Console.WriteLine(c4.Copie());
            #endregion

            #region Calcul du Prix d'une commande avec et sans promo
            Console.WriteLine("\n\nCalcul du prix d'une commande:\n");
            List<Pizza> pizzas1 = new List<Pizza>();
            Pizza p11 = new Pizza("Margherita", "Moyenne");
            Pizza p12 = new Pizza("Chèvre Miel", "Grande");
            pizzas1.Add(p11);
            pizzas1.Add(p12);

            List<Boisson> boissons1 = new List<Boisson>();
            Boisson b11 = new Boisson("Coca", "1.5l");
            Boisson b12 = new Boisson("Oasis", "0.5l");
            boissons1.Add(b11);
            boissons1.Add(b12);

            Commande c01 = new Commande("45613", pizzas1, boissons1, new DateTime(2019, 05, 01), "A", "A", "A");
            Console.WriteLine("sans promo: " + c01.PrixSansPromo());
            Console.WriteLine("avec promo: " + c01.PrixAvecPromo());
            #endregion

            #region Tri des personnes par nom
            Console.WriteLine("\n\nTri des personnes par nom:\n");
            List<Livreur> livreurs = new List<Livreur>();
            Livreur l1 = new Livreur("A", "A", "D", new DateTime(2020), "A", "A");
            Livreur l2 = new Livreur("B", "A", "C", new DateTime(2020), "A", "A");
            Livreur l3 = new Livreur("C", "A", "B", new DateTime(2020), "A", "A");
            Livreur l4 = new Livreur("D", "A", "A", new DateTime(2020), "A", "A");
            livreurs.Add(l3);
            livreurs.Add(l2);
            livreurs.Add(l4);
            livreurs.Add(l1);
            livreurs.Sort();
            livreurs.ForEach(x => Console.WriteLine(x.ToString()));
            //Méthode de delegation en lambda pour afficher les livreurs par ordre alphabétique
            Console.WriteLine();
            List<Client> clients = new List<Client>();
            Client client1 = new Client("A", "A", "D", "6453", "54edsc", new DateTime(2017,01,02));
            Client client2 = new Client("B", "A", "C", "6453", "54edsc", new DateTime(2016,05,23));
            Client client3 = new Client("C", "A", "B", "6453", "54edsc", new DateTime(2015,04,26));
            Client client4 = new Client("D", "A", "A", "6453", "54edsc", new DateTime(2017,05,23));
            clients.Add(client3);
            clients.Add(client2);
            clients.Add(client1);
            clients.Add(client4);
            clients.Sort();
            clients.ForEach(x => Console.WriteLine(x.ToString()));
            //Méthode de delegation en lambda pour afficher les clients par ordre alphabétique
            #endregion

            #region Tri des personnes par ville
            Console.WriteLine("\n\nTri des personnes par ville:\n");
            livreurs.Sort(Personne.ComparerVille);
            livreurs.ForEach(x => Console.WriteLine(x.ToString()));
            //Méthode de delegation en lambda pour afficher les livreurs par ville
            #endregion

            #region Ajout de commandes à un client
            Console.WriteLine("\n\nVérifie ajout commande client:\n");
            c01.Solde = "payée";
            client1.AjoutCommandeClient(c01);
            List<Pizza> pizzas2 = new List<Pizza>();
            Pizza p21 = new Pizza("Margherita", "Grande");
            pizzas2.Add(p21);

            List<Boisson> boissons2 = new List<Boisson>();
            Boisson b21 = new Boisson("Fanta", "0.5l");
            Boisson b22 = new Boisson("Oasis", "1.5l");
            boissons2.Add(b21);
            boissons2.Add(b22);

            Commande c02 = new Commande("45613", pizzas2, boissons2, new DateTime(2019, 03, 01), "B", "B", "B");
            c02.Solde = "payée";
            client1.AjoutCommandeClient(c02);
            client1.Commandes_client.ForEach(x => Console.WriteLine(x.AffichageFacture() + "\n"));
            #endregion

            #region Application de la promo
            Console.WriteLine("\n\nVérifie promo:\n");
            Console.WriteLine(client1.Promo());
            #endregion

            #region Prix cumulé par client
            Console.WriteLine("\n\nVérifie prix cumulé:\n");
            Console.WriteLine(client1.PrixCummule() + " euros");
            #endregion

            #region Tri des clients par prix cumulé
            Console.WriteLine("\n\nVérifie tri par prix cumulé:\n");
            List<Pizza> pizzas3 = new List<Pizza>();
            Pizza p31 = new Pizza("Royale", "Grande");
            Pizza p32 = new Pizza("Chèvre Miel", "Grande");
            List<Boisson> boissons3 = new List<Boisson>();
            Boisson b31 = new Boisson("Eau", "1.5l");
            Boisson b32 = new Boisson("Oasis", "0.5l");
            boissons2.Add(b31);
            boissons2.Add(b32);
            pizzas3.Add(p31);
            pizzas3.Add(p32);
            Commande c03 = new Commande("45615", pizzas3, boissons3, new DateTime(2019, 01, 01), "C", "C", "C");
            c03.Solde = "payée";
            client2.AjoutCommandeClient(c01);
            client3.AjoutCommandeClient(c01);
            client3.AjoutCommandeClient(c02);
            client3.AjoutCommandeClient(c03);
            clients.Sort(Client.ComparerPrixCumule);
            clients.ForEach(x => Console.WriteLine(x.ToString() + "\n"));
            #endregion

            #region Moyenne du prix d'une commande par client
            Console.WriteLine("\n\nVérifie moyenne client:\n");
            Console.WriteLine(client3.PrixCummule());
            Console.WriteLine(client3.Commandes_client.Count);
            Console.WriteLine("moyenne :" + client3.MoyenneClient() + " euros");
            #endregion

            #region Ajout de commandes au commis
            Console.WriteLine("\n\nvérifie ajout commande préparées par le commis:\n");
            Commis commis1 = new Commis("A", "A", "A", new DateTime(2020, 05, 26), "en service");
            c01.Etat = "fermée";
            c02.Etat = "fermée";
            c03.Etat = "fermée";
            commis1.AjoutCommandeCommis(c01);
            commis1.AjoutCommandeCommis(c02);
            commis1.AjoutCommandeCommis(c03);
            commis1.Commandes_preparees.ForEach(x => Console.WriteLine(x.AffichageFacture() + "\n"));
            #endregion

            #region Nombre de commandes prépararées par le commis
            Console.WriteLine("\n\nvérifie nb préparations commis:\n");
            Console.WriteLine(commis1.NbPreparation() + " préparée(s)");
            #endregion

            #region Ajout de commandes au livreur
            Console.WriteLine("\n\nvérifie ajout commande livrées par le livreur:\n");
            Livreur livreur1 = new Livreur("A", "A", "A", new DateTime(2020, 04, 12), "A", "A");
            livreur1.AjoutCommandeLivreur(c01);
            livreur1.AjoutCommandeLivreur(c02);
            livreur1.AjoutCommandeLivreur(c03);
            livreur1.Commandes_livrees.ForEach(x => Console.WriteLine(x.AffichageFacture() + "\n"));
            #endregion

            #region Nombre de commandes livrées par le livreur
            Console.WriteLine("\n\nvérifie nb commandes livrées livreur:\n");
            Console.WriteLine(livreur1.NbLivraisons() + " livrée(s)");
            #endregion

            #region Ajout de commandes, commis, client et livreurs à la pizzeria
            Console.WriteLine("\n\nvérifie ajout pizzeria:\n");
            Pizzeria pizzeria = new Pizzeria("A", "A", "486513");
            Commis commis2 = new Commis("B", "B", "B", new DateTime(2018, 01, 23), "B");
            pizzeria.AjoutCommis(commis1);
            pizzeria.AjoutCommis(commis2);
            Console.WriteLine("\ncommis:\n");
            pizzeria.Liste_commis.ForEach(x => Console.WriteLine(x.ToString()));
            Livreur livreur2 = new Livreur("B", "B", "B", new DateTime(2017, 05, 30), "A", "A");
            pizzeria.AjoutLivreur(livreur1);
            pizzeria.AjoutLivreur(livreur2);
            Console.WriteLine("\nlivreurs:\n");
            pizzeria.Livreurs.ForEach(x => Console.WriteLine(x.ToString()));
            pizzeria.AjoutClient(client1);
            pizzeria.AjoutClient(client2);
            pizzeria.AjoutClient(client3);
            pizzeria.AjoutClient(client4);
            Console.WriteLine("\nclients:\n");
            pizzeria.Clients.ForEach(x => Console.WriteLine(x.ToString()));
            pizzeria.AjoutCommande(c01);
            pizzeria.AjoutCommande(c02);
            pizzeria.AjoutCommande(c03);
            Console.WriteLine("\ncommandes:\n");
            pizzeria.Commandes.ForEach(x => Console.WriteLine(x.AffichageFacture() + "\n"));
            #endregion

            #region Affichage de commande par période
            DateTime a = new DateTime(2019, 02, 01);
            DateTime b = new DateTime(2019, 05, 01);
            Console.WriteLine("\n\nvérifie historique commande entre " + a.ToString() + " et " + b.ToString() + "\n");
            List<Commande> historique_periode = pizzeria.HistoriqueCommandesParPeriode(a, b);
            historique_periode.ForEach(x => Console.WriteLine(x.AffichageFacture() + "\n"));
            #endregion

            #region Prix moyen d'une commande à la Pizzeria
            Console.WriteLine("\n\nvérifie moyenne commandes pizzeria:\n");
            Console.WriteLine(pizzeria.MoyennePrixCommandes() + " euros");
            #endregion

            Console.ReadKey();
        }
    }
}
