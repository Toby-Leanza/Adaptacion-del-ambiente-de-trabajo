using System;

namespace AdministracionSanatorio
{
	public class Reporte
	{
		public int identificador;
		public int fecha;
		public string descripcion;
		public string nombreYApellido_paciente;
		public string nombreDoctor;
		public int matriculaDoctor;
		public string obraSocial;
		public double importe;

		public Reporte(int identificador, int fecha, string descripcion, string nombreYApellido_paciente, string nombreDoctor, int matriculaDoctor, string obraSocial, double importe)
        {
			this.identificador = identificador;
			this.fecha = fecha;
			this.descripcion = descripcion;
			this.nombreYApellido_paciente = nombreYApellido_paciente;
			this.nombreDoctor = nombreDoctor;
			this.matriculaDoctor = matriculaDoctor;
			this.obraSocial = obraSocial;
			this.importe = importe;
		}


	}
}
