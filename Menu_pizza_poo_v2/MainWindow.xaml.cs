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
using System.Media;


namespace Menu_pizza_poo_v2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int compteur = 0;
        public Border alpha;
        
        /// <summary>
        ///  La méthode joue de la musique dés l'ouverture du programme avec l'acceptation de l'utilisateur
        /// </summary>
        public void JouerMusique()
        {
            SoundPlayer player = new SoundPlayer("song.wav");
            player.Play();
        }
      
        // Constructeur :

        public MainWindow()
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous profitez d'une bonne musique pour vous accompagner durant votre découverte de notre pizzeria ?", "Préambule", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Voici un peu de Vivaldi ( les Quatre Saisons ) afin de vous accompagner ! ( avec une petite introduction présentant le programme 😄 ) ", "Préambule",MessageBoxButton.OK,MessageBoxImage.Information);
                    compteur = 1;
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("On vous comprend vous préférez le silence ! 😉", "Préambule", MessageBoxButton.OK, MessageBoxImage.Information);
                    compteur = 0;
                    break;
            }
            if (compteur == 1)
            {
                JouerMusique();
            }
            
            

            InitializeComponent();

           
            //Affichage.Content = new AffichageMenu();

            //VoirCommandes.Content = "Commandes\n   en cours";
        }
       

        /// <summary>
        ///  Dés qu'on clique sur le bouton, on passe à la page concernant la pizerria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Acces(object sender, RoutedEventArgs e)
        {
           Content = new PageBienvenue(this);
        }

        /// <summary>
        /// Dés qu'on clique sur le bouton une page s'affiche pour obtenir soit le rapport soit le diagramme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rapport(object sender, RoutedEventArgs e)
        {
            //MainWindow gamma=new MainWindow();
            Content = new PageRapport(this);
        }
        public void Home()
        {
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();
        }
    }
}
