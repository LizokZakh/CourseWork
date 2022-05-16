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

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Repertoire_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Repertoire());
        }

        private void Entry_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Poster());
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new User_tab());
        }

        private void Ticket_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Ticket());
        }
    }
}
