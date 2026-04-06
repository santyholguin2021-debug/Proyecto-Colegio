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

            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

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

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();

        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        Console.Write("Celular: ");
        string celular = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        sistema.Agregar(nombre, apellido, direccion, celular, email);
    }

    static void BuscarEstudiante()
    {
        Console.Write("Ingrese código: ");
        int codigo = Convert.ToInt32(Console.ReadLine());

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
        Console.Write("Código a eliminar: ");
        int codigo = Convert.ToInt32(Console.ReadLine());

        sistema.Eliminar(codigo);
        Console.WriteLine("Proceso finalizado.");
    }

    // FUNCIONES DE MATERIAS

    static void MenuMaterias()
    {
        Console.Write("Ingrese código del estudiante: ");
        int codigo = Convert.ToInt32(Console.ReadLine());

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

            Console.Write("Opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarMateria(estudiante);
                    break;

                case 2:
                    estudiante.materias.Listar();
                    break;

                case 3:
                    ModificarNota(estudiante);
                    break;

                case 4:
                    EliminarMateria(estudiante);
                    break;
            }

        } while (opcion != 5);
    }

    static void AgregarMateria(NodoEstudiante est)
    {
        Console.Write("Nombre materia: ");
        string nombre = Console.ReadLine();

        Console.Write("Nota: ");
        double nota = Convert.ToDouble(Console.ReadLine());

        est.materias.Agregar(nombre, nota);
    }

    static void ModificarNota(NodoEstudiante est)
    {
        Console.Write("Materia a modificar: ");
        string nombre = Console.ReadLine();

        Console.Write("Nueva nota: ");
        double nota = Convert.ToDouble(Console.ReadLine());

        est.materias.EditarNota(nombre, nota);
    }

    static void EliminarMateria(NodoEstudiante est)
    {
        Console.Write("Materia a eliminar: ");
        string nombre = Console.ReadLine();

        est.materias.Eliminar(nombre);
    }
}
