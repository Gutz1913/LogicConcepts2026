using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::: EJERCICIO DE DESCOMPOSICIÓN EN FACTORES PRIMOS :::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        var number = ConsoleExtension.GetInt("Ingrese el número a descomponer: ");

        List<int> factors = GetPrimeFactors(number);

        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.Write($"{number} = ");

        for (int i = 0; i < factors.Count; i++)
        {
            Console.Write(factors[i]);
            if (i < factors.Count - 1)
            {
                Console.Write(" x ");
            }
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
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

List<int> GetPrimeFactors(int number)
{
    List<int> factors = new List<int>();

    while (number % 2 == 0)
    {
        factors.Add(2);
        number /= 2;
    }

    for (int i = 3; i * i <= number; i += 2)
    {
        while (number % i == 0)
        {
            factors.Add(i);
            number /= i;
        }
    }

    if (number > 2)
    {
        factors.Add(number);
    }
    return factors;
}
