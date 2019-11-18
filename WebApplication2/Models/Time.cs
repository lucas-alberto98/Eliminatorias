using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Time
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static implicit operator Time(TimeModel v)
        {
            throw new NotImplementedException();
        }
    }
}
