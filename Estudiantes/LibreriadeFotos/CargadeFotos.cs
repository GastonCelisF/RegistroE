using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudiantes.LibreriadeFotos
{
    public class CargadeFotos
    {
        private OpenFileDialog Foto = new OpenFileDialog();

        //creacion del metodo cargar imagen que pasara por parametro el objeto en mi picturebox
        public void CargarImagen(PictureBox pictureBox) 
        {
            //WaitOnload es una propiedad  que si esta en true carga de forma remota la imagen.
            pictureBox.WaitOnLoad = true;
            //le indicamos al picturebox que imagenes va a filtrar por medio de que extensiones.
            Foto.Filter = "imagenes|*.jpg;*.gif;*.png;*.bmp";
            Foto.ShowDialog();
            //Verificamos si el picturebox esta vacio
            if (Foto.FileName != string.Empty)
            {
                //si es diferente a vacio nos dara la ubicacion de donde se encuentra nuesta imagen
                //en el escritorio de la PC
                pictureBox.ImageLocation = Foto.FileName;
            }
        }
        public byte[] ImageToByte(Image img) 
        { //implementacion de lcase image a traves del using drawing
            //para poder pasar nuestra imagen a valor byte
            ImageConverter Convertidor = new ImageConverter();
            //retornamos un valor byte de la creacion del array. recibiendo un objeto(que es la imagen)
            return (byte[])Convertidor.ConvertTo(img, typeof(byte[]));
            //creamos nuestro array, invocamos al objeto convertidor,utilizamos el metodo ConvertTo(recibe dos parabmetros un objeto y el siguiente parametro
            //que es el destino del objeto imagen , ademas especificamos que lo vamos a retornar en tipo byte.
        }
    }
}
