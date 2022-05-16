using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для Authoriz.xaml
    /// </summary>
    public partial class Authoriz : Page
    {
        private String Constring;
        private String Query;
        //public static int id;
        public Authoriz()
        {
            InitializeComponent();
            //Constring = @"Data Source=LAPTOP-O374IG7A\MSSQLSERVER01;Initial Catalog=Theatre;Integrated Security=True";
            Constring = ConfigurationManager.ConnectionStrings["TheatreConnection"].ConnectionString;
            Query = "SELECT id_user FROM dbo.users " + "WHERE login = @login and password = @password";;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Constring))
            {
                try
                {
                    conn.Open();
                    //MessageBox.Show("подключено");
                    SqlCommand command = new SqlCommand(Query, conn);
                        //using (SqlDataReader reader = command.ExecuteReader())
                        //{
                            //while (reader.Read())
                            //{
                            //    String tempEmail = reader["login"].ToString();
                            //    String tempPass = reader["password"].ToString();
                            //    User user = new User(tempEmail, tempPass, 0, "unset", false, false, false, false, false, false, false, "", false, false, false, 0, 0));
                            //    users.Add(user);
                            //}
                        command.Parameters.AddWithValue("@login", login.Text);
                        command.Parameters.AddWithValue("@password", password.Password);
                        SqlDataReader reader = command.ExecuteReader();
                    //MessageBox.Show("подключено: " + login.Text + " - " + password.Password);
                    //int id = id_user;
                    //client User = null;

                    //_login = login.Text;
                    //_password = password.Password;
                    //User = TheatreEntities.GetContext().client.Where(b => b.client_password == _password && b.client_login == _login).FirstOrDefault();

                    //if (User == null) MessageBox.Show("Не найдено");
                    //else
                    //{
                    //    MessageBox.Show("Успешно");
                    //    index = User.client_id;
                    //    Surname = User.client_surname;
                    //    ClientName = User.client_name;
                    //    Manager.MainFrame.Content = new clientMenu();
                    //}
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            //MessageBox.Show("idUser: " + id);
                            if (id == 5)
                            {
                                Manager.MainFrame.Navigate(new Admin());
                            }
                            else
                                //int index = id;
                                Manager.MainFrame.Navigate(new Post());
                        }
                        //public static int id;

                    } else
                    {
                        MessageBox.Show("Ошибка авторизации");
                    }
                    //MessageBox.Show( reader[0]);
                    //while (reader.Read())
                    //{
                    //    switch (reader[3])
                    //    {
                    //        case 1:
                    //            Manager.MainFrame.Navigate(new Post());
                    //            break;
                    //        case 2:
                    //            Manager.MainFrame.Navigate(new Admin());
                    //            break;
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ошибка подключения");
                }
            }
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Registr());
        }
    }
}
 
