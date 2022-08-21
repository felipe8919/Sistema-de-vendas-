namespace exemplo1.api.Models
{
    public class Venda
    {
        public long Id { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<ItemProduto> ItensProdutos { get; set; }
        public decimal ValorTotal => ItensProdutos.Sum(x => x.Quantidade * x.Valor);

        public int TotalDeProdutos => ItensProdutos.Count();
    }

}
