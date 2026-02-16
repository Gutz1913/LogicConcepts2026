using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: EJERCICIO DE ORDENAR NÚMEROS :::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var number1 = ConsoleExtension.GetInt("Ingrese el primer número....: ");
        var number2 = ConsoleExtension.GetInt("Ingrese el segundo número...: ");
        var number3 = ConsoleExtension.GetInt("Ingrese el tercer número....: ");

        if (number1 == number2 || number1 == number3 || number2 == number3)
        {
            Console.WriteLine("Los números deben ser diferentes entre sí, Intente de nuevo.");
            continue;
        }

        if (number1 > number2 && number1 > number3)
        {
            if (number2 > number3)
            {
                Console.WriteLine($"El mayor es {number1}, el medio es {number2}, el menor es {number3}");
            }
            else
            {
                Console.WriteLine($"El mayor es {number1}, el medio es {number3}, el menor es {number2}");
            }
        }
        else if (number2 > number1 && number2 > number3)
        {
            if (number1 > number3)
            {
                Console.WriteLine($"El mayor es {number2}, el medio es {number1}, el menor es {number3}");
            }
            else
            {
                Console.WriteLine($"El mayor es {number2}, el medio es {number3}, el menor es {number1}");
            }
        }
        else
        {
            if (number1 > number2)
            {
                Console.WriteLine($"El mayor es {number3}, el medio es {number1}, el menor es {number2}");
            }
            else
            {
                Console.WriteLine($"El mayor es {number3} , el medio es  {number2} , el menor es {number1}");
            }
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