using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
        Console.WriteLine(":::::::::::: EJERCICIO NÚMERO E :::::::::::");
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
        var n = ConsoleExtension.GetInt("Cuantos términos de precisión desea: ");

        var e = CalculateE(n);

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"El valor de 'e' con {n} términos de precisión es: {e}");

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?..................: ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");

double CalculateE(int n)
{
    double sum = 0;
    for (int i = 0; i < n; i++)
    {
        sum += 1 / MyMath.Factorial(i);
    }
    return sum;
}