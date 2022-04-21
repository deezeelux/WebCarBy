using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCarByBack.Models.Abstractions;
using GrpcCarByBack.Factories.Abstractions;
using System.IO;

namespace GrpcCarByBack.Models.Implementations
{
    public class ProxyCar : ICar
    {
        //Инъекция зависимости. 
        private ICar _car;
        public ProxyCar(ICar car)
        {
            //Получаем экземпляр машины снаружи
            _car = car;
        }
        //--------------------
        public string GetName()
        {
            var name = _car.GetName();

            Directory.CreateDirectory("logs");
            using (StreamWriter writer = new StreamWriter("logs/log.txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " getting car name: " + name);
            }

            return name;

        }
        public int GetPrice()
        {
            var price = _car.GetPrice();

            using (StreamWriter writer = new StreamWriter("logs/log.txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " getting car price: " + price);
            }

            return price;
        }
    }
}
