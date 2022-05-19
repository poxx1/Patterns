using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Composit
    {
        #region Ejemplos
        public class Ejemplos
        {
            public void Ejemplo1()
            {
                Componente root = new Directorio("root");
                Componente dir1 = new Directorio("dir1");
                Componente dir2 = new Directorio("dir2");

                Componente archivo1 = new Archivo("file1.txt", 10);
                Componente archivo2 = new Archivo("file2.txt", 120);
                Componente archivo3 = new Archivo("file3.txt", 20);

                root.AgregarHijo(dir1);
                root.AgregarHijo(dir2);

                dir1.AgregarHijo(archivo1);

                dir2.AgregarHijo(archivo2);
                dir2.AgregarHijo(archivo3);

                Console.WriteLine($"El dir {root.Nombre} tiene como hijos {root.ObtenerHijos().Count} directorios.");
                dir1.ObtenerHijos();
                dir2.ObtenerHijos();
            }
        }
        #endregion

        #region Ejemplo1
        public abstract class Componente
        {
            private string _nombre;

            public Componente(string nombre)
            {
                _nombre = nombre;
            }

            public string Nombre { get { return _nombre; } }
            public abstract void AgregarHijo(Componente componente);
            public abstract IList<Componente> ObtenerHijos();
            public abstract int ObtenerCapacidad { get; }
        }
        public class Directorio : Componente
        {
            private List<Componente> _hijos;
            public Directorio(string nombre) : base(nombre) //Base se lo envia a la clase Base >> osea Componente
            {
                _hijos = new List<Componente>();
            }

            public override int ObtenerCapacidad
            {
                get
                {
                    int t = 0; //Capacidad de los hijos

                    foreach (var hijo in _hijos)
                    {
                        t += hijo.ObtenerCapacidad;
                    }
                    return t;
                }
            }
            public override void AgregarHijo(Componente componente)
            {
                _hijos.Add(componente);
            }

            public override IList<Componente> ObtenerHijos()
            {
                return _hijos.ToArray();
            }
        }
        public class Archivo : Componente
        {
            //No implemento Hijos
            //Violo el principio de Liskov substitucion (segun Battaglia es segregacion de Interfaces).
            int _capacidad;
            public int capacidad { get { return _capacidad; } }
            public Archivo(string nombre, int capacidad) : base(nombre) //Usa el constructor de la clase Componente
            {
                _capacidad = capacidad;
            }
            public override int ObtenerCapacidad
            {
                get
                {
                    return capacidad;
                }
            }
            public override void AgregarHijo(Componente componente){}
            public override IList<Componente> ObtenerHijos()
            {
                return null; //Al no tener hijos, nunca voy a poder debolver uno.
            }
        }
        #endregion
    }
}
