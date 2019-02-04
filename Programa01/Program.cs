//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Programa01
{
    //Criar e aplicar atributos
    class Program
    {
        static void Main(string[] args)
        {
            Relatorio relatorio = new Relatorio();
            relatorio.Imprimir();

            Console.ReadKey();
        }
    }

    [Serializable]
    class Pessoa
    {
        public string nome;
        public int idade;
        [NonSerialized]
        private int filhos;

        public Pessoa(string nome, int idade)
        {
            this.nome = nome;
            this.idade = idade;
            this.filhos = 0;
        }
    }

    class Relatorio
    {
        readonly IList<Venda> vendas;

        public Relatorio()
        {
            vendas = JsonConvert.DeserializeObject<List<Venda>>(File.ReadAllText("Vendas.json"));
        }

        public void Imprimir()
        {
            Cabecalho();
            ListagemResumida();
            ListagemDetalhada();
        }

        [Conditional("RELATORIO_DETALHADO"), Conditional("RELATORIO_RESUMIDO")]
        void Cabecalho()
        {
            Console.WriteLine("Relatório de Vendas");
            Console.WriteLine("===================");
        }

        [Conditional("RELATORIO_DETALHADO")]
        void ListagemDetalhada()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento Nome                  Cidade                Região                Pais");
            Console.WriteLine("==========================================================================================================================================");
            foreach (var venda in vendas)
            {
                Console.WriteLine($"{venda.Data,-12}  {venda.Produto,-12}  {venda.Preco,12:C}  {venda.TipoPagamento,-12:C}  {venda.Nome,-20:C}  {venda.Cidade,-20:C}  {venda.Estado,-20:C}  {venda.Pais,-20:C}");
            }
        }

        [Conditional("RELATORIO_RESUMIDO")]
        void ListagemResumida()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento   ");
            Console.WriteLine("==========================================================");
            foreach (var venda in vendas)
            {
                Console.WriteLine($"{venda.Data,-12}  {venda.Produto,-12}  {venda.Preco,12:C}  {venda.TipoPagamento,-12:C}");
            }
        }
    }
}
