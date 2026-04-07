using ApiFinanceiro.Models;
using ApiFinanceiro.Dtos;
using AutoMapper;

namespace ApiFinanceiro.Profiles
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile()
        {
            CreateMap<DespesaDto, Despesa>()
                .ForMember
                (
                    dest => dest.Situacao,
                    opt => opt.MapFrom(src => "pendente")
                );
            CreateMap<DespesaUpdateDto, Despesa>()
                .ForMember
                (
                    dest => dest.DataPagamento,
                    opt => opt.MapFrom(
                        src => src.DataPagamento.ToDateTime(TimeOnly.MinValue)
                     )

                );
        }

    }
}
