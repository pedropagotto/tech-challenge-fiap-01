using System.Net;
using System.Net.Http.Json;
using Application.ViewModels.Authentication;
using Domain.Entities;

namespace Tests.IntegrationTests;

public class ApiTechChallengeIntegrationTests
{
    private const string AuthUrl = "api/Authentication/Login";
    
    [Fact(DisplayName = "Lista todos contatos")]
    [Trait("Metodo", "ListAllContacts")]
    public async Task ListAllContacts()
    {
        const string url = "api/Contacts";
        
        await using var application = new TechChallengeFiapApp();
        await TechChallengeFiapMockData.CreateData(application, true);

        var client = await Authenticate(application);
        
        var result = await client.GetAsync(url);
        var users = await result.Content.ReadFromJsonAsync<List<Contact>>();
        
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(users);
        Assert.NotEqual(users?.Count, 0);
    }

    private static async Task<HttpClient> Authenticate(TechChallengeFiapApp application)
    {
        var login = new LoginRequestModel
        {
            Email = "seuronchi@hotmail.com",
            Password = "102030"
        };
        
        var client = application.CreateClient();
        
        var authResponse = await client.PostAsJsonAsync(AuthUrl, login);
        var auth = await authResponse.Content.ReadFromJsonAsync<AuthenticationResponseModel>();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + auth!.AccessToken);

        return client;
    }
}