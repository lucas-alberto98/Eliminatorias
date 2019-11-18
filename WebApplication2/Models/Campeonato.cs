using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Campeonato
    {
        public int Id_Campeonato { get; set; }
        public string Nome { get; set; }
        public bool Em_progresso { get; set; }
        public DateTime Data_criacao { get; set; }
    }
}
