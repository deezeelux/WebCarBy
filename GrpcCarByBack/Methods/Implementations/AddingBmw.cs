using GrpcCarByBack.Data;
using GrpcCarByBack.Factories.Abstractions;
using GrpcCarByBack.Factories.Implementations;
using GrpcCarByBack.Methods.Abstractions;
using GrpcCarByBack.Models.Implementations;

namespace GrpcCarByBack.Methods.Implementations
{
    public class AddingBmw : TemplateMethod
    {
        public AddingBmw()
        {
            _car = new ProxyCar(new Models.Implementations.Car(new BmwFactory()));
        }
        protected override void AddCarToCart()
        {
            var carname = _car.GetName();
            var carprice = _car.GetPrice();
            CartSingleton.AddToCart(carname, carprice);
        }
    }
}
