using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public class ConsultaUsuario
{
 
    public static Usuario BuscaDados(string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        Usuario usuario = new Usuario();

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"SELECT * FROM Usuario WHERE email = @email AND senha = @senha;";
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senha);
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                usuario.id = leitura.GetInt32("id");
                usuario.nome = leitura.GetString("nome");
                usuario.email = leitura.GetString("email");
                usuario.senha = leitura.GetString("senha");
                usuario.tipoUsuario = leitura.GetString("tipoUsuario");
                usuario.dataHoraInsercao = leitura.GetDateTime("dataHoraInsercao");
                usuario.dataHoraExclusao = leitura.GetDateTime("dataHoraExclusao");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return usuario;
    }
}