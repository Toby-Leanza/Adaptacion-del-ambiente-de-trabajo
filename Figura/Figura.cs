using System;

namespace Figura
{
    interface IFigura
    {
        double calcularArea();
        double calcularPerimetro();
    }

    class Rectangulo : IFigura
    {
        public double largo;
        public double ancho;

        public Rectangulo(double largo, double ancho)
        {
            this.largo = largo;
            this.ancho = ancho;
        }

        public double calcularArea()
        {
            return largo * ancho;
        }

        public double calcularPerimetro()
        {
            return largo * 2 + ancho * 2;
        }
    }
    class Cuadrado : IFigura
    {
        public double lado;

        public Cuadrado(double lado)
        {
            this.lado = lado;
        }

        public double calcularArea()
        {
            return lado * lado;
        }

        public double calcularPerimetro()
        {
            return lado * 4;
        }
    }
    class Triangulo : IFigura
    {
        public double baseT;
        public double altura;
        public double lado2;
        public double lado3;

        public Triangulo(double baseT, double altura, double lado2, double lado3)
        {
            this.baseT = baseT;
            this.altura = altura;
            this.lado2 = lado2;
            this.lado3 = lado3;
        }

        public double calcularArea()
        {
            return (baseT * altura) / 2;
        }

        public double calcularPerimetro()
        {
            return baseT + lado2 + lado3;
        }
    }

    class Circulo : IFigura
    {
        public double radio;
        static double pi = 3.14;

        public Circulo(double radio)
        {
            this.radio = radio;
        }
        public double calcularArea()
        {
            return pi * radio * radio;
        }

        public double calcularPerimetro()
        {
            return pi * radio * 2;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IFigura[] figuras = new IFigura[4];
            Rectangulo rect = new Rectangulo(6, 6.5);
            Cuadrado sqre = new Cuadrado(5);
            Triangulo triang = new Triangulo(5, 7, 8, 9);
            Circulo circ = new Circulo(5);


            figuras[0] = new Rectangulo(6, 6.5);
            figuras[1] = new Cuadrado(5);
            figuras[2] = new Triangulo(5, 7, 8, 9);
            figuras[3] = new Circulo(5);


            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Área {figuras[i].GetType().Name}: {figuras[i].calcularArea()}");
                Console.WriteLine($"Perímetro {figuras[i].GetType().Name}: {figuras[i].calcularPerimetro()}");
                Console.WriteLine(" ");
            }
        }

    }

}


