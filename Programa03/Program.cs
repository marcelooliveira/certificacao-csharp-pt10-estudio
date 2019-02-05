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

            Type type = relatorio.GetType();
            Console.WriteLine("Tipo de relatorio é : {0}", type.ToString());

            Console.WriteLine("Os membros de relatório são:");
            foreach (System.Reflection.MemberInfo memberInfo in type.GetMembers())
            {
                Console.WriteLine(memberInfo.ToString());
            }

            relatorio.Nome = "NOME MODIFICADO!";
            relatorio.Imprimir();

            MethodInfo methodInfo = type.GetMethod("set_Nome");
            methodInfo.Invoke(relatorio, new object[] { "NOME MODIFICADO POR REFLECTION" });
            relatorio.Imprimir();

            Console.WriteLine("Tipos do Assembly:");
            Console.WriteLine("==================");
            Assembly esteAssembly = Assembly.GetExecutingAssembly();
            Type[] tipos = esteAssembly.GetTypes();
            foreach (var tipo in tipos)
            {
                Console.WriteLine(tipo.ToString());

                if (tipo.IsInterface)
                    continue;

                if (typeof(IRelatorio).IsAssignableFrom(tipo))
                {
                    Console.WriteLine("Tipo {0} implementa a interface IRelatorio", tipo.ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine("Investigando tipos via LINQ");

            var tiposRelatorio =
                from t in tipos
                where !t.IsInterface
                    && typeof(IRelatorio).IsAssignableFrom(t)
                select t;

            Console.WriteLine();
            Console.WriteLine("Tipos que implementam a interface IRelatorio:");
            Console.WriteLine();
            foreach (var tipo in tiposRelatorio)
            {
                Console.WriteLine(tipo.ToString());
            }

            Console.WriteLine();
            if (Attribute.IsDefined(typeof(Venda), typeof(SerializableAttribute)))
            {
                Console.WriteLine("Venda pode ser serializada.");
            }
            else
            {
                Console.WriteLine("Venda NÃO pode ser serializada.");
            }

            Console.ReadLine();
        }
    }
}
