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
    /// Logique d'interaction pour EffectifEtClients.xaml
    /// </summary>
    public partial class EffectifEtClients : Window// Cette fenetre permet de choisir quel type de personne on veut afficher
    {
        #region Attributs
        Pizzeria pizzeria;

        #endregion
        #region Constructeurs
        public EffectifEtClients(Pizzeria pizzeria)
        {
            this.pizzeria = pizzeria;
            InitializeComponent();
        }
        #endregion
        #region Méthodes
        private void RetourAccueil(object sender, RoutedEventArgs e) // Permet de revenir a l'accueil
        {
            MainWindow mainWindow = new MainWindow(this.pizzeria);
            this.Close();
            mainWindow.Show();
        }

        private void AfficherClients(object sender, RoutedEventArgs e)// permet d'ouvrir la fenetre d'affichage de tous les clients
        {
            AfficherLesClients afficher = new AfficherLesClients(this.pizzeria);
            this.Close();
            afficher.Show();
        }

        private void AfficherCommis(object sender, RoutedEventArgs e)// Permet d'ouvrir la fenetre d'affichage de tous les commis
        {
            AfficherLesCommis afficher = new AfficherLesCommis(this.pizzeria);
            this.Close();
            afficher.Show();
        }
        private void AfficherLivreurs(object sender, RoutedEventArgs e)// Permet d'ouvrir la fenetre d'affichage de tous les livreurs
        {
            AfficherLesLivreurs afficher = new AfficherLesLivreurs(this.pizzeria);
            this.Close();
            afficher.Show();
        }
        #endregion
    }

}
