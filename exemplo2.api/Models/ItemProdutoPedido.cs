namespace exemplo2.api.Models
{
    public class ItemProdutoPedido
    {
        public long Id { get; set; }
        public int? QuantidadeAutorizado { get; set; }
        public int? QuantidadeEntregue { get; set; }
        public Usuario Usuarios { get; set; }
        public ItemProduto ItensProdutos { get; set; }
        public IEnumerable<StatusEntrega> StatusEntrega { get; set; }
        public IEnumerable<StatusAutorizacao> StatusAutorizacao { get; set; }

    }
}
