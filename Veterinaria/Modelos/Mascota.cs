public abstract class Mascota
{
    private string nombre;
    private double peso;          // kilogramos
    private string sexo;
    private int edad;
    private string propietario;
    private string codigo;        // 8 caracteres alfanuméricos
    private bool enfermo;

    public Mascota(string nombre, double peso, string sexo,
                   int edad, string propietario, bool enfermo)
    {
        this.nombre = nombre;
        this.peso = peso;
        this.sexo = sexo;
        this.edad = edad;
        this.propietario = propietario;
        this.enfermo = enfermo;
        this.codigo = GenerarCodigo();
    }

    public string Nombre { get { return nombre; } set { nombre = value; } }
    public double Peso   { get { return peso; }   set { peso = value; } }
    public int Edad      { get { return edad; }   set { edad = value; } }
    public string Codigo { get { return codigo; } }
    public bool Enfermo  { get { return enfermo; } }

    private string GenerarCodigo()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random r = new Random();
        char[] c = new char[8];
        for (int i = 0; i < 8; i++) c[i] = chars[r.Next(chars.Length)];
        return new string(c);
    }

    public virtual double CalcularDosis(double dosis_por_Kg)
    {
        return peso * dosis_por_Kg;
    }

    public void CambiarEstado()
    {
        enfermo = !enfermo;
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"[{codigo}] {nombre} | {sexo} | {edad} años");
        Console.WriteLine($"Peso: {peso} kg | Propietario: {propietario}");
        Console.WriteLine($"Estado: {(enfermo ? "Enfermo" : "Sano")}");
    }
}