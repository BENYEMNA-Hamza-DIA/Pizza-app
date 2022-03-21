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

namespace BENYEMNA_BURY_B
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window // La page d'accueil de l'application
    {
        #region Attributs
        Pizzeria pizzeria;
        #endregion
        #region Constructeurs
        public MainWindow()// Lors de l'initialisation on créer un pizzeria avec des clients, commis et livreurs afn de tester l'application
        {
            Client a = new Client("Tata", "Toto", "Rome", "0645287519", "9 Rue de la paix", new DateTime(2018, 4, 5));
            Client b = new Client("Titi", "Tutu", "Rome", "0678641721", "11 Rue de la paix", new DateTime(2020, 5, 4));

            Commis luigi = new Commis("Russo", "Luigi", "Rome", DateTime.Now, "surplace");
            Livreur mario = new Livreur("Costa", "Mario", "Rome", DateTime.Now, "surplace", "vélo");
            this.pizzeria = new Pizzeria("La Gatta Mangiona", "Via Federico Ozanam, 30-32, 00152 Roma RM, Italie", "0659784159");
            this.pizzeria.AjoutClient(a);
            this.pizzeria.AjoutClient(b);
            Pizza piz = new Pizza("Royale", "Grande");
            List<Pizza> pizzas = new List<Pizza>() { piz };
            Commande c1 = new Commande("04064528720201401", pizzas, new List<Boisson>(), DateTime.Now, "Tata", "Russo", "Costa", "fermée", "payée");
            Commande c2 = new Commande("04067864120201401", pizzas, new List<Boisson>(), DateTime.Now, "Titi", "Russo", "Costa", "fermée", "payée");
            this.pizzeria.AjoutCommande(c1);

            luigi.AjoutCommandeCommis(c1);
            mario.AjoutCommandeLivreur(c1);
            a.AjoutCommandeClient(c1);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            b.AjoutCommandeClient(c2);
            this.pizzeria.AjoutCommis(luigi);
            this.pizzeria.AjoutLivreur(mario);
            this.DataContext = this;
            InitializeComponent();
        }
        
        public MainWindow(Pizzeria pizzeria)//Ce contstructeur permet de revenir au menu principal tout en aillant modifier la pizzeria
        {
            this.pizzeria = pizzeria;
            this.DataContext = this;
            InitializeComponent();
        }
        #endregion
        #region Méthodes
        private void OuvrirRechercheClient(object sender, RoutedEventArgs e) // ouvre une fenetre permettant de rechercher un client
        {
            RechercheClient recherche = new RechercheClient(this.pizzeria);
            this.Close();
            recherche.Show();
        }
        private void OuvrirAffichageCommandes(object sender, RoutedEventArgs e) // ouvre une fenetre permettant de rechercher un client
        {
            AfficherLesCommandes affichage = new AfficherLesCommandes(this.pizzeria);
            this.Close();
            affichage.Show();
        }
        private void OuvrirEffectifEtClients(object sender, RoutedEventArgs e) // ouvre une fenetre permettant de rechercher un client
        {
            EffectifEtClients affichage = new EffectifEtClients(this.pizzeria);
            this.Close();
            affichage.Show();
        }

        #endregion

    }
}
