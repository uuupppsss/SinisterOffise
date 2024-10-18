using Microsoft.AspNetCore.Mvc;
using SinisterOffice666.DB;

namespace SinisterOffice666.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlavesController : ControllerBase
    {
        private static List<Devil> devils = new List<Devil>();

        [HttpPost("CreateDevil")]
        public ActionResult CreateDevil(Devil devil)
        {
            if (devil == null)
                return BadRequest("Invalid employee");
            devils.Add(devil);
            return Ok(devil);
        }

        [HttpPost("UpdateDevil")]
        public ActionResult UpdateDevil(Devil updatedevil)
        {
            if (updatedevil == null)
                return BadRequest("Invalid employee");
            Devil devil= devils.FirstOrDefault(e=>e.Id==updatedevil.Id);
        }

        [HttpPost("RemoveDevil")]
        public ActionResult RemoveDevil()
        {

        }
    }
}
