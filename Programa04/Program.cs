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

            //adiciona o campo à classe
            classe.Members.Add(campoNome);

            //cria o campo salário
            CodeMemberField campoSalario = new CodeMemberField(typeof(decimal), "salario");

            //adiciona o campo à classe
            classe.Members.Add(campoSalario);

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
