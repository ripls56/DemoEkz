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
using DemoEkz.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEkz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var context = new DemoEkzDBContext())
            {
                context.ArticulSpecifications.LoadAsync();
                context.DecorCakeSpecifications.LoadAsync();
                context.DecorCakes.LoadAsync();
                context.Equipment.LoadAsync();
                context.Ingridients.LoadAsync();
                context.OperationSpecifications.LoadAsync();
                context.Products.LoadAsync();
                context.Providers.LoadAsync();
                context.SemiProductSpecifications.LoadAsync();
                context.SystemUsers.LoadAsync();
                context.TypeEquipments.LoadAsync();
                context.UserOrders.LoadAsync();
            }
        }
    }
}
