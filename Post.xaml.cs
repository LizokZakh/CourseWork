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
    /// Логика взаимодействия для Post.xaml
    /// </summary>
    public partial class Post : Page
    {
        public Post()
        {
            InitializeComponent();
        }

        private void Rep_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Repertoire());
        }

        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Cash_registr());
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Account());
        }

        //private void Repertoire_Click(object sender, RoutedEventArgs e)
        //{
        //    //Manager.MainFrame.Navigate(new );
        //}
    }
}
