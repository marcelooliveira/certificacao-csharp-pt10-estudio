using System;
using System.Reflection;
namespace Programa05
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("Nome completo: {0}", assembly.FullName);
            AssemblyName name = assembly.GetName();
            Console.WriteLine("Versão Major: {0}", name.Version.Major);
            Console.WriteLine("Versão Minor: {0}", name.Version.Minor);
            Console.WriteLine("Está no Global Assembly Cache? {0}", assembly.GlobalAssemblyCache);
            foreach (Module assemblyModule in assembly.Modules)
            {
                Console.WriteLine(" Módulo: {0}", assemblyModule.Name);
                foreach (Type moduleType in assemblyModule.GetTypes())
                {
                    Console.WriteLine(" Tipo: {0}", moduleType.Name);
                    foreach (MemberInfo member in moduleType.GetMembers())
                    {
                        Console.WriteLine(" Membro: {0}", member.Name);
                    }
                }
            }

            Console.ReadKey();
        }
    }

    public class Person
    {
        public String Name { get; set; }
        public String Age { get; }
    }
}


