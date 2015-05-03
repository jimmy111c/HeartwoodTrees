using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeartwoodTrees.Controllers
{
    using HeartwoodTrees.Business.Notifications;
    using HeartwoodTrees.ViewModels;
    using HeartwoodTrees.ViewModels.Contact;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Services()
        {
            return this.View();
        }

        [HttpPost]
        public JsonResult SendQuery(QueryViewModel query)
        {
            var notificationService = new CustomerQueryEmailService();
            notificationService.SendNotification(query.Model());

            return new JsonResult { Data = new { status = true, message = "your query has been sent, we will get back to you as soon as possible." } };
        }
    }
}
