using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionSanatorio
{
    public class Intervencion
    {
        public string codigo;
        public string descripcion;
        public string especialidad;
        public double precio;

        public Intervencion(string codigo, string descripcion, string especialidad, double precio)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.especialidad = especialidad;
            this.precio = precio;
        }
    }

    public class AltaComplejidad : Intervencion
    {
        static double porcentaje = 0.5;

        public AltaComplejidad(string codigo, string descripcion, string especialidad, double precio) : base(codigo, descripcion, especialidad, precio) { }
    }

    

}
