using GrpcCarByBack.Models.Abstractions;

namespace GrpcCarByBack.Methods.Abstractions
{
    public abstract class TemplateMethod
    {
        public bool Template()
        {
            this.AddCarToCart();
            return this.GetStatusOfAddingToCart();
        }

        protected abstract void AddCarToCart();
        protected ICar _car;

        protected bool GetStatusOfAddingToCart()
        {
            return true;             
        }
    }
}
