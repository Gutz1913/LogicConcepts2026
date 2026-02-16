using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: EJERCICIO DE DESCUENTOS :::::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var desks = ConsoleExtension.GetInt("Número de escritorios.......: ");
        var valueToPay = CalculateValue(desks);
        Console.WriteLine($"El valor a pagar es.........: {valueToPay,20:C2} ");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");

decimal CalculateValue(int desks)
{
    float discount;
    if (desks < 5)
    {
        discount = 0.1f;
    }
    else if (desks >= 5 && desks < 10)
    {
        discount = 0.2f;
    }
    else
    {
        discount = 0.4f;
    }

    return desks * 650000M * (decimal)(1 - discount);
}