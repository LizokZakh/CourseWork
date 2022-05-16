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
    /// Логика взаимодействия для Poster.xaml
    /// </summary>
    public partial class Poster : Page
    {
        public static poster selectedPoster;
        public Poster()
        {
            InitializeComponent();
            DGPoster.ItemsSource = TheatreEntities.GetContext().poster.ToList();
        }
        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            selectedPoster = DGPoster.SelectedItem as poster;
            Manager.MainFrame.Navigate(new Poster_Edit());
            DGPoster.ItemsSource = TheatreEntities.GetContext().poster.ToList();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var postersForRemoving = DGPoster.SelectedItems.Cast<poster>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {postersForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TheatreEntities.GetContext().poster.RemoveRange(postersForRemoving);
                    TheatreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGPoster.ItemsSource = TheatreEntities.GetContext().poster.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
