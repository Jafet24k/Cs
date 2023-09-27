using System;
using CoreSchool.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace CoreSchool
{
    public class EngineSchool
    {
        public Escuela? Escuela { get; set; }

        // public EngineSchool()
        // {
        // }

        // REFACTORIZAMOS

        // METODDOS
        // Metodo que debe de inicializar todos los valores dentro del programa        
        public void Inicializar()
        {
            Escuela = new Escuela("Platzy Academy", 2012, schoolTypes.Primaria,
                country: "Colombia", city: "bogota");

            CargarCursos();
            CargaAsignaturas();
            CargarEvaluaciones();

        }

        // Sobrecarga de Metodo:
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool TraeCursos = true

            )
        {
            return GetObjetoEscuelas(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        // Lista de Objetos polimorfica
        // Sobrecarga de objetos:
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
            // Parametros de salida: 
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            // Parametros opcionales 
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool TraeCursos = true

            )
        {

            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = 0;

            var ListaObj = new List<ObjetoEscuelaBase>();
            ListaObj.Add(Escuela);
            ListaObj.AddRange(Escuela.Cursos);

            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;
                if (traeEvaluaciones)
                {
                    ListaObj.AddRange(curso.Asignaturas);
                }
                if (traeAlumnos)
                {
                    ListaObj.AddRange(curso.Alumnos);
                }

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        ListaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return ListaObj.AsReadOnly();

        }

        public List<ObjetoEscuelaBase> GetObjetoEscuelas()
        {
            var ListaObj = new List<ObjetoEscuelaBase>();
            ListaObj.Add(Escuela);
            ListaObj.AddRange(Escuela.Cursos);

            foreach (var curso in Escuela.Cursos)
            {
                ListaObj.AddRange(curso.Asignaturas);

                ListaObj.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    ListaObj.AddRange(alumno.Evaluaciones);
                }
            }

            return ListaObj;

        }

        #region Metodos de carga
        private void CargarEvaluaciones()
        {
            var lista = new List<Evaluacion>();
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

        private void CargaAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matematicas"},
                    new Asignatura{Nombre="Educacion Fisica"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            // Usando OrderBy podemos ordenar por UniqueId
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }
        // Metodo para cargar cursos
        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                        new Curso(){Nombre = "IO201", Jornada = tipojornada.Manaña},
                        new Curso(){Nombre = "KO200",Jornada = tipojornada.Tarde},
                        new Curso(){Nombre = "EOX301", Jornada = tipojornada.Manaña},
                        new Curso(){Nombre = "KO202", Jornada = tipojornada.Tarde},
                        new Curso(){Nombre = "IO202", Jornada = tipojornada.Manaña},
                        new Curso(){Nombre = "EOX301", Jornada = tipojornada.Tarde},
            };
            // Creacion de numeros random 
            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAzar(cantRandom);
            }
        }
        #endregion
    }
}