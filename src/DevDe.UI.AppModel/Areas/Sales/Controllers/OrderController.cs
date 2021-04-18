using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDe.UI.AppModel.Areas.Sales.Controllers
{
    public class OrderController : Controller
    {
        [Area("Sales")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
