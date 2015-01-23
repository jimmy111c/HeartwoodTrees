using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeartwoodTrees.Controllers
{
    using HeartwoodTrees.Business.Notifications;
    using HeartwoodTrees.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
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
        public JsonResult SendQuery(QueryModel query)
        {
            //throw new Exception();
            var notificationService = new CustomerQueryEmailService();
            notificationService.SendNotification(new EmailAddress { Address = "jimmy111c@hotmail.com", Name = "james" }, query);

            return new JsonResult { Data = new { status = true, message = "your response has been sent" } };
        }
    }
}
