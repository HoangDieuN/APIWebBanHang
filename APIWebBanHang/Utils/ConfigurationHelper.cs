using Autofac;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebBanHang
{
    public static class ConfigurationHelper
    {
        // Tthông tin Services Collection
        public static void ServiceConfigs(IServiceCollection services)
        {
            #region Common

            services.AddControllers();
            services.AddOptions();
            services.AddCors();

            #endregion Common
        }

        /// <summary>
        /// swagger configs
        /// </summary>
        /// <param name="services"></param>
        public static void SwaggerConfigs(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "APIWebBanHang",
                    Description = "API web bán hàng",
                });
                c.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName };
                    }

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor != null)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });
                c.DocInclusionPredicate((name, api) => true);
            });
            //services.ConfigureOptions<ConfigureSwaggerOptions>();
        }

        /// <summary>
        /// autofac configs
        /// </summary>
        /// <param name="builder"></param>
        public static void AutofacConfigs(ContainerBuilder builder)
        {
            builder.RegisterType<AppConfiguration>().As<IAppConfiguration>();
            //register all type ends with "Repository"
            builder.RegisterAssemblyTypes(typeof(BaseRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
        }
    }

    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }
    }
}
