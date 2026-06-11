
    public class Promocion
    {
    public string? _nombre;
    public double _descuento;

        public Promocion(string nombre, double descuento)
        {
            Nombre = nombre;
            Descuento = descuento;
        }

    public string? Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("El nombre de la promoción no puede estar vacío.");
                _nombre = value;
            }
    }
    public double Descuento
    {
        get { return _descuento; }
        set
        {
            if (value < 0 || value > 100) throw new ArgumentException("El descuento debe estar entre 0 y 100.");
            _descuento = value;
        }
    }
    public void MostrarInformacion()
        {
            Console.WriteLine($"Promoción: {Nombre}");
            Console.WriteLine($"Descuento: {Descuento}%");
        }
    }


