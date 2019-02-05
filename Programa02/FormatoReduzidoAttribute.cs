//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO
using System;

namespace Programa02
{
    [AttributeUsage(AttributeTargets.Class)]
    class FormatoReduzidoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoReduzidoAttribute(string formato)
        {
            this.Formato = formato;
        }
    }
}
