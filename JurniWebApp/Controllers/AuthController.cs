using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JurniWebApp.Data;
using JurniWebApp.Data.Entities;
using JurniWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace JurniWebApp.Controllers {
    [Route("api/[controller]"), ApiController]
    public class AuthController : ControllerBase {
        private readonly JurniWebAppDbContext _context;
        
        public static string TokenKey = "SECRETKEY";

        public AuthController(JurniWebAppDbContext context, IConfiguration configuration) {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request) {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto request) {
            try {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
                if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt)) {
                    return Unauthorized("Invalid email or password");
                }
                
                string token = CreateToken(user);

                return Ok(token);
            } catch (NullReferenceException) {
                return Unauthorized("Invalid email or password");
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) {
            using (var hmac = new HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) {
            using (var hmac = new HMACSHA512(passwordSalt)) {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        
        private string CreateToken(User user) {
            List<Claim> claims = new List<Claim>();
            if (user.IsAdmin) {
                claims.Add(new Claim(ClaimTypes.Name, user.Email));
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            } else {
                claims.Add(new Claim(ClaimTypes.Name, user.Email));
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}