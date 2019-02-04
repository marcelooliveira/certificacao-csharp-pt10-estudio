#define RELATORIO_DETALHADO
//#define RELATORIO_RESUMIDO

namespace Programa01
{
    public class Venda
    {
        public string Data { get; set; }
        public string Produto { get; set; }
        public int Preco { get; set; }
        public string TipoPagamento { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string DataCriacao { get; set; }
        public string UltimoLogin { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
