using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SinisterOffice666.DB;

namespace SinisterOffice666.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevilsController : ControllerBase
    {
        readonly _666Context context;
        public DevilsController(_666Context context)
        {
            this.context = context;
        }

        [HttpPost("CreateDevil")]
        public async Task<ActionResult> CreateDevil(Devil devil)
        {
            if (devil == null)
                return BadRequest("Сотрудник инвалид");
            context.Devils.Add(devil);
            await context.SaveChangesAsync();
            return Ok("Сотрудник создан успешно! Ура победа!");
        }

        [HttpPost("UpdateDevil")]
        public async Task<ActionResult> UpdateDevil(Devil updated_devil)
        {
            context.Devils.Update(updated_devil);
            await context.SaveChangesAsync();
            return Ok("Дьявол обновлён успешно! Ура победа!");
        }

        [HttpDelete("DeleteDevil")]
        public async Task<ActionResult> DeleteDevil(int id)
        {
            var devils_racks = context.Racks.Where(s => s.IdDevil == id).ToList();
            if (devils_racks.Count > 0)
                return BadRequest("Кажется у этому сотруднику рано на покой, у него остались незавершенные дела. " +
                    "Перед удалением сотрудника передайте его стеллажи кому то другому :>");
            var devil_to_remove = context.Devils.Find(id);
            if (devil_to_remove == null)
                return BadRequest("Кажется такого дьявола нет(");
            context.Devils.Remove(devil_to_remove);
            await context.SaveChangesAsync();
            return Ok("Дьявол удален успешно! Ура победа!");
        }

        [HttpGet("GetDevils")]
        public async Task<List<Devil>> GetDevils()
        {
            List<Devil> devils=context.Devils.OrderBy(d=>d.Id).ToList();
            return devils;
        }
    }
}