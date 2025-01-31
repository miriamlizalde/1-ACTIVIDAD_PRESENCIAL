using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
using Models;
public class Bebidas : Producto {
    public static int nextId = 1;
    public int Id {get ; private set;}
    public bool EsDescafeinado {get;set;}

    public Bebidas(string nombre, double precio, bool esDescafeinado) : base(nombre, precio) {
        Id = nextId++;
        EsDescafeinado = esDescafeinado;

    }

    

}