using System;
using System.Collections.Generic;

namespace AdministracionSanatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();

            Console.WriteLine("Ingrese la operación a realizar: ");
            Console.WriteLine("1. Dar de alta a un paciente");
            Console.WriteLine("2. Listar pacientes");
            Console.WriteLine("3. Asignar nueva intervención a un paciente");
            Console.WriteLine("4. Calcular costo intervenciones para un paciente");
            Console.WriteLine("5. Realizar reporte de liquidaciones pendientes de pago");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
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
                        percent = Console.Read();
                    }
                    Paciente paciente = new Paciente(DNI, nameSurname, Telephone, socialSecurity, percent);

                    hospital.AgregarPaciente(paciente);

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



                    hospital.Pacientes.Find(y => y.DNI == dni);

                    hospital.Intervenciones.Find(x => x.codigo == ID);

                    break;

                case "4":
                    Console.WriteLine("Opción 4 elegida");


                    break;

                case "5":
                    Console.WriteLine("Opción 5 elegida");


                    break;

                default:
                    Console.WriteLine("Opción inválida. Por favor, selecciona una opción del menú.");
                    break;
            }
        }
    }
}
