using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":: EJERCICIO TRIANGULAR INFERIOR DE UNA MATRIZ ::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        var n = ConsoleExtension.GetInt("Ingrese orden de la matriz: ");
        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = i + j;
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

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
