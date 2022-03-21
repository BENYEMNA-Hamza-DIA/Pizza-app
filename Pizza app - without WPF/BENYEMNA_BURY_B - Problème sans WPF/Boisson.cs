using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    public class Boisson : Produit //La classe Boisson hérite de Produit
    {
        #region Attributs
        private string typeBoisson;
        private string volume;
        #endregion

        #region Constructeur
        public Boisson(string type, string volume)
        {
            this.typeBoisson = type;
            this.volume = volume;
        }
        #endregion

        #region Propriétés
        public string TypeBoisson
        {
            get { return this.typeBoisson; }
        }

        public string Volume
        {
            get { return this.volume; }
        }
        #endregion

        #region Méthode
        /* Tarif:
         * Eau: 0.5€ pour 0.5L, 1€ pour 1.5L
         * Coca: 0.8€ pour 0.5L, 1.5€ pour 1.5L
         * Fanta: 1€ pour 0.5L, 1.8€ pour 1.5L
         * Oasis: 1.2€ pour 0.5L, 2€ pour 1.5L
         */
        public override double Prix()
        {
            /* On procède à un switch/case concernant le choix de la boissons pour le sécuriser
             * Un une fois la boisson choisie, on détermine son prix par le choix du volume
            */
            double prix = 0;
            switch (this.TypeBoisson)
            {
                case "Eau":
                    {
                        if (this.Volume == "0.5l")
                        {
                            prix = 0.5;
                        }
                        else
                        {
                            prix = 1;
                        }
                        return prix;
                    }
                case "Coca":
                    {
                        if (this.Volume == "0.5l")
                        {
                            prix = 0.8;
                        }
                        else
                        {
                            prix = 1.5;
                        }
                        return prix;

                    }


                case "Fanta":
                    {
                        if (this.Volume == "0.5l")
                        {
                            prix = 1;
                        }
                        else
                        {
                            prix = 1.8;
                        }
                        return prix;
                    }


                case "Oasis":
                    {
                        if (this.Volume == "0.5l")
                        {
                            prix = 1.2;
                        }
                        else
                        {
                            prix = 2;
                        }
                        return prix;

                    }

                default:
                    {
                        Console.WriteLine("Choix de boisson incorrecte");
                        return prix;
                    }
                    /*
                     * Si on se trompe dans le nom de la boisson ou qu'il s'agit d'une boisson indisponible, un message d'erreur s'affiche
                     */
            }

        }
        #endregion
    }
}
