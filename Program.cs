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

        Console.WriteLine("Fin del recorrido por el zoológico.");
    }

    static void PresentarAnimal(Animal animal)
    {
        Console.WriteLine("---------------------------------");

        animal.MostrarInformacion();

        Console.WriteLine($"Sonido: {animal.HacerSonido()}");

        Console.WriteLine("---------------------------------\n");
    }
}