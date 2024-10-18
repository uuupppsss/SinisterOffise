using Microsoft.AspNetCore.Mvc;
using SinisterOffice666.DB;

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
    }
}
