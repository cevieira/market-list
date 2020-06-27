using System.Collections.Generic;
using System.Threading.Tasks;
using MarketListAPI.Data;
using MarketListAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketListAPI.Controllers
{
    [ApiController]
    [Route("v1/items")]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<Item>>> Get([FromServices] DataContext context)
        {
            return await context.Items
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<Item>> Post([FromServices] DataContext context,
            [FromBody] Item model)
        {
            if (ModelState.IsValid)
            {
                context.Items.Add(model);
                await context.SaveChangesAsync();
                return model;
            }

            return BadRequest();
        }
    }
}