# Sistema de Citas para Veterinaria en C#

Práctica 1 del curso **Introducción a la Programación y Computación 2 (IPC2)**, Universidad de San Carlos de Guatemala, Facultad de Ingeniería.

##### 

##### Descripción

El sistema permite registrar cuatro tipos de mascotas (Perro, Gato, Ave, Tortuga), cada una con atributos propios y un cálculo de dosis de medicamento ajustado según la especie. Cada mascota registrada recibe un código único de 8 caracteres alfanuméricos generado automáticamente.

##### 

##### Funcionalidades

* **Registrar mascota**: alta de un nuevo paciente, eligiendo entre Perro, Gato, Ave o Tortuga, con sus atributos específicos.
* **Gestionar pacientes**:

  * Cambiar estado de salud (enfermo/sano)
  * Calcular dosis de medicamento según peso y especie
  * Consultar información completa del paciente
* Búsqueda de pacientes por código único.
* Navegación mediante menús interactivos

## 

##### Factores de ajuste de dosis por especie



* Perro - 100% (sin Ajuste)
* Gato - 90%
* Ave - 50%
* Tortuga - 80%



La dosis base se calcula como `Peso (kg) × mg/kg indicado`.

##### 

##### Estructura del proyecto



Veterinaria/


├─ Program.cs                  # Punto de entrada y lógica de menús


├─ Veterinaria.csproj


├─ Modelos/


│  ├─ Mascota.cs                # Clase abstracta base


│  ├─ Perro.cs


│  ├─ Gato.cs


│  ├─ Ave.cs


│  └─ Tortuga.cs


├─ Servicios/


│  ├─ Veterinaria.cs            # Lógica de gestión de pacientes


│  └─ MenuConsola.cs            # Utilidades de entrada/salida en consola


└─ Utilidades/


└─ GeneradorCodigo.cs        # Generación de códigos únicos





##### Principios de POO aplicados

* **Abstracción**: `Mascota` es una clase abstracta que define el comportamiento común a toda mascota, sin permitir instanciarla directamente.
* **Herencia**: `Perro`, `Gato`, `Ave` y `Tortuga` heredan de `Mascota` y reutilizan su lógica base mediante `base(...)`.
* **Encapsulamiento**: todos los atributos son privados y se exponen mediante propiedades (`get`/`set`).
* **Polimorfismo**: los métodos `CalcularDosis()` y `MostrarInformacion()` son `virtual` en la clase base y cada especie los sobrescribe (`override`) con su propio comportamiento.



##### Requisitos

* [.NET SDK](https://dotnet.microsoft.com/download) (versión 10.0 o superior)

##### 

##### Cómo ejecutar

Dentro de la Consola/Terminal (CMD):
git clone https://github.com/PRACTICA1\_IPC2N\_202500708.git
cd PRACTICA1\_IPC2N\_202500708/Veterinaria
dotnet run

##### 

##### Autor

David Antonio Meza Silva — 202500708
Sección N — IPC2, USAC

