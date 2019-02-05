//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO
using System;

namespace Programa01
{
    //Criar e aplicar atributos
    class Program
    {
        static void Main(string[] args)
        {
            Relatorio relatorio = new Relatorio("Relatório de Vendas");
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
}
