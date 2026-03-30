    public class NodoEstudiante
    {
        // Atributos
        public Estudiante Estudiante { get; set; }
        public NodoEstudiante Siguiente { get; set; }
        
        // Constructor lleno
        public NodoEstudiante(Estudiante estudiante)
        {
            this.Estudiante = estudiante;
            this.Siguiente = null;
        }

        // ToString para mostrar el estudiante contenido en el nodo
        public override string ToString()
        {
            return Estudiante != null ? Estudiante.ToString() : "Nodo vacío";
        }
    }
