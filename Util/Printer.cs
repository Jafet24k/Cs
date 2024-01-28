using static System.Console;

namespace CoreSchool.Util
{
    public static class Printer
    {
        // DriveLine obtiene un valor por defecto de 10
        // Propiedad   
        public static void driveLine(int tam = 10)
        {
            WriteLine("".PadLeft(tam, '='));
        }
        // Nueva Propiedad   
        public static void presioneEnter()
        {
            WriteLine("Presione ENTER para continuar... ");
        }



        public static void driveTitle(string titulo)
        {
            var tamaño = titulo.Length + 4;
            driveLine(tamaño);
            WriteLine($"|  {titulo}  |");
            driveLine(tamaño);

        }
        // Tercera Propiedad   
        // No se puede reproducir debido a la incompatibilidad del sistema

        // public static void beep(int hz = 2000, int tiempo = 500, int cantidad = 1)
        // {
        //     while (cantidad > 0)
        //     {
        //         System.Console.Beep(hz, tiempo);
        //     }
        // }


    }
}