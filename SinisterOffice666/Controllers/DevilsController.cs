using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SinisterOffice666.DB;

namespace SinisterOffice666.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevilsController : ControllerBase
    {
        readonly _666Context DbContext;
        public DevilsController(_666Context context)
        {
            this.DbContext = context;
        }

        [HttpPost("CreateDevil")]
        public async Task<ActionResult> CreateDevil(Devil devil)
        {
            if (devil == null)
                return BadRequest("Invalid employee");
            DbContext.Devils.Add(devil);
            await DbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("UpdateDevil")]
        public async Task<ActionResult> UpdateDevil(int id, Devil updated_devil)
        {
            if (id != updated_devil.Id) return BadRequest("Invalid employee");
            DbContext.Entry(updated_devil).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteDevil")]
        public async Task<ActionResult> DeleteDevil(int id)
        {
            Devil devil = await DbContext.Devils.FindAsync(id);
            if (devil == null) return NotFound("Unknown employee");
            DbContext.Devils.Remove(devil);
            await DbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("GetDevils")]
        public ActionResult<List<Devil>> GetDevils()
        {
            List<Devil> devils=new List<Devil>(DbContext.Devils);
            return Ok(devils);
        }
    }
}