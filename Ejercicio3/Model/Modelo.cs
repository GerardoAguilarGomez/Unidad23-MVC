using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ejercicio3
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
            ConexionEjecutar("insert into Cientifico (Dni,NomApels) values ('11111111','Luis Martinez')");
            ConexionEjecutar("insert into Cientifico (Dni,NomApels) values ('22222222','Pilar Alegría')");
            ConexionEjecutar("insert into Cientifico (Dni,NomApels) values ('33333333','Pedro ´Marín')");

            ConexionEjecutar("insert into Proyecto (Id,Nombre,Horas) values ('0001','Proyecto 1',5)");
            ConexionEjecutar("insert into Proyecto (Id,Nombre,Horas) values ('0002','Proyecto 2',11)");
            ConexionEjecutar("insert into Proyecto (Id,Nombre,Horas) values ('0003','Proyecto 3',7)");

            ConexionEjecutar("insert into Asignado_A (Cientifico,Proyecto) values ('11111111','0003')");
            ConexionEjecutar("insert into Asignado_A (Cientifico,Proyecto) values ('22222222','0002')");
            ConexionEjecutar("insert into Asignado_A (Cientifico,Proyecto) values ('33333333','0001')");
        }


        //metodo para visualizar registros, que llama al metodo conexionejecutar
        public void SelectCientificos()
        {
            ConexionEjecutar("Select * from Cientifico");
        }

        public void SelectProyectos()
        {
            ConexionEjecutar("Select * from Proyecto");
        }

        public void SelectAsignar()
        {
            ConexionEjecutar("Select * from Asignado_A");
        }

        //metodo para actualizar registros, que llama al metodo conexionejecutar
        public void Actualizar()
        {
            ConexionEjecutar("update Cientifico set NomApels='Cientifico ' + Dni");
            ConexionEjecutar("update Proyecto set Nombre='Proyecto ' + Id");
        }

        //metodo para borrar registros, que llama al metodo conexionejecutar
        public void Borrar()
        {
            ConexionEjecutar("DELETE FROM Asignado_A");
            ConexionEjecutar("Delete from Cientifico");
            ConexionEjecutar("Delete from Proyecto");
        }
    }
}
