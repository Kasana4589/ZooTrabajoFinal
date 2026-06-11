public abstract class Animal
{
    private string? _nombre;
    private int _edad;
    private string? _especie;

    protected Animal(string? nombre, int edad, string? especie)
    {
        Nombre = nombre;
        Edad = edad;
        Especie = especie;
    }

    public string? Nombre
    {
        get { return _nombre; }
         set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("El nombre no puede estar vacío.");

            _nombre = value;
        }
    }

    public int Edad
    {
        get { return _edad; }
        set
        {
            if (value < 0)
                throw new ArgumentException("La edad no puede ser negativa.");

            _edad = value;
        }
    }

    public string? Especie
    {
        get { return _especie; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("La especie no puede estar vacía.");

            _especie = value;
        }
    }

    // Método que sirve para poder actualizar
    // el nombre, la edad y la especie de los animales.
    public void ModificarDatos(string nombre, int edad, string especie)
    {
        Nombre = nombre;
        Edad = edad;
        Especie = especie;
    }

    public virtual string? ObtenerAlimentacion()
    {
        return "Consultar con un especialista";
    }


    public abstract string? HacerSonido();


  
}