using LinkSharingRepository.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkSharingRepository.Services
{
    public interface ITokenService
    {
        Task<String> GetUserIdFromJWT(string jwtToken);
        public string GenerateToken(User user);
    }
}
