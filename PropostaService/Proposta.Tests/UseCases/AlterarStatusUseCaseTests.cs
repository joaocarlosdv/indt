using AutoMapper;
using Moq;
using Proposta.Application.Dtos;
using Proposta.Application.Mappings;
using Proposta.Application.UserCases;
using Proposta.Domain.Interfaces;

namespace Proposta.Tests.UseCases
{
    [TestFixture]

    public class AlterarStatusUseCaseTests
    {
        private Mock<IPropostaRepository> _repoMock;
        private IMapper _mapper;
        private AlterarStatusUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IPropostaRepository>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<PropostaMapper>());
            _mapper = config.CreateMapper();

            _useCase = new AlterarStatusUseCase(_repoMock.Object, _mapper);
        }

        [Test]
        public async Task AlterarStatusPropostaComSucesso()
        {
            var propostaExistente = new Proposta.Domain.Models.Proposta
            {
                Id = 1,
                Cliente = "João",
                Valor = 100,
                Status = (int)Application.Enums.StatusPropostaEnum.EmAnalise
            };

            var request = new AlterarStatusRequest
            {
                Id = 1,
                NovoStatus = Application.Enums.StatusPropostaEnum.Aprovada
            };

            _repoMock.Setup(r => r.ConsultarPorId(request.Id))
                     .ReturnsAsync(propostaExistente);

            _repoMock.Setup(r => r.Alterar(It.IsAny<Proposta.Domain.Models.Proposta>()))
                     .ReturnsAsync((Proposta.Domain.Models.Proposta p) => p);

            var response = await _useCase.ExecutarAsync(request);

            Assert.That(response.Id, Is.EqualTo(propostaExistente.Id));
            Assert.That(response.Cliente, Is.EqualTo(propostaExistente.Cliente));
            Assert.That(response.Valor, Is.EqualTo(propostaExistente.Valor));
            Assert.That(response.Status, Is.EqualTo(Application.Enums.StatusPropostaEnum.Aprovada));

            _repoMock.Verify(r => r.ConsultarPorId(request.Id), Times.Once);
            _repoMock.Verify(r => r.Alterar(It.IsAny<Proposta.Domain.Models.Proposta>()), Times.Once);
        }
    }
}
