using System;
using System.Threading;

namespace RectangularFigure
{
    class Program
    {
        // El tamaño de la consola
        static int consoleWidth = 80;
        static int consoleHeight = 25;

        // El tamaño de la figura rectangular
        static int figureWidth = 10;
        static int figureHeight = 5;

        // La posición inicial de la figura rectangular
        static int figureX = consoleWidth / 2 - figureWidth / 2;
        static int figureY = 0;

        // La velocidad de caída de la figura rectangular
        static int speed = 1;

        // La altura del suelo
        static int groundHeight = 3;

        // El array bidimensional que representa la figura rectangular
        static char[,] figure = new char[figureHeight, figureWidth];

        // El método que llena el array con el símbolo '*'
        static void FillFigure()
        {
            for (int i = 0; i < figureHeight; i++)
            {
                for (int j = 0; j < figureWidth; j++)
                {
                    figure[i, j] = '*';
                }
            }
        }

        // El método que dibuja la figura rectangular en la consola
        static void DrawFigure()
        {
            Console.SetCursorPosition(figureX, figureY);
            for (int i = 0; i < figureHeight; i++)
            {
                for (int j = 0; j < figureWidth; j++)
                {
                    Console.Write(figure[i, j]);
                }
                Console.WriteLine();
                Console.SetCursorPosition(figureX, figureY + i + 1);
            }
        }

        // El método que borra la figura rectangular de la consola
        static void ClearFigure()
        {
            Console.SetCursorPosition(figureX, figureY);
            for (int i = 0; i < figureHeight; i++)
            {
                for (int j = 0; j < figureWidth; j++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
                Console.SetCursorPosition(figureX, figureY + i + 1);
            }
        }

        // El método que actualiza la posición de la figura rectangular
        static void UpdateFigure()
        {
            // Si la figura no ha tocado el suelo, se mueve hacia abajo
            if (figureY + figureHeight < consoleHeight - groundHeight)
            {
                figureY += speed;
            }
            // Si la figura ha tocado el suelo, se detiene el programa
            else
            {
                Environment.Exit(0);
            }
        }

        // El método que dibuja el suelo en la consola
        static void DrawGround()
        {
            Console.SetCursorPosition(0, consoleHeight - groundHeight);
            for (int i = 0; i < groundHeight; i++)
            {
                for (int j = 0; j < consoleWidth; j++)
                {
                    Console.Write('_');
                }
                Console.WriteLine();
            }
        }

        // El método principal del programa
        static void Main(string[] args)
        {
            // Se configura la consola
            Console.CursorVisible = false;
            Console.SetWindowSize(consoleWidth, consoleHeight);
            Console.SetBufferSize(consoleWidth, consoleHeight);

            // Se llena el array de la figura
            FillFigure();

            // Se dibuja el suelo
            DrawGround();

            // Se inicia el bucle principal del programa
            while (true)
            {
                // Se dibuja la figura
                DrawFigure();

                // Se espera un tiempo
                Thread.Sleep(100);

                // Se borra la figura
                ClearFigure();

                // Se actualiza la posición de la figura
                UpdateFigure();
            }
        }
    }
}
