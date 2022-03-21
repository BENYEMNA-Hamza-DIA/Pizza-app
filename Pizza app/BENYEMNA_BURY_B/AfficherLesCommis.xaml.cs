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
    /// Logique d'interaction pour AfficherLesCommis.xaml
    /// </summary>
    public partial class AfficherLesCommis : Window
    {
        #region Attributs
        Pizzeria pizzeria;
        #endregion
        #region Constructeurs
        public AfficherLesCommis(Pizzeria pizzeria) // Cette fenetre permet d'afficher la liste de tous les commis
        {
            this.pizzeria = pizzeria;
            this.DataContext = this;
            InitializeComponent();
            infoCommis.ItemsSource = this.pizzeria.Liste_commis;
        }
        #endregion
        #region Méthodes
        private void RetourEffectifEtClients(object sender, RoutedEventArgs e) // Permet de retourner sur la page du choix de la liste du type de personnes à afficher
        {
            EffectifEtClients effectifEtClients = new EffectifEtClients(this.pizzeria);
            this.Close();
            effectifEtClients.Show();
        }
        #endregion
    }
}
