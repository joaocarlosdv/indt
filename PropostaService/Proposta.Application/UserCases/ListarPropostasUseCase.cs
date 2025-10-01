using AutoMapper;
using Proposta.Application.Dtos;
using Proposta.Application.Interfaces;
using Proposta.Domain.Interfaces;

namespace Proposta.Application.UserCases
{
    public class ListarPropostasUseCase: IListarPropostasUseCase
    {
        private readonly IPropostaRepository _repo;
        private readonly IMapper _mapper;

        public ListarPropostasUseCase(IPropostaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PropostaResponse>> ExecutarAsync()
        {
            return _mapper.Map<List<PropostaResponse>>(await _repo.Listar());
        }
    }
}
