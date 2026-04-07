public class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }
    public ListaEnlazadaMaterias materias { get; set; }

    // Constructor con todos los atributos
    public Estudiante(int Id, string nombre, string apellido, string direccion, string celular, string email)
    {
        this.Id = Id;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Direccion = direccion;
        this.Celular = celular;
        this.Email = email;
        this.materias = new ListaEnlazadaMaterias();
    }

    // Método ToString
    public override string ToString()
    {
        return $"Estudiante: {this.Nombre} {this.Apellido}, id: {this.Id}, Dirección: {this.Direccion}, Celular: {this.Celular}, Email: {this.Email}";
    }
}


