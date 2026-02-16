using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: EJERCICIO DE NÚMEROS PARES E IMPARES :::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var number = ConsoleExtension.GetInt("Ingrese un número entero....: ");
        if (number % 2 == 0)
        {
            Console.WriteLine($"El número {number}, es par.");
        }
        else
        {
            Console.WriteLine($"El número {number}, es impar.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");