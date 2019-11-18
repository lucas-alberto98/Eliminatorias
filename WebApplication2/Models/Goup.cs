using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Group<K, T>
    {
        public K Key;
        public IEnumerable<T> Values;
    }
}
