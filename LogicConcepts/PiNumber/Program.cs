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
        Console.WriteLine("::::::::::: EJERCICIO NÚMERO PI :::::::::::");
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
        var n = ConsoleExtension.GetInt("Cuantos términos de precisión desea: ");

        var pi = CalculatePi(n);

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"El valor de 'pi' con {n} términos de precisión es: {pi,10}");

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

double CalculatePi(int n)
{
    double sum = 0;
    double den = 1;
    int sign = 1;
    for (int i = 0; i < n; i++)
    {
        double term = 1 / den * sign;
        sum += term;
        den += 2;
        sign *= -1;
    }
    return sum * 4;
}