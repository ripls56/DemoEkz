using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using DemoEkz.Views.Pages.Director;
using Wpf.Ui.Common;
using Wpf.Ui.Controls.IconElements;
using Wpf.Ui.Controls.Navigation;

namespace DemoEkz.ViewModels
{
    public partial class DirectorViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<object> _navigationItems = new();

        bool _isInitialized = false;

        public DirectorViewModel()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            NavigationItems = new ObservableCollection<object>
            {
                new NavigationViewItem
                {
                    Content = "Управление инвентарем",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.WindowDevTools16 },
                    TargetPageType = typeof(Equipment)
                },
                new NavigationViewItem
                {
                    Content = "Управление планировкой цехом",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.BookDatabase24 },
                    TargetPageType = typeof(AccountingIngrAndDecor)
                },
                new NavigationViewItem
                {
                    Content = "Просмотр и изменение",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.History24 },
                    TargetPageType = typeof(HistoryView)
                },
                new NavigationViewItem
                {
                    Content = "Экспорт отчетов",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.WindowDevTools16 },
                    TargetPageType = typeof(DirectorExportPage)
                },
            };

            _isInitialized = true;
        }
    }
}
