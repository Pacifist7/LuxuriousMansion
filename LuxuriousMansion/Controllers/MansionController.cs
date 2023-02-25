using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace LuxuriousMansion.Controllers
{
    public class MansionController : Controller
    {
        // 
        // GET: /Mansion/
        public IActionResult Index()
        {
            return View();
        }
        // 
        // GET: /Mansion/Welcome/ 
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}
