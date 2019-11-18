using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class CampeonatosModel
    {
        Campeonato campeonato = new Campeonato();
        public List<Campeonato> listaCampeonatos()
        {
            SqlConnection conn = ConnModel.connect();
            string sql = "SELECT * FROM Campeonato";
            SqlCommand command = new SqlCommand(sql, conn);

            List<Campeonato> campeonatos = new List<Campeonato>();
            Campeonato campeonato = null;

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();
            int count = 0;

            while (reader.Read())
            {
                campeonato = new Campeonato();
                campeonato.Id_Campeonato = (int) reader["Id_Campeonato"];
                campeonato.Nome = reader["Nome"].ToString();
                campeonato.Em_progresso = (bool) reader["Em_progresso"];
                campeonato.Data_criacao = (DateTime)reader["Data_criacao"];

                campeonatos.Add(campeonato);
                count++;
                
            }

            Debug.Write("Numero de Resultados :" + count);
            reader.Close();

            return campeonatos;
        }

        public void Cadastrar(Campeonato obj) {
            SqlConnection conn = ConnModel.connect();

            string sql = "INSERT INTO Campeonato (Nome) VALUES (@nome)";

            SqlCommand comando = new SqlCommand(sql, conn);
            comando.Parameters.AddWithValue("@nome", obj.Nome);

            conn.Open();
            comando.ExecuteNonQuery();
            conn.Close();
        }
    }
}
