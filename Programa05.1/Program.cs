using System;
using System.Reflection;

namespace Programa05
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Person);
            foreach (PropertyInfo p in type.GetProperties())
            {
                Console.WriteLine("Nome da propriedade: {0}", p.Name);
                if (p.CanRead)
                {
                    Console.WriteLine("Pode ler");
                    Console.WriteLine("Get method: {0}", p.GetMethod);
                }
                if (p.CanWrite)
                {
                    Console.WriteLine("Pode escrever");
                    Console.WriteLine("Set method: {0}", p.SetMethod);
                }
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
