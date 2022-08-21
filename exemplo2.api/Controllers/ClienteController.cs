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
    public class ClienteController : ControllerBase
    {
        private const string _stringConnection = "Server=LAPTOP-BLR4SJU9\\SQLEXPRESS01;Database=estudodb;Trusted_Connection=True;";

        // GET: ClienteController
        [HttpGet]
        public IActionResult Get()
        {
            var clientes = new List<Cliente>();

            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand("select * from cliente", sqlConnection);

            sqlConnection.Open();

            var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                var cliente = new Cliente
                (
                    Convert.ToInt64(sqlDataReader["Id"].ToString()),
                    sqlDataReader["Nome"].ToString(),
                    sqlDataReader["Cpf"].ToString(),
                    new Endereco
                    {
                        Logradouro = sqlDataReader["Logradouro"].ToString(),
                        Cidade = sqlDataReader["Cidade"].ToString()
                    },
                    new Email
                    {
                        Descricao = sqlDataReader["Email"].ToString()
                    }
                );

                clientes.Add(cliente);
            }

            sqlConnection.Close();
            sqlConnection.Dispose();

            return Ok(clientes);

        }

        // GET: ClienteController/Details/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var clientes = new List<Cliente>();


            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand("select * from cliente where id = @id", sqlConnection);
            sqlCommand.Parameters.Add("@id", SqlDbType.BigInt);
            sqlCommand.Parameters["@id"].Value = id;

            sqlConnection.Open();

            var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                var cliente = new Cliente
                (
                    Convert.ToInt64(sqlDataReader["Id"].ToString()),
                    sqlDataReader["Nome"].ToString(),
                    sqlDataReader["Cpf"].ToString(),

                    new Endereco
                    {
                        Logradouro = sqlDataReader["Logradouro"].ToString(),
                        Cidade = sqlDataReader["Cidade"].ToString()
                    },
                    new Email
                    {
                        Descricao = sqlDataReader["Email"].ToString()
                    }
                ); clientes.Add(cliente);

            }

            sqlConnection.Close();
            sqlConnection.Dispose();

            return Ok(clientes.FirstOrDefault());

        }

        // GET: ClienteController
        [HttpGet("nome")]
        public IActionResult GetNome(string nome)
        {
            var clienteService = new ClienteService();

            var clientes = clienteService.ObterClientes();

            return Ok(clientes.FirstOrDefault(x => x.Nome == nome));
        }

        //POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand(@"INSERT INTO CLIENTE (NOME,CPF,EMAIL,LOGRADOURO,NUMERO,BAIRRO,CIDADE,UF,CEP,TIPOPESSOA) 
                                            VALUES (@NOME,@CPF,@EMAIL,@LOGRADOURO,@NUMERO,@BAIRRO,@CIDADE,@UF,@CEP,@TIPOPESSOA)", sqlConnection);

            sqlCommand.Parameters.Add("@NOME", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CPF", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@LOGRADOURO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@NUMERO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@BAIRRO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CIDADE", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@UF", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CEP", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@TIPOPESSOA", SqlDbType.Int);

            sqlCommand.Parameters["@NOME"].Value = cliente.Nome;
            sqlCommand.Parameters["@CPF"].Value = cliente.Cpf;
            sqlCommand.Parameters["@EMAIL"].Value = cliente.Email.Descricao;
            sqlCommand.Parameters["@LOGRADOURO"].Value = cliente.Endereco.Logradouro;
            sqlCommand.Parameters["@NUMERO"].Value = cliente.Endereco.Numero;
            sqlCommand.Parameters["@BAIRRO"].Value = cliente.Endereco.Bairro;
            sqlCommand.Parameters["@CIDADE"].Value = cliente.Endereco.Cidade;
            sqlCommand.Parameters["@UF"].Value = cliente.Endereco.Uf;
            sqlCommand.Parameters["@CEP"].Value = cliente.Endereco.Cep;
            sqlCommand.Parameters["@TIPOPESSOA"].Value = cliente.TipoPessoa;


            sqlConnection.Open();

            var linhaAfetadas = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            sqlConnection.Dispose();

            if (linhaAfetadas > 0)
                return Ok("Inserido com sucesso !! ");

            return BadRequest("Erro !!");

        }

        //PUT api/<ClienteController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand(@"UPDATE CLIENTE SET NOME = @NOME, CPF = @CPF, EMAIL = @EMAIL, LOGRADOURO = @LOGRADOURO,
            NUMERO = @NUMERO, BAIRRO = @BAIRRO, CIDADE = @CIDADE,UF = @UF, CEP = @CEP, TIPOPESSOA = @TIPOPESSOA WHERE ID = @ID", sqlConnection);

            sqlCommand.Parameters.Add("@ID", SqlDbType.BigInt);
            sqlCommand.Parameters.Add("@NOME", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CPF", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@LOGRADOURO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@NUMERO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@BAIRRO", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CIDADE", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@UF", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@CEP", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@TIPOPESSOA", SqlDbType.Int);

            sqlCommand.Parameters["@ID"].Value = cliente.Id;
            sqlCommand.Parameters["@NOME"].Value = cliente.Nome;
            sqlCommand.Parameters["@CPF"].Value = cliente.Cpf;
            sqlCommand.Parameters["@EMAIL"].Value = cliente.Email.Descricao;
            sqlCommand.Parameters["@LOGRADOURO"].Value = cliente.Endereco.Logradouro;
            sqlCommand.Parameters["@NUMERO"].Value = cliente.Endereco.Numero;
            sqlCommand.Parameters["@BAIRRO"].Value = cliente.Endereco.Bairro;
            sqlCommand.Parameters["@CIDADE"].Value = cliente.Endereco.Cidade;
            sqlCommand.Parameters["@UF"].Value = cliente.Endereco.Uf;
            sqlCommand.Parameters["@CEP"].Value = cliente.Endereco.Cep;
            sqlCommand.Parameters["@TIPOPESSOA"].Value = cliente.TipoPessoa;

            sqlConnection.Open();

            var linhasAfetadas = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            sqlConnection.Dispose();

            if (linhasAfetadas > 0)
                return Ok("Atualizado com sucesso !!");
            return BadRequest("Erro: Não atualizado !!");

        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sqlConnection = new SqlConnection(_stringConnection);

            var sqlCommand = new SqlCommand(@"DELETE FROM CLIENTE WHERE ID = @ID", sqlConnection);

            sqlCommand.Parameters.Add("@ID", SqlDbType.BigInt);
            sqlCommand.Parameters["@ID"].Value = id;

            sqlConnection.Open();

            var linhasAfetadas = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            sqlConnection.Dispose();

            if (linhasAfetadas > 0)
                return Ok("Deletada com sucesso !");

            return BadRequest("Erro: Não deletado ! ");


        }

    }
}
