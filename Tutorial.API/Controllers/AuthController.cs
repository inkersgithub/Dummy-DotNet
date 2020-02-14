using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Tutorial.Models;
using Tutorial.Security;

namespace Tutorial.AuthController
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login(string username, string password)
        {
            try
            {
                AuthManager auth = new AuthManager();
                UserModel user = new UserModel();

                user.UserName = username;
                user.Password = password;

                string result = auth.Login(user);
               
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized();
                }   
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        public string Test()
        {
            return null;
        }
    }
}