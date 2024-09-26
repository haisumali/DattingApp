using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace API.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        var tokenkey = config["TokenKey"] ?? throw new Exception("Cannot access tokenkey from appsetting");
        if (tokenkey.Length<64) throw new Exception("your tokenkey needs to be longer");
        var key = new SymmetricSecurityKey(Encoding.UTF8 .GetBytes(tokenkey));
    
    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier,user.UserName)
    };
    var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
    
    var tokenDecriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = creds

    };

    var tokenHandler = new JwtSecurityTokenHandler();  //This creates an instance of JwtSecurityTokenHandler, which is responsible for creating and validating JWT tokens.


    var token = tokenHandler.CreateToken(tokenDecriptor); //var token = tokenHandler.CreateToken(tokenDecriptor);

    return tokenHandler.WriteToken(token); //Finally, this returns the generated token as a string, which can be sent to the client or used in future requests.


    }

    
}
