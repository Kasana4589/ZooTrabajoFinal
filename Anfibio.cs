using System.ComponentModel.Design;

public class Anfibio : Animal
{
    private bool _esVenenoso;
    private string? _habitat;
    private string? _sonido;
    private string? _tipoAlimentacion;
    public Anfibio(string? nombre, int edad, string especie,
                   bool esVenenoso, string? habitat, string? sonido, string? tipoAlimentacion)
        : base(nombre, edad, especie)
    {
        EsVenenoso = esVenenoso;
        Habitat = habitat;
        Sonido = sonido;
        TipoAlimentacion = tipoAlimentacion;
    }
    public string? TipoAlimentacion
    {
        get => _tipoAlimentacion;
        private set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("No se puede dejar vacío el tipo de alimentación");
            _tipoAlimentacion=value;
        }
    }
    public bool EsVenenoso
    {
        get { return _esVenenoso; }
        private set { _esVenenoso = value; }
    }

    public string? Habitat
    {
        get { return _habitat; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("El hábitat no puede estar vacío.");
            _habitat = value;
        }
    }

    public string? Sonido
    {
        get { return _sonido; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("El sonido no puede estar vacío.");
            _sonido = value;
        }
    }

    public override string? ObtenerAlimentacion()
    {

        if (TipoAlimentacion != null)
        {
            switch (TipoAlimentacion.ToLower())
            {
                case "insectos":
                    return "Insectos: Grillos, moscas, gusanos";

                case "lombrices":
                    return "Lombrices: Lombrices de tierra, tubifex";

                case "camarones":
                    return "Camarones: Camarones pequeños, artemia";

                case "pequeños peces":
                    return "Peces: Alevines, peces pequeños";

                default:
                    return "insectos: Alimento estándar para anfibios";
            }
            
        }
        else
        {
            return "Consultar con un profesional";
        }
    }

    public override string? HacerSonido()
    {
        return Sonido;
    }
}