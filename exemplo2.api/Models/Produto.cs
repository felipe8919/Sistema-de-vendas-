namespace exemplo2.api.Models
{
    public class Produto
    {

        public long Id { get; set; }
        public string Descricao { get; protected set; }
        public string CodigoInterno { get; protected set; }
        public string CodigoExterno { get; protected set; }
        public decimal ValorUnitarioVenda { get; protected set; }
        public Classificacao Classificacao { get; protected set; }


        public Produto(long id, string descricao, string codigoInterno, string codigoExterno, decimal valorUnitarioVenda, Classificacao classificacao = null)
        {
            Id = id;
            Descricao = descricao;
            CodigoInterno = codigoInterno;
            CodigoExterno = codigoExterno;
            ValorUnitarioVenda = valorUnitarioVenda;
            Classificacao = classificacao;
        }

        public void AtribuirDescricao( string descricao)
        {
            Descricao = descricao; 

        }

        public void AtribuirCodigoInterno(string codigoInterno)
        {
            CodigoExterno = codigoInterno;
        }

        public void AtrinbuirCodigoExterno(string codigoExterno)
        {
            CodigoExterno = codigoExterno;
        }

        public void AtribuirValorUnitarioVenda(decimal valorUnitarioVenda)
        {
            ValorUnitarioVenda = valorUnitarioVenda;
        }


    
    }
}
