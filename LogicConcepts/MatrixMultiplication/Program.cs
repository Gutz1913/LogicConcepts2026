using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: EJERCICIO MULTIPLICACIÓN DE MATRICES :::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        var m = ConsoleExtension.GetInt("Ingrese el valor de m: ");
        var n = ConsoleExtension.GetInt("Ingrese el valor de n: ");
        var p = ConsoleExtension.GetInt("Ingrese el valor de p: ");

        int[,] a = new int[m, n];
        int[,] b = new int[n, p];
        int[,] c = new int[m, p];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                a[i, j] = (i + 1) * j;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < p; j++)
            {
                b[i, j] = (j + 1) * i;
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < p; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    c[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        Console.WriteLine("*** A ***");
        Show(a, m, n);
        Console.WriteLine("*** B ***");
        Show(b, n, p);
        Console.WriteLine("*** C ***");
        Show(c, m, p);
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

static void Show(int [,] m, int f, int c)
{
    for (int i = 0; i < f; i++)
    {
        for (int j = 0; j < c; j++)
        {
            Console.Write($"{m[i, j]}\t");
        }
        Console.WriteLine();
    }
}
