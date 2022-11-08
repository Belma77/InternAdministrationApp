using AutoMapper;
using Backend.Dtos;
using Backend.Models;
using Backend.Repository.UserRepo;
using Backend.Services.AuthService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Backend.Services.UserService
{
    public class AuthService:IAuthService
    {

        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private User _user;
        private SignInManager<User> signInManager;

        public AuthService(UserManager<User> userManager, IConfiguration configuration, IMapper mapper, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }
        
        public async Task<IdentityResult> RegisterUserAsync(AddEditorDto userRegistration)
        {
            var user = _mapper.Map<User>(userRegistration);
            var result = await _userManager.CreateAsync(user, userRegistration.Password);
            return result;
        }

        public async Task<bool> ValidateUserAsync(UserLoginDto loginDto)
        {
            _user = await _userManager.FindByNameAsync(loginDto.Username);
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password);
            return result;
        }

        public async Task<string> CreateTokenAsync()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        public async Task<string> Login(UserLoginDto user)
        {
            if (!await ValidateUserAsync(user))
                throw new Exception("User not found");
            return await CreateTokenAsync();
        }
        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName),

        };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
               
            }
            return claims;
        }
        //protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        //{
        //    var identity = await base.GenerateClaimsAsync(user);
        //    identity.AddClaim(new Claim("firstname", user.FirstName));
        //    identity.AddClaim(new Claim("lastname", user.LastName));
        //    var roles = await UserManager.GetRolesAsync(user);
        //    foreach (var role in roles)
        //    {
        //        identity.AddClaim(new Claim(ClaimTypes.Role, role));
        //    }

        //    return identity;
        //}
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }

}

