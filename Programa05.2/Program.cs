using System;
using System.Reflection;

namespace Programa05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Obter as informações de tipo para a classe Calculator");
            Type type = typeof(Calculator);
            Console.WriteLine("Obter as informações do método AddInt");
            MethodInfo AddIntMethodInfo = type.GetMethod("AddInt");

            Console.WriteLine("Obter as instruções IL para o método AddInt");
            MethodBody AddIntMethodBody = AddIntMethodInfo.GetMethodBody();
            // Imprima as instruções do IL.
            foreach (byte b in AddIntMethodBody.GetILAsByteArray())
            {
                Console.Write(" {0:X}", b);
            }
            Console.WriteLine();
            Console.WriteLine("Criar instância da calculadora");
            Calculator calc = new Calculator();
            Console.WriteLine("Crie uma matriz de parâmetros para o método");
            object[] inputs = new object[] { 1, 2 };

            Console.WriteLine("Chamar Invoke na informação do método");
            Console.WriteLine("Converte o resultado para um inteiro");
            int result = (int)AddIntMethodInfo.Invoke(calc, inputs);
            Console.WriteLine("Resultado de: {0}", result);
            Console.WriteLine("Chama InvokeMembe: no tipo");

            result = (int)type.InvokeMember("AddInt",
            BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
            null, calc, inputs);
            Console.WriteLine("Resultado de: {0}", result);
            Console.ReadKey();
        }
    }

    public class Calculator
    {
        public int AddInt(int v1, int v2)
        {
            return v1 + v2;
        }
    }
}




