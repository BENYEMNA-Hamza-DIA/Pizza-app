using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BENYEMNA_BURY_B
{
    /// <summary>
    /// Logique d'interaction pour ChoixDeLaPizza.xaml
    /// </summary>
    public partial class ChoixDeLaPizza : Window
    {
        #region Attibuts
        Pizzeria pizzeria;
        Client client;
        Commande commande;
        #endregion
        #region Constructeurs
        public ChoixDeLaPizza(Pizzeria pizzeria, Client client)
        {
            this.pizzeria = pizzeria;
            this.client = client;
            this.commande = new Commande(DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + client.NumTel.Substring(2, 5) + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString(), new List<Pizza>(), new List<Boisson>(), DateTime.Now, client.Nom);
            InitializeComponent();
        }
        public ChoixDeLaPizza(Pizzeria pizzeria, Client client, Commande commande) : this(pizzeria, client) // permet de retouner sur cette page sans supprimer totalement la commande
        {
            this.commande = commande;
            InitializeComponent();
        }
        #endregion
        #region Méthodes
        private void AjouterPizza(object sender, RoutedEventArgs e) //ajoute une pizza à la commande
        {
            if (this.pizzaChoisie.Text != "" && this.taille.Text != "")
            {
                Pizza pizza = new Pizza(this.pizzaChoisie.Text, this.taille.Text);
                this.commande.AjoutPizza(pizza);
                MessageBox.Show(pizza.ToString() + " ajoutée");
            }
            else
            {
                MessageBox.Show("Sélection invalide"); //message d'erreur si la sélection de la pizza est invalide ex: pas de taille choisie
            }
        }

        private void RetourRechrcheClient(object sender, RoutedEventArgs e) // permet de retouner sur la fenetre de recherche de client
        {
            RechercheClient recherche = new RechercheClient(this.pizzeria);
            this.Close();
            recherche.Show();
        }
        private void Reset(object sender, RoutedEventArgs e) // permet de totalement supprimer la commande
        {
            this.commande = new Commande(DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + client.NumTel.Substring(2, 5) + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString(), new List<Pizza>(), new List<Boisson>(), DateTime.Now, client.Nom);
            MessageBox.Show("Commande réinitialisée");
        }
        private void Suplement(object sender, RoutedEventArgs e) // permet d'ouvir une fenetre de choix des boissons
        {
            ChoixBoisson choix = new ChoixBoisson(this.pizzeria, this.client, this.commande);
            this.Close();
            choix.Show();
        }

        private void Supprimer(object sender, RoutedEventArgs e) // permet de supprimer la derniere pizza ajoutée
        {
            this.commande.SupprimerPizza();
            MessageBox.Show("Dernière pizza supprimée");
        }

        private void ValiderCommande(object sender, RoutedEventArgs e)// permet de valider la commande et d'afficher la commande, validation impossible si la commande ne contient aucune pizza
        {
            if (this.commande.ListePizzas.Count != 0)
            {
                AffichageCommande affichage = new AffichageCommande(this.pizzeria, this.client, this.commande);
                this.Close();
                affichage.Show();
            }
            else
            {
                MessageBox.Show("Commande invalide, aucune Pizza sélectionnée");
            }

        }
        #endregion
    }
}
