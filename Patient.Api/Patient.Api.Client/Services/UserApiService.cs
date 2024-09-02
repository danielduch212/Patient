using Patient.Api.Client.AdditionalClasses;
using System.Net.Http.Json;
using Shared.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Patient.Api.Client.Services;

public class UserApiService
{
    private readonly HttpClient _httpClient;

    public UserApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
   
    public async Task<IdentityOperationResult> SendRegisterRequest(RegisterUserData userData)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/Users/register", userData);
        IdentityOperationResult operationResult = new IdentityOperationResult();
        operationResult = await response.Content.ReadFromJsonAsync<IdentityOperationResult>();
        return operationResult;


    }

    public async Task<IdentityOperationResult> SendLoginRequest(string email, string password)
    {
        (string, string) data = (email, password);
        var response = await _httpClient.PostAsJsonAsync("api/Users/login", data);
        IdentityOperationResult operationResult = new IdentityOperationResult();

        operationResult = await response.Content.ReadFromJsonAsync<IdentityOperationResult>();
        return operationResult;


    }
}
