using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Models;
using API.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class JwtService
    {
        private IConfiguration config;

        public JwtService(IConfiguration config)
        {
            this.config = config;
        }

        public string GenerateSecurityToken(User result)
        {
            var claims = new List<Claim>();

            //claims.Add(new Claim("Id", result.Id.ToString()));
            claims.Add(new Claim("Username", result.Username));

            foreach (var item in result.UserRoles)
            {
                claims.Add(new Claim("roles", item.Role.RoleEmployee));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtConfig:secret"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                config["JwtConfig:Issuer"],
                config["JwtConfig:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn
                );

            var idToken = new JwtSecurityTokenHandler().WriteToken(token);

            return idToken;
        }
    }
}
