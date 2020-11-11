using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudiantes.LibreriadeFotos
{
    public class Libreria
    {
        //TODO: ver herencia multiple (donde una clase puede heredar mas de un metodo de otra clase)
        //clase dedicada a creacion de objetos de las clases.
        public CargadeFotos cargadefotos = new CargadeFotos();
        public ValidadorTxt validadorTxt = new ValidadorTxt();


    }   
}
