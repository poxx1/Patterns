using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Adaptr
    {
        /*
         Motor naftero vs Electrico

        Motor expone 4 cosas, Acelerar, arrancar, apagar y frenar.
        El electrico no apaga igual que un naftero, hace otras cosas.
        Entonces creo un Adapter que tome los 4 metodos y a dentro de las 
        implementaciones le genero la logica para que haga lo mismo, pero tomando
        en cuenta los usos del motor naftero.
        Para apagar, primero tengo que desactivar el motor y despues lo puedo activar

        entonces motor.Apagar() va  a tener {Motor.Desactivar; Motor.Apagar()};
        Eso el cliente no lo ve, expone solo lo smetodos que usa.
        El adaptee tiene la logica adentro.
         */
    }
}
