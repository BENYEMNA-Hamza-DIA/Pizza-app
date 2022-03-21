using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    public interface IVerifiePayee//Interface qui permet de vérifier l'état des commandes
    {
        public bool VerifiePayee();//Utilisée pour ajouter une commande à la liste des commandes d'un Client 
    }
}
