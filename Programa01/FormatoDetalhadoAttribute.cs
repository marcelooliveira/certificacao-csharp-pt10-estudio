//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO
using System;

namespace Programa01
{
    class FormatoDetalhadoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoDetalhadoAttribute(string formato)
        {
            this.Formato = formato;
        }
    }
}
