using System;
using System.Collections.Generic;

namespace AdministracionSanatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            void Caso1(){ // este void es para que se pueda repetir el caso 1 si no se encuentra el paciente o la intervención y ejecutarlo en el caso 1
                Console.WriteLine("Opción 1 elegida");
                        Console.WriteLine();
                        Console.Write("Ingrese DNI del paciente: ");
                        string DNI = Console.ReadLine();
                        Console.Write("Ingrese nombre y apellido del paciente: ");
                        string nameSurname = Console.ReadLine();
                        Console.Write("Ingrese telefono del paciente: ");
                        string Telephone = Console.ReadLine();
                        Console.WriteLine("¿Tiene obra social el paciente?(s/n)");
                        string socialSecurity = null;
                        double percent = 0;
                        if (Console.ReadLine() == "s")
                        {
                            Console.Write("Ingrese obra social del paciente (si tiene): ");
                            socialSecurity = Console.ReadLine();
                            Console.Write("Ingrese el porcentaje que cubre la obra social: ");
                            percent = Convert.ToDouble(Console.ReadLine()); // Cambié Console.Read() por ReadLine()
                        }
                        Paciente paciente = new Paciente(DNI, nameSurname, Telephone, socialSecurity, percent);
                        hospital.AgregarPaciente(paciente);
                        Console.WriteLine("Paciente agregado exitosamente.");
            }
            
            string opcion;
            do
            {
                // Mostrar menú
                Console.WriteLine("===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1. Agregar paciente");
                Console.WriteLine("2. Listar pacientes");
                Console.WriteLine("3. Asignar intervención");
                Console.WriteLine("4. Calcular costo intervenciones para un paciente");
                Console.WriteLine("5. Realizar reporte de liquidaciones pendientes de pago");
                Console.WriteLine("0. Salir");
                Console.WriteLine("==========================");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Caso1();
                        break;

                    case "2":
                        Console.WriteLine("Opción 2 elegida");
                        Console.WriteLine();
                        foreach (Paciente p in hospital.Pacientes)
                        {
                            p.ListarPaciente();
                        }
                        break;

                    case "3":
                        Console.WriteLine("Opción 3 elegida");
                        Console.WriteLine();
                        Console.WriteLine("Ingrese el DNI del paciente: ");
                        string dni = Console.ReadLine();
                        Console.WriteLine("Ingrese el código de la intervención: ");
                        string ID = Console.ReadLine();

                        Paciente pacienteEncontrado = hospital.Pacientes.Find(y => y.DNI == dni);
                        Intervencion intervencionEncontrada = hospital.Intervenciones.Find(x => x.codigo == ID);

                        if (pacienteEncontrado != null && intervencionEncontrada != null)
                        {
                            pacienteEncontrado.AsignarIntervencion(intervencionEncontrada);
                            Console.WriteLine("Intervención asignada exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Paciente o intervención no encontrados.");
                            Console.WriteLine("Volviendo al registro de paciente...");
                            Caso1();
                        }
                        break;

                    case "4":
                        Console.WriteLine("Opción 4 elegida");

                        Console.WriteLine("Ingrese el DNI del paciente: ");
                        string DNi = Console.ReadLine();

                        Paciente pacienteSeleccionado = hospital.Pacientes.Find(y => y.DNI == DNi);

                        if (pacienteSeleccionado != null)
                        {
                            double totalCosto = 0;
                            foreach (Intervencion intervencion in pacienteSeleccionado.intervencionesRealizadas)
                            {
                                double costo = intervencion.precio;
                                if (pacienteSeleccionado.obraSocial != null)
                                {
                                    costo -= costo * (pacienteSeleccionado.porcentaje / 100);
                                }
                                totalCosto += costo;
                            }
                            Console.WriteLine($"El costo total de las intervenciones para el paciente {pacienteSeleccionado.nombreYApellido} es: {totalCosto:C}");
                        }
                        else
                        {
                            Console.WriteLine("No se ha asignado ningún paciente.");
                        }

                        break;

                    case "5":
                        Console.WriteLine("Opción 5 elegida");

                        Console.WriteLine("Generando reporte de liquidaciones pendientes de pago...");

                        List<Reporte> reportes = new List<Reporte>();

                        foreach (Paciente p in hospital.Pacientes)
                        {
                            foreach (Intervencion i in p.intervencionesRealizadas)
                            {
                                double importe = i.precio;
                                if (p.obraSocial != null)
                                {
                                    importe -= importe * (p.porcentaje / 100);
                                }


                                Doctor doctor = hospital.Doctores.Count > 0 ? hospital.Doctores[0] : null;

                                string nombreDoctor = doctor != null ? doctor.nombreYApellido : "Doctor Desconocido";
                                int matriculaDoctor = doctor != null && int.TryParse(doctor.matrícula, out int m) ? m : 0;


                                Reporte reporte = new Reporte(
                                    reportes.Count + 1,
                                    DateTime.Now.Year,
                                    i.descripcion,
                                    p.nombreYApellido,
                                    $"{nombreDoctor}", 
                                    matriculaDoctor,
                                    p.obraSocial,
                                    importe
                                );
                                reportes.Add(reporte);
                            }
                        }

                        if (reportes.Count > 0)
                        {
                            Console.WriteLine("Reporte de liquidaciones pendientes de pago:");
                            foreach (var r in reportes)
                            {
                                Console.WriteLine($"ID: {r.identificador}, Fecha: {r.fecha}, Descripción: {r.descripcion}, Paciente: {r.nombreYApellido_paciente}, Doctor: {r.nombreDoctor}, Matrícula: {r.matriculaDoctor}, Obra Social: {r.obraSocial}, Importe: {r.importe:C}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay liquidaciones pendientes de pago.");
                        }

                        break;

                    case "0":
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Por favor, selecciona una opción del menú.");
                        break;
                }

                if (opcion != "0")
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear(); // Limpia la pantalla para mejor visualización
                }

            } while (opcion != "0");

            Console.WriteLine("¡Gracias por usar el sistema!");
        }
    }
}
