using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcCarByBack.Models.Abstractions
{
    public interface ICar
    {
        string GetName();
        int GetPrice();
    }
}
