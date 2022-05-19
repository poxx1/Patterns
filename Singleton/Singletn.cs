using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /*
    Singleton es un patrón de diseño creacional que nos permite asegurarnos de que una clase tenga una única instancia,
    a la vez que proporciona un punto de acceso global a dicha instancia.

    Garantizar que una clase tenga una única instancia. ¿Por qué querría alguien controlar cuántas instancias tiene una 
    clase? El motivo más habitual es controlar el acceso a algún recurso compartido, por ejemplo, una base de datos o 
    un archivo.

    Al igual que una variable global, el patrón Singleton nos permite acceder a un objeto desde cualquier parte del 
    programa. No obstante, también evita que otro código sobreescriba esa instancia.

    */
    public class Ejemplos
    {
        #region Ejemplo 1 Usuario
        public void Ejemplo1()
        {
            Console.WriteLine("Singleton");
            Console.WriteLine("Logging in User");
            var usr = new User();
            usr.Name = "Julian";
            usr.Password = "asd";
            SessionManager.Login(usr);
            try { SessionManager.Login(usr); } catch (Exception ex) { } //Ya esta logueado
            Console.WriteLine(usr.Name);
            SessionManager.Logout(usr);
            try { SessionManager.Logout(usr); } catch (Exception ex) { } //No hay nadie logueado
            //SessionManager session = new SessionManager.GetInstance;
        }
            public class User
            {
                public string Name { get; set; }
                public string Password { get; set; }
        }
        public class SessionManager
        {
            private static SessionManager instance; //Instancia static
            private SessionManager()//Constructor privado
            {

            }
            public User user { get; set; }
            public static SessionManager GetInstance
            {
                get
                {
                    if (instance == null) instance = new SessionManager();
                    return instance;
                }
            }
            public static void Login(User user)
            {
                if (instance == null)
                {
                    instance = new SessionManager();
                    instance.user = user;
                }
                else throw new Exception("Ya esta logueado");
            }
            public static void Logout(User user)
            {
                if (instance != null)
                {
                    instance = null;
                }
                else throw new Exception("No esta logueado");
            }
        }
        #endregion
    }
}