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
    /// Логика взаимодействия для Poster_Edit.xaml
    /// </summary>
    public partial class Poster_Edit : Page
    {
        private poster post;
        public Poster_Edit()
        {
            InitializeComponent();
            post = Poster.selectedPoster;
            if (post != null)
            {
                tbEntryCode.Text = post.entry_id.ToString();
                tbSpecCode.Text = post.spectacle_id.ToString();
                tbUserCode.Text = post.hall_id.ToString();
                //tbDate.Text = post.date.ToString();
                //tbTime.Text = post.time.ToString();
                //tbDataD.Text = histor.Date_of_dissmissal.ToString();
                //cbStat.Text = histor.Status.ToString();
            }
        }

        private void ButSave_Click(object sender, RoutedEventArgs e)
        {
            string errors = default;

            if (int.Parse(tbEntryCode.Text) <= 0)
            {
                errors = "Код не может быть 0! Повторите попытку.";
            }
            else if (int.Parse(tbSpecCode.Text) <= 0)
            {
                errors = "Код не может быть 0! Повторите попытку.";
            }
            if (int.Parse(tbUserCode.Text) <= 0)
            {
                errors = "Код не может быть 0! Повторите попытку.";
            }
            else if (string.IsNullOrWhiteSpace(tbDate.Text))
            {
                errors = "Введите Дата спектакля!";
            }
            //else if (string.IsNullOrWhiteSpace(tbTime.Text))
            //{
            //    errors = "Введите Время спектакля!";
            //}
            //else if (string.IsNullOrWhiteSpace(tbDataD.Text))
            //{
            //    errors = "Введите Дата увольнения!";
            //}
            MessageBox.Show(errors, "Сохранения успешно изменены!", MessageBoxButton.OK);
            if (errors == default)
            {
                int i = int.Parse(tbEntryCode.Text);
                var hist = TheatreEntities.GetContext().poster.Where(x => x.entry_id == i).FirstOrDefault();

                if (hist != null)
                {
                    hist.entry_id = int.Parse(tbEntryCode.Text);
                    hist.spectacle_id = int.Parse(tbSpecCode.Text);
                    hist.hall_id = int.Parse(tbUserCode.Text);
                    hist.date = DateTime.Parse(tbDate.Text);
                    //hist.time = DateTime.Parse(tbTime.Text);
                    //hist.Date_of_dissmissal = DateTime.Parse(tbDataD.Text);
                    //hist.Status = cbStat.Text;
                    TheatreEntities.GetContext().SaveChanges();
                    this.NavigationService.GoBack();
                }
            }
        }
    }
}
