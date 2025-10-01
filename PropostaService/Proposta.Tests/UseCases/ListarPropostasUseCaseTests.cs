using AutoMapper;
using Moq;
using Proposta.Application.Mappings;
using Proposta.Application.UserCases;
using Proposta.Domain.Interfaces;

namespace Proposta.Tests.UseCases
{
    [TestFixture]

    public class ListarPropostasUseCaseTests
    {
        private Mock<IPropostaRepository> _repoMock;
        private IMapper _mapper;
        private ListarPropostasUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IPropostaRepository>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<PropostaMapper>());
            _mapper = config.CreateMapper();

            _useCase = new ListarPropostasUseCase(_repoMock.Object, _mapper);
        }

        [Test]
        public async Task ListarPropostasRetornaListaCorretamente()
        {
            var listaPropostas = new List<Proposta.Domain.Models.Proposta>
        {
            new Proposta.Domain.Models.Proposta { Id = 1, Cliente = "João", Valor = 100, Status = (int)Application.Enums.StatusPropostaEnum.EmAnalise },
            new Proposta.Domain.Models.Proposta { Id = 2, Cliente = "Maria", Valor = 200, Status = (int)Application.Enums.StatusPropostaEnum.Aprovada }
        };

            _repoMock.Setup(r => r.Listar())
                     .ReturnsAsync(listaPropostas);

            var response = await _useCase.ExecutarAsync();

            Assert.That(response.Count, Is.EqualTo(2));
            Assert.That(response[0].Cliente, Is.EqualTo("João"));
            Assert.That(response[1].Cliente, Is.EqualTo("Maria"));
            Assert.That(response[0].Valor, Is.EqualTo(100));
            Assert.That(response[1].Valor, Is.EqualTo(200));

            _repoMock.Verify(r => r.Listar(), Times.Once);
        }

        [Test]
        public async Task ListarPropostasRetornaListaVaziaQuandoNaoHaPropostas()
        {
            _repoMock.Setup(r => r.Listar())
                     .ReturnsAsync(new List<Proposta.Domain.Models.Proposta>());

            var response = await _useCase.ExecutarAsync();

            Assert.That(response, Is.Empty);
            _repoMock.Verify(r => r.Listar(), Times.Once);
        }
    }
}
