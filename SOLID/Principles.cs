namespace SOLID
{
    //Principles

    #region Single Responsability
    /*
     1. La clase tiene que tener una sola responsabilidad.
     2. Se centra en mantener alta cohesion.
     3. La funcionalidad debe estar ecapsulada completamente por la clase.
     */
    public class SingleResponsability
    {
        /*
         En este ejemplo podemos ver como las responsabilidades de cada clase son unicas.
         Si tuviera todos los metodos dentro de Car (wash y changeOil) tendria baja cohesion.
         Creando las otras clases y usando la herencia, genero alta cohesion.
         */
        public class Car
        {
            public string Owner { get; set; }

            public void StartEngine() { }
            public void MeasureOilLevel() { }
            public void StopEngine() { }
        }

        public class Lavadero:Car { 
            public void Wash(Car car) { } //Single responsability
        }

        public class Mechanic:Car {
            public void ChangeOil(Car car) { } //Single responsability
        }

    }
    #endregion

    #region Open/Close
    /*
     * Abierto para la extension, cerrado para la modificacion.
     * 
     1. El comportamiento de una entidad debe poder ser alterado sin tener que modificar su propio codigo fuente.
     2. Una clase no se puede modificar, pero si se puede extender usando la herencia.
     3. Una clase solo debe ser modificada si existe un error, para no romper modulos que dependan de ella.
     4. Se centra en mantener bajo acoplamiento.
     */
    public class OpenClose
    {
        // Sin OpenClose
        //Abierta para modificar y abierta para extender.
        public class CuentaBancaria1 {
            public int Tipo {get;set;}
            public float Saldo { get;set;}
            public string Numero {get;set;}

            public float ObtenerSaldo() { return 0; }
            public void Depositar() { }
            public void Extraer() { }
        }
        //############ Paso A >> ##################
        //Cuenta bancaria > Cerrada para modificar
        //Tipo Cuenta > Abierta para extender
        public class CuentaBancaria { 
            public float Saldo { get;set;}
            public string Numero { get;set;}
            
            public TipoCuenta tipoCuenta {get;set; } //Composicion
            public float ObtenerSaldo() { return 0; }
        }

        public class TipoCuenta {
            public void Extraer(float plata) { }
            public void Depositar(float plata) { }
        }

        public class CajaDeAhorro : TipoCuenta { } // Herencia
        public class CuentaCorriente : TipoCuenta { } // Herencia
        }
    #endregion

    #region Liskov Substitution
    /*
     1. Es una extencion del principio Open/Closed.
     2. Una clase derivada puede ser reemplazada por cualquier otra que use su clase base sin alterar
    el correcto funcionamiento de un programa
     3. Si una funcion espera como parametro una clase base, esta puede ser reemplazada por cualquier clase deribada.
     4. Una subclase no debe remover ni modificar comportamiento de la clase base, no debe conocer a los demas subtipos.
     5. Si un subtipo hace algo que el cliente del supertipo no espera, es una violacion del principio.
     */
    public class LiskovSubstitution
    {
        //Winamp sin reproducir video vs VLC y WINMdiaPlayer
    }
    #endregion

    #region Interface Segregation
    /*
     1. Los clientes no deben estar forzados a implementar interfaces que no usan.
     2. Guarda relacion con la cohesion de las aplicaciones.
     3. Las clases que implementen una interfaz o una clase abstracta no deberian estar obligadas a usar partes que no van a usar.
     4. Los clientes no deben estar obligados a implementar y/o depender de una interfaz que luego no usaran.
     */

    public class InterfaceSegregation
    {
        public class Proceso1
        {
            public void Start() { }
            public void Stop() { }
            public void Suspend() { }
            public void Resume() { }
        }

        public class Manual : Proceso1 { }; // Manual si quiere suspender, dado que la persona frena a comer.
        public class Automatico : Proceso1 { }; // Automatico no necesita suspender, porque no frena para comer.

        //Entonces tengo que "Segregar las interfaces"
        public interface IProcesoManual {
            void Suspend();
            void Resume();
        };

        public interface IProcesoAutomatico {
            void Start();
            void Stop();
        };
        //Aca separo y creo dos interfaces, una para cada proceso diferente.
        public class ProcesoManual:IProcesoManual {
            public void Suspend() { }
            public void Resume() { }
        }
        public class ProcesoAutomatico : IProcesoAutomatico {
            public void Start() { }
            public void Stop() { }
        }
    }
    #endregion

    #region Dependency Inversion
    /*
     1. Las clases de alto nivel no deberian depender de las clases de bajo nivel. Ambas deberian depender de las abstracciones.
     2. Se utiliza para desacoplar modulos de software.
     3. Las abstracciones no deberian depender de los detalles. Los detalles deberian depender de las abstracciones.
     4. Al diseniar la interracion entre un modulo de alto nivel y uno de bajo nivel, la interaccion debe considerarse como una interaccion abstracta entre ellos.
     */
    public class DependencyInversion
    {
        //El boton lo unico que hace es prender la lampara. Pero no puede prender otra cosa
        public class Boton1 { }
        public class Lamp1 {
            public void TurnOn(Boton1 boton) { }
            public void TurnOff(Boton1 boton) { }
        }

        //Lo que hago es crear una interfaz para cambiar la depedencia, y hacer que el boton pueda funcionar
        // para otros elementos.
        public class Button { }
        public interface ISwitch {
            void TurnOn(Button button);
            void TurnOff(Button button);
        }
        public class Lamp: ISwitch {
            public void TurnOn(Button button) { }
            public void TurnOff(Button button) { }
        }
    }
    #endregion
}