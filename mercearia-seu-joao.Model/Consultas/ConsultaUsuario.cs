using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public class ConsultaUsuario
{
    public static Usuario ObterUsuarioPeloEmailSenha(string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        Usuario usuario = null;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Usuario Where email = @email and senha = @senha";
            comando.Parameters.AddWithValue("@senha", senha);
            comando.Parameters.AddWithValue("@email", email);
            var leitura = comando.ExecuteReader();

            while (leitura.Read())
            {
                usuario = new Usuario();
                usuario.id = leitura.GetInt32("id");
                usuario.email = leitura.GetString("email");
                usuario.senha = leitura.GetString("senha");
                break;
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        finally
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        return usuario;
    }
}