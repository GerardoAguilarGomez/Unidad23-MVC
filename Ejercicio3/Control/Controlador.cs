using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Controlador
    {
        //clase controlador

        //atributos objeto modelo y objeto vista
        private Modelo modelo;
        private Vista vista;

        //creo el constructor y lanzo el metodo seleccion (abre el menu)
        public Controlador(Modelo mod, Vista vis)
        {
            this.modelo = mod;
            this.vista = vis;
            seleccion();
        }

        //metodo que va a ejecutar la rutina de la app
        public void seleccion()
        {
            bool continuar = true;

            while (continuar == true) //mientras no diga que no quiere continuar vuelve a lanzar el menú
            {
                vista.Menu(); //abre el metodo menu de la vista
                string opcion = Console.ReadLine(); //guardo la respuesta

                switch (opcion) //voy a cada apartado dependiendo de la respuesta
                {
                    case "1":
                        modelo.Insertar(); //llamo al modelo con su metodo para que coja la sentencia que quiero
                        vista.ConfirmarAccion(modelo.Comando, modelo.Conexion); //en la vista pinto la confirmación
                        break;
                    case "2":
                        modelo.SelectCientificos();//llamo al modelo con su metodo para que coja la sentencia que quiero
                        vista.PintarRegistros(modelo.Comando, modelo.Conexion);//en la vista pinto la select
                        modelo.SelectProyectos();
                        vista.PintarRegistros(modelo.Comando, modelo.Conexion);//en la vista pinto la select
                        modelo.SelectAsignar();
                        vista.PintarRegistros(modelo.Comando, modelo.Conexion);//en la vista pinto la select
                        break;
                    case "3":
                        modelo.Actualizar();//llamo al modelo con su metodo para que coja la sentencia que quiero
                        vista.ConfirmarAccion(modelo.Comando, modelo.Conexion);//en la vista pinto la confirmación
                        break;
                    case "4":
                        modelo.Borrar();//llamo al modelo con su metodo para que coja la sentencia que quiero
                        vista.ConfirmarAccion(modelo.Comando, modelo.Conexion);//en la vista pinto la confirmación
                        break;
                    case "5":
                        Environment.Exit(1);
                        break;
                    default:
                        break;
                }

                vista.Continuar(); //para que haga la pregunta de continuar
                string opcion_continuar = Console.ReadLine(); //capturo respuesta

                if (opcion_continuar == "2")//hasta que no indique 2 seguirá haciendo el while
                {
                    continuar = false;
                }
            }

        }
    }
}
