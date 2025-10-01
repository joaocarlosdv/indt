using AutoMapper;
using Contratacao.Application.Dtos;
using Contratacao.Application.Interfaces;
using Contratacao.Domain.Interfaces;
using Contratacao.Infrastructure.Services;

namespace Contratacao.Application.UserCases
{
    public class ContratarPropostaUseCase : IContratarPropostaUseCase
    {
        private readonly IContratacaoRepository _repo;
        private readonly IPropostaServiceClient _propostaClient;
        private readonly IMapper _mapper;

        public ContratarPropostaUseCase(IContratacaoRepository repo, IPropostaServiceClient propostaClient, IMapper mapper)
        {
            _repo = repo;
            _propostaClient = propostaClient;
            _mapper = mapper;
        }

        public async Task<ContratacaoResponse> ExecutarAsync(ContratacaoRequest request)
        {
            var proposta = await _propostaClient.ConsultarStatusProposta(request.PropostaId);
            if (proposta == null)
                throw new InvalidOperationException("Não foi localizada a proposta solicitada.");
            if (proposta.Status != 1)
                throw new InvalidOperationException("Somente propostas aprovadas podem ser contratadas.");

            var contratacao = new ContratarProposta
            {
                PropostaId = request.PropostaId,
                DataContratacao = DateTime.UtcNow
            };

            var resultado = await _repo.Inserir(_mapper.Map<Domain.Models.Contratacao>(contratacao));
            return _mapper.Map<ContratacaoResponse>(resultado);
        }
    }
}
