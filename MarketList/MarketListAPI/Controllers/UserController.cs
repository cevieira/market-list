using System.Net;
using System.Threading.Tasks;
using MarketListAPI.Data;
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
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model, [FromServices]DataContext context )
        {
            var user = await UserRepository.Get(context, model.Username, model.Password);

            if (user == null)
                return NotFound();

            var token = TokenService.GenerateToken(user);

            user.Password = "";
    
            return new
            {
                user = user,
                token = token
            };
        }
        
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post([FromServices] DataContext context,
            [FromBody]User model)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return model;
            }

            return BadRequest();
        }
    }
    
    
}