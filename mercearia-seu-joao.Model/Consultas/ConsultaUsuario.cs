using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public class ConsultaUsuario
{
    public static bool InserirUsuario(string nome, string tipoUsuario, string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
            INSERT INTO Produto (nome, tipoUsuario, email, senha) 
            VALUES (@nome, @tipoUsuario, @email, @senha)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senha);
            var leitura = comando.ExecuteReader();
            foiInserido = true;
        }
        catch (Exception e)
        {          
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiInserido;
    }
    public static bool AlterarUsuario(int id, string nome, string tipoUsuario, string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiAlterado = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
            UPDATE Produto 
            SET nome = @nome, tipoUsuario = @tipoUsuario, email = @email, senha = @senha
            WHERE id = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senha);
            var leitura = comando.ExecuteReader();
            foiAlterado = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiAlterado;
    }
    public static List<Usuario> ObterTodosUsuarios()
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        List<Usuario> listaDeUsuarios = new List<Usuario>();

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                SELECT * FROM Usuario";
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                Usuario usuario = new Usuario();
                usuario.id = leitura.GetInt32("id");
                usuario.nome = leitura.GetString("nome");
                usuario.tipoUsuario = leitura.GetString("tipoUsuario");
                usuario.email = leitura.GetString("email");
                usuario.senha = leitura.GetString("senha");

                listaDeUsuarios.Add(usuario);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return listaDeUsuarios;
    }
    public static Usuario ObterUsuarioPeloEmailSenha(string email, string senha, string tipoUsuario, string nome)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        Usuario usuario = null;
        string senhaCriptografada = Criptografia.CriptografarMD5(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Usuario Where email = @email and senha = @senha";
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
            comando.Parameters.AddWithValue("@nome", nome);
            var leitura = comando.ExecuteReader();

            while (leitura.Read())
            {
                usuario = new Usuario();
                usuario.id = leitura.GetInt32("id");
                usuario.email = leitura.GetString("email");
                usuario.senha = leitura.GetString("senha");
                usuario.tipoUsuario = leitura.GetString("tipoUsuario");
                usuario.nome = leitura.GetString("nome");
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
    public static bool ObterTipoUsuario(string tipoUsuario)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool tipoEncontrado  = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Usuario Where tipoUsuario = @tipoUsuario";
            comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
            var leitura = comando.ExecuteReader();

            while (leitura.Read())
            {
                
                tipoEncontrado = true;
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

        return tipoEncontrado;
    }
}