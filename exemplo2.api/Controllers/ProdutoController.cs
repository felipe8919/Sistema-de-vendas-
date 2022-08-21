using exemplo2.api.Models;
using exemplo2.api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace exemplo2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private const string _stringConnection = "Server=LAPTOP-BLR4SJU9\\SQLEXPRESS01;Database=estudodb;Trusted_Connection=True;";

        // GET: api/<ProdutoController>
        [HttpGet]
        public IActionResult Get()
        {

            var produtoService = new ProdutoService();

            return Ok(produtoService.ObterProdutos());


            //var produtos = new List<Produto>();

            ////SqlConnection

            //var sqlConnection = new SqlConnection(_stringConnection);

            ////SqlCommand
            //var sqlCommand = new SqlCommand("select * from produto", sqlConnection);
            //sqlConnection.Open();

            ////SqlDataReader
            //var sqlDataReader = sqlCommand.ExecuteReader();


            //while (sqlDataReader.Read())
            //{
            //    var produto = new Produto(
            //        Convert.ToInt64(sqlDataReader["id"]),
            //        sqlDataReader["descricao"].ToString(),
            //        sqlDataReader["codigoInterno"].ToString(),
            //        sqlDataReader["codigoExterno"].ToString(),
            //        Convert.ToDecimal(sqlDataReader["valorUnitario"]));

            //    produtos.Add(produto);

            //}

            //sqlConnection.Close();
            //sqlConnection.Dispose();

            //return Ok(produtos);
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produtos = new List<Produto>();

            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand("select * from produto where id = @id", sqlConnection);
            sqlCommand.Parameters.Add("@id", SqlDbType.BigInt);
            sqlCommand.Parameters["@id"].Value = id;

            sqlConnection.Open();

            var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                var produto = new Produto(
                    Convert.ToInt64(sqlDataReader[0].ToString()),
                    sqlDataReader[1].ToString(),
                    sqlDataReader[2].ToString(),
                    sqlDataReader[3].ToString(),
                    Convert.ToDecimal(sqlDataReader[4].ToString()));

                produtos.Add(produto);


            }

            sqlConnection.Close();
            sqlConnection.Dispose();

            return Ok(produtos.FirstOrDefault());

        }

        [HttpGet("codigoExterno")]
        public IActionResult GetCodigo(string codigoExterno)
        {
            var produtoService = new ProdutoService();

            var produtos = produtoService.ObterProdutos();

            return Ok(produtos.FirstOrDefault(x => x.CodigoExterno == codigoExterno));
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand(@"INSERT INTO PRODUTO (DESCRICAO,CODIGOINTERNO,CODIGOEXTERNO,VALORUNITARIO,CLASSIFICACAOID)
                                            VALUES (@DESCRICAO,@CODIGOINTERNO,@CODIGOEXTERNO,@VALORUNITARIO,@CLASSIFICACAOID)", sqlConnection);
            sqlCommand.Parameters.Add("@DESCRICAO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CODIGOINTERNO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CODIGOEXTERNO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@VALORUNITARIO", SqlDbType.Decimal);
            sqlCommand.Parameters.Add("@CLASSIFICACAOID", SqlDbType.BigInt);

            sqlCommand.Parameters["@DESCRICAO"].Value = produto.Descricao;
            sqlCommand.Parameters["@CODIGOINTERNO"].Value = produto.CodigoInterno;
            sqlCommand.Parameters["@CODIGOEXTERNO"].Value = produto.CodigoExterno;
            sqlCommand.Parameters["@VALORUNITARIO"].Value = produto.ValorUnitarioVenda;
            sqlCommand.Parameters["@CLASSIFICACAOID"].Value = 4;


            sqlConnection.Open();

            var linhasAfetadas = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            sqlConnection.Dispose();

            if (linhasAfetadas > 0)
                return Ok("Inserido com sucesso !! ");

            return BadRequest("Erro !!");
        }

        // PUT api/<ProdutoController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Produto produto)
        {
            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand(@"UPDATE PRODUTO SET DESCRICAO = @DESCRICAO, CODIGOINTERNO = @CODIGOINTERNO,
            CODIGOEXTERNO = @CODIGOEXTERNO, VALORUNITARIO = @VALORUNITARIO WHERE ID = @ID", sqlConnection);
            sqlCommand.Parameters.Add("@ID", SqlDbType.BigInt);
            sqlCommand.Parameters.Add("@DESCRICAO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CODIGOINTERNO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CODIGOEXTERNO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@VALORUNITARIO", SqlDbType.Decimal);

            sqlCommand.Parameters["@ID"].Value = produto.Id;
            sqlCommand.Parameters["@DESCRICAO"].Value = produto.Descricao;
            sqlCommand.Parameters["@CODIGOINTERNO"].Value = produto.CodigoInterno;
            sqlCommand.Parameters["@CODIGOEXTERNO"].Value = produto.CodigoExterno;
            sqlCommand.Parameters["@VALORUNITARIO"].Value = produto.ValorUnitarioVenda;


            sqlConnection.Open();

            var linhasAfetadas = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            sqlConnection.Dispose();

            if (linhasAfetadas > 0)
                return Ok("Atualizado com sucesso !! ");

            return BadRequest("Erro: Não atualizado !!");

        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand(@"DELETE FROM PRODUTO WHERE ID = @ID", sqlConnection);
            sqlCommand.Parameters.Add("@ID", SqlDbType.BigInt);

            sqlCommand.Parameters["@ID"].Value = id;

            sqlConnection.Open();

            var linhasAfetadas = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            sqlConnection.Dispose();

            if(linhasAfetadas > 0)
                return Ok("Deletada com sucesso !");

            return BadRequest("Erro !");



        }
    }
}
