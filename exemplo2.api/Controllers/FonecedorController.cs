using exemplo2.api.Models;
using exemplo2.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace exemplo2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FonecedorController : ControllerBase
    {

        private const string _stringConnection = "Server=LAPTOP-BLR4SJU9\\SQLEXPRESS01;Database=estudodb;Trusted_Connection=True;";

        // GET: FonecedorController
        [HttpGet]
        public IActionResult Get()
        {
            var fornecedorService = new FornecedorService();

            return Ok(fornecedorService.ObterFornecedores);

        }

        // GET: FonecedorController/Details/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var fornecedores = new List<Fornecedor>();

            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand("SELECT * FROM FORNECEDOR WHERE ID = @ID", sqlConnection);
            sqlCommand.Parameters.Add("@ID", SqlDbType.BigInt);
            sqlCommand.Parameters["@ID"].Value = id;

            sqlConnection.Open();

            var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                var fornecedor = new Fornecedor(
                    Convert.ToInt64(sqlDataReader[0].ToString()),
                    sqlDataReader[1].ToString(),
                    sqlDataReader[2].ToString());



                fornecedores.Add(fornecedor);
            }

            sqlConnection.Close();
            sqlConnection.Dispose();

            return Ok(fornecedores.FirstOrDefault());
        }


        // GET FonecedorController
        [HttpGet("razaoSocial")]
        public IActionResult GetRazaoSocial(string razaoSocial)
        {
            var fornecedorService = new FornecedorService();

            var fornecedores = fornecedorService.ObterFornecedores();

            return Ok(fornecedores.FirstOrDefault(x => x.RazaoSocial == razaoSocial));
        }


        // GET FonecedorController
        [HttpGet("cnpjCpf")]
        public IActionResult GetCnpjCpf(string cnpjCpf)
        {
            var fornecedorService = new FornecedorService();

            var fornecedores = fornecedorService.ObterFornecedores();

            return Ok(fornecedores.FirstOrDefault(x => x.CnpjCpf == cnpjCpf));

        }


        // POST: FonecedorController/Edit/5
        [HttpPost]
        
        public IActionResult Post([FromBody] Fornecedor fornecedor)
        {
            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand(@"INSERT INTO FORNECEDOR (RAZAOSOCIAL,CNPJCPF,EMAIL,LOGRADOURO,NUMERO,BAIRRO, CIDADE,
            UF,CEP,TIPOPESSOA) VALUES (@RAZAOSOCIAL,@CNPJCPF,@EMAIL,@LOGRADOURO,@NUMERO,@BAIRRO,@CIDADE,@UF,@CEP,@TIPOPESSOA)", sqlConnection);

            sqlCommand.Parameters.Add("@RAZAOSOCIAL", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CNPJCPF", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@LOGRADOURO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@NUMERO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@BAIRRO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CIDADE", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@UF", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CEP", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@TIPOPESSOA", SqlDbType.Int);

            sqlCommand.Parameters["@RAZAOSOCIAL"].Value = fornecedor.RazaoSocial;
            sqlCommand.Parameters["@CNPJCPF"].Value = fornecedor.CnpjCpf;
            sqlCommand.Parameters["@EMAIL"].Value = fornecedor.Email.Descricao;
            sqlCommand.Parameters["@LOGRADOURO"].Value = fornecedor.Endereco.Logradouro;
            sqlCommand.Parameters["@NUMERO"].Value = fornecedor.Endereco.Numero;
            sqlCommand.Parameters["@BAIRRO"].Value = fornecedor.Endereco.Bairro;
            sqlCommand.Parameters["@CIDADE"].Value = fornecedor.Endereco.Cidade;
            sqlCommand.Parameters["@UF"].Value = fornecedor.Endereco.Uf;
            sqlCommand.Parameters["@CEP"].Value = fornecedor.Endereco.Cep;
            sqlCommand.Parameters["@TIPOPESSOA"].Value = fornecedor.TipoPessoa;

            sqlConnection.Open();

            var linhasAfetadas = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            sqlConnection.Dispose();

            if (linhasAfetadas > 0)
                return Ok("Inserido com sucesso !!");

            return BadRequest("Erro !!");

        }

        //PUT api/<ClienteController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Fornecedor fornecedor)
        {
            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand(@"UPDATE FORNECEDOR SET RAZAOSOCIAL = @RAZAOSOCIAL, CNPJCPF = @CNPJCPF, EMAIL = @EMAIL
             LOGRADOURO = @LOGRADOURO, NUMERO = @NUMERO, BAIRRO = @BAIRRO, CIDADE = @CIDADE, UF = @UF, CEP = @CEP, TIPOPESSPA = TIPOPESSOA
             WHERE ID = @ID", sqlConnection);
            sqlCommand.Parameters.Add("@ID", SqlDbType.BigInt);
            sqlCommand.Parameters.Add("@RAZAOSOCIAL", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CNPJCPF", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@LOGRADOURO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@NUMERO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@BAIRRO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CIDADE", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@UF", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CEP", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@TIPOPESSPA", SqlDbType.Int);

            sqlConnection.Open();

            var linhasAfetadas = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            sqlConnection.Dispose();

            if (linhasAfetadas > 0)
                return Ok("Atualizado com sucesso !!");
            return BadRequest("Erro: Não atualizado !!");

        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand(@"DELETE FROM FORNECEDOR WHERE ID = @ID", sqlConnection);

            sqlCommand.Parameters.Add("@ID", SqlDbType.BigInt);
            sqlCommand.Parameters["@ID"].Value = id;

            sqlConnection.Open();

            var linhasAfetadas = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            sqlConnection.Dispose();

            if (linhasAfetadas > 0)
                return Ok("Deletada com sucesso !");
            return BadRequest("Erro: Não deletado !");
        }
    }
}
