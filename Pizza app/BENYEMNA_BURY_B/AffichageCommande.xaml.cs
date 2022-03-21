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
    /// Logique d'interaction pour AffichageCommande.xaml
    /// </summary>
    public partial class AffichageCommande : Window// cette fenetre affiche la commande ainsi que les prix unitaires et le prix total de la commande
    {
        #region Attributs
        Pizzeria pizzeria;
        Client client;
        Commande commande;
        #endregion
        #region Constructeurs
        public AffichageCommande(Pizzeria pizzeria, Client client, Commande commande)
        {
            this.pizzeria = pizzeria;
            this.client = client;
            this.commande = commande;
            this.DataContext = this;
            InitializeComponent();
            pizzas.ItemsSource = this.commande.ListePizzas;
            boissons.ItemsSource = this.commande.ListeBoissons;
            this.pizzeria.MAJPrix(this.commande);
            if (this.client.Promo())
            {
                MessageBox.Show("Le client bénéficie d'une reduction de 5%");           // permet de savoir si le client bénéficie de la promo    
            }
            this.prixTotal.Text = this.commande.Prix;
        }
        #endregion
        #region Méthodes
        private void RetourChoixPizza(object sender, RoutedEventArgs e)//permet de retourner sur la fenetre du choix des pizzas
        {
            ChoixDeLaPizza choixpizza = new ChoixDeLaPizza(this.pizzeria, this.client, this.commande);
            this.Close();
            choixpizza.Show();
        }

        private void SelectionnerLeCommis(object sender, RoutedEventArgs e)// permet de valider la commande et d'afficher la fenetre de selection du commis 
        {
            SelectionCommis selection = new SelectionCommis(this.pizzeria, this.client, this.commande);
            this.Close();
            selection.Show();
        }
#endregion
    }
}
