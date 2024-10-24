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
                return BadRequest("��������� �������");
            context.Devils.Add(devil);
            await context.SaveChangesAsync();
            return Ok("��������� ������ �������! ��� ������!");
        }

        [HttpPost("UpdateDevil")]
        public async Task<ActionResult> UpdateDevil(Devil updated_devil)
        {
            context.Devils.Update(updated_devil);
            await context.SaveChangesAsync();
            return Ok("������ ������� �������! ��� ������!");
        }

        [HttpDelete("DeleteDevil")]
        public async Task<ActionResult> DeleteDevil(int id)
        {
            var devils_racks = context.Racks.Where(s => s.IdDevil == id).ToList();
            if (devils_racks.Count > 0)
                return BadRequest("������� � ����� ���������� ���� �� �����, � ���� �������� ������������� ����. " +
                    "����� ��������� ���������� ��������� ��� �������� ���� �� ������� :>");
            var devil_to_remove = context.Devils.Find(id);
            if (devil_to_remove == null)
                return BadRequest("������� ������ ������� ���(");
            context.Devils.Remove(devil_to_remove);
            await context.SaveChangesAsync();
            return Ok("������ ������ �������! ��� ������!");
        }

        [HttpGet("GetDevils")]
        public async Task<List<Devil>> GetDevils()
        {
            List<Devil> devils=context.Devils.OrderBy(d=>d.Id).ToList();
            return devils;
        }
    }
}