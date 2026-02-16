using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::::: EJERCICIO SERIE FIBONACCI ::::::::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var n = ConsoleExtension.GetInt("Cuantos términos quiere (mínimo 2): ");
        double a = 0;
        double b = 1;

        Console.Write($"{a:N0}\t{b:N0}\t");

        for (int i = 2; i < n; i++)
        {
            double c = a + b;
            Console.Write($"{c:N0}\t");
            a = b;
            b = c;
        }
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?.....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");