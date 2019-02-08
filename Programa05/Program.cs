using System;
using System.Diagnostics;
using System.Reflection;
namespace Programa05
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriterTraceListener consoleListener = new TextWriterTraceListener(Console.Out);
            Trace.Listeners.Add(consoleListener);

            //Tarefa 1: obter o nome completo do assembly atual
            Assembly assembly = Assembly.GetExecutingAssembly();
            Trace.WriteLine($"Nome completo: {assembly.FullName}");

            //Tarefa 2: obter a identificação do assembly atual
            AssemblyName identidadeAssembly = assembly.GetName();
            Trace.WriteLine($"Versão Major: {identidadeAssembly.Version.Major}");
            Trace.WriteLine($"Versão Minor: {identidadeAssembly.Version.Minor}");

            //Tarefa 3: descobrir se o assembly atual está no Global Assembly Cache
            Trace.WriteLine($"Está no Global Assembly Cache? {assembly.GlobalAssemblyCache}");

            //Tarefa 4: descobrir todos os módulos, tipos e membros do assembly
            foreach (Module modulo in assembly.Modules)
            {
                Trace.Indent();
                Trace.WriteLine($"Módulo: {modulo.Name}");
                foreach (Type tipoModulo in modulo.GetTypes())
                {
                    Trace.Indent();
                    Trace.WriteLine($"Tipo: {tipoModulo.Name}");
                    foreach (MemberInfo membro in tipoModulo.GetMembers())
                    {
                        Trace.Indent();
                        Trace.WriteLine($"Membro: {membro.Name} ({membro.MemberType})");
                        Trace.Unindent();
                    }
                    Trace.Unindent();
                }
                Trace.Unindent();
            }

            Console.ReadKey();
        }
    }
}


