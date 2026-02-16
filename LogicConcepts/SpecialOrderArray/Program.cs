using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::");
        Console.WriteLine("::: EJERCICIO ORDENACIÓN ESPECIAL DE UN ARREGLO :::");
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::");
        var n = ConsoleExtension.GetInt("Cuantas posiciones quieres en el arreglo: ");
        var vectorNumbers = new int[n];
        Console.WriteLine();

        FillArray(vectorNumbers);

        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Arreglo sin ordenar: ");
        ShowArray(vectorNumbers);
        Console.WriteLine();

        var numbersEven = GetNumbersEven(vectorNumbers);
        var numbersOdd = GetNumbersOdd(vectorNumbers);
        Console.WriteLine();
        OrderArray(numbersEven, true);
        OrderArray(numbersOdd);

        Console.WriteLine("Arreglo ordenado: ");
        ShowArray(numbersEven);
        ShowArray(numbersOdd);
        Console.WriteLine();

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

int[] GetNumbersOdd(int[] vectorNumbers)
{
    var countOdds = 0;
    foreach (var number in vectorNumbers)
    {
        if (!IsEven(number))
        {
            countOdds++;
        }
    }

    var numbersOdd = new int[countOdds];
    var i = 0;
    foreach (var number in vectorNumbers)
    {
        if (!IsEven(number))
        {
            numbersOdd[i++] = number;
        }
    }
    return numbersOdd;
}

int[] GetNumbersEven(int[] vectorNumbers)
{
    var countEvens = 0;
    foreach (var number in vectorNumbers)
    {
        if (IsEven(number))
        {
            countEvens++;
        }
    }

    var numbersEven = new int[countEvens];
    var i = 0;
    foreach (var number in vectorNumbers)
    {
        if (IsEven(number))
        {
            numbersEven[i++] = number;
        }
    }
    return numbersEven;
}

bool IsEven(int number)
{
    return number % 2 == 0;
}

void OrderArray(int[] vectorNumbers, bool isDescending = false)
{
    for (int i = 0; i < vectorNumbers.Length - 1; i++)
    {
        for (int j = i + 1; j < vectorNumbers.Length; j++)
        {
            if (isDescending)
            {
                if (vectorNumbers[i] < vectorNumbers[j])
                {
                    Change(ref vectorNumbers[i], ref vectorNumbers[j]);
                }
            }
            else
            {
                if (vectorNumbers[i] > vectorNumbers[j])
                {
                    Change(ref vectorNumbers[i], ref vectorNumbers[j]);
                }
            }
        }
    }
}

void Change(ref int v1, ref int v2)
{
    int aux = v1;
    v1 = v2;
    v2 = aux;
}

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
}