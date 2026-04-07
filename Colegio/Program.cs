using System;

class Program
{
    static ListaEstudiantes sistema = new ListaEstudiantes();

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
        string celular = LeerTexto("Celular: ");
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

        int codigo = LeerEntero("Ingrese código: ");

        var estudiante = sistema.Buscar(codigo);

        if (estudiante != null)
        {
            Console.WriteLine("\nEstudiante encontrado:");
            Console.WriteLine($"{estudiante.nombre} {estudiante.apellido}");
            Console.WriteLine($"Email: {estudiante.email}");
        }
        else
        {
            Console.WriteLine("No existe el estudiante.");
        }
    }

    static void EliminarEstudiante()
    {
        int codigo = LeerEntero("Código a eliminar: ");

        sistema.Eliminar(codigo);
        Console.WriteLine("Proceso finalizado.");
    }

    // FUNCIONES DE MATERIAS

    static void MenuMaterias()
    {
        int codigo = LeerEntero("Ingrese código del estudiante: ");

        var estudiante = sistema.Buscar(codigo);

        if (estudiante == null)
        {
            Console.WriteLine("Estudiante no encontrado.");
            return;
        }

        int opcion = 0;

        do
        {
            Console.WriteLine($"\n===== Materias de {estudiante.nombre} =====");
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

    static void AgregarMateria(NodoEstudiante est)
    {
        string nombre = LeerTexto("Nombre materia: ");
        double nota = LeerDouble("Nota: ");

        est.materias.Agregar(nombre, nota);
    }

    static void ModificarNota(NodoEstudiante est)
    {
        string nombre = LeerTexto("Materia a modificar: ");
        double nota = LeerDouble("Nueva nota: ");

        est.materias.EditarNota(nombre, nota);
    }

    static void EliminarMateria(NodoEstudiante est)
    {
        string nombre = LeerTexto("Materia a eliminar: ");

        est.materias.Eliminar(nombre);
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
}
