namespace exemplo2.api.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int NumeroUsuario { get; set; }
        public Cargo Cargos { get; set; }
        public Setor Setores { get; set; }
    }
}
