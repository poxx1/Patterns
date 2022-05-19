using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FactoryMethod;
using Composite;
using Singleton;
using Observer;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. Factory Method
            //Ejemplo 1.
            //var factoryMethod = new FactoryMethod.Ejemplos();
            //factoryMethod.Ejemplo2();
            #endregion

            #region 2. Observer
            //var observer = new Observer.Ejemplos();
            //observer.Ejemplo1();
            #endregion

            #region 3. Composite
            var composite = new Composit.Ejemplos();
            composite.Ejemplo1();
            #endregion

            Console.ReadKey();
        }
    }
}
