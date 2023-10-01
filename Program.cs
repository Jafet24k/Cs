// See https://aka.ms/new-console-template for more information
using CoreSchool;
using CoreSchool.Entidades;
using CoreSchool.Util;
using static System.Console;

class Program
{
    private static void Main(string[] args)
    {
        var engine = new EngineSchool();
        engine.Inicializar();
        Printer.driveTitle("BIENVENIDOS _ _ _ ");
        // Printer.beep();
        // Usamos dummy para representar un pareametro de salida que no se usa
        int dummy = 0;
        ImprimirCursosEscuela(engine.Escuela);

        #region Diccionario<>
        // DICCIONARIO<TKey, TValue>
        Dictionary<int, string> diccionario = new Dictionary<int, string>();

        diccionario.Add(10, "Jafet");
        diccionario.Add(23, "Loret");

        foreach (var KeyValPair in diccionario)
        {
            Console.WriteLine($"Key: {KeyValPair.Key} Valor: {KeyValPair.Value}");
        }

        Printer.driveTitle("Acceso a Diccionario");
        diccionario[0] = "Pekerman";
        Console.WriteLine(diccionario[23]);

        Printer.driveTitle("Otro Diccionario");
        var dic = new Dictionary<string, string>();
        dic["luna"] = "Cuerpo celeste que gira alrededor de la tierra";
        Console.WriteLine(dic["luna"]);
        dic.Add("luna", "Protagonist de Soy Luna");
        Console.WriteLine(dic["luna"]);
        #endregion



        Printer.driveLine(20);
        Printer.driveLine(20);
        Printer.driveLine(20);
        Printer.driveTitle("Pruebas de polimorfismo");
        var alumnoTest = new Alumno { Nombre = "Cintia Underwood" };

        // Variable Objeto
        ObjetoEscuelaBase ob = alumnoTest;

        Printer.driveTitle("Alumno");
        Console.WriteLine($"Alumno: {alumnoTest.Nombre}");
        Console.WriteLine($"Alumno: {alumnoTest.UniqueId}");
        Console.WriteLine($"Alumno: {alumnoTest.GetType()}");

        // Ejecutamos el mismo codigo pero con la variable objeto
        Printer.driveTitle("ObjetoEscuela");
        Console.WriteLine($"Alumno: {ob.Nombre}");
        Console.WriteLine($"Alumno: {ob.UniqueId}");
        Console.WriteLine($"Alumno: {ob.GetType()}");

    }

    private static void ImprimirCursosEscuela(Escuela escuela)
    {
        Printer.driveTitle("Cursos de Escuela");

        int counta = 0;
        // Agregamos la logica para condicionar direfentes errores en al programacion
        if (escuela != null && escuela.Cursos != null)
        {
            foreach (var curso in escuela.Cursos)
            {
                WriteLine($"Nombre: {curso.Nombre}, Jornada: {curso.Jornada}, Id: {curso.UniqueId}");
                counta += 1;
            }
        }
        WriteLine("===========================");
        WriteLine($"Total de clases: {counta}");
    }
}

#region notas pasadas
// // Segunda forma de crear arreglos 
// var arreglosCursos = new curso[3]{
//             new curso(){Nombre = "101"},
//             new curso(){Nombre = "201"},
//             new curso(){Nombre = "301"},
// };


// Console.WriteLine(escuela);
// Console.WriteLine("==================================================");
// // Console.WriteLine($"{curso1.Nombre}, {curso1.UniqueId}, {curso1.Jornada}");
// // Console.WriteLine($"{curso2.Nombre}, {curso2.UniqueId}, {curso2.Jornada}");
// // Console.WriteLine($"{curso3.Nombre}, {curso3.UniqueId}, {curso3.Jornada}");
// ImprimirCursosWhile(arreglosCursos);
// Console.WriteLine("==================================================");
// ImprimirCursosDoWhile(arreglosCursos);
// Console.WriteLine("==================================================");
// ImprimirCursosFor(arreglosCursos);
// Console.WriteLine("==================================================");
// ImprimirCursosForEach(arreglosCursos);

// Forma de imprimir un arreglo con WHILE
// void ImprimirCursosWhile(curso[] areglosCursos)
// {
//     int contador = 0;
//     while (contador < areglosCursos.Length)
//     {
//         Console.WriteLine($"Nombre {areglosCursos[contador].Nombre}, Id{areglosCursos[contador].UniqueId}");
//         contador++;
//     }
// }
// // Forma de recorrer arrays con DoWhile
// void ImprimirCursosDoWhile(curso[] areglosCursos)
// {
//     int contador = 0;
//     do
//     {
//         Console.WriteLine($"Nombre {areglosCursos[contador].Nombre}, Id{areglosCursos[contador].UniqueId}");
//         contador++;
//     } while (contador < areglosCursos.Length);
// }

