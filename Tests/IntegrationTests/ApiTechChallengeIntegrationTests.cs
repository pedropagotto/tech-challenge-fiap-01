using System.Net;
using System.Net.Http.Json;
using Application.ViewModels.Authentication;
using Domain.Entities;
using Domain.Shared;

namespace Tests.IntegrationTests;

public class ApiTechChallengeIntegrationTests
{
    private const string AuthUrl = "api/Authentication/Login";
    
    [Fact(DisplayName = "Lista todos contatos")]
    [Trait("Metodo", "ListAllContacts")]
    public async Task ShouldReturnAllContacts()
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
    
    // Teste de buscar todos contatos com retorno vazio
    [Fact(DisplayName = "Retorna uma lista vazia de contatos")]
    [Trait("Metodo", "ListAllContacts")]
    public async Task ShouldReturnEmptyListOfContacts()
    {
        const string url = "api/Contacts";
        
        await using var application = new TechChallengeFiapApp();
        await TechChallengeFiapMockData.CreateData(application, false);

        var client = await Authenticate(application);
        
        var result = await client.GetAsync(url);
        var users = await result.Content.ReadFromJsonAsync<List<Contact>>();
        
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(users);
        Assert.Equal(users?.Count, 0);
    }
    
    // Teste de busca por um DDD especifico
    [Fact(DisplayName = "Retorna uma lista com filtro de DDD")]
    [Trait("Metodo", "ListAllContacts")]
    public async Task ShouldReturnListOfContactsWhenFilterExists()
    {
        const string url = "api/Contacts?ddd=19";
        
        await using var application = new TechChallengeFiapApp();
        await TechChallengeFiapMockData.CreateData(application, true);

        var client = await Authenticate(application);
        
        var result = await client.GetAsync(url);
        var users = await result.Content.ReadFromJsonAsync<List<Contact>>();
        
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(users);
        Assert.Equal(users?.Count, 2);
    }
    
    // Teste de busca por um DDD especifico que não retorna registros
    [Fact(DisplayName = "Retorna uma lista vazia quando DDD não possui contatos")]
    [Trait("Metodo", "ListAllContacts")]
    public async Task ShouldReturnEmptyListOfContactsWhenThereAreNoFilterMatches()
    {
        const string url = "api/Contacts?ddd=35";
        
        await using var application = new TechChallengeFiapApp();
        await TechChallengeFiapMockData.CreateData(application, true);

        var client = await Authenticate(application);
        
        var result = await client.GetAsync(url);
        var users = await result.Content.ReadFromJsonAsync<List<Contact>>();
        
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(users);
        Assert.Equal(users?.Count, 0);
    }
    
    // Teste criando um novo contato com sucesso
    [Fact(DisplayName = "Cria um novo contato")]
    [Trait("Metodo", "CreateContact")]
    public async Task ShouldCreateNewContact()
    {
        const string url = "api/Contacts";
        
        await using var application = new TechChallengeFiapApp();
        await TechChallengeFiapMockData.CreateData(application, true);

        var client = await Authenticate(application);

        var contact = new Contact
        {
            Name = "Sander Telo",
            Ddd = "19",
            Phone = "982187199",
            Email = "sanderstet@gmail.com",
        };
        
        var result = await client.PostAsJsonAsync(url, contact);
        var newContact = await result.Content.ReadFromJsonAsync<Contact>();
        
        Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        Assert.NotNull(newContact);
    }
    
    // Teste criando um novo contato sem sucesso
    [Fact(DisplayName = "Retorna erro quando dados do contato estao incompletos")]
    [Trait("Metodo", "CreateContact")]
    public async Task ShouldThrowErrorWhenCreateNewContact()
    {
        const string url = "api/Contacts";
        
        await using var application = new TechChallengeFiapApp();
        await TechChallengeFiapMockData.CreateData(application, true);

        var client = await Authenticate(application);

        var contact = new Contact
        {
            Name = "Sander Telo",
            Ddd = "",
            Phone = "",
            Email = "sanderstet@gmail.com",
        };
        
        var result = await client.PostAsJsonAsync(url, contact);
        var newContact = await result.Content.ReadFromJsonAsync<ErrorModel>();
        
        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        Assert.NotNull(newContact);
        Assert.Equal("002", newContact.Code);
    }
    
    // Teste editando um contato existente com sucesso
    [Fact(DisplayName = "Edita dados do contato")]
    [Trait("Metodo", "EditContact")]
    public async Task ShouldEditContact()
    {
        const string url = "api/Contacts/1";
        
        await using var application = new TechChallengeFiapApp();
        await TechChallengeFiapMockData.CreateData(application, true);

        var client = await Authenticate(application);

        var contact = new Contact
        {
            Name = "Maria do Carmo Rodrigues",
            Ddd = "19",
            Phone = "982187171",
            Email = "carminhanovoemail@gmail.com",
        };
        
        var result = await client.PutAsJsonAsync(url, contact);
        var editedContact = await result.Content.ReadFromJsonAsync<Contact>();
        
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(editedContact);
        Assert.Equal("carminhanovoemail@gmail.com", editedContact.Email);
    }
    
    // Teste editando um contato inexistente
    [Fact(DisplayName = "Edita dados de contato inexistente sem sucesso")]
    [Trait("Metodo", "EditContact")]
    public async Task ShouldReturnNotFoundWhenEditNonExistentContact()
    {
        const string url = "api/Contacts/9999";
        
        await using var application = new TechChallengeFiapApp();
        await TechChallengeFiapMockData.CreateData(application, true);

        var client = await Authenticate(application);

        var contact = new Contact
        {
            Name = "Maria do Carmo Rodrigues",
            Ddd = "19",
            Phone = "982187171",
            Email = "carminhanovoemail@gmail.com",
        };
        
        var result = await client.PutAsJsonAsync(url, contact);
        
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
    }
    
    // Teste deletando um contato existente
    [Fact(DisplayName = "Deleta um contato")]
    [Trait("Metodo", "DeleteContact")]
    public async Task ShouldDeleteContact()
    {
        const string url = "api/Contacts/2";
        
        await using var application = new TechChallengeFiapApp();
        await TechChallengeFiapMockData.CreateData(application, true);

        var client = await Authenticate(application);
        
        var result = await client.DeleteAsync(url);
        
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }
    
    // Teste deletando um contato inexistente
    [Fact(DisplayName = "Deleta um contato sem sucesso")]
    [Trait("Metodo", "DeleteContact")]
    public async Task ShouldThrowNotFoundWhenDeleteNonExistentContact()
    {
        const string url = "api/Contacts/9999";
        
        await using var application = new TechChallengeFiapApp();
        await TechChallengeFiapMockData.CreateData(application, true);

        var client = await Authenticate(application);
        
        var result = await client.DeleteAsync(url);
        
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
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