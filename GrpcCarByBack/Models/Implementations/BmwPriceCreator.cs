using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCarByBack.Models.Abstractions;

namespace GrpcCarByBack.Models.Implementations
{
    public class BmwPriceCreator : ICarPrice
    {
        public int GetCarPrice()
        {
            return 6; 
        }
    }

}
