using ArtCave.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArtCave.Web.JwtFeatures
{
    public class JwtHandler
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;

        public JwtHandler(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection(Constants.Constants.Jwt.JwtSettings);
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection(Constants.Constants.Jwt.Key).Value!);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<List<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
                claims.Add(new Claim("role", role));
            }

            return claims;
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings[Constants.Constants.Jwt.Issuer],
                audience: _jwtSettings[Constants.Constants.Jwt.Issuer],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings[Constants.Constants.Jwt.Expiry])),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }
    }
}
