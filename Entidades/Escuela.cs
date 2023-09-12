using CoreSchool.Util;

namespace CoreSchool.Entidades
{ // Entidades
    public class Escuela : ObjetoEscuelaBase, Ilugar
    {

        // Con esta estructura podemos crear la misma logica que la pasada
        public int yearFundation { get; set; }

        public string country { get; set; }

        public string city { get; set; }
        public string direccion { get; set; }
        // public curso[] Cursos { get; set; }

        // Creamos una LISTA GENERICA  de Cursos 
        public List<Curso> Cursos { get; set; }

        // Llamamos la numeracion del archivo schoolTypes.cs 
        public schoolTypes tipoEscuela { get; set; }


        // Igualacion por tuplas para crear un constructor
        public Escuela(string nombre, int year) => (Nombre, yearFundation) = (nombre, year);

        // CONSTRUCTOR 
        // Creamos otro constructor con otros parametros 
        public Escuela(string nombre,
                        int year,
                        schoolTypes tipo,
                        string country = "",
                        string city = "")
        {
            (Nombre, yearFundation) = (nombre, year);
            this.country = country;
            this.city = city;
        }


        // Heredo las propiedades del papa 
        // override es para sobreescribir 
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {tipoEscuela} {System.Environment.NewLine} Pais: {country}, Ciudad: {city}";
        }

        public void LimpiarLugar()
        {
            // Aun por desarrollar
            Printer.driveLine();
            Console.WriteLine("Limpiando Escuela");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Console.WriteLine($"Escuela {Nombre} Limpia");
        }

    }





    // string nombre; // atributo o campo

    // public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
    // // Encapsulamiento 
    // // Podemos usar el prop comando para que nos cree el encapsulamiento
    // public string Nombre
    // {
    //     get { return "Copia: " + nombre; } // devolvemos el nombre
    //     set { nombre = value.ToUpper(); } // asignamos valores a la variable
    // }

    // Otras formas de crear una propiedad
    // public string Country { get; set; }
    // public string City { get; set; }

    // private int myVar; // variable privada que encapsula 
    // public int MyProperty // crear la propiedad que accede a la variable
    // {
    //     get { return myVar; }
    //     set { myVar = value; }
    // }


    // Constructor 

    // public Escuela(string nombre, int year)
    // {
    //     // usamos this. para diferenciar la variable nombre de la variable global nombre 
    //     this.nombre = nombre;
    //     yearFundation = year;

    // }


}