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
    /// Logique d'interaction pour AfficherLesCommandes.xaml
    /// </summary>
    public partial class AfficherLesCommandes : Window // Cette fenetre permet d'afficher la liste de toutes les commandes
    {
        #region Attributs
        Pizzeria pizzeria;
        #endregion
        #region Constructeurs
        public AfficherLesCommandes(Pizzeria pizzeria)
        {
            this.pizzeria = pizzeria;
            this.DataContext = this;
            InitializeComponent();
            infoCommande.ItemsSource = this.pizzeria.Commandes;
        }
        #endregion
        #region Méthodes
        private void RetourAccueil(object sender, RoutedEventArgs e) // Permet de retourner à l'accueil
        {
            MainWindow mainWindow = new MainWindow(this.pizzeria);
            this.Close();
            mainWindow.Show();
        }
        #endregion
    }
}
