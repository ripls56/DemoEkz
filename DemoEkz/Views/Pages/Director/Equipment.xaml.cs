using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using DemoEkz.models;
using DemoEkz.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Wpf.Ui.Controls.NumberBoxControl;
using controls = Wpf.Ui.Controls;

namespace DemoEkz
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Equipment
    {
        private List<models.Equipment> equipmentList;
        public Equipment()
        {
            InitializeComponent();
            using (var context = new DemoEkzDBContext())
            {
                equipmentList = context.Equipment.ToList();
                DataGrid.ItemsSource = equipmentList;
                DataGrid.IsReadOnly = true;
                DataGrid.CanUserSortColumns = true;
                //DataGrid.Columns.Remove();
            }

            Utils.SpawnElements(GeneratePanel, error => {});
        }

        private void DataGrid_OnAutoGeneratingColumn(object? sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            Utils.HideDataGridColumn(sender as DataGrid, e);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var type = new models.Equipment().GetType();
                var inst = Activator.CreateInstance(type);
                var i = 0;
                foreach (var propertyInfo in inst.GetType().GetProperties())
                {
                    if (propertyInfo.GetMethod.IsVirtual == true)
                    {
                        continue;
                    }
                    var el = GeneratePanel.Children[i];
                    switch (el)
                    {
                        case NumberBox nm:
                            propertyInfo.SetValue(inst, int.Parse(nm.Text));
                            i++;
                            break;
                        case controls.TextBox tb:
                            propertyInfo.SetValue(inst, tb.Text);
                            i++;
                            break;
                    }
                }
                //type.GetProperties()[0].SetValue(inst, null);

                var context = new DemoEkzDBContext();
                context.Equipment.Add((models.Equipment)inst);
                context.SaveChanges();

                //foreach (TextBox item in GeneratePanel.Children)
                //{
                //    var propertyInfo = eq.GetType().GetProperties();
                //    if (item.Name == propertyInfo[GeneratePanel.Children.IndexOf(item)].Name)
                //    {

                //    }
                //}
            }
            catch
            {

            }
        }
    }
}
