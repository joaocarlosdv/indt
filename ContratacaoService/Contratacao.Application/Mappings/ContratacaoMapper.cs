using AutoMapper;
using Contratacao.Application.Dtos;

namespace Contratacao.Application.Mappings
{
    public class ContratacaoMapper : Profile
    {
        public ContratacaoMapper()
        {
            CreateMap<Domain.Models.Contratacao, ContratacaoResponse>().ReverseMap();
            CreateMap<Domain.Models.Proposta, ContratarProposta>().ReverseMap();
            CreateMap<Domain.Models.Contratacao, ContratarProposta>().ReverseMap();
        }
    }
}
