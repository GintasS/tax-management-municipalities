using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxManagementAPI.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
