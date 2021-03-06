﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ejercicio2
{
    class Modelo
    {
        // clase modelo

        SqlConnection conexion = new SqlConnection("Data Source=192.168.1.49;Initial Catalog=UD22;Persist Security Info=True;User ID=root;Password=NvEPtJ&kxkWhmc21f#"); 
        SqlCommand comando = new SqlCommand();
        //creo como atributos la conexión y el comando a ejecutar

        //constructores
        public SqlConnection Conexion { get => conexion; set => conexion = value; }
        public SqlCommand Comando { get => comando; set => comando = value; }

        //metodo que crea un comando a partir de la sentencia que le paso como parametro y la conexión
        public void ConexionLeer(string cadena)
        {
            comando = new SqlCommand(cadena, conexion);
        }

        public void ConexionEjecutar(string cadena)
        {
            comando = new SqlCommand(cadena, conexion);

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        //metodo para insertar registros, que llama al metodo conexionejecutar
        public void Insertar()
        {
            ConexionEjecutar("Insert into CLIENTE (nombre,apellido,direccion,dni,fecha) values ('Gerardo','Aguilar','Calle...','77777777',GETDATE())");
            ConexionEjecutar("Insert into CLIENTE (nombre,apellido,direccion,dni,fecha) values ('Lucia','Aguilar','Calle...','33333333',GETDATE())");
            ConexionEjecutar("INSERT INTO Videos VALUES ('Punto Red','Jose Marinero',949)");
            ConexionEjecutar("INSERT INTO Videos VALUES('Boot Can', 'Jalorin Fernando',950)");
        }


        //metodo para visualizar registros, que llama al metodo conexionejecutar
        public void SelectCliente()
        {
            ConexionEjecutar("Select * from CLIENTE");
        }

        public void SelectVideo()
        {
            ConexionEjecutar("Select * from Videos");
        }

        //metodo para actualizar registros, que llama al metodo conexionejecutar
        public void Actualizar()
        {
            ConexionEjecutar("update CLIENTE SET fecha=GETDATE() from CLIENTE");
            ConexionEjecutar("UPDATE Videos SET director = 'Malcom Ride'");
        }

        //metodo para borrar registros, que llama al metodo conexionejecutar
        public void Borrar()
        {
            ConexionEjecutar("delete from CLIENTE");
            ConexionEjecutar("delete from Videos");
        }
    }
}
