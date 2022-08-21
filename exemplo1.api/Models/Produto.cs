namespace exemplo1.api.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string CodigoInterno { get; set; }
        public string CodigoExterno { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
