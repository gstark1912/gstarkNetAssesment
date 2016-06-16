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
    [Authorize]
    public class OperationsController : BaseController
    {
        IServiceOperation _serviceOperation;
        public OperationsController(IServiceOperation serviceOperation)
        {
            _serviceOperation = serviceOperation;
        }

        // GET: Operations
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBalance()
        {
            var result = _serviceOperation.GetBalance(Convert.ToInt64(SimpleSessionPersister.Username));
            return View(new BalanceViewModel { Amount = result, CardNumber = SimpleSessionPersister.Username });
        }

        public ActionResult Withdraw()
        {
            return View();
        }


        public ActionResult TryWithdraw(WithdrawnViewModel model)
        {
            var result = _serviceOperation.WithDraw(Convert.ToInt64(SimpleSessionPersister.Username), model.Amount);

            if (!result.Success)
            {
                ViewBag.Messages = result.Message;
                return View("Withdraw");
            }
            else
            {
                return RedirectToAction("OperationsReport");
            }
        }

        // GET: Operations
        public ActionResult OperationsReport()
        {
            var result = _serviceOperation.GetAllOperations(Convert.ToInt64(SimpleSessionPersister.Username));
            return View(result);
        }
    }
}