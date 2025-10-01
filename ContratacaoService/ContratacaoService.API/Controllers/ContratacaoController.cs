using Contratacao.Application.Dtos;
using Contratacao.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ContratacaoService.API.Controllers
{
    public class ContratacaoController : Controller
    {
        private readonly IContratarPropostaUseCase _ContratarPropostaUseCase;

        public ContratacaoController(IContratarPropostaUseCase contratarPropostaUseCase)
        {
            _ContratarPropostaUseCase = contratarPropostaUseCase;
        }

        [HttpPost("ContratarProposta")]
        public async Task<ActionResult> ContratarProposta(ContratacaoRequest request)
        {
            try
            {
                return Ok(await _ContratarPropostaUseCase.ExecutarAsync(request));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
