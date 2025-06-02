using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionSanatorio
{
    public class Paciente
    {
        public string DNI;
        public string nombreYApellido;
        public string telefono;
        public string obraSocial;
        public double porcentaje;
        public List<Intervencion> intervencionesRealizadas = new List<Intervencion>();
        

        public Paciente(string DNI, string nombreYApellido, string telefono, string obraSocial, double porcentaje)
        {
            this.DNI = DNI;
            this.nombreYApellido = nombreYApellido;
            this.telefono = telefono;
            this.obraSocial = obraSocial;
            this.porcentaje = porcentaje;
        }
        
        public void ListarPaciente() {
            Console.WriteLine();
            Console.WriteLine(DNI);
            Console.WriteLine(nombreYApellido);
            Console.WriteLine(telefono);
            Console.WriteLine(obraSocial);
            Console.WriteLine(porcentaje);
            Console.WriteLine();
        }

        public void AsignarIntervencion(Intervencion intervencion)
        {
            intervencionesRealizadas.Add(intervencion);
        }

    }
}
