using AutoMapper;
using Proposta.Application.Dtos;

namespace Proposta.Application.Mappings
{
    public class PropostaMapper : Profile
    {
        public PropostaMapper()
        {
            CreateMap<Domain.Models.Proposta, CriarPropostaRequest>().ReverseMap();
            CreateMap<Domain.Models.Proposta, CriarPropostaResponse>().ReverseMap();
            CreateMap<CriarPropostaRequest, CriarPropostaResponse>().ReverseMap();
            CreateMap<Domain.Models.Proposta, AlterarStatusResponse>().ReverseMap();
            CreateMap<Domain.Models.Proposta, PropostaResponse>().ReverseMap();
        }
    }
}
