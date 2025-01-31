namespace Models;

public class RegistroPedido : Producto {
    private List<(Producto, int)> productos;
    public static int nextId = 1;
    public new int Id { get; private set;} 
    public bool Pagado { get; set; }
    public DateTime Registro { get; set; }

    public RegistroPedido(string nombre, double precio) : base(nombre, precio) {
        productos = new List<(Producto, int)>();
        Registro = DateTime.Now;
        Id = nextId++;
    }

    public void AgregarProducto(Producto producto, int cantidad) {
        productos.Add((producto, cantidad));
    }

    public double CalcularTotal() {
        double total = 0;
        foreach (var (producto, cantidad) in productos) {
            total += producto.Precio * cantidad;
        }
        return total;
    }
}
