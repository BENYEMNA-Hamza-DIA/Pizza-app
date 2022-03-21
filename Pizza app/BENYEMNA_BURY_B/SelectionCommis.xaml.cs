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
    /// Logique d'interaction pour SelectionCommis.xaml
    /// </summary>
    public partial class SelectionCommis : Window// permet de choisir le commis qui s'occupe de préparer la commande
    {
        #region Attributs
        Pizzeria pizzeria;
        Client client;
        Commande commande;
        #endregion
        #region Construteurs
        public SelectionCommis(Pizzeria pizzeria, Client client, Commande commande)
        {
            this.pizzeria = pizzeria;
            this.client = client;
            this.commande = commande;
            this.DataContext = this;
            InitializeComponent();

            infocommis.ItemsSource = this.pizzeria.Liste_commis;
        }
        #endregion
        #region Méthodes
        private void Terminer(object sender, RoutedEventArgs e)// permet de valider la commande et de l'ajouter a la liste de commande de la pizzeria, impossible si aucun commis n'est sélectionné
        {
            if (infocommis.SelectedItems != null && infocommis.SelectedItems.Count != 0)
            {
                this.commande.NomCommis = (infocommis.SelectedItems[0] as Commis).Nom;
                this.commande.NomClient = this.client.Nom;
                this.pizzeria.AjoutCommande(this.commande);
                (infocommis.SelectedItems[0] as Commis).AjoutCommandeCommis(this.commande);
                MessageBox.Show("La commande a été validée");
                MainWindow mainWindow = new MainWindow(this.pizzeria);
                this.Close();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Erreur Aucun Commis sélectionné");
            }
        }

        private void RetourAffichageCommande(object sender, RoutedEventArgs e)// permet de retourner sur la page d'affichage de la commande
        {
            AffichageCommande affichage = new AffichageCommande(this.pizzeria, this.client, this.commande);
            this.Close();
            affichage.Show();
        }
        #endregion
    }
}
