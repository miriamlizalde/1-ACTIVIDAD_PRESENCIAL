using Models;
public class Clientes {
    public static int nextId = 1;
    public  int Id {get; private set;}
    public string Nombre {get;set;}
    public string Telefono {get;set;}

    public Clientes(string nombre, string telefono) {
        Id = nextId++;
        Nombre = nombre;
        Telefono = telefono;
    }



}