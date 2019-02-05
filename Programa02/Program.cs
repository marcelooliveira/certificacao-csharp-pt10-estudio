//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Programa02
{
    //Ler atributos
    class Program
    {
        static void Main(string[] args)
        {
            Relatorio relatorio = new Relatorio();
            relatorio.Imprimir();

            Console.WriteLine();
            if (Attribute.IsDefined(typeof(Venda), typeof(SerializableAttribute)))
            {
                Console.WriteLine("Venda pode ser serializada.");
            }
            else
            {
                Console.WriteLine("Venda NÃO pode ser serializada.");
            }

            Console.ReadKey();
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

            Attribute a = Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoDetalhadoAttribute));
            FormatoDetalhadoAttribute formatoDetalhado = (FormatoDetalhadoAttribute)a;

            foreach (var venda in vendas)
            {
                //Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}"
                Console.WriteLine(formatoDetalhado.Formato
                            , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento, venda.Nome, venda.Cidade, venda.Estado, venda.Pais);
            }
        }

        [Conditional("RELATORIO_RESUMIDO")]
        void ListagemResumida()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento   ");
            Console.WriteLine("==========================================================");

            Attribute a = Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoReduzidoAttribute));
            FormatoReduzidoAttribute formatoReduzido = (FormatoReduzidoAttribute)a;

            foreach (var venda in vendas)
            {
                //Console.WriteLine("{0}  {1}  {2}  {3}"
                Console.WriteLine(formatoReduzido.Formato
                    , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    class FormatoReduzidoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoReduzidoAttribute(string formato)
        {
            this.Formato = formato;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    class FormatoDetalhadoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoDetalhadoAttribute(string formato)
        {
            this.Formato = formato;
        }
    }
}
