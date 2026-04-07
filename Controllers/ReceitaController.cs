using ApiFinanceiro.Dtos;
using ApiFinanceiro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinanceiro.Controllers
{
    [Route("/receitas")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private static List<Receita> listaReceitas = new()
        {
            new Receita
            {
                Descricao = "Salário",
                Valor = 3500,
                Categoria = "Trabalho",
                DataPrevisao = new DateOnly(2026, 03, 10),
                Situacao = "Recebido",
                Observacao = "Salário mensal"
            },
            new Receita
            {
                Descricao = "Freelance",
                Valor = 500,
                Categoria = "Trabalho",
                DataPrevisao = new DateOnly(2026, 03, 12),
                Situacao = "Pendente"
            }
        };

        [HttpGet()]
        public ActionResult FindAll()
        {
            return Ok(listaReceitas);
        }

        [HttpPost()]
        public ActionResult Create([FromBody] ReceitaDto novaReceita)
        {
            var receita = new Receita
            {
                Descricao = novaReceita.Descricao,
                Valor = novaReceita.Valor,
                Categoria = novaReceita.Categoria,
                DataPrevisao = novaReceita.DataPrevisao,
                Observacao = novaReceita.Observacao,
                Situacao = "Pendente"
            };

            listaReceitas.Add(receita);

            return Created("", receita);
        }

        [HttpGet("{id}")]
        public ActionResult FindById(Guid id)
        {
            var receita = listaReceitas.FirstOrDefault(r => r.Id == id);

            if (receita is null)
                return NotFound(new { mensagem = $"Receita #{id} não encontrada" });

            return Ok(receita);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] ReceitaUpdateDto receitaDto)
        {
            var receita = listaReceitas.FirstOrDefault(r => r.Id == id);

            if (receita is null)
                return NotFound(new { mensagem = $"Receita #{id} não encontrada" });

            receita.Descricao = receitaDto.Descricao;
            receita.Valor = receitaDto.Valor;
            receita.Categoria = receitaDto.Categoria;
            receita.DataPrevisao = receitaDto.DataPrevisao;
            receita.Observacao = receitaDto.Observacao;
            receita.Situacao = receitaDto.Situacao;
            receita.DataRecebimento = receitaDto.DataRecebimento;

            return Ok(receita);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var receita = listaReceitas.FirstOrDefault(r => r.Id == id);

            if (receita is null)
                return NotFound(new { mensagem = $"Receita #{id} não encontrada" });

            listaReceitas.Remove(receita);

            return NoContent();
        }
    }
}