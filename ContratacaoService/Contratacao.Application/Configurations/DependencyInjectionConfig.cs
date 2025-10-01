using AutoMapper;
using Contratacao.Application.Interfaces;
using Contratacao.Application.Mappings;
using Contratacao.Application.UserCases;
using Contratacao.Domain.Interfaces;
using Contratacao.Infrastructure.Repositories;
using Contratacao.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Contratacao.Application.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ApiConfigServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpClientApiService, HttpClientApiService>();

            services.AddScoped<IContratacaoRepository, ContratacaoRepository>();
            services.AddScoped<IContratarPropostaUseCase, ContratarPropostaUseCase>();
            services.AddScoped<IPropostaServiceClient, PropostaServiceClient>();

            var configExpression = new MapperConfigurationExpression();
            configExpression.AddProfile<ContratacaoMapper>();

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ContratacaoMapper>();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
