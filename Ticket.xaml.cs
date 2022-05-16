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
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Page
    {
        public static tickets selectedTicket;
        public Ticket()
        {
            InitializeComponent();
            DGTicket.ItemsSource = TheatreEntities.GetContext().tickets.ToList();
        }
        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            selectedTicket = DGTicket.SelectedItem as tickets;
            Manager.MainFrame.Navigate(new Ticket_Edit());
            DGTicket.ItemsSource = TheatreEntities.GetContext().tickets.ToList();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ticketsForRemoving = DGTicket.SelectedItems.Cast<tickets>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ticketsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TheatreEntities.GetContext().tickets.RemoveRange(ticketsForRemoving);
                    TheatreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGTicket.ItemsSource = TheatreEntities.GetContext().tickets.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
