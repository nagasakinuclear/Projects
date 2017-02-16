using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DOC.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        DOC.Models.DocDBEntities db = new Models.DocDBEntities();
        [HttpGet]
        public async Task<ActionResult> Info(int Serv_Id, string name)
        {
            ViewBag.Name = name;
            return await Task.Run(() =>
            {
                ViewBag.Service = db.MainContent.FirstOrDefault(x => x.Id == Serv_Id);
                return View();
            });
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}