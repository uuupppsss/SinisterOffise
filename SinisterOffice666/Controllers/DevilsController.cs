using Microsoft.AspNetCore.Mvc;
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
    }
}