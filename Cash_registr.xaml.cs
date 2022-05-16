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
    /// Логика взаимодействия для Cash_registr.xaml
    /// </summary>
    /// 
    public partial class Cash_registr : Page
    {

        public Cash_registr()
        {
            InitializeComponent();
            FillSpectacle();
            //ComboSpectacle.ItemsSource = TheatreEntities.GetContext().repertoire.ToList();
        }
        void FillSpectacle()
        {
            TheatreEntities obj = new TheatreEntities();
            List<repertoire> lst = obj.repertoire.ToList();
            ComboSpectacle.ItemsSource = lst;
        }

        private void ComboSpectacle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SpectacleID = Convert.ToInt32(ComboSpectacle.SelectedValue);
            TheatreEntities obj = new TheatreEntities();
            List<poster> lst_date = obj.poster.Where(x=>x.spectacle_id == SpectacleID).ToList();
            ComboDate.ItemsSource = lst_date;
            //List<poster> lst_time = obj.poster.Where(x => x.spectacle_id == SpectacleID).ToList();
            //ComboTime.ItemsSource = lst_time;
            //List<poster> lst_hall = obj.poster.Where(x => x.spectacle_id == SpectacleID).ToList();
            //ComboHall.ItemsSource = lst_hall;
            //List<free_seats> lst_row = obj.free_seats.Where(x => x.spectacle_id == SpectacleID).ToList();
            //ComboRow.ItemsSource = lst_row.Select(x => new { x.row }).Distinct().ToList();
            //List<free_seats> lst_seat = obj.free_seats.Distinct().Where(x => x.spectacle_id == SpectacleID).ToList();
            //ComboSeat.ItemsSource = lst_seat.Select(x => new { x.seat }).Distinct().ToList();
        }

        //private void ButCash_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Я купиль");
        //}

        private void ComboDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SpectacleID = Convert.ToInt32(ComboSpectacle.SelectedValue);
            int DateID = Convert.ToInt32(ComboDate.SelectedValue);
            TheatreEntities obj = new TheatreEntities();
            List<poster> lst_time = obj.poster.Where(x => x.spectacle_id == SpectacleID && x.entry_id == DateID).ToList();
            ComboTime.ItemsSource = lst_time;
        }

        private void ComboTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SpectacleID = Convert.ToInt32(ComboSpectacle.SelectedValue);
            int TimeID = Convert.ToInt32(ComboTime.SelectedValue);
            TheatreEntities obj = new TheatreEntities();
            List<poster> lst_hall = obj.poster.Where(x => x.spectacle_id == SpectacleID && x.entry_id == TimeID).ToList();
            ComboHall.ItemsSource = lst_hall;
        }

        private void ComboHall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SpectacleID = Convert.ToInt32(ComboSpectacle.SelectedValue);
            int TimeID = Convert.ToInt32(ComboTime.SelectedValue);
            int HallID = Convert.ToInt32(ComboHall.SelectedValue);
            TheatreEntities obj = new TheatreEntities();
            List<free_seats> lst_row = obj.free_seats.Where(x => x.spectacle_id == SpectacleID && x.entry_id == TimeID && x.hall_id == HallID).ToList();
            ComboRow.ItemsSource = lst_row.Select(x => new { x.row }).Distinct().ToList(); ;
        }

        private void ComboRow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SpectacleID = Convert.ToInt32(ComboSpectacle.SelectedValue);
            int TimeID = Convert.ToInt32(ComboTime.SelectedValue);
            int HallID = Convert.ToInt32(ComboHall.SelectedValue);
            int RowID = Convert.ToInt32(ComboRow.SelectedValue);
            TheatreEntities obj = new TheatreEntities();
            List<free_seats> lst_seat = obj.free_seats.Where(x => x.spectacle_id == SpectacleID && x.entry_id == TimeID && x.hall_id == HallID && x.row == RowID).ToList();
            ComboSeat.ItemsSource = lst_seat.Select(x => new { x.seat }).Distinct().ToList(); ;
        }
        private void ButCash_Click(object sender, RoutedEventArgs e)
        {
            int DateID = Convert.ToInt32(ComboDate.SelectedValue);
            int HallID = Convert.ToInt32(ComboHall.SelectedValue);
            int RowID = Convert.ToInt32(ComboRow.SelectedValue);
            int SeatID = Convert.ToInt32(ComboSeat.SelectedValue);
            //int id = id_user.users;
            //var id = Guid.NewGuid();
            TheatreEntities obj = new TheatreEntities();
            var last_id = obj.tickets.Count();
            var seat = obj.seat.Where(x => x.hall_id == HallID && x.row == RowID && x.seat1 == SeatID).Select(x => x.seat_id).FirstOrDefault();
            tickets ticket = new tickets
            {
                num_ticket = last_id + 1,
                id_user = 1,
                entry_id = DateID,
                seat_id = seat
            };
            obj.tickets.Add(ticket);
            obj.SaveChanges();
            MessageBox.Show(last_id + 1 + ", Я купиль: " + seat.ToString() + " - " + ticket.num_ticket);
            
        }

    }
}
