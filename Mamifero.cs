public class Mamifero : Animal
{
    private string? _habitat;
    private string? _sonido;
    private string? _tipoAlimentacion;
    public Mamifero(string? nombre, int edad, string especie, string habitat, string? sonido, string? alimentacion)
        : base(nombre, edad, especie)
    {
        Habitat = habitat;
        Sonido = sonido;
        TipoAlimentacion = alimentacion;
    }
    public string? TipoAlimentacion
    {
        get => _tipoAlimentacion;
        private set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("El tipo de alimentación no puede quedar vacío");
            _tipoAlimentacion = value;
        }
    }
    public string? Habitat
    {
        get { return _habitat; }
        private set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("El hábitat no puede estar vacío.");
            _habitat = value;
        }
    }
    public string? Sonido
    {
        get => _sonido;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("El sonido no puede estra vacío");
            _sonido = value;
        }
    }
    public override string? ObtenerAlimentacion()
    {
        if (TipoAlimentacion != null)
        {
            switch (TipoAlimentacion.ToLower())
            {
                case "carnívoro":
                    return "Carnivora: Carne fresca - 5-7 kg cada 2 días";
                case "herbívoro":
                    return "Herbívora: Pasto, heno, frutas - 30-40 kg diarios";
                case "omnívoro":
                    return "Omnívora: Frutas, verduras, proteína - Dieta balanceada";
                case "pescado":
                    return "Pescado: Pescado fresco - 8-10 kg diarios";
                default:
                    return "No se encontraron resultados, consultar a un especialista";
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