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
    /// Logique d'interaction pour ChoixBoisson.xaml
    /// </summary>
    public partial class ChoixBoisson : Window// cette fenetre permet de d'ajouter des boissons à la commande
    {
        #region Attibuts
        Pizzeria pizzeria;
        Client client;
        Commande commande;
        #endregion
        #region Constructeurs
        public ChoixBoisson(Pizzeria pizzeria, Client client, Commande commande)
        {
            this.pizzeria = pizzeria;
            this.client = client;
            this.commande = commande;
            InitializeComponent();
        }
        #endregion
        #region Méthodes
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
        private void Reset(object sender, RoutedEventArgs e)//Permet de supprimer toute les boissons 
        {
            while (this.commande.ListeBoissons.Count != 0)
            {
                this.commande.SupprimerBoisson();
            }
            MessageBox.Show("Toutes les boissons ont été supprimées");
        }
        private void RetourChoixPizza(object sender, RoutedEventArgs e)//Permet de retourner sur la fenetre de choix des pizzas
        {
            ChoixDeLaPizza choixpizza = new ChoixDeLaPizza(this.pizzeria, this.client, this.commande);
            this.Close();
            choixpizza.Show();
        }
        private void AjouterBoisson(object sender, RoutedEventArgs e)// ajoute la boisson sélectionnée a la commande
        {
            if (this.boissonChoisie.Text != "" && this.volume.Text != "")
            {
                Boisson boisson = new Boisson(this.boissonChoisie.Text, this.volume.Text);
                this.commande.AjoutBoisson(boisson);
                MessageBox.Show(boisson.ToString() + " ajouté");
            }
            else
            {
                MessageBox.Show("Sélection invalide");
            }
        }
        private void Supprimer(object sender, RoutedEventArgs e)// supprime la dernier boisson ajoutée de la commande
        {
            this.commande.SupprimerBoisson();
            MessageBox.Show("Dernière boisson supprimée");
        }
        #endregion
    }
}
