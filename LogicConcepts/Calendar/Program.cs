using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
        Console.WriteLine(":::::::::::::::: CALENDARIO :::::::::::::::");
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
        var year = ConsoleExtension.GetInt("Ingrese el año: ");
        Console.Clear();

        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;

        ShowCalendar(year);

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?..................: ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");

void ShowCalendar(int year)
{
    Console.WriteLine($"***** AÑO: {year} *****");

    List<string> months = ["ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"];
    int i = 1;
    foreach (var month in months)
    {
        Console.WriteLine();
        Console.WriteLine($"{month}");
        Console.WriteLine("Dom\tLun\tMar\tMie\tJue\tVie\tSab\t");
        var daysPerMonth = GetDaysPerMonth(year, i);
        var zeller = Zeller(year, i);
        var daysCounter = 0;
        for (int j = 0; j < zeller; j++)
        {
            Console.Write("\t");
            daysCounter++;
        }

        for (int day = 1; day <= daysPerMonth; day++)
        {
            Console.Write($"{day}\t");
            daysCounter++;
            if (daysCounter == 7)
            {
                daysCounter = 0;
                Console.WriteLine();
            }
        }
        Console.WriteLine();
        i++;
    }
}

int GetDaysPerMonth(int year, int month)
{
    if (month == 2 && DateUtilities.IsLeapYear(year))
    {
        return 29;
    }

    List<int> daysPerMonth = [0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    return daysPerMonth.ElementAt(month);
}

int Zeller(int year, int month)
{
    int a = (14 - month) / 12;
    int y = year - a;
    int m = month + 12 * a - 2;
    int day = 1, d;
    d = (day + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;
    return (d);
}