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
        MenuConsola.LimpiarPantalla();
        Console.WriteLine();
        Console.WriteLine("====VETERINARIA====");
        Console.WriteLine("1. Registrar mascota");
        Console.WriteLine("2. Gestionar pacientes");
        Console.WriteLine("3. Salir");
        Console.WriteLine();
        Console.WriteLine($"Pacientes registrados: {veterinaria.CantidadPacientes()}");
        Console.WriteLine("=====================");
    }

    static void RegistrarMascota()
    {
        MenuConsola.LimpiarPantalla();
        Console.WriteLine("==== Registrar mascota ====");
        Console.WriteLine("1. Perro  2. Gato  3. Ave  4. Tortuga");
        Console.WriteLine("0. Volver al menú principal");
        int especie = MenuConsola.LeerOpcion("Seleccione especie: ", 0, 4);

        if (especie == 0) return; //Salir de la función si el usuario elige volver al menú principal

        string nombre = MenuConsola.LeerTexto("Nombre: ");
        double peso = MenuConsola.LeerDouble("Peso (kg): ");
        string sexo = MenuConsola.LeerSexo();
        int edad = MenuConsola.LeerEntero("Edad (años): ");
        string propietario = MenuConsola.LeerTexto("Propietario: ");
        bool enfermo = MenuConsola.LeerSiNo("¿Está enfermo?");

        Mascota? nuevaMascota = null;

        switch (especie)
        {
            
            //Perro 
            case 1:
                string raza = MenuConsola.LeerTexto("Raza: ");
                string tamano = MenuConsola.LeerTamano();
                nuevaMascota = new Perro(nombre, peso, sexo, edad, propietario, enfermo, raza, tamano);
                break;
            //Gato
            case 2:
                string razaGato = MenuConsola.LeerTexto("Raza: ");
                bool esterilizado = MenuConsola.LeerSiNo("¿Está esterilizado?");
                nuevaMascota = new Gato(nombre, peso, sexo, edad, propietario, enfermo, razaGato, esterilizado);
                break;
            //Ave
            case 3:
                double envergadura = MenuConsola.LeerDouble("Envergadura de alas (cm): ");
                bool puedeVolar = MenuConsola.LeerSiNo("¿Puede volar?");
                nuevaMascota = new Ave(nombre, peso, sexo, edad, propietario, enfermo, envergadura, puedeVolar);
                break;
            //Tortuga
            case 4:
                string caparazon = MenuConsola.LeerTexto("Tipo de caparazón: ");
                bool esAcuatica = MenuConsola.LeerSiNo("¿Es acuática?");
                nuevaMascota = new Tortuga(nombre, peso, sexo, edad, propietario, enfermo, caparazon, esAcuatica);
                break;
        }

        veterinaria.Registrar(nuevaMascota);
        Console.WriteLine($"Mascota registrada con código: {nuevaMascota.Codigo}");
        MenuConsola.Pausar();
    }   

    static void GestionarPacientes()
    {
        if (veterinaria.CantidadPacientes() == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            MenuConsola.Pausar();
            MenuConsola.LimpiarPantalla();
            return;
        }
        string codigo;
        do
        {
        veterinaria.ListarCodigos();
        codigo = MenuConsola.LeerTexto("Ingrese el código del paciente (Ingrese 0 para salir): ");
        
            if (codigo == "0") return; //Salir de la función si el usuario ingresa 0

        Mascota mascota = veterinaria.BuscarPorCodigo(codigo);
        if (mascota == null)
        {
            Console.WriteLine("No se encontró ningún paciente con ese código.");
            MenuConsola.Pausar();
            continue;
        }
        int opcion;
            do {
                MenuConsola.LimpiarPantalla();
                Console.WriteLine();
                Console.WriteLine($"====MASCOTA ENCONTRADA: {mascota.Nombre} ====");
                Console.WriteLine("1. Cambiar estado de Salud");
                Console.WriteLine("2. Calcular dosis de medicamento");
                Console.WriteLine("3. Ver información completa");

                opcion = MenuConsola.LeerOpcion("Seleccione una opción(Presione 0 para salir): ", 0, 3);

                switch (opcion)
                {
                case 0:
                    break; //Salir de la función si el usuario elige volver al menú principal
                case 1:
                    mascota.CambiarEstado();
                    Console.WriteLine("Estado de salud actualizado.!");
                    MenuConsola.Pausar();
                    break;
                case 2:
                    double dosisPorKg = MenuConsola.LeerDouble("Dosis por Kg (mg/kg): ");
                    Console.WriteLine($"Dosis a administrar: {mascota.CalcularDosis(dosisPorKg)} mg");
                    MenuConsola.Pausar();
                    break;
                case 3:
                    MenuConsola.LimpiarPantalla();
                    Console.WriteLine($"=== Información completa de la mascota: {mascota.Nombre} ===");
                    Console.WriteLine();
                    mascota.MostrarInformacion();
                    MenuConsola.Pausar();
                    break;
                }
            } while (opcion != 0);
        } while (true);
    }
}