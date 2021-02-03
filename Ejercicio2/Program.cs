using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            //creo un objeto de tipo modelo y otro de tipo vista y los combino en el objeto controlador
            
            Modelo M1 = new Modelo();
            Vista V1 = new Vista();

            Controlador C1 = new Controlador(M1, V1);
        }
    }
}
