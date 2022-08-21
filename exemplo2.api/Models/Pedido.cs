namespace exemplo2.api.Models
{
    public class Pedido
    {
        public long Id { get; set; }
        public int? OrdemDeCompra { get; set; }
        public DateTime DataHora { get; set; }
        public string Observacao { get; set; }
        public ItemProdutoPedido ItensProdutosPedidos { get; set; }
    }
}
