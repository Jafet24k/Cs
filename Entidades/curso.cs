using System.Collections.Generic;
using CoreSchool.Util;

namespace CoreSchool.Entidades
{
    public class Curso : ObjetoEscuelaBase, Ilugar
    {
        // PROPIEDADES
        // modificadoe de acceso 
        // Encapsulamiento 
        // Se puede manterner en privado el metodo get de la clase 
        public tipojornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string direccion { get; set; }

        public void LimpiarLugar()
        {
            Printer.driveLine();
            Console.WriteLine("Limpiando establecimiento ....");
            Console.WriteLine($"Curso {Nombre} Limpio ....");
        }
    }
}