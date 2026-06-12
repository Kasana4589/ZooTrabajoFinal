public class GestorDeVisitante
{
    private readonly List<Visitante> _visitantes = new();
    public void RegistrarVisitante(List<Visitante> visitantes)
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Edad: ");
        int edad = int.Parse(Console.ReadLine() ?? "0");

        visitantes.Add(new Visitante(nombre, edad));

        Console.WriteLine("Visitante registrado correctamente.");
    }


 public void MostrarVisitantes(List<Visitante> visitantes)
{
    if (visitantes.Count == 0)
    {
        Console.WriteLine("No hay visitantes registrados.");
        return;
    }

    visitantes.ForEach(v =>
    {
        Console.WriteLine("------------------");
        Console.WriteLine($"Nombre: {v.Nombre}");
        Console.WriteLine($"Edad: {v.Edad}");
    });
}

    public void BuscarVisitante(List<Visitante> visitantes)
    {
        Console.Write("Ingrese el nombre del visitante: ");
        string nombre = Console.ReadLine() ?? "";

        Visitante? visitante =
            visitantes.Find(v =>
                v.Nombre != null &&
                v.Nombre.Equals(nombre,
                StringComparison.OrdinalIgnoreCase));

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

    public void ModificarVisitante(List<Visitante> visitantes)
    {
        Console.Write("Nombre del visitante a modificar: ");
        string nombre = Console.ReadLine() ?? "";

        Visitante? visitante =
            visitantes.Find(v =>
                v.Nombre != null &&
                v.Nombre.Equals(nombre,
                StringComparison.OrdinalIgnoreCase));

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

        Console.WriteLine("Visitante actualizado.");
    }

    public void EliminarVisitante(List<Visitante> visitantes)
    {
        Console.Write("Nombre del visitante a eliminar: ");
        string nombre = Console.ReadLine() ?? "";

        Visitante? visitante =
            visitantes.Find(v =>
                v.Nombre != null &&
                v.Nombre.Equals(nombre,
                StringComparison.OrdinalIgnoreCase));

        if (visitante != null)
        {
            visitantes.Remove(visitante);
            Console.WriteLine("Visitante eliminado.");
        }
        else
        {
            Console.WriteLine("Visitante no encontrado.");
        }
    }

    public void CantidadVisitantes(List<Visitante> visitantes)
    {
        Console.WriteLine(
            $"Hay {visitantes.Count} visitantes registrados.");
    }

}

