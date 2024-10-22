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
        readonly _666Context DbContext;
        public RacksController(_666Context context)
        {
            this.DbContext = context;
        }

        [HttpGet("GetRacks")]
        public ActionResult<List<Rack>> GetRacks()
        {
            List<Rack> racks = new List<Rack>(DbContext.Racks);
            return Ok(racks);
        }

        [HttpPost("CreateRack")]
        public async Task<ActionResult> CreateRack( Rack rack)
        {
            if (rack == null) return BadRequest("Invalid rack");
            DbContext.Racks.Add(rack);
            await DbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("UpdateRack")]
        public async Task<ActionResult> UpdateRack(int id, Rack rack)
        {
            if (id != rack.Id) return BadRequest("Invalid rack");
            DbContext.Entry(rack).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Appointment")]
        public async Task<ActionResult> Appointment(Rack rack, int devil_id)
        {
            if (rack == null || devil_id == 0)
                return BadRequest("Invalid data");
            rack.IdDevil = devil_id;
            DbContext.Entry(rack).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
