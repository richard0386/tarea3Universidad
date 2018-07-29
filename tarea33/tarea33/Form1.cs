using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tarea33.Automovil;
using tarea33.motos;
using tarea33.mtrans;
using tarea33.clientess;
namespace tarea33
{
    public partial class Form1 : Form
    {   //***************************************************************************************************************************************** 

        //Para esta tarea se utilizó la tecnología de Entity Framework de ADO.NET la cual simplifica en gran manera la forma en la que se hacen 
        //inserciones,eliminaciones,modificaciones,busquedas en una base de datos SQL. Sin embargo previamente se guardaron los datos en una 
        //lista de System.Collections.Generic según los requerimientos de la tarea. Antes de ingresar los datos en SQL se ingresaron en la lista 
        //y de la lista se pasaron a SQL al mismo tiempo para consultar se carga la lista con la base de datos previemente. La base de datos SQL esta
        //en un servidor de azure gracias a la cuenta de microsoft imagine que me otorgo la UNED pude poner la base de datos en ese servidor azure.
        //La lista se creo de tipo mtransporte debido a que por la herencia esta debia ser de tipo de la clase padre y poder guardar objetos
        //de automóviles y motocicletas en la misma lista.

        //***************************************************************************************************************************************** 
        Lista l = new Lista();
        public Form1()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            comboBox1.SelectedIndex = 0;
            llenarlistaautos();
        }


        public void llenarlistaautos()
        {
            try
            {
                using (tarea3Entities2 context = new tarea3Entities2())
                {
                    IQueryable<Auto> autosquery = from Auto in context.Autos //IQueryable<Auto> sirve para hacer una consulta a la base de datos
                                                                             //y devuelve una lista de todos los registros en este caso la tabla Auto
                                                  select Auto;

                    IQueryable<Moto> motosquery = from Moto in context.Motoes//IQueryable<Auto> sirve para hacer una consulta a la base de datos
                                                  select Moto;//y devuelve una lista de todos los registros en este caso la tabla Auto
                    foreach (Auto a in autosquery)
                    {
                        Lista.lista.Add(new automovil(a.Placa, a.Marca, a.Color, a.NombreCliente, a.TelefonoCliente, a.Tipo, a.Categoria));
                        //Se recorre la lista devuelta por la base de datos de la tabla Auto y se inserta en la lista general declarada en la clase Lista
                    }
                    foreach (Moto m in motosquery)
                    {
                        Lista.lista.Add(new moto(m.Placa, m.Marca, m.Color, m.NombreCliente, m.TelefonoCliente, m.Tipo, m.Categoria));
                        //Se recorre la lista devuelta por la base de datos de la tabla Moto y se inserta en la lista general declarada en la clase Lista
                    }

                    foreach (mtransporte mt in Lista.lista)
                    {
                        if (mt.Tipo == "automovil")
                        {
                            //Se verifica si el tipo de transporte es automovil o motocicleta y se llena el datagrid correspondiente
                            dataGridView1.DataSource = autosquery.ToList();
                        }
                        else if(mt.Tipo=="moto")
                        {

                            dataGridView2.DataSource = motosquery.ToList();
                        }

                    }





                    context.SaveChanges();
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

        private void automóvilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoform af = new autoform();
            af.Show(this);
        }

        private void motocicletasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            motoform m = new motoform();
            m.Show(this);
        }

        private void verListaDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cliform cfm = new cliform();
            cfm.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                using (tarea3Entities2 context = new tarea3Entities2())
                {
                    if (!string.IsNullOrEmpty(comboBox1.Text) && comboBox1.Text == "Placa" && !string.IsNullOrEmpty(textBox1.Text))
                    {
                        IQueryable<Auto> autosquery = from Auto in context.Autos//IQueryable<Auto> sirve para hacer una consulta a la base de datos
                                                                                //where EF.Functions.Like(Auto.Placa, ""+comboBox1.Text+""+"%")
                                                      where Auto.Placa.Contains(textBox1.Text)
                                                      select Auto;
                        context.SaveChanges();
                        dataGridView1.DataSource = autosquery.ToList();

                    }
                    else
                    {
                        IQueryable<Auto> autosquery = from Auto in context.Autos//IQueryable<Auto> sirve para hacer una consulta a la base de datos
                                                                                //where EF.Functions.Like(Auto.Placa, ""+comboBox1.Text+""+"%")
                                                      select Auto;
                        context.SaveChanges();
                        dataGridView1.DataSource = autosquery.ToList();

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
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString(), ee.TargetSite.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Representa los errores que se producen durante la ejecución de una aplicación

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (tarea3Entities2 context = new tarea3Entities2())
                {
                    if (comboBox1.SelectedIndex == 1)
                    {
                        IQueryable<Auto> autosquery = from Auto in context.Autos//IQueryable<Auto> sirve para hacer una consulta a la base de datos
                                                                                //where EF.Functions.Like(Auto.Placa, ""+comboBox1.Text+""+"%")
                                                      where Auto.Categoria.Contains("Automático")
                                                      select Auto;
                        context.SaveChanges();
                        dataGridView1.DataSource = autosquery.ToList();

                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        IQueryable<Auto> autosquery = from Auto in context.Autos//IQueryable<Auto> sirve para hacer una consulta a la base de datos
                                                                                //where EF.Functions.Like(Auto.Placa, ""+comboBox1.Text+""+"%")
                                                      where Auto.Categoria.Contains("Manual")
                                                      select Auto;
                        context.SaveChanges();
                        dataGridView1.DataSource = autosquery.ToList();

                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        IQueryable<Auto> autosquery = from Auto in context.Autos//IQueryable<Auto> sirve para hacer una consulta a la base de datos
                                                                                //where EF.Functions.Like(Auto.Placa, ""+comboBox1.Text+""+"%")
                                                      where Auto.Categoria.Contains("Cantidad de pasajeros")
                                                      select Auto;
                        context.SaveChanges();
                        dataGridView1.DataSource = autosquery.ToList();

                    }
                    else
                    {
                        IQueryable<Auto> autosquery = from Auto in context.Autos//IQueryable<Auto> sirve para hacer una consulta a la base de datos
                                                                                //where EF.Functions.Like(Auto.Placa, ""+comboBox1.Text+""+"%")
                                                      select Auto;
                        context.SaveChanges();
                        dataGridView1.DataSource = autosquery.ToList();

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
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString(), ee.TargetSite.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Representa los errores que se producen durante la ejecución de una aplicación

            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                using (tarea3Entities2 context = new tarea3Entities2())
                {
                    if (!string.IsNullOrEmpty(textBox2.Text.Trim()))
                    {
                        IQueryable<Moto> motosquery = from Moto in context.Motoes//IQueryable<Moto> sirve para hacer una consulta a la base de datos
                                                                               //where EF.Functions.Like(Auto.Placa, ""+comboBox1.Text+""+"%")
                                                      where Moto.Placa.Contains(textBox2.Text)
                                                      select Moto;
                        context.SaveChanges();
                        dataGridView2.DataSource = motosquery.ToList();

                    }
                    else
                    {
                        IQueryable<Moto> motosquery = from Moto in context.Motoes//IQueryable<Moto> sirve para hacer una consulta a la base de datos
                                                                                 //where EF.Functions.Like(Auto.Placa, ""+comboBox1.Text+""+"%")
                                                      where Moto.Placa.Contains(textBox2.Text)
                                                      select Moto;
                        context.SaveChanges();
                        dataGridView2.DataSource = motosquery.ToList();

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
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString(), ee.TargetSite.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Representa los errores que se producen durante la ejecución de una aplicación

            }

        }
    }
}
