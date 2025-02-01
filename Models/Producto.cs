public abstract class Producto{
    public int Id {get;set;}
    public string Nombre {get;set;}
    public double Precio {get;set;}

    public Producto(string nombre, double precio) {
        Nombre = nombre;
        Precio = precio;

        if(precio < 0) {
            throw new ArgumentException("El precio no puede ser negativo");
        }
        if (String.IsNullOrWhiteSpace(nombre)) {
            throw new ArgumentException("El nombre no puede estar vacio");
        }

    }
 }

