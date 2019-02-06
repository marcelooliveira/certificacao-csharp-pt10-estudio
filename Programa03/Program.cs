//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Programa03
{
    //Usar reflection
    class Program
    {
        static void Main(string[] args)
        {
            Relatorio relatorio = new Relatorio("Relatório de Vendas");
            relatorio.Imprimir();

            Console.WriteLine();
            if (Attribute.IsDefined(typeof(Venda), typeof(SerializableAttribute)))
            {
                Console.WriteLine("A classe Venda DEFINE o atributo Serializable");
            }
            else
            {
                Console.WriteLine("A classe Venda NÃO DEFINE o atributo Serializable");
            }
            Console.WriteLine();

            //TAREFA 1: 
            Console.WriteLine("OBTENDO O TIPO DO RELATÓRIO");
            Console.WriteLine("===========================");

            Type type = relatorio.GetType();
            Console.WriteLine(type.ToString());

            //TAREFA 2: 
            Console.WriteLine();
            Console.WriteLine("OBTENDO OS MEMBROS DO RELATÓRIO");
            Console.WriteLine("===============================");
            Console.WriteLine();

            foreach (System.Reflection.MemberInfo memberInfo in type.GetMembers())
            {
                Console.WriteLine(memberInfo.ToString());
            }

            //TAREFA 3: 
            Console.WriteLine();
            Console.WriteLine("MODIFICANDO NOME VIA REFLECTION");
            Console.WriteLine("===============================");
            Console.WriteLine();

            relatorio.Nome = "NOME MODIFICADO!";
            relatorio.Imprimir();

            MethodInfo methodInfo = type.GetMethod("set_Nome");
            methodInfo.Invoke(relatorio, new object[] { "NOME MODIFICADO POR REFLECTION" });
            relatorio.Imprimir();

            //TAREFA 4: 
            //     E 5: 

            Console.WriteLine();
            Console.WriteLine("TIPOS DO ASSEMBLY");
            Console.WriteLine("QUE IMPLEMENTAM A INTERFACE IRelatorio");
            Console.WriteLine("======================================");
            Assembly esteAssembly = Assembly.GetExecutingAssembly();
            Type[] tipos = esteAssembly.GetTypes();
            foreach (var tipo in tipos)
            {
                if (tipo.IsInterface)
                    continue;

                if (typeof(IRelatorio).IsAssignableFrom(tipo))
                {
                    Console.WriteLine(tipo.ToString());
                }
            }

            //TAREFA 6: 
            Console.WriteLine();
            Console.WriteLine("USANDO LINQ PARA VER TIPOS DO ASSEMBLY");
            Console.WriteLine("QUE IMPLEMENTAM A INTERFACE IRelatorio");
            Console.WriteLine("======================================");

            var tiposRelatorio =
                from t in tipos
                where !t.IsInterface
                    && typeof(IRelatorio).IsAssignableFrom(t)
                select t;

            foreach (var tipo in tiposRelatorio)
            {
                Console.WriteLine(tipo.ToString());
            }

            Console.ReadLine();
        }
    }
}
