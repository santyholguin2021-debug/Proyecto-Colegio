using System;

class Program
{
    static ListaEnlazadaEstudiantes sistema = new ListaEnlazadaEstudiantes();

    static void Main(string[] args)
    {
        EjecutarMenu();
    }

    static void EjecutarMenu()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("\n===== SISTEMA DE ESTUDIANTES =====");
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Mostrar estudiantes");
            Console.WriteLine("3. Consultar estudiante");
            Console.WriteLine("4. Eliminar estudiante");
            Console.WriteLine("5. Administrar materias");
            Console.WriteLine("6. Salir");

            opcion = LeerEntero("Seleccione una opción: ");

            switch (opcion)
            {
                case 1:
                    RegistrarEstudiante();
                    break;

                case 2:
                    sistema.Listar();
                    break;

                case 3:
                    BuscarEstudiante();
                    break;

                case 4:
                    EliminarEstudiante();
                    break;

                case 5:
                    MenuMaterias();
                    break;

                case 6:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

        } while (opcion != 6);
    }

    // FUNCIONES DE ESTUDIANTES

    static void RegistrarEstudiante()
    {
        Console.WriteLine("\n===== Nuevo Estudiante =====");

        string nombre = LeerTexto("Nombre: ");
        string apellido = LeerTexto("Apellido: ");
        string direccion = LeerTexto("Dirección: ");
        string celular = LeerTelefono("Celular: ");
        string email = LeerTexto("Email: ");

        sistema.Agregar(nombre, apellido, direccion, celular, email);
    }

    static void BuscarEstudiante()
    {
        if (sistema.EstaVacio())
        {
            Console.WriteLine("Vacío, agrega algo...");
            return;
        }

        int id = LeerEntero("Ingrese id: ");

        var estudiante = sistema.Buscar(id);

        if (estudiante != null)
        {
            Console.WriteLine("\nEstudiante encontrado:");
            Console.WriteLine($"{estudiante.Nombre} {estudiante.Apellido}");
            Console.WriteLine($"Email: {estudiante.Email}");
        }
        else
        {
            Console.WriteLine("No existe el estudiante.");
        }
    }

    static void EliminarEstudiante()
    {
        int id = LeerEntero("Id a eliminar: ");

        sistema.Eliminar(id);
        Console.WriteLine("Estudiante eliminado exitosamente.");
    }

    // FUNCIONES DE MATERIAS

    static void MenuMaterias()
    {
        int id = LeerEntero("Ingrese id del estudiante: ");

        var estudiante = sistema.Buscar(id);

        if (estudiante == null)
        {
            Console.WriteLine("Estudiante no encontrado.");
            return;
        }

        int opcion = 0;

        do
        {
            Console.WriteLine($"\n===== Materias de {estudiante.Nombre} =====");
            Console.WriteLine("1. Agregar materia");
            Console.WriteLine("2. Ver materias");
            Console.WriteLine("3. Cambiar nota");
            Console.WriteLine("4. Quitar materia");
            Console.WriteLine("5. Volver");

            opcion = LeerEntero("Opción: ");

            switch (opcion)
            {
                case 1:
                    AgregarMateria(estudiante);
                    break;

                case 2:
                    estudiante.materias.Listar();
                    break;

                case 3:
                    if (estudiante.materias.EstaVacio())
                    {
                        Console.WriteLine("Vacío, agrega algo...");
                        break;
                    }
                    ModificarNota(estudiante);
                    break;

                case 4:
                    if (estudiante.materias.EstaVacio())
                    {
                        Console.WriteLine("Vacío, agrega algo...");
                        break;
                    }
                    EliminarMateria(estudiante);
                    break;

                case 5:
                    Console.WriteLine("Volviendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

        } while (opcion != 5);
    }

    static void AgregarMateria(Estudiante est)
    {
        string nombre = LeerTexto("Nombre materia: ");
        double nota = LeerDoubleValidado("Nota (0 a 5): ");

        if (!est.materias.Agregar(nombre, nota))
        {
            Console.WriteLine("Error: Esta materia ya está registrada para este estudiante.");
        }
        else
        {
            Console.WriteLine("Materia agregada exitosamente.");
        }
    }

    static void ModificarNota(Estudiante est)
    {
        string nombre = LeerTexto("Materia a modificar: ");
        double nota = LeerDoubleValidado("Nueva nota (0 a 5): ");

        est.materias.EditarNota(nombre, nota);
    }

    static void EliminarMateria(Estudiante est)
    {
        string nombre = LeerTexto("Materia a eliminar: ");

        est.materias.Eliminar(nombre);
        Console.WriteLine("Materia eliminada exitosamente.");
    }

    static string LeerTexto(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? entrada = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entrada))
                return entrada.Trim();
            Console.WriteLine("Entrada inválida. Intente de nuevo.");
        }
    }

    static int LeerEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            string? entrada = Console.ReadLine();
            if (int.TryParse(entrada, out valor))
                return valor;
            Console.WriteLine("Entrada inválida. Intente de nuevo.");
        }
    }

    static double LeerDouble(string mensaje)
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            string? entrada = Console.ReadLine();
            if (double.TryParse(entrada, out valor))
                return valor;
            Console.WriteLine("Entrada inválida. Intente de nuevo.");
        }
    }

    static double LeerDoubleValidado(string mensaje)
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            string? entrada = Console.ReadLine();
            if (double.TryParse(entrada, out valor) && valor >= 0 && valor <= 5)
                return valor;
            Console.WriteLine("Nota inválida. Ingrese un valor entre 0 y 5.");
        }
    }

    static string LeerTelefono(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? entrada = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entrada) && entrada.All(char.IsDigit))
                return entrada.Trim();
            Console.WriteLine("Teléfono inválido. Ingrese solo números sin espacios.");
        }
    }
}
