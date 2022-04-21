using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GrpcCarByBack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebCarBy.Models;

namespace WebCarBy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using (var channel = GrpcChannel.ForAddress("https://localhost:5001")) // Создание канала связи между клиентской стороной и сервисом
            {
                var client = new CarByService.CarByServiceClient(channel);
                var info = await client.GetDataAsync(new Empty()); // Запрос данных от grpc-сервиса
                var response = new IndexViewModel();
                response.NameList = new List<string>();
                response.NameList.AddRange(info.Cars);
                response.Amount = info.Amount;

                return View(response);
            } 
        }
         
        
        public IActionResult AddCar(string carname)
        {
            using(var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var client = new CarByService.CarByServiceClient(channel);
                client.AddCar(new Car()
                {
                    Name = carname
                });
                return Redirect("~/Home/Index");
            }
        }

        public IActionResult ClearCart()
        {
            using(var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var client = new CarByService.CarByServiceClient(channel);
                client.ClearCart(new Empty());
                return Redirect("~/Home/Index");
            }
        }
    }
}
