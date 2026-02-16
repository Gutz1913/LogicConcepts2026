using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: EJERCICIO 2 DE NÚMEROS PRIMOS ::::::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var n = ConsoleExtension.GetInt("Cuantos números primos quieres: ");
        var primes = GetPrimes(n);
        foreach (var prime in primes)
        {
            Console.Write($"{prime,10:N0}");
        }
        Console.WriteLine();
        Console.WriteLine($"La sumatoria es..................: {primes.Sum(),10:N0}");
        Console.WriteLine($"El promedio es...................: {primes.Average(),10:N2}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?.....: ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");

List<int> GetPrimes(int n)
{
    var primes = new List<int>();
    var num = 2;
    while (primes.Count < n)
    {
        if (MyMath.IsPrime(num))
        {
            primes.Add(num);
        }
        num++;
    }
    return primes;
}