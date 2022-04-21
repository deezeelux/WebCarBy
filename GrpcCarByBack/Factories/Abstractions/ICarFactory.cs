using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCarByBack.Models.Abstractions;

//Интерфейс фабрики
namespace GrpcCarByBack.Factories.Abstractions
{
    public interface ICarFactory
    {
        ICarName GetCarNameCreator();

        ICarPrice GetCarPriceCreator();
    }
}
