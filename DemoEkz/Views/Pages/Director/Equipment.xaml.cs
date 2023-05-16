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
using controls = Wpf.Ui.Controls;

namespace DemoEkz
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Equipment
    {
        private List<Models.Equipment> equipmentList;
        public Equipment()
        {
            InitializeComponent();
            using (var context = new DemoEkzDBContext())
            {
                equipmentList = context.Equipment.ToList();
                DataGrid.ItemsSource = equipmentList;
            }

            try
            {
                var propertyInfo = typeof(Models.Equipment).GetProperties();
                foreach (var item in propertyInfo)
                {
                    if (item.PropertyType == typeof(string))
                    {
                        GeneratePanel.Children.Add(new controls.TextBox
                        {
                            Name = item.Name,
                        });
                    }
                    else if (item.PropertyType == typeof(int))
                    {
                        GeneratePanel.Children.Add(new controls.NumberBoxControl.NumberBox()
                        {
                            Name = item.Name,
                        });
                    }
                }
            }
            catch
            {

            }
            
        }
    }
}
