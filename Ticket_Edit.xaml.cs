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
    /// Логика взаимодействия для Ticket_Edit.xaml
    /// </summary>
    public partial class Ticket_Edit : Page
    {
        private tickets ticket;
        public Ticket_Edit()
        {
            InitializeComponent();
            ticket = Ticket.selectedTicket;
            if (ticket != null)
            {
                tbTicketCode.Text = ticket.num_ticket.ToString();
                tbUserCode.Text = ticket.id_user.ToString();
                tbEntryCode.Text = ticket.entry_id.ToString();
                tbSeatCode.Text = ticket.seat_id.ToString();
                //tbTime.Text = post.time.ToString();
                //tbDataD.Text = histor.Date_of_dissmissal.ToString();
                //cbStat.Text = histor.Status.ToString();
            }
        }
        private void ButSave_Click(object sender, RoutedEventArgs e)
        {
            string errors = default;

            if (int.Parse(tbTicketCode.Text) <= 0)
            {
                errors = "Код не может быть 0! Повторите попытку.";
            }
            else if (int.Parse(tbUserCode.Text) <= 0)
            {
                errors = "Код не может быть 0! Повторите попытку.";
            }
            if (int.Parse(tbEntryCode.Text) <= 0)
            {
                errors = "Код не может быть 0! Повторите попытку.";
            }
            else if (int.Parse(tbSeatCode.Text) <= 0)
            {
                errors = "Код не может быть 0! Повторите попытку.";
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
                int i = int.Parse(tbTicketCode.Text);
                var tick = TheatreEntities.GetContext().tickets.Where(x => x.num_ticket == i).FirstOrDefault();

                if (tick != null)
                {
                    tick.num_ticket = int.Parse(tbTicketCode.Text);
                    tick.id_user = int.Parse(tbUserCode.Text);
                    tick.entry_id = int.Parse(tbEntryCode.Text);
                    tick.seat_id = int.Parse(tbSeatCode.Text);
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
