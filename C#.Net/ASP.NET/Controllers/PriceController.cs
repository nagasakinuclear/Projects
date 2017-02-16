
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DOC.Controllers
{
    public class PriceController : Controller
    {
        // GET: Price
        DOC.Models.DocDBEntities db = new Models.DocDBEntities();
        [HttpGet]
        public async Task<ActionResult> ShowPrices()
        {
            return await Task.Run(() =>
            {
                ViewBag.Service = db.Services.ToList();
                return View();
            });
        }
    }
}