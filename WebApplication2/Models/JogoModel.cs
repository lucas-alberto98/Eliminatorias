using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class JogoModel
    {   Jogo jogo = new Jogo();
        public void Cadastrar(Jogo obj)
        {
            SqlConnection conn = ConnModel.connect();

            string sql = "INSERT INTO Jogo ( Id_Time1, Id_Time2, N_Rodada, Id_Campeonato) VALUES (@Id_Time1, @Id_Time2, @N_Rodada, @Id_Campeonato)";

            SqlCommand comando = new SqlCommand(sql, conn);

            comando.Parameters.AddWithValue("@Id_Time1", obj.Id_Time1);
            comando.Parameters.AddWithValue("@Id_Time2", obj.Id_Time2);
            comando.Parameters.AddWithValue("@N_Rodada", obj.N_Rodada);
            comando.Parameters.AddWithValue("@Id_Campeonato", obj.Id_Campeonato);

            conn.Open();
            comando.ExecuteNonQuery();
            conn.Close();

        }

        public List<Jogo> Listar(int id_campeonato)
        {
            SqlConnection conn = ConnModel.connect();
            string sql = "SELECT * FROM Jogo WHERE id_campeonato = @id_campeonato";
            SqlCommand command = new SqlCommand(sql, conn);

            command.Parameters.AddWithValue("@id_campeonato", id_campeonato);

            List<Jogo> jogos = new List<Jogo>();
            Jogo jogo = null;

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();
            int count = 0;

            while (reader.Read())
            {
                jogo = new Jogo();
                jogo.Id_Rodada = (int)reader["Id_Rodada"];
                jogo.Id_Campeonato = (int) reader["Id_Campeonato"];
                jogo.Id_Time1 = (int)reader["Id_Time1"];
                jogo.Id_Time2 = (int)reader["Id_Time2"];
                jogo.Vencedor = reader["Vencedor"].ToString();
                jogo.N_Rodada = (int)reader["N_Rodada"];

                jogos.Add(jogo);
                count++;

            }

            Debug.Write("Numero de Resultados :" + count);
            reader.Close();

            return jogos;
        }
    }
}
