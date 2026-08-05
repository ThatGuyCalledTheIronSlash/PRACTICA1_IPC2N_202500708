using System;
using System.Collections.Generic;

public class VeterinariaMenu
{
    private List<Mascota> pacientes;

    public VeterinariaMenu()
    {
        pacientes = new List<Mascota>();
    }

    public void Registrar(Mascota mascota)
    {
        pacientes.Add(mascota);
    }

    public int CantidadPacientes()
    {
        return pacientes.Count;
    }

    public Mascota? BuscarPorCodigo(string codigo)
    {
        foreach (Mascota m in pacientes)
        {
            if (m.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                return m;
        }
        return null;
    }

    public void ListarCodigos()
    {
        if (pacientes.Count == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }

        Console.WriteLine("--- Pacientes registrados ---");
        foreach (Mascota m in pacientes)
        {
            Console.WriteLine($"Código: {m.Codigo} | Nombre: {m.Nombre}");
        }
    }
}