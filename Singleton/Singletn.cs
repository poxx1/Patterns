using System;

namespace Singleton
{
    public class Singletn
    {
        private static Singletn instance = null;
        public int Id { get; set; }
        private Singletn() { Id = new Random().Next(1, 1000);} //Evito new instances.
        public static Singletn Instance
        { 
            get 
            {
                if (instance == null)
                    instance = new Singletn();    
                return instance;
            }
        }
    }
}
