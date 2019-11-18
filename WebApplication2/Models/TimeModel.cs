using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class TimeModel
    {
    
        public void Adicionar(Time time) {
            SqlConnection conn = ConnModel.connect();

            string sql = "INSERT INTO Time (Nome) VALUES (@nome)";
            
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.Parameters.AddWithValue("@nome", time.Nome);
           
            conn.Open();
            comando.ExecuteNonQuery();
            conn.Close();
            
            
        }

        public List<Time> Listar()
        {
            SqlConnection conn = ConnModel.connect();
            string sql = "SELECT * FROM Time";
            SqlCommand command = new SqlCommand(sql, conn);

            List<Time> times = new List<Time>();
            Time time = null;

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();
            int count = 0;

            while (reader.Read())
            {
                time = new Time();
                time.Id = (int)reader["Id"];
                time.Nome = reader["Nome"].ToString();
                

                times.Add(time);
                count++;

            }

            Debug.Write("Numero de Resultados :" + count);
            reader.Close();

            return times;
        }

        public string Exibir(int id)
        {
            SqlConnection conn = ConnModel.connect();
            string sql = "SELECT * FROM Time WHERE Id = @id";
            SqlCommand command = new SqlCommand(sql, conn);

            command.Parameters.AddWithValue("@id", id);

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();
            int count = 0;
            string nome = null;
            while (reader.Read())
            {
               
                nome = reader["Nome"].ToString();
                count++;

            }

            Debug.Write("Nome :" + nome);
            reader.Close();

            return nome;
        }
    }
}
