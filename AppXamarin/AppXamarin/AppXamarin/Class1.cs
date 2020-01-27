using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarin
{
    public class Class1 : ClsVMBase
    {
        private string name;

        public ICommand EnterCommand => new Command(EnterCommandExecute);

        

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private async void EnterCommandExecute()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Alerta mannn", "OK");
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new SecondPage());
        }
    }
}
