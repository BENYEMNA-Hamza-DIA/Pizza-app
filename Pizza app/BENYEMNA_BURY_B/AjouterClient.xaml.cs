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
    /// Logique d'interaction pour AjouterClient.xaml
    /// </summary>
    public partial class AjouterClient : Window // C'est une fenetre qui permet d'ajouter un nouveau client
    {

        #region Attributs
        Pizzeria pizzeria;
        #endregion
        #region Constructeurs
        public AjouterClient(Pizzeria pizzeria)
        {
            this.pizzeria = pizzeria;
            InitializeComponent();
        }
        #endregion
        #region Méthodes
        private void AjouterNouveauClient(object sender, RoutedEventArgs e) // permet d'ajouter un nouveau client à la liste de clients de lapizzeria grace aux informations saisies et affiche les informationsdu client
        {
            if (this.NumClient.Text != "")
            {
                if (this.pizzeria.Clients.Find(x => x.NumTel == this.NumClient.Text) == null) //verifie que le client n'est pas déjà dans la liste de clients de la pizzeria
                {
                    if (this.NumClient.Text.Length == 10 && this.PrenomClient.Text != "" && this.NomClient.Text != "" && this.AdresseClient.Text != "" && this.VilleClient.Text != "")
                    {
                        Client c = new Client(this.NomClient.Text, this.PrenomClient.Text, this.VilleClient.Text, this.NumClient.Text, this.AdresseClient.Text, DateTime.Now);
                        this.pizzeria.AjoutClient(c);
                        AffichageDuClient affichage = new AffichageDuClient(this.pizzeria, c);
                        this.Close();
                        affichage.Show();
                    }
                    else
                    {
                        MessageBox.Show("Erreur saisie invalide");
                    }
                }
                else
                {
                    MessageBox.Show("Un client avec ce numero de téléphone existe déjà");
                }

            }
            else
            {
                MessageBox.Show("Erreur saisie invalide");
            }


        }
        private void RetourRecherche(object sender, RoutedEventArgs e) // permet de retourner sur la fenetre de recherche de client
        {
            RechercheClient recherche = new RechercheClient(this.pizzeria);
            this.Close();
            recherche.Show();
        }
        #endregion

    }
}
