﻿using LovelyReads.Core.Repositories;
using LovelyReads.Core.Services;
using LovelyReads.Infrastructure.Persistence;
using LovelyReads.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LovelyReads.Infrastructure.ExtensionMethods
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddRepositories()
                .AddUnitOfWork()
                .AddDbContext(configuration)
                .AddAuthService();

            return services;
            
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserBookRepository, UserBookRepository>();
            services.AddScoped<IUserBookReviewRepository, UserBookReviewRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("LovelyReadsCs");

            services.AddDbContext<LovelyReadsDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services) 
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        
        }

        public static IServiceCollection AddAuthService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService.AuthService>();

            return services;
        }
    }
}
