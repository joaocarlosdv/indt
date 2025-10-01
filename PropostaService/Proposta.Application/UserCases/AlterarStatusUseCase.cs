using AutoMapper;
using Proposta.Application.Dtos;
using Proposta.Application.Interfaces;
using Proposta.Domain.Interfaces;

namespace Proposta.Application.UserCases
{
    public class AlterarStatusUseCase : IAlterarStatusUseCase
    {
        private readonly IPropostaRepository _repo;
        private readonly IMapper _mapper;

        public AlterarStatusUseCase(IPropostaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AlterarStatusResponse> ExecutarAsync(AlterarStatusRequest request)
        {
            var proposta = await _repo.ConsultarPorId(request.Id);
            proposta.Status = (int) request.NovoStatus;
            
            return _mapper.Map<AlterarStatusResponse>(await _repo.Alterar(proposta));
        }
    }
}
