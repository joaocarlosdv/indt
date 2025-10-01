using Microsoft.AspNetCore.Mvc;
using Proposta.Application.Dtos;
using Proposta.Application.Interfaces;
using System.Net;

namespace PropostaService.API.Controllers
{
    public class PropostaController : Controller
    {
        private readonly ICriarPropostaUseCase _CriarPropostaUseCase;
        private readonly IAlterarStatusUseCase _AlterarStatusUseCase;
        private readonly IListarPropostasUseCase _ListarPropostasUseCase;
        private readonly IConsultarStatusPropostaUseCase _ConsultarStatusPropostaUseCase;

        public PropostaController(ICriarPropostaUseCase criarPropostaUseCase,
                                  IAlterarStatusUseCase alterarStatusUseCase,
                                  IListarPropostasUseCase listarPropostasUseCase,
                                  IConsultarStatusPropostaUseCase consultarStatusPropostaUseCase)
        {
            _CriarPropostaUseCase = criarPropostaUseCase;
            _AlterarStatusUseCase = alterarStatusUseCase;
            _ListarPropostasUseCase = listarPropostasUseCase;
            _ConsultarStatusPropostaUseCase = consultarStatusPropostaUseCase;
        }

        [HttpPost("CriarProposta")]
        public async Task<ActionResult> CriarProposta(CriarPropostaRequest request)
        {
            try
            {
                return Ok(await _CriarPropostaUseCase.ExecutarAsync(request));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost("AlterarStatus")]
        public async Task<ActionResult> AlterarStatus(AlterarStatusRequest request)
        {
            try
            {
                return Ok(await _AlterarStatusUseCase.ExecutarAsync(request));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet("ListarPropostas")]
        public async Task<ActionResult> ListarPropostas()
        {
            try
            {
                return Ok(await _ListarPropostasUseCase.ExecutarAsync());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet("ConsultarProposta")]
        public async Task<ActionResult> ConsultarProposta(int id)
        {
            try
            {
                return Ok(await _ConsultarStatusPropostaUseCase.ExecutarAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
