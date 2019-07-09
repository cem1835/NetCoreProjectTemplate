using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.WEB.Models;
using Project.ServiceBroker.Interfaces;
using Project.Extensions.MQ;

namespace Project.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestInterface _testInterface;

        public HomeController(TestInterface testInterface)
        {
            this._testInterface = testInterface;
        }


        public IActionResult Index()
        {
            var message = new MessageRequest(1, "test", "");
            var res = MqBus.CreateRequest<MessageRequest, MessageResponse>(message);
            var test = res.Result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignalRChat()
        {
            return View();
        }
    }
}
