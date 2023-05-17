using DemoEkz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using controls = Wpf.Ui.Controls;

namespace DemoEkz
{
    public class Utils
    {
        
        public static void SpawnElements(StackPanel generatePanel, Action<string> onError)
        {
            try
            {
                var propertyInfo = typeof(models.Equipment).GetProperties();
                foreach (var item in propertyInfo)
                {
                    if (item.PropertyType == typeof(string))
                    {
                        generatePanel.Children.Add(new controls.TextBox
                        {
                            Name = item.Name,
                            BorderBrush = new SolidColorBrush(Colors.GhostWhite),
                            Width = 120
                        });
                    }
                    else if (item.PropertyType == typeof(int))
                    {
                        generatePanel.Children.Add(new controls.NumberBoxControl.NumberBox
                        {
                            Name = item.Name,
                            Width = 120,
                            BorderBrush = new SolidColorBrush(Colors.GhostWhite),
                            ClearButtonEnabled = false,
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                onError(ex.Message);
            }
        }

        public static void HideDataGridColumn(DataGrid data, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            if (propertyDescriptor.DisplayName.Substring(0, 2) == "Id") e.Column.Visibility = Visibility.Hidden;
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (propertyDescriptor.DisplayName.Contains("Id")) e.Column.Visibility = Visibility.Hidden;
            }
        }


    }
}
