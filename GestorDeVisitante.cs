using System.Text.Json;

public class GestorDeVisitante
{
    private readonly JsonRepository<Visitante> _repo;

    public GestorDeVisitante(JsonRepository<Visitante> repoVisitantes)
    {
        _repo = repoVisitantes;
    }

    // ============================
    // REGISTRAR
    // ============================
    public void RegistrarVisitante()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Edad: ");
        int edad = int.Parse(Console.ReadLine() ?? "0");

        _repo.Agregar(new Visitante(nombre, edad));

        Console.WriteLine("Visitante registrado correctamente.");
    }

    // ============================
    // MOSTRAR
    // ============================
    public void MostrarVisitantes()
    {
        var lista = _repo.ObtenerTodos();

        if (lista.Count == 0)
        {
            Console.WriteLine("No hay visitantes registrados.");
            return;
        }

        foreach (var v in lista)
            Console.WriteLine(v);
    }

    // ============================
    // BUSCAR
    // ============================
    public void BuscarVisitante()
    {
        Console.Write("Ingrese el nombre del visitante: ");
        string nombre = Console.ReadLine() ?? "";

        var lista = _repo.ObtenerTodos();

        var visitante = lista.FirstOrDefault(v =>
            v.Nombre != null &&
            v.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (visitante != null)
        {
            Console.WriteLine("Visitante encontrado:");
            Console.WriteLine($"Nombre: {visitante.Nombre}");
            Console.WriteLine($"Edad: {visitante.Edad}");
        }
        else
        {
            Console.WriteLine("Visitante no encontrado.");
        }
    }

    // ============================
    // MODIFICAR
    // ============================
    public void ModificarVisitante()
    {
        var lista = _repo.ObtenerTodos();

        Console.Write("Nombre del visitante a modificar: ");
        string nombre = Console.ReadLine() ?? "";

        var visitante = lista.FirstOrDefault(v =>
            v.Nombre != null &&
            v.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (visitante == null)
        {
            Console.WriteLine("Visitante no encontrado.");
            return;
        }

        Console.Write("Nuevo nombre: ");
        string nuevoNombre = Console.ReadLine() ?? "";

        Console.Write("Nueva edad: ");
        int nuevaEdad = int.Parse(Console.ReadLine() ?? "0");

        visitante.ModificarDatos(nuevoNombre, nuevaEdad);

        Guardar(lista);

        Console.WriteLine("Visitante actualizado.");
    }

    // ============================
    // ELIMINAR
    // ============================
    public void EliminarVisitante()
    {
        var lista = _repo.ObtenerTodos();

        Console.Write("Nombre del visitante a eliminar: ");
        string nombre = Console.ReadLine() ?? "";

        var visitante = lista.FirstOrDefault(v =>
            v.Nombre != null &&
            v.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (visitante != null)
        {
            lista.Remove(visitante);
            Guardar(lista);
            Console.WriteLine("Visitante eliminado.");
        }
        else
        {
            Console.WriteLine("Visitante no encontrado.");
        }
    }

    // ============================
    // CANTIDAD
    // ============================
    public void CantidadVisitantes()
    {
        var lista = _repo.ObtenerTodos();
        Console.WriteLine($"Hay {lista.Count} visitantes registrados.");
    }

    // ============================
    // GUARDAR CAMBIOS
    // ============================
    private void Guardar(List<Visitante> visitantes)
    {
        File.WriteAllText("visitantes.json",
            JsonSerializer.Serialize(visitantes, new JsonSerializerOptions { WriteIndented = true }));
    }
}

