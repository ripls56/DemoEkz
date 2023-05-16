using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CommunityToolkit.Mvvm.ComponentModel;
using DemoEkz.ViewModels;
using Wpf.Ui.Common;
using Wpf.Ui.Controls.IconElements;
using Wpf.Ui.Controls.Navigation;

namespace DemoEkz.Models
{
    /// <summary>
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow 
    {

        public DirectorViewModel ViewModel
        {
            get;
        }
        //public DirectorViewModel ViewModel;

        public DirectorWindow()
        {
            ViewModel = new DirectorViewModel();

            DataContext = this;
            InitializeComponent();
        }
    }
}
