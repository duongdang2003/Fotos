using Fotos.Code;
using Fotos.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotos.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignInModels model)
        {
            var result = new DangNhapModel().Login(model.username, model.hashed_pass);
            if(result && ModelState.IsValid)
            {
                if (model.username.Equals("Admin"))
                {
                    SessionHelper.SetSession(new UserSession() { username = model.username });
                    return RedirectToAction("Index", "Dashboard");
                }
                SessionHelper.SetSession(new UserSession() { username = model.username });
                return RedirectToAction("Index", "Home");   
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }
    }
}