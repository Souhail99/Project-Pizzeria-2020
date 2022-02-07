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

namespace Menu_pizza_poo_v2
{
    /// <summary>
    /// Logique d'interaction pour PageAffichageClient.xaml
    /// </summary>
    public partial class PageAffichageClient : Page
    {
       // Attributs :

        private PageBienvenue main;
        private List<Client> clients;
        private bool premierefois = true;

        /// <summary>
        /// Permet d'afficher une liste de Clients
        /// </summary>
        /// <param name="mainWindow"></param>
        /// <param name="list">Liste de clients à afficher</param>
        public PageAffichageClient(PageBienvenue mainWindow, List<Client> list)
        {
            InitializeComponent();
            this.main = mainWindow;
            this.clients = list;
            if (list == null || list.Count <= 0 || (list.Count == 1 && list[0] == null))
            {
                TextBlock text = new TextBlock
                {
                    Text = "\n          Pas de client, revenez plus tard !"
                };
                Border rec = new Border()
                {
                    Height = 50,
                    Width = 300,
                    Background = Brushes.LightGray,
                    BorderBrush = Brushes.LightGray,
                    CornerRadius = new CornerRadius(20),
                };
                grid.Children.Add(text);
                grid.Children.Add(rec);
                Grid.SetRow(rec, 3);
                Grid.SetColumn(rec, 1);
                Grid.SetZIndex(rec, 0);
                Grid.SetRow(text, 3);
                Grid.SetColumn(text, 1);
                Grid.SetZIndex(text, 1);
            }
            else
            {
                List<TextBlock> str = new List<TextBlock> { };
                List<TextBlock> adr = new List<TextBlock> { };
                List<TextBlock> ach = new List<TextBlock> { };
                List<Border> bor = new List<Border> { };
                int compteur = 1;
                foreach (Client cli in clients)
                {
                    str.Add(new TextBlock() { Text = cli.NomFamille + " " + cli.Prenom, FontFamily = new FontFamily("Arial"), FontSize = 20, HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 5, 0, 0) });
                    adr.Add(new TextBlock() { Text = cli.Adresse, FontFamily = new FontFamily("Arial"), FontSize = 16, HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10, 40, 0, 0) });
                    ach.Add(new TextBlock() { Text = cli.AchatsCumulés.ToString() + "€", FontFamily = new FontFamily("Arial"), FontSize = 16, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 5, 10, 0) });
                    bor.Add(new Border()
                    {
                        MinHeight = 70,
                        Width = 300,
                        Background = Brushes.LightGray,
                        BorderBrush = Brushes.LightGray,
                        CornerRadius = new CornerRadius(20),
                    });
                }
                if (premierefois)
                {
                    for (int i = 0; i < str.Count; i++)
                    {
                        grid.Children.Add(str[i]);
                        grid.Children.Add(adr[i]);
                        grid.Children.Add(bor[i]);
                        grid.Children.Add(ach[i]);

                        Grid.SetRow(str[i], 1 + 2 * (i + 1));
                        Grid.SetColumn(str[i], 1);
                        Grid.SetZIndex(str[i], 1);

                        Grid.SetRow(adr[i], 1 + 2 * (i + 1));
                        Grid.SetColumn(adr[i], 1);
                        Grid.SetZIndex(adr[i], 1);

                        Grid.SetRow(ach[i], 1 + 2 * (i + 1));
                        Grid.SetColumn(ach[i], 1);
                        Grid.SetZIndex(ach[i], 1);

                        Grid.SetRow(bor[i], 1 + 2 * (i + 1));
                        Grid.SetColumn(bor[i], 1);
                        Grid.SetZIndex(bor[i], 0);
                    }
                    premierefois = false;
                }
                else
                {
                    grid.Children.Add(str[compteur - 1]);
                    grid.Children.Add(bor[compteur - 1]);
                    grid.Children.Add(adr[compteur - 1]);
                    grid.Children.Add(ach[compteur - 1]);

                    Grid.SetRow(str[compteur - 1], 1 + 2 * compteur);
                    Grid.SetColumn(str[compteur - 1], 1);
                    Grid.SetZIndex(str[compteur - 1], 1);

                    Grid.SetRow(adr[compteur - 1], 1 + 2 * compteur);
                    Grid.SetColumn(adr[compteur - 1], 1);
                    Grid.SetZIndex(adr[compteur - 1], 1);

                    Grid.SetRow(ach[compteur - 1], 1 + 2 * compteur);
                    Grid.SetColumn(ach[compteur - 1], 1);
                    Grid.SetZIndex(ach[compteur - 1], 1);

                    Grid.SetRow(bor[compteur - 1], 1 + 2 * compteur);
                    Grid.SetColumn(bor[compteur - 1], 1);
                    Grid.SetZIndex(bor[compteur - 1], 0);
                }
                compteur++;
            }
        }
        public List<Client> Clients
        {
            get 
            {
                return this.clients;
            }
        }




    }
}
