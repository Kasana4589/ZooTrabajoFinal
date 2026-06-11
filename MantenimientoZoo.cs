public class MantenimientoZoo
{

    public static void RegistrarAnimal(List<Animal> zoologico)
    {

        Console.WriteLine("Ingrese el tipo de animal");
        string? tipoAnimal = Console.ReadLine() ?? "".Trim();

        Console.Write("Ingrese el nombre: ");
        string? nombre = Console.ReadLine();

        Console.Write("Ingrese la edad: ");
        int edad = int.Parse(Console.ReadLine() ?? "");

        Console.Write("Ingrese la especie: ");
        string? especie = Console.ReadLine() ?? "";

        switch (tipoAnimal)
        {
            case "ave":
                Console.Write("¿Puede volar? (true/false): ");
                bool volar = bool.Parse(Console.ReadLine() ?? "");

                Console.Write("¿Es un ave rapaz? (true/false): ");
                bool rapaz = bool.Parse(Console.ReadLine() ?? "");

                Console.Write("Sonido característico: ");
                string? sonido = Console.ReadLine() ?? "";

                Ave nuevaAve = new Ave(nombre, edad, especie, volar, sonido, rapaz);
                zoologico.Add(nuevaAve);
                Console.WriteLine($"{nombre} ha sido registrada correctamente");
                break;

            case "mamifero":
                Console.Write("Hábitat del mamífero: ");
                string habitat = Console.ReadLine() ?? "";

                Console.Write("Sonido característico: ");
                sonido = Console.ReadLine() ?? "";

                Console.WriteLine("Ingrese su tipo de alimentación: ");
                string? alimentacion = Console.ReadLine();

                Mamifero nuevoMamifero = new Mamifero(nombre, edad, especie, habitat, sonido, alimentacion);
                zoologico.Add(nuevoMamifero);
                Console.WriteLine($"{nombre} ha sido registrado correctamente");
                break;

            case "anfibio":
                Console.Write("¿Es venenoso? (true/false): ");
                bool esVenenoso = bool.Parse(Console.ReadLine() ?? "");

                Console.Write("Hábitat del anfibio: ");
                string? habitatAnfibio = Console.ReadLine() ?? "";

                Console.Write("Sonido característico: ");
                sonido = Console.ReadLine() ?? "";

                Console.WriteLine("Ingrese su tipo de alimentación: ");
                alimentacion = Console.ReadLine();

                Anfibio nuevoAnfibio = new Anfibio(nombre, edad, especie, esVenenoso, habitatAnfibio, sonido, alimentacion);
                zoologico.Add(nuevoAnfibio);
                Console.WriteLine($"{nombre} ha sido registrado correctmnete");
                break;

            default:
                Console.WriteLine("Tipo de animal no válido.");
                break;
        }

        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }
    public static void BuscarAnimal(List<Animal> zoologico)
    {
      
        Console.Write("Ingrese el nombre del animal a buscar: ");
        string? nombreBuscado = Console.ReadLine() ?? "";

        Console.WriteLine($"Buscando a {nombreBuscado}");

        Animal? animalEncontrado = null;
         
        foreach (Animal animal in zoologico)
        {
            if (animal.Nombre != null &&
                animal.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
            {
                animalEncontrado = animal;
                break;
            }
        }

        if (animalEncontrado != null)
        {
            Console.WriteLine("Animal encontrado");
            MantenimientoZoo.MostrarInformacion(animalEncontrado);
            Console.WriteLine($"Sonido: {animalEncontrado.HacerSonido()}");
        }
        else
        {
            Console.WriteLine("Animal no encontrado");

        }

        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }
    public static void MostrarInformacion(Animal animal)
    {
        Console.WriteLine($"Nombre: {animal.Nombre}");
        Console.WriteLine($"Edad: {animal.Edad} años");
        Console.WriteLine($"Especie: {animal.Especie}");

        if (animal is Ave ave)
            Console.WriteLine($"Tipo: Ave | Rapaz: {(ave.EsRapaz ? "Sí" : "No")}");
        else if (animal is Mamifero mamifero)
            Console.WriteLine($"Tipo: Mamífero | Hábitat: {mamifero.Habitat}");
        else if (animal is Anfibio anfibio)
            Console.WriteLine($"Tipo: Anfibio | Venenoso: {(anfibio.EsVenenoso ? "Sí" : "No")}");
        Console.WriteLine($"Alimentación: {animal.ObtenerAlimentacion()}");
        Console.WriteLine($"Sonido: {animal.HacerSonido()}");
    }
    public static void MostrarInformacion(List<Animal> zoologico)
    {

        foreach (Animal animal in zoologico)
        {
            Console.WriteLine($"Nombre: {animal.Nombre}");
            Console.WriteLine($"Edad: {animal.Edad} años");
            Console.WriteLine($"Especie: {animal.Especie}");

            if (animal is Ave ave)
                Console.WriteLine($"Tipo: Ave | Rapaz: {(ave.EsRapaz ? "Sí" : "No")}");
            else if (animal is Mamifero mamifero)
                Console.WriteLine($"Tipo: Mamífero | Hábitat: {mamifero.Habitat}");
            else if (animal is Anfibio anfibio)
                Console.WriteLine($"Tipo: Anfibio | Venenoso: {(anfibio.EsVenenoso ? "Sí" : "No")}");
            Console.WriteLine($"Alimentación: {animal.ObtenerAlimentacion()}");
            Console.WriteLine($"Sonido: {animal.HacerSonido()}");
        }
    }
    public static void CantidadAnimales (List<Animal> zoologico)
    {
     
        if (zoologico.Count == 0)
        {
            Console.WriteLine("No hay animales registrados en el zoológico.");
        }
        else
        {
            int contador = 1;
            foreach (Animal animal in zoologico)
            {
                Console.WriteLine($"Animal #{contador}");
                PresentarAnimal(animal);
                contador++;
            }
            Console.WriteLine($"Total de animales: {zoologico.Count}");
        }

        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }
    // Busca un animal y actualiza sus datos.

    public static void ModificarAnimal(List<Animal> zoologico)
    {
        Console.Write("Ingrese el nombre del animal a modificar: ");
        string nombreBuscado = Console.ReadLine() ?? "". Trim();

        foreach (Animal animal in zoologico)
        {
            if (animal.Nombre == nombreBuscado)
            {
                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine() ?? "";

                Console.Write("Nueva edad: ");
                int nuevaEdad = int.Parse(Console.ReadLine() ?? "");

                Console.Write("Nueva especie: ");
                string nuevaEspecie = Console.ReadLine() ?? "";

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
    public static void EliminarAnimal(List<Animal> zoologico)
    {
        Console.Write("Ingrese el nombre del animal a eliminar: ");
        string nombreBuscado = Console.ReadLine() ?? "".Trim();

        Animal? animalEliminar = null;

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
    public static void PresentarAnimal(Animal animal)
    {
        Console.WriteLine("---------------------------------");
        MantenimientoZoo.MostrarInformacion(animal);
        Console.WriteLine($"Sonido: {animal.HacerSonido()}");
        Console.WriteLine("---------------------------------\n");
    }
}

