using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    /*
     Representar el estado de un objeto para despues poder volver al mismo estado mas tarde.
     */

    public class Ejemplos
    {
        static CareTaker careTaker = new CareTaker();
        #region Ejemplo1
        public void Ejemplo1()
        {
            var p = new Persona();
            p.Nombre = "Julian";
            Console.Write(p.Nombre);
            careTaker.Add(p.saveToMemento());
            p.Nombre = "Jose";
            Console.Write(p.Nombre);
            Memento1 memento = careTaker.GetMemento1(0);
            p.restoreToMemento(memento);
            Console.Write(p.Nombre);
        }

        public class Memento1 
        {
            private string _estado;
            public Memento1()
            {

            }
            public Memento1(string estado)
            {
                _estado = estado;
            }

            public string Estado { get { return _estado; } }
        }
        public class Persona
        {
            public string Nombre { get; set; }

            public Memento1 saveToMemento()
            {
                Console.WriteLine($"Originator: Guardo el memento de : {Nombre}");
                return new Memento1(Nombre);
            }
            public void restoreToMemento(Memento1 memento)
            {
                Nombre = memento.Estado;
                Console.WriteLine($"Originator: Recupero el memento de : {Nombre}");
            }
        }
        public class CareTaker 
        { 
            private List<Memento1> _list = new List<Memento1>();

            public void Add(Memento1 m)
            {
                _list.Add(m);
            }
            public Memento1 GetMemento1(int index) { return _list[index]; }
        }
        #endregion
    }
}
