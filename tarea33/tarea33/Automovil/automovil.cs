using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea33.mtrans;
namespace tarea33.Automovil
{
    public class automovil:mtransporte
    {


        //Clase que hereda de mtransporte 
        public automovil(string p, string m,string c,string nc,string tc,string tip,string cate)
            :base(p,m,c,nc,tc,tip,cate)
        {
           
            
        }

    }
}
