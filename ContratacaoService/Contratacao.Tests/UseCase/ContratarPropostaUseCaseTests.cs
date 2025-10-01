using AutoMapper;
using Contratacao.Application.Dtos;
using Contratacao.Application.UserCases;
using Contratacao.Domain.Interfaces;
using Contratacao.Domain.Models;
using Moq;

namespace Contratacao.Tests.UseCase
{
    [TestFixture]
    public class ContratarPropostaUseCaseTests
    {
        private Mock<IContratacaoRepository> _repoMock;
        private Mock<IPropostaServiceClient> _propostaClientMock;
        private IMapper _mapper;
        private ContratarPropostaUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IContratacaoRepository>();
            _propostaClientMock = new Mock<IPropostaServiceClient>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContratarProposta, Domain.Models.Contratacao>();
                cfg.CreateMap<Contratacao.Domain.Models.Contratacao, ContratacaoResponse>();
            });
            _mapper = config.CreateMapper();

            _useCase = new ContratarPropostaUseCase(_repoMock.Object, _propostaClientMock.Object, _mapper);
        }

        [Test]
        public void ExcecaoSePropostaNaoEncontrada()
        {
            var request = new ContratacaoRequest { PropostaId = 1 };
            _propostaClientMock.Setup(c => c.ConsultarStatusProposta(1))!.ReturnsAsync((Proposta)null);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await _useCase.ExecutarAsync(request));
        }

        [Test]
        public void ExcecaoSePropostaNaoAprovada()
        {
            var request = new ContratacaoRequest { PropostaId = 123 };
            _propostaClientMock.Setup(c => c.ConsultarStatusProposta(123))
                               .ReturnsAsync(new Proposta { Id = 1, Status = 2 });

            Assert.ThrowsAsync<InvalidOperationException>(async () => await _useCase.ExecutarAsync(request));
        }

        [Test]
        public async Task ContratarSePropostaAprovada()
        {
            var request = new ContratacaoRequest { PropostaId = 123 };
            _propostaClientMock.Setup(c => c.ConsultarStatusProposta(123))
                               .ReturnsAsync(new Proposta { Id = 1, Status = 1 });

            var contratacao = new Domain.Models.Contratacao { Id = 1, PropostaId = 1 };
            _repoMock.Setup(r => r.Inserir(It.IsAny<Contratacao.Domain.Models.Contratacao>()))
                     .ReturnsAsync(contratacao);

            var response = await _useCase.ExecutarAsync(request);

            Assert.That(response.PropostaId, Is.EqualTo(1));
            _repoMock.Verify(r => r.Inserir(It.IsAny<Domain.Models.Contratacao>()), Times.Once);
        }
    }
}
