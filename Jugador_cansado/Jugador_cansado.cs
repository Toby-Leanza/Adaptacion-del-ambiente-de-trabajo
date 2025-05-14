using System;
using System.Security.Cryptography.X509Certificates;

namespace Jugador_cansado
{
    interface IJugador
    {
        bool correr(int min);
        bool cansado();
        void descansar(int min);
    }

    class Amateur : IJugador
    {
        public int min;

        public Amateur(int min)
        {
            this.min = min;
        }
        public bool correr(int min)
        {
            if (min > 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool cansado()
        {
            if (correr(min))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void descansar(int min)
        {
            Console.WriteLine("Descansando");
        }
    }
    class Profesional : IJugador
    {

        public int min;

        public Profesional(int min)
        {
            this.min = min;
        }
        public bool correr(int min)
        {
            return (min > 40);
        }
        public bool cansado()
        {
            if (correr(min))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void descansar(int min)
        {
            Console.WriteLine("Descansando");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Amateur playerA = new Amateur(40);
            Profesional playerP = new Profesional(40);

            Console.WriteLine(playerA.correr(40));
            Console.WriteLine(playerP.correr(40));


        }

    }

}


