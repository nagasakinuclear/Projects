using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Mapping;
using DataLayer.DataAccess;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ShowTasks(int ? UserId , int PageId = 1)
        {
            int pageSize = 6;
            if (UserId == null)
                Error();
            IEnumerable<Tasks> tasks = TasksAccessAsync.GetAllTasksAsync(UserId.Value)
                .Result
                .Skip((PageId - 1) * pageSize)
                .Take(pageSize);
            
            return PartialView(tasks);
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}