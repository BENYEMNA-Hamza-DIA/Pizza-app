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
    /// Logique d'interaction pour AfficherLesLivreurs.xaml
    /// </summary>
    public partial class AfficherLesLivreurs : Window // Cette fenetre permet d'afficher la liste de tous les livreurs
    {
        Pizzeria pizzeria;
        public AfficherLesLivreurs(Pizzeria pizzeria)
        {
            this.pizzeria = pizzeria;
            this.DataContext = this;
            InitializeComponent();
            infoLivreurs.ItemsSource = this.pizzeria.Livreurs;
        }
        private void RetourEffectifEtClients(object sender, RoutedEventArgs e)// Permet de retourner sur la page du choix de la liste du type de personnes à afficher
        {
            EffectifEtClients effectifEtClients = new EffectifEtClients(this.pizzeria);
            this.Close();
            effectifEtClients.Show();
        }
    }
}
