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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Page
    {
        //private users registr;
        private int reg = 0;
        private users _curretUser = new users();
        int maxid = TheatreEntities.GetContext().users.Max(u => u.id_user);
        public Registr()
        {
            InitializeComponent();
            //if (selectedUser != null)
            //{
            //    _curretUser = selectedUser;
            //    reg = 1;
            //    password.Password = _curretUser.password;
            //}
            //else
            //{
                _curretUser.id_user = maxid + 1;
            //}
            DataContext = _curretUser;
            //registr = User_tab.selectedUser;
            //if (registr != null)
            //{
            //    tbID.Text = registr.id_user.ToString();
            //    tbLogin.Text = registr.login.ToString();
            //    tbPassword.Text = registr.password.ToString();
            //    tbSurname.Text = registr.surname.ToString();
            //    tbName.Text = registr.name.ToString();
            //    tbSecondName.Text = registr.secondname.ToString();
            //    tbPhone.Text = registr.phone.ToString();
            //}
        }

        private void ButReg_Click(object sender, RoutedEventArgs e)
        {
            _curretUser.password = password.Password;
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_curretUser.login)) errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(_curretUser.password)) errors.AppendLine("Введите пароль");
            if (string.IsNullOrWhiteSpace(_curretUser.surname)) errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_curretUser.name)) errors.AppendLine("Введите имя");
            //if (string.IsNullOrWhiteSpace(_curretUser.login)) errors.AppendLine("Введите логин");
            //if (string.IsNullOrWhiteSpace(_curretUser.password)) errors.AppendLine("Введите пароль");
            //проверка пороля:
            string str2; int i = 0; bool boo; int yes = 0;
            if (_curretUser.password.Length < 6) errors.AppendLine("Пароль должен быть длиннее 6 символов");
            str2 = _curretUser.password.ToLower();
            if (_curretUser.password == str2) errors.AppendLine("В пароле должны быть большие буквы");
            char[] array = _curretUser.password.ToCharArray();
            while (_curretUser.password.Length > i)
            {
                boo = Char.IsDigit(array[i]);
                if (boo == true) yes = yes + 1;
                i = i + 1;
            }
            if (_curretUser.password.Length <= yes) errors.AppendLine("Пароль должен включать в себя ещё и буквы, большие и маленькие");
            if (yes == 0) errors.AppendLine("Пароль должен включать в себя ещё и цифры");
            //проверки длины:
            if (_curretUser.surname != null)
            {
                if (_curretUser.surname.Length > 40) errors.AppendLine("Фамилия должна быть короче 40 символов");
            }
            if (_curretUser.name != null)
            {
                if (_curretUser.name.Length > 40) errors.AppendLine("имя должно быть короче 40 символов");
            }
            if (_curretUser.secondname != null)
            {
                if (_curretUser.secondname.Length > 40) errors.AppendLine("отчество должна быть короче 40 символов");
            }
            if (_curretUser.login != null)
            {
                if (_curretUser.login.Length > 70) errors.AppendLine("Логин должна быть короче 70 символов");
            }
            if (_curretUser.password != null)
            {
                if (_curretUser.password.Length > 70) errors.AppendLine("Пароль должен быть короче 70 символов");
            }
            if (errors.Length > 0) 
            { 
                MessageBox.Show(errors.ToString()); 
                return; 
            }

            if (reg == 0) TheatreEntities.GetContext().users.Add(_curretUser);
            else
            {
                var clnts = TheatreEntities.GetContext().users.Where(b => b.id_user == _curretUser.id_user).FirstOrDefault();
                clnts.login = _curretUser.login;
                clnts.password = _curretUser.password;
                clnts.surname = _curretUser.surname;
                clnts.name = _curretUser.name;
                //clnts.surname = _curretUser.surname;
                clnts.secondname = _curretUser.secondname;
            }
            try
            {
                TheatreEntities.GetContext().SaveChanges();
                if (reg == 0) MessageBox.Show("Вы зарегестрированы!");
                else MessageBox.Show("Данные изменены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            //string errors = default;

            //if (int.Parse(tbID.Text) <= 0)
            //{
            //    errors = "Введите номер!";
            //}
            //else if (string.IsNullOrWhiteSpace(tbLogin.Text))
            //{
            //    errors = "Введите логин!";
            //}
            //else if (string.IsNullOrWhiteSpace(tbPassword.Text))
            //{
            //    errors = "Введите пароль!";
            //}
            //if (string.IsNullOrWhiteSpace(tbSurname.Text))
            //{
            //    errors = "Введите фамилию!";
            //}
            //if (string.IsNullOrWhiteSpace(tbName.Text))
            //{
            //    errors = "Введите имя!";
            //}
            //else if (string.IsNullOrWhiteSpace(tbSecondName.Text))
            //{
            //    errors = "Введите отчество!";
            //}
            //else if (string.IsNullOrWhiteSpace(tbPhone.Text))
            //{
            //    errors = "Введите номер телефона!";
            //}
            //MessageBox.Show(errors, "Вы зарегестрировались!", MessageBoxButton.OK);
            //if (errors == default)
            //{
            //    int i = int.Parse(tbID.Text);
            //    var hist = TheatreEntities.GetContext().users.Where(x => x.id_user == i).FirstOrDefault();

            //    if (hist != null)
            //    {
            //        hist.id_user = int.Parse(tbID.Text);
            //        hist.login = tbLogin.Text;
            //        hist.password = tbPassword.Text;
            //        hist.surname = tbSurname.Text;
            //        hist.name = tbName.Text;
            //        hist.secondname = tbSecondName.Text;
            //        hist.phone = tbPhone.Text;
            //        TheatreEntities.GetContext().SaveChanges();
            //        this.NavigationService.GoBack();
            //    }
            //}
        }
    }
}
