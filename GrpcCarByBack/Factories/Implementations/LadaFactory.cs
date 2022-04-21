using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCarByBack.Factories.Abstractions;
using GrpcCarByBack.Models.Abstractions;
using GrpcCarByBack.Models.Implementations;

namespace GrpcCarByBack.Factories.Implementations
{
    public class LadaFactory : ICarFactory
    {
        public ICarName GetCarNameCreator()
        {
            return new LadaNameCreator();
        }

        public ICarPrice GetCarPriceCreator()
        {
            return new LadaPriceCreator();
        }
    }
}
