using System;

class Program
{
    static Veterinaria veterinaria = new Veterinaria();

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            MostrarMenuPrincipal();
            opcion = MenuConsola.LeerOpcion("Seleccione una opción: ", 1, 3);

            switch (opcion)
            {
                case 1: RegistrarMascota(); break;
                case 2: GestionarPacientes(); break;
                case 3: Console.WriteLine("Saliendo del sistema..."); break;
            }

        } while (opcion != 3);
    }

    static void MostrarMenuPrincipal()
    {
        Console.WriteLine();
        Console.WriteLine("=== VETERINARIA ===");
        Console.WriteLine($"Pacientes registrados: {veterinaria.CantidadPacientes()}");
        Console.WriteLine("1. Registrar mascota");
        Console.WriteLine("2. Gestionar pacientes");
        Console.WriteLine("3. Salir");
    }

    static void RegistrarMascota()
    {
        Console.WriteLine();
        Console.WriteLine("--- Registrar mascota ---");
        Console.WriteLine("1. Perro  2. Gato  3. Ave  4. Tortuga");
        int especie = MenuConsola.LeerOpcion("Seleccione especie: ", 1, 4);

        string nombre = MenuConsola.LeerTexto("Nombre: ");
        double peso = MenuConsola.LeerDouble("Peso (kg): ");
        string sexo = MenuConsola.LeerSexo();
        int edad = MenuConsola.LeerEntero("Edad (años): ");
        string propietario = MenuConsola.LeerTexto("Propietario: ");
        bool enfermo = MenuConsola.LeerSiNo("¿Está enfermo?");

        Mascota nuevaMascota = null;

        switch (especie)
        {
            case 1:
                string raza = MenuConsola.LeerTexto("Raza: ");
                string tamano = MenuConsola.LeerTexto("Tamaño (grande/mediano/pequeño): ");
                nuevaMascota = new Perro(nombre, peso, sexo, edad, propietario, enfermo, raza, tamano);
                break;
            case 2:
                string razaGato = MenuConsola.LeerTexto("Raza: ");
                bool esterilizado = MenuConsola.LeerSiNo("¿Está esterilizado?");
                nuevaMascota = new Gato(nombre, peso, sexo, edad, propietario, enfermo, razaGato, esterilizado);
                break;
            case 3:
                double envergadura = MenuConsola.LeerDouble("Envergadura de alas (cm): ");
                bool puedeVolar = MenuConsola.LeerSiNo("¿Puede volar?");
                nuevaMascota = new Ave(nombre, peso, sexo, edad, propietario, enfermo, envergadura, puedeVolar);
                break;
            case 4:
                string caparazon = MenuConsola.LeerTexto("Tipo de caparazón: ");
                bool esAcuatica = MenuConsola.LeerSiNo("¿Es acuática?");
                nuevaMascota = new Tortuga(nombre, peso, sexo, edad, propietario, enfermo, caparazon, esAcuatica);
                break;
        }

        veterinaria.Registrar(nuevaMascota);
        Console.WriteLine($"Mascota registrada con código: {nuevaMascota.Codigo}");
    }

    static void GestionarPacientes()
    {
        if (veterinaria.CantidadPacientes() == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }

        veterinaria.ListarCodigos();
        string codigo = MenuConsola.LeerTexto("Ingrese el código del paciente: ");
        Mascota mascota = veterinaria.BuscarPorCodigo(codigo);

        if (mascota == null)
        {
            Console.WriteLine("No se encontró ningún paciente con ese código.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("1. Cambiar estado");
        Console.WriteLine("2. Calcular dosis de medicamento");
        Console.WriteLine("3. Ver información");
        int opcion = MenuConsola.LeerOpcion("Seleccione una opción: ", 1, 3);

        switch (opcion)
        {
            case 1:
                mascota.CambiarEstado();
                Console.WriteLine("Estado actualizado.");
                break;
            case 2:
                double dosisPorKg = MenuConsola.LeerDouble("Dosis por Kg (mg/kg): ");
                Console.WriteLine($"Dosis a administrar: {mascota.CalcularDosis(dosisPorKg)} mg");
                break;
            case 3:
                mascota.MostrarInformacion();
                break;
        }
    }
}