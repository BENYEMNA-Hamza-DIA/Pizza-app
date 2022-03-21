using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B
{
    interface IVerifieEtat //Interface qui permet de vérifier l'état des commandes
    {
        bool VerifiePreparation(); //Utilisée pour ajouter une commande à la liste des commandes préparées par un Commis
        bool VerifieLivraison(); //Utilisée pour ajouter une commande à la liste des commandes livrées par un Livreur
    }
}
