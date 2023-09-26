using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWD_API.Payload.Response;
using SWD_API.Repository.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SWD_API.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IConfiguration _config;
        private readonly SWDProjectContext _db = new();

        public AccountServices(IConfiguration config)
        {
            _config = config;

        }

        public LoginResponse? Login(string email)
        {
            var intern = _db.Interns.Where(x => x.Email.Equals(email)).Include(x => x.University).Include(x => x.Major)
                .Include(x => x.Team).Include(x => x.InternshipSemester).FirstOrDefault();
            var user = _db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (intern != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                 new Claim(ClaimTypes.Email,intern.Email),
                new Claim(ClaimTypes.Role,intern.Role)
            };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);


                var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
                return new LoginResponse
                {
                    AccessToken = accessToken,
                    Id = intern.Id,
                    FullName = intern.FullName,
                    PhoneNumber = intern.PhoneNumber,
                    Dob = intern.Dob,
                    Major = intern.Major.Name,
                    University = intern.University.Name,
                    Team = intern.Team.Name,
                    InternshipSemester = intern.InternshipSemester.Name,
                    Gender = intern.Gender,
                    Role = intern.Role,
                    Email = email,
                    Status = intern.Status
                };
            }
            else if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                 new Claim(ClaimTypes.Email,user.Email),
                 new Claim(ClaimTypes.Role,user.Role)
            };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);


                var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

                return new LoginResponse
                {
                    AccessToken = accessToken,
                    Id = user.Id,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    Dob = user.Dob,
                    Gender = user.Gender,
                    Role = user.Role,
                    Email = email,
                    Status = user.Status
                };
            }
            else
            {
                return null;
            }
        }
    }
}
