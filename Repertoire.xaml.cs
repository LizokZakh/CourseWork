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
    /// Логика взаимодействия для Repertoire.xaml
    /// </summary>
    public partial class Repertoire : Page
    {
        public static repertoire selectedRep;
        public Repertoire()
        {
            InitializeComponent();
            TheatreEntities db = new TheatreEntities();
            DGRep.ItemsSource = db.repertoire.ToList();
            //DGRep.ItemsSource = TheatreEntities.GetContext().repertoire.ToList();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var repertoiresForRemoving = DGRep.SelectedItems.Cast<repertoire>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {repertoiresForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TheatreEntities.GetContext().repertoire.RemoveRange(repertoiresForRemoving);
                    TheatreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGRep.ItemsSource = TheatreEntities.GetContext().repertoire.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
