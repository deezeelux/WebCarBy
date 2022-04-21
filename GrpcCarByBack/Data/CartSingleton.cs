using System.Collections.Generic;


// Паттерн "Многопоточный одиночка" для списка в корзине
namespace GrpcCarByBack.Data
{
    public class CartSingleton
    {
        private CartSingleton() { }

        private static CartSingleton _instance; // Объект корзины (наш одиночка)

        private static readonly object _lock = new object();

        public static CartSingleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock) // Блокировщик действий
                {
                    if (_instance == null) // Повторная проверка на создание
                    {
                        _instance = new CartSingleton();
                        _instance.CurrentCart = new List<string>();
                        _instance.Amount = 0;
                    }
                }
            }
            return _instance;
        }

        public static void AddToCart(string carName, int carPrice)
        {
            if (_instance?.CurrentCart == null)
            {
                lock (_lock)
                {
                    if (_instance?.CurrentCart == null)
                    {
                        _instance = new CartSingleton();
                        _instance.CurrentCart = new List<string>();
                        _instance.Amount = 0;
                    }
                }
            }
            // Добавление итема в список в корзине
            _instance.CurrentCart.Add(carName);
            // Добавление цены итема в существующую сумму в корзине
            _instance.Amount += carPrice;
        }

        public static void ClearCart()
        {
            if (_instance?.CurrentCart != null)
            {
                lock (_lock)
                {
                    // Удаление итемов в списке в корзине
                    _instance.CurrentCart.Clear();
                    _instance.Amount = 0;
                }
            }
        }

        public List<string> CurrentCart { get; private set; } // Список в текущей корзине
        public int Amount { get; private set; } // Сумма товаров в корзине
    }
}
