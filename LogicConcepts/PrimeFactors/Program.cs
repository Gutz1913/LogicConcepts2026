using Shared;

var response = string.Empty;
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

    Console.Write("¿Desea continuar? (S/N): ");
    response = Console.ReadLine()!.ToUpper();
    Console.WriteLine();
} while (response == "S");

Console.WriteLine("\n :::::::::: GAME OVER :::::::::: \n");

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
