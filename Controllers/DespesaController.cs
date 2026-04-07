using ApiFinanceiro.DataContexts;
using ApiFinanceiro.Dtos;
using ApiFinanceiro.Exceptions;
using ApiFinanceiro.Models;
using ApiFinanceiro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ApiFinanceiro.Controllers
{
    [Route("/despesas")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly DespesaService _service;
        public DespesaController(DespesaService service, AppDbContext context)
        {
            _context = context;
            _service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var despesas = await _service.FindAll();
                return Ok(despesas);
            }
            catch (Exception e)
            {
                return Problem(e.Message);

            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var despesa = await _service.FindById(id);
                return Ok(despesa);

            }
            catch(ErrorServiceException e)
            {
                return e.ToActionResult(this);
            }
            catch (Exception e)
            {
                return Problem(e.Message);

            }

        }
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] DespesaDto novaDespesa)
        {
            try
            {
                var despesa = await _service.Create(novaDespesa);
                return Created("", despesa);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DespesaUpdateDto despesaDto)
        {
            try
            {
                var despesa = await _service.Update(id, despesaDto);
                return Ok(despesa);

            }
            catch (ErrorServiceException e)
            {
                return e.ToActionResult(this);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }  

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                await _service.Remove(id);

                return NoContent();
            }catch(Exception e)
            {
                return Problem(e.Message);
            }

        }


    }


}

            


           



        //    private static List<Despesa> listaDespesas = new()
        //    {
        //        new Despesa {
        //            Descricao = "Internet",
        //            Valor = 150, Categoria = "Moradia",
        //            DataVencimento = new DateOnly(2026, 03, 15),
        //            Situacao = "Aberto"
        //        },
        //        new Despesa {
        //            Descricao = "Caerd",
        //            Valor = 45, Categoria = "Moradia",
        //            DataVencimento = new DateOnly(2026, 03, 10),
        //            Situacao = "Aberto"
        //        },
        //        new Despesa {
        //            Descricao = "Energisa",
        //            Valor = 245, Categoria = "Moradia",
        //            DataVencimento = new DateOnly(2026, 03, 09),
        //            Situacao = "Aberto"
        //        }
        //    };

        //    [HttpGet()]
        //    public ActionResult FindAll()
        //    {
        //        return Ok(listaDespesas);
        //    }

        //    [HttpPost()]
        //    public ActionResult Create([FromBody]DespesaDto novaDespesa)
        //    {
        //        var despesa = new Despesa
        //        {
        //            Descricao = novaDespesa.Descricao,
        //            Valor = novaDespesa.Valor,
        //            Categoria = novaDespesa.Categoria,
        //            DataVencimento = novaDespesa.DataVencimento,
        //            Situacao = "Pendente"
        //        };

        //        listaDespesas.Add(despesa);

        //        return Created("", despesa);
        //    }

        //    [HttpGet("{id}")]
        //    public ActionResult FindById(Guid id)
        //    {
        //        var despesa = listaDespesas.FirstOrDefault(d => d.Id == id);

        //        if (despesa is null)
        //        {
        //            return NotFound(new { mensagem = $"Despesa #{id} não encontrada" });
        //        }

        //        return Ok(despesa);
        //    }

        //    [HttpPut("{id}")]
        //    public ActionResult Update(Guid id, [FromBody] DespesaUpdateDto despesaDto)
        //    {
        //        var despesa = listaDespesas.FirstOrDefault(d => d.Id == id);

        //        if (despesa is null)
        //        {
        //            return NotFound(new { mensagem = $"Despesa #{id} não encontrada" });
        //        }

        //        var dataPagamento = new DateTime(despesaDto.DataPagamento.Year, despesaDto.DataPagamento.Month, despesaDto.DataPagamento.Day);

        //        despesa.Descricao = despesaDto.Descricao;
        //        despesa.Valor = despesaDto.Valor;
        //        despesa.DataVencimento = despesaDto.DataVencimento;
        //        despesa.Categoria = despesaDto.Categoria;
        //        despesa.Situacao = despesaDto.Situacao;
        //        despesa.DataPagamento = dataPagamento;

        //        return Ok(despesa);
        //    }

        //    [HttpDelete("{id}")]
        //    public ActionResult Remove(Guid id)
        //    {
        //        var despesa = listaDespesas.FirstOrDefault(d => d.Id == id);

        //        if (despesa is null)
        //        {
        //            return NotFound(new { mensagem = $"Despesa #{id} não encontrada" });
        //        }

        //        listaDespesas.Remove(despesa);

        //        return NoContent();
        //    }
        //}

