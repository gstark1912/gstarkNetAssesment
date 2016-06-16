using BLL.Interfaces;
using MVC.Common.Authentication;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        IServiceLogin _service;
        public HomeController(IServiceLogin service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            // I Log the user off each time he's in the home page so he needs to log in again like any ATM Application I know..
            SimpleSessionPersister.Username = string.Empty;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult LogCardNumber(LoginViewModel model)
        {
            if (model.CardNumber.ToString().Length != 16)
                return View("Index", new LoginViewModel("A card number must be a 16-digit number"));

            var result = _service.IsCardNumberInvalidOrBlocked(model.CardNumber);

            if (!result.Sucess)
            {
                if (result.Blocked)
                    return View("BlockedCard");
                else
                {
                    return View("Index", new LoginViewModel(result.Message));
                }
            }
            else
                return View("CardPassword", model);
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            var result = _service.Login(model.CardNumber, model.Password);

            if (!result.Sucess)
            {
                if (result.Blocked)
                    return View("BlockedCard");
                else
                    return View("CardPassword", model);
            }
            else
            {
                SimpleSessionPersister.Username = result.CardNumber.ToString();
                return RedirectToAction("Index", "Operations");
            }
        }
    }
}