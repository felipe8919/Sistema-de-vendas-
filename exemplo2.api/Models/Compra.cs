namespace exemplo2.api.Models
{
    public class Compra
    {
        public long Id { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataEmissaoNotaFiscal { get; set; }
        public decimal ValorTotalProdutos { get; set; }
        public decimal ValorTotalNotaFiscal { get; set; }
        public Pedido Pedido { get; set; }

        decimal ValorTotal()
        {
            return ValorTotalProdutos;
        }
    }
}
