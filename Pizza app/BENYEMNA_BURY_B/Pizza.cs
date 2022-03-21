using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B
{
    public class Pizza : Produit
    {
        #region Attributs
        private string type;
        private string taille;
        private string prix;
        #endregion
        #region Constructeurs
        public Pizza(string type, string taille)
        {
            this.type = type;
            this.taille = taille;
            this.prix = this.CalculPrix() + " euros";
        }
        #endregion
        #region Propriétés
        public string Type { get => type; }
        public string Taille { get => taille; }
        public override string ToString()
        {
            return this.type + " " + this.taille;
        }
        public string Prix
        {
            get { return this.prix; }
        }
        #endregion
        #region Méthodes
        /* Tarifs:
         * Margherita: 15€ la grande, 10€ la moyenne, 5€ la petite
         * Quatre Fromages: 16€ la grande, 11€ la moyenne, 6€ la petite
         * Chèvre Miel: 17€ la grande, 12€ la moyenne, 7€ la petite
         * Royale: 18€ la grande, 13€ la moyenne, 8€ la petite
         */
        public override double CalculPrix()
        {
            /* On procède à un switch/case concernant le choix de la boissons pour le sécuriser
             * Un une fois la pizza choisie, on détermine son prix par le choix de la taille
            */
            double prix = 0;
            switch (this.Type)
            {
                case "Margherita":
                    {
                        if (this.Taille == "Grande")
                        {
                            prix = 15;
                        }
                        else if (this.Taille == "Moyenne")
                        {
                            prix = 10;
                        }
                        else
                        {
                            prix = 5;
                        }
                        return prix;
                    }
                case "Royale":
                    {
                        if (this.Taille == "Grande")
                        {
                            prix = 18;
                        }
                        else if (this.Taille == "Moyenne")
                        {
                            prix = 13;
                        }
                        else
                        {
                            prix = 8;
                        }
                        return prix;
                    }


                case "Chèvre Miel":
                    {
                        if (this.Taille == "Grande")
                        {
                            prix = 17;
                        }
                        else if (this.Taille == "Moyenne")
                        {
                            prix = 12;
                        }
                        else
                        {
                            prix = 7;
                        }
                        return prix;
                    }


                case "Quatre Fromages":
                    {
                        if (this.Taille == "Grande")
                        {
                            prix = 16;
                        }
                        else if (this.Taille == "Moyenne")
                        {
                            prix = 11;
                        }
                        else
                        {
                            prix = 6;
                        }
                        return prix;

                    }
                default:
                    {
                        Console.WriteLine("Choix de pizza incorrecte");
                        return prix;
                    }
                    /*
                    * Si on se trompe dans le nom de la pizza ou qu'il s'agit d'une pizza indisponible, un message d'erreur s'affiche
                    */

            }


        }
        #endregion
    }
}
