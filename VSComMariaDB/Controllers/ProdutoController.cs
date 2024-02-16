using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet("ListaAsync")]
        public async Task<List<Produto>> GetListaAsync()
        {
            var _dbContext = new _DbContext();
            var vLista = await _dbContext.Produto.ToListAsync();

            return vLista;
        }


        [HttpGet("{id}")]
        public async Task<Produto> GetPessoa(int id)
        {
            var _dbContext = new _DbContext();
                      

            var vProduto = await _dbContext.Produto.FindAsync(id);

            
            return vProduto;
        }






        [HttpPost]
        public async Task<Produto> Inserir(Produto produto)
        {
            var _dbContext = new _DbContext();
            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();


            return produto;
        }





        [HttpPut]
        public async Task<Produto> Alterar(Produto produto)
        {
            var _dbContext = new _DbContext();

            _dbContext.Produto.Entry(produto).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return produto;
        }





        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            
            var _dbContext = new _DbContext();           
            var vProduto = await _dbContext.Produto.FindAsync(id);            
            _dbContext.Produto.Remove(vProduto);           
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
