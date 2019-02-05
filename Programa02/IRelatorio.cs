//#define RELATORIO_DETALHADO
#define RELATORIO_RESUMIDO

namespace Programa02
{
    interface IRelatorio
    {
        string Nome { get; set; }
        void Imprimir();
    }
}
