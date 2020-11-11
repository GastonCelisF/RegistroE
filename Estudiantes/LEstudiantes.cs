using BA;
using Estudiantes.LibreriadeFotos;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudiantes
{
    //ahora todos los objetos creados en la clase libreria
    //pueden ser llamados en la clase estudiantes
    public class LEstudiantes 
    {
        //metodo constructor que recibe como parable un objeto de la clase list que contiene una coleecion de objetos de la clase textbox.
        // con el objeto creado para ser inciializado dentro del metodo constructor de la clase.
        private List<TextBox> listadeTxtBoxs;
        private List<Label> listadeLabels;
        private PictureBox Imagen;
        private Libreria liberia;
        public LEstudiantes(List<TextBox> listadeTxtBoxs, List<Label> listadeLabels, object[] objetoFotos)
        {
            this.listadeTxtBoxs = listadeTxtBoxs;
            this.listadeLabels = listadeLabels;
            liberia = new Libreria();
            Imagen = (PictureBox)objetoFotos[0];//convertimos un objeto ,en un objeto de la clase PictureBox
        }
        public void RegistradordeTextosVacios()
        {
            //si en la posicion 0 de la matris que seria txtDNI que esta en su propiedad TEXT
            //voy a verificar si es igual a vacio
            if (listadeTxtBoxs[0].Text.Equals(""))
            {
                //se insertara un texto de erro en el label correspondiente
                listadeLabels[0].Text = "DNI NO INGRESADO";
                //volvemos a usar la propiedad forecolor para cambiar de color la fuente del string(no olvidar siempre primero poner el llamado del using System.Drawing)
                listadeLabels[0].ForeColor = Color.Red;
                listadeTxtBoxs[0].Focus();

            }
            else
            {
                if (listadeTxtBoxs[1].Text.Equals(""))
                {
                    listadeLabels[1].Text = "APELLIDO NO INGRESADO";
                    listadeLabels[1].ForeColor = Color.Red;
                    listadeTxtBoxs[1].Focus();

                }
                else
                {
                    if (listadeTxtBoxs[2].Text.Equals(""))
                    {
                        listadeLabels[2].Text = "NOMBRE NO INGRESADO";
                        listadeLabels[2].ForeColor = Color.Red;
                        listadeTxtBoxs[2].Focus();

                    }
                    else
                    {
                        if (listadeTxtBoxs[3].Text.Equals(""))
                        {
                            listadeLabels[3].Text = "EMAIL NO INGRESADO";
                            listadeLabels[3].ForeColor = Color.Red;
                            listadeTxtBoxs[3].Focus();

                        }
                        else
                        {
                            if (liberia.validadorTxt.ValidadordeEmail(listadeTxtBoxs[3].Text))
                                //el metodo al recibir como parametro un dato de tipo string,tenemos que llamarlo desde el lugar correspondiente de la matriz
                            {
                                var ArrayImagen = liberia.cargadefotos.ImageToByte(Imagen.Image);
                                //.image es la propiedad que nos devolvera un objeto de la clase imagen
                                //almacenaremos la informacion en un array  porque recibiremos un array de la imagen

                                using (var db = new Conexiones())
                                {
                                    db.Insert(new Estudiante()
                                    //insertamos datos en la base de datos. a traves del siguiente metodo que viene de la clase insert.que viene de la libreria dataconexion(linqdb)
                                    {
                                        DNI = listadeTxtBoxs[0].Text,
                                        Nombre = listadeTxtBoxs[1].Text,
                                        Apellido = listadeTxtBoxs[2].Text,
                                        Email = listadeTxtBoxs[3].Text
                                    });
                                }
                                   
                            }
                            else
                            {
                                listadeLabels[3].Text = "EL EMAIL NO ES VALIDO";
                                listadeLabels[3].ForeColor = Color.Red;
                                listadeTxtBoxs[3].Focus();

                            }
                        }
                       
                    }
                    
                }
            }
        }

    }
}
