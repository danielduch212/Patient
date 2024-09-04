using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Interfaces;

public interface ITokenGenerator
{
    public Task<string> GenerateToken(User user);
}
