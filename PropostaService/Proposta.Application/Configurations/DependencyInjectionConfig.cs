using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Proposta.Application.Interfaces;
using Proposta.Application.Mappings;
using Proposta.Application.UserCases;
using Proposta.Domain.Interfaces;
using Proposta.Infrastructure.Repositories;

namespace Proposta.Application.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ApiConfigServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IPropostaRepository, PropostaRepository>();
            services.AddScoped<ICriarPropostaUseCase, CriarPropostaUseCase>();
            services.AddScoped<IAlterarStatusUseCase, AlterarStatusUseCase>();
            services.AddScoped<IListarPropostasUseCase, ListarPropostasUseCase>();
            services.AddScoped<IConsultarStatusPropostaUseCase, ConsultarStatusPropostaUseCase>();

            var configExpression = new MapperConfigurationExpression();
            configExpression.AddProfile<PropostaMapper>();

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PropostaMapper>();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }        
    }
}
