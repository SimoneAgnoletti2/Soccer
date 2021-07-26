using Acr.UserDialogs;
using Soccer.Controls;
using Soccer.Models;
using Soccer.Resources;
using Soccer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Soccer.ViewModels
{
    public class ClassificheCampViewModels : INotifyPropertyChanged
    {
        public INavigation _Navigation;
        public ICommand selezionapaese { get; private set; }

        public ICommand SelezionaPaese
        {
            get { return selezionapaese; }
            set
            {
                if (selezionapaese != value)
                    selezionapaese = value;
                OnPropertyChanged("SelezionaPaese");
            }
        }

        public ObservableCollection<Paese> listaCountry { get; set; }
        public ObservableCollection<Paese> ListaCountry
        {
            get { return listaCountry; }
            set
            {
                if (listaCountry != value)
                    listaCountry = value;
                OnPropertyChanged("ListaCountry");
            }
        }

        public Command ItemTappedCommand
        {
            get
            {
                return new Command((data) =>
                {
                    UserDialogs.Instance.Alert("FlowListView", data + "", "Ok");
                });
            }
        }

        public ClassificheCampViewModels(INavigation navigation)
        {

            DatabasePaesi dtp = new DatabasePaesi();
            Task<List<Paese>> task = Task.Run<List<Paese>>(async () => await dtp.getPaesi());
            List<Paese> lsc = new List<Paese>();
            listaCountry = new ObservableCollection<Paese>();
            lsc = task.Result;
            foreach (Paese p in lsc)
            {
                ListaCountry.Add(p);
            }
            //_Navigation = navigation;

            //selezionapaese = new Command(gotoPaesi);


        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void gotoPaesi(object s)
        {
            //await _Navigation.PushAsync(new ListaCountry());
        }
    }
}
