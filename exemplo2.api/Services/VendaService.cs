using exemplo2.api.Models;

namespace exemplo2.api.Services
{
    public class VendaService
    {
        public IEnumerable<Venda> ObterVendas()
        {
            var cliente = new Cliente(1,"Felipe Rodrigues","14421549770");
          

            var produtoPastilha = new Produto(1,"HG456465", "123132123", "PASTILHA FREIO", 100M);

            var itemProdutoPatilha = new ItemProdutoVenda
            {
                Id = 1
            };
            itemProdutoPatilha.AdicionarProdudo(produtoPastilha);
            itemProdutoPatilha.AtribuirQuantidade(10);
            itemProdutoPatilha.AtribuirValorUnitario(100M);


            var produtoAmortecedor = new Produto(1, "AM587453", "58745852", "AMORTECEDOR", 200M);

            var itemProdutoAmortecedor = new ItemProdutoVenda
            {
                Id = 2
            };
            itemProdutoAmortecedor.AdicionarProdudo(produtoAmortecedor);
            itemProdutoAmortecedor.AtribuirQuantidade(5);
            itemProdutoAmortecedor.AtribuirValorUnitario(200M);


            var produtoMola = new Produto(1, "ML748958", "89536254", "MOLA", 120M);

            var itemProdutoMola = new ItemProdutoVenda
            {
                Id = 3
            };
            itemProdutoMola.AdicionarProdudo(produtoMola);
            itemProdutoMola.AtribuirQuantidade(2);
            itemProdutoMola.AtribuirValorUnitario(120M);


            var produtoCalco = new Produto(1, "C748958", "8953325", "CALCO", 450M);
           
            var itemProdutoCalco = new ItemProdutoVenda
            {
                Id = 4
            };
            itemProdutoCalco.AdicionarProdudo(produtoCalco);
            itemProdutoCalco.AtribuirQuantidade(5);
            itemProdutoCalco.AtribuirValorUnitario(450M) ;


            var itensProduto = new List<ItemProdutoVenda>
            {
                itemProdutoPatilha,
                itemProdutoAmortecedor,
                itemProdutoMola,
                itemProdutoCalco
            };

            var venda1 = new Venda();
            venda1.Id = 1;
            venda1.Cliente = cliente;
            venda1.ItensProdutos = itensProduto;

            var venda2 = new Venda();
            venda2.Id = 1;
            venda2.Cliente = cliente;
            venda2.ItensProdutos = itensProduto;

            var venda3 = new Venda();
            venda3.Id = 1;
            venda3.Cliente = cliente;
            venda3.ItensProdutos = itensProduto;

            var venda4 = new Venda();
            venda4.Id = 1;
            venda4.Cliente = cliente;
            venda4.ItensProdutos = itensProduto;

            var vendas = new List<Venda>(); 
            vendas.Add(venda1);
            vendas.Add(venda2);
            vendas.Add(venda3);
            vendas.Add(venda4);

            return vendas;
        }
    }
}
