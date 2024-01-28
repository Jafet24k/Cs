using System.Linq;
using CoreSchool.Entidades;

namespace CoreSchool.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;

        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {

            if (dicObsEsc == null)
            {
                throw new ArgumentNullException(nameof(dicObsEsc));
            }
            _diccionario = dicObsEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluacion()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
                // Escribir en el log de auditoria
            }
        }
        // Creamos una sobrecarga del metodo para no siempre pasar un parametro 
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluacion();

            return (from ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct(); ;
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluaXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;
                dictaRta.Add(asig, evalsAsig);
            }
            return dictaRta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromAlumnxAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDicEvaluaXAsig();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var dummy = from eval in asigConEval.Value
                            group eval by eval.Alumno.UniqueId
                            into grupoEvalAlumno
                            select new
                            {
                                AlumnoID = grupoEvalAlumno.Key,
                                promedio = grupoEvalAlumno.Average(evaluacion => evaluacion.Nota)
                            };
            }

            return rta;
        }

    }
}