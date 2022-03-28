using AppServices.Mappings;
using AppServices.Services;
using AppServices.Services.Interface;
using AutoMapper;
using Class.Context;
using Class.Identity;
using Class.Repositories;
using Domain.Account;
using Domain.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgressConection")));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "Account/Login");

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<IComicBookService, ComicBookService>();
            services.AddScoped<IComicBookRepository, ComicBookRepository>();

            services.AddScoped<IBuyService, BuyService>();
            services.AddScoped<IBuyRepository, BuyRepository>();

            services.AddAutoMapper(typeof(DomainToDTOMapping));
            services.AddAutoMapper(typeof(DtoToDomain));

            return services;

        }
    }
}
