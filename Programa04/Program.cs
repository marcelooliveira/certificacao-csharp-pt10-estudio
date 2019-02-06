using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace Programa04
{
    //Gerar código em tempo de execução usando expressões CodeDom e lambda
    class Program
    {
        static void Main(string[] args)
        {
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            //define um novo namespace de Funcionario
            CodeNamespace nameSpace = new CodeNamespace("RecursosHumanos");

            //importa o namespace System
            CodeNamespaceImport import = new CodeNamespaceImport("system");
            nameSpace.Imports.Add(import);

            //cria classe Funcionario
            CodeTypeDeclaration classe = new CodeTypeDeclaration("Funcionario");
            classe.IsClass = true;
            classe.TypeAttributes = System.Reflection.TypeAttributes.Public;


            //cria o campo nome
            CodeMemberField campoNome = new CodeMemberField(typeof(string), "nome");
            campoNome.Attributes = MemberAttributes.Public;

            //adiciona o campo à classe
            classe.Members.Add(campoNome);

            //cria o campo salário
            CodeMemberField campoSalario = new CodeMemberField(typeof(decimal), "salario");
            campoSalario.Attributes = MemberAttributes.Public;

            //adiciona o campo à classe
            classe.Members.Add(campoSalario);

            //cria o construtor da classe
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

            //Cria o provedor de modelo de código
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            //processa o documento
            using (var sw = new StreamWriter("Funcionario.cs"))
            {
                CodeGeneratorOptions options = new CodeGeneratorOptions();
                provider.GenerateCodeFromCompileUnit(codeCompileUnit, sw, options);
            }
        }
    }
}
