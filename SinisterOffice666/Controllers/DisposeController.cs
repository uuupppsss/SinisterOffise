﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
