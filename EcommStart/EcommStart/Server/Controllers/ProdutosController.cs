using EcommStart.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommStart.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost("incluir")]
        public IActionResult Adicionar(Produto produto)
        {
            if (produto == null) return BadRequest("Produto não foi enviado por parâmetro");

            Produto? produtoAnterior = Banco.Produtos.OrderByDescending(e => e.Id).FirstOrDefault();
            if (produtoAnterior != null)
                produto.Id = produtoAnterior.Id + 1;
            else
                produto.Id = 1;
            Banco.Produtos.Add(produto);
            return Ok();
        }

        [HttpPut("alterar")]
        public IActionResult Alterar(Produto produto)
        {
            if (produto == null) return BadRequest("Produto não foi enviado por parâmetro");

            Produto? p = Banco.Produtos.Where(e => e.Id == produto.Id).FirstOrDefault();
            if (p == null) return BadRequest("Produto não existe mais na base, deve ter sido removido.");

            p.Nome = produto.Nome;
            p.Preco = produto.Preco;
            p.Quantidade = produto.Quantidade;
            p.Imagem = produto.Imagem;

            return Ok();
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir(int id)
        {
            Produto? p = Banco.Produtos.Where(e => e.Id == id).FirstOrDefault();
            if (p == null) return BadRequest("Produto não existe mais na base, deve ter sido removido.");
            Banco.Produtos.Remove(p);
            return Ok();
        }

        [HttpGet("listar")]
        public IActionResult Listar(string? nome)
        {
            List<Produto> retorno = Banco.Produtos.ToList();
            if (nome != null)
            {
                retorno = Banco.Produtos.Where(e => e.Nome.Contains(nome)).ToList();
            }
            return Ok(retorno);
        }

        [HttpGet("consultar")]
        public IActionResult Consultar(int id)
        {
            Produto? p = Banco.Produtos.Where(e => e.Id == id).FirstOrDefault();
            if (p == null) return BadRequest("Produto não existe mais na base, deve ter sido removido.");
            return Ok(p);
        }

    }
}
