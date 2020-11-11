using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudiantes.LibreriadeFotos
{
    public class ValidadorTxt
    {
        //metodo que no retorna nada pero recibe el parametro keypress 
        public void textKeyPress(KeyPressEventArgs evento)
        {
            //condicion que solo nos permite ingresar datos string
            // uso false para poder pemitirle ingresar el dato en el txt (siempre y cuando dicho dato sea CHAR)
            // al ser un valor un valor falso keychar permitira digitar el valor que se ingrese por el txt en este caso uno tipo CHAR
            if (char.IsLetter(evento.KeyChar))
            {
                evento.Handled = false;

            }//bien ahora ya validado nuestro caracter usaremos este else if para que el usuario no use enter y causar posible errores de programa o saltos de linea.
            // {Keys} convierte en propiedad un boton, en este caso la tecla ENTER, lo convertimos  a tipo CHAR y lo comporamos con lo que se ingreso
            // si enter en su propiedad CHAR igual a evento.key sera true evitando que se ejecuto el salto de linea.
            else if (evento.KeyChar == Convert.ToChar(Keys.Enter))
            {
                evento.Handled = true;
            }//utilizamos otro else if para poder eliminar caracteres
            else if (char.IsControl(evento.KeyChar))
            {
                evento.Handled = false;
            }//condicion que nos permite utilizar la barra espaciadora
            else if (char.IsSeparator(evento.KeyChar))
            {
                evento.Handled = true;
            }
            else//si el usuario esta ingresando un valor que no sea ninguno de los anteriores no podra ingresarlo.
            {
                evento.Handled = true;
            }


        }
        public void ValidadordeNumero(KeyPressEventArgs digito)
        {
            //condion que permite la digitacion de nuemeros.
            //si el valor ingresado por char es un digito se le asignara el valor de falso y se podra digitar en el txt
            if (char.IsDigit(digito.KeyChar))
            {
                digito.Handled = false;
            }//condicion para que no se ejecuten saltos de lineas.
            else if (digito.KeyChar == Convert.ToChar(Keys.Enter))
            {
                digito.Handled = true;
            }//condicion que no permite ingresar datos de tipo string.
            else if (char.IsLetter(digito.KeyChar))
            {
                digito.Handled = true;
            }//condicion para permitir el uso del boton retroceso(borrar strings).
            else if (char.IsControl(digito.KeyChar))
            {
                digito.Handled = false;
            }//condicion que permite el uso de la barra espaciadora
            // tambien se le podria negar el ingreso de espacios otorgandole le valor de true.por temas de interfaz creo que espacios seria mejor
            else if (char.IsSeparator(digito.KeyChar))
            {
                digito.Handled = false;
            }
            else//si el usuario digita un valor diferente a los anterior se negaran.
            {
                digito.Handled = true;
            }

           
        }
        //validador de EMAIL
        public bool ValidadordeEmail(string email)
        {
            //este metodo que recibira como parametro un dato tipo string y devolvera un valor tipo BOOL.
            // añadiremos System.ComponentModel.DataAnnotations para validar los emails.
            //si el email es validod retornara un valor verdadero gracias al metodo IsValid.
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
