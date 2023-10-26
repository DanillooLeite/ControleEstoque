using ControleEstoque;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

class ProdutoRepository
{
   private string connectionString = "Data Source=DESKTOP-QRHHF20;Initial Catalog=ControleEstoque;Integrated Security=True;";


    public void AdicionarProduto(Produto produto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Produtos (Nome, Quantidade, Preco) VALUES (@Nome, @Quantidade, @Preco)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nome", produto.Nome);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.Parameters.AddWithValue("@Preco", produto.Preco);

                command.ExecuteNonQuery();
            }
        }
    }

    public List<Produto> ObterTodosProdutos()
    {
        List<Produto> produtos = new List<Produto>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Produtos";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Produto produto = new Produto
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Nome = Convert.ToString(reader["Nome"]),
                            Quantidade = Convert.ToInt32(reader["Quantidade"]),
                            Preco = Convert.ToDecimal(reader["Preco"])
                        };

                        produtos.Add(produto);
                    }
                }
            }
        }

        return produtos;
    }
}
