using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Jogo
    {
        public int Id_Rodada { set; get;}
        public int Id_Time1 {get; set;}
        public int Id_Time2 {get; set;}
        public string Vencedor { get; set;}
        public int N_Rodada { get; set;}
        public int Id_Campeonato { get; set; }
        public string Nome { get; set; }
    }
}
