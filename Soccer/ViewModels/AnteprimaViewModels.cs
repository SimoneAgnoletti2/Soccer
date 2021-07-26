using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Connectivity;
using Soccer.Controls;
using Soccer.Models;
using Soccer.Views;
using Xamarin.Forms;

namespace Soccer.ViewModels
{
    public class AnteprimaViewModels : INotifyPropertyChanged
    {
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
        public AnteprimaViewModels(INavigation navigation)
        {
            CheckWifiOnStart();
            CheckWifiContinously();
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
        
    }
}
