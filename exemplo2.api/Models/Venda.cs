namespace exemplo2.api.Models
{
    public class Venda
    {
        public long Id { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<ItemProdutoVenda> ItensProdutos { get; set; }
        public IEnumerable<TipoFormaPagamento> TiposFormasPagamentos { get; set; }
       
        public decimal ValorTotal => ItensProdutos.Sum(x => x.Quantidade * x.ValorUnitario);

        public int TotalDeProdutos => ItensProdutos.Count();
    }
}
