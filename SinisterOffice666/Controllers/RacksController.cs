using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SinisterOffice666.DB;
using System;

namespace SinisterOffice666.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RacksController : ControllerBase
    {
        readonly _666Context context;
        public RacksController(_666Context context)
        {
            this.context = context;
        }

        [HttpGet("GetRacks")]
        public ActionResult<List<Rack>> GetRacks()
        {
            List<Rack> racks = context.Racks.Include(r => r.IdDevilNavigation).OrderBy(r => r.Id).ToList();
            return racks;
        }

        [HttpPost("CreateRack")]
        public async Task<ActionResult> CreateRack( Rack rack)
        {
            if (rack == null)
                return BadRequest("Стеллаж инвалид");
            rack.IdDevilNavigation = null;
            context.Racks.Add(rack);
            await context.SaveChangesAsync();
            return Ok("Стеллаж создан! Ура победа!");
        }

        [HttpPost("UpdateRack")]
        public async Task<ActionResult> UpdateRack(Rack updated_rack)
        {
            if (updated_rack == null)
                return BadRequest("Стеллаж инвалид");
            context.Racks.Update(updated_rack);
            await context.SaveChangesAsync();
            return Ok("Стеллаж обновлён! Ура победа!");
        }

        [HttpDelete("RemoveRack")]
        public async Task<ActionResult> RemoveRack(int id)
        {
            var rack_to_remove = context.Racks.Find(id);
            context.Racks.Remove(rack_to_remove);
            await context.SaveChangesAsync();
            return Ok("Стеллаж удалён! Ура победа!");
        }
    }
}
