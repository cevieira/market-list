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
            return await context.MarketLists.ToListAsync();
        }
    }
}