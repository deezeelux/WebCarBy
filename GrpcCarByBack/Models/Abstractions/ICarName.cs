using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Здесь объявляется интерфейс машины 
namespace GrpcCarByBack.Models.Abstractions
{
    public interface ICarName
    {
        string GetCarName();
    }
}
