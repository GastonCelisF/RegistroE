using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
    public class Estudiante
    {
        //propiedades que contienen los mismos nombres 
        //que en las columnas de la base de datos
        [PrimaryKey, Identity]
        public int id { set; get; }//tenemos que declara que este sera la keyprimary y que sera autoincrementable
        public string DNI { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Email { set; get; }

    }
}
