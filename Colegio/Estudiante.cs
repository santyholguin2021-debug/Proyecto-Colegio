public class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; get; }
    public string celular { get; set; }
    public string Correo { get; set; }

 // Constructor con todos los atributos//
        public Estudiante(int codigo, string nombre, string apellido, string direccion, string celular, string email)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Celular = celular;
            this.Email = Correo;
        }

        // Método ToString
        public override string ToString()
        {
            return $"Estudiante: {this.Nombre} {this.Apellido}, Código: {this.Codigo}, Dirección: {this.Direccion}, Celular: {this.Celular}, Email: {this.Email}";
        }
    }


