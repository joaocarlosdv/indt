using AutoMapper;
using Proposta.Application.Dtos;
using Proposta.Application.Enums;
using Proposta.Application.Interfaces;
using Proposta.Domain.Interfaces;

namespace Proposta.Application.UserCases
{
    public class CriarPropostaUseCase: ICriarPropostaUseCase
    {
        private readonly IPropostaRepository _repo;
        private readonly IMapper _mapper;

        public CriarPropostaUseCase(IPropostaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CriarPropostaResponse> ExecutarAsync(CriarPropostaRequest request)
        {
            request.Status = StatusPropostaEnum.EmAnalise;
            return _mapper.Map<CriarPropostaResponse>(await _repo.Inserir(_mapper.Map<Domain.Models.Proposta>(request)));
        }
    }
}
