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
    /// Logique d'interaction pour RechercheClient.xaml
    /// </summary>
    public partial class RechercheClient : Window // Cette fenetre permet de rechercher un client dans la liste des clients de la pizzeria
    {
        #region Attributs
        Pizzeria pizzeria;
        #endregion
        #region Constructeurs
        public RechercheClient(Pizzeria pizzeria)
        {
            this.pizzeria = pizzeria;
            InitializeComponent();
            
        }
        #endregion
        #region Méthodes

        private void RechercheParNum(object sender, RoutedEventArgs e)// la saisie d'un numero de téléphone permet de rechercher un client, s'il est present dans la liste de la pizzeria alors on affiche ses informations sinon un message d'erreur s'affiche
        {
            Client c = this.pizzeria.Clients.Find(x => x.NumTel == this.Telephone.Text);
            if (c != null)
            {
                AffichageDuClient affichage = new AffichageDuClient(this.pizzeria,c);
                this.Close();
                affichage.Show();
            }
            else
            {
                MessageBox.Show("Introuvable");
            }
        }

        private void Ajouter(object sender, RoutedEventArgs e)// ouvre une fenetre qui permet d'ajouter un nouveau client
        {
            AjouterClient ajout = new AjouterClient(this.pizzeria);
            this.Close();
            ajout.Show();
        }

        private void RetourAccueil(object sender, RoutedEventArgs e)// permet de retourner à l'accueil
        {
            MainWindow mainWindow = new MainWindow(this.pizzeria);
            this.Close();            
            mainWindow.Show();
        }
        #endregion
    }
}
