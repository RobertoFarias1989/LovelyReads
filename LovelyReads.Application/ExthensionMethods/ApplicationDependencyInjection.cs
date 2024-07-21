using FluentValidation;
using FluentValidation.AspNetCore;
using LovelyReads.Application.Author.Commands.CreateAuthor;
using LovelyReads.Application.Author.Validators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LovelyReads.Application.ExthensionMethods
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediator()
                .AddValidator();

            return services;
        }

        public static IServiceCollection AddMediator(this IServiceCollection services) 
        {
            services.AddMediatR(typeof(CreateAuthorCommand));

            return services; 
            
        }

        public static IServiceCollection AddValidator(this IServiceCollection services) 
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAuthorCommandValidator>());

            return services;

        }
    }
}
