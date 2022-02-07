using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    interface IStatistique
    {
        // Interface permettant l'implémentation des statistique en lien avec les salariés (commis et livreurs)
        int[] NombredeCommandeGererCommis();
        int[] NombredeLivraisonsEffectues();


    }
}
