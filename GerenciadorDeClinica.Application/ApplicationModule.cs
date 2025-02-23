using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciadorDeClinica.Application.Commands.AtendimentoCommands.InsertAtendimento;
using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorDeClinica.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers()
                .AddValidators();

            return services;

        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertAtendimentoCommand>());

            services.AddTransient<IPipelineBehavior<InsertAtendimentoCommand, ResultViewModel<int>>, ValidateInsertAtendimentoCommandBehavior>();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertAtendimentoCommand>();

            return services;
        }

    }
}



