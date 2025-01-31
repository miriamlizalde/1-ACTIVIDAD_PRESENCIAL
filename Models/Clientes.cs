using Models;
public class Clientes {
    public static int nextId = 1;
    public int Id {get; private set;}
    public string Nombre {get;set;}
    public string Telefono {get;set;}

    public Clientes(int id, string nombre, string telefono) {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
    }



}