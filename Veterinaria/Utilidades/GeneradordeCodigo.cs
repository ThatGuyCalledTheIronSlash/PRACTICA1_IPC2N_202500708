using System;

public static class GeneradorCodigo
{
    private const string CARACTERES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private static readonly Random random = new Random();

    public static string Generar(int longitud = 8)
    {
        char[] codigo = new char[longitud];
        for (int i = 0; i < longitud; i++)
        {
            codigo[i] = CARACTERES[random.Next(CARACTERES.Length)];
        }
        return new string(codigo);
    }
}