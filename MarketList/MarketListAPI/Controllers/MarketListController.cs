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
    [Route("v1/marketlists")]
    public class MarketListController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<MarketList>>> Get([FromServices] DataContext context)
        {
            return await context.MarketLists
                .AsNoTracking()
                .ToListAsync();
        }
        
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult<MarketList>> GetById([FromServices] DataContext context, int id)
        {
            return await context.MarketLists
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<MarketList>> Post([FromServices] DataContext context,
            [FromBody] MarketList model)
        {
            if (ModelState.IsValid)
            {
                context.MarketLists.Add(model);
                await context.SaveChangesAsync();
                return model;
            }

            return BadRequest();
        }
    }
}