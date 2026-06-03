public class Mamifero : Animal
{
    private string? _habitat;

    public Mamifero(string nombre, int edad, string especie, string habitat)
        : base(nombre, edad, especie)
    {
        Habitat = habitat;
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
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Hábitat: {Habitat}");
    }

    public override string HacerSonido()
    {
        return "Mamifero:";
    }
}