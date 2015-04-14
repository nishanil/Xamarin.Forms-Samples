using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;

namespace WeatherCheck.ViewModel
{
   public class HomePageViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<WeatherListViewModel> ListData { get; set; }

       private bool isLoading = false;
        public bool IsLoading {
            get { return isLoading; }
            set { isLoading = value; RaisePropertyChanged(); }
        }


       public event PropertyChangedEventHandler PropertyChanged;

       public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
       {
           if(PropertyChanged!=null)
               PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
       }
    }
}
