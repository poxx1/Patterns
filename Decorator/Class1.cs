using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Class1
    {
        /*
         Ejemplo de la maquina de cafe,
        Un cafe vale 10 pesos si es colombiano 12 si es argentino.
        Pero si le agregas leche, u otra cosa le tenes que sumar el precio.
         */

        public void Ejemplo1()
        {
            BebidaComponent cafe = new CafeExpresso();
            cafe = new Azucar(cafe);

            Console.ReadKey();

        }
        public class Azucar : AgregadoDecorator
        {
            public Azucar(BebidaComponent bebida) : base(bebida) { }
            public override double Costo => _bebida.Costo + 0.5;
            public override string Descripcion => string.Format($"{_bebida.Descripcion}, Azúcar");

        }
        public class CafeExpresso : BebidaComponent
        {
            public override double Costo => 12;
            public override string Descripcion => "Café expreso";
        }
        public class CafeSolo : BebidaComponent
        {
            public override double Costo => 10;
            public override string Descripcion => "Café solo";
        }

        public abstract class BebidaComponent
        {

            public abstract double Costo { get; }
            public abstract string Descripcion { get; }
        }
        public abstract class AgregadoDecorator : BebidaComponent
        {
            protected BebidaComponent _bebida;
            public AgregadoDecorator(BebidaComponent bebida)
            {
                _bebida = bebida;
            }


        }


    }
}
