//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO

namespace Programa03
{
    interface IRelatorio
    {
        string Nome { get; set; }
        void Imprimir();
    }
}
