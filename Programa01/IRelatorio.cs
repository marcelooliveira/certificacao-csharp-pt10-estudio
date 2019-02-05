//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO

namespace Programa01
{
    interface IRelatorio
    {
        string Nome { get; set; }
        void Imprimir();
    }
}
