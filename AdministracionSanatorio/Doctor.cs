using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionSanatorio
{
    public class Doctor
    {
        public string nombreYApellido;
        public string matrícula;
        public string especialidad;
        public bool disponibilidad;

        public Doctor(string nombreYApellido, string matrícula, string especialidad, bool disponibilidad)
        {
            this.nombreYApellido = nombreYApellido;
            this.matrícula = matrícula;
            this.especialidad = especialidad;
            this.disponibilidad = disponibilidad;
        }
    }
}
