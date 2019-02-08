using Programa05_1.Modelo;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Programa05
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriterTraceListener TraceListener = new TextWriterTraceListener(Console.Out);
            Trace.Listeners.Add(TraceListener);

            //TAREFA 1: obter as propriedades de CarrinhoCliente
            //TAREFA 2: descobrir se podem ler ou escrever
            //TAREFA 3: descobrir seus acessadores getters e setters

            Type type = typeof(CarrinhoCliente);
            foreach (PropertyInfo p in type.GetProperties())
            {
                Trace.WriteLine($"Nome da propriedade: {p.Name}");
                Trace.Indent();
                if (p.CanRead)
                {
                    Trace.WriteLine($"Pode ler");
                    Trace.WriteLine($"Get method: {p.GetMethod}");
                }
                if (p.CanWrite)
                {
                    Trace.WriteLine($"Pode escrever");
                    Trace.WriteLine($"Set method: {p.SetMethod}");
                }
                Trace.Unindent();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    public class Person
    {
        public String Name { get; set; }
        public String Age { get; }
    }
}
