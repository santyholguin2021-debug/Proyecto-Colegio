    public class ListaEnlazadaEstudiantes
    {
        private Nodo<Estudiante>? cabeza;
        private Nodo<Estudiante>? ultimo;
        private int cantidad;

        public ListaEnlazadaEstudiantes()
        {
            this.cabeza = null;
            this.ultimo = null;
            this.cantidad = 0;
        }

        public int Cantidad => cantidad;

        // Agregar estudiante al final
        public void Agregar(Estudiante estudiante)
        {
            Nodo<Estudiante> nuevo = new Nodo<Estudiante>(estudiante);
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
        }

        // Buscar estudiante por código
        public Estudiante? Buscar(int codigo)
        {
            Nodo<Estudiante>? actual = cabeza;
            while (actual != null)
            {
                if (actual.Valor != null && actual.Valor.Codigo == codigo)
                {
                    return actual.Valor;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        // Listar estudiantes
        public void Imprimir()
        {
            Nodo<Estudiante>? actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Valor?.ToString());
                actual = actual.Siguiente;
            }
        }

        // Eliminar estudiante por código
        public bool Eliminar(int codigo)
        {
            if (cabeza == null) return false;

            if (cabeza.Valor != null && cabeza.Valor.Codigo == codigo)
            {
                cabeza = cabeza.Siguiente;
                cantidad--;
                return true;
            }

            Nodo<Estudiante>? actual = cabeza;
            while (actual?.Siguiente != null)
            {
                if (actual.Siguiente.Valor != null && actual.Siguiente.Valor.Codigo == codigo)
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
