using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public static class ConnModel
    {
        public static SqlConnection connect()
        {
            //definição da string de conexão
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Campeonato;Integrated Security=True");
     
            return conn;
        
        }
    }
}
