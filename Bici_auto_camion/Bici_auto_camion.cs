using System;

namespace Bici_auto_camion
{
    interface IVehiculo
    {
        void mover(int tiempo);
        int posicion();
        void reiniciarPosicion();
    }

    class Auto : IVehiculo
    {
        public int velocidad;
        public int posicion_actual;


        public Auto(int velocidad, int posicion_actual)
        {
            this.velocidad = velocidad;
            this.posicion_actual = posicion_actual;
        }

        public void mover(int tiempo)
        {
            posicion_actual += (velocidad * tiempo);
        }

        public int posicion()
        {
            return posicion_actual;
        }

        public void reiniciarPosicion()
        {
            posicion_actual = 0;
        }

    }

    class Camion : IVehiculo
    {
        public int velocidad;
        public int posicion_actual;


        public Camion(int velocidad, int posicion_actual)
        {
            this.velocidad = velocidad;
            this.posicion_actual = posicion_actual;
        }

        public void mover(int tiempo)
        {
            posicion_actual += (velocidad * tiempo);
        }

        public int posicion()
        {
            return posicion_actual;
        }

        public void reiniciarPosicion()
        {
            posicion_actual = 0;
        }
    }

    class Bicicleta : IVehiculo
    {
        public int velocidad;
        public int posicion_actual;

        public Bicicleta(int velocidad, int posicion_actual)
        {
            this.velocidad = velocidad;
            this.posicion_actual = posicion_actual;
        }

        public void mover(int tiempo)
        {
            posicion_actual += (velocidad * tiempo);
        }

        public int posicion()
        {
            return posicion_actual;
        }

        public void reiniciarPosicion()
        {
            posicion_actual = 0;
        }
    }

    class Carrera
    {
        public IVehiculo vehiculo1;
        public IVehiculo vehiculo2;
        public int segundos;

        public Carrera(IVehiculo vehiculo1, IVehiculo vehiculo2, int segundos)
        {
            this.vehiculo1 = vehiculo1;
            this.vehiculo2 = vehiculo2;
            this.segundos = segundos;
        }

        public string iniciarCarrera()
        {
            vehiculo1.mover(segundos);
            vehiculo2.mover(segundos);

            return ($" {vehiculo1.GetType().Name}: {vehiculo1.posicion()}m ; {vehiculo2.GetType().Name}: {vehiculo2.posicion()}m");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Auto car = new Auto(45, 0);
            Bicicleta bike = new Bicicleta(30, 0);
            Camion truck = new Camion(10, 0);

            car.mover(10);
            car.mover(20);

            Console.WriteLine($"Distancia recorrida por Auto: {car.posicion()}m");

            car.reiniciarPosicion();

            Console.WriteLine($"Distancia recorrida por Auto: {car.posicion()}m");

            Carrera race = new Carrera(car, bike, 10);

            Console.WriteLine(race.iniciarCarrera());
        }

    }
}


