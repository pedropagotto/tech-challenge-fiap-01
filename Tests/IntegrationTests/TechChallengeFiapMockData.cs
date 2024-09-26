using Domain.Entities;
using Infra;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.IntegrationTests;

public class TechChallengeFiapMockData
{
    public static async Task CreateData(TechChallengeFiapApp application, bool criar)
    {
        using (var scope = application.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using (var techChallengeDbContext = provider.GetRequiredService<AppDbContext>())
            {
                await techChallengeDbContext.Database.EnsureCreatedAsync();

                if (criar)
                {
                    #region Contacts
                    await techChallengeDbContext.Contacts.AddAsync(new Contact
                        { Name = "Maria do Carmo Rodrigues", Ddd = "19", Phone = "982187171", Email = "mariadocarmo@hotmail.com" });
                    
                    await techChallengeDbContext.Contacts.AddAsync(new Contact
                        { Name = "Sanders Ernesto", Ddd = "19", Phone = "982347171", Email = "sanders@hotmail.com" });
                    
                    await techChallengeDbContext.Contacts.AddAsync(new Contact
                        { Name = "Mateus Alves", Ddd = "11", Phone = "989857171", Email = "malves@hotmail.com" });
                    #endregion
                    
                    #region Users
                    await techChallengeDbContext.Users.AddAsync(new User 
                        { FirstName = "Jose", LastName = "Ronchi", Email = "seuronchi@hotmail.com", Cpf = "38865053833", AuthenticationId = 1});
                    #endregion
                    
                    #region Authentications
                    await techChallengeDbContext.Authentications.AddAsync(new Authentication 
                        { Email = "seuronchi@hotmail.com", Password = "EC7117851C0E5DBAAD4EFFDB7CD17C050CEA88CB", EmailValidated = true, ChangePassword = false});
                    #endregion
                    
                    await techChallengeDbContext.SaveChangesAsync();
                }
            }
        }
    }
}