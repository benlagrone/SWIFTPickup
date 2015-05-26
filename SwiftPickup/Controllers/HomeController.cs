using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SwiftPickup.Data;
using SwiftPickup.Models;
using SwiftPickup.Services;

namespace SwiftPickup.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;
        private ISwiftPickupRepository _repo;

        public HomeController(IMailService mail, ISwiftPickupRepository repo)
        {
            _mail = mail;
            _repo = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var topics = _repo.GetTopics().OrderByDescending(t => t.Created).Take(25).ToList();

            return View(topics);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment from{1}{0}Email:{2}{0}Website: {3}{0}Comment",
                Environment.NewLine,
            model.Name,
            model.Email,
            model.Website);


            _mail.SendMail("noreply@yourdomain.com", 
                "foo@yourdomian.com",
                "Website Contact", 
                msg);
            {
                ViewBag.MailSent = true;
            }
            return View();
        }

        [Authorize]
        public ActionResult MyMessages()
        {
            return View();
        }
    }
}
