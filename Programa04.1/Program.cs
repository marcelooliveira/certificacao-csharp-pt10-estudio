﻿using System;
using System.Linq.Expressions;

namespace Programa04._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<float, float> metade = quo => quo / 2;
            Console.WriteLine("Metade de 9 é {0}", metade(9));

            //TAREFA: Recriar a Função acima, 
            //porém usando árvore de expressões LINQ

            //1) Criar as expressões individuais
            ParameterExpression quociente
                = Expression.Parameter(typeof(float), "quo");
            ConstantExpression divisor
                = Expression.Constant(2f, typeof(float));
            BinaryExpression opDivisao
                = Expression.Divide(quociente, divisor);

            //2) Criar a árvore de expressões

            Expression<Func<float, float>> exprMetade
                = Expression.Lambda<Func<float, float>>(opDivisao,
                new ParameterExpression[] { quociente });

            //3) Compilar e executar o código

            var metadeCompilada = exprMetade.Compile();
            Console.WriteLine("Metade de 7 é {0}", metadeCompilada(7));

            Console.ReadLine();
        }
    }
}