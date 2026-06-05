public class Anfibio : Animal
{
    private bool _esVenenoso;
    private string _habitat;
    private string _sonido;

    public Anfibio(string nombre, int edad, string especie,
                   bool esVenenoso, string habitat, string sonido)
        : base(nombre, edad, especie)
    {
        EsVenenoso = esVenenoso;
        Habitat = habitat;
        Sonido = sonido;
    }

    public bool EsVenenoso
    {
        get { return _esVenenoso; }
        private set { _esVenenoso = value; }
    }

    public string Habitat
    {
        get { return _habitat; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("El hábitat no puede estar vacío.");
            _habitat = value;
        }
    }

    public string Sonido
    {
        get { return _sonido; }
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("El sonido no puede estar vacío.");
            _sonido = value;
        }
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Es venenoso: {(EsVenenoso ? "Sí" : "No")}");
        Console.WriteLine($"Hábitat: {Habitat}");
    }

    public override string HacerSonido()
    {
        return Sonido;
    }
}