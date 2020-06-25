using System.Collections.Generic;
using System.Threading.Tasks;
using MarketListAPI.Data;
using MarketListAPI.Models;
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
        public async Task<ActionResult<List<MarketList>>> Get([FromServices] DataContext context)
        {
            return await context.MarketLists
                .Include(x => x.Itens)
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpPost]
        [Route("")]
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