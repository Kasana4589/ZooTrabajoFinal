using System.Text.Json;

public class MantenimientoZoo
{
    private readonly JsonRepository<Animal> _repo;

    public MantenimientoZoo(JsonRepository<Animal> repo)
    {
        _repo = repo;
    }

    // ============================
    // REGISTRAR ANIMAL
    // ============================
    public void RegistrarAnimal()
    {
        Console.WriteLine("Ingrese el tipo de animal (ave/mamifero/anfibio): ");
        string tipoAnimal = Console.ReadLine()?.Trim().ToLower() ?? "";

        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Ingrese la edad: ");
        int edad = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ingrese la especie: ");
        string especie = Console.ReadLine() ?? "";

        Animal nuevo = null;

        switch (tipoAnimal)
        {
            case "ave":
                Console.Write("¿Puede volar? (true/false): ");
                bool volar = bool.Parse(Console.ReadLine() ?? "");

                Console.Write("¿Es rapaz? (true/false): ");
                bool rapaz = bool.Parse(Console.ReadLine() ?? "");

                Console.Write("Sonido característico: ");
                string sonidoAve = Console.ReadLine() ?? "";

                nuevo = new Ave(nombre, edad, especie, volar, sonidoAve, rapaz);
                break;

            case "mamifero":
                Console.Write("Hábitat: ");
                string habitat = Console.ReadLine() ?? "";

                Console.Write("Sonido característico: ");
                string sonidoMamifero = Console.ReadLine() ?? "";

                Console.Write("Tipo de alimentación: ");
                string alimentacionMamifero = Console.ReadLine() ?? "";

                nuevo = new Mamifero(nombre, edad, especie, habitat, sonidoMamifero, alimentacionMamifero);
                break;

            case "anfibio":
                Console.Write("¿Es venenoso? (true/false): ");
                bool venenoso = bool.Parse(Console.ReadLine() ?? "");

                Console.Write("Hábitat: ");
                string habitatAnf = Console.ReadLine() ?? "";

                Console.Write("Sonido característico: ");
                string sonidoAnf = Console.ReadLine() ?? "";

                Console.Write("Tipo de alimentación: ");
                string alimentacionAnf = Console.ReadLine() ?? "";

                nuevo = new Anfibio(nombre, edad, especie, venenoso, habitatAnf, sonidoAnf, alimentacionAnf);
                break;

            default:
                Console.WriteLine("Tipo de animal no válido.");
                return;
        }

        _repo.Agregar(nuevo);
        Console.WriteLine($"{nombre} ha sido registrado correctamente.");
        Console.ReadLine();
    }

    // ============================
    // BUSCAR ANIMAL
    // ============================
    public void BuscarAnimal()
    {
        var zoologico = _repo.ObtenerTodos();

        Console.Write("Ingrese el nombre del animal a buscar: ");
        string nombreBuscado = Console.ReadLine() ?? "";

        var animal = zoologico.FirstOrDefault(a =>
            a.Nombre != null &&
            a.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase));

        if (animal == null)
        {
            Console.WriteLine("Animal no encontrado.");
        }
        else
        {
            Console.WriteLine("Animal encontrado:");
            MostrarInformacion(animal);
        }

        Console.ReadLine();
    }

    // ============================
    // MOSTRAR INFORMACIÓN
    // ============================
    public void MostrarInformacion(Animal animal)
    {
        Console.WriteLine($"Nombre: {animal.Nombre}");
        Console.WriteLine($"Edad: {animal.Edad}");
        Console.WriteLine($"Especie: {animal.Especie}");

        if (animal is Ave ave)
            Console.WriteLine($"Tipo: Ave | Rapaz: {ave.EsRapaz}");
        else if (animal is Mamifero mam)
            Console.WriteLine($"Tipo: Mamífero | Hábitat: {mam.Habitat}");
        else if (animal is Anfibio anf)
            Console.WriteLine($"Tipo: Anfibio | Venenoso: {anf.EsVenenoso}");

        Console.WriteLine($"Alimentación: {animal.ObtenerAlimentacion()}");
        Console.WriteLine($"Sonido: {animal.HacerSonido()}");
    }

    public void MostrarInformacion()
    {
        var zoologico = _repo.ObtenerTodos();

        foreach (var animal in zoologico)
        {
            MostrarInformacion(animal);
            Console.WriteLine("--------------------------");
        }
    }

    // ============================
    // CANTIDAD DE ANIMALES
    // ============================
    public void CantidadAnimales()
    {
        var zoologico = _repo.ObtenerTodos();
        Console.WriteLine($"Total de animales: {zoologico.Count}");
        Console.ReadLine();
    }

    // ============================
    // MODIFICAR ANIMAL
    // ============================
    public void ModificarAnimal()
    {
        var zoologico = _repo.ObtenerTodos();

        Console.Write("Ingrese el nombre del animal a modificar: ");
        string nombreBuscado = Console.ReadLine() ?? "";

        var animal = zoologico.FirstOrDefault(a => a.Nombre == nombreBuscado);

        if (animal == null)
        {
            Console.WriteLine("Animal no encontrado.");
            return;
        }

        Console.Write("Nuevo nombre: ");
        animal.Nombre = Console.ReadLine() ?? "";

        Console.Write("Nueva edad: ");
        animal.Edad = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Nueva especie: ");
        animal.Especie = Console.ReadLine() ?? "";

        // Guardar cambios
        Guardar(zoologico);

        Console.WriteLine("Animal modificado correctamente.");
        Console.ReadLine();
    }

    // ============================
    // ELIMINAR ANIMAL
    // ============================
    public void EliminarAnimal()
    {
        var zoologico = _repo.ObtenerTodos();

        Console.Write("Ingrese el nombre del animal a eliminar: ");
        string nombreBuscado = Console.ReadLine() ?? "";

        var animal = zoologico.FirstOrDefault(a => a.Nombre == nombreBuscado);

        if (animal == null)
        {
            Console.WriteLine("Animal no encontrado.");
            return;
        }

        zoologico.Remove(animal);
        Guardar(zoologico);

        Console.WriteLine("Animal eliminado correctamente.");
        Console.ReadLine();
    }

    // ============================
    // GUARDAR CAMBIOS
    // ============================
    private void Guardar(List<Animal> animales)
    {
        File.WriteAllText("animales.json",
            JsonSerializer.Serialize(animales, new JsonSerializerOptions { WriteIndented = true }));
    }
}
