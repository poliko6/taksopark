﻿
using System;
using System.Web.Mvc;
using Taksopark.BL;
using Taksopark.DAL.Models;

namespace Taksopark.MVC.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
       public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult UserInfo()
        {
            return View();
        }

        public ActionResult BingMap()
        {
            return PartialView();
        }

        public ActionResult ConPartialView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderTaxi()
        {
            var userBl = new UserBl();
            var request = new Request();
            if (Session["UserLogin"] != null)
            {
                var user = userBl.GetUserByLogin((string) Session["UserLogin"]);
                request.CreatorId = user.Id;
            }
            else
            {
                request.CreatorId = null;
            }
            request.OperatorId = null;
            request.FinishPoint = Request["txtFrom"];
            request.PhoneNumber = Request["txtPhone"];
            request.StartPoint = Request["txtTo"];
            request.Status = "Active";
            request.RequesTime = Request["date-time"] == string.Empty
                ? DateTime.Now
                : DateTime.Parse(Request["date-time"]);

            userBl.CreateRequest(request);
            return RedirectToAction("Index", "Home");
        }

    }
}