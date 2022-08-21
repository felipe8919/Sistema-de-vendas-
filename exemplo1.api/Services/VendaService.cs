using exemplo1.api.Models;

namespace exemplo1.api.Services
{
    public class VendaService
    {
        public Venda ObterVenda()
        {
            var cliente = new Cliente();
            cliente.Id = 1;
            cliente.Nome = "Felipe Rodrigues";

            var itemProduto1 = new ItemProduto();
            itemProduto1.Id = 1;
            itemProduto1.Descricao = "PASTILHA FREIO";
            itemProduto1.Quantidade = 10;
            itemProduto1.Valor = 110.50M;


            var itemProduto2 = new ItemProduto();
            itemProduto2.Id = 2;
            itemProduto2.Descricao = "AMORTECEDOR";
            itemProduto2.Quantidade = 1;
            itemProduto2.Valor = 150.50M;


            var itemProduto3 = new ItemProduto();
            itemProduto3.Id = 3;
            itemProduto3.Descricao = "MOLA";
            itemProduto3.Quantidade = 2;
            itemProduto3.Valor = 65.70M;

            var itemProduto4 = new ItemProduto();
            itemProduto4.Descricao = "CALÇO MOTOR";
            itemProduto4.Quantidade = 5;
            itemProduto4.Valor = 160.72M;
            itemProduto4.Id = 4;

            var itensProduto = new List<ItemProduto>();
            itensProduto.Add(itemProduto1);
            itensProduto.Add(itemProduto2);
            itensProduto.Add(itemProduto3);
            itensProduto.Add(itemProduto4);

            var venda = new Venda();
            venda.Id = 1;
            venda.Cliente = cliente;
            venda.ItensProdutos = itensProduto;

            return venda;
        }
    }
}
