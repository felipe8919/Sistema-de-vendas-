namespace exemplo2.api.Models
{
    public class Fornecedor
    {
        public long Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CnpjCpf { get; set; }
        public Endereco Endereco { get; set; }
        public Email Email { get; set; }
        //public PoliticaComercial PoliticaComecial { get; set; }
        public TipoPessoa TipoPessoa { get; set; }

        public Fornecedor(long id, string razaoSocial, string cnpjCpf,Endereco endereco = null, Email email = null)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            CnpjCpf = cnpjCpf;
            Endereco = endereco;    
            Email = email;
            //PoliticaComecial = politicaComercial;

        }

        public void AtribuirRazaoSocial(string razaoSocial)
        {
            RazaoSocial = razaoSocial;
        }

        public void AtribuirCnpjCpf(string cnpjCpf)
        {
            CnpjCpf = cnpjCpf;  
        }



    }
}
