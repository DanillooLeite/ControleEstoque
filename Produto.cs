using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque
{
   
        public class Produto
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public int Quantidade { get; set; }
            public decimal Preco { get; set; }

            public Produto()
            {
            }

            public Produto(string nome, int quantidade, decimal preco)
            {
                Nome = nome;
                Quantidade = quantidade;
                Preco = preco;
            }

            public void ExibirDetalhes()
            {
                Console.WriteLine($"ID: {ID}, Nome: {Nome}, Quantidade: {Quantidade}, Preço: {Preco:C}");
            }
        }

    
}
