using System;

namespace Cronometro
{
    class Cronometro
    {
        public int seg = 0;
        public int min = 0;

        public Cronometro(int seg, int min)
        {
            this.seg = seg;
            this.min = min;
        }

        public void reiniciar()
        {
            seg = 0;
            min = 0;
        }

        public void incrementarTiempo()
        {
            if (seg == 60)
            {
                min++;
                seg = 0;
            }
            else
            {
                seg++;
            }
        }

        public void mostrarTiempo()
        {
            Console.WriteLine("Tiempo: " + min + ":" + seg);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cronometro timer = new Cronometro(0, 0);

            for (int i = 0; i < 5000; i++)
            {
                timer.incrementarTiempo();
            }
            timer.mostrarTiempo();
            timer.reiniciar();
            timer.mostrarTiempo();
        }

    }

}



