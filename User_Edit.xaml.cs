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
    /// Логика взаимодействия для User_Edit.xaml
    /// </summary>
    public partial class User_Edit : Page
    {
        private users user;
        public User_Edit()
        {
            InitializeComponent();
            user = User_tab.selectedUser;
            if (user != null)
            {
                tbUserCode.Text = user.id_user.ToString();
                tbLogin.Text = user.login.ToString();
                tbPassword.Text = user.password.ToString();
                tbSurname.Text = user.surname.ToString();
                tbName.Text = user.name.ToString();
                tbSecondName.Text = user.secondname.ToString();
                //cbStat.Text = user.Status.ToString();
            }
        }

        private void ButSave_Click(object sender, RoutedEventArgs e)
        {
            string errors = default;

            if (int.Parse(tbUserCode.Text) <= 0)
            {
                errors = "Код не может быть 0! Повторите попытку.";
            }
            else if (string.IsNullOrWhiteSpace(tbLogin.Text))
            {
                errors = "Введите логин!";
            }
            else if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                errors = "Введите Пароль!";
            }
            else if (string.IsNullOrWhiteSpace(tbSurname.Text))
            {
                errors = "Введите фамилию!";
            }
            else if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                errors = "Введите имя!";
            }
            else if (string.IsNullOrWhiteSpace(tbSecondName.Text))
            {
                errors = "Введите отчество!";
            }
            MessageBox.Show(errors, "Сохранения успешно изменены!", MessageBoxButton.OK);
            if (errors == default)
            {
                int i = int.Parse(tbUserCode.Text);
                var us = TheatreEntities.GetContext().users.Where(x => x.id_user == i).FirstOrDefault();

                if (us != null)
                {
                    us.id_user = int.Parse(tbUserCode.Text);
                    us.login = tbLogin.Text;
                    us.password = tbPassword.Text;
                    us.surname = tbSurname.Text;
                    us.name = tbName.Text;
                    us.secondname = tbSecondName.Text;
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
