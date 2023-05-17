using DemoEkz.Models;
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
using System.Windows.Shapes;
using DemoEkz.models;
using Wpf.Ui.Controls.Window;
using Wpf.Ui.Dpi;

namespace DemoEkz.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private DemoEkzDBContext context { get; set; }
        private int clicked = 0;
        private async void Auth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clicked++;
                context = new DemoEkzDBContext();
                var user = context.SystemUsers.Find(loginTB.Text, passTB.Password);
                if (user == null)
                {
                    if (clicked == 3)
                    {
                        AuthForm.IsEnabled = false;
                        for (int i = 5; i >= 0; i--)
                        {
                            snackbar.Show($"Слишком много попыток авторизации, вы заблокированы, осталось {i} секунд.");
                            await Task.Delay(1000);
                        }
                        AuthForm.IsEnabled = true;

                        //TODO Ban 5 sec
                        clicked = 0;
                        return;
                    }
                    snackbar.Show("Пользователь с таким Логином и/или Паролем не найден");
                    return;
                }
                else
                {
                    switch (user.NameRoleSystemUser)
                    {
                        case "Заказчик":
                            new ClientWindow().Show();
                            break;
                        case "Мастер":
                            new MasterWindow().Show();
                            break;
                        case "Менеджер по работе с клиентами":
                            new ClientManagerWindow().Show();
                            break;
                        case "Менеджер по закупкам":
                            new BuyManagerWindow().Show();
                            break;
                        case "Директор":
                            new DirectorWindow().Show();
                            break;
                    }
                    this.Close();
                }
            }
            catch (Exception ex) { snackbar.Show(ex.Message); }
        }

        private void Reg_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new RegistrationWindow();
            window.Show();
            this.Close();
        }
    }
}
