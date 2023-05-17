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
using Wpf.Ui.Dpi;

namespace DemoEkz.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        

        private void Reg_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var context = new DemoEkzDBContext();
                var login = loginTB.Text;
                var pass = passTB.Password;
                if (pass.Length <= 4) { snackbar.Show("Пароль должен быть от 5 символов."); return; }
                if (pass.Length >= 21) { snackbar.Show("Пароль должен быть до 20 символов."); return; }
                if (pass.Contains(login)) { snackbar.Show("Пароль не должен содержать логин."); return; }
                if (isUpper(pass) == false) { snackbar.Show("В пароле должен быть хотя-бы 1 заглавный символ."); return; }
                if (isLower(pass) == false) { snackbar.Show("В пароле должен быть хотя-бы 1 прописной символ."); return; }
                if (pass != passRepeatTB.Password) { snackbar.Show("Пароли не совпадают"); return; }
                var user = new SystemUser
                {
                    LoginSystemUser = login,
                    PasswordSystemUser = pass,
                    NameRoleSystemUser = RoleCB.Text
                };
                if (LastName.Text != "") user.LastnameSystemUser = LastName.Text;
                if (Name.Text != "") user.NameSystemUser = Name.Text;
                if (MiddleName.Text != "") user.SurenameSystemUser = MiddleName.Text;
                context.SystemUsers.Add(user);
                context.SaveChanges();
            }
            catch (Exception ex) { snackbar.Show(ex.Message); }
        }

        public bool isUpper(string text)
        {
            foreach (char t in text)
                if (Char.IsUpper(t)) return true;
            return false;
        }

        public bool isLower(string text)
        {
            foreach (char t in text)
                if (Char.IsLower(t)) return true;
            return false;
        }

        private void Auth_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var window = new AuthWindow();
                window.Show();
                this.Close();
            }
            catch (Exception exception)
            {
            }
        }

    }
}
