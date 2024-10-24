using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SinisterOffice666.DB;

namespace SinisterOffice666.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisposeController : ControllerBase
    {
        readonly _666Context DbContext;
        public DisposeController(_666Context context)
        {
            this.DbContext = context;
        }

        [HttpPost("DisposeRack")]
        public async Task<ActionResult> DisposeRack(Rack rack)
        {
            if(rack==null)
                return BadRequest("Стеллаж инвалид");
            Disposal disposal = new Disposal() { Id=rack.Id, Title=rack.Title, Year=rack.YearBuy};
            DbContext.Disposals.Add(disposal);
            await DbContext.SaveChangesAsync();
            return Ok("Стеллаж утилизирован! Ура победа!");
        }
    }
}
