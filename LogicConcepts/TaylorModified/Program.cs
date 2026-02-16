using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::: EJERCICIO SERIE DE TAYLOR MODIFICADA ::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var n = ConsoleExtension.GetInt("Número de términos: ");
        var x = ConsoleExtension.GetDouble("Valor de x........: ");
        var taylor = TaylorModified(x, n);
        Console.WriteLine($"f({x}) = {taylor:N5} ");
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
double TaylorModified(double x, int n)
{
    double sum = 0;
    int signo = 1;
    for (int i = 0; i < n; i++)
    {
        sum += Math.Pow(x, i) / MyMath.Factorial(i) * signo;
        signo *= -1;
    }
    return sum;
}