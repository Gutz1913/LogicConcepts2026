using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::::::::: EJERCICIO RELOJ DE ARENA :::::::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        var n = ConsoleExtension.GetInt("Ingrese orden de la matriz: ");

        int[,] m = new int[n, n];

        Console.WriteLine("MATRIZ COMPLETA");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                m[i, j] = (i * 2) + j;
                Console.Write($"{m[i, j]}\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        //Declaramos e inicializamos la matriz auxiliar
        string[,] a = new string[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                a[i, j] = "";
            }
        }

        //Rellenamos la matriz auxiliar con el reloj de arena
        var x = (n / 2) + 1;
        for (int i = 0; i < x; i++)
        {
            for (int j = i; j < n - i; j++)
            {
                a[i, j] = m[i, j].ToString();
                a[n - i - 1, j] = m[n - i - 1, j].ToString();
            }
        }

        //Mostramos como queda el reloj de arena
        Console.WriteLine("RELOJ DE ARENA");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{a[i, j]}\t");
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
