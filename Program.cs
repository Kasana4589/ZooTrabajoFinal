using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Visitante visitante = new Visitante("Heidy", 17);

        Promocion promocion =
            new Promocion("Entrada Estudiantil", 25);

        Console.WriteLine("=================================");
        Console.WriteLine("   ZOOLÓGICO VIRTUAL NICARAGUA");
        Console.WriteLine("=================================\n");

        Console.WriteLine($"Bienvenido/a: {visitante.Nombre}");
        Console.WriteLine();

        promocion.MostrarInformacion();

        Console.WriteLine("\n=================================");
        Console.WriteLine("      INICIO DEL RECORRIDO");
        Console.WriteLine("=================================\n");

        List<Animal> zoologico = new List<Animal>()
        {
            // AVES
            new Ave("Águila Real", 5, "Ave rapaz", true),
            new Ave("Pingüino Emperador", 8, "Ave marina", false),

            // MAMÍFEROS
            new Mamifero("León", 7, "Felino", "Sabana"),
            new Mamifero("Delfín", 12, "Mamífero marino", "Océano"),

            // ANFIBIOS
            
new Anfibio(
    "Rana Roja",
    2,
    "Rana venenosa",
    true,
    "Selva tropical",
    "Croac croac"
),

new Anfibio(
    "Sapo Común",
    4,
    "Sapo",
    false,
    "Bosques y jardines",
    "Croooac"
),

new Anfibio(
    "Ajolote",
    3,
    "Salamandra acuática",
    false,
    "Lagos y canales",
    "Sonido suave"
),

new Anfibio(
    "Salamandra Tigre",
    5,
    "Salamandra",
    false,
    "Bosques húmedos",
    "Chirrido"
),

new Anfibio(
    "Rana Toro",
    4,
    "Rana",
    false,
    "Pantanos",
    "BRROOOOM"
),

new Anfibio(
    "Rana Arborícola",
    2,
    "Rana",
    false,
    "Árboles de zonas húmedas",
    "Cri cri"
),

new Anfibio(
    "Tritón Alpino",
    3,
    "Tritón",
    false,
    "Lagunas de montaña",
    "Chii"
),

new Anfibio(
    "Rana Dardo Azul",
    1,
    "Rana venenosa",
    true,
    "Selvas tropicales",
    "Croac"
),

new Anfibio(
    "Salamandra Gigante",
    10,
    "Salamandra",
    false,
    "Ríos de montaña",
    "Gruñido suave"
),

new Anfibio(
    "Rana de Cristal",
    2,
    "Rana",
    false,
    "Bosques tropicales",
    "Croac transparente"
)
        };

        foreach (Animal animal in zoologico)
        {
            PresentarAnimal(animal);
        }

        // Funciones agregadas para modificar y eliminar registros.
        ModificarAnimal(zoologico);

        EliminarAnimal(zoologico);

        Console.WriteLine("\nLista actualizada:\n");

        foreach (Animal animal in zoologico)
        {
            PresentarAnimal(animal);
        }

        Console.WriteLine("Fin del recorrido por el zoológico.");
    }

    static void PresentarAnimal(Animal animal)
    {
        Console.WriteLine("---------------------------------");

        animal.MostrarInformacion();

        Console.WriteLine($"Sonido: {animal.HacerSonido()}");

        Console.WriteLine("---------------------------------\n");

    }
   
    // Busca un animal y actualiza sus datos.

    static void ModificarAnimal(List<Animal> zoologico)
    {
        Console.Write("Ingrese el nombre del animal a modificar: ");
        string nombreBuscado = Console.ReadLine();

        foreach (Animal animal in zoologico)
        {
            if (animal.Nombre == nombreBuscado)
            {
                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();

                Console.Write("Nueva edad: ");
                int nuevaEdad = int.Parse(Console.ReadLine());

                Console.Write("Nueva especie: ");
                string nuevaEspecie = Console.ReadLine();

                animal.ModificarDatos(
                    nuevoNombre,
                    nuevaEdad,
                    nuevaEspecie
                );

                Console.WriteLine("Datos actualizados correctamente.");
                return;
            }
        }

        Console.WriteLine("No se encontró el animal.");
    }
    // Busca un animal por nombre y lo elimina de la lista.
    static void EliminarAnimal(List<Animal> zoologico)
    {
        Console.Write("Ingrese el nombre del animal a eliminar: ");
        string nombreBuscado = Console.ReadLine();

        Animal animalEliminar = null;

        foreach (Animal animal in zoologico)
        {
            if (animal.Nombre == nombreBuscado)
            {
                animalEliminar = animal;
                break;
            }
        }

        if (animalEliminar != null)
        {
            zoologico.Remove(animalEliminar);

            Console.WriteLine("Animal eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró el animal.");
        }
    }
    //Registrar Datos
   

}
