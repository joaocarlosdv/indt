using AutoMapper;
using Proposta.Application.Dtos;
using Proposta.Application.Interfaces;
using Proposta.Domain.Interfaces;

namespace Proposta.Application.UserCases
{
    public class ConsultarStatusPropostaUseCase: IConsultarStatusPropostaUseCase
    {
        private readonly IPropostaRepository _repo;
        private readonly IMapper _mapper;

        public ConsultarStatusPropostaUseCase(IPropostaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PropostaResponse> ExecutarAsync(int id)
        {
            return _mapper.Map<PropostaResponse>(await _repo.ConsultarPorId(id));
        }
    }
}
