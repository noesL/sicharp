
// C# --> Lenguaje de tipado estatico 

// Dos maneras de definir variables --> implicito y explicito

int explicitVar = 10;
var implicitVar = 10; // --> el compilador de c# asume el tipo en el momento de compilacion

// reasignar valores, operador =

explicitVar = 20;

// C# tiene programacion orientada a objetos, se usa class como en C++.
// Se crea el constructor dentro de la clase y las instancias se crean con la palabra clave new

class Objeto
{   
    // aqui se crea la clase
    // creando metodo publico dentro de la clase
    public int Sumar(x, y) 
    {
        return x + y;
    }
}

var objeto1 = new Objeto;

//Llamando metodos por fuera de la clase (se puede hacer de ambas maneras)
var suma1 = objeto.Sumar(1, 2);
var suma2 = objeto.Sumar(x: 1, y: 2);

//Sintaxis es muy parecida a C++, en donde se define la scope por las llaves {}


