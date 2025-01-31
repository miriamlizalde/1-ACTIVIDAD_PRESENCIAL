using Models;

class InvalidIngredientesException : Exception{
    public InvalidIngredientesException(String message = ""): base(message){}
}

public class Comida : Producto {
    public static int nextId = 1;
    public int Id {get; private set;}
    public bool ConGluten {get;set;}

    public string Ingredientes {get;set;}

    public Comida(string nombre, double precio, bool conGluten, string ingredientes): base (nombre,precio){
        Id = nextId++;
        ConGluten = conGluten;
        Ingredientes = ingredientes;
        if (string.IsNullOrEmpty(ingredientes)) {
            throw new InvalidIngredientesException("Los ingredientes no pueden estar vacios");
        }
    }
}