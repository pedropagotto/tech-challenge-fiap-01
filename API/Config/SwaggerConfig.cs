using Microsoft.OpenApi.Models;
using System.Reflection;

namespace API.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {

            });


            services.AddSwaggerGen(options =>
            {
                // Configuração do título e descrição
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para cadastro de contatos",
                    Description = "Esta API fornece serviços para cadastro, consulta e edição de contatos.",
                    Contact = new OpenApiContact
                    {
                        Name = "Equipe Projeto 1",
                        Email = "sergiofdf@gmail.com"
                    }
                });


                // Para incluir comentários XML
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);


                //Configs para autenticação JWT
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Autenticacao baseada em Json Web Token. Informar somente o token, sem a palavra 'Bearer'."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });

            return services;
        }
    }
}
