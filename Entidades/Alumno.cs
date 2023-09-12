using System;
using System.Collections.Generic;

namespace CoreSchool.Entidades
{
    // Para eredar desde otra clase usamos : despues el nombre de la clase
    // Ya se eliminan las propiedades y constructores que ahora estan en la nueva clase
    public class Alumno : ObjetoEscuelaBase
    {
        // Propiedades
        // public string UniqueId { get; private set; }
        // public string Nombre { get; set; }
        // Propiedad de lista generica
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();


        // Constructor
        // public Alumno()
        // {
        //     this.UniqueId = Guid.NewGuid().ToString();
        //     this.Evaluaciones = new List<Evaluacion>() { };
        // }

    }
}