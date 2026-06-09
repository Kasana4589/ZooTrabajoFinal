public class MantenimientoZoo
{
    public static void RegistrarAnimal(List<Animal> zoologico)
    {
  
        Console.WriteLine("Tipos de animales disponibles:");
        Console.WriteLine("1. Ave");
        Console.WriteLine("2. Mamifero");
        Console.WriteLine("3. Anfibio");
        Console.Write("Seleccione el tipo de animal: ");

        string? tipoAnimal = Console.ReadLine();

        Console.Write("Nombre del animal: ");
        string? nombre = Console.ReadLine();

        Console.Write("Edad del animal: ");
        int edad = int.Parse(Console.ReadLine() ?? "");

        Console.Write("Especie del animal: ");
        string especie = Console.ReadLine() ?? "";

        switch (tipoAnimal)
        {
            case "1":
                Console.Write("¿Es un ave rapaz? (true/false): ");
                bool esRapaz = bool.Parse(Console.ReadLine() ?? "");

                Ave nuevaAve = new Ave(nombre, edad, especie, esRapaz);
                zoologico.Add(nuevaAve);
                Console.WriteLine($"\n Ave '{nombre}' registrada exitosamente");
                break;

            case "2":
                Console.Write("Hábitat del mamífero: ");
                string habitat = Console.ReadLine() ?? "";

                Mamifero nuevoMamifero = new Mamifero(nombre, edad, especie, habitat);
                zoologico.Add(nuevoMamifero);
                Console.WriteLine($"\n Mamífero '{nombre}' registrado exitosamente");
                break;

            case "3":
                Console.Write("¿Es venenoso? (true/false): ");
                bool esVenenoso = bool.Parse(Console.ReadLine() ?? "");

                Console.Write("Hábitat del anfibio: ");
                string habitatAnfibio = Console.ReadLine() ?? "";

                Console.Write("Sonido característico: ");
                string sonido = Console.ReadLine() ?? "";

                Anfibio nuevoAnfibio = new Anfibio(nombre, edad, especie, esVenenoso, habitatAnfibio, sonido);
                zoologico.Add(nuevoAnfibio);
                Console.WriteLine($"\n Anfibio '{nombre}' registrado exitosamente");
                break;

            default:
                Console.WriteLine("Tipo de animal no válido.");
                break;
        }

        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }
}

