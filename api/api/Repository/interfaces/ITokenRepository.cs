using api.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace api.Repository.interfaces
{
    public interface ITokenRepository
{
    string CreateJwtToken(User user, List<string> roles);

}
}
