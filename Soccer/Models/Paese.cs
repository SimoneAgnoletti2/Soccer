using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Models
{
    public class Paese
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LinkImage { get; set; }
        public int Preferito { get; set; }
        public int Valido { get; set; }
        public Paese()
        {
            
        }
        public Paese(int id,string nome, string linkImage, int preferito, int valido)
        {
            Id = id;
            Nome = nome;
            LinkImage = linkImage;
            Preferito = preferito;
            Valido = valido;
        }
    }
}
