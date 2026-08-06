public abstract class Mascota
{
    private string nombre;
    private double peso;   
    private string sexo;
    private int edad; 
    private string propietario; 
    private string codigo; //Código de la mascota
    private bool enfermo; 
//------------------------------------------------------
    public Mascota(string nombre, double peso, string sexo,
                   int edad, string propietario, bool enfermo)
    {
        this.nombre = nombre;
        this.peso = peso;
        this.sexo = sexo;
        this.edad = edad;
        this.propietario = propietario;
        this.enfermo = enfermo;
        this.codigo = GeneradorCodigo.Generar();
    }
//------------------------------------------------------
    public string Nombre { get { return nombre; } set { nombre = value; } }
//------------------------------------------------------
    public double Peso   { get { return peso; }   set { peso = value; } }
//------------------------------------------------------
    public string Sexo   { get { return sexo; }   set { sexo = value; } }
//------------------------------------------------------
    public string Propietario { get { return propietario; } set { propietario = value; } }
//------------------------------------------------------
    public int Edad      { get { return edad; }   set { edad = value; } }
//------------------------------------------------------
    public string Codigo { get { return codigo; } }
//------------------------------------------------------
    public bool Enfermo  { get { return enfermo; } }
//-----------------------------------------------------
    public virtual double CalcularDosis(double dosis_por_Kg)
    {
        return peso * dosis_por_Kg;
    }

    public void CambiarEstado()
    {
        enfermo = !enfermo;
    }
//------------------------------------------------------
    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"[{codigo}] {nombre} | {sexo} | {edad} años");
        Console.WriteLine($"Peso: {peso} kg | Propietario: {propietario}");
        Console.WriteLine($"Estado: {(enfermo ? "Enfermo" : "Sano")}");
    }
}