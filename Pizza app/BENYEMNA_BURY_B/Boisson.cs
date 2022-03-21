using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B
{
    public class Boisson : Produit
    {
        #region Attributs
        private string typeBoisson;
        private string volume;
        private string prix;
        #endregion
        #region Constructeurs
        public Boisson(string type, string volume)
        {
            this.typeBoisson = type;
            this.volume = volume;
            this.prix = this.CalculPrix() + " euros";
        }
        #endregion
        #region Propriétes
        public string TypeBoisson
        {
            get { return this.typeBoisson; }
        }

        public string Volume
        {
            get { return this.volume; }
        }

        public override string ToString()
        {
            return this.typeBoisson + " " + this.volume;
        }
        public string Prix
        {
            get { return this.prix; }
        }
        #endregion
        #region Methodes
        public override double CalculPrix()
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
