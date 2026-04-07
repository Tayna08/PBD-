using ApiFinanceiro.DataContexts;
using ApiFinanceiro.Dtos;
using ApiFinanceiro.Exceptions;
using ApiFinanceiro.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ApiFinanceiro.Services
{
    public class DespesaService
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public DespesaService(AppDbContext context, IMapper mapper) {

            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Despesa>> FindAll()
        {
            try
            {
                return await _context.Despesas.ToListAsync();


            } catch (Exception)
            {
                throw;
            }
        }
        public async Task<Despesa> Create(DespesaDto data)
        {
            try
            {
                var despesa = _mapper.Map<Despesa>(data);
                await _context.Despesas.AddAsync(despesa);
                await _context.SaveChangesAsync();

                return despesa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Despesa> FindById(int id)
        {
            try
            {
                var despesa = await _context.Despesas.FirstOrDefaultAsync(x => x.Id == id);
                if (despesa is null)
                {
                    throw new ErrorServiceException($"Despesa ${id}não encontrada",
                        c => c.NotFound(new {message = $"Despesa ${id}não encontrada" }));
                }

                return despesa;

            }
            catch (Exception )
            {
                throw;

            }

        }

        [HttpPut("{id}")]

        public async Task<Despesa> Update(int id, DespesaUpdateDto despesaDto)
        {
            try
            {
                var despesa = await FindById(id);
                
                var dataVencimento = new DateTime(despesaDto.DataVencimento.Year, despesaDto.DataVencimento.Month, despesaDto.DataVencimento.Day);
                var dataPagamento = new DateTime(despesaDto.DataPagamento.Year, despesaDto.DataPagamento.Month, despesaDto.DataPagamento.Day);

                ////TODO: adicionar data de emissão
                //if (dataPagamento < dataVencimento)
                //{
                //    throw new ErrorServiceException("Somente é possivel realizar o pagamento no dia do vencimento",
                //        c => c.Conflict(new { message = $"Somente é possivel realizar o pagamento no dia do vencimento" }));
                //}

                _mapper.Map<DespesaUpdateDto, Despesa>(despesaDto, despesa);

                _context.Despesas.Update(despesa);
                await _context.SaveChangesAsync();

                return despesa;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Despesa> Remove(int id)
        {
            try
            {
                var despesa = await FindById(id);
               
                _context.Despesas.Remove(despesa);
                await _context.SaveChangesAsync();

                return despesa;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

   
