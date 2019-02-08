using System;
using System.Diagnostics;
using System.Reflection;

namespace Programa05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tarefa 1: Obter as informações de tipo para a classe Calculadora
            //Tarefa 2: Obter as informações do método "Adiciona"
            //Tarefa 3: Obter as instruções IL para o método "Adiciona"
            //Tarefa 4: Criar instância da calculadora
            //Tarefa 5: Criar uma matriz de parâmetros para o método
            //Tarefa 6: Invocar o método


            //Tarefa 1: Obter as informações de tipo para a classe Calculator
            Console.WriteLine("Obter as informações de tipo para a classe Calculator");
            Type type = typeof(Calculadora);

            //Tarefa 2: Obter as informações do método "Adiciona"
            Console.WriteLine("Obter as informações do método Adiciona");
            MethodInfo AdicionaMethodInfo = type.GetMethod("Adiciona");

            //Tarefa 3: Obter as instruções IL para o método "Adiciona"
            Console.WriteLine("Obter as instruções IL para o método Adiciona");
            MethodBody AdicionaMethodBody = AdicionaMethodInfo.GetMethodBody();
            foreach (byte b in AdicionaMethodBody.GetILAsByteArray())
            {
                Console.Write(" {0:X}", b);
            }
            Console.WriteLine();
            //Tarefa 4: Criar instância da calculadora
            Console.WriteLine("Criar instância da calculadora");
            Calculadora calc = new Calculadora();
            
            //Tarefa 5: Criar uma matriz de parâmetros para o método
            Console.WriteLine("Crie uma matriz de parâmetros para o método");
            object[] inputs = new object[] { 1, 2 };

            //Tarefa 6: Invocar o método
            int resultado = (int)AdicionaMethodInfo.Invoke(calc, inputs);
            Console.WriteLine("Resultado: {0}", resultado);
            resultado = (int)type.InvokeMember("Adiciona",
            BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
            null, calc, inputs);
            Console.WriteLine("Resultado: {0}", resultado);
            Console.ReadKey();
        }
    }

    public class Calculadora
    {
        public int Adiciona(int valor1, int valor2)
        {
            return valor1 + valor2;
        }
    }
}




