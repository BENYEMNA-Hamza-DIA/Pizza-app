using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENYEMNA_BURY_B___Problème_sans_WPF
{
    public interface IPromo//Interface grâce à laquelle on applique des promotions aux clients de plus de 10 commandes
    {
        public bool Promo();
    }
}
