using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCarByBack.Models.Abstractions;

namespace GrpcCarByBack.Models.Implementations
{
    public class OpelNameCreator : ICarName
    {
        public string GetCarName()
        {
            return "Opel"; 
        }
    }

}
