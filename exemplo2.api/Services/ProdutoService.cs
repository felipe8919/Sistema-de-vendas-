using exemplo2.api.Models;
using exemplo2.api.Repositories;

namespace exemplo2.api.Services
{
    public class ProdutoService
    {
        public IEnumerable<Produto> ObterProdutos()
        {
            var produtoRepository = new ProdutoRespository();

            return produtoRepository.ObterTodos(); 

            //var produtoPastilha = new Produto(1, "HG456465", "123132123", "PASTILHA FREIO",100M);
            //var produtoAmortecedor = new Produto(2, "AM587453", "58745852", "AMORTECEDOR", 200M);
            //var produtoMola = new Produto(3, "ML748958", "89536254", "MOLA", 120M);
            //var produtoCalco = new Produto(4, "C748958", "8953325", "CALCO", 450M);

            //return new List<Produto>
            //{
            //    produtoPastilha,
            //    produtoAmortecedor,
            //    produtoMola,
            //    produtoCalco
            //};
        }
    }
}
