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
        Console.WriteLine(": EJERCICIO PARES E IMPARES EN UN ARREGLO :");
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
        var n = ConsoleExtension.GetInt("Cuantas posiciones quieres en el arreglo: ");
        var vectorNumbers = new int[n];

        FillArray(vectorNumbers);
        var sum = GetSumEven(vectorNumbers);
        var prod = GetProdOdd(vectorNumbers);

        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;

        ShowArray(vectorNumbers);
        Console.WriteLine($"La sumatoria de los números pares es..........: {sum,10:N0}");
        Console.WriteLine($"La productoria de los números impares es......: {prod,10:N0}");

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

double GetProdOdd(int[] vectorNumbers)
{
    double prod = 1;
    foreach (var number in vectorNumbers)
    {
        if (number % 2 != 0)
        {
            prod *= number;
        }
    }
    return prod;
}

int GetSumEven(int[] vectorNumbers)
{
    var sum = 0;
    foreach (var number in vectorNumbers)
    {
        if (number % 2 == 0)
        {
            sum += number;
        }
    }
    return sum;
}

void ShowArray(int[] vectorNumbers)
{
    foreach (var number in vectorNumbers)
    {
        Console.Write($"{number,10:N0}");
    }
    Console.WriteLine();
}

void FillArray(int[] vectorNumbers)
{
    var random = new Random();
    for (int i = 0; i < vectorNumbers.Length; i++)
    {
        vectorNumbers[i] = random.Next(0, 100);
    }
}