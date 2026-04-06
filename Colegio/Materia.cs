public class Materia
{
    public string NombreMateria { get; set; }
    public double Nota { get; set; }

        // Constructor 
        public Materia(string nombreMateria, double nota)
        {
            this.NombreMateria = nombreMateria;
            this.Nota = nota;
        }

        // Método ToString
        public override string ToString()
        {
            return $"Materia: {this.NombreMateria}, Nota: {this.Nota}";
        }
    }

