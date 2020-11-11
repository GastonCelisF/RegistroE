using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
    public class Conexiones : DataConnection
    {
        public Conexiones() : base("CONEXION1") { }
        public ITable<Estudiante> _Estudiante { get { return GetTable<Estudiante>(); } }
        //Linq verifica si en la base de datos hay una tabla con el nombre CONEXION1 si la hay se vinculara.
        //al hacer la relacion con el objeto _Estudiante podremos, obtener,insertar y actualizar datos en las tablas
    }
}
