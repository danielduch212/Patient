using Microsoft.AspNetCore.Http;

namespace Patient.Application.Users;


public interface IUserContext
{
    public Task<CurrentUser?> GetCurrentUserAsync();
    public CurrentUser? GetCurrentUser();

}

