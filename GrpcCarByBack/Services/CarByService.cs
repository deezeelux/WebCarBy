using Grpc.Core;
using GrpcCarByBack.Data;
using GrpcCarByBack.Factories.Implementations;
using GrpcCarByBack.Methods.Abstractions;
using GrpcCarByBack.Methods.Implementations;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcCarByBack
{
    public class CarByServiceService : CarByService.CarByServiceBase
    {
        public CarByServiceService()
        {
        }

        //Метод сервиса для очистки корзины
        public override Task<StatusResponse> ClearCart(Empty request, ServerCallContext context)
        {
            try
            {
                CartSingleton.ClearCart();
                return Task.FromResult(new StatusResponse() { Status = true });
            }
            catch
            {
                return Task.FromResult(new StatusResponse() { Status = false });
            }
        }

        //Метод сервиса для добавления в корзину
        public override Task<StatusResponse> AddCar(Car request, ServerCallContext context)
        {
            try
            {
                TemplateMethod method = null;
                if (request.Name.ToLower() == "bmw")
                {
                    method = new AddingBmw();
                }
                else if (request.Name.ToLower() == "lada")
                {
                    method = new AddingLada();
                }
                else if (request.Name.ToLower() == "opel")
                {
                    method = new AddingOpel();
                }
                var result = method.Template();
                return Task.FromResult(new StatusResponse() { Status = result });
            }
            catch
            {
                return Task.FromResult(new StatusResponse() { Status = false });
            }
        }

        //Метод сервиса для получения состояния корзины
        public override Task<DataModel> GetData(Empty request, ServerCallContext context)
        {
            var cartInstance = CartSingleton.GetInstance();
            var response = new DataModel(); // Выделение памяти под ответ, в котором список и сумма из полученной корзины
            response.Amount = cartInstance.Amount; // Добавление в ответ текущей суммы 
            response.Cars.AddRange(cartInstance.CurrentCart); // Добавление списка
            return Task.FromResult(response);
        }
    }
}
