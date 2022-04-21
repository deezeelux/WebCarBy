using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCarByBack.Factories.Abstractions;
using GrpcCarByBack.Models.Abstractions;
using GrpcCarByBack.Models.Implementations;



namespace GrpcCarByBack.Factories.Implementations
{
    public class OpelFactory : ICarFactory
    {
        public ICarName GetCarNameCreator()
        {
            return new OpelNameCreator();
        }

        public ICarPrice GetCarPriceCreator()
        {
            return new OpelPriceCreator();
        }
    }
}
