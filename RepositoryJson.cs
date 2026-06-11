using System.Text.Json;

public class JsonRepository<T> where T : class
{
    private readonly string _filePath;

    // ============================
    // CONSTRUCTOR PARA INICIALIZAR EL REPOSITORIO CON LA RUTA DEL ARCHIVO JSON
    // ============================
    public JsonRepository(string filePath)
    {
        _filePath = filePath;

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
    }
    // ============================
    // METODOS PRIVADOS PARA LEER Y GUARDAR DATOS EN EL ARCHIVO JSON
    // ============================
    private List<T> LeerArchivo()
    {
        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    private void GuardarArchivo(List<T> datos)
    {
        string json = JsonSerializer.Serialize(
            datos,
            new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(_filePath, json);
    }
    // ============================
    // 
    // ============================

    // ============================
    // AGREGAR
    // ============================
    public void Agregar(T elemento)
    {
        var datos = LeerArchivo();
        datos.Add(elemento);
        GuardarArchivo(datos);
    }

    // ============================
    // OBTENER TODOS
    // ============================
    public List<T> ObtenerTodos()
    {
        return LeerArchivo();
    }

    // ============================
    // ACTUALIZAR (REEMPLAZAR ELEMENTO)
    // ============================
    public void Actualizar(Func<T, bool> criterio, T nuevoElemento)
    {
        var datos = LeerArchivo();

        int index = datos.FindIndex(x => criterio(x));

        if (index == -1)
            throw new Exception("Elemento no encontrado.");

        datos[index] = nuevoElemento;

        GuardarArchivo(datos);
    }

    // ============================
    // ELIMINAR
    // ============================
    public void Eliminar(Func<T, bool> criterio)
    {
        var datos = LeerArchivo();

        var elemento = datos.FirstOrDefault(criterio);

        if (elemento == null)
            throw new Exception("Elemento no encontrado.");

        datos.Remove(elemento);

        GuardarArchivo(datos);
    }

    // ============================
    // REEMPLAZAR TODA LA LISTA
    // ============================
    public void GuardarLista(List<T> nuevaLista)
    {
        GuardarArchivo(nuevaLista);
    }
}
