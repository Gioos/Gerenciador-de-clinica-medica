using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciadorDeClinica.Application.Commands.AtendimentoCommands.InsertAtendimento;
using GerenciadorDeClinica.Application.Commands.RecuperarSenhaCommands;
using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Infrastructure.Notifications;
using GerenciadorDeClinica.Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Extensions.DependencyInjection;
using System.Text;

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
            {
                config.RegisterServicesFromAssemblyContaining<InsertAtendimentoCommand>();
                



            });



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



