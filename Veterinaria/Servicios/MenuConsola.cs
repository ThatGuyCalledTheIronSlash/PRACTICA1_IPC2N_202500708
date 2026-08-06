using System;

public static class MenuConsola
{

//---------------------------------------------------------
    public static string LeerTexto(string mensaje)
    {
        string valor;
        do
        {
            Console.Write(mensaje);
            valor = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(valor));
        return valor;
    }
//---------------------------------------------------------
    public static double LeerDouble(string mensaje)
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out valor) && valor > 0)
                return valor;
            Console.WriteLine("Valor inválido. Ingrese un número mayor a 0.");
        }
    }
//---------------------------------------------------------
    public static int LeerEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                return valor;
            Console.WriteLine("Valor inválido. Ingrese un número entero válido.");
        }
    }
//---------------------------------------------------------
    public static bool LeerSiNo(string mensaje)
    {
        while (true)
        {
            Console.Write($"{mensaje} (S/N): ");
            string entrada = Console.ReadLine()?.Trim().ToUpper();
            if (entrada == "S") return true;
            if (entrada == "N") return false;
            Console.WriteLine("Respuesta inválida, escriba S o N.");
        }
    }
//---------------------------------------------------------
    public static string LeerSexo()
    {
        while (true)
        {
            Console.Write("Sexo (M = Macho / H = Hembra): ");
            string entrada = Console.ReadLine()?.Trim().ToUpper();
            if (entrada == "M") return "Macho";
            if (entrada == "H") return "Hembra";
            Console.WriteLine("Opción inválida.");
        }
    }
//---------------------------------------------------------
    public static string LeerTamano()
    {
        while (true)
        {
            Console.Write("Tamaño (P = Pequeño / M = Mediano / G = Grande): ");
            string entrada = Console.ReadLine()?.Trim().ToUpper();
            if (entrada == "P") return "Pequeño";
            if (entrada == "M") return "Mediano";
            if (entrada == "G") return "Grande";
            Console.WriteLine("Opción inválida.");
        }
    }
//---------------------------------------------------------
    public static int LeerOpcion(string mensaje, int min, int max)
    {
        int opcion;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= min && opcion <= max)
                return opcion;
            Console.WriteLine($"Opción inválida. Ingrese un número entre {min} y {max}.");
        }
    }
//----------------------------------------
    public static void LimpiarPantalla()
        {
            Console.Clear();
        }
//----------------------------------------
    public static void Pausar()
    {
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}