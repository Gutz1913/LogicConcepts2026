using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::::::::: EJERCICIO DEL DIAMANTE ::::::::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        var n = ConsoleExtension.GetInt("Ingrese el tamaño del diamante: ");

        char[,] diamond = new char[n, n];

        //Llenar la matriz con espacios en blanco
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                diamond[i, j] = ' ';
            }
        }

        //Llenar la matriz con asteriscos para formar el diamante
        var half = n / 2;
        for (int i = 0; i <= half; i++)
        {
            diamond[i, half - i] = '*';
            diamond[i, half + i] = '*';
            diamond[n - i - 1, half - i] = '*';
            diamond[n - i - 1, half + i] = '*';
        }

        //Mostramos el diamante
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(diamond[i, j]);
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
