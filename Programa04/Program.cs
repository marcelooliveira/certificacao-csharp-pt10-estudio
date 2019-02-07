using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Programa04
{
    //Gerar código em tempo de execução usando expressões CodeDom e lambda

    class Program
    {
        static void Main(string[] args)
        {
            //TAREFA: Utilizar código C# para gerar código C#,
            //          produzindo a classe Funcionario:

            /*
            namespace RecursosHumanos
            {
                using system;
                public class Funcionario
                {
                    public string nome;
                    public decimal salario;
                    public Funcionario(string nome, decimal salario)
                    {
                    }
                }
            }
            */

            //Tarefa 1: criar uma unidade de compilação
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            //Tarefa 2: criar o namespace RecursosHumanos
            CodeNamespace nameSpace = new CodeNamespace("RecursosHumanos");

            //Tarefa 2.1: importar o namespace System
            CodeNamespaceImport import = new CodeNamespaceImport("system");
            nameSpace.Imports.Add(import);

            //Tarefa 2.2: criar a classe Funcionario
            CodeTypeDeclaration classe = new CodeTypeDeclaration("Funcionario");
            classe.IsClass = true;
            classe.TypeAttributes = System.Reflection.TypeAttributes.Public;

            //Tarefa 2.3: criar o campo nome
            CodeMemberField campoNome = new CodeMemberField(typeof(string), "nome");
            campoNome.Attributes = MemberAttributes.Public;

            //adiciona o campo à classe
            classe.Members.Add(campoNome);

            //Tarefa 2.4: criar o campo salário
            CodeMemberField campoSalario = new CodeMemberField(typeof(decimal), "salario");
            campoSalario.Attributes = MemberAttributes.Public;

            //adiciona o campo à classe
            classe.Members.Add(campoSalario);

            //Tarefa 2.5: criar o construtor da classe
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public;
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "nome"));
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(decimal), "salario"));

            //adiciona o construtor à classe
            classe.Members.Add(constructor);

            //adiciona classe ao namespace
            nameSpace.Types.Add(classe);

            //adiciona o namespace ao documento
            codeCompileUnit.Namespaces.Add(nameSpace);

            //Tarefa 3: cria o provedor de modelo de código
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            //Tarefa 4: gerar código e salva o arquivo
            using (var sw = new StreamWriter("Funcionario.cs"))
            {
                CodeGeneratorOptions options = new CodeGeneratorOptions();
                provider.GenerateCodeFromCompileUnit(codeCompileUnit, sw, options);
            }
        }
    }
}
