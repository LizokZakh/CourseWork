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
    /// Логика взаимодействия для User_tab.xaml
    /// </summary>
    public partial class User_tab : Page
    {
        public static users selectedUser;
        public User_tab()
        {
            InitializeComponent();
            DGUser.ItemsSource = TheatreEntities.GetContext().users.ToList();
        }
        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            selectedUser = DGUser.SelectedItem as users;
            Manager.MainFrame.Navigate(new User_Edit());
            DGUser.ItemsSource = TheatreEntities.GetContext().users.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DGUser.SelectedItems.Cast<users>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TheatreEntities.GetContext().users.RemoveRange(usersForRemoving);
                    TheatreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGUser.ItemsSource = TheatreEntities.GetContext().users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
