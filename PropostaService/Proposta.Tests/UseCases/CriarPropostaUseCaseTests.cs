using AutoMapper;
using Moq;
using Proposta.Application.Dtos;
using Proposta.Application.Mappings;
using Proposta.Application.UserCases;
using Proposta.Domain.Interfaces;

namespace Proposta.Tests.UseCases
{
    [TestFixture]
    public class CriarPropostaUseCaseTests
    {
        private Mock<IPropostaRepository> _repoMock;
        private IMapper _mapper;
        private CriarPropostaUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IPropostaRepository>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<PropostaMapper>());
            _mapper = config.CreateMapper();

            _useCase = new CriarPropostaUseCase(_repoMock.Object, _mapper);
        }

        [Test]
        public async Task CriarPropostaComSucesso()
        {
            var request = new CriarPropostaRequest
            {
                Id = 1,
                Cliente = "João",
                Valor = 100,
                Status = Application.Enums.StatusPropostaEnum.EmAnalise
            };

            _repoMock.Setup(r => r.Inserir(It.IsAny<Proposta.Domain.Models.Proposta>()))
                 .ReturnsAsync((Proposta.Domain.Models.Proposta p) => p);

            var response = await _useCase.ExecutarAsync(request);

            Assert.That(response.Cliente, Is.EqualTo("João"));
            Assert.That(response.Valor, Is.EqualTo(100));
            Assert.That(response.Status, Is.EqualTo(Application.Enums.StatusPropostaEnum.EmAnalise));

            _repoMock.Verify(r => r.Inserir(It.IsAny<Proposta.Domain.Models.Proposta>()), Times.Once);
        }
    }
}
