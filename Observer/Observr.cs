using System;
using System.Collections.Generic;

namespace Observer
{
    /*
     1. Define una dependencia 1* entre objetos, de forma que cuando un objt cambie de estado se notifique, y
    se actualicen automaticamente todos los objetos que dependan de el.
     */
    #region Ejemplos
    public class Ejemplos
    {
        public void Ejemplo1() 
        {
            var product = new Product("Papa", 10);
            var user = new User("Julian");
            product.Subscribe(user);
            product.Price = 12; 
            product.Unsubscribe(user);
            product.Price = 13; //Inflacion
        }
    }

    #endregion

    #region Ejemplo 1. Usuarios
    public interface ISubscribe
    {
        void Subscribe(IObserbableUser user);
        void Unsubscribe(IObserbableUser user);
        void Notify();
    }

    public interface IObserbableUser 
    {
        void Update(Product product); // Lo que hago al momento de actualizar
    }
    public class Product : ISubscribe
    {
        private decimal _price { get; set; }
        public decimal Price { get { return _price; } set { _price = value; this.Notify(); } }
        private string Name { get; set; }
        private List<IObserbableUser> _users;

        public Product(string name, decimal price)
        {
            _users = new List<IObserbableUser>();
            Name = name;
            _price = price;
        }

        public void Subscribe(IObserbableUser user)
        {
            if (!_users.Contains(user))
            {
                _users.Add(user);
                Console.WriteLine($"{user.ToString()} has been addded to the list");
            }
            else Console.WriteLine("The user is alredy subscribed, loser!");
        }
        public void Unsubscribe(IObserbableUser user)
        {
            if (_users.Contains(user))
            {
                _users.Remove(user);
                Console.WriteLine($"{user.ToString()} has been removed from the list");
            }
            else Console.WriteLine("The user was not subscribed, loser!");
        }
        public void Notify() 
        {
            if (_users.Count > 0)
            {
                foreach (var user in _users) { user.Update(this);}
            }
            else Console.WriteLine("The list of users is empty. No one is subscribed!");
        }
    }
    public class User : IObserbableUser
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name.ToString();
        }
        public User(string name) { Name = name;}

        void IObserbableUser.Update(Product product)
        {
            Console.WriteLine($"{this.Name} has been updated about the product {product.Price}.");
        }
    }
    #endregion
}
