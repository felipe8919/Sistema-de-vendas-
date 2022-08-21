namespace exemplo2.api.Models
{
    public class Estoque
    {
        public long Id { get; set; }
        public int Quantidade { get; set; }
        public string Localizacao { get; set; }
        public Produto Produto { get; set; }
    }
}
