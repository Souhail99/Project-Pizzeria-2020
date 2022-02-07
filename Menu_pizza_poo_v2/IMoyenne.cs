using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_pizza_poo_v2
{
    interface IMoyenne
    {
        // Interface permet l'écriture et héritage des méthodes en lien avec la partie Moyenne et le nombre de commande selon le temps
        double MoyennedesPrixdesCommandes();
        double MoyennedesComptesClients();
        int NombredeCommandesSelonPeriodedeTemps(int jour);

    }
}
