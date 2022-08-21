using exemplo2.api.Models;

namespace exemplo2.api.Services
{
    public class FornecedorService
    {
        public  IEnumerable<Fornecedor> ObterFornecedores()
        {
            var fornecedor1 = new Fornecedor(1, "Real Motor Peças", "1442154970");
            var fornecedor2 = new Fornecedor(2, "Embrepar Distribuidora", "1442154971");
            var fornecedor3 = new Fornecedor(3, "Suporte Distribuidora", "1442154972");
            var fornecedor4 = new Fornecedor(4, "Sama Distribuidora", "1442154973");
            var fornecedor5 = new Fornecedor(5, "Pellegrino Distribuidora", "1442154974");

            return new List<Fornecedor>
            {
                fornecedor1,
                fornecedor2,
                fornecedor3,
                fornecedor4,
                fornecedor5
            };

        }
    }
}
