//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO
using System;

namespace Programa01
{
    class FormatoReduzidoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoReduzidoAttribute(string formato)
        {
            this.Formato = formato;
        }
    }
}
