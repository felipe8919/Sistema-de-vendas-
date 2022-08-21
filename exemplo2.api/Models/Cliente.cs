using System.ComponentModel.DataAnnotations;

namespace exemplo2.api.Models
{
    public class Cliente
    {
        [Key]
        public long Id { get; set; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo CPF obrigatório")]
        [MaxLength(11)]
        public string Cpf { get; set; }

        public Endereco Endereco { get; set; }

        public Email Email { get; set; }

        [Display(Name = "Tipo Pessoa")]
        [Required(ErrorMessage = "Campo Tipo Pessoa obrigatório")]
        public TipoPessoa TipoPessoa { get; set; }  


        public Cliente(long id, string nome, string cpf, Endereco endereco = null, Email email = null)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Email = email;
        }

        public void AtribuirNome(string nome)
        {
            Nome = nome;
        }

        public void AtribuirCpf(string cfp)
        {
            Cpf = cfp;
        }

    }
}
