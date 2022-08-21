using exemplo2.api.Models;

namespace exemplo2.api.Services
{

    public class ClienteService
    {
        public IEnumerable<Cliente> ObterClientes()
        {
            var cliente1 = new Cliente(1, "Felipe Rodrigues", "14421549770");
            var cliente2 = new Cliente(2, "Thays Tacila", "14421549771");
            var cliente3 = new Cliente(3, "Pedro Henrique", "14421549772");

            return new List<Cliente>
            {
                cliente1,
                cliente2,
                cliente3
            };
        }
    }
}
