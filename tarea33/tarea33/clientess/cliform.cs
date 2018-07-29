using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tarea33.mtrans;

namespace tarea33.clientess
{
    public partial class cliform : Form
    { Lista l = new Lista();
        public cliform()
        {
            InitializeComponent();
        }

        private void cliform_Load(object sender, EventArgs e)
        {
            llenarclientes();
        }


        public void llenarclientes()
        {

            try
            {

                foreach (mtransporte mts in Lista.lista)
                {

                    dataGridView1.Rows.Add(mts.Nombrecliente,mts.Telefonocliente);
                    //Se cargan los datos de los clientes registrados hasta el momento de la lista. 
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

        private void cliform_Shown(object sender, EventArgs e)
        {
           
        }
    }
}
