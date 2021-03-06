using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    abstract public class Produit //Produit est abstract car elle n'hérite d'aucune classe et il est inutile de l'instancier
    {
        public virtual double Prix() //Selon si le Produit est une Boisson ou une Pizza, la méthode Prix est overridé dans les classes filles
        {
            return 0.0;
        }
    }
}
