using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentExchange.API.Configuration
{
    public static class IdentityConfig
    {
        //public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
        //                                                               IConfiguration configuration)
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //    {
        //        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //    });

        //    services.AddIdentity<IdentityUser, IdentityRole>()
        //        .AddEntityFrameworkStores<ApplicationDbContext>()
        //        .AddDefaultTokenProviders();

        //    IConfigurationSection appSettingsSection = configuration.GetSection("AppSettings");
        //    services.Configure<AppSettings>(appSettingsSection);

        //    AppSettings appSettings = appSettingsSection.Get<AppSettings>();
        //    byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

        //    services.AddAuthentication(c =>
        //    {
        //        c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    }).AddJwtBearer(c =>
        //    {
        //        c.RequireHttpsMetadata = true;
        //        c.SaveToken = true;
        //        c.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidAudience = appSettings.Audience,
        //            ValidIssuer = appSettings.Issuer
        //        };
        //    });

        //    return services;
        //}
    }
}
