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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;


namespace BENYEMNA_BURY_B
{
    /// <summary>
    /// Logique d'interaction pour AffichageDuClient.xaml
    /// </summary>
    public partial class AffichageDuClient : Window// Cette page affiche les informations du client
    {
        #region Attibuts
        List<Client> client; // permet d'afficher le client à l'aide d'une listview
        Pizzeria pizzeria;
        #endregion
        #region Constructeurs
        public AffichageDuClient(Pizzeria pizzeria, Client client)
        {
            this.pizzeria = pizzeria;
            this.client = new List<Client>() { client };
            this.DataContext = this;
            InitializeComponent();
            info1.ItemsSource = this.client;
            info2.ItemsSource = this.client;
        }
        #endregion
        #region Méthodes

        private void RetourRecherche(object sender, RoutedEventArgs e) // permet de retourner sur la fenetre de recherche de client
        {
            RechercheClient recherche = new RechercheClient(this.pizzeria);
            this.Close();
            recherche.Show();
        }
        private void ChoixPizzas(object sender, RoutedEventArgs e) //Permet de valider la selection du client et d'ouvir une fenetre de choix des pizzas
        {
            ChoixDeLaPizza choix = new ChoixDeLaPizza(this.pizzeria, this.client[0]);
            this.Close();
            choix.Show();
        }
#endregion
    }
}
