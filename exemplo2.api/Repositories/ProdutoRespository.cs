using exemplo2.api.Models;

namespace exemplo2.api.Repositories
{
    public class ProdutoRespository
    {
        public IEnumerable<Produto> ObterTodos()
        {
            return Enumerable.Empty<Produto>(); 
        }
    }
}
