using Shared;

var response = string.Empty;
do
{
    try
    {
        var number = ConsoleExtension.GetInt("Ingrese un número entero para saber si es par o impar: ");
        if (number % 2 == 0)
        {
            Console.WriteLine($"El número {number} es par.");
        }
        else
        {
            Console.WriteLine($"El número {number} es impar.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.Write("¿Desea continuar? (S/N): ");
    response = Console.ReadLine()!.ToUpper();
} while (response == "S");
Console.WriteLine("\n :::::::::: GAME OVER :::::::::: \n");