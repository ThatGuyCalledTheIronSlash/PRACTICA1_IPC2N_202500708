public class Tortuga : Mascota
//------------------------------------------------------------------------
{
    private string tipoCaparazon;
    private bool esAcuatica;


    public Tortuga(string nombre, double peso, string sexo, int edad,
                    string propietario, bool enfermo,
                    string tipoCaparazon, bool esAcuatica)
        : base(nombre, peso, sexo, edad, propietario, enfermo)
    {
        this.tipoCaparazon = tipoCaparazon;
        this.esAcuatica = esAcuatica;
    }

    public string TipoCaparazon { get { return tipoCaparazon; } set { tipoCaparazon = value; } }
    public bool EsAcuatica { get { return esAcuatica; } set { esAcuatica = value; } }
//------------------------------------------------------------------------
    // Factor de ajuste del 80 %
    public override double CalcularDosis(double dosis_por_Kg)
    {
        return base.CalcularDosis(dosis_por_Kg) * 0.80;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("== TORTUGA ==");
        base.MostrarInformacion();
        Console.WriteLine($"Tipo de caparazón: {tipoCaparazon} | Acuática: {(esAcuatica ? "Sí" : "No")}");
    }
}