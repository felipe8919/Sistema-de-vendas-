namespace exemplo2.api.Models
{
    public class ItemProduto
    {
      
        public long Id { get; set; }
        public int Quantidade { get; protected set; }
        public decimal ValorUnitario { get; set; }
        public Produto Produto { get; protected set; }

        public void AtribuirQuantidade(int quantidade)
        {
            this.Quantidade = quantidade;
        }

        public void AdicionarProdudo(Produto produto)
        {
            this.Produto = produto;
        }

        public void AtribuirValorUnitario(decimal valorUnitario)
        {
            this.ValorUnitario = valorUnitario;
        }
    }
}
