using System;
using System.Linq;
using System.Web.Mvc;
using DOC.Models;
using System.Data;

namespace DOC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DOC.Models.DocDBEntities db = new Models.DocDBEntities();
        [HttpPost]
        public RedirectToRouteResult AddInfo(Orders order)
        {
            int Id = (from m in db.Orders select m.Id).ToList().Last() + 1;
            order.Id = Id;
            if (order.Description.Length > 80 || order.Name.Length > 40 || order.Number.Length > 18)
                return RedirectToAction("WrongInput", "Home", new { Message = "Превышен лимит символов. Попробуйте еще раз" });
            try
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("WrongInput", "Home", new { Message = ex.Message + ". Попробуйте еще раз" });
            }
            return RedirectToAction("Greetings");
        } 
        [HttpGet]
        public ActionResult Index()
        {
            return View();  
        }
        [HttpGet]
        public ActionResult WrongInput(string Message)
        {
            ViewBag.ErrorMessage = Message;
            return View();
        }
        [HttpGet]
        public ActionResult Greetings()
        {
            return View();
        }
        [HttpGet]
        public String GetList()
        {
            string buf ="";
            buf += "<ul>";
           
                foreach (var item in db.Services)
                {
                    buf += "<li>";
                    buf += "<a href = " + Url.Action("Info", "Service", new { Serv_Id = item.Id, name = item.Name }) + ">";
                    buf += "<span>" + item.Name + "</span>" + "</a>";
                    buf += "</li>";
                }
                buf += "</ul>";
                return buf;             
        }
    }
}