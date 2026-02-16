using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: EJERCICIO DE NÓMINA SENCILLA :::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var name = ConsoleExtension.GetString("Ingrese el nombre...................: ");
        var workHours = ConsoleExtension.GetFloat("Ingrese número de horas trabajadas..: ");
        var hourValue = ConsoleExtension.GetDecimal("Ingrese valor de la hora............: ");
        var minimumSalary = ConsoleExtension.GetDecimal("Ingrese valor salario mínimo mensual: ");

        var salary = (decimal)workHours * hourValue;
        if (salary < minimumSalary)
        {
            Console.WriteLine($"Nombre..............................: {name}");
            Console.WriteLine($"Salario.............................: {minimumSalary,20:C2}");
        }
        else
        {
            Console.WriteLine($"Nombre..............................: {name}");
            Console.WriteLine($"Salario.............................: {salary,20:C2}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?........: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");