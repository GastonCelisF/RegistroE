using Estudiantes;
using Estudiantes.LibreriadeFotos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEstudiantes
{
    public partial class Form1 : Form
    {

        private LEstudiantes estudiante;
        private Libreria liberia;
        public Form1()
        {
            InitializeComponent();


            liberia = new Libreria();//objeto libreria para contener datos en la base de datos

           //creacion de la lista donde se guardaran los txt.
           //todos los elementos seran utilizados dentro de la clase estudiante
           var listadeTxtBoxs = new List<TextBox>();
            listadeTxtBoxs.Add(txtDNI);
            listadeTxtBoxs.Add(txtNombre);
            listadeTxtBoxs.Add(txtApellido);
            listadeTxtBoxs.Add(txtEmail);
          
            //lista de labels de la interfaz de usuario (la neceisto para la clase estudiante)
            var listadeLabels = new List<Label>();
            listadeLabels.Add(lblDNI);
            listadeLabels.Add(lblApellido);
            listadeLabels.Add(lblNombre);
            listadeLabels.Add(lblEmail);
            Object[] objetoFotos = {pboxFoto};

            //collecciones de objetos (lista de txt's y de label's y array del pictureBox) a la clase estudiante.
            //parametros que recibira el metodo constructor
            estudiante = new LEstudiantes(listadeTxtBoxs, listadeLabels, objetoFotos);

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pboxFoto_Click(object sender, EventArgs e)
        {
            //carga de la imagen
            //primer prueba de metodos con cargadefotos
            liberia.cargadefotos.CargarImagen(pboxFoto);
        }
        #region Eventos
        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            //validar contenido de datos.
            //si nuestro txt se encuentra vacio,no cambiara de color nuestro lbl
            if (txtDNI.Text.Equals(""))
            {

                lblDNI.ForeColor = Color.DarkCyan;
            }
            else //si introducimos datos cambiara a color azul.
            {
                lblDNI.ForeColor = Color.YellowGreen;
                lblDNI.Text = "DNI:";
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            //con el objeto estudiante en la clase validador y llamando al metodo validadordenumeros aplicado al objeto e.
            liberia.validadorTxt.ValidadordeNumero(e);   
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            //validar contenido de datos.
            //si nuestro txt se encuentra vacio,no cambiara de color nuestro lbl
            if (txtApellido.Text.Equals(""))
            {

                lblApellido.ForeColor = Color.DarkCyan;
            }
            else //si introducimos datos cambiara a color azul.
            {
                lblApellido.ForeColor = Color.YellowGreen;
                lblApellido.Text = "Apellido:";
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            liberia.validadorTxt.textKeyPress(e);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            //validar contenido de datos.
            //si nuestro txt se encuentra vacio,no cambiara de color nuestro lbl
            if (txtNombre.Text.Equals(""))
            {

                lblNombre.ForeColor = Color.DarkCyan;
            }
            else //si introducimos datos cambiara a color amarillo.
            {
                lblNombre.ForeColor = Color.YellowGreen;
                lblNombre.Text = "Nombre:";
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //al recibir como parametro un objeto de la siguiente clase keypresseventargs
            // hay que pasarle el objeto e 
            //ahora solo ingresaran valos TIPO CHAR EXCLUSIVAMENTE en este txt.
            liberia.validadorTxt.textKeyPress(e);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            //validar contenido de datos.
            //si nuestro txt se encuentra vacio,no cambiara de color nuestro lbl
            if (txtEmail.Text.Equals(""))
            {

                lblEmail.ForeColor = Color.DarkCyan;
            }
            else //si introducimos datos cambiara a color Amarillo.
            {
                lblEmail.ForeColor = Color.YellowGreen;
                lblEmail.Text = "Email:";
            }
        }

      
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            estudiante.RegistradordeTextosVacios();
        }
    }
}
