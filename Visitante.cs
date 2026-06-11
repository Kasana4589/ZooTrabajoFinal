public class Visitante
    {
    private string? _nombre;
    private int _edad;

    public Visitante(string? nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public string? Nombre
        {
        get { return _nombre; }
        private set { 
            if(string.IsNullOrEmpty(value)) throw new ArgumentException("El nombre no puede estar vacío.");
            _nombre = value; }
    }

    public int Edad
        {
        get { return _edad; }
        private set { 
            if(value < 0) throw new ArgumentException("La edad no puede ser negativa.");
            _edad = value; }
    }
    public override string ToString()
    {
            return $"Visitante: {Nombre}, Edad: {Edad}";
    }
    public void ModificarDatos(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
}

