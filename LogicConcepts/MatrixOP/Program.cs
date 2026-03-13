using Shared;

var response = string.Empty;
do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        var n = ConsoleExtension.GetInt("Ingrese orden de la matriz: ");
        int[,] matrix = new int[n, n];
        int sum = 0;
        int max = int.MinValue;
        int min = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int value = (i + 1) - j;
                matrix[i, j] = value;
                sum += value;

                if (value > max) max = value;
                if (value < min) min = value;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j].ToString().PadRight(6));
            }
            Console.WriteLine();
        }
        Console.WriteLine($"La sumatoriaes: {sum}");
        Console.WriteLine($"El valor máximo es: {max}");
        Console.WriteLine($"El valor mínimo es: {min}");
        Console.WriteLine();
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
