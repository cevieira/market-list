using System;
using System.Net;
using System.Threading.Tasks;
using MarketListAPI.Data;
using MarketListAPI.Helpers;
using MarketListAPI.Models;
using MarketListAPI.Repositories;
using MarketListAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketListAPI.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]AuthenticateModel model, [FromServices]DataContext context,
            [FromServices] PasswordHasher passwordHasher,
            [FromServices]UserService userService)
        {
            var user = await userService.Authenticate(context, passwordHasher, model.Username, model.Password);

            if (user == null)
                return NotFound();

            var token = TokenService.GenerateToken(user);

            return new
            {
                user = user.WithoutPassword(),
                token = token
            };
        }
        
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post([FromServices] DataContext context,
            [FromServices] PasswordHasher passwordHasher,
            [FromBody]User model)
        {
            if (ModelState.IsValid)
            {
                var passwordHashed = passwordHasher.Hash(model.Password);
                model.Password = passwordHashed;
                
                if (string.IsNullOrWhiteSpace(model.Role))
                {
                    model.Role = Role.User;
                }
                
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return model;
            }

            return BadRequest();
        }
    }
    
    
}