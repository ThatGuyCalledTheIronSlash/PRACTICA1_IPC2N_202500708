public class Perro : Mascota
{
    private string raza;
    private string tamano;

    public Perro(string nombre, double peso, string sexo, int edad,
                 string propietario, bool enfermo,
                 string raza, string tamano)
        : base(nombre, peso, sexo, edad, propietario, enfermo)
    {
        this.raza = raza;
        this.tamano = tamano;
    }

    public string Raza { get { return raza; } set { raza = value; } }

    // Dosis estándar: peso x mg/kg, sin ajuste adicional
    public override double CalcularDosis(double dosis_por_Kg)
    {
        return base.CalcularDosis(dosis_por_Kg);
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("== PERRO ==");
        base.MostrarInformacion();
        Console.WriteLine($"Raza: {raza} | Tamaño: {tamano}");
    }
}