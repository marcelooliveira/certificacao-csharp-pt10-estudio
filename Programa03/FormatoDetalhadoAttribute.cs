//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO
using System;

namespace Programa03
{
    [AttributeUsage(AttributeTargets.Class)]
    class FormatoDetalhadoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoDetalhadoAttribute(string formato)
        {
            this.Formato = formato;
        }
    }
}
