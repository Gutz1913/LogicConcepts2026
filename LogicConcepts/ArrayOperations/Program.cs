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
        Console.WriteLine("::: EJERCICIO OPERACIONES EN UN ARREGLO :::");
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
        var n = ConsoleExtension.GetInt("Cuantas posiciones quieres en el arreglo: ");
        var vectorNumbers = new int[n];

        FillArray(vectorNumbers);
        //var sum = GetSum(vectorNumbers);

        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;

        ShowArray(vectorNumbers);
        Console.WriteLine($"La sumatoria es..........: {vectorNumbers.Sum(),10:N0}");
        Console.WriteLine($"El promedio es..........: {vectorNumbers.Average(),10:N2}");

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

//double GetSum(int[] vectorNumbers)
//{
//    var sum = 0;
//    foreach (var number in vectorNumbers)
//    {
//        sum += number;
//    }
//    return sum;
//}

void FillArray(int[] vectorNumbers)
{
    var random = new Random();
    for (int i = 0; i < vectorNumbers.Length; i++)
    {
        vectorNumbers[i] = random.Next(0, 100);
    }
}

void ShowArray(int[] vectorNumbers)
{
    foreach (var number in vectorNumbers)
    {
        Console.Write($"{number,10:N0}");
    }
    Console.WriteLine();
}