using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::::: EJERCICIO DE SUMA Y PROMEDIO ::::::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var n = ConsoleExtension.GetInt("Cuantos números desea: ");
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"{i}\t");
            sum += i;
        }
        var average = sum / n;
        Console.WriteLine();
        Console.WriteLine($"La suma es.......................: {sum,10:N0}");
        Console.WriteLine($"El promedio es...................: {average,10:N0}");
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