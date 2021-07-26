using SQLite;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Soccer.Models
{
    public class Utente
    {
        [PrimaryKey]
        public string Nome { get; set; }
        public string Password { get; set; }
        public int Mantain { get; set; }
        public float Saldo { get; set; }
        public string Ip { get; set; } 
        public Utente(string name, string password, int mantain)
        {
            Nome = name;
            Password = password;
            Mantain = mantain;
            Saldo = 100;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Ip = ip.ToString();
                }
            }
        }

        public Utente()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Ip = ip.ToString();
                }
            }
        }

        public Utente(string name)
        {
            Nome = name; 
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Ip = ip.ToString();
                }
            }
        }


        public Utente(string name, string password, int mantain, float saldo)
        {

            Nome = name;
            Password = password;
            Mantain = mantain;
            Saldo = saldo;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Ip = ip.ToString();
                }
            }

        }
    }
}
