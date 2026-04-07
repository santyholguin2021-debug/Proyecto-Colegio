public class ListaEnlazadaMaterias
{
    private Nodo<Materia>? cabeza;
    private Nodo<Materia>? ultimo;
    private int cantidad;

    public ListaEnlazadaMaterias()
    {
        this.cabeza = null;
        this.ultimo = null;
        this.cantidad = 0;
    }

    public int Cantidad => cantidad;

    // Verificar si la lista está vacía
    public bool EstaVacio()
    {
        return cantidad == 0;
    }

    // Agregar materia al final
    public bool Agregar(string nombreMateria, double nota)
    {
        // Verificar si la materia ya existe
        if (Buscar(nombreMateria) != null)
        {
            return false;
        }

        Materia nuevaMateria = new Materia(nombreMateria, nota);

        Nodo<Materia> nuevo = new Nodo<Materia>(nuevaMateria);
        if (cabeza == null)
        {
            cabeza = nuevo;
            ultimo = nuevo;
        }
        else
        {
            ultimo!.Siguiente = nuevo;
            ultimo = nuevo;
        }
        cantidad++;
        return true;
    }

    // Buscar materia por nombre
    public Materia? Buscar(string nombreMateria)
    {
        Nodo<Materia>? actual = cabeza;
        while (actual != null)
        {
            if (actual.Valor != null && actual.Valor.NombreMateria.Equals(nombreMateria, System.StringComparison.OrdinalIgnoreCase))
            {
                return actual.Valor;
            }
            actual = actual.Siguiente;
        }
        return null;
    }

    // Listar todas las materias
    public void Listar()
    {
        if (EstaVacio())
        {
            Console.WriteLine("No hay materias registradas.");
            return;
        }
        
        Nodo<Materia>? actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine(actual.Valor?.ToString());
            actual = actual.Siguiente;
        }
    }

    // Editar la nota de una materia
    public bool EditarNota(string nombreMateria, double nuevaNota)
    {
        // Validar que la nota esté entre 0 y 5
        if (nuevaNota < 0 || nuevaNota > 5)
        {
            Console.WriteLine("Nota inválida. La nota debe estar entre 0 y 5.");
            return false;
        }

        Nodo<Materia>? actual = cabeza;
        while (actual != null)
        {
            if (actual.Valor != null && actual.Valor.NombreMateria.Equals(nombreMateria, System.StringComparison.OrdinalIgnoreCase))
            {
                actual.Valor.Nota = nuevaNota;
                Console.WriteLine("Nota actualizada exitosamente.");
                return true;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine("Materia no encontrada.");
        return false;
    }

    // Eliminar materia por nombre
    public bool Eliminar(string nombreMateria)
    {
        if (cabeza == null) return false;

        if (cabeza.Valor != null && cabeza.Valor.NombreMateria.Equals(nombreMateria, System.StringComparison.OrdinalIgnoreCase))
        {
            cabeza = cabeza.Siguiente;
            cantidad--;
            return true;
        }

        Nodo<Materia>? actual = cabeza;
        while (actual?.Siguiente != null)
        {
            if (actual.Siguiente.Valor != null && actual.Siguiente.Valor.NombreMateria.Equals(nombreMateria, System.StringComparison.OrdinalIgnoreCase))
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                cantidad--;
                return true;
            }
            actual = actual.Siguiente;
        }
        return false;
    }
}
