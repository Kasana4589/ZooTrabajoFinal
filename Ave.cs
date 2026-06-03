public class Ave : Animal
{
    private bool _puedeVolar;

    public Ave(string nombre, int edad, string especie, bool puedeVolar)
        : base(nombre, edad, especie)
    {
        PuedeVolar = puedeVolar;
    }

    public bool PuedeVolar
    {
        get { return _puedeVolar; }
        private set { _puedeVolar = value; }
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Puede volar: {PuedeVolar}");
    }

    public override string HacerSonido()
    {
        return "Canto de ave";
    }
}