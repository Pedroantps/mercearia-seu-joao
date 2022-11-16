using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ConsultaProduto
{
    public static bool InserirProduto(string nome, int quantidade, float precoUnitario, string fornecedor, string dataHoraInsercao)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
            INSERT INTO Produto (nome, quantidade, precoUnitario, fornecedor, dataHoraInsercao) 
            VALUES (@nome, @quantidade, @precoUnitario, @fornecedor, @dataHoraInsercao)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@quantidade", quantidade);
            comando.Parameters.AddWithValue("@precoUnitario", precoUnitario);
            comando.Parameters.AddWithValue("@fornecedor", fornecedor);
            comando.Parameters.AddWithValue("@dataHoraInsercao", dataHoraInsercao);
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

    public static bool ExcluirProduto(int id, string dataHoraExclusao)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiExcluido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
            UPDATE Produto
            SET dataHoraExclusao = @dataHoraExclusao
            WHERE id = @id;";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@dataHoraExclusao", dataHoraExclusao);
            var leitura = comando.ExecuteReader();
            foiExcluido = true;
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
        return foiExcluido;
    }

    public static bool AlterarProduto(int id, string nome, int quantidade, float precoUnitario, string fornecedor)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiAlterado = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
            UPDATE Produto 
            SET nome = @nome, quantidade = @quantidade, precoUnitario = @precoUnitario, fornecedor = @fornecedor
            WHERE id = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@quantidade", quantidade);
            comando.Parameters.AddWithValue("@precoUnitario", precoUnitario);
            comando.Parameters.AddWithValue("@fornecedor", fornecedor);
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
    public static List<Produto> ObterTodosProdutos()
    {

        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        List<Produto> listaDeProdutos = new List<Produto>();

        try
        {
           conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                SELECT * FROM Produto";
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                Produto produto = new Produto();
                produto.id = leitura.GetInt32("id");
                produto.nome = leitura.GetString("nome");
                produto.quantidade = leitura.GetInt32("quantidade");
                produto.precoUnitario = leitura.GetFloat("precoUnitario");
                produto.fornecedor = leitura.GetString("fornecedor");

                listaDeProdutos.Add(produto);
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
        return listaDeProdutos;
    }
}

