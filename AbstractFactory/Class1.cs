using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /*
     Cuando tengo que agregar nuevas familias de productos.
    Pero la caga cuando tiene que agregar nuevos objetos/productos

    Proposito:
    Crear una interfaz para crear familias de objetos relacionados que dependen entre si, sin especificar
    sus clases concretas.

    Uso:
    Un sistema tiene que ser independiente de como se crean, componenen y representan sus productos.
     */
    public class Class1
    {
        public void Ejemplo1()
        {
            Pizzeria fabrica;
            fabrica = new PizzeriaArgentina();

            Empanada empanada = fabrica.CrearEmpanada();
            Console.WriteLine($"Empanada: {empanada.Descripcion}");

            Console.ReadKey();
        }
        public abstract class Pizza
        {
            protected string _descripcion;

            public object Descripcion
            {
                get
                {
                    return _descripcion;
                }
            }
        }
        public abstract class Empanada
        {
            protected string _descripcion;
            public string Descripcion
            {
                get
                {
                    return _descripcion;
                }
            }
        }
        public class EmpanadaDeCarne : Empanada
        {
            public EmpanadaDeCarne()
            {
                _descripcion = "Empanada de carne";
            }
        }
        public class PizzeriaArgentina : Pizzeria
        {
            public override Empanada CrearEmpanada()
            {
                return new EmpanadaDeCarne();
            }
        }
        public abstract class Pizzeria
        {
            public abstract Empanada CrearEmpanada();
        }

    }
}
