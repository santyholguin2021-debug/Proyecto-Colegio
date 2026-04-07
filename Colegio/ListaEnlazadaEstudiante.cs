    public class ListaEnlazadaEstudiantes
    {
        private Nodo<Estudiante>? cabeza;
        private Nodo<Estudiante>? ultimo;
        private int cantidad;
        private int idAutoIncrementable = 1;

        public ListaEnlazadaEstudiantes()
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

        // Agregar estudiante con parámetros individuales
        public void Agregar(string nombre, string apellido, string direccion, string celular, string email)
        {
            Estudiante nuevoEstudiante = new Estudiante(idAutoIncrementable++, nombre, apellido, direccion, celular, email);
            Agregar(nuevoEstudiante);
        }

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
        public Estudiante? Buscar(int id)
        {
            Nodo<Estudiante>? actual = cabeza;
            while (actual != null)
            {
                if (actual.Valor != null && actual.Valor.Id == id)
                {
                    return actual.Valor;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        // Listar estudiantes
        public void Listar()
        {
            if (EstaVacio())
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            Nodo<Estudiante>? actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Valor?.ToString());
                actual = actual.Siguiente;
            }
        }

        // Eliminar estudiante por código
        public bool Eliminar(int id)
        {
            if (cabeza == null) return false;

            if (cabeza.Valor != null && cabeza.Valor.Id == id)
            {
                cabeza = cabeza.Siguiente;
                cantidad--;
                return true;
            }

            Nodo<Estudiante>? actual = cabeza;
            while (actual?.Siguiente != null)
            {
                if (actual.Siguiente.Valor != null && actual.Siguiente.Valor.Id == id)
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
