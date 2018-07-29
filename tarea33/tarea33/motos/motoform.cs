using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tarea33.motos;

namespace tarea33.motos
{
    public partial class motoform : Form
    {
        Lista l = new Lista();
        public motoform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validaciones())
            { //Si las validaciones fueron exitosas se ejecuta el método crearmoto()
                crearmoto();
                limpiar();
            }
           
        }


        public void crearmoto()
        {
            bool existe = false;
            try
            {
               
                //Se crea un objeto de la clase moto 
                moto m = new moto(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox6.Text.Trim(), textBox7.Text.Trim(), "moto", textBox4.Text.Trim());

                using (var ent = new tarea3Entities2())
                {
                    IQueryable<Moto> motosquery = from Moto in ent.Motoes //IQueryable<Auto> sirve para hacer una consulta a la base de datos
                                                                         //y devuelve una lista de todos los registros en este caso la tabla Moto
                                                  select Moto;

                    foreach (Moto ahu in motosquery)
                    {
                        if (ahu.Placa == textBox1.Text.Trim())
                        {
                            existe = true;
                            //Se recorre el objeto motosquery para validar si la placa en el cuadro de texto de placa ya existe

                        }


                    }

                    if (existe)
                    { //Si la placa ya existe se arroja un mensaje en pantalla indicandolo
                        MessageBox.Show("El proceso no se pudo realizar debido a que este número de placa ya existe", "Solicitud no procesada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       

                    }
                    else
                    { //Si la placa no existe se ingresa en la lista el objeto moto y seguidamente se ingresa en la base de datos de azure obteniendo
                      //la última posición de la lista que se acaba de ingresar
                        Lista.lista.Add(m);
                        Moto au = new Moto()
                        {

                            Placa = Lista.lista.Last().Placa,
                            Marca = Lista.lista.Last().Marca,
                            Color = Lista.lista.Last().Color,
                            NombreCliente = Lista.lista.Last().Nombrecliente,
                            TelefonoCliente = Lista.lista.Last().Telefonocliente,
                            Tipo = Lista.lista.Last().Tipo,
                            Categoria = Lista.lista.Last().Categoria
                        };
                        ent.Motoes.Add(au);
                        ent.SaveChanges();
                        MessageBox.Show("El proceso se realizó correctamente", "Solicitud procesada", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }

                }
            }


            catch (ArgumentNullException efn)
            {
                MessageBox.Show(efn.ToString(), efn.TargetSite.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Excepcion que se produce cuando se pasa una referencia nula
            }
            catch (NullReferenceException exce)
            {
                MessageBox.Show(exce.ToString(), exce.TargetSite.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Excepcion que se produce cuando se intenta desreferenciar un objeto null

            }
            catch (ArgumentException age)
            {
                MessageBox.Show(age.ToString(), age.TargetSite.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Excepcion que se produce cuando no es válido uno de los argumentos proporcionados para un método

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), e.TargetSite.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Representa los errores que se producen durante la ejecución de una aplicación

            }




        }

        private void motoform_Load(object sender, EventArgs e)
        {

        }


        private bool placa()
        {
            //Método que retorna  un valor verdader si la longitud de la cadena en el cudro de texto es mayor a 0 de lo contrario devuelve valor falso
            return (textBox1.Text.Length > 0);
        }
        private bool marca()
        {
            //Método que retorna  un valor verdader si la longitud de la cadena en el cudro de texto es mayor a 0 de lo contrario devuelve valor falso
            return (textBox2.Text.Length > 0);
        }
        private bool color()
        {
            //Método que retorna  un valor verdader si la longitud de la cadena en el cudro de texto es mayor a 0 de lo contrario devuelve valor falso
            return (textBox3.Text.Length > 0);
        }
        private bool nombrecliente()
        {
            //Método que retorna  un valor verdader si la longitud de la cadena en el cudro de texto es mayor a 0 de lo contrario devuelve valor falso
            return (textBox6.Text.Length > 0);
        }
        private bool telefonocliente()
        {
            //Método que retorna  un valor verdader si la longitud de la cadena en el cudro de texto es mayor a 0 de lo contrario devuelve valor falso
            return (textBox7.Text.Length > 0);
        }
       
       

        public bool validaciones()
        {
            //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
            int count = 0;

            if (placa())
            {
                //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
                errorProvider1.SetError(this.textBox1, String.Empty); count++;

            }
            else
            {
                //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
                errorProvider1.SetError(this.textBox1, "La placa es requerida");
            }
            if (marca())
            {
                //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
                errorProvider1.SetError(this.textBox2, String.Empty); count++;
            }
            else
            {
                //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
                errorProvider1.SetError(this.textBox2, "La marca es requerida");
            }
            if (color())
            {
                //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
                errorProvider1.SetError(this.textBox3, String.Empty); count++;
            }
            else
            {
                //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
                errorProvider1.SetError(this.textBox3, "El color es requerido");
            }
            if (nombrecliente())
            {
                //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
                errorProvider1.SetError(this.textBox6, String.Empty); count++;
            }
            else
            {
                //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
                errorProvider1.SetError(this.textBox6, "El nombre de cliente es requerido");
            }
            if (telefonocliente())
            {
                //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
                errorProvider1.SetError(this.textBox7, String.Empty); count++;
            }
            else
            {
                //Método que configura el errorprovider para arrojar una imagen roja intermitente indicando que es necesario ingresar el dato correspondiente
                errorProvider1.SetError(this.textBox7, "El teléfono es requerido");
            }

            if (count<4)
            {
                return false;

            }
            else
            {

                return true;
            }
         
        }

        public void limpiar()
        {
            //método para limpiar los cuadros de texto despúes de insertar un registro
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }




    }
}
