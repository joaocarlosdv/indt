using Contratacao.Domain.Interfaces;
using Contratacao.Domain.Models;
using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Contratacao.Infrastructure.Services
{
    public class PropostaServiceClient : IPropostaServiceClient
    {
        private readonly IHttpClientApiService httpClientApiService;
        private readonly HttpClient _httpClient;

        public PropostaServiceClient(IHttpClientApiService httpClientApiService)
        {
            this.httpClientApiService = httpClientApiService;
            _httpClient = httpClientApiService.GerarHttpClient();
        }

        public async Task<Proposta> ConsultarStatusProposta(int propostaId)
        {            
            var response = await _httpClient.GetAsync($"https://localhost:7174/ConsultarProposta?id={propostaId}");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var requisicao = JsonConvert.DeserializeObject<dynamic>(responseBody);

            if (requisicao == null)
                return null;

            return requisicao.ToObject<Proposta>();
        }
    }
}
