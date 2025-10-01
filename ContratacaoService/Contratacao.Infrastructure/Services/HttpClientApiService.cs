using Contratacao.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Contratacao.Infrastructure.Services
{
    public class HttpClientApiService : IHttpClientApiService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public IHttpClientFactory httpClientFactory;

        public HttpClientApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            this.httpClientFactory = httpClientFactory;
            this.httpContextAccessor = httpContextAccessor;
        }

        public HttpClient GerarHttpClient()
        {
            var httpClient = httpClientFactory.CreateClient();

            return httpClient;
        }
    }
}
