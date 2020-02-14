using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Tutorial.Models;

namespace Tutorial.Security
{
    public class AuthManager
    {
        public string Login(UserModel user)
        {
            try
            {
                if (user.UserName == "anoop" && user.Password == "anoop")
                {
                    UserView userView = new UserView();

                    userView.JWTToken = GenerateJWT();

                    return JsonConvert.SerializeObject(userView);

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }  
        }

        public string GenerateJWT()
        {
            //security key
            string securityKey = "this_is_our_supper_long_security_key_for_token_validation_project_2018_09_07$smesk.in";

            //symmetric security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing credentials
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //create token
            var token = new JwtSecurityToken(
                    issuer: "inkers.in",
                    audience: "readers",
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                );

            //return token
            string s = (new JwtSecurityTokenHandler().WriteToken(token));
            return s;
        }
    }
}
