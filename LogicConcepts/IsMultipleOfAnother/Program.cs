using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: EJERCICIO DE MÚLTIPLOS :::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var number1 = ConsoleExtension.GetInt("Ingrese el primer número....: ");
        var number2 = ConsoleExtension.GetInt("Ingrese el segundo número...: ");
        if (number2 % number1 == 0)
        {
            Console.WriteLine($"{number1} es múltiplo de {number2}");
        }
        else
        {
            Console.WriteLine($"{number1} no es múltiplo de {number2}");
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