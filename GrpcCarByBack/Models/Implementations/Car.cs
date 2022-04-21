using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCarByBack.Models.Abstractions;
using GrpcCarByBack.Factories.Abstractions;

namespace GrpcCarByBack.Models.Implementations
{
    public class Car : ICar
    {
        //Инъекция зависимости 
        private ICarFactory _carFactory;
        public Car(ICarFactory carFactory)
        {
            //Получаем экземпляр фабрики снаружи
            _carFactory = carFactory;
        }
        //--------------------
        public string GetName()
        {
            //Получаем из фабрики NameCreator
            var nameCreator = _carFactory.GetCarNameCreator();
            //Получаем из NameCreator имя автомобиля
            var name = nameCreator.GetCarName();
            //Возвращаем имя автомобиля
            return name;
        }
        public int GetPrice()
        {
            var priceCreator = _carFactory.GetCarPriceCreator();
            var price = priceCreator.GetCarPrice();
            return price;
        }
    }
}
