using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ejercicio2
{
    class Vista
    {
        //clase vista
        public void Menu() //pinto el menú
        {
            Console.WriteLine("----- BIENVENIDO APP CRUD 2 -----");
            Console.WriteLine();
            Console.WriteLine("Selecciona la opción que deseas: \n" +
                " 1 - Insertar \n" +
                " 2 - Mostrar \n" +
                " 3 - Actualizar \n" +
                " 4 - Eliminar \n" +
                " 5 - Salir \n");
        }

        public void Continuar() //pinto el menú de si quiere continuar
        {
            Console.WriteLine();
            Console.WriteLine("Deseas realizar alguna operación más: 1 - Si | 2 - No");
        }

        public void ConfirmarAccion(SqlCommand comando, SqlConnection conexion) //devuelvo que ha ejecutado la sentencia
        {
            Console.WriteLine("Operacion realizada");
        }
        public void PintarRegistros(SqlCommand comando, SqlConnection conexion) // pinto los registros
        {
            conexion.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetValue(i) + " - ");
                    }
                    Console.WriteLine();

                }
                Console.WriteLine();
                conexion.Close();
            }
        }
    }
}
