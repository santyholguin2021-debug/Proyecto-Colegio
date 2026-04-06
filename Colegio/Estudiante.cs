public class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string celular { get; set; }
    public string email { get; set; }

 // Constructor con todos los atributos//
        public Estudiante(int Id, string nombre, string apellido, string direccion, string celular, string email)
        {
            this.Codigo = Id;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Direccion = Direccion;
            this.Celular = celular;
            this.email = email;
        }

        // Método ToString
        public override string ToString()
        {
            return $"Estudiante: {this.Nombre} {this.Apellido}, id: {this.Id}, Dirección: {this.Direccion}, Celular: {this.celular}, email: {this.email}";
        }
    }


