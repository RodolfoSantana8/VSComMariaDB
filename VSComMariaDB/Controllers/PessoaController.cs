using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        /// <summary>
        /// Pegar a lista de todas as pessoas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Pessoa> GetLista()
        {
            var _dbContext = new _DbContext();
            var vLista = _dbContext.Pessoa.ToList();

            return vLista; 
        }

        /// <summary>
        /// Pegar os dados de uma pessoa específica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public  Pessoa GetPessoa(int id)
        {
            //Instanciar o banco de dados
            var _dbContext = new _DbContext();

            //Selecionar a Pessoa pelo id
            /*var vPessoa = _dbContext.Pessoa
                .Where(p => p.Id == id)
                .FirstOrDefault();*/

            var vPessoa = _dbContext.Pessoa.Find(id);

            //Retornar dos dados
            return vPessoa;
        }


        [HttpPost]
        public Pessoa Inserir(Pessoa pessoa)
        {
            var _dbContext = new _DbContext();
            _dbContext.Pessoa.Add(pessoa);
            _dbContext.SaveChanges();


            return pessoa;
        }

        [HttpPut]
        public Pessoa Alterar(Pessoa pessoa)
        {
            var _dbContext = new _DbContext();

            _dbContext.Pessoa.Entry(pessoa).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return pessoa;
        }


        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            //Instanciar o banco de dados
            var _dbContext = new _DbContext();
            //Localizar o registro a ser removido pelo id
            var vPessoa = _dbContext.Pessoa.Find(id);
            //remove o registro encontrado
            _dbContext.Pessoa.Remove(vPessoa);
            //Salvar alterações
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
