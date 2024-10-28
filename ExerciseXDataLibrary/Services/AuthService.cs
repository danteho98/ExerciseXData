using ExerciseXData.Data;
using ExerciseXData.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Services
{
    public class AuthService
    {
        //private readonly AppDbContext _context;
        //private readonly IConfiguration _configuration;

        //public AuthService(AppDbContext context, IConfiguration configuration)
        //{
        //    _context = context;
        //    _configuration = configuration;
        //}

        //// Authenticate method checks the username and password and returns JWT token or null
        //public string Authenticate(string username, string password)
        //{
        //    var user = _context.Users.SingleOrDefault(u => u.U_Name == username);
        //    if (user == null || !VerifyPasswordHash(password, user.PasswordHash))
        //    {
        //        return null; // Invalid credentials
        //    }

        //    // If authentication succeeds, return a JWT token
        //    var token = GenerateJwtToken(user);
        //    return token;
        //}

        //// Password verification method (e.g., using bcrypt)
        //private bool VerifyPasswordHash(string password, string storedHash)
        //{
        //    // Implement password verification (using plain text for demo purposes, but ideally hashed)
        //    return password == storedHash;
        //}

        //// JWT Token Generation
        //private string GenerateJwtToken(UsersModel user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new List<Claim>
        //{
        //    new Claim(JwtRegisteredClaimNames.Sub, user.U_Name),
        //    new Claim(ClaimTypes.Role, user.Role),  // Role claim
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //};

        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["Jwt:Issuer"],
        //        audience: _configuration["Jwt:Audience"],
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(120),
        //        signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
