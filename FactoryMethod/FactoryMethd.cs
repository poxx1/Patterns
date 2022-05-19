using System;

namespace FactoryMethod
{
    /* 
     1. Define una interfaz para crear un objeto, pero deja que sean las subclases quienes decidan que clase instancia.
     2. Permite a una clase delegar en sus subclases la creacion de objetos.
     */
    public class Ejemplos
    {
        public void Ejemplo1()
        {
            Pizzeria pizzeria;
            Pizza pizza;
            pizzeria = new PizzeriaArgentina();
            pizza = new Pizza();

            pizza = pizzeria.CrearPizza("Margherita");
            pizza.CSOutput();
            pizza = pizzeria.CrearPizza("Napolitana");
            pizza.CSOutput();
        }

        public void Ejemplo2() {
            Maquina maquina;
            Fabrica fabrica;

            fabrica = new FabricaSommer();
            maquina = fabrica.FabricarMaquina("TIG");
            maquina.CSOutput();
            maquina = fabrica.FabricarMaquina("MIG");
            maquina.CSOutput();
        }
    }

    #region Ejemplo 1. Pizzeria
    public class Pizza
    {
        protected string _descripcion;
        protected string _origen;

        public void CSOutput()
        {
            Console.WriteLine($"Pizza de {_descripcion}, hecha en {_origen}");
        }
    }
    public abstract class Pizzeria {
        public abstract Pizza CrearPizza(string tipo);
    }
    public class PizzaMargherita : Pizza{
        public PizzaMargherita(string Origen)
        {
            _descripcion = "Margherita";
            _origen = Origen;
        }
    }
    public class PizzaNapolitana : Pizza{
        public PizzaNapolitana(string Origen)
        {
            _descripcion = "Napolitana";
            _origen = Origen;
        }
    }
    public class PizzeriaArgentina : Pizzeria
    {
        public override Pizza CrearPizza(string tipo)
        {
            if (tipo == "Margherita") return new PizzaMargherita("Argentina");
            else if (tipo == "Napolitana") return new PizzaNapolitana("Argentina");
            else { return null; }
        }
    }
    public class PizzeriaItaliana : Pizzeria 
    {
        public override Pizza CrearPizza(string tipo)
        {
            if (tipo == "Margherita") return new PizzaMargherita("Italiana");
            else if (tipo == "Napolitana") return new PizzaNapolitana("Italiana");
            else { return null; }
        }
    }
    #endregion

    #region Ejemplo 2. Maquinas de Soldar
    public abstract class Fabrica {
        public abstract Maquina FabricarMaquina(string tipo);
    }
    public class FabricaSommer : Fabrica {
        public override Maquina FabricarMaquina(string tipo)
        {
            if (tipo == "MIG") return new MaquinaMIG("Sommer");
            else if (tipo == "TIG") return new MaquinaTIG("Sommer");
            else return null;
        }
    }
    public class FabricaLusqtoff : Fabrica {
        public override Maquina FabricarMaquina(string tipo)
        {
            if (tipo == "MIG") return new MaquinaMIG("Lusqtoff");
            else if (tipo == "TIG") return new MaquinaTIG("Lusqtoff");
            else return null;
        }
    }
    public class Maquina
    {
        protected string _marca;
        protected string _tipo;
        public void CSOutput() 
        { 
            Console.WriteLine($"La maquina {_tipo}, fue creada por {_marca}");
        }
    }
    public class MaquinaMIG : Maquina { 
        public MaquinaMIG(string fabrica)
        {
            _marca = fabrica;
            _tipo = "MIG";
        }
    }
    public class MaquinaTIG : Maquina {
        public MaquinaTIG(string fabrica)
        {
            _marca = fabrica;
            _tipo = "TIG";
        }
    }
    #endregion
}
