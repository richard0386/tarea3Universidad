using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace tarea33.mtrans
{
    public class mtransporte
    {
        //Clase padre que hereda sus atributos a automóviles y motocicletas
        private string placa;
        private string marca;
        private string color;
        private string nombrecliente;
        private string telefonocliente;
        private string tipo;
        private string categoria;

        public mtransporte(string p,string m,string c,string nc,string tc,string tip,string cate)
        {
            placa = p;
            marca = m;
            color = c;
            nombrecliente = nc;
            telefonocliente = tc;
            tipo = tip;
            categoria = cate;
        }

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Color { get => color; set => color = value; }
        public string Nombrecliente { get => nombrecliente; set => nombrecliente = value; }
        public string Telefonocliente { get => telefonocliente; set => telefonocliente = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Categoria { get => categoria; set => categoria = value; }
    }
}
