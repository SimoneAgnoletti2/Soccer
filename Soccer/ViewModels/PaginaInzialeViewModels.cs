using Plugin.Connectivity;
using Soccer.Controls;
using Soccer.Models;
using Soccer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Soccer.ViewModels
{
    public class PaginaInzialeViewModels : INotifyPropertyChanged
    {
        public ICommand nuovaschedina { get; private set; }

        public ICommand NuovaSchedina
        {
            get { return nuovaschedina; }
            set
            {
                if (nuovaschedina != value)
                    nuovaschedina = value;
                OnPropertyChanged("NuovaSchedina");
            }
        }

        public ICommand schedineincorso { get; private set; }

        public ICommand SchedineInCorso
        {
            get { return schedineincorso; }
            set
            {
                if (schedineincorso != value)
                    schedineincorso = value;
                OnPropertyChanged("SchedineInCorso");
            }
        }

        public ICommand storicoschedine { get; private set; }

        public ICommand StoricoSchedine
        {
            get { return storicoschedine; }
            set
            {
                if (storicoschedine != value)
                    storicoschedine = value;
                OnPropertyChanged("StoricoSchedine");
            }
        }

        public ICommand classifichecampionati { get; private set; }

        public ICommand ClassificheCampionati
        {
            get { return classifichecampionati; }
            set
            {
                if (classifichecampionati != value)
                    classifichecampionati = value;
                OnPropertyChanged("ClassificheCampionati");
            }
        }

        public ICommand classifichegiocatori { get; private set; }

        public ICommand ClassificheGiocatori
        {
            get { return classifichegiocatori; }
            set
            {
                if (classifichegiocatori != value)
                    classifichegiocatori = value;
                OnPropertyChanged("ClassificheGiocatori");
            }
        }

        public ICommand impostazioni { get; private set; }

        public ICommand Impostazioni
        {
            get { return impostazioni; }
            set
            {
                if (impostazioni != value)
                    impostazioni = value;
                OnPropertyChanged("Impostazioni");
            }
        }
        public ICommand meseAvanti { get; private set; }

        public ICommand MeseAvanti
        {
            get { return meseAvanti; }
            set
            {
                if (meseAvanti != value)
                    meseAvanti = value;
                OnPropertyChanged("MeseAvanti");
            }
        }

        public ICommand meseIndietro { get; private set; }
        public ICommand MeseIndietro
        {
            get { return meseIndietro; }
            set
            {
                if (meseIndietro != value)
                    meseIndietro = value;
                OnPropertyChanged("MeseIndietro");
            }
        }
        public string title { get; set; }

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                    title = value;
                OnPropertyChanged("Title");
            }
        }

        public string name { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                    name = value;
                OnPropertyChanged("Mese");
            }
        }

        public string mese { get; set; }

        public string Mese
        {
            get { return mese; }
            set
            {
                if (mese != value)
                    mese = value;
                OnPropertyChanged("Mese");
            }
        }

        public string sgiocate { get; set; }

        public string Sgiocate
        {
            get { return sgiocate; }
            set
            {
                if (sgiocate != value)
                    sgiocate = value;
                OnPropertyChanged("Sgiocate");
            }
        }

        public string svinte { get; set; }

        public string Svinte
        {
            get { return svinte; }
            set
            {
                if (svinte != value)
                    svinte = value;
                OnPropertyChanged("Svinte");
            }
        }

        public string sincorso { get; set; }

        public string Sincorso
        {
            get { return svinte; }
            set
            {
                if (sincorso != value)
                    sincorso = value;
                OnPropertyChanged("Sincorso");
            }
        }

        public string saldo { get; set; }

        public string Saldo
        {
            get { return saldo; }
            set
            {
                if (saldo != value)
                    saldo = value;
                OnPropertyChanged("Saldo");
            }
        }
        public bool avanti { get; set; }

        public bool Avanti
        {
            get { return avanti; }
            set
            {
                if (avanti != value)
                    avanti = value;
                OnPropertyChanged("Avanti");
            }
        }

        public bool indietro { get; set; }

        public bool Indietro
        {
            get { return indietro; }
            set
            {
                if (indietro != value)
                    indietro = value;
                OnPropertyChanged("Indietro");
            }
        }

        private bool _conn { get; set; }
        public bool NotConn
        {
            get { return _conn; }
            set
            {
                if (_conn != value)
                    _conn = value;
                OnPropertyChanged("NotConn");
            }
        }

        private bool conn { get; set; }

        public bool Conn
        {
            get { return conn; }
            set
            {
                if (conn != value)
                    conn = value;
                OnPropertyChanged("Conn");
            }
        }

        public DateTime dataimpostata;

        public PaginaInzialeViewModels(INavigation navigation)
        {
            CheckWifiOnStart();
            CheckWifiContinously();
            DatabaseUser dbu = new DatabaseUser();
            string n = Preferences.Get("Nome", "");
            Name = n;
            Title = "Pagina iniziale";
            dataimpostata = DateTime.Today;
            Mese = FirstLetterToUpper(dataimpostata.ToString("MMMM", CultureInfo.CurrentCulture) + " " + dataimpostata.Year);
            Indietro = true;
            meseIndietro = new Command(scorriMeseIndietro);
            Avanti = false;
            meseAvanti = new Command(scorriMeseAvanti);
            Sgiocate = "0";
            Svinte = "0";
            Saldo = "0€";

            nuovaschedina = new Command(gotoNuovaSchedina);
            schedineincorso = new Command(gotoSchedineInCorso);
            storicoschedine = new Command(gotoStoricoSchedine);
            classifichecampionati = new Command(gotoClassificheCampionati);
            classifichegiocatori = new Command(gotoClassificheGiocatori);
            impostazioni = new Command(gotoImpostazioni);
        }

        public void scorriMeseIndietro(object s)
        {
            dataimpostata = dataimpostata.AddMonths(-1);
            Mese = FirstLetterToUpper(dataimpostata.ToString("MMMM", CultureInfo.CurrentCulture) + " " + dataimpostata.Year);
            Indietro = true;
            Avanti = true;

            
        }

        public void scorriMeseAvanti(object s)
        {
            dataimpostata = dataimpostata.AddMonths(1);
            Mese = FirstLetterToUpper(dataimpostata.ToString("MMMM", CultureInfo.CurrentCulture) + " " + dataimpostata.Year);
            Indietro = true;
            if (dataimpostata.Month != DateTime.Today.Month)
                Avanti = true;
            else
                Avanti = false;

            
        }

        public async void gotoNuovaSchedina(object s)
        {
            await Shell.Current.GoToAsync("//Menu/NuovaSchedina");
        }

        public async void gotoSchedineInCorso(object s)
        {
            await Shell.Current.GoToAsync("//Menu/SchedineInCorso");
        }

        public async void gotoStoricoSchedine(object s)
        {
            await Shell.Current.GoToAsync("//Menu/StoricoSchedine");
        }
        public async void gotoClassificheCampionati(object s)
        {
            await Shell.Current.GoToAsync("//Menu/ClassificheCampionati");
        }
        public async void gotoClassificheGiocatori(object s)
        {
            await Shell.Current.GoToAsync("//Menu/ClassificheGiocatori");
        }
        public async void gotoImpostazioni(object s)
        {
            await Shell.Current.GoToAsync("//Menu/Impostazioni");
        }



        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CheckWifiOnStart()
        {
            NotConn = CrossConnectivity.Current.IsConnected ? false : true;
            if (NotConn)
                Conn = false;
            else
                Conn = true;


        }

        public void CheckWifiContinously()
        {
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                NotConn = args.IsConnected ? false : true;
                if (NotConn)
                    Conn = false;
                else
                    Conn = true;

            };
        }
        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }


    }

}
