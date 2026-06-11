public class Ave : Animal
{
    private bool _puedeVolar;
    private string? _sonido;
    private bool _esRapaz;

    public Ave(string? nombre, int edad, string especie, bool puedeVolar, string sonido, bool esrapaz)
        : base(nombre, edad, especie)
    {
        PuedeVolar = puedeVolar;
        EsRapaz= esrapaz;
    }
    public bool EsRapaz
    {
        get => _esRapaz;
        private set => _esRapaz = value;
    }
    public bool PuedeVolar
    {
        get => _puedeVolar; 
        private set { _puedeVolar = value; }
    }
    
    public string? Sonido
    {
        get => _sonido;
        private set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("El sonido no puede estar vacío");
            _sonido=value;
        }
    }

    public override string ObtenerAlimentacion()
    {
        if (EsRapaz)
        {
            return " Carnivora: Carne fresca - 200g diarios";
        }
        else
        {
            return "Granivora: Semillas y granos - 150g diarios";
        }
    }

    public override string? HacerSonido()
    {
        return Sonido;
    }
}