namespace exemplo2.api.Models
{
    public class PoliticaComercial
    {
        public long Id { get; set; }
        public decimal ValorMinimo { get; set; }
        public int PrazoDeEntrega { get; set; }
        public string Frete { get; set; }
        public string Observacao { get; set; }
        public PrazoFaturamento PrazoFaturamento { get; set; }
        public Vendedor Vendedores { get; set; }
    }
}
