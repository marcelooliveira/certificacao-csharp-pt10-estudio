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
            Trace.Indent();
            foreach (Module modulo in assembly.Modules)
            {
                Trace.WriteLine($"Módulo: {modulo.Name}");
                Trace.Indent();
                foreach (Type tipoModulo in modulo.GetTypes())
                {
                    Trace.WriteLine($"Tipo: {tipoModulo.Name}");
                    Trace.Indent();
                    foreach (MemberInfo membro in tipoModulo.GetMembers())
                    {
                        Trace.WriteLine($"Membro: {membro.Name} ({membro.MemberType})");
                    }
                    Trace.Unindent();
                }
                Trace.Unindent();
            }
            Trace.Unindent();

            Console.ReadKey();
        }
    }
}


