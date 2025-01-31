using Microsoft.Net.Http.Headers;
namespace Models;
 class RegistroPedido : Producto{
    private List<(Producto, int)> productos;
    private Clientes Clientes{get;set;}
    public static int Identificador {get; private set;} = 0;
    public int ID {get; set;} = 0;
    public bool Pagado {get;set;}
    public DateTime Registro{get;private set;}

    public RegistroPedido(Clientes cliente) {
        productos = new List<(Producto,int)>();
        Clientes = clientes;
        Registro = DateTime.Now;
        Identificador++;
        ID = Identificador;
    }

    public double CalcularTotal(){
        double total = 0;
        foreach(var(producto, cantidad) in productos) {
            total += producto.Precio * cantidad;
        }
        return total;
    }


}