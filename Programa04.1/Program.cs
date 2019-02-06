using System;
using System.Linq.Expressions;

namespace Programa04._1
{
    class Program
    {
        static void Main(string[] args)
        {
            // constrói a árvore de expressão:
            //================================

            // Expression<Func<int,float>> metade = quo => quo / 2;
            ParameterExpression quociente = Expression.Parameter(typeof(float), "quo");
            ConstantExpression divisor = Expression.Constant(2f, typeof(float));

            // operação de divisão pela metade
            BinaryExpression opMetade = Expression.Divide(quociente, divisor);

            // Cria a árvore de expressão
            Expression<Func<float, float>> metade =
                Expression.Lambda<Func<float, float>>(opMetade,
                        new ParameterExpression[] { quociente });

            // Compila a árvore e a atribui a um delegado
            Func<float, float> calculaMetade = metade.Compile();

            Console.WriteLine("Metade de 9 é {0}", calculaMetade(9));

            Console.WriteLine();

            MultiplyToAdd m = new MultiplyToAdd();


            Expression<Func<float, float>> dobro = (Expression<Func<float, float>>)m.Modify(metade);

            // Compila a árvore e a atribui a um delegado
            Func<float, float> calculaDobro = dobro.Compile();

            Console.WriteLine("Dobro de 9 é {0}", calculaDobro(9));

            Console.ReadLine();
        }
    }

    public class MultiplyToAdd : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }
        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b.NodeType == ExpressionType.Divide)
            {
                Expression left = this.Visit(b.Left);
                Expression right = this.Visit(b.Right);

                //Muda a expressão para multiplicar em vez de dividir.
                return Expression.Multiply(left, right);
            }
            return base.VisitBinary(b);
        }
    }
}