using System;
using System.Threading;

public class Semaforo
{
    private enum EstadoSemaforo { Rojo, RojoAmarillo, Verde, Amarillo }
    private EstadoSemaforo estadoActual;
    private int segundosTranscurridos;
    private bool intermitente;
    private int timer;

    public Semaforo(string colorInicial)
    {
        estadoActual = (EstadoSemaforo)Enum.Parse(typeof(EstadoSemaforo), colorInicial, true);
        Console.WriteLine($"Semáforo iniciado en {estadoActual}");
    }

    public void PasoDelTiempo(int segundos)
    {
        for (int i = 0; i < segundos; i++)
        {
            if (intermitente)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(timer % 2 == 0 ? "Amarillo (Intermitente)" : "Apagado (Intermitente)");
                Thread.Sleep(1000);
                timer++;
                continue;
            }

            segundosTranscurridos++;
            Console.WriteLine($"Segundo {segundosTranscurridos}: {estadoActual}");

            if (estadoActual == EstadoSemaforo.Rojo && segundosTranscurridos >= 30) CambiarEstado();
            if (estadoActual == EstadoSemaforo.RojoAmarillo && segundosTranscurridos >= 2) CambiarEstado();
            if (estadoActual == EstadoSemaforo.Verde && segundosTranscurridos >= 20) CambiarEstado();
            if (estadoActual == EstadoSemaforo.Amarillo && segundosTranscurridos >= 2) CambiarEstado();

            Thread.Sleep(1000);
        }
    }

    private void CambiarEstado()
    {
        segundosTranscurridos = 0;
        estadoActual = estadoActual switch
        {
            EstadoSemaforo.Rojo => EstadoSemaforo.RojoAmarillo,
            EstadoSemaforo.RojoAmarillo => EstadoSemaforo.Verde,
            EstadoSemaforo.Verde => EstadoSemaforo.Amarillo,
            _ => EstadoSemaforo.Rojo
        };
        Console.WriteLine($"Cambiando a {estadoActual}");
    }

    public void PonerEnIntermitente()
    {
        intermitente = true;
        Console.WriteLine("Activando modo intermitente");
    }

    public void SacarDeIntermitente()
    {
        intermitente = false;
        estadoActual = EstadoSemaforo.Verde;
        segundosTranscurridos = 0;
        Console.WriteLine("Desactivando modo intermitente");
    }
}

public class Program
{
    public static void Main()
    {
        var semaforo = new Semaforo("Rojo");

        semaforo.PasoDelTiempo(32);
        semaforo.PonerEnIntermitente();
        semaforo.PasoDelTiempo(4);
        semaforo.SacarDeIntermitente();
        semaforo.PasoDelTiempo(22);
    }
}
