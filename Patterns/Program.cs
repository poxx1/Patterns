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
#if DEBUG
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
            //var composite = new Composit.Ejemplos();
            //composite.Ejemplo1();
            #endregion

            #region 4. Singleton
            //var singleton = new Singleton.Ejemplos();
            //singleton.Ejemplo1();
            #endregion

            #region 5. Memento
            var memento = new Memento.Ejemplos();
            memento.Ejemplo1();
            #endregion
            Console.ReadKey();
         #endif
        }
    }
}