// // Forma de recorrer arrays con FOR
// void ImprimirCursosFor(curso[] areglosCursos)
// {
//     for (int i = 0; i < areglosCursos.Length; i++)
//     {
//         Console.WriteLine($"Nombre {areglosCursos[i].Nombre}, Id{areglosCursos[i].UniqueId}");
//     }
// }

// // Forma de recorrer arrays con FOR EACH
// void ImprimirCursosForEach(curso[] areglosCursos)
// {
//     foreach (var curso in areglosCursos)
//     {
//         Console.WriteLine($"Nombre {curso.Nombre}, Id{curso.UniqueId}");
//     }

// CONDICIONES IF

// bool rta = 10 == 11; // FALSE
// int cantidad = 10;
// if (!rta)
// {
//     WriteLine("La primera condicion se cumplio");
// }
// else if (cantidad > 5)
// {
//     WriteLine("Se cumplio la segunda condicion");
// }
// else
// {
//     WriteLine("Ninguna de las dos condiciones se cumplieron");
// }

// if (cantidad > 5 && rta == false)
// {
//     WriteLine("Se cumplio la condicion 3");
// }
// }

// ARRAYS / ARREGLOS

// Tercera forma de arreglos Arrays

// escuela.Cursos = new curso[3]{
//             new curso(){Nombre = "KO200"},
//             new curso(){Nombre = "IO201"},
//             new curso(){Nombre = "EOX301"},

// };

// Codigo para el ejemplo de las condiciones 
// escuela.Cursos = null;





// Inicialzadores de objetos y de coleccion 

// // Lista Generica

// escuela.Cursos = new List<curso>(){
//             new curso(){Nombre = "IO201", Jornada = tipojornada.Manaña},
//             new curso(){Nombre = "KO200",Jornada = tipojornada.Manaña},
//             new curso(){Nombre = "EOX301", Jornada = tipojornada.Manaña},

// };
// // Agregamos nuevos cursos a la lista usando .Add()
// escuela.Cursos.Add(new curso() { Nombre = "EOX302", Jornada = tipojornada.Tarde });
// escuela.Cursos.Add(new curso() { Nombre = "IO302", Jornada = tipojornada.Tarde });


// // Creamos otra coleccion con los mismos parametros
// var otraColeccion = new List<curso>(){
//             new curso(){Nombre = "KO202", Jornada = tipojornada.Tarde},
//             new curso(){Nombre = "IO202", Jornada = tipojornada.Manaña},
//             new curso(){Nombre = "EOX301", Jornada = tipojornada.Tarde},

// };
// // Lista Generica

// escuela.Cursos = new List<curso>(){
//             new curso(){Nombre = "IO201", Jornada = tipojornada.Manaña},
//             new curso(){Nombre = "KO200",Jornada = tipojornada.Manaña},
//             new curso(){Nombre = "EOX301", Jornada = tipojornada.Manaña},

// };
// // Agregamos nuevos cursos a la lista usando .Add()
// escuela.Cursos.Add(new curso() { Nombre = "EOX302", Jornada = tipojornada.Tarde });
// escuela.Cursos.Add(new curso() { Nombre = "IO302", Jornada = tipojornada.Tarde });


// // Creamos otra coleccion con los mismos parametros
// var otraColeccion = new List<curso>(){
//             new curso(){Nombre = "KO202", Jornada = tipojornada.Tarde},
//             new curso(){Nombre = "IO202", Jornada = tipojornada.Manaña},
//             new curso(){Nombre = "EOX301", Jornada = tipojornada.Tarde},

// };


// Para borrar items de una coleccion
// otraColeccion.Clear();
// Con esta funcion agregamos los nuevos valores a la lista de coleccion 
// escuela.Cursos.AddRange(otraColeccion);


// ImprimirCursosEscuela(escuela);



// PREDICATE
// Predicate<curso> miAlgoritmo = Predicado;

// Usamos un DELEGATE para hacer la busqueda y eliminacion del objeto
// escuela.Cursos.RemoveAll(delegate (curso cur)
// {
//     return cur.Nombre == "EOX301" && cur.Jornada == tipojornada.Manaña;
// });

#endregion