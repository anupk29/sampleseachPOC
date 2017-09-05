using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Search_POC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlueOysterMDMaster : ContentPage
    {
        public ListView ListView;

        public BlueOysterMDMaster()
        {
            InitializeComponent();

            BindingContext = new BlueOysterMDMasterViewModel();
            ListView = MenuItemsListView;
        }

        class BlueOysterMDMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<BlueOysterMDMenuItem> MenuItems { get; set; }

            public BlueOysterMDMasterViewModel()
            {
                MenuItems = new ObservableCollection<BlueOysterMDMenuItem>(new[]
                {
                    new BlueOysterMDMenuItem { Id = 0, Title = "Home" }
                    //new BlueOysterMDMenuItem { Id = 1, Title = "Page 2" },
                    //new BlueOysterMDMenuItem { Id = 2, Title = "Page 3" },
                    //new BlueOysterMDMenuItem { Id = 3, Title = "Page 4" },
                    //new BlueOysterMDMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}